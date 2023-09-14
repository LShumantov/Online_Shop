namespace OnlineShop.Models
{
    using OnlineShop.Data.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    public class Store:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Store Logo")]
        [Required(ErrorMessage = "Store logo is required")]
        public string Logo { get; set; }
        [Display(Name = "Store Name")]
        [Required(ErrorMessage = "Store name is required")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Store description is required")]
        public string Description { get; set; }
        //Relationships
        public List<Product>? Products { get; set; }
    }
}
