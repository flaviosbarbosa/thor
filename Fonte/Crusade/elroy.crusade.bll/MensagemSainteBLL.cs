using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class MensagemSainteBLL
    {
        public MensagemSainte Grava(MensagemSainte mensagemSainte)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (mensagemSainte.Id == 0)
                {
                    try
                    {
                        mensagemSainte.Id = (int)conn.ExecuteScalar(@"INSERT INTO MENSAGEMSAINTE
                                        (CODMINISTERIO,
                                        CODTIPOMENSAGEM,
                                        MENSAGEM,
                                        DATAENVIO,
                                        CODMENSAGEMENTRANTE)
                                    OUTPUT INSERTED.id
                                    VALUES
                                        (@CODMINISTERIO,
                                        @CODTIPOMENSAGEM,
                                        @MENSAGEM,
                                        @DATAENVIO,
                                        @CODMENSAGEMENTRANTE)", mensagemSainte);

                        return mensagemSainte;
                    }
                    catch (Exception e )
                    {
                        return new MensagemSainte();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE MENSAGEMSAINTE
                                          SET CODMINISTERIO = @CODMINISTERIO,
                                              CODTIPOMENSAGEM = @CODTIPOMENSAGEM,
                                              CODMENSAGEMENTRANTE = @CODMENSAGEMENTRANTE,
                                              MENSAGEM = @MENSAGEM,
                                              DATAENVIO = @DATAENVIO
                                        WHERE id = @id", mensagemSainte);

                        return conn.QueryFirst<MensagemSainte>(@"SELECT ID
                                                                      , CODMINISTERIO
                                                                      , CODTIPOMENSAGEM
                                                                      , MENSAGEM
                                                                      , DATAENVIO
                                                                      , CODMENSAGEMENTRANTE  
                                                                      FROM MENSAGEMSAINTE", mensagemSainte);
                    }
                    catch (Exception e)
                    {
                        return new MensagemSainte();
                        throw new Exception(e.Message);
                    }
            }
        }

        public MensagemSainte BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<MensagemSainte>(@"SELECT ID
                                                                    , CODMINISTERIO
                                                                    , CODTIPOMENSAGEM
                                                                    , MENSAGEM
                                                                    , DATAENVIO
                                                                    , CODMENSAGEMENTRANTE  
                                                                    FROM MENSAGEMSAINTE", new { Id = id });


                }
                catch (Exception e)
                {
                    return new MensagemSainte();
                    throw new Exception(e.Message);
                }
            }
        }

        public bool Deleta(MensagemSainte MensagemSainte)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<MensagemSainte>(@"DELETE FROM MensagemSainte                                                         
                                                        WHERE ID = @id", MensagemSainte);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw new Exception(e.Message);
                }
            }
        }

        public List<MensagemSainte> ListaMensagemSainte()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<MensagemSainte>(@"SELECT ID
                                                                , CODMINISTERIO
                                                                , CODTIPOMENSAGEM
                                                                , MENSAGEM
                                                                , DATAENVIO
                                                                , CODMENSAGEMENTRANTE  
                                                                FROM MENSAGEMSAINTE");

                return (List<MensagemSainte>)retorno;
            }
        }
    }
}