using Microsoft.AspNetCore.Mvc;
using SessionMVC850.Models;
using SessionMVC850.Services;

namespace SessionMVC850.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBL departmentBL = new DepartmentBL();
        public IActionResult Index()
        {
            //Moh comment1
            //Moh comment2
            //Moh comment3
            var departments = departmentBL.GetAll();
            return View(departments);
        }

        public IActionResult Details(int id)
        {
            var department = departmentBL.GetByIdWithEmployees(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        public IActionResult Edit(int id)
        {
            var department = departmentBL.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult SaveEdit(Department department)
        {
            if (department.Name != null)
            {
                departmentBL.Update(department);

                return RedirectToAction("Index");
            }

            return View("Edit", department);
        }

        public IActionResult Delete(int id)
        {
            var department = departmentBL.GetByIdWithEmployees(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult SaveDelete(int id)
        {
            departmentBL.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        //public IActionResult SaveAdd(string Name, string MangerName)
        public IActionResult SaveAdd(Department department)
        {
            if(department.Name !=null)
            {
                department.Code = "000";
                departmentBL.Ceate(department);

                return RedirectToAction("Index");


            }
            return View("Add",department);

        }






        //public IActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult SaveAdd(Department department)
        //{
        //    if (department.Name!=null)
        //    {
        //        //Add At DB
        //        // For now, display the submitted department name
        //        ViewBag.Message = "Department added successfully!";
        //        //return View(department);
        //        return RedirectToAction("Index");

        //    }

        //    return View("Add",department);
        //}
    }
}
