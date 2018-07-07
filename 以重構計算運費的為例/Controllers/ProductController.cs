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

            // Validation若不合法，則直接回傳
            if(!ModelState.IsValid)
            {
                return View(product);
            }

            double fee = 0;
            if(product.Company == 1)// 當貨運商為黑貓時
            {
                //fee =CalculateFeeByBlackcat(product)
                var blackcat = new Blackcat();
                fee = blackcat.CalculateFee(product);
            }
            else if(product.Company == 2)// 當貨運商為新竹貨運時
            {
                //fee =CalculateFeeByHsinchu(product)
                var hsinchu = new Hsinchu();
                fee = hsinchu.CalculateFee(product);
            }
            else if(product.Company == 3)// 當貨運商為郵局時
            {
                // fee = CalculateFeeByPostoffice(product)
                var postoffice = new Postoffice();
                fee = postoffice.CalculateFee(product);
            }

            // 將運費結果呈現在 View 上
            ViewBag.Fee = fee;
            return View(product);
        }       

      
    }
}