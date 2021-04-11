using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;


        public BlogController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displayData = _db.BlogTable.ToList();
            
            return View(displayData);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog bc)
        {
            if (ModelState.IsValid)
            {
                _db.Add(bc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(bc);



        }


    }
}
