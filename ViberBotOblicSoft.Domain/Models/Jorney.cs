using System.ComponentModel.DataAnnotations.Schema;

namespace ViberBotOblicSoft.Domain.Models
{
    [NotMapped]
    public class Jorney
    {
        public int Id { get; set; }
        public decimal Distance { get; set; }
        public int Time { get; set; }
    }
}
