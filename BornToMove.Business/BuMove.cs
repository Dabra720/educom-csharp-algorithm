using BornToMove.DAL;
using BornToMove.DAL.Contracts;
using Organizer;

namespace BornToMove.Business
{
    public class BuMove
    {
        private readonly IMoveCrud crud;
        private RotateSort<MoveWithRating> sorter;

        public BuMove(IMoveCrud moveCrud)
        {
            crud = moveCrud;
            sorter = new RotateSort<MoveWithRating>();
        }

        public Move? GetRandomMove()
        {
            //List<Move> allMoves = crud.readAllMoves();
            List<int> moveIds = crud.ReadAllMoveIds();

            Random rdm = new();
            int randomIndex = rdm.Next(0, moveIds.Count);// allMoves.Count);

            Move? move = crud.ReadMoveById(moveIds[randomIndex]);//allMoves[randomIndex];

            return move;
        }
        public MoveWithRating GetRandomMoveWithRating()
        {
            List<int> moveIds = crud.ReadAllMoveIds();
            int rndIndex = new Random().Next(0, moveIds.Count);
            var move = crud.ReadMoveWithRatingById(moveIds[rndIndex]);
            return move;
        }

        public List<MoveWithRating> GetAllMoves()
        {
            List<MoveWithRating> moves = crud.ReadAllMoveWithRatings();
            moves = sorter.Sort(moves, new RatingsConverter());
            return moves;
        }

        public MoveWithRating? GetMoveById(int id)
        {
            MoveWithRating? move = crud.ReadMoveWithRatingById(id);
            return move;
        }

        public MoveWithRating? GetMoveByName(string name)
        {
            var move = crud.ReadMoveByName(name);
            return move;
        }

        public int SaveMove(Move move)
        {
            if (crud.ReadMoveByName(move.Name) != null) return 0; // Already exists

            int id = crud.Create(move);

            return id;
        }

        public void UpdateMove(Move updated)
        {
            if (crud.ReadMoveByName(updated.Name) != null) return; // Name already exists

            crud.Update(updated);
        }

        public void DeleteMove(int id) { crud.Delete(id); }

        public int SaveRating(double rating, double vote, Move move)
        {
            var moveRating = new MoveRating
            {
                Move = move,
                Rating = rating,
                Vote = vote
            };

            int ratingId = crud.CreateMoveRating(moveRating);

            return ratingId;
        }
    }
}