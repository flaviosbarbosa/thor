using Dapper;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.bll
{
    public class ParticipanteBLL
    {
        //DONE: Implementar
        public Participantes Grava(Participantes participante)
        {            
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                if (participante.Id == 0)
                {
                    try
                    {
                        participante.Id = (int)conn.ExecuteScalar(@"INSERT INTO Participantes
	    	                            (
                                        Situacao,
                                        CodMembro,
                                        CodEvento,
                                        Lembrete)
                                        OUTPUT INSERTED.id        
                                        VALUES
                                        (
                                        @Situacao,
                                        @CodMembro,
                                        @CodEvento,
                                        @Lembrete)", participante);

                        return participante;
                    }
                    catch (Exception e)
                    {
                        return new Participantes();
                        throw new Exception(e.Message);
                    }
                }
                else
                try
                {
                    var retorno =
                    conn.Execute(@"UPDATE Participantes
                                      SET 
                                 Situacao = @SITUACAO,
                                CodMembro = @CODMEMBRO,
                                CodEvento = @CODEVENTO,
                                 Lembrete = @LEMBRETE
                                 WHERE id = @id", participante);

                    return conn.QueryFirst<Participantes>(@"SELECT ID, 
                                                                   Situacao,
                                                                   CodMembro,
                                                                   CodEvento,
                                                                   Lembrete 
                                                              FROM Participantes
                                                                  where id = @id", new { id = participante.Id });
                        
                }
                catch (Exception e)
                {
                    return new Participantes();
                    throw new Exception(e.Message);
                }
            }
        }

        public Participantes BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Participantes>(@"SELECT ID, 
                                                                   Situacao,
                                                                   CodMembro,
                                                                   CodEvento,
                                                                   Lembrete 
                                                              FROM Participantes
                                                        WHERE ID = @ID", new { Id = id });
                }
                catch (Exception e)
                {
                    return new Participantes();
                    throw new Exception(e.Message);
                }
            }
        }

        public bool Deleta(Participantes participante)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Participantes>(@"DELETE FROM Participantes                                                         
                                                        WHERE ID = @id", participante);
                    return true;
                }
                catch (Exception e)
                { 
                    return false;
                    throw new Exception(e.Message);
                }
            }
        }

        public List<Participantes> ListaParticipante()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Participantes>(@"SELECT ID, 
                                                                   Situacao,
                                                                   CodMembro,
                                                                   CodEvento,
                                                                   Lembrete 
                                                              FROM Participantes");

                return (List<Participantes>)retorno;
            }
        }
    }
}
