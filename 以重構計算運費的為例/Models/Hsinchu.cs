using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 以重構計算運費的為例.Models
{
    public class Hsinchu
    {
        /// <summary>
        /// 新竹貨運計算運費
        /// </summary>
        /// <param name="product">商品規格</param>
        /// <returns>運費</returns>
        public double CalculateFee(Models.ProductModels product)
        {
            double fee = 0;
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
    }
}