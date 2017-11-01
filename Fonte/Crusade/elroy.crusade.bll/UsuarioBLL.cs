using System;
using elroy.crusade.dominio;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

namespace elroy.crusade.Infra
{
    public class UsuarioBLL
    {
        public Usuario Grava(Usuario usuario)
        {           
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (usuario.Id == 0)
                {
                    try
                    {        
                        usuario.Id = (int)conn.ExecuteScalar(@"INSERT INTO USUARIO
                                       (
                                       NOME,
                                       LOGIN,
                                       SENHA,
                                       ATIVO,
                                       CPF,
                                       EMAIL)
                                        OUTPUT INSERTED.id
                                 VALUES
                                       (
                                       @NOME,
                                       @LOGIN,
                                       @SENHA,
                                       @ATIVO,
                                       @CPF,
                                       @EMAIL)", usuario);

                    return usuario;
                        //TODO: Verificar porque está retornando 'S' ao consultar e não 'SIM'
                    }
                    catch (Exception e)
                    {
                        return new Usuario();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE USUARIO
                                          SET 
		                                      NOME = @nome,
                                              LOGIN = @login,
                                              SENHA = @SENHA,
		                                      ATIVO = @ATIVO,
                                              CPF = @CPF,
                                              EMAIL = @EMAIL
                                         WHERE id = @id", usuario);                        
                        
                        return conn.QueryFirst<Usuario>(@"SELECT * FROM USUARIO 
                                                             where id = @id", usuario);
                    }
                    catch (Exception)
                    {
                        return new Usuario();
                    }
            }
        }

        public Usuario BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Usuario>(@"SELECT ID, NOME, LOGIN, SENHA, ATIVO, CPF, EMAIL
                                                        FROM USUARIO
                                                       WHERE ID = @ID", new { Id = id });
                }                                
                catch (Exception e)
                {
                    return new Usuario();
                    throw new Exception(e.Message);
                }
            }
        }

        public bool Deleta(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Usuario>(@"DELETE FROM USUARIO                                                         
                                                        WHERE ID = @id", usuario);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<Usuario> ListaUsuario()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Usuario>(@"SELECT * FROM USUARIO");

                return (List<Usuario>)retorno;
            }
        }
    }
}
