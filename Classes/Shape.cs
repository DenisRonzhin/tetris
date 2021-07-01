using System;

public class Shape 
    {
        public enum actionType {AddPointMap, RemovePointMap}
        
        public struct allowMovementType
        { 
           public bool left;
           public bool right;
           public bool top;
           public int shiftX;
           public int shiftY;
           public int angle;
        
           public allowMovementType(bool left_, bool right_, bool top_, int shiftX, int shiftY, int angle)
           {
               this.left = left_;
               this.right = right_;
               this.top = top_;
               //Смещение для нулефой точки. Используется для поворота
               this.shiftX = shiftX; 
               this.shiftY = shiftY;
               this.angle = angle;
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

            allowMovement = new allowMovementType(true,true,true,0,0,0);   

        }
    
        public Point[,]  shapeMap;

        public int positionX {set;get;} 
        public int positionY {set;get;} 
           
        int previousPositionX;
        int previousPositionY;
         
        
        public void CreateShape()
        {

    
            tShape = (typeShape)ChooseShape();    

            tShape = typeShape.I;


            switch(tShape)
            {
                //     
                // ##
                // ##
                //  
                case typeShape.O: 
                        { 

                            allowMovement.shiftX = 1;
                            allowMovement.shiftY = 2;
                            allowMovement.angle = 0;
                            

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
            
                            allowMovement.shiftX = 1;
                            allowMovement.shiftY = 2;
                            allowMovement.angle = 0;
                   
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
                            allowMovement.shiftX = 2;
                            allowMovement.shiftY = 2;
                            allowMovement.angle = 0;
                   
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
                            allowMovement.shiftX = 1;
                            allowMovement.shiftY = 2;
                            allowMovement.angle = 0;
                   
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
                            
                            allowMovement.shiftX = 1;
                            allowMovement.shiftY = 2;
                            allowMovement.angle = 0;
                   
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

                            allowMovement.shiftX = 1;
                            allowMovement.shiftY = 2;
                            allowMovement.angle = 0;
                            
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
                    
                            allowMovement.shiftX = 1;
                            allowMovement.shiftY = 2;
                            allowMovement.angle = 0;
                    
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
            FindExtrem(shapeMap);

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

        //Метод поворота

         public void RotateShape()
         {
          
            if (tShape != typeShape.O)
          
            {
          
                Point[,] tempPoint; //вспомогательный массив. В нем собираем новую фигуру после поворота

                int x = 0;
                int y = 0;
            
                //Пустой массив   
                tempPoint = new Point[,]
                                        {
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        {new Point(0), new Point(0), new Point(0), new Point(0)},
                                        };

                //Записываем пороворот фигуры в новом массиве            
                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    
                    {
                        if (shapeMap[row,col].visibility == 1) 
                        {
                            //Для линии свои правила поворачиваем ее на 90 и обратно
                            if (tShape == typeShape.I && allowMovement.angle == 90)
                            {
                                    //развернем в обратную сторону
                                    x =  (row - allowMovement.shiftY)+allowMovement.shiftX;
                                    y =  -(col - allowMovement.shiftX)+allowMovement.shiftY; 
                                    tempPoint[y,x] = shapeMap[row,col];    
                            } 
                            else   
                            {    
                                x =  -(row - allowMovement.shiftY)+allowMovement.shiftX;
                                y =  (col - allowMovement.shiftX)+allowMovement.shiftY; 
                                tempPoint[y,x] = shapeMap[row,col];    
                            }    

                        }
                    }

          
                }

                FindExtrem(tempPoint);

                if (TryAddShape(tempPoint)) 

                { 
                
                    if (tShape == typeShape.I) 

                    {
                        if (allowMovement.angle == 90) allowMovement.angle = 0; else allowMovement.angle = allowMovement.angle+90;
                    }
                    
                    else
                   
                    {
                        if (allowMovement.angle == 360 ) allowMovement.angle = 0; else allowMovement.angle = allowMovement.angle+90;
                    }  
                    
                    shapeMap  = (Point[,])tempPoint.Clone();
                
                }
    
                FindExtrem(shapeMap);
            }    
        }


         public bool TryAddShape(Point[,] shapeArray)
         {
           
             bool result = true;

            //Обходим в цикле фигуру и переносим ее в массив рабочей области
            for (int col = currentExtremPoints.leftPointPosition; col < currentExtremPoints.rightPointPosition+1; col++)
            {
            for (int row = 0; row <= Math.Min(positionY,currentExtremPoints.topPointPosition); row++)
            
                {
                    if (positionY-row < 0) { result = false;} else//ушли за границы массива 
                    if (positionX-2+col >= WorkSpace.wightGame || positionX-2+col < 0 ) { result = false;} else//ушли за границы массивы
                    if (Game.pointMap[positionY-row,positionX-2+col].visibility ==1) { result = false;} //наткнулись на фигуру 
                   
                    //if (shapeArray[currentExtremPoints.topPointPosition-row,col].visibility == 1) Game.pointMap[positionY-row,positionX-2+col] = shapeMap[currentExtremPoints.topPointPosition-row,col];
                   
                }

            }

            return result;

        }


        //Метод для поиска границ фигуры
        void FindExtrem(Point[,] shapeArray)
        {
            int minX = 4;
            int maxX = 0;
            int maxY = 0;    


            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    if (shapeArray[row,col].visibility == 1 && col < minX) {minX = col;}
                    if (shapeArray[row,col].visibility == 1 && col > maxX) {maxX = col;}
                    if (shapeArray[row,col].visibility == 1 && row > maxY) {maxY = row;}
    
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
            
            if (positionX-1+currentExtremPoints.rightPointPosition < WorkSpace.wightGame) allowMovement.right = true; else
             allowMovement.right = false; 
            
            if (positionY < WorkSpace.hightGame) allowMovement.top = true;
            
            else 
            
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
            
            int numberShape = randomShape.Next(1,8); //фигуры с 1 по 7

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