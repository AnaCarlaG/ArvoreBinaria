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

            //var listLRN = arv.raiz.LRN();

            //var arvorePosOrdem = Arvore.CriarArvorePosOrdem(listLRN);

            // foreach(var item in arvorePosOrdem.raiz.LRN())
            // {
            //     Console.WriteLine(item.dados);
            // }

            //var listNLR = arv.raiz.NLR();

            //var arvorePreOrdem = Arvore.CriarArvorePreOrdem(listNLR);

            //foreach (var item in arvorePreOrdem.raiz.NLR())
            //{
            //    Console.WriteLine(item.dados);
            //}

            arv.raiz.ImprimeMenoresValores();
            //arv.raiz.NLR().ForEach(x => Console.WriteLine(x.key.ToString()));

            //arv.raiz.LRN().ForEach(x => Console.WriteLine(x.key.ToString()));

            // arv.raiz.LNR().ForEach(x => Console.WriteLine(x.NumeroNos()));
        }
    }
}
