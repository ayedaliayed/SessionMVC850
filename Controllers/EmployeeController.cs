using Microsoft.AspNetCore.Mvc;
using SessionMVC850.ModelView;
using SessionMVC850.Models;
using SessionMVC850.Services;

namespace SessionMVC850.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeBL EmployeeBL = new EmployeeBL();
        DepartmentBL DepartmentBL = new DepartmentBL();
        public IActionResult Index()
        {
            var employees = EmployeeBL.GetAll();
            return View(employees);
        }

        public IActionResult Edit(int id)
        {
            var employee = EmployeeBL.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            ViewBag.Departments = DepartmentBL.GetAll();
            return View(employee);
        }

      
        public IActionResult SaveEdit(Employee employee)
        {
            if (employee.Name != null)
            {
                EmployeeBL.Update(employee);

                return RedirectToAction("Index");
            }

            ViewBag.Departments = DepartmentBL.GetAll();
            return View("Edit", employee);
        }

        public IActionResult GetEmp(int id)
        {
            int grade = 150;
            string companyaddress = "cairo";

            List<string> branchs = new List<string>();
            branchs.Add("Cairo");
            branchs.Add("alex");
            branchs.Add("assuit");

            //ViewData["branchs"] = branchs;
            //ViewData["grade"] = grade;
            //ViewData["companyaddress"] = companyaddress;

            var em = EmployeeBL.GetById(id);
            var depanme = DepartmentBL.GetById(em.DeptId);

            EmopyeeViewMode emopyeeViewMode = new EmopyeeViewMode();


            //employee
            emopyeeViewMode.Id = em.Id;
            emopyeeViewMode.age = em.age;
            emopyeeViewMode.Nameeeeeeee = em.Name;

            //deparmnet
            emopyeeViewMode.DeptName = depanme.Name;


            //others data
            emopyeeViewMode.grade = grade;
            emopyeeViewMode.companyaddress = companyaddress;
            emopyeeViewMode.branchs = branchs;




            return View("EmpDetails", emopyeeViewMode);
        }


        // create delete action
        // id 
        // get emplyee from database
        // delete from database
        // return to index page

        public IActionResult Delete(int id)
        {
            EmployeeBL.Delete(id);

            return RedirectToAction("Index");

        }







        // create open add apge    => form add employee
        //create action save data 
        // save DB

        public IActionResult Add()
        {
            ViewBag.Departments = DepartmentBL.GetAll();
            return View("Create");
        }


        public IActionResult Create(Employee employee)
        {

            if(employee.Name!=null)
                EmployeeBL.Create(employee);
            // add valiadtion 
            //Save AtDatababase


            return RedirectToAction("Index");
        }





        //public IActionResult Create(CreateUpadteEmployee employee)
        //{

        //    //if(employee.Name!=null)
        //    //    EmployeeBL.Create(employee);
        //    // add valiadtion 
        //    //Save AtDatababase

        //    if (ModelState.IsValid)
        //    {
        //        var newemployee = new Employee();
        //        newemployee.Name = employee.Name;
        //        newemployee.age = employee.age;
        //        newemployee.DeptId = employee.DeptId;
        //        newemployee.Image = employee.Image;
        //        newemployee.Phone = employee.Phone;
        //        EmployeeBL.Create(newemployee);

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        ViewBag.Departments = DepartmentBL.GetAll();
        //        return View("Create", employee);
        //    }

        //    return RedirectToAction("Index");
        //}

    }
}
