using System;

namespace XO_game
{
    class Program
    {
        static int[,] board = {{0,0,0},{0,0,0},{0,0,0}};
            //0 - nothing
            //1 - X
            //2 - O
        static int moves = 0;
        static bool flag = true; 
            //true - X move
            //false - O move
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
                        Console.Write("X ");
                    else if(board[i,j] == 2)
                        Console.Write("O ");
                    else if(board[i,j] == 9)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("X ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    else if(board[i,j] == 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("O ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void InputMove()
        {
            if(flag)
                Console.WriteLine("Ход крестиков: ");
            else Console.WriteLine("Ход ноликов: ");
            if(!(int.TryParse(Console.ReadLine(), out tempInput)))
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
        static void Main()
        {
            do//Цикл для бесконечного повтора игры
            {
                do//Цикл для принятия ходов
                {    
                    do//Цикл для проверки ходов
                    {
                        Console.Clear();
                        ShowBoard();
                        InputMove();
                    }
                    while(tempInput < 1 || 9 < tempInput);
                    x = (tempInput - 1) / 3;
                    y = (tempInput - 1) % 3;
                    boardHistory[tempInput - 1] = true;
                    board[x,y] = flag ? 1 : 2;
                    ShowBoard();
                    moves++;
                    flag = !flag;
                }
                while(GameWinner()==0 && moves < 9);
                if(GameWinner() == 0)
                    Console.WriteLine("Ничья");
                else if(GameWinner() == 9)
                    Console.WriteLine("Победили крестики");
                else if(GameWinner() == 10)
                    Console.WriteLine("Победили нолики");
                Console.Clear();
                ShowBoard();
                Console.WriteLine("Нажмите любую кнопку, чтобы начать заново...");
                Console.ReadKey();
                RestartGame();
            }
            while(true);
        }
    }
}
