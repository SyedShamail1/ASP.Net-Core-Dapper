using DapperDemo.Interface;
using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.DataAccessLayer.Services
{
    public class AdminsService : IGenericRepository<Admin>
    {
        private readonly ApplicationDBContext _context;

        public AdminsService(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Admin> GetAll()
        {
            return _context.Admin.ToList();
        }

        public Admin GetById(int id)
        {
            return _context.Admin.Find(id);
        }

        public Admin Insert(Admin admin)
        {
            _context.Admin.Add(admin);
            _context.SaveChanges();
            return admin;
        }

        public Admin Update(Admin admin)
        {
            _context.Admin.Update(admin);
            _context.SaveChanges();
            return admin;
        }

        public void Delete(int id)
        {
            var result = _context.Admin.FirstOrDefault(x => x.AdminID == id);

            if(result != null)
                _context.Admin.Remove(result);
                _context.SaveChanges();
        }

    }
}
