using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_11
{
    internal class Pantallas
    {
        public static float[] notas = new float[7];
        public static int contador = 0;

        public static int PantallaPrincipal()
        {
            string texto = "" +
                "================================\n" +
                "Casos con arreglos\n" +
                "================================\n" +
                "1: Registrar notas\n" +
                "2: Hallar la nota mayor\n" +
                "3: Hallar la nota menor\n" +
                "4: Encontrar una nota\n" +
                "5: Modificar una nota\n" +
                "6: Ver notas registradas\n" +
                "7: Salir\n" +
                "================================\n";
             Console.Write(texto);
            return Operaciones.getEntero("Ingrese una opción:",texto);


        }

        public static int RegistrarUnaNota()
        {
            int opcion = 0;

            do
            {
                Console.Clear();
                string texto = "================================\n" +
                               "Registrar una nota\n" +
                               "================================\n";
                Console.WriteLine(texto);

                if (contador == 7)
                {
                    Console.WriteLine("LAS NOTAS YA ESTÁN LLENAS");
                }
                else
                {
                    float calificacion = Operaciones.getDecimal("Ingresa la nota Nro " + (contador + 1) + ": ");
                    if (contador < 7)
                    {
                        notas[contador] = calificacion;
                        contador++;
                    }
                }

                string texto2 = "================================\n" +
                                "1: Registrar otra nota\n" +
                                "2: Regresar\n";
                Console.WriteLine(texto2);

                opcion = Operaciones.getEntero("Ingrese una opción:", texto);

            } while (opcion == 1 && contador < 7);

            return opcion;
        }

        public static int HallarNotaMayor()
        {
            Console.Clear();

            string texto = "================================\n" +
                "La nota mayor\n" +
                "================================";
            Console.WriteLine(texto);

            if (contador == 0)
            {
                Console.WriteLine("NO HAY NOTAS TODAVÍA");
            }
            else
            {
                float mayor = notas[0];
                int indexMayor = 0;

                for (int i = 1; i < contador; i++)
                {
                    if (notas[i] > mayor)
                    {
                        mayor = notas[i];
                        indexMayor = i;
                    }
                }

                // vals
                Console.Write("La nota mayor es :"+ mayor+"\n");
                for (int i = 0; i < contador; i++)
                {
                    if (i == indexMayor)
                    {
                        Console.Write("[" + mayor + "] ");
                    }
                    else
                    {
                        Console.Write(notas[i] + " ");
                    }
                }
            }

            string texto2 = "\n================================\n" +
                "1: Regresar\n";
            Console.WriteLine(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción:", texto);
            if (opcion == 1)
            {
                return 0;
            }
            return opcion;
        }

        public static int HallarNotaMenor()
        {
            Console.Clear();

            string texto = "================================\n" +
                "La nota menor\n" +
                "================================";
            Console.WriteLine(texto);

            if (contador == 0)
            {
                Console.WriteLine("NO HAY NOTAS TODAVÍA");
            }
            else
            {
                float menor = notas[0];
                int indexMenor = 0;

                for (int i = 1; i < contador; i++)
                {
                    if (notas[i] < menor)
                    {
                        menor = notas[i];
                        indexMenor = i;
                    }
                }
                Console.Write("La nota mayor es :" + menor + "\n");
                for (int i = 0; i < contador; i++)
                {
                    if (i == indexMenor)
                    {
                        Console.Write("[" + menor + "] ");
                    }
                    else
                    {
                        Console.Write(notas[i] + " ");
                    }
                }
            }

            string texto2 = "\n================================\n" +
                "1: Regresar\n";
            Console.WriteLine(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción:", texto);
            if (opcion == 1)
            {
                return 0;
            }
            return opcion;
        }

        public static int Encontrar()
        {
            Console.Clear();
            string texto = "================================\n" +
                           "Buscar nota\n" +
                           "================================\n";
            if (contador == 0)
            {
                Console.WriteLine("NO HAY NOTAS PARA ENCONTRAR");
            }
            else { 

            string valornota = Operaciones.getTextoPantalla("Ingrese la nota a buscar: ");
            int posicionEncontrada = -1;

            for (int i = 0; i < contador; i++)
            {

                if (valornota == notas[i].ToString())
                {
                    posicionEncontrada = i;
                    break;
                }
            }

            if (posicionEncontrada != -1)
            {
                Console.WriteLine($"La nota está en la posición {posicionEncontrada}\n");

                // Mostrar el contenido del arreglo con el número encontrado entre corchetes
                for (int i = 0; i < contador; i++)
                {
                    if (i == posicionEncontrada)
                    {
                        Console.WriteLine($"{i} -> [{valornota}]");
                    }
                    else
                    {
                        Console.WriteLine($"{i} -> {notas[i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("La nota no se encontró en el arreglo.\n");
            }
        }
            string texto2 = "================================\n" +
                            "1: Regresar";
            Console.WriteLine(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1)
            {
                return 0;
            }
            return opcion;
        }

        public static int Modificar()
        {
            Console.Clear();
            string texto = "================================\n" +
                            "Modificar nota\n" +
                            "================================";
            Console.WriteLine(texto);

            if (contador == 0)
            {
                Console.WriteLine("NO HAY NOTAS PARA MODIFICAR");
            }
            else
            {
                Console.Write("Ingrese la posición: ");
                if (int.TryParse(Console.ReadLine(), out int posicion))
                {
                    if (posicion >= 1 && posicion <= contador)
                    {
                        Console.Write("Ingrese el nuevo valor: ");
                        if (float.TryParse(Console.ReadLine(), out float nuevoValor))
                        {
                            float notaAntes = notas[posicion - 1]; // Almacena el valor original
                            notas[posicion - 1] = nuevoValor; // Actualiza el valor en la posición indicada

                            Console.WriteLine("================================");
                            Console.Write("Antes: ");
                            for (int i = 0; i < contador; i++)
                            {
                                if (i == posicion - 1)
                                {
                                    Console.Write($"[{notaAntes}] ");
                                }
                                else
                                {
                                    Console.Write($"{notas[i]} ");
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Después: ");
                            for (int i = 0; i < contador; i++)
                            {
                                if (i == posicion - 1)
                                {
                                    Console.Write($"[{nuevoValor}] ");
                                }
                                else
                                {
                                    Console.Write($"{notas[i]} ");
                                }
                            }
                          
                        }
                    }
                    else
                    {
                        Console.WriteLine("Posición no válida. Por favor, ingrese una posición válida.");
                    }
                }
            }
            string texto2 = "\n================================\n" +
                    "1: Regresar";
            Console.Write(texto2 + "\n");

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1)
            {
                return 0;
            }
            return opcion;
        }

        public static int VerNotas()
        {
            Console.Clear();
            string texto = "" +
                "================================\n\r" +
                "Notas Registradas\n\r" +
                "================================\n\r"+
                "Notas actuales:\n";

            Console.Write(texto);
            if (contador == 0)
            {
                Console.Write("NO HAY NOTAS");
            }

            for(int i = 0; i < contador; i++)
            {
                Console.Write( + notas[i]+ "-" );
            }  

            Console.WriteLine("");

               string texto2 = "================================\n\r" +
                "1: Regresar\n\r";

            Console.Write(texto2);
            int opcion = Operaciones.getEntero("Ingrese una opción:", texto);
            if (opcion == 1) return 0;
            return opcion;

        }



       

    }
}
