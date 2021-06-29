using Helper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Helper
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
            DirectoryInfo d = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var dbPath = d.Parent.Parent.Parent.Parent + @"\myDB.db";
            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}
