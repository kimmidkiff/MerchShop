using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MerchShop.Models;

namespace MerchShop.Controllers
{
    public class VendorsController : Controller
    {
        private Repository<Vendor> _vendorData { get; set; }
        private MerchShopContext _context { get; set; }

        public VendorsController(MerchShopContext context)
        {
            _context = context;
            _vendorData = new Repository<Vendor>(context);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendorID, Name, WebURL")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }

        public IActionResult Index() => RedirectToAction("List");


        public IActionResult List(int PageNumber = 1, int PageSize = 5, string SortDirection = "asc", string SortField = "Name")
        {
            VendorGridData tempGrid =
                 new VendorGridData { PageNumber = PageNumber, PageSize = PageSize, SortDirection = SortDirection, SortField = SortField };

            var options = new QueryOptions<Vendor>
            {

                PageNumber = tempGrid.PageNumber,
                PageSize = tempGrid.PageSize,
                OrderByDirection = tempGrid.SortDirection,
            };

            if (tempGrid.IsSortByWebURL)
            {
                options.OrderBy = a => a.WebURL;
            }
            else
                options.OrderBy = a => a.Name;


            var vm = new VendorListView
            {
                Vendor = _vendorData.List(options),
                CurrentRoute = tempGrid,
                TotalPages = tempGrid.GetTotalPages(_vendorData.Count)

            };
            return View(vm);
        }

       
    }
}
