using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Repository
{
    public interface IDepartmentRepository
    {
        public void Add(Department obj);
        public void Update(Department obj);
        public void Delete(int id);

        public List<Department> GetAll();
        public Department Getbyid(int id);
        public void Save();
    }
}
