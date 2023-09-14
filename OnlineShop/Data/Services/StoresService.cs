namespace OnlineShop.Data.Services
{
    using OnlineShop.Data.Base;
    using OnlineShop.Models;
    using System;
    public class StoresService:EntityBaseRepository<Store>, IStoresService
    {
        public StoresService(AppDbContext context) : base(context)
        {
        }
    }
}
