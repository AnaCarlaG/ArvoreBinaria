using System;
using System.Collections.Generic;
using System.Text;

namespace ArvoreBinaria
{
    public class No
    {
        public int dados { get; set; }
        public No filhoEsquerdo { get; set; }
        public No filhoDireito { get; set; }
        public No noPai { get; set; }

        public No(int _dados, No _noPai)
        {
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
