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
    public class IgrejaBLL
    {
        public Igreja Grava(Igreja Igreja)
        {
            // parei ontem criando a conexao com o banco
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (Igreja.id == 0)
                {
                    //try
                    //{
                    //conn.Query(@"INSERT INTO [dbo].[Igreja]
                    conn.Execute(@"INSERT INTO IGREJA
	    	                                    (
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
                                                @RESPONSAVEL)", Igreja);

                    return conn.QueryFirst<Igreja>(@"SELECT * FROM Igreja", Igreja);
                    //}
                    //catch (Exception e)
                    //{
                    //    return new Igreja();
                    //}
                }
                else
                    //try
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
                                        WHERE id = @id", Igreja);

                        return conn.QueryFirst<Igreja>(@"SELECT * FROM Igreja", Igreja);
                    }
                    //catch (Exception)
                    //{
                    //    return new Igreja();
                    //}
            }
        }

        public Igreja BuscaPorCodigo(int id)
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