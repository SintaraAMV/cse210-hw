using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🏋️ EXERCISE TRACKING PROGRAM");
        Console.WriteLine("============================\n");

        // Crear una lista de actividades (polimorfismo)
        List<Activity> activities = new List<Activity>();

        // Añadir una actividad de Running (4.83 km ≈ 3 millas)
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 4.83));

        // Añadir una actividad de Cycling (velocidad 15 kph durante 45 min)
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 15.0));

        // Añadir una actividad de Swimming (20 largos = 1.0 km)
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 60, 20));

        // Mostrar los resúmenes
        Console.WriteLine("Activity Summaries:");
        Console.WriteLine("-------------------");
        foreach (Activity act in activities)
        {
            Console.WriteLine(act.GetSummary());
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}