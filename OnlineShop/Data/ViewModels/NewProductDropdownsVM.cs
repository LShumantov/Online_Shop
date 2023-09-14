namespace OnlineShop.Data.ViewModels
{
    using OnlineShop.Models;
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Manufactures = new List<Manufacture>();
            Stores = new List<Store>();
            Categorys = new List<Category>();
        }
        public List<Manufacture> Manufactures { get; set; }
        public List<Store> Stores { get; set; }
        public List<Category> Categorys { get; set; }
    }
}
