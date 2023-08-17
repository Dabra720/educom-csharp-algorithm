using BornToMove.DAL;

namespace BornToMove.Business
{
    public class BuMove
    {
        private MoveCrud crud;

        public BuMove()
        {
            crud = new MoveCrud();
        }

        public Move GetRandomMove()
        {
            List<Move> allMoves = crud.readAllMoves();

            Random rdm = new Random();
            int randomIndex = rdm.Next(0, allMoves.Count);

            Move move = allMoves[randomIndex];

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

        public Move GetMoveByName(string name)
        {
            Move move = crud.readMoveByName(name);
            return move;
        }

        public int SaveMove(Move move)
        {
            if (crud.readMoveByName(move.name) != null) return 0; // Already exists

            int id = crud.create(move);

            return id;
        }

        public void UpdateMove(Move updated)
        {
            if (crud.readMoveByName(updated.name) != null) return; // Name already exists

            crud.update(updated);
        }

        public void DeleteMove(int id) { crud.delete(id); }
    }
}