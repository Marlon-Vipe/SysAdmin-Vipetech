using System;
using System.Collections.Generic;

namespace empleados.Models
{
    public partial class Paise
    {
        public Paise()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
