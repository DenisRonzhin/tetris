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
            MyShape.DrawShape(Shape.drawingOption.draw);

            Game.InitPointMap();


            Task delayTimer = Task.CompletedTask;

            ConsoleKeyInfo ConsoleKeyInf = new ConsoleKeyInfo();

            while (true)
                 {

                   Game.currentShape = MyShape;

                   if (Console.KeyAvailable)
                       {
                    
                           ConsoleKeyInf = Console.ReadKey();

                           MyShape.SetCursor(); // затычка, курсор убегает, стирает стены 
       
                       };

                     if (!delayTimer.IsCompleted) continue; // если таймер не сработал, продолжаем цикл

                 
                
                      delayTimer  = delayGame(150);  


                    //алгоритм отрисовки: стираем, меняем координаты, рисуем по новой.
                   
                      switch(ConsoleKeyInf.Key)
    
                         { 
                            case ConsoleKey.LeftArrow:
                                {
                                    MyShape.DrawShape(Shape.drawingOption.clear);             
                                    Game.ClearPointMap();
                                    MyShape.MooveShapeleft();   
                
                                    break;
                                }
                            case ConsoleKey.RightArrow: 
                                {
                                    MyShape.DrawShape(Shape.drawingOption.clear);
                                    Game.ClearPointMap();            
                                    MyShape.MooveShapeRight();   
                                    break;
                                }

                            case ConsoleKey.Spacebar:

                                 {
                                     MyShape.DrawShape(Shape.drawingOption.clear);
                                     Game.ClearPointMap();            
                                     MyShape.CreateShape();
                                     break;
                                 }
    
                        
                         } 
                      MyShape.DrawShape(Shape.drawingOption.clear);             
                      Game.ClearPointMap(); // тестовая хуйня для отладки массива поля, стираем фигуру из массива поля
                     // MyShape.MooveShapeDown();
 
                      MyShape.DrawShape(Shape.drawingOption.draw);
                      Game.FillPointMap(); //  тестовая хуйня для отладки массива поля, заполняем массив поля по текущей фигуре
                      Game.ShowPointMap(); //  тестовая хуйня для отладки массива поля, отображаем массив поля

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
