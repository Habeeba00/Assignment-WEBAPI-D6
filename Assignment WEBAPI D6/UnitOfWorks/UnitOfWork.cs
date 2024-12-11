using Assignment_WEBAPI_D6.Models;
using Assignment_WEBAPI_D6.Repository;

namespace Assignment_WEBAPI_D6.UnitOfWorks
{
    public class UnitOfWork
    {
        GenericRepository<Employee> employeerepo;
        GenericRepository<Department> departmentrepo;
        CompanyDbContext db;
        public UnitOfWork(CompanyDbContext db)
        {
            this.db = db;

            //employeerepo = new GenericRepository<Employee>(db);
            //departmentrepo = new GenericRepository<Department>(db);

        }
        public GenericRepository<Employee> Employeerepo 
        { 
            get 
            {
                if (employeerepo == null) 
                
                    employeerepo = new GenericRepository<Employee>(db);
                    return employeerepo;

                
            } 
        }

        public GenericRepository<Department> Departmentrepo
        { 
            get
            {
                if(departmentrepo == null)
                    departmentrepo=new GenericRepository<Department>(db);
                return departmentrepo;

            } 
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
