using System;
using System.Collections.Generic;

static public class Game
{

    static public int score {get;set;}
    static public int speed {get;set;}
    static public Point[,] pointMap = new Point[WorkSpace.hightGame,WorkSpace.wightGame];
    static Point[,] tempPointMap;  // Временный массив для сдвига заполненных строк
    static List<int> fullRow = new List<int>{}; //Список хранит индексы заполненных строк массива 
    //static public Shape currentShape {get; set;}
    
    //Заполняем стакан нулевыми элементами
    static public void InitPointMap()
    {
        for (int col = 0; col < WorkSpace.wightGame; col++)
        {
            for (int row = 0; row < WorkSpace.hightGame; row++)
            {
               pointMap[row,col] = new Point(0,0,' ');  
            }
            
        }

    }

    public static void CheckRow()
    {
        int fullRowCount = 0;
        int currentRow = 0;
        bool fullRow = false; 

        tempPointMap = new Point[WorkSpace.hightGame,WorkSpace.wightGame];

        for (int col = 0; col < WorkSpace.wightGame; col++)
        {
            for (int row = 0; row < WorkSpace.hightGame; row++)
            {
               tempPointMap[row,col] = new Point(0,0,' ');  
            }
            
        }

        for (int row = 0; row < WorkSpace.hightGame; row++)
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
                currentRow++;
          
                for (int col = 0; col < WorkSpace.wightGame ; col++)
                {
                
                    tempPointMap[currentRow-1,col] = pointMap[row,col];

                }
            } else fullRow = true;

        }

        //Перезаполним исходный массив, если есть заполненные строки

        if (fullRow) pointMap  = (Point[,])tempPointMap.Clone();

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
                Console.SetCursorPosition(25,0); // глючит курсор, стирает часть стены. Загоним его в область где нет символов.
            }
        }

    }


    static public void AddScore()
    {
        score++;
     
    }

    static public void AddSpeed()
    {
        speed++;

    }

    static public void DrawIndicators()
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



