using System;
using System.Collections.Generic;
using System.Text;

namespace ArvoreBinaria
{
    public class No
    {
        public int dados { get; set; }
        public int key { get; set; }
        public No filhoEsquerdo { get; set; }
        public No filhoDireito { get; set; }
        public No noPai { get; set; }

        public No(int key, int _dados, No _noPai)
        {
            this.key = key;
            this.dados = _dados;
            this.noPai = _noPai;
        }

        public bool isRaiz()
        {
            if (noPai != null)
            {
                return false;
            }
            return true;
        }

        public void Persistir(int key, int dados)
        {
            this.AdicionarOrAtualizarRecursivo(key, dados);
        }
        private void AdicionarOrAtualizarRecursivo(int key, int dados)
        {
            if (this.key == key)
            {
                this.dados = dados;
            }
            else if (this.key > key)
            {
                if (this.filhoEsquerdo != null)
                {
                    filhoEsquerdo.AdicionarOrAtualizarRecursivo(key, dados);
                }
                else
                {
                    filhoEsquerdo = new No(key, dados, this);
                }
            }
            else
            {
                if (this.filhoDireito != null)
                {
                    filhoDireito.AdicionarOrAtualizarRecursivo(key, dados);
                }
                else
                {
                    filhoDireito = new No(key, dados, this);
                }
            }
        }
        public No Consultar(int key)
        {
            return this.ConsultaRecursiva(key);
        }
        private No ConsultaRecursiva(int key)
        {
            if (this.key == key)
            {
                return this;
            }
            else if (this.key > key)
            {
                if (this.filhoEsquerdo != null)
                {
                    return this.filhoEsquerdo.ConsultaRecursiva(key);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (this.filhoDireito != null)
                {
                    return this.filhoDireito.ConsultaRecursiva(key);
                }
                else
                {
                    return null;
                }
            }
        }
        public No Sucessor()
        {
            if (this.filhoDireito != null)
            {
                return this.filhoDireito.Minimo();
            }
            return this;
        }
        public No Antecessor()
        {
            if (this.filhoEsquerdo != null)
            {
                return this.filhoEsquerdo.Maximo();
            }
            return this;
        }
        public No Maximo()
        {
            if (this.filhoDireito != null)
            {
                return this.filhoDireito.Maximo();
            }
            return this;
        }
        public No Minimo()
        {
            if (this.filhoEsquerdo != null)
            {
                return filhoEsquerdo.Minimo();
            }
            return this;
        }
        public int getGrau()
        {
            int aux = 0;
            if (this.filhoEsquerdo != null)
            {
                aux += 1;
            }
            if (this.filhoDireito != null)
            {
                aux += 1;
            }
            return aux;
        }
        public int NumeroNos()
        {
            int aux = 1;
            if (isFolha())
            {
                return 1;
            }
            if (this.filhoEsquerdo != null)
            {
                aux += this.filhoEsquerdo.NumeroNos();
            }
            if (this.filhoDireito != null)
            {
                aux += filhoDireito.NumeroNos();
            }
            return aux;
        }

        public bool isFolha()
        {
            if (this.filhoEsquerdo == null && this.filhoDireito == null)
            {
                return true;
            }
            return false;
        }

        public int getNivel()
        {
            if (this.isRaiz())
            {
                return 0;
            }
            return noPai.getNivel() + 1;
        }
        public int getProfundidade()
        {
            int alturaFilhoEsquerdo = 0, alturaFilhoDireito = 0;
            if (this.isFolha())
            {
                return 1;
            }
            if (this.filhoEsquerdo != null)
            {
                alturaFilhoEsquerdo = this.filhoEsquerdo.getProfundidade();
            }
            if (this.filhoDireito != null)
            {
                alturaFilhoDireito = this.filhoDireito.getProfundidade();
            }
            if (alturaFilhoDireito > alturaFilhoEsquerdo)
            {
                return alturaFilhoDireito + 1;
            }
            else
            {
                return alturaFilhoEsquerdo + 1;
            }
        }
        private List<No> CaminhamentoNLR(List<No> lista)
        {
            lista.Add(this);

            if (this.filhoEsquerdo != null)
            {
                this.filhoEsquerdo.CaminhamentoNLR(lista);
            }

            if (this.filhoDireito != null)
            {
                this.filhoDireito.CaminhamentoNLR(lista);
            }

            return lista;
        }
        public List<No> NLR()
        {
            List<No> lista = new List<No>();
            return this.CaminhamentoNLR(lista);
        }
        private List<No> CaminhamentoLRN(List<No> lista)
        {

            if (this.filhoEsquerdo != null)
            {
                this.filhoEsquerdo.CaminhamentoLRN(lista);
            }

            if (this.filhoDireito != null)
            {
                this.filhoDireito.CaminhamentoLRN(lista);
            }

            lista.Add(this);

            return lista;
        }
        public List<No> LRN()
        {
            List<No> lista = new List<No>();
            return this.CaminhamentoLRN(lista);
        }

        private List<No> CaminhamentoLNR(List<No> lista)
        {

            if (this.filhoEsquerdo != null)
            {
                this.filhoEsquerdo.CaminhamentoLNR(lista);
            }

            lista.Add(this);

            if (this.filhoDireito != null)
            {
                this.filhoDireito.CaminhamentoLNR(lista);
            }


            return lista;
        }
        public List<No> LNR()
        {
            List<No> lista = new List<No>();
            return this.CaminhamentoLNR(lista);
        }
        public void InverterSubarvores()
        {
            var filhoE = this.filhoEsquerdo;
            var filhoD = this.filhoDireito;

            this.filhoEsquerdo = filhoD;
            this.filhoDireito = filhoE;
        }
        public void ImprimeMenoresValores()
        {
            var nodes = this.LNR();
            int size = nodes.Count / 2;

            var aux = nodes.GetRange(0, size);
            foreach (var item in aux)
            {
                Console.WriteLine("key: " + item.key.ToString() + " dados: " + item.dados);
            }      
        }

        public void ImprimirNoPaiEMaiorValorFilho()
        {
            var nodes = this.LNR();
            foreach (var item in nodes)
            {
                if (item.getGrau() > 0)
                {
                    Console.WriteLine("No pai: " + item.key.ToString());

                    if (item.filhoEsquerdo != null && item.filhoDireito != null)
                    {
                        if (item.filhoDireito.dados > item.filhoEsquerdo.dados)
                        {
                            Console.WriteLine("Valor máximo do filho: " + item.filhoDireito.dados);
                        }
                        else
                        {
                            Console.WriteLine("Valor máximo do filho: " + item.filhoEsquerdo.dados);
                        }
                    }
                    else if (item.filhoEsquerdo != null)
                    {
                        Console.WriteLine("Valor máximo do filho: " + item.filhoEsquerdo.dados);
                    }
                    else if (item.filhoDireito != null)
                    {
                        Console.WriteLine("Valor máximo do filho: " + item.filhoDireito.dados);
                    }
                }

            }
        }

        public bool EstritamenteBinaria()
        {
            var nodes = this.LNR();
            foreach (var item in nodes)
            {
                if (item.getGrau() > 0)
                {
                    if (item.filhoEsquerdo == null || item.filhoDireito == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
