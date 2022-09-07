using System;
using System.Collections.Generic;

namespace empleados.Models
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cedula { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public int? Salario { get; set; }
        public string? NombrePais { get; set; }

        public virtual Paise? NombrePaisNavigation { get; set; }
    }
}
