using System;
using System.Threading.Tasks;

namespace tetris
{
    class Program
    {
        static void Main(string[] args)
        {

            int skip = 0;    

            WorkSpace.InintWindowsSize();
            WorkSpace.DrawWall();

            Game.score = 0;
            Game.DrawIndicators(); 
    
            Shape MyShape;

            MyShape = new Shape((char)164,12,0);
            MyShape.CreateShape();

            Shape NextShape;
            NextShape = new Shape((char)164,12,0);
            NextShape.CreateShape();
            
            Game.currentShape = MyShape;
            Game.InitPointMap();
            MyShape.AddShapePointMap(Shape.actionType.AddPointMap);
            NextShape.DrawNextShape();

            Task delayTimer = Task.CompletedTask;

            ConsoleKeyInfo ConsoleKeyInf = new ConsoleKeyInfo();

            while (true)
                 {
                        if (Console.KeyAvailable)
                        {

                        ConsoleKeyInf = Console.ReadKey();


                        };

                        if (!delayTimer.IsCompleted) continue; // если таймер не сработал, продолжаем цикл


                        //алгоритм отрисовки: стираем, меняем координаты, рисуем по новой.

                        switch(ConsoleKeyInf.Key)

                        { 
                        case ConsoleKey.LeftArrow:
                        {
                            MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                            MyShape.MooveShapeleft();   
                            delayTimer  = delayGame(10);
                            break;
                        }
                        case ConsoleKey.RightArrow: 
                        {
                            MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                            MyShape.MooveShapeRight();   
                            delayTimer  = delayGame(10);
                            break;
                        }

                        case ConsoleKey.Spacebar:

                            {
                            MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                            MyShape.CreateShape();
                            delayTimer  = delayGame(10);
         
                            break;
                            }

                        case ConsoleKey.DownArrow:

                            {
                            MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                            MyShape.MooveShapeDown();
                            delayTimer  = delayGame(10);
                            break;
                            }


                        default:
                            {
                                MyShape.AddShapePointMap(Shape.actionType.RemovePointMap); 
                                MyShape.MooveShapeDown();
                                delayTimer  = delayGame(500);
                                break;
                            }    
 
                        } 
    
                         MyShape.AddShapePointMap(Shape.actionType.AddPointMap); 
                        Game.ShowPointMap(); 
    
                       
                        if (MyShape.allowMovement.top == false) 
                        {
                            skip++;
                            delayTimer  = delayGame(200);
                        
                            if (skip == 3)
                                {
                                skip = 0;        
                                MyShape = NextShape;
                                //MyShape.CreateShape();
                                Game.currentShape = MyShape;
                                MyShape.AddShapePointMap(Shape.actionType.AddPointMap);
                                delayTimer  = delayGame(500);

                                NextShape = new Shape((char)164,12,0);
                                NextShape.CreateShape();
                                NextShape.DrawNextShape();

                                }
                          
                        }
                       
                        ConsoleKeyInf = new ConsoleKeyInfo();       
  
                 }  

           // Console.ReadKey();

 
        }

        static async Task delayGame(int spd_value)
        {
             await Task.Delay(spd_value);

        }         

        

    }
}
