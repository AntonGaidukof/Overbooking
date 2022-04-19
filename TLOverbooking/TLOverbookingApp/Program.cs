using System;
using TLOverbookingApp.Schedule;

namespace TLOverbookingApp
{
    public class Program
    {
        static void Main( string[] args )
        {
            TaskInitializer.Start();

            Console.WriteLine( "Для завершения работы нажмите любую кнопку" );
            Console.ReadLine();
        }
    }
}
