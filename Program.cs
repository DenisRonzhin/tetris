﻿using System;
using System.Threading.Tasks;

namespace tetris
{
    class Program
    {   static Shape MyShape;
        static Shape NextShape;
        static int skip = 0;

        static void InitGame()
        {
            WorkSpace.InintWindowsSize();
            WorkSpace.DrawWall();

            Game.score = 0;
            Game.ShowIndicators(); 
    
            MyShape = new Shape(12,0);
            MyShape.CreateShape();

            NextShape = new Shape(12,0);
            NextShape.CreateShape();
            
            //Game.currentShape = MyShape;
            Game.InitPointMap();
            MyShape.AddShapePointMap(Shape.actionType.AddPointMap);
            NextShape.DrawNextShape();

        }


        static void Main(string[] args)
        {

            InitGame();

            Task delayTimer = Task.CompletedTask;

            ConsoleKeyInfo ConsoleKeyInf = new ConsoleKeyInfo();

            while (true)
                 {
                        if (Console.KeyAvailable)
                        {

                            ConsoleKeyInf = Console.ReadKey(true);

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
                       
                        if (MyShape.allowMovement.top == false && Game.CheckGameOver() == false) 
                        {
                            skip++;
                            delayTimer  = delayGame(200);
                            if (skip == 3) 
                                {
                                    Game.CheckRow();
                                    skip = 0;        
                                    MyShape = NextShape;
                                    MyShape.AddShapePointMap(Shape.actionType.AddPointMap);
                                    delayTimer  = delayGame(500);

                                    NextShape = new Shape(12,0);
                                    NextShape.CreateShape();
                                    NextShape.DrawNextShape();

                                } 
                          
                        } else 
                        
                        if (MyShape.allowMovement.top == false && Game.CheckGameOver())
                        {

                            Game.ShowGameOver();
                            Console.ReadKey();
                            InitGame();  
                            
                     
                             
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
