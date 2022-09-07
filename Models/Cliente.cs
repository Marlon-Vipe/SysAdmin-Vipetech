using System;
using System.Collections.Generic;

namespace empleados.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cedula { get; set; }
        public string? Telefono { get; set; }
        public int? IdCiudad { get; set; }
        public int? IdDireccion { get; set; }
        public int? IdTienda { get; set; }
        public int? IdTipoVenta { get; set; }
        public int? TipoCliente { get; set; }

        public virtual Ciudad? IdCiudadNavigation { get; set; }
        public virtual Direccion? IdDireccionNavigation { get; set; }
        public virtual Tiendum? IdTiendaNavigation { get; set; }
        public virtual TipoDeVentum? IdTipoVentaNavigation { get; set; }
        public virtual TipoCliente? TipoClienteNavigation { get; set; }
    }
}
