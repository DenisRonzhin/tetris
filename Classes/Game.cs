using System;

static public class Game
{



    static public int score {get;set;}
    static public int speed {get;set;}
    static public Point[,] pointMap = new Point[WorkSpace.hightGame,WorkSpace.wightGame];
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


    //метод двигает фигуру в массиве poinMap (рабочая область)

    static public void FillPointMap()
    {

        //Обходим в цикле фигуру и переносим ее в массив рабочей области
        for (int col = currentShape.currentExtremPoints.leftPointPosition; col < currentShape.currentExtremPoints.rightPointPosition+1; col++)
        {
            for (int row = 0; row < currentShape.currentExtremPoints.topPointPosition+1; row++)
            {
                 pointMap[currentShape.positionY+row,currentShape.positionX-2+col] = currentShape.shapeMap[row,col];


                //отладка Проверяем позиционирование
                Console.SetCursorPosition(80,1);
                Console.Write($"X = {currentShape.positionX} Y = {currentShape.positionY}");


            }
        }

        //Отладака Проверяем крайние точки фигуры    
        Console.SetCursorPosition(80,2);
        Console.Write($"left = {currentShape.currentExtremPoints.leftPointPosition} right = {currentShape.currentExtremPoints.rightPointPosition} top = {currentShape.currentExtremPoints.topPointPosition}");


    }

    static public void ClearPointMap() 
    {
        
        //Получим крайние точки фигуры по вертикали и горизонтали
        //currentShape.FindExtrem();    
        
       for (int col = currentShape.currentExtremPoints.leftPointPosition; col < currentShape.currentExtremPoints.rightPointPosition+1; col++)
        {
            for (int row = 0; row < currentShape.currentExtremPoints.topPointPosition+1; row++)
             {
               pointMap[currentShape.positionY+row,currentShape.positionX-2+col] = new Point(0,0,' ');

            }
        }


    }

    

    //Отрисовка игрового поля
    
    static public void ShowPointMap()
    {
        for (int col = 0; col < WorkSpace.wightGame; col++)
        {
            for (int row = 0; row < WorkSpace.hightGame; row++)
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



