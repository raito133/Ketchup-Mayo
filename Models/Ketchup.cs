using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KetchupMayoSite.Models
{
    public class Ketchup
    {
        public Ketchup()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Marka")]
        public string Brand { get; set; }
        [Required]
        [DisplayName("Ostrość")]
        public int Spiciness { get; set; }
        [DisplayName("Data produkcji")]
        public DateTime ProductionDate { get; set; }

    }
}
