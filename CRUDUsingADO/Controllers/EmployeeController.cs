using Microsoft.AspNetCore.Mvc;
using CRUDUsingADO.Models;
namespace CRUDUsingADO.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeCRUD crud;
        DeptCRUD deptCRUD;
        private readonly IConfiguration configuration;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new EmployeeCRUD(this.configuration);
            deptCRUD = new DeptCRUD(this.configuration);
        }
        // GET: EmployeeController Emplist
        public ActionResult Index()
        {
            var list = crud.GetAllEmployess();
            return View(list);
        }

        // GET: EmployeeController/Details/5 -> single emp
        public ActionResult Details(int id) 
        {
            var emp = crud.GetEmployeeById(id);
            return View(emp);
        }

        // GET: EmployeeController/Create -> add emp
        public ActionResult Create()
        {
            var deptlist=deptCRUD.DeptList();
            ViewBag.DeptList = deptlist;
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result = crud.AddEmployee(emp);
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

        // GET: EmployeeController/Edit/5 --> modify emp
        public ActionResult Edit(int id)
        {
            var deptlist = deptCRUD.DeptList();
            ViewBag.DeptList = deptlist;
            var emp = crud.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = crud.UpdateEmployee(emp);
                if (result == 1)
                {
                    ViewBag.Error = "";
                    return RedirectToAction(nameof(Index));
                }
                    
                else
                {
                    ViewBag.Error = "Something went wrong";
                    return View();
                }
                    

            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = crud.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteEmployee(id);
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
