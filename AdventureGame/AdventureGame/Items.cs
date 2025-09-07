using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Items:Things
    {
        private int value; //use or not use
        private int loc;

        public void setLoc(int r) { loc = r; }
        public int getLoc() { return loc; }//tell me return location



        public void setValue(int v) { this.value = v; }
        public int getValue() { return this.value; }
    }
}
