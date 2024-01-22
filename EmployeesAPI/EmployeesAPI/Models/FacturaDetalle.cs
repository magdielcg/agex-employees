using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Models
{
    public class FacturaDetalle
    {
        [Key]
        public int id { get; set; }

        public int facturaId { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string producto { get; set; }

        [Column(TypeName = "INT")]
        public int cantidad { get; set; }

        [Column(TypeName = "DECIMAL(18,2)")]
        public int monto { get; set; }

        [Column(TypeName = "DECIMAL(18,2)")]
        public int total { get; set; }

    }
}
