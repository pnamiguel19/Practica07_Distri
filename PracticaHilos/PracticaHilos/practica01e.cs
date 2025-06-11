using System;
using System.Threading;
using System.Timers; 

namespace PracticaHilos
{
    internal class practica01e
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Empezando el programa");

            // Se crean dos hilos, uno con retardo y otro que no hace nada
            Thread primerHilo = new Thread(ImprimirNumerosConRetardo);
            Thread segundoHilo = new Thread(NoHaceNada);

            // Muestra el estado inicial del primer hilo (Unstarted)
            Console.WriteLine(primerHilo.ThreadState.ToString());

            // Se inician ambos hilos
            primerHilo.Start();
            segundoHilo.Start();

            // Durante este bucle se imprime el estado actual del primer hilo 29 veces rápidamente
            for (int i = 1; i < 30; i++)
            {
                Console.WriteLine(primerHilo.ThreadState.ToString());
            }

            // El hilo principal duerme 6 segundos
            Thread.Sleep(TimeSpan.FromSeconds(6));

            // Intenta abortar el primer hilo
            primerHilo.Abort();
            Console.WriteLine("El primer hilo ha abortado!");

            // Muestra los estados finales de ambos hilos
            Console.WriteLine(primerHilo.ThreadState.ToString());
            Console.WriteLine(segundoHilo.ThreadState.ToString());

            // Espera una entrada del usuario antes de cerrar la consola
            Console.ReadLine();
        }

        // Método que imprime números del 1 al 9 con una pausa de 2 segundos
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando");
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());

            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
            Console.WriteLine("Hilo trabajador por concluir");
        }

        // Método que duerme 2 segundos y luego imprime un mensaje
        static void NoHaceNada()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("No hace nada");
        }
    }
}
