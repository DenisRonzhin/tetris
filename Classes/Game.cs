using System;

static public class Game
{


    public enum actionType {AddPointMap, RemovePointMap}

    static public int score {get;set;}
    static public int speed {get;set;}
    static public Point[,] pointMap = new Point[WorkSpace.hightGame,WorkSpace.wightGame];

    static public Point[,] previousPointMap = new Point[WorkSpace.hightGame,WorkSpace.wightGame];

    static public Shape currentShape {get; set;}
    
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
    


    //метод вставляет/удаляет фигуру в массив poinMap (рабочая область)
    //

  

    //Полная отрисовка игрового поля с фигурами 

    static public void ShowPointMap()
    {
        for (int col = 0; col < WorkSpace.wightGame; col++)
        {
            for (int row = 0; row < WorkSpace.hightGame; row++)
            {
                Console.SetCursorPosition(2+col,row);
                pointMap[row,col].DrawPoint();
                Console.SetCursorPosition(25,0); // глючит курсор, стирает часть стены. Загоним его в область где нет символов.
            }
        }

    }

    //метод делает копию массива с фигурами. 
    static public void CopyPointMap()
    {

        previousPointMap = (Point[,])pointMap.Clone();

    }

    static public void ReturnPreviousPointMap()
    {
        pointMap = (Point[,])previousPointMap.Clone();

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



