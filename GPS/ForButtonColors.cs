using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS
{
    public class ForButtonColors
    {
        private static ForButtonColors instance = null;
        private int counter = 0;

        public static int status { get; set; }

        public static ForButtonColors GetColorClass
        {
            get
            {
                if (instance == null)
                {
                    instance = new ForButtonColors();
                    
                }
                return instance;
            }
        }
        private ForButtonColors()
        {
            counter = 1;
        }

        enum Color
        {
            Red = 0,
            Orange = 1,
            Green = 2,
            Grey = 3
        }

    }
}
