using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 以重構計算運費的為例.Models
{
    public class Postoffice
    {
        /// <summary>
        /// 郵局計算運費
        /// </summary>
        /// <param name="product">商品規格</param>
        /// <returns>運費</returns>
        public double CalculateFee(Models.ProductModels product)
        {
            double fee = 0;
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
    }
}