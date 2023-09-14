namespace OnlineShop.Controllers
{
    using OnlineShop.Data;
    using OnlineShop.Data.Services;
    using OnlineShop.Data.Static;
    using OnlineShop.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize(Roles = UserRoles.Admin)]
    public class CategorysController : Controller
    {
        private readonly ICategorysService _service;
        public CategorysController(ICategorysService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Description")] Category Category)
        {
            if (!ModelState.IsValid)
            {
                return View(Category);
            }
            await _service.AddAsync(Category);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var CategoryDetails = await _service.GetByIdAsync(id);
            if (CategoryDetails == null) return View("NotFound");
            return View(CategoryDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var CategoryDetails = await _service.GetByIdAsync(id);
            if (CategoryDetails == null) return View("NotFound");
            return View(CategoryDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Description")] Category Category)
        {
            if (!ModelState.IsValid)
            {
                return View(Category);
            }
            await _service.UpdateAsync(id, Category);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var CategoryDetails = await _service.GetByIdAsync(id);
            if (CategoryDetails == null) return View("NotFound");
            return View(CategoryDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CategoryDetails = await _service.GetByIdAsync(id);
            if (CategoryDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
