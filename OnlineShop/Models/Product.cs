namespace OnlineShop.Models
{
    using OnlineShop.Data;
    using OnlineShop.Data.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    public class Product:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProductCategory ProductCategory { get; set; }
        //Relationships
        public List<Category_Product> Categorys_Products { get; set; }
        //Store
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store Store { get; set; }
        //Manufacture
        public int ManufactureId { get; set; }
        [ForeignKey("ManufactureId")]
        public Manufacture Manufacture { get; set; }
    }
}
