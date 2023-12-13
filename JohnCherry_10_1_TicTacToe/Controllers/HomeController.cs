using JohnCherry_10_1_TicTacToe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JohnCherry_10_1_TicTacToe.Controllers
{
    public class HomeController : Controller
    {

        private TicTacContext context { get; set; }

        public HomeController(TicTacContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Index()
        {

            var board = context.TicTacToe.Find(1);

            if (board.whoWon != "")
            {
                if (board.whoWon == "tie")
                {
                    ViewBag.Action = "It's a Tie!";
                }
                else
                {

                    ViewBag.Action = board.whoWon + " Won";
                }
            }
            else
            {

                if(board.WhosTurn == "")
                {
                    board.WhosTurn = "X";
                    context.TicTacToe.Update(board);
                    context.SaveChanges();
                }
                ViewBag.Action = board.WhosTurn + "'s Turn";
            }



            return View(board);
        }

        [HttpPost]
        public IActionResult Index(TicTac tic)
        {
            Console.WriteLine("1111111111111");
            Console.WriteLine("1111111111111");
            Console.WriteLine("1111111111111");
            var board = context.TicTacToe.Find(1);

            board.whoWon = "";
            board.WhosTurn = "";
            board.square1 = "";
            board.square2 = "";
            board.square3 = "";
            board.square4 = "";
            board.square5 = "";
            board.square6 = "";
            board.square7 = "";
            board.square8 = "";
            board.square9 = "";

            context.TicTacToe.Update(board);
            context.SaveChanges();

            Console.WriteLine("XXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXX");

            return RedirectToAction("Index", "Home");
        }

            [HttpPost]
        public IActionResult Update([FromRoute] int id)
        {
            Console.WriteLine("xxxxxxxxx");
            Console.WriteLine(id);
            Console.WriteLine("xxxxxxxxx");

            var tic = context.TicTacToe.Find(1);
            tic = AddMark(tic, id);
            context.TicTacToe.Update(tic);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        private TicTac AddMark(TicTac tic, int id)
        {

            if (tic.whoWon != "") return tic;

            bool alreadyMarked = true;
            if (id == 1) if (tic.square1 == "") { tic.square1 = tic.WhosTurn; alreadyMarked = false; }
            if (id == 2) if (tic.square2 == "") { tic.square2 = tic.WhosTurn; alreadyMarked = false; }
            if (id == 3) if (tic.square3 == "") { tic.square3 = tic.WhosTurn; alreadyMarked = false; }
            if (id == 4) if (tic.square4 == "") { tic.square4 = tic.WhosTurn; alreadyMarked = false; }
            if (id == 5) if (tic.square5 == "") { tic.square5 = tic.WhosTurn; alreadyMarked = false; }
            if (id == 6) if (tic.square6 == "") { tic.square6 = tic.WhosTurn; alreadyMarked = false; }
            if (id == 7) if (tic.square7 == "") { tic.square7 = tic.WhosTurn; alreadyMarked = false; }
            if (id == 8) if (tic.square8 == "") { tic.square8 = tic.WhosTurn; alreadyMarked = false; }
            if (id == 9) if (tic.square9 == "") { tic.square9 = tic.WhosTurn; alreadyMarked = false; }

            if (alreadyMarked) return tic;

            if (tic.WhosTurn == "X")
                {
                    tic.WhosTurn = "O";
                }
                else
                {
                    tic.WhosTurn = "X";
                }


            VictoryCheck(tic);

            return tic;
        }

        private TicTac VictoryCheck(TicTac tic)
        {
            string[] squares = MakeStringArray(tic);

            if (squares[0] == "X" && squares[1] == "X" && squares[2] == "X") { tic.whoWon = "X"; return tic; }
            if (squares[3] == "X" && squares[4] == "X" && squares[5] == "X") { tic.whoWon = "X"; return tic; }
            if (squares[6] == "X" && squares[7] == "X" && squares[8] == "X") { tic.whoWon = "X"; return tic; }

            if (squares[0] == "X" && squares[3] == "X" && squares[6] == "X") { tic.whoWon = "X"; return tic; }
            if (squares[1] == "X" && squares[4] == "X" && squares[7] == "X") { tic.whoWon = "X"; return tic; }
            if (squares[2] == "X" && squares[5] == "X" && squares[8] == "X") { tic.whoWon = "X"; return tic; }

            if (squares[0] == "X" && squares[4] == "X" && squares[8] == "X") { tic.whoWon = "X"; return tic; }
            if (squares[6] == "X" && squares[4] == "X" && squares[2] == "X") { tic.whoWon = "X"; return tic; }

            //===================================================================================================

            if (squares[0] == "O" && squares[1] == "O" && squares[2] == "O") { tic.whoWon = "O"; return tic; }
            if (squares[3] == "O" && squares[4] == "O" && squares[5] == "O") { tic.whoWon = "O"; return tic; }
            if (squares[6] == "O" && squares[7] == "O" && squares[8] == "O") { tic.whoWon = "O"; return tic; }

            if (squares[0] == "O" && squares[3] == "O" && squares[6] == "O") { tic.whoWon = "O"; return tic; }
            if (squares[1] == "O" && squares[4] == "O" && squares[7] == "O") { tic.whoWon = "O"; return tic; }
            if (squares[2] == "O" && squares[5] == "O" && squares[8] == "O") { tic.whoWon = "O"; return tic; }

            if (squares[0] == "O" && squares[4] == "O" && squares[8] == "O") { tic.whoWon = "O"; return tic; }
            if (squares[6] == "O" && squares[4] == "O" && squares[2] == "O") { tic.whoWon = "O"; return tic; }

            //===================================================================================================

            int squareCheck = 0;
            for(int i = 0; i<9; i++)
            {
                if(squares[i] == "")
                {
                    squareCheck++;
                }
            }

            if (squareCheck == 0)
            {
                tic.whoWon = "tie";
            }


            return tic;
        }

        private string[] MakeStringArray(TicTac tic)
        {
            string[] squares = new string[9];
            squares[0] = tic.square1;
            squares[1] = tic.square2;
            squares[2] = tic.square3;
            squares[3] = tic.square4;
            squares[4] = tic.square5;
            squares[5] = tic.square6;
            squares[6] = tic.square7;
            squares[7] = tic.square8;
            squares[8] = tic.square9;

            return squares;
        }


        [HttpPost]
        public IActionResult NewGame(TicTac tic)
        {
            var board = context.TicTacToe.Find(1);

            board.whoWon = "";
            board.WhosTurn = "";
            board.square1 = "";
            board.square2 = "";
            board.square3 = "";
            board.square4 = "";
            board.square5 = "";
            board.square6 = "";
            board.square7 = "";
            board.square8 = "";
            board.square9 = "";

            context.TicTacToe.Update(board);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}