using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.Infra
{
    public class BeneficiarioBLL
    {
        public Beneficiario Grava(Beneficiario beneficiario)
        {
            // parei ontem criando a conexao com o banco
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (beneficiario.Id == 0)
                {
                    try
                    {
                        conn.Execute(@"INSERT INTO BENEFICIARIO                                               
                                         ( NOME,
                                          EMAIL,
                                          TELEFONE,
                                          DATACADASTRO,
                                          TIPOBENEFICIARIO,
                                          ATIVO,
                                          TIPOPESSOA,
                                          DOCUMENTOI,
                                          DOCUMENTOII,
                                          ENDERECO,
                                          NUMERO,
                                          BAIRRO,
                                          CIDADE,
                                          UF,
                                          CELULAR)
                                         VALUES                                               
                                          (@NOME,
                                          @EMAIL,
                                          @TELEFONE,
                                          @DATACADASTRO,
                                          @TIPOBENEFICIARIO,
                                          @ATIVO,
                                          @TIPOPESSOA,
                                          @DOCUMENTOI,
                                          @DOCUMENTOII,
                                          @ENDERECO,
                                          @NUMERO,
                                          @BAIRRO,
                                          @CIDADE,
                                          @UF,
                                          @CELULAR)", beneficiario);

                        return conn.QueryFirst<Beneficiario>(@"SELECT ID,
                                                                      NOME,
                                                                      EMAIL,
                                                                      TELEFONE,
                                                                      DATACADASTRO,
                                                                      TIPOBENEFICIARIO,
                                                                      ATIVO,
                                                                      TIPOPESSOA,
                                                                      DOCUMENTOI,
                                                                      DOCUMENTOII,
                                                                      ENDERECO,
                                                                      NUMERO,
                                                                      BAIRRO,
                                                                      CIDADE,
                                                                      UF,
                                                                      CELULAR
                                                                  FROM BENEFICIARIO", beneficiario);
                    }
                    catch (Exception e)
                    {
                        return new Beneficiario();
                        throw new Exception(e.Message);
                        
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE BENEFICIARIO
                                           SET 
                                              NOME =@NOME,
                                              EMAIL = @EMAIL,
                                              TELEFONE = @TELEFONE,
                                              DATACADASTRO = @DATACADASTRO,
                                              TIPOBENEFICIARIO = @TIPOBENEFICIARIO,
                                              ATIVO = @ATIVO,
                                              TIPOPESSOA = @TIPOPESSOA,
                                              DOCUMENTOI = @DOCUMENTOI,
                                              DOCUMENTOII = @DOCUMENTOII,
                                              ENDERECO = @ENDERECO,
                                              NUMERO = @NUMERO,
                                              BAIRRO = @BAIRRO,
                                              CIDADE = @CIDADE,
                                              UF = @UF,
                                              CELULAR = @CELULAR
                                             WHERE ID = @ID", new { Id = beneficiario.Id});

                        return conn.QueryFirst<Beneficiario>(@"SELECT ID,
                                                                      NOME,
                                                                      EMAIL,
                                                                      TELEFONE,
                                                                      DATACADASTRO,
                                                                      TIPOBENEFICIARIO,
                                                                      ATIVO,
                                                                      TIPOPESSOA,
                                                                      DOCUMENTOI,
                                                                      DOCUMENTOII,
                                                                      ENDERECO,
                                                                      NUMERO,
                                                                      BAIRRO,
                                                                      CIDADE,
                                                                      UF,
                                                                      CELULAR
                                                                  FROM BENEFICIARIO", beneficiario);
                    }
                    catch (Exception)
                    {
                        return new Beneficiario();
                    }
            }
        }

        public Beneficiario BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Beneficiario>(@"SELECT ID,
                                                                NOME,
                                                                EMAIL,
                                                                TELEFONE,
                                                                DATACADASTRO,
                                                                TIPOBENEFICIARIO,
                                                                ATIVO,
                                                                TIPOPESSOA,
                                                                DOCUMENTOI,
                                                                DOCUMENTOII,
                                                                ENDERECO,
                                                                NUMERO,
                                                                BAIRRO,
                                                                CIDADE,
                                                                UF,
                                                                CELULAR
                                                            FROM BENEFICIARIO
                                                           WHERE ID = @ID", new { Id = id });
                }
                catch (Exception e )
                {
                    return new Beneficiario();
                    throw new Exception(e.Message);
                }
            }
        }

        public bool Deleta(Beneficiario beneficiario)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.Execute(@"DELETE FROM Beneficiario                                                         
                                                        WHERE ID = @id", beneficiario);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw new Exception(e.Message);
                }
            }
        }

        public List<Beneficiario> ListaBeneficiario()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Beneficiario>(@"SELECT ID,
                                                                  NOME,
                                                                  EMAIL,
                                                                  TELEFONE,
                                                                  DATACADASTRO,
                                                                  TIPOBENEFICIARIO,
                                                                  ATIVO,
                                                                  TIPOPESSOA,
                                                                  DOCUMENTOI,
                                                                  DOCUMENTOII,
                                                                  ENDERECO,
                                                                  NUMERO,
                                                                  BAIRRO,
                                                                  CIDADE,
                                                                  UF,
                                                                  CELULAR
                                                              FROM BENEFICIARIO ");
                return (List<Beneficiario>)retorno;
            }
        }
    }
}
