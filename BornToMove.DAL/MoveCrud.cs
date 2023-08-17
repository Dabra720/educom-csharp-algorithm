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

            id = move.id;
            
            return id;
        }

        public void update(Move updated)
        {
            var move = context.Move.Find(updated.id);
            move = updated;
            context.SaveChanges();

        }

        public void delete(int id) 
        {
            Move move = new Move { id = id };
            
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

        public Move readMoveByName(string name)
        {
            Move move = null;

            //move = context.Move.Where(a =>  a.id == id).Single();
            move = context.Move.FirstOrDefault(x => x.name == name);

            return move;
        }

        public List<Move> readAllMoves()
        {
            List<Move> moves = context.Move.ToList();

            return moves;
        }
    }
}
