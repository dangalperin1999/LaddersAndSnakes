using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaddersAndSnakes
{
    public class Board
    {
        public Cell[,] cells = new Cell[10,10];
        int laddersSum;
        int snakesSum;
        public Board(int laddersSum, int snakesSum)
        {
            this.laddersSum = laddersSum;
            this.snakesSum = snakesSum;
        }
        public void createBoard()
        {
            Random rnd = new Random();
            int ladderStart, ladderEnd;
            int snakeStart, snakeEnd;
            int column, row;
            int[] tempIndex = new int[4];
            int golden;
            bool isFree;
            for (int i = 0; i < 10; i += 2)
            {
                for (int j = 0; j < 10; j++)
                {
                    cells[i, j] = new Cell();
                }
            }
            for (int i = 1; i < 10; i += 2)
            {
                for (int j = 9; j >= 0; j--)
                {
                    cells[i, j] = new Cell();
                }
            }
            for (int i = 0; i < 10; i += 2)
            {
                for (int j = 0; j < 10; j++)
                {
                    cells[i, j].number = i * 10 + j + 1;
                }
            }
            for (int i = 1; i < 10; i += 2)
            {
                for (int j = 9; j >= 0; j--)
                {
                    cells[i, j].number = i * 10 + 9 - j + 1;
                }
            }

            for (int i = 0; i < laddersSum; i++)
            {
                do
                {
                    ladderStart = rnd.Next(1, 90);
                    isFree = true;
                    if (ladderStart / 10 % 2 == 0 && ladderStart % 10 == 0)
                    {
                        column = ladderStart / 10 - 1;
                        row = ladderStart % 10;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].ladder.start = ladderStart;
                            tempIndex[0] = column;
                            tempIndex[1] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (ladderStart / 10 % 2 != 0 && ladderStart % 10 == 0)
                    {
                        column = ladderStart / 10 - 1;
                        row = ladderStart % 10 + 9;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].ladder.start = ladderStart;
                            tempIndex[0] = column;
                            tempIndex[1] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (ladderStart / 10 % 2 == 0 && ladderStart % 10 != 0)
                    {
                        column = ladderStart / 10;
                        row = ladderStart % 10 - 1;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].ladder.start = ladderStart;
                            tempIndex[0] = column;
                            tempIndex[1] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (ladderStart / 10 % 2 != 0 && ladderStart % 10 != 0)
                    {
                        column = ladderStart / 10;
                        row = 10 - (ladderStart % 10);
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].ladder.start = ladderStart;
                            tempIndex[0] = column;
                            tempIndex[1] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                } while (isFree == false);

                do
                {
                    ladderEnd = rnd.Next(ladderStart + (11 - (ladderStart % 10)), 100);
                    isFree = true;
                    if (ladderEnd / 10 % 2 == 0 && ladderEnd % 10 == 0)
                    {
                        column = ladderEnd / 10 - 1;
                        row = ladderEnd % 10;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].ladder.end = ladderEnd;
                            tempIndex[2] = column;
                            tempIndex[3] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (ladderEnd / 10 % 2 != 0 && ladderEnd % 10 == 0)
                    {
                        column = ladderEnd / 10 - 1;
                        row = ladderEnd % 10 + 9;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].ladder.end = ladderEnd;
                            tempIndex[2] = column;
                            tempIndex[3] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (ladderEnd / 10 % 2 == 0 && ladderEnd % 10 != 0)
                    {
                        column = ladderEnd / 10;
                        row = ladderEnd % 10 - 1;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].ladder.end = ladderEnd;
                            tempIndex[2] = column;
                            tempIndex[3] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (ladderEnd / 10 % 2 != 0 && ladderEnd % 10 != 0)
                    {
                        column = ladderEnd / 10;
                        row = 10 - (ladderEnd % 10);
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].ladder.end = ladderEnd;
                            tempIndex[2] = column;
                            tempIndex[3] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                } while (isFree == false);
                cells[tempIndex[0], tempIndex[1]].ladder.end = ladderEnd;
                cells[tempIndex[2], tempIndex[3]].ladder.start = ladderStart;
            }
            for (int i = 0; i < snakesSum; i++)
            {
                do
                {
                    snakeStart = rnd.Next(11, 100);
                    isFree = true;
                    if (snakeStart / 10 % 2 == 0 && snakeStart % 10 == 0)
                    {
                        column = snakeStart / 10 - 1;
                        row = snakeStart % 10;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].snake.start = snakeStart;
                            tempIndex[0] = column;
                            tempIndex[1] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (snakeStart / 10 % 2 != 0 && snakeStart % 10 == 0)
                    {
                        column = snakeStart / 10 - 1;
                        row = snakeStart % 10 + 9;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].snake.start = snakeStart;
                            tempIndex[0] = column;
                            tempIndex[1] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (snakeStart / 10 % 2 == 0 && snakeStart % 10 != 0)
                    {
                        column = snakeStart / 10;
                        row = snakeStart % 10 - 1;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].snake.start = snakeStart;
                            tempIndex[0] = column;
                            tempIndex[1] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (snakeStart / 10 % 2 != 0 && snakeStart % 10 != 0)
                    {
                        column = snakeStart / 10;
                        row = 10 - (snakeStart % 10);
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].snake.start = snakeStart;
                            tempIndex[0] = column;
                            tempIndex[1] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                } while (isFree == false);

                do
                {
                    snakeEnd = rnd.Next(1, snakeStart - (snakeStart % 10));
                    isFree = true;
                    if (snakeEnd / 10 % 2 == 0 && snakeEnd % 10 == 0)
                    {
                        column = snakeEnd / 10 - 1;
                        row = snakeEnd % 10;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].snake.end = snakeEnd;
                            tempIndex[2] = column;
                            tempIndex[3] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (snakeEnd / 10 % 2 != 0 && snakeEnd % 10 == 0)
                    {
                        column = snakeEnd / 10 - 1;
                        row = snakeEnd % 10 + 9;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].snake.end = snakeEnd;
                            tempIndex[2] = column;
                            tempIndex[3] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (snakeEnd / 10 % 2 == 0 && snakeEnd % 10 != 0)
                    {
                        column = snakeEnd / 10;
                        row = snakeEnd % 10 - 1;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].snake.end = snakeEnd;
                            tempIndex[2] = column;
                            tempIndex[3] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (snakeEnd / 10 % 2 != 0 && snakeEnd % 10 != 0)
                    {
                        column = snakeEnd / 10;
                        row = 10 - (snakeEnd % 10);
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].snake.end = snakeEnd;
                            tempIndex[2] = column;
                            tempIndex[3] = row;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                } while (isFree == false);
                cells[tempIndex[0], tempIndex[1]].snake.end = snakeEnd;
                cells[tempIndex[2], tempIndex[3]].snake.start = snakeStart;
            }
            for (int i = 0; i < 2; i++)
            {
                do
                {
                    golden = rnd.Next(1, 100);
                    isFree = true;
                    if (golden / 10 % 2 == 0 && golden % 10 == 0)
                    {
                        column = golden / 10 - 1;
                        row = golden % 10;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].isGolden = true;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (golden / 10 % 2 != 0 && golden % 10 == 0)
                    {
                        column = golden / 10 - 1;
                        row = golden % 10 + 9;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].isGolden = true;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (golden / 10 % 2 == 0 && golden % 10 != 0)
                    {
                        column = golden / 10;
                        row = golden % 10 - 1;
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].isGolden = true;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                    if (golden / 10 % 2 != 0 && golden % 10 != 0)
                    {
                        column = golden / 10;
                        row = 10 - (golden % 10);
                        if (cells[column, row].ladder.start == 0 && cells[column, row].ladder.end == 0 && cells[column, row].snake.start == 0 && cells[column, row].snake.end == 0 && cells[column, row].isGolden == false)
                        {
                            cells[column, row].isGolden = true;
                        }
                        else
                        {
                            isFree = false;
                        }
                    }
                } while (isFree == false);
            }
        }
    }
}
