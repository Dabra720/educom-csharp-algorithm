using BornToMove.DAL;

namespace BornToMove.Business
{
    public class BuMove
    {
        private readonly MoveCrud crud;

        public BuMove(MoveCrud moveCrud)
        {
            crud = moveCrud;
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

        public List<Move> GetAllMoves()
        {
            List<Move> moves = crud.ReadAllMoves();
            return moves;
        }

        public Move? GetMoveById(int id)
        {
            Move? move = crud.ReadMoveById(id);
            return move;
        }

        public MoveWithRating? GetMoveByName(string name)
        {
            MoveWithRating? move = crud.ReadMoveByName(name);
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
                move = move,
                Rating = rating,
                Vote = vote
            };

            int ratingId = crud.CreateMoveRating(moveRating);

            return ratingId;
        }
    }
}