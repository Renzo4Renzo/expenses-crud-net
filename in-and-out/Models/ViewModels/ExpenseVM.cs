using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace in_and_out.Models.ViewModels
{
    public class ExpenseVM
    {
        public Expense Expense { get; set; }
        public IEnumerable<SelectListItem> ExpenseTypesDropdown { get; set; }
    }
}
