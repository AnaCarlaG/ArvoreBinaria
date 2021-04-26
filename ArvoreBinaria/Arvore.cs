using System;
using System.Collections.Generic;
using System.Text;

namespace ArvoreBinaria
{
    public class Arvore
    {
        public No raiz { get; set; }

        public int Delete(int key)
        {
            if (this.raiz.key == key)
            {
                if (this.raiz.filhoEsquerdo == null && this.raiz.filhoDireito == null)
                {
                    var objeto = this.raiz.dados;
                    this.raiz = null;
                    return objeto;
                }
                else if (this.raiz.filhoEsquerdo != null && this.raiz.filhoDireito == null)
                {
                    var objeto = this.raiz.dados;
                    this.raiz = this.raiz.filhoEsquerdo;
                    this.raiz.noPai = null;
                    return objeto;
                }
                else if (this.raiz.filhoEsquerdo == null && this.raiz.filhoDireito != null)
                {
                    var objeto = this.raiz.dados;
                    this.raiz = this.raiz.filhoDireito;
                    this.raiz.noPai = null;
                    return objeto;
                }
                else
                {
                    var sucessor = this.raiz.Sucessor();
                    var objeto = raiz.dados;
                    this.Delete(sucessor.key);
                    this.raiz.key = sucessor.key;
                    this.raiz.dados = sucessor.dados;
                    return objeto;
                }
            }
            else
            {
                No node = this.raiz.Consultar(key);
                var objeto = node.dados;
                if (node.filhoEsquerdo == null && node.filhoDireito == null)
                {
                    if (node.noPai.filhoEsquerdo.key == node.key)
                    {
                        node.noPai.filhoEsquerdo = null;
                    }
                    else
                    {
                        node.noPai.filhoDireito = null;
                    }
                    return objeto;
                }
                else if (node.filhoEsquerdo != null && node.filhoDireito == null)
                {
                    if (node.noPai.filhoEsquerdo.key == node.key)
                    {
                        node.noPai.filhoEsquerdo = node.filhoEsquerdo;
                    }
                    else
                    {
                        node.noPai.filhoDireito = node.filhoEsquerdo;
                    }
                    return objeto;
                }
                else if (node.filhoEsquerdo == null && node.filhoDireito != null)
                {
                    if (node.noPai.filhoDireito.key == node.key)
                    {
                        node.noPai.filhoDireito = node.filhoDireito;
                    }
                    else
                    {
                        node.noPai.filhoEsquerdo = node.filhoDireito;
                    }
                    return objeto;
                }
                else if (node.filhoEsquerdo != null && node.filhoDireito != null)
                {
                    var sucessor = node.Sucessor();
                    objeto = node.dados;
                    this.Delete(sucessor.key);
                    node.key = sucessor.key;
                    node.dados = sucessor.dados;
                    return objeto;
                }
                else
                {
                    if (node.noPai.filhoDireito.key == node.key)
                    {
                        node.noPai.filhoDireito = null;
                    }
                    else
                    {
                        node.noPai.filhoEsquerdo = null;
                    }
                    return objeto;
                }
            }
        }

        public void Inverter()
        {
            var listaNos = this.raiz.LNR();
            foreach (No item in listaNos)
            {
                item.InverterSubarvores();
            }
        }

        public void Inserir(int key, int dados)
        {
            if (this.raiz == null)
            {
                this.raiz = new No(key, dados, null);
            }
            else
            {
                this.raiz.Persistir(key, dados);
            }
        }

        public No Consultar(int key)
        {
            return this.raiz.Consultar(key);
        }

        public int NumeroNos()
        {
            return this.raiz.NumeroNos();
        }

        public static Arvore CriarArvorePosOrdem(List<No> nodes)
        {
            nodes.Reverse();
            Arvore arv = new Arvore();
            foreach (var item in nodes)
            {
                arv.Inserir(item.key, item.dados);
            }
            return arv;
        }
        public static Arvore CriarArvorePreOrdem(List<No> nodes)
        {
            Arvore arv = new Arvore();
            nodes.ForEach(x => arv.Inserir(x.key, x.dados));

            return arv;
        }

        public static Arvore CriarArvoreInOrdem(List<No> nodes)
        {
            Arvore arv = new Arvore();
            foreach(var item in nodes)
            {
                arv.Inserir(item.key, item.dados);
            }
            return arv;
        }
        public bool EstritamenteBinaria()
        {
            return raiz.EstritamenteBinaria();
        }
        public void ImprimirNoPaiEMaiorValorFilho()
        {
            raiz.ImprimirNoPaiEMaiorValorFilho();
        }
        public void ImprimeMenoresValores()
        {
            raiz.ImprimeMenoresValores();
        }
    }
}