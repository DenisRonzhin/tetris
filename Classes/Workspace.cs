using System;

static public class WorkSpace
{
    
    public static int wightForm = 35; //ширина формы
    public static int hightGame = 20; //высота игрового поля
    public static int wightGame = 20; //ширина игрового поля


    static public void InintWindowsSize()
    {
       Console.ForegroundColor = ConsoleColor.Green; 
       Console.Clear(); 
      
       Console.SetWindowSize(100, hightGame); // исправить 100 на wightForm
    

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

        for (int i =1; i<=hightGame; i++)
        {
            Console.SetCursorPosition(1,i);
            Console.Write('|'); 

            Console.SetCursorPosition(2,i);
            Console.Write($"{i}"); 


            Console.SetCursorPosition(wightGame+1,i);
            Console.Write('|'); 

            Console.SetCursorPosition(wightForm,i);
            Console.Write('|'); 
        }    



    }

}