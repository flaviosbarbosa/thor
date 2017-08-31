using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class MensagemSainteBLL
    {
        public MensagemSainte Grava(MensagemSainte MensagemSainte)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (MensagemSainte.id == 0)
                {
                    try
                    {
                        conn.Execute(@"INSERT INTO MENSAGEMSAINTE
                                        (CODMINISTERIO,
                                        CODTIPOMENSAGEM,
                                        MENSAGEM,
                                        DATAENVIO)
                                    VALUES
                                        (@CODMINISTERIO,
                                        @CODTIPOMENSAGEM,
                                        @MENSAGEM,
                                        @DATAENVIO)", MensagemSainte);

                        return conn.QueryFirst<MensagemSainte>(@"SELECT ID,
                                                                          CODMINISTERIO,
                                                                          CODTIPOMENSAGEM,
                                                                          MENSAGEM,
                                                                          DATAENVIO
                                                                      FROM MENSAGEMSAINTE", MensagemSainte);
                    }
                    catch (Exception e)
                    {
                        return new MensagemSainte();
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE MENSAGEMSAINTE
                                          SET CODMINISTERIO = @CODMINISTERIO,
                                              CODTIPOMENSAGEM = @CODTIPOMENSAGEM,
                                              MENSAGEM = @MENSAGEM,
                                              DATAENVIO = @DATAENVIO
                                        WHERE id = @id", MensagemSainte);

                        return conn.QueryFirst<MensagemSainte>(@"SELECT ID,
                                                                          CODMINISTERIO,
                                                                          CODTIPOMENSAGEM,
                                                                          MENSAGEM,
                                                                          DATAENVIO
                                                                      FROM MENSAGEMSAINTE", MensagemSainte);
                    }
                    catch (Exception e)
                    {
                        return new MensagemSainte();
                    }
            }
        }

        public MensagemSainte BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<MensagemSainte>(@"SELECT ID,
                                                                      CODMINISTERIO,
                                                                      CODTIPOMENSAGEM,
                                                                      MENSAGEM,
                                                                      DATAENVIO
                                                                  FROM MENSAGEMSAINTE", new { Id = id });


                }
                catch (Exception)
                {

                    return new MensagemSainte();
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
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<MensagemSainte> ListaMensagemSainte()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<MensagemSainte>(@"SELECT ID,
                                                                  CODMINISTERIO,
                                                                  CODTIPOMENSAGEM,
                                                                  MENSAGEM,
                                                                  DATAENVIO
                                                              FROM MENSAGEMSAINTE");

                return (List<MensagemSainte>)retorno;
            }
        }
    }
}