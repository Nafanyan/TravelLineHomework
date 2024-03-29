﻿using System.ComponentModel.DataAnnotations;

namespace Shop.Databases;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    public string NameProduct { get; set; } = null!;

    public float WeightProduct { get; set; }

    public decimal Price { get; set; }

    public string DescriptionProduct { get; set; } = null!;

    public int CountInStock { get; set; }

    public string TypeProduct { get; set; } = null!;
}
