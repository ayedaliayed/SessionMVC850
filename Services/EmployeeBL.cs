using SessionMVC850.Context;
using SessionMVC850.Models;

namespace SessionMVC850.Services
{
    public class EmployeeBL
    {
        CompanyContext CompanyContext = new CompanyContext();

        public List<Employee> GetAll()
        {
            return CompanyContext.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return CompanyContext.Employees.FirstOrDefault(d => d.Id == id);
        }

        public void Update(Employee employee)
        {
            var existing = CompanyContext.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.age = employee.age;
                existing.Image = employee.Image;
                existing.Phone = employee.Phone;
                existing.DeptId = employee.DeptId;
                CompanyContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var emp = CompanyContext.Employees.FirstOrDefault(e => e.Id == id);
            CompanyContext.Remove(emp);
            CompanyContext.SaveChanges();

        }


        public void Create(Employee employee)
        {
            CompanyContext.Add(employee);
            CompanyContext.SaveChanges();
        }
    }
}
