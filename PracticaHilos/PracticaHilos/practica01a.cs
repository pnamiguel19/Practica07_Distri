using Microsoft.SqlServer.Server;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading;

namespace PracticaHilos
{
    // ************************************************************************
    // Practica 01
    // Miguel Avilez, Mathew Gutierrez
    // Fecha de realización: 23/04/2025
    // Fecha de entrega: 30/04/2025
    // Resultados:
    // * En esta practica se trabajara con hilos por lo que es importante conocer como trabajan estos, con cada ejercicio,
    // se espera comprender cómo crear y controlar múltiples hilos en C#, incluyendo su ejecución en foreground o background,
    // pausas temporales (Sleep), espera controlada (Join), y el manejo seguro de recursos compartidos mediante bloqueos
    // como lock, Monitor e Interlocked. También se aprende a pasar parámetros a hilos y a evitar prácticas inseguras como Abort.
    // Estos mecanismos permiten una programación concurrente más eficiente, sincronizada y segura.
    //
    // Conclusiones:
    // * En síntesis, al crear hilos secundarios, el sistema operativo los gestiona usando un planificador que asigna ranuras
    //   de tiempo “time slices” a cada hilo, permitiendo que el hilo principal y los secundarios se ejecuten de manera intercalada,
    //   aunque no necesariamente equitativa. Cuando se emplean métodos como Thread.Sleep(), se fuerza al hilo a liberar su tiempo
    //   de CPU, permitiendo que otros hilos tomen el control temporalmente, esta segmentación del tiempo evita bloqueos y mejora
    //   la eficiencia en tareas concurrentes.
    // * En resumen, algunos métodos de hilos como el método Join() obliga al hilo principal a esperar hasta que el hilo secundario
    //   termine, alterando el flujo natural de ejecución paralela y haciendo que los hilos se comporten de forma secuencial.
    //   Por otro lado, Abort() interrumpe abruptamente un hilo, lo que puede dejar recursos sin liberar o tareas incompletas,
    //   por lo que no es una práctica recomendada. Además, el monitoreo del estado del hilo con ThreadState permite verificar en
    //   qué etapa se encuentra un hilo (nuevo, en ejecución, dormido, finalizado, etc.), esto para depuración y control de flujo.

    // Recomendaciones:
    // * Se debe, evita usar Thread.Abort() para detener hilos, ya que es inseguro e impredecible. Una opción más segura,
    //   es utilizar mecanismos como CancellationToken para finalizar hilos de manera controlada y segura.
    // * Se recomienda, utilizar Thread.Join() solo cuando sea estrictamente necesario, ya que bloquea el hilo actual y
    //   puede afectar el rendimiento si se usa sin un propósito claro de sincronización.
    //
    // ************************************************************************

    internal class practica01a
    {
        static void Main(string[] args)
        {
            // Crear explícitamente un delegado ThreadStart
            ThreadStart delegado = new ThreadStart(ImprimirNumeros);

            // Pasar el delegado al constructor del hilo
            Thread hiloTrabajador = new Thread(delegado);

            //// Se crea un nuevo hilo y se le asigna el método ImprimirNumeros como tarea.
            //Thread hiloTrabajador = new Thread(ImprimirNumeros);

            // Se inicia el hilo, ejecutando ImprimirNumeros() de forma paralela.
            hiloTrabajador.Start();

            // Se ejecuta el mismo método en el hilo principal.
            ImprimirNumeros();

            // Evita que la consola se cierre automáticamente.
            Console.ReadLine();
        }

        // Método que imprime los números del 1 al 49
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando");

            for (int i = 1; i < 50; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
