using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejer1Tema3
{
    class ListaEquipos
    {
       
        public Hashtable equipos;
        private Equipo eq = new Equipo();
        string ip ="";
        string ram = "";
        string nombreArchivo = "..\\..\\fich.txt";

        public ListaEquipos()
        {
            equipos = new Hashtable();
            LecturaFichero();
        }

        public void IntroducirIP()
        {
            Console.WriteLine("\n ++++ Agregar equipo ++++");
            Console.Write("IP: ");
            ip = Console.ReadLine();
            if (eq.comprobarIp(ref ip))
            {
                if (equipos.ContainsKey(ip))
                {
                    Console.WriteLine("Error. La IP ya existe en la lista");
                }
                else
                {
                    Console.Write("GB RAM: ");
                    ram = Console.ReadLine();
                    if (eq.comprobarRam(ref ram))
                    {
                        equipos.Add(ip, Convert.ToInt32(ram));
                        Console.WriteLine("La IP se ha añadido\n");
                    }
                }
            }
        }

        public void IntroducirIP(string ip, int ram)
        {
            equipos.Add(ip, ram);
        }

        public void EliminarIP()
        {
            if (equipos.Count > 0)
            {                
                Console.WriteLine("\n---- Eliminar equipo ----");
                Console.WriteLine("IP: ");
                ip = Console.ReadLine();
                if (eq.comprobarIp(ref ip))
                {
                    if (equipos.ContainsKey(ip))
                    {
                        Console.WriteLine("Eliminada IP {0} de {1} GB RAM\n", ip, equipos[ip]);
                        equipos.Remove(ip);                                                    
                    }
                    else
                    {
                        Console.WriteLine("La IP no se corresponde con ningún equipo de la lista\n");
                    }                          
                }
            }
            else
            {
                Console.WriteLine("No existen equipos para eliminar");
            }
        }

        public void MostrarColeccion()
        {
            if(equipos.Count > 0)
            {
                Console.WriteLine("\n **** Lista equipos ****");
                foreach (DictionaryEntry de in equipos)
                {
                    Console.WriteLine("IP {0, 15} --- {1, -2}GB RAM", de.Key, de.Value);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No existen equipos para mostrar");
            }
            
        }

        public void MostrarIP()
        {
            if(equipos.Count > 0)
            {
                Console.WriteLine("\n ~ ~ Mostrar equipo ~ ~");
                Console.WriteLine("IP: ");
                ip = Console.ReadLine();
                if (eq.comprobarIp(ref ip))
                {
                    if (equipos.ContainsKey(ip))
                    {
                        Console.WriteLine("IP {0} --- {1}GB RAM\n", ip, equipos[ip]);
                    }
                    else
                    {
                        Console.WriteLine("La IP no se corresponde con ningún equipo de la lista\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("No exiten equipos para mostrar");
            }
        }

        public void LecturaFichero()
        {
            StreamReader sr;
            if (File.Exists(nombreArchivo))
            {
                try
                {
                    using (sr = new StreamReader(nombreArchivo))
                    {                    
                        while ((ip = sr.ReadLine()) != null)
                        {
                            if(eq.comprobarIp(ref ip, true))
                            {
                                if (equipos.ContainsKey(ip))
                                {
                                    Console.WriteLine("Error. La IP " + ip + " ya existe en la lista");
                                    sr.ReadLine();                                    
                                }
                                else
                                {
                                    ram = sr.ReadLine();
                                    if (eq.comprobarRam(ref ram, true))
                                    {
                                        equipos.Add(ip, ram);
                                    }
                                }                                                                                                                                                                
                            }
                            else
                            {
                                sr.ReadLine();
                            }
                        }                  
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ya existe un equipo con la IP " + ip);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error al leer archivo: " + e.Message);
                }
            }
        }

        public void EscribirFichero()
        {
            StreamWriter sw;
            try
            {
                using (sw = new StreamWriter(nombreArchivo))
                {
                    foreach (DictionaryEntry de in equipos)
                    {
                        sw.WriteLine(de.Key);
                        sw.WriteLine(de.Value);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error al escribir archivo: " + e.Message);
            }
        }
    }
}
