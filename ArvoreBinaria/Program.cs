using System;

namespace ArvoreBinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Arvore arv = new Arvore();

            arv.Inserir(8, 8);
            arv.Inserir(4, 4);
            arv.Inserir(12, 12);
            arv.Inserir(2, 2);
            arv.Inserir(3, 3);
            arv.Inserir(6, 6);
            arv.Inserir(5, 5);
            arv.Inserir(7, 7);
            arv.Inserir(10, 10);
            arv.Inserir(9, 9);
            arv.Inserir(11, 11);
            arv.Inserir(14, 14);
            arv.Inserir(13, 13);

            // arv.Delete(8);

            Console.WriteLine(arv.Consultar(12).getAltura());


           // arv.Consultar(3);
            // arv.raiz.NLR().ForEach(x => Console.WriteLine(x.key.ToString()));

           // arv.raiz.LRN().ForEach(x => Console.WriteLine(x.key.ToString()));

            //arv.raiz.LNR().ForEach(x => Console.WriteLine(x.NumeroNos()));
        }
    }
}
