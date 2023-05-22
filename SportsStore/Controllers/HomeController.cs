using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
namespace SportsStore.Controllers
{

    public class HomeController : Controller
    {
        private readonly IStoreRepository _repository;
        public int PageSize = 4;
        public HomeController(IStoreRepository repo)
        {
            _repository = repo;
        }
        // public IActionResult Index() => View(_repository.Products);
        public ViewResult Index(string? category, int productPage = 1)
        => View(new ProductsListViewModel
        {
            Products = _repository.Products
            .Where(p => category == null || p.Category == category)
            .OrderBy(p => p.ProductID)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = _repository.Products.Count()
            },
            CurrentCategory = category
        }
            );
    }
}