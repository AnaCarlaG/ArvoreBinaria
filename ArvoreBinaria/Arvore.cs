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
                if (node.filhoEsquerdo == null && node.filhoDireito == null)
                {
                    var objeto = node.dados;
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
                    var objeto = node.dados;
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
                    var objeto = node.dados;
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
                else if(node.filhoEsquerdo != null && node.filhoDireito != null)
                {
                    var sucessor = node.Sucessor();
                    var objeto = node.dados;
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
                }
            }
        }
    }
}
