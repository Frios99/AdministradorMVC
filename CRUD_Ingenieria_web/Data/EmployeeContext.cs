using CRUD_Ingenieria_web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRUD_Ingenieria_web.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options){ }
        public DbSet<Employee> Employees { get; set; }
       public DbSet<User> Users { get; set; }

    }
}
