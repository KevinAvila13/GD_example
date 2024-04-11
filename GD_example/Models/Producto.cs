using System;
using System.Collections.Generic;

namespace GD_example.Models;

public partial class Producto
{
    public int CodigoProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public int CodigoCategoria { get; set; }

    public virtual Categoria CodigoCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
