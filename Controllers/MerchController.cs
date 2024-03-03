using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerchShop.Models;

namespace MerchShop.Controllers
{
    public class MerchController : Controller
    {

        private Repository<Merch> _merchData { get; set; }
        private MerchShopContext _context { get; set; }

        public MerchController(MerchShopContext context)
        {
            _context = context;
            _merchData = new Repository<Merch>(context);
        }

        public IActionResult Index() => RedirectToAction("List");


        public IActionResult List(int PageNumber = 1, int PageSize = 8, string SortDirection = "asc", string SortField = "Title")
        {
            MerchGridData tempGrid =
                 new MerchGridData { PageNumber = PageNumber, PageSize = PageSize, SortDirection = SortDirection, SortField = SortField };

            var options = new QueryOptions<Merch>
            {

                Includes = "Vendor",
                PageNumber = tempGrid.PageNumber,
                PageSize = tempGrid.PageSize,
                OrderByDirection = tempGrid.SortDirection,
            };


            var vm = new MerchListView
            {
                Merch = _merchData.List(options),
                CurrentRoute = tempGrid,
                TotalPages = tempGrid.GetTotalPages(_merchData.Count)

            };
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var merch = _context.Merch.FirstOrDefault(x => x.MerchID == id);
            var vendor = _context.Vendors.OrderBy(g => g.VendorID).ToList();
            var mdv = new MerchDetailView { Merch = merch ?? new Merch(), Vendors = vendor};
            return View(mdv);
        }
    
   
    }
}
