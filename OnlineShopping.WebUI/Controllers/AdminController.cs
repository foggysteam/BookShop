using OnlineShopping.Domain.Abstract;
using OnlineShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        private IUser user;

        public AdminController(IProductRepository repo, IUser us)
        {
            repository = repo;
            user = us;
        }
        public ActionResult Index()
        {
            return View(repository.Products);
        }

        
        public ViewResult Create()
        {
            return View(new Product());
        }
        //[HttpPost]
        //public ActionResult Create(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveProduct(product);
        //        TempData["message"] = string.Format("{0} has been saved", product.name);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(product);
        //    }
        //}
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.productId == productId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.name);
            }
            return RedirectToAction("Index");
        }









        public ActionResult UserIndex()
        {
            return View(user.Users);
        }


        public ViewResult Createuser()
        {
            return View(new User());
        }
        
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {

                this.user.SaveUser(user);
                TempData["message"] = string.Format("{0} has been saved", user.Username);
                return RedirectToAction("UserIndex");
            }
            else
            {
                return View(user);
            }
        }


        [HttpPost]
        public ActionResult DeleteUser(int userId)
        {
            User deletedUser = user.DeleteUser(userId);
            if (deletedUser != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedUser.Username);
            }
            return RedirectToAction("UserIndex");
        }


    }
}