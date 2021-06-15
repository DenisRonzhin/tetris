  using System;

  public class Point
    {
        public int visibility {get;set;}
        char symbolVisibility = (char)164;
        char symbolInVisibility = '.';
         

        public Point(int visibility)
        {
            this.visibility  = visibility;
        }

        public void DrawPoint()
        {

            if (visibility == 1) 

            { 
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(symbolVisibility);
         
            } 

            else

            {
                Console.ForegroundColor = ConsoleColor.DarkGray;   
                Console.Write(symbolInVisibility);
            }
     
            Console.CursorVisible = false;
        }

    } 
   


