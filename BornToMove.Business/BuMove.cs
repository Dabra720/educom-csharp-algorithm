using BornToMove.DAL;

namespace BornToMove.Business
{
    public class BuMove
    {
        private MoveCrud crud;

        public BuMove(MoveCrud moveCrud)
        {
            crud = moveCrud;
        }

        public Move GetRandomMove()
        {
            //List<Move> allMoves = crud.readAllMoves();
            List<int> moveIds = crud.readAllMoveIds();

            Random rdm = new Random();
            int randomIndex = rdm.Next(0, moveIds.Count);// allMoves.Count);

            Move move = crud.readMoveById(moveIds[randomIndex]);//allMoves[randomIndex];

            return move;
        }

        public List<Move> GetAllMoves()
        {
            List<Move> moves = crud.readAllMoves();
            return moves;
        }

        public Move GetMoveById(int id)
        {
            Move move = crud.readMoveById(id);
            return move;
        }

        public MoveWithRating GetMoveByName(string name)
        {
            MoveWithRating move = crud.readMoveByName(name);
            return move;
        }

        public int SaveMove(Move move)
        {
            if (crud.readMoveByName(move.Name) != null) return 0; // Already exists

            int id = crud.create(move);

            return id;
        }

        public void UpdateMove(Move updated)
        {
            if (crud.readMoveByName(updated.Name) != null) return; // Name already exists

            crud.update(updated);
        }

        public void DeleteMove(int id) { crud.delete(id); }

        public int SaveRating(double rating, double vote, Move move)
        {
            var moveRating = new MoveRating
            {
                move = move,
                Rating = rating,
                Vote = vote
            };

            int ratingId = crud.createMoveRating(moveRating);

            return ratingId;
        }
    }
}