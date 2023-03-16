using System;

namespace LotoClassNS
{
    // Clase que almacena una combinación de la lotería
    //
    public class LotoCNDV2223
    {
        // definición de constantes
        public const int MAX_NUMEROS = 6;
        public const int NUMERO_MENOR = 1;
        public const int NUMERO_MAYOR = 49;
        
        private int[] _numeros = new int[MAX_NUMEROS];   // numeros de la combinación
        public bool ok = false;      // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)

        public int[] Numeros { 
            get => _numeros; 
            set => _numeros = value; 
        }

        // En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta
        //
        /// <summary>
        /// Constructor sin parámetros que genera una combinación de números aleatorios de la lotería
        /// </summary>
        public LotoCNDV2223()
        {
            GeneradorNumerosAleatorios();
        }

        private void GeneradorNumerosAleatorios()
        {
            Random r = new Random();    // clase generadora de números aleatorios

            int i = 0, j, num;

            do             // generamos la combinación
            {
                num = r.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);     // generamos un número aleatorio del 1 al 49
                for (j = 0; j < i; j++)    // comprobamos que el número no está
                {
                    if (Numeros[j] == num)
                    {
                        break;
                    }
                }

                if (i == j)               // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                {
                    Numeros[i] = num;
                    i++;
                }
            } while (i < MAX_NUMEROS);

            ok = true;
        }

        // La segunda forma de crear una combinación es pasando el conjunto de números
        // misnums es un array de enteros con la combinación que quiero crear (no tiene porqué ser válida)
        /// <summary>
        /// Constructor con un parámetro 
        /// </summary>
        /// <param name="misNumeros"></param>
        public LotoCNDV2223(int[] misNumeros)  // misnumeros: combinación con la que queremos inicializar la clase
        {
            for (int i = 0; i < MAX_NUMEROS; i++)
                if (misNumeros[i] >= NUMERO_MENOR && misNumeros[i] <= NUMERO_MAYOR)
                {
                    int j;
                    for ( j = 0; j < i; j++)
                    {
                        if ( misNumeros[i] == Numeros[j] )
                        {
                            break;
                        }
                    }

                    if ( i == j)
                    {
                        Numeros[i] = misNumeros[i]; // validamos la combinación
                    }
                    else {
                        ok = false;
                        return;
                    }
                }
                else
                {
                    ok = false;     // La combinación no es válida, terminamos
                    return;
                }
	    ok = true;
        }

        // Método que comprueba el número de aciertos
        // premi es un array con la combinación ganadora
        // se devuelve el número de aciertos
        /// <summary>
        /// Método que comprueba el número de aciertos de la lotería
        /// </summary>
        /// <param name="premios">El método tiene un parámetro</param>
        /// <returns> Devuelve el resultado de los aciertos</returns>
        public int Comprobar(int[] premios)
        {
            int a = 0;  
            // número de aciertos
            for (int i = 0; i < MAX_NUMEROS; i++)
            {
                for ( int j = 0; j < MAX_NUMEROS; j++)
                {
                    if (premios[i] == Numeros[j])
                    {
                        a++;
                    }
                }
            }

            return a;
        }

        public int Comprobar()
        {
            throw new NotImplementedException();
        }
    }

}
