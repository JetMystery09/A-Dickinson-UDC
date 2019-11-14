using System;
using System.Collections.Generic;

namespace UNiDAYS_Discounts_Coding_Challenge
{
    class Program
    {
        /// <summary>
        /// Performs discounts on Items A, B, C, D and E
        /// </summary>
        /// <param name="item_list"></param>
        /// <returns></returns>
        static double Pricing_Rules(Dictionary<char, int> item_list)
        {
            double total_price_discount = 0;
            foreach (var item in item_list)
            {
                if (item.Key == 'A')
                {
                    total_price_discount += item.Value * 8;
                }
                else if (item.Key == 'B')
                {
                    if (item.Value % 2 == 0)
                    {
                        total_price_discount += ((item.Value / 2) * 20);
                    }
                    else
                    {
                        total_price_discount += (((item.Value - 1) / 2) * 20) + 12;
                    }
                }
                else if (item.Key == 'C')
                {
                    if (item.Value % 3 == 0)
                    {
                        total_price_discount += ((item.Value / 2) * 10);
                    }
                    else if (item.Value % 3 == 1)
                    {
                        total_price_discount += (((item.Value - 1) / 2) * 10) + 4;
                    }
                    else
                    {
                        total_price_discount += (((item.Value - 2) / 2) * 10) + 8;
                    }
                }
                else if (item.Key == 'D')
                {
                    if (item.Value % 2 == 0)
                    {
                        total_price_discount += (item.Value * 7) / 2;
                    }
                    else
                    {
                        total_price_discount += (((item.Value - 1) * 7) / 2) + 7;
                    }
                }
                else if (item.Key == 'E')
                {
                    if (item.Value % 3 == 0)
                    {
                        total_price_discount += item.Value * (2.0 / 3.0) * 5;
                    }
                    else if (item.Value % 3 == 1)
                    {
                        total_price_discount += ((item.Value - 1) * 5 * (2.0 / 3.0)) + 5;
                    }
                    else
                    {
                        total_price_discount += ((item.Value - 2) * 5 * (2.0 / 3.0)) + 10;
                    }
                }
            }

            return total_price_discount;
        }

        static void Main(string[] args)
        {
            Total_Cost result;
            double totalPrice;
            int deliveryCharge;
            double overallTotal;

            UnidaysDiscountChallenge example = new UnidaysDiscountChallenge(Pricing_Rules);
            example.AddToBasket(""); //<----User inputs their items here. 
            example.AddToBasket(""); //<----User inputs their items here. 

            result = example.CalculateTotalPrice();
            totalPrice = result.Total;
            deliveryCharge = result.DeliveryCharge;
            overallTotal = totalPrice + deliveryCharge;
            Console.WriteLine($"Total Price: £{totalPrice}," +
            $" Delivery Charge: £{deliveryCharge}," +
            $" Overall Total: £{overallTotal}");
        }
    }
}
