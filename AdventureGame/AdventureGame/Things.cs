using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Things
    {  
        protected string name;

        protected string desc;

        public void setName(string name)
        {
            this.name = name;
        }
        public void setDesc(string d)
        {
            this.desc = d;
        }
        
        public string getName()
        {
            return this.name;
        }
        public string getDesc()
        {
            return this.desc;
        }
    }
}
