using System;
using System.Threading;

class Program
{
    static int contador = 0;

    static void Main()
    {
        // Creamos dos hilos que ejecutan el mismo método
        Thread t1 = new Thread(Incrementar);
        Thread t2 = new Thread(Incrementar);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine($"Resultado Sin Protección: {contador} (Esperado: 200000)");
    }

    static void Incrementar()
    {
        for (int i = 0; i < 100_000; i++)
        {
            contador++; // Aquí ocurre la condición de carrera
        }
    }
}