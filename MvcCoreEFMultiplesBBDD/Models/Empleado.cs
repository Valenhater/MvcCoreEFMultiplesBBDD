using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreEFMultiplesBBDD.Models
{
    [Table("v_empleados")]
    public class Empleado
    {
        [Key]
        [Column("IDEMPLEADO")]
        public int IdEmpleado { get; set; }
        [Column("APELLIDO")]
        public string Apellido { get; set; }
        [Column("OFICIO")]
        public string Oficio { get; set; }
        [Column("SALARIO")]
        public int Salario { get; set; }
        [Column("NombreDepartamento")]
        public string NomDept { get; set; }
        [Column("Localidad")]
        public string Localidad { get; set; }
        [Column("NumeroDepartamento")]
        public int NumDept { get; set; }
    }
}
