using Dapper;
using elroy.crusade.dominio;
using elroy.crusade.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class TipoMensagemBLL
    {
        public TipoMensagem Grava(TipoMensagem tipoMensagem)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();

            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(tipoMensagem.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, tipoMensagem.Id);
                else
                {
                    tipoMensagem.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }

                if (acao == Acoes.Inserir.ToString())

                {
                    try
                    {
                        conn.Execute(@"INSERT INTO TIPOMENSAGEM
                                               (ID,TIPO,
                                               DESCRICAO)                                    
                                         VALUES
                                               (@ID,
                                               @TIPO,
                                               @DESCRICAO)", tipoMensagem);

                        return tipoMensagem;
                    }
                    catch (Exception e )
                    {
                        return new TipoMensagem();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE TIPOMENSAGEM
                                        SET TIPO = @TIPO,
                                            DESCRICAO = @DESCRICAO
                                        WHERE id = @id", tipoMensagem);

                        return conn.QueryFirst<TipoMensagem>(@"SELECT ID,
                                                                      TIPO,
                                                                      DESCRICAO
                                                                  FROM TIPOMENSAGEM", tipoMensagem);
                    }
                    catch (Exception )
                    {
                        return new TipoMensagem();
                    }
            }
        }

        public TipoMensagem Busca(String id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<TipoMensagem>(@"SELECT ID,
                                                                  TIPO,
                                                                  DESCRICAO
                                                              FROM TIPOMENSAGEM
                                                              WHERE id = @id", new { Id = id });


                }
                catch (Exception)
                {

                    return new TipoMensagem();
                }
            }
        }

        public bool Deleta(TipoMensagem TipoMensagem)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<TipoMensagem>(@"DELETE FROM TipoMensagem                                                         
                                                        WHERE ID = @id", TipoMensagem);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<TipoMensagem> ListaTipoMensagem()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<TipoMensagem>(@"SELECT ID,
                                                                  TIPO,
                                                                  DESCRICAO
                                                              FROM TIPOMENSAGEM");

                return (List<TipoMensagem>)retorno;
            }
        }
    }
}