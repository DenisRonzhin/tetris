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
            Console.Write(symbol);
        }

        public void ClearPoint()
        {
            Console.Write(' ');
        }

    } 
   


