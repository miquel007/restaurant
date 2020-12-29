using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp42
{
    class Program
    {
        private static int preu_500 = 500;
        private static int preu_200 = 200;
        private static int preu_100 = 100;
        private static int preu_50 = 50;
        private static int preu_20 = 20;
        private static int preu_10 = 10;
        private static int preu_5 = 5;

        static void Main(string[] args)
        {

            Dictionary<string, int> map = new Dictionary<string, int>();
            List<string> resposta = new List<string>();

            try
            {
                                    
                map = omplir_carta();
                            
                mostrar(map);
            
                resposta = preguntar(map);

                comparador(map, resposta);


            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void comparador (Dictionary<string, int> array, List<string> resposta)
        {
            int suma = 0;

            int billet500 = 0;
            int billet200 = 0;
            int billet100 = 0;
            int billet50 = 0;
            int billet20 = 0;
            int billet10 = 0;
            int billet5 = 0;

            foreach (string caso in resposta )
            {
                suma = suma + array[caso];
            }

            Console.WriteLine(suma);

            while(preu_500 <= suma)
            {
                billet500++;
                suma = suma - preu_500;
            }
            while(preu_200 <= suma)
            {
                billet200++;
                suma = suma - preu_200;
            }
            while (preu_100 <= suma)
            {
                billet100++;
                suma = suma - preu_100;
            }
            while (preu_50 <= suma)
            {
                billet50++;
                suma = suma - preu_50;
            }
            while (preu_20 <= suma)
            {
                billet20++;
                suma = suma - preu_20;
            }
            while (preu_10 <= suma)
            {
                billet10++;
                suma = suma - preu_10;
            }
            while (preu_5 <= suma)
            {
                billet5++;
                suma = suma - preu_5;
            }

            if (billet500 > 0)
                Console.WriteLine("Has de ficar {0} billets de 500", billet500);
            if (billet200 > 0)
                Console.WriteLine("Has de ficar {0} billets de 200", billet200);
            if (billet100 > 0)
                Console.WriteLine("Has de ficar {0} billets de 100", billet100);
            if (billet50 > 0)
                Console.WriteLine("Has de ficar {0} billets de 50", billet50);
            if (billet20 > 0)
                Console.WriteLine("Has de ficar {0} billets de 20", billet20);
            if (billet10 > 0)
                Console.WriteLine("Has de ficar {0} billets de 10", billet10);
            if (billet5 > 0)
                Console.WriteLine("Has de ficar {0} billets de 5", billet5);

        }

        public static List<string> preguntar(Dictionary<string, int> array)
        {
            bool continuar = true;
            List<string> resposta = new List<string>();


            while (continuar)
            {
                Console.WriteLine("Quin plat vols menjar?");
                string plat = Console.ReadLine();

                if (!array.ContainsKey(plat))
                    throw new ArgumentException("No existeix el plat");
                else
                    resposta.Add(plat);

                Console.WriteLine("Vols parar?  Si / No");
                string Nfake = Console.ReadLine();

                if (Nfake.Equals("Si") || Nfake.Equals("si"))
                    continuar = false;
                else if (!Nfake.Equals("No") && !Nfake.Equals("no"))
                    throw new ArgumentException("No saps escriure Si/No");

            }

            return resposta;
        }

        public static void mostrar (Dictionary<string, int> array)
        {
            Console.WriteLine("\n");


            foreach (KeyValuePair<string, int> key in array)
            {
                Console.WriteLine("{0} -> {1}", key.Key, key.Value);
            }
        }

        public static Dictionary<string, int> omplir_carta()
        {
            Dictionary<string, int> array = new Dictionary<string, int>();
            List<string> plats = new List<string>();
            List<int> preu = new List<int>();

            plats.Add("plat_ror");
            plats.Add("plat_rok");
            plats.Add("plat_roi");
            plats.Add("plat_rol");
            plats.Add("plat_rop");

            preu.Add(5);
            preu.Add(50);
            preu.Add(500);
            preu.Add(10);
            preu.Add(100);
            
            for (int i = 0; i < plats.Count; i++)
                array.Add(plats[i], preu[i]);

            return array;
        }
    }
}
