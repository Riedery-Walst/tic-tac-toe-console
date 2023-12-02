using System;
using System.Linq;

namespace tic_tac_toe
{
  internal class Program
{
    static readonly char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int playerTurn = 1; 

    static void Main()
    {
        int choice;
        bool validInput;

        do
        {
            Console.Clear();
            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine("\n");
            Console.WriteLine($"  {board[0].ToString()}  |  {board[1].ToString()}  |  {board[2].ToString()}  ");
            Console.WriteLine($"  {board[3].ToString()}  |  {board[4].ToString()}  |  {board[5].ToString()}  ");
            Console.WriteLine($"  {board[6].ToString()}  |  {board[7].ToString()}  |  {board[8].ToString()}  ");
            validInput = false;

            do
            {
                Console.Write($"Player {playerTurn.ToString()}, choose your position (1-9): ");
                string input = Console.ReadLine();
                validInput = Int32.TryParse(input, out choice);

                if (!validInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    validInput = false;
                }
            } while (!validInput);

            if (playerTurn % 2 == 0)
                board[choice - 1] = 'O';
            else
                board[choice - 1] = 'X';

            playerTurn = (playerTurn % 2) + 1;

        } while (!CheckForWin() && !CheckForDraw());

        Console.Clear();
        Console.WriteLine("Game Over!");

        if (CheckForDraw())
            Console.WriteLine("It's a draw!");
        else
            Console.WriteLine($"Player {(playerTurn % 2 == 0 ? 1 : 2).ToString()} wins!");

        Console.ReadLine();
    }

    static bool CheckForWin()
    {
        return (CheckLine(0, 1, 2) || CheckLine(3, 4, 5) || CheckLine(6, 7, 8) ||
                CheckLine(0, 3, 6) || CheckLine(1, 4, 7) || CheckLine(2, 5, 8) ||
                CheckLine(0, 4, 8) || CheckLine(2, 4, 6));
    }

    static bool CheckLine(int a, int b, int c)
    {
        return (board[a] == board[b] && board[b] == board[c]);
    }

    private static bool CheckForDraw()
    {
        return board.All(position => position == 'X' || position == 'O');
    } 
  }

}
