using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        Mydb db;
        public DepartmentRepository(Mydb db)
        {
            this.db = db;
        }
        public void Add(Department obj)
        {
            db.Add(obj);
        }
        public void Update(Department obj)
        {
            db.Update(obj);
        }
        public void Delete(int id)
        {
            Department department = this.Getbyid(id);
            db.Departments.Remove(department);
        }

        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }
        public Department Getbyid(int id)
        {
            return db.Departments.SingleOrDefault(c => c.id == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
