using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class MoveRating
    {
        public int id { get; set; }
        public Move move { get; set; }
        public double rating { get; set; }
        public double vote { get; set; }
    }
}
