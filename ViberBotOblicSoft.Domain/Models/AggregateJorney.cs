using System.ComponentModel.DataAnnotations.Schema;

namespace ViberBotOblicSoft.Domain.Models
{
    [NotMapped]
    public class AggregateJorney
    {
        public int Count { get; set; }
        public decimal Distance { get; set; }
        public int Time { get; set; }
    }
}
