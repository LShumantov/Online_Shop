namespace OnlineShop.Models
{
    using OnlineShop.Data;
    using System.ComponentModel.DataAnnotations;
    public class NewProductVM
    {
        public int Id { get; set; }
        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Product poster URL")]
        [Required(ErrorMessage = "Product poster URL is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Product start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Product end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Product Category is required")]
        public ProductCategory ProductCategory { get; set; }
        //Relationships
        [Display(Name = "Category(s) Item(s)")]
        [Required(ErrorMessage = "Product Category(s) is required")]
        public List<int> CategoryIds { get; set; }
        [Display(Name = "Select a Store")]
        [Required(ErrorMessage = "Product Store is required")]
        public int StoreId { get; set; }
        [Display(Name = "Select a Manufacture")]
        [Required(ErrorMessage = "Product Manufacture is required")]
        public int ManufactureId { get; set; }
    }
}
