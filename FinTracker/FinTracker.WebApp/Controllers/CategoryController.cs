//using FinTracker.Service;
//using FinTracker.WebApp.Framework;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace FinTracker.WebApp.Controllers
//{
//    public class CategoryController : Controller
//    {
//        private readonly MapperService _mapperService;
//        private readonly CategoryService _categoryService;

//        public CategoryController()
//        {
//            _mapperService = new MapperService();
//            _categoryService = new CategoryService(Configuration.GetConnectionString(), _mapperService);
//        }

//        // GET: CategoryController
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: CategoryController/Details/5
//        public ActionResult Details(int id)
//        {
//            var cat = _categoryService.Get(id);
//            return View(cat);
//        }

//        // GET: CategoryController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: CategoryController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: CategoryController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: CategoryController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: CategoryController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: CategoryController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
