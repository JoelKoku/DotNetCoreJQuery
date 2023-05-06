using DotNetCoreJQuery.Models;

namespace DotNetCoreJQuery.ViewModel
{
    public class CategoryInfoModel
    {
        public int TotalRow { get; set; }
        public string? ErrorMsg { get; set; }
        public Category Category { get; set; }= new Category();

        private List<Category> categories= new List<Category>();
        public List<Category> CategoryList
        {
            get { return categories; }
            set { categories = value; }
        }
    }
}
