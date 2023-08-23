using BornToMove.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BornToMove
{
    internal class View
    {
        public void ShowMove(MoveWithRating move) {
            Console.WriteLine(move.Move.Id + ". " + move.Move.Name + " | Rating: " + move.AverageRating);
        }

        public void ShowMoveList(List<MoveWithRating> allMoves)
        {
            for (int i = 0; i < allMoves.Count; i++)
            {
                MoveWithRating move = allMoves[i];
                Console.WriteLine((i + 1) + ". " + move.Move.Name + " | Rating: " + move.AverageRating);
            }
        }
    }
}
