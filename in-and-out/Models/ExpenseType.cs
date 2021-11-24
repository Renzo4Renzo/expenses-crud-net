using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace in_and_out.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }
    }
}
