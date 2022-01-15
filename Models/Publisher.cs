using System;
using System.Collections.Generic;
using System.Text;

namespace KckProject3.Models
{
    public class Publisher
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string LogoBackgroundColor { get; set; } = "AliceBlue";
        public string Describtion { get; set; }
        public string Country { get; set; }
        public DateTime CreationYear { get; set; }
    }
}
