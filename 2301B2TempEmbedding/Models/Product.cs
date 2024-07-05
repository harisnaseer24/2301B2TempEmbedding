using System;
using System.Collections.Generic;

namespace _2301B2TempEmbedding.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Pname { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Price { get; set; }
}
