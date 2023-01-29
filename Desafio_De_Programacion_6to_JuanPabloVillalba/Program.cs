using System;
using System.Text;

namespace Ejercicio6to
{
    class Program
    {
        public static void Main(string[] args)
        {

            /*

            Dos amigos quieren enviar mensajes de texto cifrados, de manera que nadie más que ellos 
            dos puedan entenderlos. Para ello deciden escribir los mensajes mezclando frases escritas 
            en sentido normal, con frases escritas al revés. Pero para no olvidarse de las frases al 
            revés, las escriben entre paréntesis.
            Se pide desarrollar un programa capaz de leer desde el teclado un mensaje cifrado, 
            descifrarlo y mostrarlo por pantalla.
            Por ejemplo, dado el mensaje:
            Hola ¿(opmeit otnat sadna omóc)? Hoy nos juntamos (nauJ ed asac al ne) a las 8 de 
            la noche.
            La salida deberá ser:
            Hola ¿cómo andas tanto tiempo? Hoy nos juntamos en la casa de Juan a las 8 de la 
            noche

            */

            string texto;

            Console.Write("\n\n\tEJERCICIO DE 6TO");
            Console.Write("\n\t--------- -- ---");

            Console.Write("\n\n\n\tIngrese Un Mensaje Y Entre Parentesis Escriba El Mensaje Cifrado (al reves): ");

            texto = Console.ReadLine();

            Detectar(texto);

            Console.ReadKey();

        }

        // Convierte la string en un array de tipo char para luego invertir todo y retornar la respuesta.
        public static string Invertir(string str)
        {
            char[] wordsArray = str.ToCharArray();

            Array.Reverse(wordsArray);
            
            return new string(wordsArray);

        }

        public static void Detectar(string str)
        {
            int count = 0;

            foreach (char word in str)
            {
                if(word == '(')
                {
                    count++;  
                }
            }

            if (count > 0)
            {

                int start = str.IndexOf("(");

                int end = str.IndexOf(")");

                string delete = str.Remove(start, (end - start) + 1);

                string cut = str.Substring((start + 1), (end - start) - 1);

                string response = Invertir(cut);

                string finish = delete.Insert(start, response);

                if (count > 1)
                {
                    for (int i = 0; i < count - 1; i++)
                    {

                        start = finish.IndexOf("(");

                        end = finish.IndexOf(")");

                        delete = finish.Remove(start, (end - start) + 1);

                        cut = finish.Substring((start + 1), (end - start) - 1);

                        response = Invertir(cut);

                        finish = delete.Insert(start, response);

                    }
                }

                Console.WriteLine("\n\n\tRESULTADO");

                Console.WriteLine("\t---------");

                Console.WriteLine("\n\n\t" + finish);

               } else
                {
                    Console.WriteLine("\n\n\n\t(!) Lo siento, este mensaje no es valido (!)");
                }
            }

        }

    }