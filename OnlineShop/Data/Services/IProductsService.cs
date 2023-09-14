namespace OnlineShop.Data.Services
{
    using OnlineShop.Data.Base;
    using OnlineShop.Data.ViewModels;
    using OnlineShop.Models;
    public interface IProductsService:IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductDropdownsVM> GetNewProductDropdownsValues();
        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);
    }
}
