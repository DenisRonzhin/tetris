using System;

public class Shape 
    {
        public enum actionType {AddPointMap, RemovePointMap}
 
        public struct allowMovementType
        { 
           public bool left;
           public bool right;
           public bool top;
        
           public allowMovementType(bool left_, bool right_, bool top_)
           {
               this.left = left_;
               this.right = right_;
               this.top = top_;
           }
        }     

        public allowMovementType allowMovement; 


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

       
        // конструктор класса, создание фигуры
        public Shape(int x, int y )
        {
 
            positionX = x;
            positionY = y;

            allowMovement = new allowMovementType(true,true,true);   

        }
    
        public Point[,]  shapeMap;

        public int positionX {set;get;} 
        public int positionY {set;get;} 
           
        int previousPositionX;
        int previousPositionY;
         

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
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        {new Point(0), new Point(1), new Point(1), new Point(0)},
                                        {new Point(0), new Point(1), new Point(1), new Point(0)},
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
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
                                        {new Point(0), new Point(1), new Point(0), new Point(0)},
                                        {new Point(0), new Point(1), new Point(0), new Point(0)},
                                        {new Point(0), new Point(1), new Point(0), new Point(0)},
                                        {new Point(0), new Point(1), new Point(0), new Point(0)},
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
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        {new Point(0), new Point(0), new Point(1), new Point(1)},
                                        {new Point(0), new Point(1), new Point(1), new Point(0)},
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
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
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        {new Point(1), new Point(1), new Point(0), new Point(0)},
                                        {new Point(0), new Point(1), new Point(1), new Point(0)},
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
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
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        {new Point(0), new Point(1), new Point(0), new Point(0)},
                                        {new Point(0), new Point(1), new Point(0), new Point(0)},
                                        {new Point(0), new Point(1), new Point(1), new Point(0)},
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
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        {new Point(0), new Point(1), new Point(0), new Point(0)},
                                        {new Point(0), new Point(1), new Point(0), new Point(0)},
                                        {new Point(1), new Point(1), new Point(0), new Point(0)},
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
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        {new Point(1), new Point(1), new Point(1), new Point(0)},
                                        {new Point(0), new Point(1), new Point(0), new Point(0)},
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        };

                            break;
                        }
                
            }
 

            //Заполним крайние точки фигуры
            FindExtrem();

        }

        //Метод отрисовывает следующую фигуру

        public void DrawNextShape()
        {
            for (int row = 0; row < 4; row++)
            {

               Console.SetCursorPosition(27,11+row);     

               for (int col = 0; col < 4; col++)
               {
                   shapeMap[row,col].DrawPoint();
               }     

            }

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


        //Функция проверяет возможность движения лево,право,вниз
        public allowMovementType CheckCollision()
        {

            //Проверяем налетели на стенки или нет и дошли ли до конца   
            if (positionX-2+currentExtremPoints.leftPointPosition > 0) allowMovement.left = true; else allowMovement.left = false;
            
            if (positionX-1+currentExtremPoints.rightPointPosition < WorkSpace.wightGame) allowMovement.right = true; else allowMovement.right = false; 
            
            if (positionY < WorkSpace.hightGame) allowMovement.top = true; else 
            
            {
             allowMovement.top = false;
             positionY = previousPositionY;
            };
                      
            //Проверяем столкновение с другими фигурами
            //Обходим в цикле фигуру и переносим ее в массив рабочей области
            for (int col = currentExtremPoints.leftPointPosition; col < currentExtremPoints.rightPointPosition+1; col++)
            {
                for (int row = 0; row <= Math.Min(positionY,currentExtremPoints.topPointPosition); row++)
                {
                        {
                            // налетели на фигуру в массиве PointMap при движении вниз
                           
                            if ((Game.pointMap[positionY-row,positionX-2+col].visibility == 1) && (shapeMap[currentExtremPoints.topPointPosition-row,col].visibility==1) )
                            
                             { 
                                allowMovement.top = false; 
                                //Если налетели, откатываемся на шаг назад
                                positionY = previousPositionY;
                             }  

                            //проверяем упремся на следующем шаге в фигуру при движении вправо или нет    
                            if ((positionX-2+col+1) <= 19 && (Game.pointMap[positionY-row,positionX-2+col+1].visibility == 1) && (shapeMap[currentExtremPoints.topPointPosition-row,col].visibility==1)) 
                             { 
                                allowMovement.right = false; 
                             }  
                         
                            // проверяем упремся на следующем шаге в фигуру при движении влево или нет    
                            if ((positionX-2+col-1) >= 0 && (Game.pointMap[positionY-row,positionX-2+col-1].visibility == 1) && (shapeMap[currentExtremPoints.topPointPosition-row,col].visibility==1) ) 
                             { 
                                allowMovement.left = false; 
                             }  


                        } 
                  
                }
            }

            return allowMovement;

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
           for (int row = 0; row <= Math.Min(positionY,currentExtremPoints.topPointPosition); row++)
           
            {
                    if (actionType_ == actionType.AddPointMap)
                
                    {
                        if (shapeMap[currentExtremPoints.topPointPosition-row,col].visibility == 1) Game.pointMap[positionY-row,positionX-2+col] = shapeMap[currentExtremPoints.topPointPosition-row,col];

                    } 
                
                    else
                
                    {
                        if (shapeMap[currentExtremPoints.topPointPosition-row,col].visibility == 1) Game.pointMap[positionY-row,positionX-2+col]  = new Point(0);
                    }

            }
        }

        }


        public void MooveShapeDown()
        {
            if (CheckCollision().top) 
            {
                previousPositionY = positionY;       
                positionY++;
                CheckCollision();
            }
        }

        public void MooveShapeleft()
        {
           if (CheckCollision().left) 
           {
               previousPositionX = positionX;
               positionX--;
           } 
        }

        public void MooveShapeRight()
        {
            if (CheckCollision().right)
            {   
                previousPositionX = positionX;
                positionX++;
            } 
        }

    }