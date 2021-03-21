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
            else if (this.key < key)
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
            else if (this.key < key)
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
            int aux = 1;
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
        public int NumeroNos()
        {
            int aux = 0;
            if (isFolha())
            {
                return 0;
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
            if (this.filhoEsquerdo == null)
            {
                return true;
            }
            else if (this.filhoDireito == null)
            {
                return true;
            }
            return false;
        }

        public int getProfundidade()
        {
            if (this.isRaiz())
            {
                return 0;
            }
            return noPai.getProfundidade() + 1;
        }
        public int getAltura()
        {
            int alturaFilhoEsquerdo = 0, alturaFilhoDireito = 0;
            if (this.isFolha())
            {
                return 0;
            }
            if (this.filhoEsquerdo != null)
            {
                alturaFilhoEsquerdo = this.filhoEsquerdo.getAltura();
            }
            if (this.filhoDireito != null)
            {
                alturaFilhoDireito = this.filhoDireito.getAltura();
            }
            if (alturaFilhoDireito > alturaFilhoEsquerdo)
            {
                return alturaFilhoDireito;
            }
            else
            {
                return alturaFilhoEsquerdo;
            }

        }
        private List<int> CaminhamentoNLR(List<int> lista)
        {
            lista.Add(this.dados);

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
        public List<int> NLR()
        {
            List<int> lista = new List<int>();
            return this.CaminhamentoNLR(lista);
        }
        private List<int> CaminhamentoLRN(List<int> lista)
        {

            if (this.filhoEsquerdo != null)
            {
                this.filhoEsquerdo.CaminhamentoLRN(lista);
            }

            if (this.filhoDireito != null)
            {
                this.filhoDireito.CaminhamentoLRN(lista);
            }

            lista.Add(this.dados);

            return lista;
        }
        public List<int> LRN()
        {
            List<int> lista = new List<int>();
            return this.CaminhamentoLRN(lista);
        }

        private List<int> CaminhamentoLNR(List<int> lista)
        {

            if (this.filhoEsquerdo != null)
            {
                this.filhoEsquerdo.CaminhamentoLNR(lista);
            }

            lista.Add(this.dados);

            if (this.filhoDireito != null)
            {
                this.filhoDireito.CaminhamentoLNR(lista);
            }


            return lista;
        }
        public List<int> LNR()
        {
            List<int> lista = new List<int>();
            return this.CaminhamentoLNR(lista);
        }
    }
}
