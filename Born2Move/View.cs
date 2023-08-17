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
        public void ShowMoveList(List<Move> allMoves)
        {
            for (int i = 0; i < allMoves.Count; i++)
            {
                Move move = allMoves[i];
                Console.WriteLine((i + 1) + ". " + move.name + " Sweatrate: " + move.sweatRate);
            }
        }
    }
}
