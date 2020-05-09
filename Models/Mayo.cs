using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KetchupMayoSite.Models
{
    public class Mayo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Marka")]
        public string Brand { get; set; }
        [Required]
        [DisplayName("Łagodność")]
        public int Mildness { get; set; }
        [DisplayName("Data produkcji")]
        public DateTime ProductionDate { get; set; }
    }
}
