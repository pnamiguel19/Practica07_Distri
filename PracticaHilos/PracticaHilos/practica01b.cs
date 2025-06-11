using System;
using System.Threading;

namespace PracticaHilos
{
    internal class practica01b
    {
        static void Main(string[] args)
        {
            // Se crea un hilo y se le asigna el método ImprimirNumerosConRetardo
            Thread hiloTrabajador = new Thread(ImprimirNumerosConRetardo);

            // Se inicia el hilo, que ejecutará ImprimirNumerosConRetardo
            hiloTrabajador.Start();

            // Mientras tanto, el hilo principal ejecuta ImprimirNumeros
            ImprimirNumeros();
            Console.ReadLine();
        }

        // Método que imprime números del 1 al 9 sin pausas
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando");
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        // Método que imprime números del 1 al 9, pero esperando 2 segundos entre cada número
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2)); // Pausa de 2 segundos
                Console.WriteLine(i);
            }
        }
    }
}
