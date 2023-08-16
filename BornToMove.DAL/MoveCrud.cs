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

        public int create(Move move)
        {
            int id = 0;
            using(var context = new MoveContext())
            {
                context.Move.Add(move);
                context.SaveChanges();

                id = move.id;
            }
            return id;
        }

        public bool update(Move updated)
        {

            return true;
        }

        public void delete(int id) 
        {
            Move move = new Move { id = id };
            using (var context = new MoveContext())
            {
                context.Move.Remove(move);
                context.SaveChanges();
            }
        }

        public Move readMoveById(int id)
        {
            Move move = null;
            using(var context = new MoveContext())
            {
                //move = context.Move.Where(a =>  a.id == id).Single();
                move = context.Move.Find(id);
            }
            return move;
        }
    }
}
