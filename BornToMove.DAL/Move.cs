using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class Move
    {
        public int Id { get; init; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int sweatRate { get; set; }
        public ICollection<MoveRating> Ratings { get; set; }

    }
}
