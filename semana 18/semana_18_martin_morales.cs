using System.ComponentModel;

namespace PracticaClases
{
    class Program
    {
        static string [] nombres = new string[10];
        static int [ , ] notasAlumnos = new int[10, 10];
        public static void Main(string[] args)
        {
            IngresarDatos();Console.Clear();
            while(true)
            {
                Menu();
                while(true)
                {
                    Console.WriteLine("¿Desea continuar? (Si/No):");
                    string continuar = Console.ReadLine()!;
                    if (continuar.ToLower() == "si" || continuar.ToLower() == "no")
                    {
                        if (continuar.ToLower() == "no")
                        {
                            Console.WriteLine("Saliendo del programa...");
                            return;
                        }
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opcion no valida, ingrese nuevamente (Si/No):");
                        continuar = Console.ReadLine()!;
                    }
                }
            }
        }
        public static void Menu()
        {
            Console.WriteLine("MENU URL\n\n1.Nombre y notas aprobadas para cada alumno.\n2.Mostrar nombre y notas no aprobadas para cada alumno.\n3.Mostrar el promedio de notas del grupo.\n4.Salir del programa.\n");
                string opcion = Console.ReadLine()!;
                int numero = 0;
                while (true)
                {
                    if (int.TryParse(opcion, out numero) && numero >= 1 && numero <= 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opcion no valida, ingrese nuevamente la opcion entre 1 - 4:\n");
                        opcion = Console.ReadLine()!;
                    }
                }
                switch(opcion)
                {
                    case "1":
                        MostrarNotasAprobadas();
                        break;
                    case "2":
                        MostrarNotasNoAprobadas();
                        break;
                    case "3":
                        MostrarPromedioGrupo();
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del programa...");
                        return;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
        }
        public static void IngresarDatos()
        {
            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine("Ingrese el nombre del alumno No. " + (i + 1) + ":");
                nombres[i] = Console.ReadLine()!;
            }
            int numero = 0, contador = 1;
            string nota = "";
            for (int filas = 0; filas < 10; filas++)
            {
                for (int columnas = 0; columnas < 10; columnas ++)
                {   
                    Console.Clear();
                    Console.WriteLine("Ingrese la nota (entre 0 - 100 ) No. " + (contador) + " del alumno " + (nombres[filas]) + ":");
                    nota = Console.ReadLine()!;
                    while(true)
                    {
                        if (int.TryParse(nota, out numero) && numero <= 100 && numero >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nota no valida, ingrese nuevamente la nota (entre 0 - 100 ) No. " + (columnas + 1) + " del alumno " + (nombres[filas]) + ":");
                            nota = Console.ReadLine()!;
                        }
                    }
                    notasAlumnos[filas, columnas] = numero;
                    contador++;
                }
                contador = 1;
            }
        }
        public static void MostrarNotasAprobadas()
        {
            for (int filas = 0; filas < 10; filas++)
            {
                for (int columnas = 0; columnas < 10; columnas++)
                {
                    if (notasAlumnos[filas, columnas] > 64)
                    {
                        Console.WriteLine("\nEl alumno: " + nombres[filas] + " ha aprobado la clase No. " + (columnas+1) + " con una nota de: " + notasAlumnos[filas, columnas]);
                    }
                }
            }
        }
        public static void MostrarNotasNoAprobadas()
        {
            for (int filas = 0; filas < 10; filas++)
            {
                for (int columnas = 0; columnas < 10; columnas++)
                {
                    if (notasAlumnos[filas, columnas] < 65)
                    {
                        Console.WriteLine("\nEl alumno: " + nombres[filas] + " no ha aprobado la clase No. " + (columnas+1) + " con una nota de: " + notasAlumnos[filas, columnas]);
                    }
                }
            }
        }
        public static void MostrarPromedioGrupo()
        {
            int promedio = 0;
            for (int filas = 0; filas < 10; filas++)
            {
                for (int columnas = 0; columnas < 10; columnas++)
                {
                    promedio += notasAlumnos[filas, columnas];
                }
            }
            promedio = promedio / 100;
            Console.WriteLine("El promedio del grupo es: " + promedio);
        }
    }
}