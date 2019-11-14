using System;
using System.Collections.Generic;
using System.Text;

namespace UNiDAYS_Discounts_Coding_Challenge
{
    public class UnidaysDiscountChallenge
    {
        protected Func<Dictionary<char, int>, double> _pricingRules;
        protected Dictionary<char, int> item_list = new Dictionary<char, int>();
       
        /// <summary>
        /// Defines the dictionary to store the items and the pricing rules method.
        /// </summary>
        /// <param name="rules"></param>
        public UnidaysDiscountChallenge(Func<Dictionary<char, int>, double> rules)
        {
            item_list.Add('A', 0);
            item_list.Add('B', 0);
            item_list.Add('C', 0);
            item_list.Add('D', 0);
            item_list.Add('E', 0);
            _pricingRules = rules;
        }
       
        /// <summary>
        /// Only adds items A, B, C, D and E to the basket.
        /// </summary>
        /// <param name="item"></param>
        public void AddToBasket(string item)
        {
            item = item.ToUpper();
            foreach (char c in item)
            {
                if (item_list.ContainsKey(c))
                {
                    item_list[c]++; 
                }
            }
        }
        
        /// <summary>
        /// Sets the values of the Total_Cost struct and returns it.
        /// </summary>
        /// <returns></returns>
        public Total_Cost CalculateTotalPrice()
        {
            Total_Cost _cost = new Total_Cost();
            _cost.Total = Get_Total_Price();
            _cost.DeliveryCharge = DeliveryCharge(_cost.Total);
            return _cost;
        }
        
        /// <summary>
        /// Gets and returns the total discounted cost of the order.
        /// </summary>
        /// <returns></returns>
        public double Get_Total_Price()
        {
           return  _pricingRules(item_list);
        }
        
        /// <summary>
        /// Calculates the delivery charge of the order.
        /// </summary>
        /// <param name="total_price"></param>
        /// <returns></returns>
        public int DeliveryCharge(double total_price)
        {
            if (total_price < 50 && total_price > 0)
            {
                return 7;
            }
            else
            {
                return 0;
            }
        }
    }
    /// <summary>
    /// Holds a double for total discounted price and an int for the delivery charge.
    /// </summary>
    public struct Total_Cost
    {
        public double Total;
        public int DeliveryCharge;
    }
}
