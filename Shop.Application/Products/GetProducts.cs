﻿using Shop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.Products
{
    public class GetProducts
    {
        private ApplicationDbContext _ctx;

        public GetProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() =>
             _ctx.Products.ToList().Select(x => new ProductViewModel
             {
                 Name = x.Name,
                 Description = x.Description,
                 Value = $"$ {x.Value:N2}" // 1100,50 => 1.100,50
             });

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
        }
    }

}