using Assignment_WEBAPI_D6.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_WEBAPI_D6.Repository
{
    public class EmployeeRepository
    {
        public EmployeeRepository(CompanyDbContext db)
        {
            Db = db;
        }

        public CompanyDbContext Db { get; }


        //select all
        public List<Employee> selectall() 
        {
            return Db.Employees.ToList();
        }

        public Employee GetByid(int id) 
        {
            return Db.Employees.FirstOrDefault(n=>n.Id==id);
        }

        public void Add(Employee e) 
        {
            Db.Employees.Add(e);
            Db.SaveChanges();
        }
        public void Edit(Employee e) 
        {
            Db.Entry(e).State=EntityState.Modified;
            Db.SaveChanges();     
        }

        public void Delete(int id) 
        {
            Employee emp = GetByid(id);
            Db.Employees.Remove(emp);
            Db.SaveChanges();
        }


    }
}
