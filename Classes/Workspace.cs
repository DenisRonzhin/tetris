using System;

static public class WorkSpace
{
    static int x = 35;
    static int y = 20;

    static public void InintWindowsSize()
    {
       Console.ForegroundColor = ConsoleColor.Green; 
       Console.Clear(); 
       Console.SetWindowSize(x, y); 
    
    }

    static public void DrawWall()
    {

        // горизонтальные линии
        //for (int i = 1; i<=x; i++)
        //{

            // Console.SetCursorPosition(i,1);
            // Console.Write(''); 

            //Console.SetCursorPosition(i,y);
            //Console.Write('_'); 

        //}


        // Вертикальные линии

        for (int i =1; i<=y; i++)
        {
            Console.SetCursorPosition(1,i);
            Console.Write('|'); 

            Console.SetCursorPosition(2,i);
            Console.Write($"{i}"); 


            Console.SetCursorPosition(21,i);
            Console.Write('|'); 

            Console.SetCursorPosition(x,i);
            Console.Write('|'); 
        }    



    }

}