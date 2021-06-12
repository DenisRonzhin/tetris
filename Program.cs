using System;
using System.Threading.Tasks;

namespace tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkSpace.InintWindowsSize();
            WorkSpace.DrawWall();

            Game.score = 0;
            Game.speed = 1;
            Game.DrawIndicators(); 
    
            Shape MyShape;

            MyShape = new Shape('#',12,1);
            MyShape.CreateShape();

            Game.currentShape = MyShape;
            Game.InitPointMap();
            MyShape.AddShapePointMap(Shape.actionType.AddPointMap);

            Task delayTimer = Task.CompletedTask;

            ConsoleKeyInfo ConsoleKeyInf = new ConsoleKeyInfo();

            while (true)
                 {
                        if (Console.KeyAvailable)
                        {

                        ConsoleKeyInf = Console.ReadKey();


                        };

                        if (!delayTimer.IsCompleted) continue; // если таймер не сработал, продолжаем цикл



                        delayTimer  = delayGame(250);  


                        //алгоритм отрисовки: стираем, меняем координаты, рисуем по новой.

                        switch(ConsoleKeyInf.Key)

                        { 
                        case ConsoleKey.LeftArrow:
                        {
                            MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                            MyShape.MooveShapeleft();   

                            break;
                        }
                        case ConsoleKey.RightArrow: 
                        {
                            MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                            MyShape.MooveShapeRight();   
                            break;
                        }

                        case ConsoleKey.Spacebar:

                            {
                            MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                            MyShape.CreateShape();
                            break;
                            }


                        } 
                        MyShape.AddShapePointMap(Shape.actionType.RemovePointMap); 
                        MyShape.MooveShapeDown();
                        MyShape.AddShapePointMap(Shape.actionType.AddPointMap); 
                        Game.ShowPointMap(); 
                       
                        if (MyShape.allowMovement.top == false)
                        {
                            MyShape = new Shape('#',12,1);
                            MyShape.CreateShape();
                            Game.currentShape = MyShape;
                            MyShape.AddShapePointMap(Shape.actionType.AddPointMap);
                        
                        }
                       
                        ConsoleKeyInf = new ConsoleKeyInfo();       
  
                 }  

            Console.ReadKey();

 
        }

        static async Task delayGame(int spd_value)
        {
             await Task.Delay(spd_value);

        }         

        

    }
}
