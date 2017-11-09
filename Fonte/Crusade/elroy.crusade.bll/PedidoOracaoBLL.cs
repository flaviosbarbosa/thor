using Dapper;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using elroy.crusade.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.bll
{
    public class PedidoOracaoBLL
    {
        //DONE: Implementar
        public PedidoOracao Grava(PedidoOracao pedidoOracao)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();

            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(pedidoOracao.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, pedidoOracao.Id);
                else
                {
                    pedidoOracao.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }

                if (acao == Acoes.Inserir.ToString())

                {
                    try
                    {
                        conn.Execute(@"INSERT INTO PedidoOracao
	    	                            (ID,
                                        CodMensagemEntrante,
                                        CodSolicitante,
                                        NomeSolicitante,
                                        DataSolicitacao,
                                        Assunto,
                                        Descricao,
                                        DescricaoRevisada)                                    
                                        VALUES
                                        (@ID,
                                        @CodMensagemEntrante,
                                        @CodSolicitante,
                                        @NomeSolicitante,
                                        @DataSolicitacao,
                                        @Assunto,
                                        @Descricao,
                                        @DescricaoRevisada)", pedidoOracao);

                        return pedidoOracao;
                    }
                    catch (Exception e)
                    {
                        return new PedidoOracao();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE PedidoOracao
                                      SET 
                                        CodMensagemEntrante = @CodMensagemEntrante,
                                        CodSolicitante = @CodSolicitante,
                                        NomeSolicitante = @NomeSolicitante,
                                        DataSolicitacao = @DataSolicitacao,
                                        Assunto = @Assunto,
                                        Descricao = @Descricao,
                                        DescricaoRevisada = @DescricaoRevisada
                                        WHERE id = @id", pedidoOracao);

                        return conn.QueryFirst<PedidoOracao>(@"SELECT ID, 
                                                                   CodMensagemEntrante,
                                                                      CodSolicitante,
                                                                      NomeSolicitante,
                                                                      DataSolicitacao,
                                                                      Assunto,
                                                                      Descricao,
                                                                      DescricaoRevisada                                                                
                                                              FROM PedidoOracao
                                                             where id = @id", pedidoOracao);
                    }
                    catch (Exception e)
                    {
                        return new PedidoOracao();
                        throw new Exception(e.Message);
                    }
            }
        }

        public PedidoOracao Busca(String id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<PedidoOracao>(@"SELECT ID, 
                                                                   CodMensagemEntrante,
                                                                      CodSolicitante,
                                                                      NomeSolicitante,
                                                                      DataSolicitacao,
                                                                      Assunto,
                                                                      Descricao,
                                                                      DescricaoRevisada
                                                                    
                                                              FROM PedidoOracao
                                                        WHERE ID = @ID", new { Id = id });
                }
                catch (Exception e)
                {
                    return new PedidoOracao();
                    throw new Exception(e.Message);
                }
            }
        }

        public bool Deleta(PedidoOracao pedidoOracao)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<PedidoOracao>(@"DELETE FROM PedidoOracao                                                         
                                                        WHERE ID = @id", pedidoOracao);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw new Exception(e.Message);
                }
            }
        }

        public List<PedidoOracao> ListaPedidoOracao()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<PedidoOracao>(@"SELECT ID, 
                                                                CodMensagemEntrante,
                                                                CodSolicitante,
                                                                NomeSolicitante,
                                                                DataSolicitacao,
                                                                Assunto,
                                                                Descricao,
                                                                DescricaoRevisada
                                                             
                                                              FROM PedidoOracao");

                return (List<PedidoOracao>)retorno;
            }
        }
    }
}
