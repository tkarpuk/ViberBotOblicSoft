USE [Track]
GO

/****** Object:  UserDefinedFunction [dbo].[calcDistance]    Script Date: 6/30/2022 3:39:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[calcDistance](@lat DECIMAL(12, 9), @lng DECIMAL(12, 9), @pnt_lat DECIMAL(12, 9), @pnt_lng DECIMAL(12, 9))
    RETURNS DECIMAL(12, 3)
BEGIN
    DECLARE @dist DECIMAL(12, 3);
	DECLARE @tmp FLOAT(1);

	SET @tmp = cos(radians(@pnt_lat)) * cos(radians(@lat)) * cos(radians(@lng) - radians(@pnt_lng)) + 
					 sin(radians(@pnt_lat)) * sin(radians(@lat));

	SET @dist = ROUND(6371 * acos(CASE WHEN @tmp >= -1 AND @tmp <= 1 THEN @tmp ELSE NULL END), 3);

    RETURN @dist;
END
GO

