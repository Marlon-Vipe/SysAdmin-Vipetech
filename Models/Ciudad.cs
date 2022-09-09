using System;
using System.Collections.Generic;

namespace empleados.Models
{
    public partial class Ciudad
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ciudad"/> class.
        /// </summary>
        public Ciudad()
        {
            Clientes = new HashSet<Cliente>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string? Nombre { get; set; }

        /// <summary>
        /// Gets or sets the clientes.
        /// </summary>
        /// <value>
        /// The clientes.
        /// </value>
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
