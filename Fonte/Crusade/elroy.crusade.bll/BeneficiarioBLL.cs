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
    public class BeneficiarioBLL
    {
        public Beneficiario Grava(Beneficiario beneficiario)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();

            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(beneficiario.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, beneficiario.Id);
                else
                {
                    beneficiario.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }

                if (acao == Acoes.Inserir.ToString())
                {
                    try
                    {
                       conn.Execute(@"INSERT INTO BENEFICIARIO                                               
                                         ( ID,
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
                                          CELULAR,
                                          CODPROFISSAO)                                   
                                         VALUES                                               
                                          (@ID, @NOME,
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
                                          @CELULAR,
                                          @CODPROFISSAO)", beneficiario);

                        return beneficiario;                            
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
                        conn.Execute(@"UPDATE BENEFICIARIO
                                           SET 
                                              NOME = @NOME,
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
                                              CELULAR = @CELULAR,
                                              CODPROFISSAO = @CODPROFISSAO
                                             WHERE ID = @ID", beneficiario);

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
                                                                      CELULAR, CODPROFISSAO
                                                                    FROM BENEFICIARIO
                                                                   WHERE ID = @ID", new { Id = beneficiario.Id });
                    }
                    catch (Exception e)
                    {
                        return new Beneficiario();
                        throw new Exception(e.Message);
                    }
            }
        }

        public Beneficiario Busca(String id)
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
                                                                CELULAR, CODPROFISSAO
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
                                                                  CELULAR, CODPROFISSAO
                                                              FROM BENEFICIARIO ");
                return (List<Beneficiario>)retorno;
            }
        }
    }
}
