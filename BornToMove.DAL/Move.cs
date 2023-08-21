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
        public string Name { get; set; }
        public string Description { get; set; }
        public int sweatRate { get; set; }
        public ICollection<MoveRating> Ratings { get; set; }

        public void Show()
        {
            Console.WriteLine("Naam: " + Name + " | Sweatrate: " + sweatRate);
        }
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
