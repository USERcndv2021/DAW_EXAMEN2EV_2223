using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LotoClassNS;
using System.Collections.Generic;

namespace TestLotoCNDV22223
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       
        public void ValiadarNumeros()
        {
            List<int > numeros = new List<int>();
            {
                numeros.Add(3);
                numeros.Add(4);
                numeros.Add(12);
                numeros.Add(45);
                numeros.Add(7);
                numeros.Add(23);
            }
            try
            {
                for (int numero = 0; numero < numeros.Count; numero++)
                {
                    if (numeros[numero] < 0)
                    {

                        int[] cantidadNumerosEsperados = { 3, 4, 12, 45, 7, 23 };
                        LotoCNDV2223 miLoto = new LotoCNDV2223();
                        int actual = miLoto.Comprobar();
                        Assert.AreEqual(actual, cantidadNumerosEsperados);

                    }


                }

            }catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
