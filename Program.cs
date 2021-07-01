using System;
using System.Threading.Tasks;
using System.Threading;

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


        static void ClearBuferKey()
        {
            while (Console.KeyAvailable) Console.ReadKey(true);
        }


        static void Main(string[] args)
        {

             //Фиксируем время нажатия на клавишу    
            long keyPressTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            //Фиксируем текущее время                       
            long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();


            InitGame();

            Task delayTimer = Task.CompletedTask;

            ConsoleKeyInfo ConsoleKeyInf = new ConsoleKeyInfo();

            
            while (true)
                 {
                        if (Console.KeyAvailable ) 
                        {
                            
                            keyPressTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();   

                            ConsoleKeyInf = Console.ReadKey(true);

                            switch(ConsoleKeyInf.Key)

                            { 
                                case ConsoleKey.LeftArrow:
                            
                                {  
                                    MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                                    MyShape.MooveShapeleft();   
                                    MyShape.AddShapePointMap(Shape.actionType.AddPointMap); 
                                    Game.ShowPointMap();
                                    ClearBuferKey(); 
                                    break;
                                }

                                case ConsoleKey.RightArrow: 
                                { 
                                    MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                                    MyShape.MooveShapeRight();   
                                    MyShape.AddShapePointMap(Shape.actionType.AddPointMap);
                                    Game.ShowPointMap();
                                    ClearBuferKey();  
                                    break;
                                }
    
                                case ConsoleKey.Spacebar:
                                {
                                    MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                                    MyShape.RotateShape();
                                    //MyShape.CreateShape();
                                    MyShape.AddShapePointMap(Shape.actionType.AddPointMap); 
                                    Game.ShowPointMap();
                                    ClearBuferKey(); 
                                    break;
                                }

                                case ConsoleKey.DownArrow:
                                {
                                    MyShape.AddShapePointMap(Shape.actionType.RemovePointMap);
                                    MyShape.MooveShapeDown();
                                    MyShape.AddShapePointMap(Shape.actionType.AddPointMap); 
                                    Game.ShowPointMap();
                                    ClearBuferKey();
                                    break;
                                }
                            }
                        }

                            Console.SetCursorPosition(25,15);
                            Console.Write($"x-{MyShape.positionX}, y-{MyShape.positionY} ");                         

                        currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();    

                        if (!delayTimer.IsCompleted) continue; // если таймер не сработал, продолжаем цикл

                        if (currentTime - keyPressTime >  70 || MyShape.allowMovement.left == false || MyShape.allowMovement.right == false) 
                        {
                            MyShape.AddShapePointMap(Shape.actionType.RemovePointMap); 
                            MyShape.MooveShapeDown();
                            MyShape.AddShapePointMap(Shape.actionType.AddPointMap); 
                            Game.ShowPointMap();
                            delayTimer  = delayGame(500);

                            //allowMove = true;
                        } 
                       
                        if (MyShape.allowMovement.top == false && Game.CheckGameOver() == false) 
                        {
                            skip++;
                            delayTimer  = delayGame(200);
                            if (skip == 3) 
                                {

                                   // Thread.Sleep(500); 
                                    Game.CheckRow();
                                    skip = 0;        
                                    MyShape = NextShape;
                                    MyShape.AddShapePointMap(Shape.actionType.AddPointMap);
                                    Game.ShowPointMap();

                                    delayTimer  = delayGame(500);

                                    NextShape = new Shape(12,0);
                                    NextShape.CreateShape();

                                    NextShape.DrawNextShape();

                                   // allowMove = false;
                                    
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

            // Console.ReadKey();
 
        }

        static async Task delayGame(int spd_value)
        {
             await Task.Delay(spd_value);

        }         

    }
}

