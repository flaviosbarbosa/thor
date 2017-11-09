
using Dapper;
using elroy.crusade.dominio;
using elroy.crusade.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class AgendaPastoralBLL
    {
        public AgendaPastoral Grava(AgendaPastoral AgendaPastoral)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();

            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(AgendaPastoral.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, AgendaPastoral.Id);
                else
                {
                    AgendaPastoral.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }
                
                if (acao == Acoes.Inserir.ToString())
                {
                    try
                    {                        
                    conn.Execute(@"INSERT INTO AGENDAPASTORAL
                                           (ID,
                                           EVENTO,
                                           DATA,                                           
                                           LOCAL,
                                           PRIVADO)
                                     VALUES
                                           (@ID,
                                           @EVENTO,
                                           @DATA,                                           
                                           @LOCAL,
                                           @PRIVADO)", AgendaPastoral);

                        return AgendaPastoral;
                    }
                    catch (Exception e )
                    {
                        return new AgendaPastoral();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE AGENDAPASTORAL
                                           SET EVENTO = @EVENTO,
                                                DATA = @DATA,                                                
                                                LOCAL = @LOCAL,
                                                PRIVADO = @PRIVADO
                                            WHERE id = @id", AgendaPastoral);

                        return conn.QueryFirst<AgendaPastoral>(@"SELECT * FROM AgendaPastoral", AgendaPastoral);
                    }
                    catch (Exception e)
                    {
                        return new AgendaPastoral();
                        throw new Exception(e.Message);
                    }
            }
        }

        public AgendaPastoral Busca(String id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<AgendaPastoral>(@"SELECT ID,
                                                                    EVENTO,
                                                                    DATA,                                                                  
                                                                    LOCAL,
                                                                    PRIVADO
                                                                FROM AGENDAPASTORAL
                                                        WHERE ID = @ID", new { Id = id });
                }
                catch (Exception e)
                {
                    return new AgendaPastoral();
                    throw new Exception(e.Message);

                }
            }
        }

        public bool Deleta(AgendaPastoral AgendaPastoral)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<AgendaPastoral>(@"DELETE FROM AgendaPastoral                                                         
                                                        WHERE ID = @id", AgendaPastoral);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw new Exception(e.Message);
                }
            }
        }

        public List<AgendaPastoral> ListaAgendaPastoral()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<AgendaPastoral>(@"SELECT * FROM AgendaPastoral");

                return (List<AgendaPastoral>)retorno;
            }
        }
    }
}
