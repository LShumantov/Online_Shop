namespace OnlineShop.Controllers
{
    using OnlineShop.Data;
    using OnlineShop.Data.Services;
    using OnlineShop.Data.Static;
    using OnlineShop.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
        public ProductsController(IProductsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(n => n.Store);
            return View(allProducts);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync(n => n.Store);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allProducts.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filteredResultNew);
            }
            return View("Index", allProducts);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var ProductDetail = await _service.GetProductByIdAsync(id);
            return View(ProductDetail);
        }
        public async Task<IActionResult> Create()
        {
            var ProductDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Stores = new SelectList(ProductDropdownsData.Stores, "Id", "Name");
            ViewBag.Manufactures = new SelectList(ProductDropdownsData.Manufactures, "Id", "FullName");
            ViewBag.Categorys = new SelectList(ProductDropdownsData.Categorys, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM Product)
        {
            if (!ModelState.IsValid)
            {
                var ProductDropdownsData = await _service.GetNewProductDropdownsValues();
                ViewBag.Stores = new SelectList(ProductDropdownsData.Stores, "Id", "Name");
                ViewBag.Manufactures = new SelectList(ProductDropdownsData.Manufactures, "Id", "FullName");
                ViewBag.Categorys = new SelectList(ProductDropdownsData.Categorys, "Id", "FullName");
                return View(Product);
            }
            await _service.AddNewProductAsync(Product);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var ProductDetails = await _service.GetProductByIdAsync(id);
            if (ProductDetails == null) return View("NotFound");
            var response = new NewProductVM()
            {
                Id = ProductDetails.Id,
                Name = ProductDetails.Name,
                Description = ProductDetails.Description,
                Price = ProductDetails.Price,
                StartDate = ProductDetails.StartDate,
                EndDate = ProductDetails.EndDate,
                ImageURL = ProductDetails.ImageURL,
                ProductCategory = ProductDetails.ProductCategory,
                StoreId = ProductDetails.StoreId,
                ManufactureId = ProductDetails.ManufactureId,
                CategoryIds = ProductDetails.Categorys_Products.Select(n => n.CategoryId).ToList(),
            };
            var ProductDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Stores = new SelectList(ProductDropdownsData.Stores, "Id", "Name");
            ViewBag.Manufactures = new SelectList(ProductDropdownsData.Manufactures, "Id", "FullName");
            ViewBag.Categorys = new SelectList(ProductDropdownsData.Categorys, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM Product)
        {
            if (id != Product.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var ProductDropdownsData = await _service.GetNewProductDropdownsValues();
                ViewBag.Stores = new SelectList(ProductDropdownsData.Stores, "Id", "Name");
                ViewBag.Manufactures = new SelectList(ProductDropdownsData.Manufactures, "Id", "FullName");
                ViewBag.Categorys = new SelectList(ProductDropdownsData.Categorys, "Id", "FullName");
                return View(Product);
            }
            await _service.UpdateProductAsync(Product);
            return RedirectToAction(nameof(Index));
        }
    }
}