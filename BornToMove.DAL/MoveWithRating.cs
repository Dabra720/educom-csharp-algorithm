using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class MoveWithRating
    {
        public Move Move { get; set; }
        public double AverageRating { get; set; }
        //public double AverageVote { get; set; }
    }
}
