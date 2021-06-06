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
            

            // foreach (Shape.typeShape s in Enum.GetValues(typeof(Shape.typeShape)))

            // {

                //  MyShape = new Shape('#',s);
                //  MyShape.CreateShape();
                //  MyShape.DrawShape(x,y);
       
            //     y = y+4;
            // }

            // Console.ReadKey();


            MyShape = new Shape('#',12,1);
            MyShape.CreateShape();
            MyShape.DrawShape(false);
            
            Task delayTimer = Task.CompletedTask;

            ConsoleKeyInfo ConsoleKeyInf = new ConsoleKeyInfo();

            while (true)
                 {


                   if (Console.KeyAvailable)
                       {
                    
                           ConsoleKeyInf = Console.ReadKey();
       
                       };

                     if (!delayTimer.IsCompleted) continue; // если таймер не сработал, продолжаем цикл

                 
                
                      delayTimer  = delayGame(550);  

                      MyShape.DrawShape(true);             
                   
                      switch(ConsoleKeyInf.Key)
    
                         { 
                             case ConsoleKey.LeftArrow:
                                 {
                                     MyShape.MooveShapeleft();   
                                     break;
                                 }
                             case ConsoleKey.RightArrow: 
                                 {
                                     MyShape.MooveShapeRight();   
                                     break;
                                 }
                            default:
                                {
                                    MyShape.MooveShapeDown();
                                    break;
                                }
            

                         } 
                      MyShape.DrawShape(false);

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
