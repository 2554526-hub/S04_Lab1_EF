using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class ZombieType
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Type Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} has to be filled.")]

        [Range(5,10)]
        public string TypeName { get; set; }
    }
}
