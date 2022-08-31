using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTracker.Service.ViewModels.Category
{
    public class GetCategoriesViewModel: List<GetCategoriesItem>
    {
    }

    public class GetCategoriesItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
