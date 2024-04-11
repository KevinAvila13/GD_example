using System;
using System.Collections.Generic;

namespace GD_example.Models;

public partial class Ventum
{
    public int CodigoVenta { get; set; }

    public DateOnly Fecha { get; set; }

    public int CodigoProducto { get; set; }

    public virtual Producto CodigoProductoNavigation { get; set; } = null!;
}
