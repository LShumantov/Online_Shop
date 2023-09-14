using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.XUnitTest.MemoryData
{
    public class MemoryDataContex : DbContext
    {
        public AppDbContext DataBaseContext { get; private set; }

        public async Task<AppDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dataBaseContext = new AppDbContext(options);
            dataBaseContext.Database.EnsureCreated();
            if (await dataBaseContext.Products.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dataBaseContext.Manufactures.AddAsync(

                      new Manufacture()
                      {
                          FullName = "Toshiba",
                          Description = "This is the Description of the first Manufacture",
                          ProfilePictureURL = "https://www.tokyo-dome.jp/english/upload/2023/02/top_slide01-scaled-0x0.jpg",
                          Products = new List<Product>()

                          {
                              new Product
                              {
                                  Name = "Laptop",
                                  Description = "Processor: Intel Celeron N4020 | Gemini Lake Refresh | Dual-Core (1.10 GHz up to 2.8 GHz. 4 MB Cache, 14 nm, 6 W)",
                                  Price = 39.50,
                                  ImageURL = "https://static.plasico.bg/thumbs/12/lenovo-ideapad-1-15-gen-7-399282.jpg",
                                  StartDate = DateTime.Now.AddDays(-10),
                                  EndDate = DateTime.Now.AddDays(10),
                                  StoreId = 1,
                                  ManufactureId = 1,
                                  ProductCategory = ProductCategory.Laptop,
                                  Categorys_Products = new List<Category_Product>()
                                  {
                                      new Category_Product
                                      {
                                          Category = new Category
                                          {
                                              FullName = "Laptops",
                                              Description = "This is the Description of the first Category",
                                              ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRkkKfploN4Ds5o7zE3wHIOaCYmlQcFSyxlkA&usqp=CAU"

                                          }
                                      }
                                  },

                                  Store = new Store()
                                  {
                                      Name = "Technomarket",
                                      Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSEl52To3-wjKJvvS3ysQnaO0tF-AiI_fP-UQ&usqp=CAU",
                                      Description = "This is the description of the first Store"
                                  },

                              },
                                new Product
                              {
                                 Name = "Telephon",
                                 Description = "Processor: Intel Celeron N4020 | Gemini Lake Refresh | Dual-Core (1.10 GHz up to 2.8 GHz. 4 MB Cache, 14 nm, 6 W)",
                                 Price = 3926.50,
                                 ImageURL = "https://s13emagst.akamaized.net/products/49519/49518966/images/res_4e57fa047c769e10699c285711d06bb2.jpg?width=720&height=720&hash=AF88FB3958A77E244877FAF0F5322170",
                                 StartDate = DateTime.Now.AddDays(-10),
                                 EndDate = DateTime.Now.AddDays(-5),
                                 StoreId = 2,
                                 ManufactureId = 2,
                                 ProductCategory = ProductCategory.Telephon,
                                 Categorys_Products = new List<Category_Product>()
                                  {
                                      new Category_Product
                                      {
                                          Category = new Category
                                          {
                                              FullName = "Laptops",
                                              Description = "This is the Description of the first Category",
                                              ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRkkKfploN4Ds5o7zE3wHIOaCYmlQcFSyxlkA&usqp=CAU"

                                          }
                                      }
                                  },

                                  Store = new Store()
                                  {
                                      Name = "Technopolis",
                                      Logo = "https://themall.bg/wp-content/uploads/2016/07/technopolis-store-photo1.jpg",
                                      Description = "This is the description of the first Store"
                                  },

                              },
                          }
                      }); ;


                    await dataBaseContext.SaveChangesAsync();
                }
            }
            return dataBaseContext;
        }
    }
}
