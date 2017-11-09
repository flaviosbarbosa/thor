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
    public class IgrejaBLL
    {     
        
        public Igreja Grava(Igreja igreja)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();
            
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(igreja.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, igreja.Id);                
                else
                {
                    igreja.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }


                if (acao == Acoes.Inserir.ToString())
                {
                    try
                    {                        
                    conn.Execute(@"INSERT INTO IGREJA
	    	                                    (
                                                ID,
                                                RAZAOSOCIAL,
                                                NOMEFANTASIA,
                                                CNPJ,
                                                ENDERECO,
                                                BAIRRO,
                                                CIDADE,
                                                NUMERO,
                                                UF,
                                                CEP,
                                                TELEFONE,
                                                CELULAR,
                                                RESPONSAVEL)
                                            VALUES
                                                (   
                                                @ID,
                                                @RAZAOSOCIAL,
                                                @NOMEFANTASIA,
                                                @CNPJ,
                                                @ENDERECO,
                                                @BAIRRO,
                                                @CIDADE,
                                                @NUMERO,
                                                @UF,
                                                @CEP,
                                                @TELEFONE,
                                                @CELULAR,
                                                @RESPONSAVEL)", igreja);                  
                    return igreja;                        
                    }
                    catch (Exception e)
                    {
                        return new Igreja();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE IGREJA
                                        SET 
                                            RAZAOSOCIAL = @RAZAOSOCIAL,
                                            NOMEFANTASIA = @NOMEFANTASIA,
                                            CNPJ = @CNPJ,
                                            ENDERECO = @ENDERECO,
                                            BAIRRO = @BAIRRO,
                                            CIDADE = @CIDADE,
                                            NUMERO = @NUMERO,
                                            UF = @UF,
                                            CEP = @CEP,
                                            TELEFONE = @TELEFONE,
                                            CELULAR = @CELULAR,
                                            RESPONSAVEL = @RESPONSAVEL
                                        WHERE id = @id", igreja);

                        return conn.QueryFirst<Igreja>(@"SELECT * FROM Igreja", igreja);
                    }
                    catch (Exception e)
                    {
                        return new Igreja();
                        throw new Exception(e.Message);
                    }
            }
        }

        public Igreja Busca(string id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Igreja>(@"SELECT *
                                                        FROM Igreja
                                                        WHERE ID = @ID", new { Id = id });


                }
                catch (Exception)
                {

                    return new Igreja();
                }
            }
        }

        public bool Deleta(Igreja Igreja)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Igreja>(@"DELETE FROM Igreja                                                         
                                                        WHERE ID = @id", Igreja);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<Igreja> ListaIgreja()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Igreja>(@"SELECT * FROM Igreja");

                return (List<Igreja>)retorno;
            }
        }
    }
}