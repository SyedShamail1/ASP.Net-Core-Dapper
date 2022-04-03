using Dapper;
using DapperDemo.Interface;
using DapperDemo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.DataAccessLayer.Services
{
    public class AdminsServiceDapper : IGenericRepository<Admin>
    {
        private IDbConnection db;
        public AdminsServiceDapper(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public IEnumerable<Admin> GetAll()
        {
            var sql = "Select * from Admin";
            return db.Query<Admin>(sql).ToList();
            
        }

        public Admin GetById(int id)
        {
            var sql = "Select * from Admin Where AdminID = @id";
            return db.Query<Admin>(sql, new { @id = id}).FirstOrDefault();
        }

        public Admin Insert(Admin admin)
        {
            var sql = "INSERT INTO ADMIN (FirstName, LastName, Age, IsActive) VALUES (@FirstName, @LastName, @Age, @IsActive);"
                        + "SELECT CAST(SCOPE_IDENTITY() as int); ";
            int adminID = db.Query<int>(sql, new { 
                        @FirstName = admin.FirstName,
                        @LastName = admin.LastName,
                        @Age = admin.Age,
                        @IsActive = admin.IsActive
            }).Single();

            admin.AdminID = adminID;
            return admin;
            
        }

        public Admin Update(Admin admin)
        {
            var sql = "UPDATE Admin SET FirstName = @FirstName, LastName = @LastName, Age = @Age, " +
                        "IsActive = @IsActive WHERE AdminID = @AdminID";
             db.Execute(sql, admin);
            return admin;
        }
        public void Delete(int id)
        {
            var sql = "Delete from Admin Where AdminID = @id";
            db.Query(sql, new { @id = id });
        }
    }
}
