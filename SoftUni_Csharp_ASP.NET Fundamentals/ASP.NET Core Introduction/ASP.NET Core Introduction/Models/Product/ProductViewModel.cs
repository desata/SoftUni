﻿namespace ASP.NET_Core_Introduction.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; }
    }
}
