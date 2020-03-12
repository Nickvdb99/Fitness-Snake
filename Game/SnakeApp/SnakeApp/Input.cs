using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Windows.Forms;

namespace SnakeApp
{
    class Input
    {
        private static Hashtable keyTable = new Hashtable();
        // this class is used to optimize keys inserted in it

        public static bool KeyPress(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool)keyTable[key];
        }

        public static void changeState(Keys key,bool state)
        {
            keyTable[key] = state;
        }
    }
}
