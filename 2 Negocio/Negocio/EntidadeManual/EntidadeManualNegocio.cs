using System;
using System.Collections.Generic;
using Negocio.Dominio.ViewModels;
using EN = Negocio.Dominio.Entidades;
using Infraestrutura.Dados;
using System.Linq;

namespace Negocio.EntidadeManual
{
    public class EntidadeManualNegocio : IEntidadeManualNegocio
    {
        private readonly MovimentosManuaisContext contexto;
        public EntidadeManualNegocio(MovimentosManuaisContext _contexto)
        {
            contexto = _contexto;
        }

        public bool Add(EntidadeManualViewModel entidadeManual){
            var entidadeMan = new EN.EntidadeManual() {
                Mes = entidadeManual.Mes,
                Ano = entidadeManual.Ano,
                CodigoProduto =  entidadeManual.CodigoProduto,
                CodigoProdutoCosif = entidadeManual.CodigoProdutoCosif,
                Valor = entidadeManual.Valor,
                Descricao = entidadeManual.Descricao,
                CodigoUsuario = "TESTE",
                DataMovimento = DateTime.Now
            };
            
            contexto.EntidadesManuais.Add(entidadeMan);

            return contexto.SaveChanges() > 0;
        }
        public List<EntidadeManualExibirViewModel> Listar() 
        {
            var entidadesManuais = contexto.EntidadesManuais
                .Select(em => new EntidadeManualExibirViewModel{
                    Mes = em.Mes,
                    Ano = em.Ano,
                    CodigoProduto =  em.CodigoProduto,
                    CodigoProdutoCosif = em.CodigoProdutoCosif,
                    Valor = em.Valor,
                    Descricao = em.Descricao
                });

            return entidadesManuais.ToList();
        }
    }
}