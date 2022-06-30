USE [Track]
GO

/****** Object:  StoredProcedure [dbo].[GetJORNEY]    Script Date: 6/30/2022 3:38:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetJORNEY]
(
	@IMEI varchar(50),
	@TIME_BREAKE int
)
AS
BEGIN
-- attempt to run DROP TABLE only if it exists 
DROP TABLE IF EXISTS [dbo].[#Tmp1];

-- calculate time and distance
  SELECT [id]
		,[date_track]
		,[dbo].[calcDistance](
		    [latitude],
			[longitude], 
			LAG([latitude]) OVER(ORDER BY [date_track]), 
			LAG([longitude]) OVER(ORDER BY [date_track])
		    ) AS [DIST_JORNEY]
		,DATEDIFF(MINUTE, LAG([date_track]) OVER(ORDER BY [date_track]), [date_track]) AS [TIME_JORNEY]
		,0 AS ID_JORNEY
  INTO #Tmp1
  FROM [Track].[dbo].[TrackLocation]
  WHERE [IMEI] = @IMEI

  -- grouping using cursor
  DECLARE @JORNEY int = 0;
  DECLARE @ID int;
  DECLARE @TIME_JORNEY int;

  DECLARE TestCursor CURSOR FOR
  SELECT [id], [TIME_JORNEY] 
  FROM #Tmp1
  WHERE [TIME_JORNEY] IS NOT NULL 
	--AND [DIST_JORNEY] > 0
  ORDER BY [date_track]

  OPEN TestCursor

  FETCH NEXT FROM TestCursor INTO @ID, @TIME_JORNEY

  WHILE @@FETCH_STATUS = 0
  BEGIN
	IF (@TIME_JORNEY > @TIME_BREAKE)
		SET @JORNEY += 1;		

	UPDATE #Tmp1 SET [ID_JORNEY] = @JORNEY WHERE [id] = @ID

	FETCH NEXT FROM TestCursor INTO @ID, @TIME_JORNEY
  END

  CLOSE TestCursor
  DEALLOCATE TestCursor


  -- result sums
  SELECT [ID_JORNEY] AS [Id]
        ,SUM([DIST_JORNEY]) AS [Distance]
		,SUM([TIME_JORNEY]) AS [Time]
  FROM #Tmp1
  WHERE [TIME_JORNEY] IS NOT NULL
    --AND [DIST_JORNEY] > 0
  GROUP BY [ID_JORNEY]
  HAVING SUM([DIST_JORNEY]) > 0
  ORDER BY [ID_JORNEY]
END;
GO

