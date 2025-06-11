using System;
using System.Threading;

namespace PracticaHilos
{
    internal class practica01c
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Empezando"); // Mensaje inicial desde el hilo principal

            // Se crea un nuevo hilo y se le asigna la tarea de ejecutar el método ImprimirNumerosConRetardo
            Thread hiloTrabajador = new Thread(ImprimirNumerosConRetardo);

            // Se inicia el hilo secundario
            hiloTrabajador.Start();

            // El hilo principal espera a que el hilo secundario termine antes de continuar
            //hiloTrabajador.Join();

            // Una vez finalizado el hilo secundario, se imprime este mensaje
            Console.WriteLine("Ejecución de hilo principal finalizada");

            Console.ReadLine(); // Espera entrada del usuario para evitar que se cierre la consola automáticamente
        }

        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando"); // Mensaje desde el hilo secundario
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2)); // Pausa de 2 segundos entre cada número
                Console.WriteLine(i); // Imprime número
            }
            Console.WriteLine("Hilo trabajador por concluir"); // Mensaje al final del hilo secundario
        }
    }
}
