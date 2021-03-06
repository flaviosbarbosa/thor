﻿using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class TipoMensagemBLL
    {
        public TipoMensagem Grava(TipoMensagem tipoMensagem)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (tipoMensagem.id == 0)
                {
                    try
                    {
                        conn.Execute(@"INSERT INTO TIPOMENSAGEM
                                               (TIPO,
                                               DESCRICAO)
                                         VALUES
                                               (
                                               @TIPO,
                                               @DESCRICAO)", tipoMensagem);

                        return conn.QueryFirst<TipoMensagem>(@"SELECT ID,
                                                                      TIPO,
                                                                      DESCRICAO
                                                                  FROM TIPOMENSAGEM", tipoMensagem);
                    }
                    catch (Exception e)
                    {
                        return new TipoMensagem();
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
                    catch (Exception e)
                    {
                        return new TipoMensagem();
                    }
            }
        }

        public TipoMensagem BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<TipoMensagem>(@"SELECT ID,
                                                                  TIPO,
                                                                  DESCRICAO
                                                              FROM TIPOMENSAGEM", new { Id = id });


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