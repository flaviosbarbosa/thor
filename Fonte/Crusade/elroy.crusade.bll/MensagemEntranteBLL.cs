using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class MensagemEntranteBLL
    {
        public MensagemEntrante Grava(MensagemEntrante mensagemEntrante)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (mensagemEntrante.Id == 0)
                {
                    try
                    {
                        conn.Execute(@"INSERT INTO MENSAGEMENTRANTE
                                           (CODTIPOMENSAGEM,
                                           NOMESOLICITANTE,
                                           ASSUNTO,
                                           MENSAGEM,
		                                   EMAILCONTATO,
                                           PERMITERETORNO,
                                           TELEFONECONTATO,
		                                   DATACONTATO,
                                           FREQUENTA)
                                     VALUES
                                           (
                                           @CODTIPOMENSAGEM,
                                           @NOMESOLICITANTE,
                                           @ASSUNTO,
                                           @MENSAGEM,
                                           @EMAILCONTATO,
                                           @PERMITERETORNO,
                                           @TELEFONECONTATO,
                                           @DATACONTATO,
                                           @FREQUENTA)", mensagemEntrante);

                        return conn.QueryFirst<MensagemEntrante>(@"SELECT ID,
                                                                          CODTIPOMENSAGEM,
                                                                          NOMESOLICITANTE,
                                                                          ASSUNTO,
                                                                          MENSAGEM,
                                                                          EMAILCONTATO,
                                                                          PERMITERETORNO,
                                                                          TELEFONECONTATO,
                                                                          DATACONTATO,
                                                                          FREQUENTA
                                                                      FROM MENSAGEMENTRANTE", mensagemEntrante);
                    }
                    catch (Exception )
                    {
                        return new MensagemEntrante();
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE MENSAGEMENTRANTE
                                           SET CODTIPOMENSAGEM = @CODTIPOMENSAGEM,
                                              NOMESOLICITANTE = @NOMESOLICITANTE,
                                              ASSUNTO = @ASSUNTO,
                                              MENSAGEM = @MENSAGEM,
                                              EMAILCONTATO = @EMAILCONTATO,
                                              PERMITERETORNO = @PERMITERETORNO,
                                              TELEFONECONTATO = @TELEFONECONTATO, 
                                              DATACONTATO = @DATACONTATO,
                                              FREQUENTA = @FREQUENTA
                                         WHERE id = @id", mensagemEntrante);

                        return conn.QueryFirst<MensagemEntrante>(@"SELECT ID,
                                                                          CODTIPOMENSAGEM,
                                                                          NOMESOLICITANTE,
                                                                          ASSUNTO,
                                                                          MENSAGEM,
                                                                          EMAILCONTATO,
                                                                          PERMITERETORNO,
                                                                          TELEFONECONTATO,
                                                                          DATACONTATO,
                                                                          FREQUENTA
                                                                      FROM MENSAGEMENTRANTE", mensagemEntrante);
                    }
                    catch (Exception )
                    {
                        return new MensagemEntrante();
                    }
            }
        }

        public MensagemEntrante BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<MensagemEntrante>(@"SELECT ID,
                                                                      CODTIPOMENSAGEM,
                                                                      NOMESOLICITANTE,
                                                                      ASSUNTO,
                                                                      MENSAGEM,
                                                                      EMAILCONTATO,
                                                                      PERMITERETORNO,
                                                                      TELEFONECONTATO,
                                                                      DATACONTATO,
                                                                      FREQUENTA
                                                                  FROM MENSAGEMENTRANTE", new { Id = id });


                }
                catch (Exception)
                {

                    return new MensagemEntrante();
                }
            }
        }

        public bool Deleta(MensagemEntrante MensagemEntrante)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<MensagemEntrante>(@"DELETE FROM MensagemEntrante                                                         
                                                        WHERE ID = @id", MensagemEntrante);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<MensagemEntrante> ListaMensagemEntrante()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<MensagemEntrante>(@"SELECT ID,
                                                                      CODTIPOMENSAGEM,
                                                                      NOMESOLICITANTE,
                                                                      ASSUNTO,
                                                                      MENSAGEM,
                                                                      EMAILCONTATO,
                                                                      PERMITERETORNO,
                                                                      TELEFONECONTATO,
                                                                      DATACONTATO,
                                                                      FREQUENTA
                                                                  FROM MENSAGEMENTRANTE");

                return (List<MensagemEntrante>)retorno;
            }
        }
    }
}