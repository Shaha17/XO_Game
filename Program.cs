using System;

namespace XO_game
{
    class Program
    {
        static string Choose;
        static char p1 = 'X', p2 = 'O';
        static int[,] board = {{0,0,0},{0,0,0},{0,0,0}};
            //0 - nothing
            //1 - p1(X)
            //2 - p2(O)
        static int moves = 0;
        static int gameRez = 0;
        static bool flag = true; 
            //true - p1(X) move
            //false - p2(O) move
        static int x, y, tempInput;
        static bool[] boardHistory = new bool[9];
        public static void RestartGame()
        {
            for (int i = 0; i < 9; i++)
                boardHistory[i] = false;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i,j] = 0;
            flag = true;
            moves = 0;
            gameRez = 0;
        }
        public static int GameWinner()
        {
            int win = 0;
            for(int i = 0; i < 3; i++)
            {
                if(board[0,i]==board[1,i] && board[1,i]==board[2,i] && board[1,i] != 0)
                {
                    board[0,i] += 2;
                    board[1,i] += 2;
                    board[2,i] += 2;
                    return board[1,i];
                }
                if(board[i,0]==board[i,1] && board[i,1]==board[i,2] && board[i,1] != 0)
                {
                    board[i,0] += 2;
                    board[i,1] += 2;
                    board[i,2] += 2;
                    return board[i,1];
                }
            }
            if(board[0,0]==board[1,1] && board[1,1]==board[2,2] && board[1,1] != 0)
            {
                board[0,0] += 2;
                board[1,1] += 2;
                board[2,2] += 2;
                return board[1,1];
            }
            if(board[0,2]==board[1,1] && board[1,1]==board[2,0] && board[1,1] != 0)
            {
                board[0,2] += 2;
                board[1,1] += 2;
                board[2,0] += 2;
                return board[1,1];
            }
            return win;
            //0 - game continue
            //1 - X win
            //2 - O win
        }
        public static void ShowBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    if(board[i,j] == 0)
                        Console.Write("_ ");
                    else if(board[i,j] == 1)
                        Console.Write(p1 + " ");
                    else if(board[i,j] == 2)
                        Console.Write(p2 + " ");
                    else if(board[i,j] == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(p1 + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    else if(board[i,j] == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(p2 + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void InputMove()
        {
            if(flag)
                Console.WriteLine("Ход " + p1 + ": ");
            else Console.WriteLine("Ход " + p2 + ": ");
            if(!(int.TryParse(Console.ReadLine(), out tempInput)) || tempInput < 1 || 9 < tempInput)
            {
                Console.WriteLine("Ошибка ввода, введите заново...");
                InputMove();
            }
            for (int i = 0; i < 9; i++)
                if(boardHistory[tempInput - 1] == true)
                {
                    Console.WriteLine("Ошибка, поле занято. Введите заново...");
                    InputMove();
                }
        }
        public static void SideChoose(int playerNum)
        {
            if(playerNum == 1)
            {
                Console.WriteLine("Символ для первого игрока:");
                Choose = Console.ReadLine().ToUpper();
                p1 = Choose[0];
            }
            if(playerNum == 2)
            {
                Console.WriteLine("Символ для второго игрока:");
                Choose = Console.ReadLine().ToUpper();
                p2 = Choose[0];
                if(p1 == p2)
                {
                    Console.WriteLine("Одинаковые символы, выберите заново...");
                    SideChoose(2);
                }
            }
        }

        static void Main()
        {
            while(true)//Цикл для бесконечного повтора игры
            {
                SideChoose(1);
                SideChoose(2);
                do//Цикл для принятия ходов
                {    
                    do//Цикл для проверки ходов
                    {
                    Console.Clear();
                    ShowBoard();
                    InputMove();
                    } while(tempInput < 1 || 9 < tempInput);
                    x = (tempInput - 1) / 3;
                    y = (tempInput - 1) % 3;
                    boardHistory[tempInput - 1] = true;
                    board[x,y] = flag ? 1 : 2;
                    ShowBoard();
                    moves++;
                    flag = !flag;
                    gameRez = GameWinner();
                } while(gameRez==0 && moves < 9);
                if(gameRez == 0)
                    Console.WriteLine("Ничья");
                else if(gameRez == 3)
                    Console.WriteLine("Победили " + p1);
                else if(gameRez == 4)
                    Console.WriteLine("Победили " + p2);
                Console.Clear();
                ShowBoard();
                Console.WriteLine("Нажмите любую кнопку, чтобы начать заново...");
                Console.ReadKey();
                RestartGame();
            }
        }
    }
}
