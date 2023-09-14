namespace OnlineShop.Data.Services
{
    using OnlineShop.Data.Base;
    using OnlineShop.Models;
    public class CategorysService : EntityBaseRepository<Category>, ICategorysService
    {
        public CategorysService(AppDbContext context) : base(context) { }
    }
}
