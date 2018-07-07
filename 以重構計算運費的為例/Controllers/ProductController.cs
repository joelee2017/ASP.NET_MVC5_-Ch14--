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
                fee = CalculateFeeByBlackcat(product);
            }
            else if(product.Company == 2)// 當貨運商為新竹貨運時
            {
                fee = CalculateFeeByHsinchu(product);
            }
            else if(product.Company == 3)// 當貨運商為郵局時
            {
                fee = CalculateFeeByPostoffice(product);
            }

            // 將運費結果呈現在 View 上
            ViewBag.Fee = fee;
            return View(product);
        }

        /// <summary>
        /// 郵局計算運費
        /// </summary>
        /// <param name="product">商品規格</param>
        /// <returns>運費</returns>
        private static double CalculateFeeByPostoffice(ProductModels product)
        {
            double fee;
            //郵局計算運費
            var feeByWeight = 80 + product.Weight * 10;

            var size = product.Length * product.Width * product.Height;
            var feeBysize = size * 0.0000353 * 1100;

            if (feeByWeight < feeBysize)
            {
                fee = feeByWeight;
            }
            else
            {
                fee = feeBysize;
            }

            return fee;
        }

        /// <summary>
        /// 新竹貨運計算運費
        /// </summary>
        /// <param name="product">商品規格</param>
        /// <returns>運費</returns>
        private static double CalculateFeeByHsinchu(ProductModels product)
        {
            double fee;
            //新竹貨運計算運費
            var size = product.Length * product.Width * product.Height;
            // 長 * 寬 * 高(公分) * 0.0000353
            if (product.Length > 100 || product.Width > 100 || product.Height > 100)
            {
                fee = size * 0.0000353 * 1100 + 500;
            }
            else
            {
                fee = size * 0.0000353 * 1200;
            }

            return fee;
        }

        /// <summary>
        /// 黑貓計算運費
        /// </summary>
        /// <param name="product">商品規格</param>
        /// <returns>運費</returns>
        private static double CalculateFeeByBlackcat(ProductModels product)
        {
            double fee;
            //黑貓計算運費
            var weight = product.Weight;
            if (weight > 20)
            {
                fee = 500;
            }
            else
            {
                fee = 100 + weight * 10;
            }

            return fee;
        }
    }
}