using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace in_and_out.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Borrower { get; set; }
        public string Lender { get; set; }

        [DisplayName("Item Name")]
        public string ItemName { get; set; }

    }
}
