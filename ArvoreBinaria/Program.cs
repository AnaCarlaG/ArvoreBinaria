using System;

namespace ArvoreBinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Arvore arv = new Arvore();

            No _1 = new No(1, null);

            arv.raiz = _1;

            No _2 = new No(2, _1);
            No _3 = new No(3, _1);
            No _6 = new No(6, _3);
            No _4 = new No(4, _2);
            No _5 = new No(5, _2);
            No _7 = new No(7, _5);
            No _8 = new No(8, _5);

            _1.filhoEsquerdo = _2;
            _1.filhoDireito = _3;

            _2.filhoEsquerdo = _4;
            _2.filhoDireito = _5;

            _5.filhoDireito = _8;
            _5.filhoEsquerdo = _7;

            _3.filhoDireito = _6;

           // arv.raiz.NLR().ForEach(x => Console.WriteLine(x.ToString()));

            //arv.raiz.LRN().ForEach(x => Console.WriteLine(x.ToString()));

            arv.raiz.LNR().ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
