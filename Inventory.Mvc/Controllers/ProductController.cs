using Domain.Models;
using Infrastructure.DataAcces;
using Inventory.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace Inventory.Mvc.Controllers
{
    public class ProductController : BaseController
    {
        private readonly InventoryDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductController(InventoryDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Products.Include(p => p.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryName"] = new SelectList(_context.Categories, "CategoryName", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]ProductViewModel model)
        {

          if(ModelState.IsValid)
            { 

                string uniqueFileName = ProcessUploadedFile(model);

                var foundCategory = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == model.CategoryName);
                if (foundCategory is null)
                    throw new NotFoundException(nameof(Category), model.CategoryName);

                Product product = new()
                {
                    Name = model.Name,
                    Price = model.Price,
                    ProductPicture = uniqueFileName
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
           
           ViewData["CategoryName"] = new SelectList(_context.Categories, "CategoryName", "CategoryName", model.CategoryName);
            return View("Product");
        }

        private string ProcessUploadedFile(ProductViewModel model)
        {

            string uniqueFileName = null;
            string path = Path.Combine(_environment.WebRootPath, "Uploads1");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (model.ProductPicture != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Uploads1");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProductPicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProductPicture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productView = new ProductView()
            {
                ProductId = product.Id,
                Price = product.Price,
                ProductName = product.Name,      
                CategoryName = product.Category.CategoryName

            };
            ViewData["CategoryName"] = new SelectList(_context.Categories, "CategoryName", "CategoryName", productView.CategoryName);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Price,ProductPicture,Discount,Description,ProductImage,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


