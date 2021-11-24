using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace in_and_out.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [DisplayName("Expense")]
        [Required(ErrorMessage = "This field is required.")]
        public string ExpenseName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0!")]
        public int? Amount { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Expense Type")]
        public int ExpenseTypeId { get; set; }
        //public int? ExpenseTypeId { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
