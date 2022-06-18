using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaddersAndSnakes
{
    public class Game
    {
        Board board;
        Player bot = new Player();
        Player player = new Player();
        public int[] getIndexes(Player playerOrBot)
        {
            int[] indexes = new int[2];
            int column, row;
            if (playerOrBot.points / 10 % 2 == 0 && playerOrBot.points % 10 == 0)
            {
                column = playerOrBot.points / 10 - 1;
                row = playerOrBot.points % 10;
            }
            if (playerOrBot.points / 10 % 2 != 0 && playerOrBot.points % 10 == 0)
            {
                column = playerOrBot.points / 10 - 1;
                row = playerOrBot.points % 10 + 9;
            }
            if (playerOrBot.points / 10 % 2 == 0 && playerOrBot.points % 10 != 0)
            {
                column = playerOrBot.points / 10;
                row = playerOrBot.points % 10 - 1;
            }
            if (playerOrBot.points / 10 % 2 != 0 && playerOrBot.points % 10 != 0)
            {
                column = playerOrBot.points / 10;
                row = 10 - (playerOrBot.points % 10);
            }
                return indexes;
        }
        public void checkIfCellSpecial(Player playerOrBot, int[] indexes)
        {
            int column = indexes[0];
            int row = indexes[1];
            bool canBreakLoop = false;
            if (board.cells[column, row].ladder.start != 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board.cells[i, j].ladder.start == board.cells[column, row].ladder.start && board.cells[i, j].number > board.cells[column, row].number)
                        {
                            if (board.cells[i, j].player1.name != "")
                            {
                                board.cells[i, j].player2.name = playerOrBot.name;
                                playerOrBot.points = board.cells[i, j].number;
                                if (board.cells[column, row].player1.name == playerOrBot.name)
                                {
                                    board.cells[column, row].player1.name = "";
                                }
                                else
                                {
                                    board.cells[column, row].player2.name = "";
                                }
                            }
                            else
                            {
                                board.cells[i, j].player1.name = playerOrBot.name;
                                playerOrBot.points = board.cells[i, j].number;
                                if (board.cells[column, row].player1.name == playerOrBot.name)
                                {
                                    board.cells[column, row].player1.name = "";
                                }
                                else
                                {
                                    board.cells[column, row].player2.name = "";
                                }
                            }
                            Console.WriteLine(playerOrBot.name + "-" + playerOrBot.points);
                            canBreakLoop = true;
                            break;
                        }
                    }
                    if (canBreakLoop == true)
                    {
                        break;
                    }
                }
            }
            canBreakLoop = false;
            if (board.cells[column, row].snake.start != 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board.cells[i, j].snake.start == board.cells[column, row].snake.start && board.cells[i, j].number < board.cells[column, row].number)
                        {
                            if (board.cells[i, j].player1.name != "")
                            {
                                board.cells[i, j].player2.name = playerOrBot.name;
                                playerOrBot.points = board.cells[i, j].number;
                                if (board.cells[column, row].player1.name == playerOrBot.name)
                                {
                                    board.cells[column, row].player1.name = "";
                                }
                                else
                                {
                                    board.cells[column, row].player2.name = "";
                                }
                            }
                            else
                            {
                                board.cells[i, j].player1.name = playerOrBot.name;
                                playerOrBot.points = board.cells[i, j].number;
                                if (board.cells[column, row].player1.name == playerOrBot.name)
                                {
                                    board.cells[column, row].player1.name = "";
                                }
                                else
                                {
                                    board.cells[column, row].player2.name = "";
                                }
                            }
                            Console.WriteLine(playerOrBot.name + "-" + playerOrBot.points);
                            canBreakLoop = true;
                            break;
                        }
                    }
                    if (canBreakLoop == true)
                    {
                        break;
                    }
                }
            }
            canBreakLoop = false;
            if (board.cells[column, row].isGolden == true)
            {
                for (int i = 9; i >= 0; i--)
                {
                    for (int j = 9; j >= 0; j--)
                    {
                        if (board.cells[i, j].player1.name != "" || board.cells[i, j].player2.name != "" && board.cells[i, j].number > playerOrBot.points)
                        {
                            playerOrBot.points = board.cells[i, j].number;
                            if (board.cells[i, j].player1.name == player.name)
                            {
                                board.cells[i, j].player1.name = bot.name;
                                player.points = board.cells[column, row].number;
                                board.cells[column, row].player1.name = player.name;
                            }

                            if(board.cells[i, j].player1.name == bot.name)
                            {
                                board.cells[i, j].player1.name = player.name;
                                bot.points = board.cells[column, row].number;
                                board.cells[column, row].player1.name = bot.name;
                            }

                            if (board.cells[i, j].player2.name == player.name)
                            {
                                board.cells[i, j].player2.name = bot.name;
                                player.points = board.cells[column, row].number;
                                board.cells[column, row].player2.name = player.name;
                            }

                            if (board.cells[i, j].player2.name == bot.name)
                            {
                                board.cells[i, j].player2.name = player.name;
                                bot.points = board.cells[column, row].number;
                                board.cells[column, row].player2.name = bot.name;
                            }
                            Console.WriteLine(playerOrBot.name + "-" + playerOrBot.points);
                            canBreakLoop = true;
                            break;
                        }
                    }
                    if (canBreakLoop == true)
                    {
                        break;
                    }
                }
            }
        }
        public void playGame()
        {
            int column, row;
            int ladders, snakes;
            int diceSum;
            int[] indexes = new int[2];
            bot.name = "npc1";
            Console.WriteLine("Type your name");
            player.name = Console.ReadLine();
            Console.WriteLine("Type number of ladders");
            ladders = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type number of snakes");
            snakes = Convert.ToInt32(Console.ReadLine());
            board = new Board(ladders, snakes);
            board.createBoard();
            Console.WriteLine("Board:");
            Console.WriteLine("[number],[number] = [ladder start],[ladder end]");
            Console.WriteLine("{number},{number} = {snake start},{snake end}");
            Console.WriteLine("golden = golden cell");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(board.cells[i, j].ladder.start != 0)
                    {
                        Console.Write("[" + board.cells[i, j].ladder.start + "]," + "[" + board.cells[i, j].ladder.end + "],");
                    }
                    else if(board.cells[i, j].snake.start != 0)
                    {
                        Console.Write("{" + board.cells[i, j].snake.start + "}," + "{" + board.cells[i, j].snake.end + "},");
                    }
                    else if (board.cells[i, j].isGolden == true)
                    {
                        Console.Write("golden,");
                    }
                    else
                    {
                        Console.Write(board.cells[i, j].number+",");
                    }
                }
                Console.WriteLine();
            }
            while(player.points < 100 && bot.points < 100)
            {
                Console.WriteLine("Player points:");
                Console.WriteLine(player.name + "-" + player.points);
                diceSum = player.throwDice();
                player.points += diceSum;
                indexes = getIndexes(player);
                checkIfCellSpecial(player, indexes);
                if(player.points >= 100)
                {
                    break;
                }

                Console.WriteLine("Bot points:");
                Console.WriteLine(bot.name + "-" + bot.points);
                diceSum = bot.throwDice();
                bot.points += diceSum;
                indexes = getIndexes(bot);
                checkIfCellSpecial(bot, indexes);
                if (bot.points >= 100)
                {
                    break;
                }
            }
            if(player.points > bot.points)
            {
                Console.WriteLine(player.name + "-" + player.points);
                Console.WriteLine(player.name + " wins the game!");
            }
            else
            {
                Console.WriteLine(bot.name + "-" + bot.points);
                Console.WriteLine(bot.name + " wins the game!");
            }
        }
    }
    
}
