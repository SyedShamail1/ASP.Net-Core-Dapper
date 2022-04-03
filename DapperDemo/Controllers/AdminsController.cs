using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DapperDemo.DataAccessLayer;
using DapperDemo.Models;
using DapperDemo.Interface;

namespace DapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IGenericRepository<Admin> _adminRepo;

        public AdminsController(IGenericRepository<Admin> adminRepo)
        {
            _adminRepo = adminRepo;
        }

        // GET: api/Admins
        [HttpGet]
        public IEnumerable<Admin> GetAdmin()
        {
            var result = _adminRepo.GetAll();
            return result;
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public ActionResult GetAdmin(int id)
        {
            var admin = _adminRepo.GetById(id);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutAdmin(int id, Admin admin)
        {
            if (id != admin.AdminID)
            {
                return BadRequest();
            }

            var result = _adminRepo.Update(admin);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
            
        }

        // POST: api/Admins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult PostAdmin(Admin admin)
        {
            var result = _adminRepo.Insert(admin);

            if (result == null)
                return NotFound();
            
            return CreatedAtAction("GetAdmin", new { id = admin.AdminID }, admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public ActionResult DeleteAdmin(int id)
        {
            _adminRepo.Delete(id);
            return Ok();
        }

        
    }
}
