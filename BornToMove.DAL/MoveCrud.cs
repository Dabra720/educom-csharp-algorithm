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
        private readonly MoveContext context;

        public MoveCrud()
        {
            context = new MoveContext();
        }

        public int Create(Move move)
        {
            int id = 0;

            context.Move.Add(move);
            context.SaveChanges();

            id = move.Id;
            
            return id;
        }

        public void Update(Move updated)
        {
            var move = context.Move.Find(updated.Id);
            move.Name = updated.Name;
            move.Description = updated.Description;
            move.sweatRate = updated.sweatRate;
            context.SaveChanges();

        }

        public void Delete(int id) 
        {
            Move move = new() { Id = id };
            
            context.Move.Remove(move);
            context.SaveChanges();
            
        }

        public Move ReadMoveById(int id)
        {
            //move = context.Move.Where(a =>  a.id == id).Single();
            Move? move = context.Move.Find(id);
            return move;
        }

        public MoveWithRating? ReadMoveWithRatingById(int id)
        {
            var move = context.Move
                .Select(move => new MoveWithRating()
                {
                    Move = move,
                    AverageRating = move.Ratings.Select(r => r.Rating).Average()
                })
                .Where(m=> m.Move.Id == id)
                .FirstOrDefault();
            
            return move;
        }

        public MoveWithRating? ReadMoveByName(string name)
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
                .FirstOrDefault();

            return move;
        }

        public List<Move> ReadAllMoves()
        {
            List<Move> moves = context.Move.ToList();

            return moves;
        }

        public List<MoveWithRating?> ReadAllMoveWithRatings()
        {
            List<MoveWithRating?> moves = context.Move
                .Select(move => new MoveWithRating()
                {
                    Move = move,
                    AverageRating = move.Ratings.Select(r => r.Rating)
                                                .DefaultIfEmpty()
                                                .Average()
                })
                .DefaultIfEmpty()
                .ToList();

            return moves;
        }

        public List<int> ReadAllMoveIds()
        {
            List<int> moveIds = context.Move.Select(move => move.Id).ToList();

            return moveIds;
        }

        public int CreateMoveRating(MoveRating rating)
        {
            context.MoveRating.Add(rating);
            context.SaveChanges();

            var moveId = rating.Move.Id;

            return moveId;
        }

        public MoveRating? ReadMoveRatingById(int id)
        {
            var moveRating = context.MoveRating.Find(id);
            return moveRating;
        }
    }
}
