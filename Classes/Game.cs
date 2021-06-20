using System;
using System.Threading;


static public class Game
{
    static public int score {get;set;}
    static public int speed {get;set;}
    static public Point[,] pointMap = new Point[WorkSpace.hightGame,WorkSpace.wightGame];
    static Point[,] tempPointMap;  // Временный массив для сдвига заполненных строк
    
    //Заполняем стакан нулевыми элементами
    static public void InitPointMap()
    {
        for (int col = 0; col < WorkSpace.wightGame; col++)
        {
            for (int row = 0; row < WorkSpace.hightGame; row++)
            {
               pointMap[row,col] = new Point(0);  
            }
        }

    }


    public static void ShowGameOver()
    {

       for (int row = WorkSpace.hightGame - 1; row >= 0; row--)
       {
            for (int col = 0; col < WorkSpace.wightGame; col++)
            {
                pointMap[row,col].visibility = 1;
                Console.SetCursorPosition(col+2,row);
                pointMap[row,col].DrawPoint();
            }    

            Thread.Sleep(30);

        }

       for (int row = 0; row < WorkSpace.hightGame; row++)
       {
            for (int col = 0; col < WorkSpace.wightGame; col++)
            {
                pointMap[row,col].visibility = 0;
                Console.SetCursorPosition(col+2,row);
                pointMap[row,col].DrawPoint();
            }    

            Thread.Sleep(30);

        }

        Console.SetCursorPosition(7,10);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("GAME OVER");
        

    }

    public static bool CheckGameOver()
    {
        int fillRow = 0;
        for (int row = 0; row < WorkSpace.hightGame; row++)
        {
            for (int col = 0; col < WorkSpace.wightGame; col++)
            {
                if (pointMap[row,col].visibility==1)
                {
                    fillRow++;
                    break;
                }
            }    

        }       

        if (fillRow == WorkSpace.hightGame)
        {
           
           //ShowGameOver();

           return true;
           
        }
        else return false;
    }

    public static void CheckRow()
    {
        int fullRowCount = 0;
        int currentRow = WorkSpace.hightGame;
        bool fullRow = false; 

        tempPointMap = new Point[WorkSpace.hightGame,WorkSpace.wightGame];

        for (int col = 0; col < WorkSpace.wightGame; col++)
        {
            for (int row = WorkSpace.hightGame-1; row >= 0; row--)
            {
               tempPointMap[row,col] = new Point(0);  
            }
            
        }

        for (int row = WorkSpace.hightGame - 1; row >= 0; row--)
        {
        
            fullRowCount = 0;

            for (int col = 0; col < WorkSpace.wightGame ; col++)
            {
              
               if (pointMap[row,col].visibility == 1) 
               fullRowCount++;
         
            }

            //заполним тестовый массив без заполненных строк
            if (fullRowCount != WorkSpace.wightGame)
            {
                currentRow--;
          
                for (int col = 0; col < WorkSpace.wightGame ; col++)
                {
                
                    tempPointMap[currentRow,col] = pointMap[row,col];

                }
            } else 
            
            {
                AddScore();
                fullRow = true;
            }   

        }

        //Перезаполним исходный массив, если есть заполненные строки

        if (fullRow)
        {
            pointMap  = (Point[,])tempPointMap.Clone();
            ShowIndicators();
        }
        
    }

  

    //Полная отрисовка игрового поля с фигурами 

    static public void ShowPointMap()
    {
        for (int col = 0; col < WorkSpace.wightGame; col++)
        {
            for (int row = 0; row < WorkSpace.hightGame; row++)
            {
                Console.SetCursorPosition(col+2,row);
                pointMap[row,col].DrawPoint();
            }
        }

          

        Console.SetCursorPosition(25,0); // глючит курсор, стирает часть стены. Загоним его в область где нет символов.
        
    }


    static public void AddScore()
    {
        score++;
     
    }

    static public void AddSpeed()
    {
        speed++;

    }

    static public void ShowIndicators()
    {

        Console.ForegroundColor = ConsoleColor.Yellow;   

        Console.SetCursorPosition(24,1);
        Console.Write("**TETRIS**");

        Console.SetCursorPosition(24,4);
        Console.Write($"SCORE:{score}");

        Console.SetCursorPosition(24,6);
        Console.Write($"SPEED:{speed}");

        Console.SetCursorPosition(24,10);
        Console.Write("NEXT SHAPE");

    }



}



