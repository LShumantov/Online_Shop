namespace OnlineShop.Data.Services
{
    using OnlineShop.Data.Base;
    using OnlineShop.Data.ViewModels;
    using OnlineShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StoreId = data.StoreId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                ProductCategory = data.ProductCategory,
                ManufactureId = data.ManufactureId
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            foreach (var CategoryId in data.CategoryIds)
            {
                var newCategoryProduct = new Category_Product()
                {
                    ProductId = newProduct.Id,
                    CategoryId = CategoryId
                };
                await _context.Categorys_Products.AddAsync(newCategoryProduct);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var ProductDetails = await _context.Products
                .Include(c => c.Store)
                .Include(p => p.Manufacture)
                .Include(am => am.Categorys_Products).ThenInclude(a => a.Category)
                .FirstOrDefaultAsync(n => n.Id == id);

            return ProductDetails;
        }
        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Categorys = await _context.Categorys.OrderBy(n => n.FullName).ToListAsync(),
                Stores = await _context.Stores.OrderBy(n => n.Name).ToListAsync(),
                Manufactures = await _context.Manufactures.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(dbProduct != null)
            {
                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.ImageURL = data.ImageURL;
                dbProduct.StoreId = data.StoreId;
                dbProduct.StartDate = data.StartDate;
                dbProduct.EndDate = data.EndDate;
                dbProduct.ProductCategory = data.ProductCategory;
                dbProduct.ManufactureId = data.ManufactureId;
                await _context.SaveChangesAsync();
            }
            var existingCategorysDb = _context.Categorys_Products.Where(n => n.ProductId == data.Id).ToList();
            _context.Categorys_Products.RemoveRange(existingCategorysDb);
            await _context.SaveChangesAsync();
            foreach (var CategoryId in data.CategoryIds)
            {
                var newCategoryProduct = new Category_Product()
                {
                    ProductId = data.Id,
                    CategoryId = CategoryId
                };
                await _context.Categorys_Products.AddAsync(newCategoryProduct);
            }
            await _context.SaveChangesAsync();
        }
    }
}
