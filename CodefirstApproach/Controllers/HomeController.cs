using CodefirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodefirstApproach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationProduct productdb;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ApplicationProduct productdb)
        {
            this.productdb = productdb;
        }

        public async Task<IActionResult> Index()
        {
            var stddata = await productdb.ProductTable.ToListAsync();
            return View(stddata);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Create(Product prod)
        {
            if (ModelState.IsValid) 
            {
                await productdb.ProductTable.AddAsync(prod);
                await productdb.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(prod);
        }

        public async Task<IActionResult> Details(int ? id)
        {
            if (id == null || productdb.ProductTable == null)
            {
                return NotFound();
            }
            var proddata = await productdb.ProductTable.FindAsync( id);
            if (proddata == null)
            {
                return NotFound();
            }
            return View(proddata);
        }
        
        

        public async Task<IActionResult> Edit(int ? id,Product prod)
        {
            if(id==null || productdb.ProductTable == null)  return NotFound();
            if (ModelState.IsValid)
            {
                productdb.ProductTable.Update(prod);
                await productdb.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            var productdata = await productdb.ProductTable.FindAsync(id);

            if(productdata == null)
            {
                return NotFound();

            }

            return View(productdata);
        }
        
        public async Task<IActionResult> Delete(int ? id)
        {
            if (id==null || productdb.ProductTable == null) return NotFound();
            var productdata = await productdb.ProductTable.FirstOrDefaultAsync(x=>x.ProductId==id);
            if (productdata == null) return NotFound();
            return View(productdata);  
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int  ? id)
        {
            if (id == null || productdb.ProductTable == null)
            {
                return NotFound();
            }
            var productdata = productdb.ProductTable.FirstOrDefault(x=>x.ProductId==id);
            if (productdata != null)
            {
                productdb.ProductTable.Remove(productdata);
               
            }
            await productdb.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
