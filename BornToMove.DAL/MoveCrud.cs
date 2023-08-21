using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class MoveCrud
    {
        private MoveContext context;

        public MoveCrud()
        {
            context = new MoveContext();
        }

        public int create(Move move)
        {
            int id = 0;

            context.Move.Add(move);
            context.SaveChanges();

            id = move.Id;
            
            return id;
        }

        public void update(Move updated)
        {
            var move = context.Move.Find(updated.Id);
            move.Name = updated.Name;
            move.Description = updated.Description;
            move.sweatRate = updated.sweatRate;
            context.SaveChanges();

        }

        public void delete(int id) 
        {
            Move move = new Move { Id = id };
            
            context.Move.Remove(move);
            context.SaveChanges();
            
        }

        public Move readMoveById(int id)
        {
            Move move = null;
            
            //move = context.Move.Where(a =>  a.id == id).Single();
            move = context.Move.Find(id);
            
            return move;
        }

        public MoveWithRating readMoveByName(string name)
        {
            //Move move = null;

            //move = context.Move.Where(a =>  a.id == id).Single();
            //move = context.Move.FirstOrDefault(x => x.Name == name);

            var move = context.Move
                .Select(move => new MoveWithRating()
                {
                    Move = move,
                    AverageRating = move.Ratings.Select(r=>r.Rating)
                                                .DefaultIfEmpty()
                                                .Average()
                })
                .Where(move => move.Move.Name == name)
                .First();

            return move;
        }

        public List<Move> readAllMoves()
        {
            List<Move> moves = context.Move.ToList();

            return moves;
        }

        public List<int> readAllMoveIds()
        {
            List<int> moveIds = context.Move.Select(move => move.Id).ToList();

            return moveIds;
        }

        public int createMoveRating(MoveRating rating)
        {
            var ratingId = 0;
            
            context.MoveRating.Add(rating);
            context.SaveChanges();

            ratingId = rating.Id;

            return ratingId;
        }

        public MoveRating readMoveRatingById(int id)
        {
            var moveRating = context.MoveRating.Find(id);
            return moveRating;
        }
    }
}
