using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Born2Move.Controller
{
    internal class Controller
    {
        private CRUD.Crud crud;
        private View.View view;
        
        public Controller(CRUD.Crud crud = null)
        {
            this.crud = crud;
            view = new View.View();
        }

        public void Start()
        {
            view.Welcome("Welkom!");
            view.Welcome("Het is weer tijd om te bewegen!");

            string choice = view.ListOrSuggestion();

            switch (choice)
            {
                case "1":
                    PickMove();
                    break;
                case "2":
                    view.ShowSuggestion();
                    break;
                case "0":
                    Console.WriteLine("Nieuwe move!!");
                    break;
            }
        }

        public void PickMove()
        {

        }
        


    }
}
