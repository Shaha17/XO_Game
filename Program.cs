using System;

namespace XO_game
{
    class Program
    {
        static int[,] xoMap = {{0,0,0},{0,0,0},{0,0,0}};
            //0 - nothing
            //1 - X
            //2 - O
        static int moves = 0;
        static bool flag = true; 
            //true - X move
            //false - O move
        public static void RestartGame()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    xoMap[i,j] = 0;
            flag = true;
            moves = 0;
        }
        public static int GameWinner()
        {
            int win = 0;
            for(int i = 0; i < 3; i++)
            {
                if(xoMap[0,i]==xoMap[1,i] && xoMap[1,i]==xoMap[2,i] && xoMap[1,i] != 0)
                    return xoMap[1,i];
                if(xoMap[i,0]==xoMap[i,1] && xoMap[i,1]==xoMap[i,2] && xoMap[i,1] != 0)
                    return xoMap[i,1];
            }
            if(xoMap[0,0]==xoMap[1,1] && xoMap[1,1]==xoMap[2,2] && xoMap[1,1] != 0)
                return xoMap[1,1];
            if(xoMap[0,2]==xoMap[1,1] && xoMap[1,1]==xoMap[2,0] && xoMap[1,1] != 0)
                return xoMap[1,1];
            return win;
            //0 - game continue
            //1 - X win
            //2 - O win
        }
        public static void ShowMap()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    if(xoMap[i,j] == 0)
                        Console.Write("_ ");
                    else if(xoMap[i,j] == 1)
                        Console.Write("X ");
                    else if(xoMap[i,j] == 2)
                        Console.Write("O ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main()
        {
            int x, y;
            do//Цикл для бесконечного повтора игры
            {
                do//Цикл для принятия ходов
                {    
                    do//Цикл для проверки ходов
                    {
                        Console.Clear();
                        ShowMap();
                        if(flag)
                            Console.WriteLine("Ход крестиков: ");
                        else Console.WriteLine("Ход ноликов: ");
                        int.TryParse(Console.ReadLine(), out x);
                        int.TryParse(Console.ReadLine(), out y);
                        x -= 1;
                        y -= 1;
                    }
                    while(0 > x || x > 2 || 0 > y || y > 2 || xoMap[x,y] != 0);
                    xoMap[x,y] = flag ? 1 : 2;
                    ShowMap();
                    moves++;
                    flag = !flag;
                }
                while(GameWinner()==0 && moves < 9);
                if(GameWinner() == 0)
                    Console.WriteLine("Ничья");
                else if(GameWinner() == 1)
                    Console.WriteLine("Победили крестики");
                else if(GameWinner() == 2)
                    Console.WriteLine("Победили нолики");
                Console.WriteLine("Нажмите любую кнопку, чтобы начать заново...");
                Console.ReadKey();
                RestartGame();
            }
            while(true);
        }
    }
}
