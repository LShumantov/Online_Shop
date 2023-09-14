namespace OnlineShop.Controllers
{
    using OnlineShop.Data;
    using OnlineShop.Data.Services;
    using OnlineShop.Data.Static;
    using OnlineShop.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = UserRoles.Admin)]
    public class ManufacturesController : Controller
    {
        private readonly IManufacturesService _service;
        public ManufacturesController(IManufacturesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allManufactures = await _service.GetAllAsync();
            return View(allManufactures);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var ManufactureDetails = await _service.GetByIdAsync(id);
            if (ManufactureDetails == null) return View("NotFound");
            return View(ManufactureDetails);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Description")]Manufacture Manufacture)
        {
            if (!ModelState.IsValid) return View(Manufacture);
            await _service.AddAsync(Manufacture);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var ManufactureDetails = await _service.GetByIdAsync(id);
            if (ManufactureDetails == null) return View("NotFound");
            return View(ManufactureDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Description")] Manufacture Manufacture)
        {
            if (!ModelState.IsValid) return View(Manufacture);

            if(id == Manufacture.Id)
            {
                await _service.UpdateAsync(id, Manufacture);
                return RedirectToAction(nameof(Index));
            }
            return View(Manufacture);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var ManufactureDetails = await _service.GetByIdAsync(id);
            if (ManufactureDetails == null) return View("NotFound");
            return View(ManufactureDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ManufactureDetails = await _service.GetByIdAsync(id);
            if (ManufactureDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
