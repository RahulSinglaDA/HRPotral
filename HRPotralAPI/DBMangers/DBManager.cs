using HRPotralAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace HRPotralAPI.DBManagers
{
    public class DBManager : DbContext
    {
        private bool dbExists=false;
        public DBManager()
        {
            if(!dbExists)
            {
                Database.EnsureCreated();
                dbExists = true;
            }
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\myDB.db";
            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}
