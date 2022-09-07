using System;
using System.Collections.Generic;

namespace empleados.Models
{
    public partial class Tiendum
    {
        public Tiendum()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
