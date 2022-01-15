using System;
using System.Collections.Generic;
using System.Text;

namespace KckProject3.Models
{
    public class Game
    {
        public string Name { get; set; }
        public Developer Developer { get; set; }
        public Publisher Publisher { get; set; }
        public DateTime PublishYear { get; set; }
        public decimal Price { get; set; }
        public decimal Promotion { get; set; }
        public string Image { get; set; }
        public string Platform { get; set; }
        public string Logo { get; set; }
        public string Trailer { get; set; } = "bfTrailer.mp4";
        public string Describtion { get; set; }
        public Game(string name, decimal price, string image, int promotion)
        {
            Name = name;
            Price = price;
            Promotion = promotion;
            Image = image;
        }
        public Game(){}
    }
}
