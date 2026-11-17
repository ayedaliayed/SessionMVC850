using Microsoft.EntityFrameworkCore;
using SessionMVC850.Context;
using SessionMVC850.Models;

namespace SessionMVC850.Services
{
    public class DepartmentBL
    {
        CompanyContext CompanyContext = new CompanyContext();

        public List<Department>GetAll()
        {
            return CompanyContext.Departments.ToList();
        }


        public Department GetById(int id)
        {
            return CompanyContext.Departments.FirstOrDefault(d => d.Id == id);
        }

        public Department GetByIdWithEmployees(int id)
        {
            return CompanyContext.Departments
                .Include(d => d.Employees)
                .FirstOrDefault(d => d.Id == id);
        }

        public void Ceate(Department department)
        {
            CompanyContext.Departments.Add(department);
            CompanyContext.SaveChanges();
        }

        public void Update(Department department)
        {
            var existing = CompanyContext.Departments.FirstOrDefault(d => d.Id == department.Id);
            if (existing != null)
            {
                existing.Name = department.Name;
                existing.Code = department.Code;
                existing.MangerName = department.MangerName;
                CompanyContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var department = CompanyContext.Departments.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                CompanyContext.Departments.Remove(department);
                CompanyContext.SaveChanges();
            }
        }

    }
}
