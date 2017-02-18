using OnlineShopping.Domain.Abstract;
using OnlineShopping.Domain.Entities;
using OnlineShopping.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public int pageSize = 8;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                products = repository.Products
                .Where(p => category == null || p.category == category)
                .OrderBy(p => p.productId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                pagingInfo = new PagingInfo
                {
                    currentPage = page,
                    itemPerPage = pageSize,
                    totalItems = category == null ?
                                 repository.Products.Count() :
                                 repository.Products.Where(p => p.category == category).Count()
                },
                currentCategory = category
            };
        
            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.productId == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}