using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 以重構計算運費的為例.Models
{
    public class Blackcat
    {
        /// <summary>
        /// 黑貓計算運費
        /// </summary>
        /// <param name="product">商品規格</param>
        /// <returns>運費</returns>
        public double CalculateFee(Models.ProductModels product)
        {
            double fee =0;

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