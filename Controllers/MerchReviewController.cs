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
    public class MerchReviewController : Controller
    {
        private Repository<MerchReview> _merchReviewData { get; set; }
        private MerchShopContext _context { get; set; }

        public MerchReviewController(MerchShopContext context)
        {
            _context = context;
            _merchReviewData = new Repository<MerchReview>(context);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MerchID, CustomerID, ReviewScore, ReviewText")] MerchReview merchReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merchReview);
        }

        public IActionResult Index() => RedirectToAction("List");


        public IActionResult List(int PageNumber = 1, int PageSize = 8, string SortDirection = "asc", string SortField = "Title")
        {
            MerchReviewGridData tempGrid =
                 new MerchReviewGridData { PageNumber = PageNumber, PageSize = PageSize, SortDirection = SortDirection, SortField = SortField };

            var options = new QueryOptions<MerchReview>
            {

                Includes = "Merch, Customer",
                PageNumber = tempGrid.PageNumber,
                PageSize = tempGrid.PageSize,
                OrderByDirection = tempGrid.SortDirection,
            };

            if (tempGrid.IsSortByReviewScore)
            {
                options.OrderBy = a => a.ReviewScore;
            }
            else
                options.OrderBy = a => a.Merch.ItemName;

            var vm = new MerchReviewListView
            {
                MerchReview = _merchReviewData.List(options),
                CurrentRoute = tempGrid,
                TotalPages = tempGrid.GetTotalPages(_merchReviewData.Count)

            };
            return View(vm);
        }

      
    }

}
