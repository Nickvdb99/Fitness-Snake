using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
       
        // integers for deciding (X,Y) snake
        public Circle()
        {
            //resetting the integers to 0
            X = 0;
            Y = 0;
        }
    }
}
