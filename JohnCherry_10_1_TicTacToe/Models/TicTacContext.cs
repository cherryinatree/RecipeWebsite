
using Microsoft.EntityFrameworkCore;

namespace JohnCherry_10_1_TicTacToe.Models
{
    public class TicTacContext : DbContext
    {
        public TicTacContext(DbContextOptions<TicTacContext> options) : base(options) { }

        //both of these are needed in order to show the catagory instead of the catagory ID.
        //this is because the user selects the catagory from a drop down menu instead of typing it. 
        public DbSet<TicTac> TicTacToe { get; set; } = null!;


        // data that the database starts with
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TicTac>().HasData(

                new TicTac
                {
                    Id = 1,
                    WhosTurn = "X",
                    square1 = "",
                    square2 = "",
                    square3 = "",
                    square4 = "",
                    square5 = "",
                    square6 = "",
                    square7 = "",
                    square8 = "",
                    square9 = "",
                    whoWon = ""

                }

                );
        }
        }
    }
