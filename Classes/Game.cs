using System;

static public class Game
{

    static public int score {get;set;}
    static public int speed {get;set;}
    static public Point[,] pointMap = new Point[20,20];
    static public Shape currentShape {get; set;}
    
    //Заполняем стакан нулевыми элементами
    static public void InitPointMap()
    {
        for (int col = 0; col < 20; col++)
        {
            for (int row = 0; row < 20; row++)
            {
               pointMap[row,col] = new Point(0,0,' ');  
            }
            
        }

    }

    static public void FillPointMap()
    {
        for (int col = 0; col < Math.Min(4,21 - currentShape.positionX); col++)
        {
            for (int row = 0; row < 4; row++)
            {
                 pointMap[currentShape.positionY+row,currentShape.positionX-2+col] = currentShape.shapeMap[row,col];


                //отладка
                Console.SetCursorPosition(80,1);
                Console.Write($"X = {currentShape.positionX+col} Y = {currentShape.positionY+row}");
      

            }
        }


    }

    static public void ClearPointMap()
    {
        for (int col = 0; col < Math.Min(4,(21 - currentShape.positionX)); col++)
        {
            for (int row = 0; row < 4; row++)
            {
               pointMap[currentShape.positionY+row,currentShape.positionX-2+col] = new Point(0,0,' ');

            }
        }


    }

    static public void ShowPointMap()
    {
        for (int col = 0; col < 20; col++)
        {
            for (int row = 0; row < 20; row++)
            {
                Console.SetCursorPosition(50+col,row);
                pointMap[row,col].DrawPoint();
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



