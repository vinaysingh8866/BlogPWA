using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

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


        public IActionResult Details(int? id)
        {
            
            Blog bc = _db.BlogTable.Find(id);
            //Console.WriteLine(bc.auther_name);
            return View(bc);
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
