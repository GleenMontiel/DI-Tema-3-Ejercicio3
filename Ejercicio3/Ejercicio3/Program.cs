using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public delegate void MyDelegate();
    class Program
    {
        static Videogames videogames = new Videogames();
        static void d(MyDelegate d)
        {
            bool flag = false;
            do
            {
                try
                {
                    d();
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Introduce una opción válida");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("EPA");
                }
            } while (!flag);
        }

        static void Opc1()
        {
            string titulo;
            int anio;
            bool flag = false;
            eStyle style;

            Console.Write("\nIntroduce titulo: ");
            titulo = Console.ReadLine();

            Console.Write("\nIntroduce año: ");
            anio = int.Parse(Console.ReadLine());


            do
            {
                Console.WriteLine();
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("{0,-2} {1,-12}", i + 1, (eStyle)i);
                }
                Console.Write("\n¿Qué estilo? ");
                style = ((eStyle)(int.Parse(Console.ReadLine()) - 1));
                if (style >= eStyle.Arcade && style <= eStyle.Deportivo)
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Introduce un dato válido");
                }
            } while (!flag);
            videogames.AddNewGame(new Videogame(titulo, anio, style));
        }
        static void Opc2()
        {
            videogames.VideogameList();
            int start = 0;
            int end = 0;
            Console.Write("\nDesde: ");
            start = int.Parse(Console.ReadLine());

            Console.Write("\nHasta: ");
            end = int.Parse(Console.ReadLine());

            videogames.Delete(start, end);
        }
        static void Opc4()
        {
            bool flag = false;
            eStyle style;
            do
            {
                Console.WriteLine();
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("{0,-2} {1,-12}", i + 1, (eStyle)i);
                }
                Console.Write("\n¿Qué estilo? ");
                style = ((eStyle)(int.Parse(Console.ReadLine()) - 1));
                if (style >= eStyle.Arcade && style <= eStyle.Deportivo)
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Introduce un dato válido");
                }
            } while (!flag);

            if (videogames.Search(style).Count > 0)
            {
                videogames.VideogameList(videogames.Search(style));
            }
            else
            {
                Console.WriteLine("No hay videojuegos con ese estilo");
            }

        }

        static void Opc5()
        {
            int pos;
            int opc;
            string titulo;
            int anio;
            eStyle estilo;

            bool flag = false;
            videogames.VideogameList();
            do
            {
                Console.Write("\n¿Qué videojuego? ");
                pos = int.Parse(Console.ReadLine());
                if (pos < 1 || pos > videogames.videogames.Count())
                {
                    Console.WriteLine("Introduce un número válido");
                }
            } while (pos < 1 || pos > videogames.videogames.Count());
            do
            {
                Console.WriteLine("1.- Titulo");
                Console.WriteLine("2.- Año");
                Console.WriteLine("3.- Estilo");

                Console.Write("\n¿Qué modificaremos? ");
                opc = int.Parse(Console.ReadLine());
                if (opc < 1 || opc > 3)
                {
                    Console.WriteLine("Introduce un número válido");
                }
            } while (opc < 1 || opc > 3);


            do
            {

                if (opc == 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("{0,-2} {1,-12}", i + 1, (eStyle)i);
                    }
                    Console.Write("\n¿Qué estilo? ");
                    estilo = ((eStyle)(int.Parse(Console.ReadLine()) - 1));
                    if (estilo > eStyle.Deportivo || estilo < eStyle.Arcade)
                    {
                        Console.WriteLine("Introduce una opción válida");
                    }
                    else
                    {
                        videogames.ModifyVideogame(pos, opc, estilo);
                        flag = true;
                    }

                }
                else if (opc == 2)
                {
                    Console.Write("\nIntroduce nuevo año: ");
                    anio = int.Parse(Console.ReadLine());
                    videogames.ModifyVideogame(pos, opc, anio);
                    flag = true;

                }
                else
                {
                    Console.Write("\nIntroduce nuevo titulo: ");
                    titulo = Console.ReadLine();
                    videogames.ModifyVideogame(pos, opc, titulo);
                    flag = true;
                }
            } while (!flag);

        }

        static void Main(string[] args)
        {

            int opc = 0;
            do
            {
                try
                {
                    Console.WriteLine("\n1.- Insertar nuevo videojuego.");
                    Console.WriteLine("2.- Eliminar videojuegos.");
                    Console.WriteLine("3.- Visualizar toda las lista de videojuegos.");
                    Console.WriteLine("4.- Visualización de videojuegos de un estilo determinado.");
                    Console.WriteLine("5.- Modifcación de un videojuego.");
                    Console.WriteLine("6.- Salir del programa.");
                    Console.Write("Introduce opción: ");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            d(Opc1);
                            break;

                        case 2:
                            d(Opc2);
                            break;

                        case 3:
                            videogames.VideogameList();
                            break;

                        case 4:
                            d(Opc4);
                            break;

                        case 5:
                            d(Opc5);
                            break;

                        case 6:
                            Console.WriteLine("Adios");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Introduce una opción válida");
                }

                catch (OverflowException)
                {
                    Console.WriteLine("EPA");
                }
            } while (opc != 6);
        }
    }
}
