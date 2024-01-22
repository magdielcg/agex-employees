using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Models
{
    public class EmployeesAPIContext:DbContext
    {
        public EmployeesAPIContext(DbContextOptions<EmployeesAPIContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalle { get; set; }
    }
}
