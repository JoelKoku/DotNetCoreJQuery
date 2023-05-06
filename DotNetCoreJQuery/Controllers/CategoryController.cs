using DotNetCoreJQuery.DataContext;
using DotNetCoreJQuery.Models;
using DotNetCoreJQuery.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreJQuery.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAllcategory()
        {
            CategoryInfoModel model = new CategoryInfoModel();
            model.CategoryList = _context.Categories.ToList();
            return Json(model);
        }
        [HttpPost]
        public IActionResult AddUpdateCategory(Category infomodel)
        {
            CategoryInfoModel model = new CategoryInfoModel();
            try
            {
                if (infomodel == null)
                {
                    model.ErrorMsg = "All Data are required";
                }
                else
                {
                    if (infomodel.Id == 0)
                    {
                        _context.Add(infomodel);
                        model.TotalRow = _context.SaveChanges();
                        model.ErrorMsg = "category add successfully";
                    }
                    else
                    {
                        _context.Update(infomodel);
                        model.TotalRow = _context.SaveChanges();
                        model.ErrorMsg = "category Update successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                model.ErrorMsg = ex.Message;
            }
                return Json(model);
        }
        [HttpPost]
        public IActionResult GetCategoryDetails(int id)
        {
            CategoryInfoModel model = new CategoryInfoModel();
            try
            {
                var categorydata = _context.Categories.FirstOrDefault(m => m.Id == id);
            if(categorydata == null)
                {
                    model.TotalRow = 0;
                    model.ErrorMsg= "DataNotFound";
                }
                else
                {
                    model.Category = categorydata;
                }
            }
            catch (Exception ex)
            {
                model.ErrorMsg = ex.Message;
            }
            return Json(model);
        }
        [HttpPost]
        public IActionResult DeleteCategory(Category model)
        {
            CategoryInfoModel infomodel = new CategoryInfoModel();
            try
            {
                _context.Remove(model);
                _context.SaveChanges();
                infomodel.TotalRow = 1;
                infomodel.ErrorMsg = "Record Deleted";
            }
            catch (Exception ex)
            {
                infomodel.ErrorMsg = ex.Message;
            }
            return Json(model);
        }
    }
}
