using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer1Tema3
{
    public class Equipo
    {
        public string ip;
        public int ram;

        public bool comprobarIp(ref string ip, bool lectura = false)
        {
            bool valido = false;
            while (!valido)
            {
                try
                {
                    valido = true;                    
                    int[] octetos = new int[4];
                    string[] octetosString = ip.Split('.');

                    if (ip.Split('.').Length != 4)
                    {
                        throw new FormatException();
                    }

                    for (int i = 0; i < octetosString.Length; i++)
                    {
                        octetos[i] = Convert.ToInt32(octetosString[i]);

                        if (octetos[i] < 0 || octetos[i] > 255)
                        {
                            throw new ArgumentException();
                        }
                    }
                }
                catch (FormatException)
                {
                    if (!lectura)
                    {
                        Console.WriteLine("La IP es incorrecta. Error en el formato");
                    }
                    valido = false;                                                            
                }
                catch (ArgumentException)
                {
                    if (!lectura)
                    {
                        Console.WriteLine("La IP es incorrecta. Los valores están fuera de rango");
                    }
                    valido = false;                                                            
                }
                catch (OverflowException)
                {
                    if (!lectura)
                    {
                        Console.WriteLine("Dato inválido");
                    }
                    valido = false;                                        
                }

                if (lectura == true && !valido)
                {
                    Console.WriteLine("Error en la lectura de la IP ("+ip+"). No se ha podido recuperar, dato inválido\n");
                    return false;
                }

                if (!valido)
                {
                    Console.Write("IP: ");
                    ip = Console.ReadLine();
                }
            }
            return valido;
        }

        public bool comprobarRam(ref string ram, bool lectura = false)
        {
            int n;
            bool valido = false;
            while (!valido)
            {
                try
                {
                    valido = true;                    
                    n = Convert.ToInt32(ram);
                    if (n <= 0)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (FormatException)
                {
                    if (!lectura)
                    {
                        Console.WriteLine("Los GB RAM tiene que ser un dato numérico");
                    }
                    valido = false;
                }
                catch (ArgumentException)
                {
                    if (!lectura)
                    {
                        Console.WriteLine("Los GB RAM tiene que ser un dato numérico positivo");
                    }
                    valido = false;
                }
                catch (OverflowException)
                {
                    if (!lectura)
                    {
                        Console.WriteLine("Dato inválido");
                    }
                    valido = false;
                }
                if (lectura == true && !valido)
                {
                    Console.WriteLine("Error en la lectura de la RAM de la IP. No se ha podido recuperar, dato inválido\n");
                    return false;
                }
                if (!valido)
                {
                    Console.Write("RAM: ");
                    ram = Console.ReadLine();
                }
            }
            return valido;
        }
    }
}
