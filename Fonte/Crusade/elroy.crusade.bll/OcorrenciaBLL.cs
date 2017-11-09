using Dapper;
using elroy.crusade.dominio;
using elroy.crusade.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.Infra
{
    public class OcorrenciaBLL
    {
        public OcorrenciaEntrante Grava(OcorrenciaEntrante ocorrencia)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();

            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(ocorrencia.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, ocorrencia.Id);
                else
                {
                    ocorrencia.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }

                if (acao == Acoes.Inserir.ToString())
                {
                    try
                    {
                        conn.Execute(@"INSERT INTO OCORRENCIAENTRANTE
                                                   ( ID, CODMENSAGEMENTRANTE,
                                                     CODRESPONSAVEL,
                                                     DESCRICAO,
                                                     DATA)                                                    
                                             VALUES
                                                   (@ID, @CODMENSAGEMENTRANTE,
                                                    @CODRESPONSAVEL,
                                                    @DESCRICAO,
                                                    @DATA)", ocorrencia);                      
                         
                         return ocorrencia;
                    }
                    catch (Exception e)
                    {
                        return new OcorrenciaEntrante();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE OCORRENCIAENTRANTE
                                           SET CODMENSAGEMENTRANTE = @CODMENSAGEMENTRANTE,
                                               CODRESPONSAVEL = @CODRESPONSAVEL,
                                               DESCRICAO = @DESCRICAO,
                                               DATA = @DATA
                                         WHERE id = @id", ocorrencia);

                        return conn.QueryFirst<OcorrenciaEntrante>(@"SELECT ID,
                                                                             CODMENSAGEMENTRANTE,
                                                                             CODRESPONSAVEL,
                                                                             DESCRICAO,
                                                                             DATA
                                                                        FROM OCORRENCIAENTRANTE
                                                                  where id = @id", new { id = ocorrencia.Id });                        
                    }
                    catch (Exception e)
                    {
                        return new OcorrenciaEntrante();
                        throw new Exception(e.Message);

                    }
            }
        }

        public OcorrenciaEntrante Busca(String id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<OcorrenciaEntrante>(@"SELECT ID,
                                                                        CODMENSAGEMENTRANTE,
                                                                        CODRESPONSAVEL,
                                                                        DESCRICAO,
                                                                        DATA
                                                                FROM OCORRENCIAENTRANTE", new { Id = id });


                }
                catch (Exception)
                {

                    return new OcorrenciaEntrante();
                }
            }
        }

        public bool Deleta(OcorrenciaEntrante ocorrencia)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<OcorrenciaEntrante>(@"DELETE FROM OCORRENCIAENTRANTE                                                         
                                                        WHERE ID = @id", ocorrencia);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<OcorrenciaEntrante> ListaOcorrencia()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<OcorrenciaEntrante>(@"SELECT ID,
                                                                      CODMENSAGEMENTRANTE,
                                                                      CODRESPONSAVEL,
                                                                      DESCRICAO,
                                                                      DATA
                                                                FROM OCORRENCIAENTRANTE");

                return (List<OcorrenciaEntrante>)retorno;
            }
        }
    }
}