using System;
using System.Threading;

namespace PracticaHilos
{
    internal class practica01d
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Empezando el programa");

            // Se crea un hilo secundario que imprimirá números con retardo
            Thread hiloTrabajador = new Thread(ImprimirNumerosConRetardo);
            hiloTrabajador.Start(); // Inicia la ejecución del hilo

            // El hilo principal duerme por 6 segundos
            Thread.Sleep(TimeSpan.FromSeconds(6));

            // Intenta abortar el hilo secundario después de 6 segundos
            hiloTrabajador.Abort();
            Console.WriteLine("El hilo trabajador ha abortado!");

            // Se crea e inicia otro hilo que imprime números sin retardo
            Thread hiloTrabajador2 = new Thread(ImprimirNumeros);
            hiloTrabajador2.Start();

            // El hilo principal también imprime números
            ImprimirNumeros1();

            Console.ReadLine(); // Espera para que no se cierre la consola automáticamente
        }

        // Método que imprime números del 1 al 9 con una pausa de 2 segundos entre cada uno
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
            Console.WriteLine("Hilo trabajador por concluir");
        }

        // Método usado por el segundo hilo, imprime números sin pausas
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando hilo secundario");
            for (int i = 1; i < 10; i++)
                Console.WriteLine(i);
        }

        // Método agregagado por el grupo para saber cuando se usa en el hilo principal, también imprime números sin pausas
        static void ImprimirNumeros1()
        {
            Console.WriteLine("Empezando Hilo principal");
            for (int i = 1; i < 10; i++)
                Console.WriteLine(i);
        }
    }
}
