using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZombieParty.Models
{
    public class Zombie
    {
        public string Name { get; set; }

        public int Id { get; set; }

        // FACULTATIF on peut formellement identifier le champ lien
        // sinon le champ de foreignKey sera auto généré dans la BD
        [Display(Name = "Zombie Type")]
        [ForeignKey("ZombieType")]
        public int ZombieTypeId { get; set; }
        public ZombieType ZombieType { get; set; }
        public int Point { get; set; }
    }
}
