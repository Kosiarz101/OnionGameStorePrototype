using System;
using System.Collections.Generic;
using System.Text;

namespace KckProject3.Models
{
    public class Developer
    {
        public string Name { get; set; }
        public Publisher Publisher { get; set; }
        public string Country { get; set; }
        public string Describtion { get; set; }
        public string Logo { get; set; }
        public string LogoBackgroundColor { get; set; } = "AliceBlue";
        public DateTime CreationYear { get; set; }
    }
}
