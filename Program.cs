using System;

namespace tetris
{
    public class Point
    {
        int x {get;set;}
        int y {get;set;}
        int visibility {get;set;}
        int color {get;set;}
        char symbol {get;set;}

        public Point(int visibility, int color, char symbol)
        {

            this.visibility  = visibility;
            this.color = color;
            this.symbol = symbol;
        }

        public void DrawPoint()
        {
            Console.Write(symbol);
        }

        public void ClearPoint()
        {
            Console.Write(' ');
        }

    }

    
    public class Shape 
    {
        public char vsb {get;set;}

        public enum typeShape 
            {
                O = 1,
                I = 2,
                S = 3,
                Z = 4,
                L = 5,
                J = 6,
                T = 7
            }       

        public typeShape tShape {get;set;} 
     
        public Shape(char visibleSymbol, typeShape tShape)
        {
            vsb = visibleSymbol;
            this.tShape = tShape;

        }

        Point[,]  shapeMap;
  
        public void CreateShape()
        {
            switch(tShape)
            {
                //     
                // ##
                // ##
                //  
                case typeShape.O: 
                        { 
                            shapeMap = new Point[4,4]
                                        {
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(1,0,vsb), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(1,0,vsb), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' ')},
                                        };

                            break;
                        }
                //  #   
                //  #
                //  #
                //  #
   
                case typeShape.I: 
                        { 
                            shapeMap = new Point[,]
                                        {
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        };

                            break;
                        }

                //     
                //  ##
                // ##
                //  
                case typeShape.S: 
                        { 
                            shapeMap = new Point[,]
                                        {
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(1,0,vsb), new Point(1,0,vsb)},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(1,0,vsb), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' ')},
                                        };

                            break;
                        }
                //     
                //## 
                // ##
                //  

                case typeShape.Z: 
                        { 
                            shapeMap = new Point[,]
                                        {
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(1,0,vsb), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(1,0,vsb), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' ')},
                                        };

                            break;
                        }
                //     
                // # 
                // #
                // ## 

                case typeShape.L: 
                        { 
                            shapeMap = new Point[,]
                                        {
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(1,0,vsb), new Point(0,0,' ')},
                                        };

                            break;
                        }
                //     
                // # 
                // #
                //## 
                case typeShape.J: 
                        { 
                            shapeMap = new Point[,]
                                        {
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(1,0,vsb), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        };

                            break;
                        }
                //     
                //###  
                // # 
                //  
               case typeShape.T: 
                        { 
                            shapeMap = new Point[,]
                                        {
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(1,0,vsb), new Point(1,0,vsb), new Point(1,0,vsb), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(1,0,vsb), new Point(0,0,' '), new Point(0,0,' ')},
                                        {new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' '), new Point(0,0,' ')},
                                        };

                            break;
                        }
                
            }

        }

        public void DrawShape()
        {

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x< 4; x++)

                {
                    Console.SetCursorPosition(x,y);
                    shapeMap[y,x].DrawPoint();
                }

            }    

        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            int x = Console.LargestWindowWidth;
            int y = Console.LargestWindowHeight;  
            Console.SetWindowSize(x, y); 
    
    
            Shape MyShape;

              foreach (Shape.typeShape s in Enum.GetValues(typeof(Shape.typeShape)))

            {

                MyShape = new Shape('#',s);
                MyShape.CreateShape();
                MyShape.DrawShape();
                
                Console.ReadKey();
              
            }


            // MyShape = new Shape('#',Shape.typeShape.J);
            // MyShape.CreateShape();
            // MyShape.DrawShape();

            // MyShape = new Shape('#',Shape.typeShape.S);
            // MyShape.CreateShape();
            // MyShape.DrawShape();
 

            

        }
    }
}
