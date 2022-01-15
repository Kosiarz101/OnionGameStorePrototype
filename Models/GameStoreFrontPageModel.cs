using System;
using System.Collections.Generic;
using System.Text;

namespace KckProject3.Models
{
    public class GameStoreFrontPageModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Promotion { get; set; }
        public GameStoreFrontPageModel(string name, decimal price, string image, int promotion)
        {
            Name = name;
            Price = price;
            Image = image;
            Promotion = promotion;
        }
    }
}
