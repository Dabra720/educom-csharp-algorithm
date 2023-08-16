using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class Move
    {
        public int id { get; init; }
        public string name { get; set; }
        public string description { get; set; }
        public int sweatRate { get; set; }

       /* public Move(int id, string name, string description, int sweatRate)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.sweatRate = sweatRate;
        }

        public Move(string name, string description, int sweatRate)
        {
            this.name = name;
            this.description = description;
            this.sweatRate= sweatRate;
        }*/
    }
}
