namespace OnlineShop.Data.Services
{
    using OnlineShop.Data.Base;
    using OnlineShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class ManufacturesService: EntityBaseRepository<Manufacture>, IManufacturesService
    {
        public ManufacturesService(AppDbContext context) : base(context)
        {
        }
    }
}
