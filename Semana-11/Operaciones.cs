﻿using System;

namespace Semana_11
{
    internal class Operaciones
    {
        public static int getEntero(string prefijo, string reemplazo)
        {

            int respuesta = 0;
            bool correcto = false;

            do
            {
                string numeroTexto = getTextoPantalla(prefijo);
                correcto = int.TryParse(numeroTexto, out respuesta);
                if (!correcto)
                {
                    Console.Clear();
                    Console.WriteLine(reemplazo);
                    Console.WriteLine("Ingresa un número válido");
                }

            } while (!correcto);

            return respuesta;

        }

        public static float getDecimal(string prefijo)
        {
            float respuesta = 0;
            bool correcto = false;

            do
            {
                string numeroTexto = getTextoPantalla(prefijo);
                correcto = float.TryParse(numeroTexto, out respuesta);
                if (!correcto)
                {
                    Console.WriteLine("Ingresa un número válido");
                }

            } while (!correcto);

            return respuesta;
        }

        public static string getTextoPantalla(string prefijo)
        {
            Console.Write(prefijo);
            return Console.ReadLine();
        }


        public static int getOpcion()
        {
            string opcionTexto = Console.ReadLine();
            return int.Parse(opcionTexto);
        }


    }
}