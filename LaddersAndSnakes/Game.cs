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
        public void playGame()
        {
            bool canBreakLoop = false;
            int column, row;
            int ladders, snakes;
            int diceSum;
            bot.name = "npc1";
            Console.WriteLine("Type your name");
            player.name = Console.ReadLine();
            Console.WriteLine("Type number of ladders");
            ladders = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type number of snakes");
            snakes = Convert.ToInt32(Console.ReadLine());
            board = new Board(ladders, snakes);
            board.createBoard();
            while(player.points < 100 && bot.points < 100)
            {
                Console.WriteLine("Player points:");
                Console.WriteLine(player.name + "-" + player.points);
                diceSum = player.throwDice();
                player.points += diceSum;
                if (player.points / 10 % 2 == 0 && player.points % 10 == 0)
                {
                    column = player.points / 10 - 1;
                    row = player.points % 10;
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
                                        board.cells[i, j].player2.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
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
                                        board.cells[i, j].player1.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if(canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (player.points >= 100)
                    {
                        break;
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
                                        board.cells[i, j].player2.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
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
                                        board.cells[i, j].player1.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (player.points >= 100)
                    {
                        break;
                    }
                    canBreakLoop = false;
                    if (board.cells[column, row].isGolden == true)
                    {
                        for (int i = 9; i >= 0; i--)
                        {
                            for (int j = 9; j >= 0; j--)
                            {
                                if (board.cells[i, j].player1.name != "" || board.cells[i, j].player2.name != "" && board.cells[i, j].number > player.points)
                                {
                                    player.points = board.cells[i, j].number;
                                    bot.points = board.cells[column, row].number;
                                    if (board.cells[i, j].player1.name != "")
                                    {
                                        board.cells[i, j].player1.name = player.name;
                                    }
                                    else
                                    {
                                        board.cells[i, j].player2.name = player.name;
                                    }
                                    if (board.cells[column, row].player1.name != "")
                                    {
                                        board.cells[column, row].player1.name = bot.name;
                                    }
                                    else
                                    {
                                        board.cells[column, row].player2.name = bot.name;
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }

                }
                if (player.points >= 100)
                {
                    break;
                }
                canBreakLoop = false;
                if (player.points / 10 % 2 != 0 && player.points % 10 == 0)
                {
                    column = player.points / 10 - 1;
                    row = player.points % 10 + 9;
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
                                        board.cells[i, j].player2.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
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
                                        board.cells[i, j].player1.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (player.points >= 100)
                    {
                        break;
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
                                        board.cells[i, j].player2.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
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
                                        board.cells[i, j].player1.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (player.points >= 100)
                    {
                        break;
                    }
                    canBreakLoop = false;
                    if (board.cells[column, row].isGolden == true)
                    {
                        for (int i = 9; i >= 0; i--)
                        {
                            for (int j = 9; j >= 0; j--)
                            {
                                if (board.cells[i, j].player1.name != "" || board.cells[i, j].player2.name != "" && board.cells[i, j].number > player.points)
                                {
                                    player.points = board.cells[i, j].number;
                                    bot.points = board.cells[column, row].number;
                                    if (board.cells[i, j].player1.name != "")
                                    {
                                        board.cells[i, j].player1.name = player.name;
                                    }
                                    else
                                    {
                                        board.cells[i, j].player2.name = player.name;
                                    }
                                    if (board.cells[column, row].player1.name != "")
                                    {
                                        board.cells[column, row].player1.name = bot.name;
                                    }
                                    else
                                    {
                                        board.cells[column, row].player2.name = bot.name;
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                }
                if (player.points >= 100)
                {
                    break;
                }
                canBreakLoop = false;
                if (player.points / 10 % 2 == 0 && player.points % 10 != 0)
                {
                    column = player.points / 10;
                    row = player.points % 10 - 1;
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
                                        board.cells[i, j].player2.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
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
                                        board.cells[i, j].player1.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (player.points >= 100)
                    {
                        break;
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
                                        board.cells[i, j].player2.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
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
                                        board.cells[i, j].player1.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (player.points >= 100)
                    {
                        break;
                    }
                    canBreakLoop = false;
                    if (board.cells[column, row].isGolden == true)
                    {
                        for (int i = 9; i >= 0; i--)
                        {
                            for (int j = 9; j >= 0; j--)
                            {
                                if (board.cells[i, j].player1.name != "" || board.cells[i, j].player2.name != "" && board.cells[i, j].number > player.points)
                                {
                                    player.points = board.cells[i, j].number;
                                    bot.points = board.cells[column, row].number;
                                    if (board.cells[i, j].player1.name != "")
                                    {
                                        board.cells[i, j].player1.name = player.name;
                                    }
                                    else
                                    {
                                        board.cells[i, j].player2.name = player.name;
                                    }
                                    if (board.cells[column, row].player1.name != "")
                                    {
                                        board.cells[column, row].player1.name = bot.name;
                                    }
                                    else
                                    {
                                        board.cells[column, row].player2.name = bot.name;
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                }
                if (player.points >= 100)
                {
                    break;
                }
                canBreakLoop = false;
                if (player.points / 10 % 2 != 0 && player.points % 10 != 0)
                {
                    column = player.points / 10;
                    row = 10 - (player.points % 10);
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
                                        board.cells[i, j].player2.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
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
                                        board.cells[i, j].player1.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (player.points >= 100)
                    {
                        break;
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
                                        board.cells[i, j].player2.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
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
                                        board.cells[i, j].player1.name = player.name;
                                        player.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == player.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (player.points >= 100)
                    {
                        break;
                    }
                    canBreakLoop = false;
                    if (board.cells[column, row].isGolden == true)
                    {
                        for (int i = 9; i >= 0; i--)
                        {
                            for (int j = 9; j >= 0; j--)
                            {
                                if (board.cells[i, j].player1.name != "" || board.cells[i, j].player2.name != "" && board.cells[i, j].number > player.points)
                                {
                                    player.points = board.cells[i, j].number;
                                    bot.points = board.cells[column, row].number;
                                    if (board.cells[i, j].player1.name != "")
                                    {
                                        board.cells[i, j].player1.name = player.name;
                                    }
                                    else
                                    {
                                        board.cells[i, j].player2.name = player.name;
                                    }
                                    if (board.cells[column, row].player1.name != "")
                                    {
                                        board.cells[column, row].player1.name = bot.name;
                                    }
                                    else
                                    {
                                        board.cells[column, row].player2.name = bot.name;
                                    }
                                    Console.WriteLine(player.name + "-" + player.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                }
                if(player.points >= 100)
                {
                    break;
                }
                canBreakLoop = false;
                Console.WriteLine("Bot points:");
                Console.WriteLine(bot.name + "-" + bot.points);
                diceSum = bot.throwDice();
                bot.points += diceSum;
                if (bot.points / 10 % 2 == 0 && bot.points % 10 == 0)
                {
                    column = bot.points / 10 - 1;
                    row = bot.points % 10;
                    canBreakLoop = false;
                    if (board.cells[column, row].ladder.start != 0)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                if(board.cells[i, j].ladder.start == board.cells[column, row].ladder.start && board.cells[i, j].number > board.cells[column, row].number)
                                {
                                    if(board.cells[i, j].player1.name != "")
                                    {
                                        board.cells[i, j].player2.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
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
                                        board.cells[i, j].player1.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (bot.points >= 100)
                    {
                        break;
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
                                        board.cells[i, j].player2.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
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
                                        board.cells[i, j].player1.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (bot.points >= 100)
                    {
                        break;
                    }
                    canBreakLoop = false;
                    if (board.cells[column, row].isGolden == true)
                    {
                        for(int i = 9; i >= 0; i--)
                        {
                            for(int j = 9; j >= 0; j--)
                            {
                                if(board.cells[i, j].player1.name != "" || board.cells[i, j].player2.name != "" && board.cells[i, j].number > bot.points)
                                {
                                    bot.points = board.cells[i, j].number;
                                    player.points = board.cells[column, row].number;
                                    if (board.cells[i, j].player1.name != "")
                                    {
                                        board.cells[i, j].player1.name = bot.name;
                                    }
                                    else
                                    {
                                        board.cells[i, j].player2.name = bot.name;
                                    }
                                    if (board.cells[column, row].player1.name != "")
                                    {
                                        board.cells[column, row].player1.name = player.name;
                                    }
                                    else
                                    {
                                        board.cells[column, row].player2.name = player.name;
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                }
                if (bot.points >= 100)
                {
                    break;
                }
                canBreakLoop = false;
                if (bot.points / 10 % 2 != 0 && bot.points % 10 == 0)
                {
                    column = bot.points / 10 - 1;
                    row = bot.points % 10 + 9;
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
                                        board.cells[i, j].player2.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
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
                                        board.cells[i, j].player1.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (bot.points >= 100)
                    {
                        break;
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
                                        board.cells[i, j].player2.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
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
                                        board.cells[i, j].player1.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (bot.points >= 100)
                    {
                        break;
                    }
                    canBreakLoop = false;
                    if (board.cells[column, row].isGolden == true)
                    {
                        for (int i = 9; i >= 0; i--)
                        {
                            for (int j = 9; j >= 0; j--)
                            {
                                if (board.cells[i, j].player1.name != "" || board.cells[i, j].player2.name != "" && board.cells[i, j].number > bot.points)
                                {
                                    bot.points = board.cells[i, j].number;
                                    player.points = board.cells[column, row].number;
                                    if (board.cells[i, j].player1.name != "")
                                    {
                                        board.cells[i, j].player1.name = bot.name;
                                    }
                                    else
                                    {
                                        board.cells[i, j].player2.name = bot.name;
                                    }
                                    if (board.cells[column, row].player1.name != "")
                                    {
                                        board.cells[column, row].player1.name = player.name;
                                    }
                                    else
                                    {
                                        board.cells[column, row].player2.name = player.name;
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                }
                if (bot.points >= 100)
                {
                    break;
                }
                canBreakLoop = false;
                if (bot.points / 10 % 2 == 0 && bot.points % 10 != 0)
                {
                    column = bot.points / 10;
                    row = bot.points % 10 - 1;
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
                                        board.cells[i, j].player2.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
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
                                        board.cells[i, j].player1.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (bot.points >= 100)
                    {
                        break;
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
                                        board.cells[i, j].player2.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
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
                                        board.cells[i, j].player1.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (bot.points >= 100)
                    {
                        break;
                    }
                    canBreakLoop = false;
                    if (board.cells[column, row].isGolden == true)
                    {
                        for (int i = 9; i >= 0; i--)
                        {
                            for (int j = 9; j >= 0; j--)
                            {
                                if (board.cells[i, j].player1.name != "" || board.cells[i, j].player2.name != "" && board.cells[i, j].number > bot.points)
                                {
                                    bot.points = board.cells[i, j].number;
                                    player.points = board.cells[column, row].number;
                                    if (board.cells[i, j].player1.name != "")
                                    {
                                        board.cells[i, j].player1.name = bot.name;
                                    }
                                    else
                                    {
                                        board.cells[i, j].player2.name = bot.name;
                                    }
                                    if (board.cells[column, row].player1.name != "")
                                    {
                                        board.cells[column, row].player1.name = player.name;
                                    }
                                    else
                                    {
                                        board.cells[column, row].player2.name = player.name;
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                }
                if (bot.points >= 100)
                {
                    break;
                }
                canBreakLoop = false;
                if (bot.points / 10 % 2 != 0 && bot.points % 10 != 0)
                {
                    column = bot.points / 10;
                    row = 10 - (bot.points % 10);
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
                                        board.cells[i, j].player2.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
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
                                        board.cells[i, j].player1.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if(canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (bot.points >= 100)
                    {
                        break;
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
                                        board.cells[i, j].player2.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
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
                                        board.cells[i, j].player1.name = bot.name;
                                        bot.points = board.cells[i, j].number;
                                        if (board.cells[column, row].player1.name == bot.name)
                                        {
                                            board.cells[column, row].player1.name = "";
                                        }
                                        else
                                        {
                                            board.cells[column, row].player2.name = "";
                                        }
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                    if (bot.points >= 100)
                    {
                        break;
                    }
                    canBreakLoop = false;
                    if (board.cells[column, row].isGolden == true)
                    {
                        for (int i = 9; i >= 0; i--)
                        {
                            for (int j = 9; j >= 0; j--)
                            {
                                if (board.cells[i, j].player1.name != "" || board.cells[i, j].player2.name != "" && board.cells[i, j].number > bot.points)
                                {
                                    bot.points = board.cells[i, j].number;
                                    player.points = board.cells[column, row].number;
                                    if (board.cells[i, j].player1.name != "")
                                    {
                                        board.cells[i, j].player1.name = bot.name;
                                    }
                                    else
                                    {
                                        board.cells[i, j].player2.name = bot.name;
                                    }
                                    if (board.cells[column, row].player1.name != "")
                                    {
                                        board.cells[column, row].player1.name = player.name;
                                    }
                                    else
                                    {
                                        board.cells[column, row].player2.name = player.name;
                                    }
                                    Console.WriteLine(bot.name + "-" + bot.points);
                                    canBreakLoop = true;
                                    break;
                                }
                            }
                            if (canBreakLoop = true)
                            {
                                break;
                            }
                        }
                    }
                }
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
