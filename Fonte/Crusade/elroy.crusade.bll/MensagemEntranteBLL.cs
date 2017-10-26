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
                                           (CODTIPOMENSAGEM
                                           ,CODRESPONSAVEL
                                           ,CODSOLICITANTE
                                           ,NOMESOLICITANTE
                                           ,ASSUNTO
                                           ,MENSAGEM
                                           ,EMAILCONTATO
                                           ,PERMITERETORNO
                                           ,TELEFONECONTATO
                                           ,DATACONTATO
                                           ,FREQUENTA
                                           ,SITUACAO)
                                     VALUES
                                           (
                                           @CODTIPOMENSAGEM
                                           ,@CODRESPONSAVEL
                                           ,@CODSOLICITANTE
                                           ,@NOMESOLICITANTE
                                           ,@ASSUNTO
                                           ,@MENSAGEM
                                           ,@EMAILCONTATO
                                           ,@PERMITERETORNO
                                           ,@TELEFONECONTATO
                                           ,@DATACONTATO
                                           ,@FREQUENTA
                                           ,@SITUACAO)", mensagemEntrante);

                        return conn.QueryFirst<MensagemEntrante>(@"SELECT ID
                                                                        ,CODTIPOMENSAGEM
                                                                        ,CODRESPONSAVEL
                                                                        ,CODSOLICITANTE
                                                                        ,NOMESOLICITANTE
                                                                        ,ASSUNTO
                                                                        ,MENSAGEM
                                                                        ,EMAILCONTATO
                                                                        ,PERMITERETORNO
                                                                        ,TELEFONECONTATO
                                                                        ,DATACONTATO
                                                                        ,FREQUENTA
                                                                        ,SITUACAO
                                                                      FROM MENSAGEMENTRANTE", mensagemEntrante);
                    }
                    catch (Exception e)
                    {
                        return new MensagemEntrante();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE MENSAGEMENTRANTE
                                           SET CODTIPOMENSAGEM = @CODTIPOMENSAGEM
                                              ,CODRESPONSAVEL = @CODRESPONSAVEL
                                              ,CODSOLICITANTE = @CODSOLICITANTE
                                              ,NOMESOLICITANTE = @NOMESOLICITANTE
                                              ,ASSUNTO = @ASSUNTO
                                              ,MENSAGEM = @MENSAGEM
                                              ,EMAILCONTATO = @EMAILCONTATO
                                              ,PERMITERETORNO = @PERMITERETORNO
                                              ,TELEFONECONTATO = @TELEFONECONTATO
                                              ,DATACONTATO = @DATACONTATO
                                              ,FREQUENTA = @FREQUENTA
                                              ,SITUACAO = @SITUACAO
                                         WHERE id = @id", mensagemEntrante);

                        return conn.QueryFirst<MensagemEntrante>(@"SELECT ID
                                                                        ,CODTIPOMENSAGEM
                                                                        ,CODRESPONSAVEL
                                                                        ,CODSOLICITANTE
                                                                        ,NOMESOLICITANTE
                                                                        ,ASSUNTO
                                                                        ,MENSAGEM
                                                                        ,EMAILCONTATO
                                                                        ,PERMITERETORNO
                                                                        ,TELEFONECONTATO
                                                                        ,DATACONTATO
                                                                        ,FREQUENTA
                                                                        ,SITUACAO
                                                                      FROM MENSAGEMENTRANTE", mensagemEntrante);
                    }
                    catch (Exception e)
                    {
                        return new MensagemEntrante();
                        throw new Exception(e.Message);
                    }
            }
        }

        public MensagemEntrante BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<MensagemEntrante>(@"SELECT ID
                                                                        ,CODTIPOMENSAGEM
                                                                        ,CODRESPONSAVEL
                                                                        ,CODSOLICITANTE
                                                                        ,NOMESOLICITANTE
                                                                        ,ASSUNTO
                                                                        ,MENSAGEM
                                                                        ,EMAILCONTATO
                                                                        ,PERMITERETORNO
                                                                        ,TELEFONECONTATO
                                                                        ,DATACONTATO
                                                                        ,FREQUENTA
                                                                        ,SITUACAO
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
                var retorno = conn.Query<MensagemEntrante>(@"SELECT  ID
                                                                        ,CODTIPOMENSAGEM
                                                                        ,CODRESPONSAVEL
                                                                        ,CODSOLICITANTE
                                                                        ,NOMESOLICITANTE
                                                                        ,ASSUNTO
                                                                        ,MENSAGEM
                                                                        ,EMAILCONTATO
                                                                        ,PERMITERETORNO
                                                                        ,TELEFONECONTATO
                                                                        ,DATACONTATO
                                                                        ,FREQUENTA
                                                                        ,SITUACAO
                                                                  FROM MENSAGEMENTRANTE");

                return (List<MensagemEntrante>)retorno;
            }
        }
    }
}