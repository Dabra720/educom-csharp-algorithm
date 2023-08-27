using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL.Contracts
{
    public interface IMoveCrud
    {
        int Create(Move move);
        int CreateMoveRating(MoveRating rating);
        void Delete(int id);
        List<int> ReadAllMoveIds();
        List<Move> ReadAllMoves();
        List<MoveWithRating> ReadAllMoveWithRatings();
        Move? ReadMoveById(int id);
        MoveWithRating? ReadMoveByName(string name);
        MoveRating? ReadMoveRatingById(int id);
        MoveWithRating? ReadMoveWithRatingById(int id);
        void Update(Move updated);
    }
}
