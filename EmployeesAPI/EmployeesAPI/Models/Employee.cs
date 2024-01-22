using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string nit { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string nombre { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string fecha { get; set; }

        [Column(TypeName = "INT")]
        public int estado { get; set; }

        [ForeignKey("facturaId")]
        public ICollection<FacturaDetalle> detalle { get; set; }
    }
}
