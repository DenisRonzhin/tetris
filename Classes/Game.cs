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
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
               pointMap[x,y] = new Point(0,0,' ');  
            }
            
        }

    }

    static public void FillPointMap()
    {
        for (int x = 0; x < Math.Min(4,21 - currentShape.positionX); x++)
        {
            for (int y = 0; y < 4; y++)
            {
               pointMap[currentShape.positionX-2+x,currentShape.positionY+y] = currentShape.shapeMap[x,y];


                //отладка
                Console.SetCursorPosition(80,1);
                Console.Write($"X = {currentShape.positionX+x} Y = {currentShape.positionY+y}");
      

            }
        }


    }

    static public void ClearPointMap()
    {
        for (int x = 0; x < Math.Min(4,(21 - currentShape.positionX)); x++)
        {
            for (int y = 0; y < 4; y++)
            {
               pointMap[currentShape.positionX-2+x,currentShape.positionY+y] = new Point(0,0,' ');

            }
        }


    }

    static public void ShowPointMap()
    {
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                Console.SetCursorPosition(50+x,1+y);
                pointMap[x,y].DrawPoint();
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



