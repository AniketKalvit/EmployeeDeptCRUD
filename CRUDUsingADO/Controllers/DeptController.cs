using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingADO.Controllers
{
    public class DeptController : Controller
    {
        private readonly IConfiguration configuration;
        DeptCRUD crud;
        public DeptController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new DeptCRUD(this.configuration);
        }
        public ActionResult Index()
        {
            var list = crud.DeptList();
            return View(list);
        }
        public ActionResult Details(int id)
        {
            var dept = crud.GetDeptById(id);
            return View(dept);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dept dept)
        {
            try
            {
                int result = crud.AddDept(dept);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var dept = crud.GetDeptById(id);
            return View(dept);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dept dept)
        {
            try
            {
                int result = crud.UpdateDept(dept);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var dept = crud.GetDeptById(id);
            return View(dept);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteDept(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
