using Dapper;
using elroy.crusade.dominio;
using elroy.crusade.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class MensagemSainteBLL
    {
        public MensagemSainte Grava(MensagemSainte mensagemSainte)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();

            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(mensagemSainte.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, mensagemSainte.Id);
                else
                {
                    mensagemSainte.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }

                if (acao == Acoes.Inserir.ToString())

                {
                    try
                    {
                        conn.Execute(@"INSERT INTO MENSAGEMSAINTE
                                        (ID,CODMINISTERIO,
                                        CODTIPOMENSAGEM,
                                        MENSAGEM,
                                        DATAENVIO,
                                        CODMENSAGEMENTRANTE)                                    
                                    VALUES
                                        (@ID, @CODMINISTERIO,
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

                        return conn.QueryFirst<MensagemSainte>(@"SELECT ID,
                                                                        CODMINISTERIO,
                                                                        CODTIPOMENSAGEM,
                                                                        MENSAGEM,
                                                                        DATAENVIO,
                                                                        CODMENSAGEMENTRANTE  
                                                                   FROM MENSAGEMSAINTE
                                                                  where id = @id", new { id = mensagemSainte.Id });
                        //WHERE ID = @ID", mensagemSainte.Id);
                    }
                    catch (Exception e)
                    {
                        return new MensagemSainte();
                        throw new Exception(e.Message);
                    }
            }
        }

        public MensagemSainte Busca(String id)
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
                                                                    FROM MENSAGEMSAINTE
                                                             where id = @id", new { Id = id });


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