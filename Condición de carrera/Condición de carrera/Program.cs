using System;
using System.Threading;

class Program
{
    static int contador = 0;
    static readonly object cerrojo = new object();

    static void Main()
    {
        Thread t1 = new Thread(Incrementar);
        Thread t2 = new Thread(Incrementar);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine($"Resultado con Lock: {contador} (Esperado: 200000)");
    }

    static void Incrementar()
    {
        for (int i = 0; i < 100_000; i++)
        {
            lock (cerrojo) 
            {
                contador++;
            }
        }
    }
}