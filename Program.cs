﻿using System;
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

                           Console.SetCursorPosition(MyShape.positionX,MyShape.positionY); // затычка, курсор убегает, стирает стены 
       
                       };

                     if (!delayTimer.IsCompleted) continue; // если таймер не сработал, продолжаем цикл

                 
                
                      delayTimer  = delayGame(550);  

                   
                      switch(ConsoleKeyInf.Key)
    
                         { 
                             case ConsoleKey.LeftArrow:
                                 {
                                     MyShape.DrawShape(true);             
                                     MyShape.MooveShapeleft();   
                    
                                     break;
                                 }
                             case ConsoleKey.RightArrow: 
                                 {
                                     MyShape.DrawShape(true);             
                                     MyShape.MooveShapeRight();   
                                     break;
                                 }
                      
                        
                         } 
                      MyShape.DrawShape(true);             
                      MyShape.MooveShapeDown();
 
                      MyShape.DrawShape(false);
                      
                      //WorkSpace.DrawWall();

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
