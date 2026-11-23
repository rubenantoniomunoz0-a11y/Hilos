csharp
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine($"[Main] Hilo principal ID: {Environment.CurrentManagedThreadId}");

        var t = new Thread(() =>
        {
            Console.WriteLine($"[Hilo] Hilo secundario ID: {Environment.CurrentManagedThreadId}");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"[Hilo] Número: {i}");
                Thread.Sleep(500);
            }
        });

        t.Start();
        Console.WriteLine("[Main] Mensaje propio del hilo principal");
        Console.WriteLine("Fin del programa (sin esperar al hilo)");
    }
}