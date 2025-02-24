﻿using System;
using System.Collections.Generic;

namespace GD_example.Models;

public partial class Categoria
{
    public int CodigoCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
