using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes___Part_1
{
    public class Display
    {
        private double? displaySize;
        private string displayColors;

        public string DisplayColors
        {
            get
            {
                return this.displayColors;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input for colors.");
                }

                this.displayColors = value;
            }
        }

        public double? DisplaySize
        {
            get
            {
                return this.displaySize;
            }
            set
            {
                if (!value.HasValue || (value.HasValue && value < 1))
                {
                    throw new ArgumentException("Display size cannot be set to less than 1 inch.");
                }

                this.displaySize = value;
            }
        }

        public Display()
        {

        }

        private Display(double? size, string colors)
        {
            this.DisplaySize = size;
            this.DisplayColors = colors;
        }
    }
}
