using System;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Collections.Generic;
namespace reverse_string
{
    class Program
    {
        //1 ¡Invertir Cadena de 2 formas Distintas!
        static string Reverse(string text)
        {
            char[] charArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                reverse += charArray[i];
            }
            return reverse;
        }
        static string ReverseFor(string text)
        {
            char[] charArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                reverse += charArray[i];
            }
            return reverse;
        }
        static int DistHamming(string strand1, string strand2)
        {
            if (strand1.Length != strand2.Length) throw new ArgumentException("Ingrese dos palabras con la misma longitud");

            int difHamming = strand1.Zip(strand2).Count(pair => pair.First != pair.Second);
            return difHamming;
        }


        //4 ¡Contador de palabras! 
        public static int CountWords(string text)
        {
            int aux = 0;
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i - 1]) == true)
                {
                    if (char.IsLetterOrDigit(text[i]) == true ||
                        char.IsPunctuation(text[i]))
                    {
                        aux++;
                    }
                }
            }
            if (text.Length > 2)
            {
                aux++;
            }
            return aux;
        }
      
       

        static void Main(string[] args)
        {
            string original = "hugo chagoya";
            string strand1 = "hugo";
            string strand2 = "hego";
            string reversed = Reverse(original);
            string reversedFor = ReverseFor(original);
            //2 ¡Cuantas Veces se repite un caracter de 2 formas Distintas!
            //metodo 1
            int count = original.Count(f => f == 'o');
            //metodo 2
            int count2 = original.Split('o').Length - 1;
            //3 ¡Distancia de Hamming!
            var DistHamming1 = DistHamming(strand1, strand2);
            string text = "Podemos pueda ser llamado";
            int countWords1 = CountWords(text);
            Console.WriteLine("forma 1:  {0} ; forma 2: {1} " +
                "\n , se repite(forma1): {2}" + "\n , se repite(forma2): {3}" +
                "\n los caracteres diferentes son:{4}" + " \nel total de palabras son: {5}"
                , reversed, reversedFor, count, count2, DistHamming1, countWords1);
            //        Rutina de Calculo! valores de entrada 05368, 4114, 2777, 4497
            //5.1: Rellenar por la izquierda con ceros si la clave es menor a 5 dígitos, comenzar desde la izquierda, sumar todos los caracteres ubicados en las posiciones impares.
            //5.2: Multiplicar la suma obtenida en la etapa 1 por el número 3.
            //5.3: Comenzar desde la izquierda, sumar todos los caracteres que están ubicados en las posiciones pares.
            //5.4: Sumar los resultados obtenidos en las etapas 2 y 3.
            //5.5: Buscar el menor número que sumado al resultado obtenido en la etapa 4 dé un número múltiplo de 10.
            //        Ejemplo 22374
            //5.1 = 2 + 3 + 4 = 09
            //5.2 = 09 x 3 = 27
            //5.3 = 2 + 7 = 09
            //5.4 = 27 + 09 = 36
            //5.5 = 36 + 4 = 40
            //salida: 22374
            int[] array = { 05368, 4114, 2777, 4497 };

            var mapArray2 = array.Select(n => n.ToString("D5"));
            foreach (string element in mapArray2)
            {
                string sumaimpares = element;
                char[] arrayNumeros = sumaimpares.ToCharArray();
                int sumaimpares0 = int.Parse(arrayNumeros[0].ToString());
                int sumaimpares2 = int.Parse(arrayNumeros[2].ToString());
                int sumaimpares4 = int.Parse(arrayNumeros[4].ToString());
                int sumapares1 = int.Parse(arrayNumeros[1].ToString());
                int sumapares3 = int.Parse(arrayNumeros[3].ToString());
                int sumatotalImpa = sumaimpares0 + sumaimpares2 + sumaimpares4;
                int sumatotalPares = sumapares1 + sumapares3;

                Console.WriteLine($"Suma de los numeros impares : {sumatotalImpa}");

                Console.WriteLine($"Multiplicar la suma obtenida en la etapa 1 por el número 3 : {sumatotalImpa * 3}");

                Console.WriteLine($"Suma de los numeros pares : {sumatotalPares}");
                decimal sumaE2yE3 = (sumatotalImpa * 3) + sumatotalPares;

                Console.WriteLine($"Sumar los resultados obtenidos en las etapas 2 y 3:{sumaE2yE3}");
                int base10 = 10;
                if (sumaE2yE3 % 10 != 0)
                {
                    decimal decimalSuma = sumaE2yE3 / base10;
                    decimal numMultiplo = Math.Ceiling(decimalSuma) - decimalSuma;
                    decimal numMultiploInt = numMultiplo * 10;
                    Console.WriteLine($"El numero que sumado a la etapa 4 dara un multiplo de 10 es : {numMultiploInt}");

                }
                else
                {
                    Console.WriteLine("El numero que sumado a la etapa 4 dara un multiplo de 10 es : 0");
                }

            }

            
            Console.ReadLine();

        }






    }
}

