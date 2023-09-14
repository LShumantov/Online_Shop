namespace OnlineShop
{
    using OnlineShop.Data.Static;
    using OnlineShop.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using OnlineShop.Data;

    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //Store
                if (!context.Stores.Any())
                {
                    context.Stores.AddRange(new List<Store>()
                    {
                        new Store()
                        {
                            Name = "Technomarket",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSEl52To3-wjKJvvS3ysQnaO0tF-AiI_fP-UQ&usqp=CAU",
                            Description = "This is the description of the first Store"
                        },
                        new Store()
                        {
                            Name = "Technopolis",
                            Logo = "https://themall.bg/wp-content/uploads/2016/07/technopolis-store-photo1.jpg",
                            Description = "This is the description of the first Store"
                        },                                     
                    });
                    context.SaveChanges();
                }
                //Categorys
                if (!context.Categorys.Any())
                {
                    context.Categorys.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            FullName = "Laptops",
                            Description = "This is the Description of the first Category",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRkkKfploN4Ds5o7zE3wHIOaCYmlQcFSyxlkA&usqp=CAU"

                        },
                        new Category()
                        {
                            FullName = "Telephones",
                            Description = "This is the Description of the second Category",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSdk2GbVpxQFiEZ2HucIKwXWg510qKjDogsQ&usqp=CAU"
                        },               
                    });
                    context.SaveChanges();
                }
                //Manufactures
                if (!context.Manufactures.Any())
                {
                    context.Manufactures.AddRange(new List<Manufacture>()
                    {
                        new Manufacture()
                        {
                            FullName = "Toshiba",
                            Description = "This is the Description of the first Manufacture",
                            ProfilePictureURL = "https://www.tokyo-dome.jp/english/upload/2023/02/top_slide01-scaled-0x0.jpg"

                        },
                        new Manufacture()
                        {
                            FullName = "Motorola",
                            Description = "This is the Description of the second Manufacture",
                            ProfilePictureURL = "https://media.architecturaldigest.com/photos/5d3f6c8084a5790008e99f37/master/w_1600%2Cc_limit/GettyImages-1143278588.jpg"
                        },                                        
                    });
                    context.SaveChanges();
                }
                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Laptop",
                            Description = "Processor: Intel Celeron N4020 | Gemini Lake Refresh | Dual-Core (1.10 GHz up to 2.8 GHz. 4 MB Cache, 14 nm, 6 W)",
                            Price = 39.50,
                            ImageURL = "https://static.plasico.bg/thumbs/12/lenovo-ideapad-1-15-gen-7-399282.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            StoreId = 1,
                            ManufactureId = 1,
                            ProductCategory = ProductCategory.Laptop
                        },
                        new Product()
                        {
                            Name = "Laptop",
                            Description = "Processor: Intel Celeron N4020 | Gemini Lake Refresh | Dual-Core (1.10 GHz up to 2.8 GHz. 4 MB Cache, 14 nm, 6 W)",
                            Price = 29.50,
                            ImageURL = "https://static.plasico.bg/thumbs/12/lenovo-ideapad-1-15-gen-7-399282.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            StoreId = 1,
                            ManufactureId = 1,
                            ProductCategory = ProductCategory.Laptop
                        },
                        new Product()
                        {
                            Name = "Laptop",
                            Description = "Processor: Intel Celeron N4020 | Gemini Lake Refresh | Dual-Core (1.10 GHz up to 2.8 GHz. 4 MB Cache, 14 nm, 6 W)",
                            Price = 397.50,
                            ImageURL = "https://static.plasico.bg/thumbs/12/lenovo-ideapad-1-15-gen-7-399282.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            StoreId = 1,
                            ManufactureId = 1,
                            ProductCategory = ProductCategory.Laptop
                        },
                        new Product()
                        {
                            Name = "Telephon",
                            Description = "Processor: Intel Celeron N4020 | Gemini Lake Refresh | Dual-Core (1.10 GHz up to 2.8 GHz. 4 MB Cache, 14 nm, 6 W)",
                            Price = 3926.50,
                            ImageURL = "https://s13emagst.akamaized.net/products/49519/49518966/images/res_4e57fa047c769e10699c285711d06bb2.jpg?width=720&height=720&hash=AF88FB3958A77E244877FAF0F5322170",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            StoreId = 2,
                            ManufactureId = 2,
                            ProductCategory = ProductCategory.Telephon
                        },
                    
                    });
                    context.SaveChanges();
                }
                //Categorys & Products
                if (!context.Categorys_Products.Any())
                {
                    context.Categorys_Products.AddRange(new List<Category_Product>()
                    {
                        new Category_Product()
                        {
                            CategoryId = 1,
                            ProductId = 1
                        },
                        new Category_Product()
                        {
                            CategoryId = 1,
                            ProductId = 2
                        },

                         new Category_Product()
                        {
                            CategoryId = 2,
                            ProductId = 1
                        },
                         new Category_Product()
                        {
                            CategoryId = 2,
                            ProductId = 2
                        },

                       

                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@OnlineShop.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                string appUserEmail = "user@OnlineShop.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
