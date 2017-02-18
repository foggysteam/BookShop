using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace OnlineShopping.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int productId { get; set; }
        [Required(ErrorMessage = "Please enter a book title")]
        [Display(Name = "Title:")]
        public string name { get; set; }
        //[DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter an author")]
        [Display(Name = "Author:")]
        public string description { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Please Enter a positive price")]
        [Display(Name = "Price:")]
        public decimal price { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Category:")]
        public string category { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
