
using Dapper;
using elroy.crusade.dominio;
using elroy.crusade.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class EventosBLL
    {
        public Eventos Grava(Eventos eventos)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();

            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(eventos.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, eventos.Id);
                else
                {
                    eventos.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }

                if (acao == Acoes.Inserir.ToString())

                {
                    try
                    {
                        conn.Execute(@"INSERT INTO EVENTOS
                                        (ID,
                                              CODMINISTERIO,
                                              TITULO,
                                              DESCRICAO,
                                              DATA,
                                              LOCAL,                                              
                                              PRIVADO,
                                              PASTORPRESENTE)                                              
                                             VALUES
                                             (@ID,
                                              @CODMINISTERIO,
                                              @TITULO,
                                              @DESCRICAO,
                                              @DATA,
                                              @LOCAL,                                              
                                              @PRIVADO,
                                              @PASTORPRESENTE)", eventos);

                        return eventos;
                    }
                    catch (Exception e)
                    {
                        return new Eventos();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE EVENTOS
                                       SET CODMINISTERIO = @CODMINISTERIO,
                                          TITULO = @TITULO,
                                          DESCRICAO = @DESCRICAO,
                                          DATA = @DATA,
                                          LOCAL = @LOCAL,                                          
                                          PRIVADO = @PRIVADO,
                                          PASTORPRESENTE = @PASTORPRESENTE
                                     WHERE id = @id", eventos);

                        return conn.QueryFirst<Eventos>(@"SELECT ID,
                                                              CODMINISTERIO,
                                                              TITULO,
                                                              DESCRICAO,
                                                              DATA,
                                                              LOCAL,                                                         
                                                              PRIVADO,
                                                              PASTORPRESENTE
                                                          FROM EVENTOS", eventos);
                    }
                    catch (Exception e)
                    {
                        return new Eventos();
                        throw new Exception(e.Message);
                    }
            }                      
        }

        public Eventos Busca(String id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Eventos>(@"SELECT ID,
                                                              CODMINISTERIO,
                                                              TITULO,
                                                              DESCRICAO,
                                                              DATA,
                                                              LOCAL,
                                                              PRIVADO,
                                                              PASTORPRESENTE
                                                          FROM EVENTOS
                                                         WHERE id = @id", new { Id = id });


                }
                catch (Exception e)
                {
                    return new Eventos();
                    throw new Exception(e.Message);

                }
            }
        }

        public bool Deleta(Eventos eventos)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Eventos>(@"DELETE FROM Eventos                                                         
                                                        WHERE ID = @id", eventos);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<Eventos> ListaEventos()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Eventos>(@"SELECT ID,
                                                          CODMINISTERIO,
                                                          TITULO,
                                                          DESCRICAO,
                                                          DATA,
                                                          LOCAL,
                                                          PRIVADO,
                                                          PASTORPRESENTE
                                                      FROM EVENTOS");

                return (List<Eventos>)retorno;
            }
        }
    }
}