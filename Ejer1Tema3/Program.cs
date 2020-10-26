using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer1Tema3
{
    class Program
    {

        static void Main(string[] args)
        {

            ListaEquipos c = new ListaEquipos();

            int opcion = 0;
            bool valido = false;
            do
            {                
                Console.WriteLine("1. Nuevo equipo");
                Console.WriteLine("2. Eliminar equipo");
                Console.WriteLine("3. Mostrar lista de equipos");
                Console.WriteLine("4. Mostrar un equipo");
                Console.WriteLine("5. Salir");
                while (!valido)
                {
                    try
                    {
                        valido = true;
                        opcion = Convert.ToInt32(Console.ReadLine());                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nIntroduce un número");
                        valido = false;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Dato incorrecto");
                        valido = false;
                    }
                }
                valido = false;          

                switch (opcion)
                {
                    case 1:
                        c.IntroducirIP();
                        break;
                    case 2:
                        c.EliminarIP();
                        break;
                    case 3:
                        c.MostrarColeccion();
                        break;
                    case 4:
                        c.MostrarIP();
                        break;
                    case 5:
                        Console.WriteLine("Abur");
                        c.EscribirFichero();
                        break;
                    default:
                        Console.WriteLine("Opción no válida\n");
                        break;
                }
            } while (opcion != 5);            
        }
    }
}
