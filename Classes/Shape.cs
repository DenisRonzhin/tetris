using System;

public class Shape 
    {
        public char vsb {get;set;}
        public enum actionType {AddPointMap, RemovePointMap}
 
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

        public extremPoints currentExtremPoints {get;set;}

          
        
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
 

            //Заполним крайние точки фигуры
            FindExtrem();

        }




        //Метод для поиска границ фигуры
        void FindExtrem()
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

            currentExtremPoints = new extremPoints(minX,maxX,maxY); 

        }

       

        //Метод выравнивает положение курсора. Курсор уходит вперед и стрирает стены
        public void SetCursor()
        {
            Console.SetCursorPosition(positionX+currentExtremPoints.leftPointPosition,positionY);
        }


        //Функция проверяет достигла ли фигура границ левой стенки
        bool CheckMooveLeft()
        {
            bool mooveAllowed;
            
            if (positionX-2+currentExtremPoints.leftPointPosition > 0)  mooveAllowed = true; 
            
            else  mooveAllowed = false; 

            return mooveAllowed;       
        }

        //Функция проверяет достигла ли фигура границ правой стенки
        bool CheckMooveRight()
        {
            bool mooveAllowed;
            
            if (positionX-1+currentExtremPoints.rightPointPosition < WorkSpace.wightGame)  mooveAllowed = true; 
            
            else  mooveAllowed = false; 

            return mooveAllowed;       
        }




        public int ChooseShape()
        {

            Random randomShape = new Random();
            
            int numberShape = randomShape.Next(1,7); //фигуры с 1 по 7

            return numberShape;

        }

        public void AddShapePointMap(actionType actionType_)
        {
        //Обходим в цикле фигуру и переносим ее в массив рабочей области
        for (int col = currentExtremPoints.leftPointPosition; col < currentExtremPoints.rightPointPosition+1; col++)
        {
            for (int row = 0; row < currentExtremPoints.topPointPosition+1; row++)
            {
                    if (actionType_ == actionType.AddPointMap)
                    {
                    Game.pointMap[positionY+row,positionX-2+col] = shapeMap[row,col];
                    Console.SetCursorPosition(80,1);
                    Console.Write($"X = {positionX} Y = {positionY}");
                    } 
                    else
                    {
                    Game.pointMap[positionY+row,positionX-2+col] = new Point(0,0,' ');
                    }

            }
        }

        //Отладака Проверяем крайние точки фигуры    
        Console.SetCursorPosition(80,2);
        Console.Write($"left = {currentExtremPoints.leftPointPosition} right = {currentExtremPoints.rightPointPosition} top = {currentExtremPoints.topPointPosition}");

        }


        public void MooveShapeDown()
        {
            positionY++;
        }

        public void MooveShapeleft()
        {
           if (CheckMooveLeft()) positionX--;
        }

        public void MooveShapeRight()
        {
            if (CheckMooveRight()) positionX++;
        }



    }