using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 以重構計算運費的為例.Models;

namespace 以重構計算運費的為例.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var companies = new List<SelectListItem>
            {
                new SelectListItem { Text="黑貓", Value= "1"},
                new SelectListItem { Text="新竹貨運", Value= "2"},
                new SelectListItem { Text="郵局", Value= "3"},
            };
            ViewBag.Company = companies;
            return View();
        }

        [HttpPost]
        public ActionResult Index(ProductModels product)
        {
            var companies = new List<SelectListItem>
            {
                new SelectListItem { Text="黑貓", Value= "1"},
                new SelectListItem { Text="新竹貨運", Value= "2"},
                new SelectListItem { Text="郵局", Value= "3"},
            };

            ViewBag.Company = companies;

            if(!ModelState.IsValid)
            {
                return View(product);
            }

            double fee = 0;
            if(product.Company == 1)
            {
                var weight = product.Weight;
                if(weight > 20)
                {
                    fee = 500;
                }
                else
                {
                    fee = 100 + weight * 10;
                }
            }
            else if(product.Company == 2)
            {
                var size = product.Length * product.Width * product.Height;
                // 長 * 寬 * 高(公分) * 0.0000353
                if(product.Length > 100 || product.Width > 100 || product.Height > 100)
                {
                    fee = size * 0.0000353 * 1100 + 500;
                }
                else
                {
                    fee = size * 0.0000353 * 1200;
                }
            }
            else if(product.Company == 3)
            {
                var feeByWeight = 80 + product.Weight * 10;

                var size = product.Length * product.Width * product.Height;
                var feeBysize = size * 0.0000353 * 1100;

                if(feeByWeight < feeBysize)
                {
                    fee = feeByWeight;
                }
                else
                {
                    fee = feeBysize;
                }
            }
            ViewBag.Fee = fee;
            return View(product);
        }
    }
}