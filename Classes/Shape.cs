using System;

public class Shape 
    {
        public char vsb {get;set;}
        
        public enum drawingOption
        {
          clear,
          draw      
        }

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


        //Структура хранит крайние индексы фигуры в массиве 4x4 
        public struct extremPoints
        {
            public int leftPointPosition;
            public int rightPointPosition;
            public int topPointPosition; 

            public extremPoints(int leftPointPosition, int rightPointPosition, int topPointPosition)
            {
                this.leftPointPosition = leftPointPosition;
                this.rightPointPosition = rightPointPosition;
                this.topPointPosition = topPointPosition;
            }
        
        }

          
        
        public Shape(char visibleSymbol, int x, int y )
        {
            vsb = visibleSymbol;

            positionX = x;
            positionY = y;

        }
    
        public Point[,]  shapeMap;

        public int positionX {set;get;} 
        public int positionY {set;get;} 
           

        public void CreateShape()
        {
            tShape = (typeShape)ChooseShape();    

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

        //Метод для поиска границ фигуры
        public extremPoints FindExtrem()
        {
            int minX = 4;
            int maxX = 0;
            int maxY = 0;    


            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    if (shapeMap[row,col].visibility == 1 && col < minX) {minX = col;}
                    if (shapeMap[row,col].visibility == 1 && col > maxX) {maxX = col;}
                    if (shapeMap[row,col].visibility == 1 && row > maxY) {maxY = row;}
    
                }    

            }

            return new extremPoints(minX,maxX,maxY); 

        }

        //positionX, positionY - текущая позиция массива с фигурой
        //параметр drOption - вариант отрисовки фигуры. clear - стереть, draw - отобразить на экране

        public void DrawShape(drawingOption drOption)
        {
            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row< 4; row++)
                {
                    Console.SetCursorPosition(positionX+col,positionY+row);
                   
                    if (shapeMap[row,col].visibility == 1) { if (drOption == drawingOption.clear) shapeMap[row,col].ClearPoint(); else shapeMap[row,col].DrawPoint();}
                
                    Console.SetCursorPosition(positionX,positionY);                                   
                }

            }    

            Console.CursorVisible = false;

        }

        public int ChooseShape()
        {

            Random randomShape = new Random();
           
            int numberShape = randomShape.Next(1,7);   

            return numberShape;

        }


        public void MooveShapeDown()
        {
            positionY++;
        }

        public void MooveShapeleft()
        {
            positionX--;
        }

        public void MooveShapeRight()
        {
            positionX++;
        }



    }