  using System;

  public class Point
    {
        public int visibility {get;set;}
        public int color {get;set;}
        public char symbol {get;set;}

        public Point(int visibility, int color, char symbol)
        {

            this.visibility  = visibility;
            this.color = color;
            this.symbol = symbol;
        }

        public void DrawPoint()
        {

            if (visibility == 1) Console.ForegroundColor = ConsoleColor.White; else Console.ForegroundColor = ConsoleColor.DarkGray;   
   
            Console.Write(symbol);
        
            Console.CursorVisible = false;
        }

        public void ClearPoint()
        {
            Console.ForegroundColor = ConsoleColor.Gray; 
            Console.Write('.');
            Console.CursorVisible = false;
        }



    } 
   


