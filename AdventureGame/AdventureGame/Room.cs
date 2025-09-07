using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Room:Things
    {
        private int[] exits = new int[4];
        //create an empty array of intergers of the lenth 4

        public void setExits(int n, int s, int e, int w)
        {
            exits[0] = n;
            exits[1] = s;
            exits[2] = e;
            exits[3] = w;

            //need to add getters(vandan)

        }

        public int getNorth() { return exits[0]; }
        public int getSouth() { return exits[1]; }
        public int getEast() { return exits[2]; }
        public int getWest() { return exits[3]; }
    }
}
