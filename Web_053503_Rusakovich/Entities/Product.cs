using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Web_053503_Rusakovich.Entities
{
    public class Product
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public string ImageName { get; set; }
        public int TypeId { get; set; }
        public ProductType ProductType { get; set; }

    }

    public class ProductType
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int TypeId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }

}
