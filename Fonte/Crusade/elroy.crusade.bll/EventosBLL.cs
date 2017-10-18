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
    public class EventosBLL
    {
        public Eventos Grava(Eventos eventos)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (eventos.id == 0)
                {
                    try
                    {                        
                        conn.Execute(@"INSERT INTO EVENTOS
                                        (
                                              CODMINISTERIO,
                                              TITULO,
                                              DESCRICAO,
                                              DATA,
                                              LOCAL,
                                              HORARIO,
                                              BANNER,
                                              PRIVADO,
                                              PASTORPRESENTE)
                                             VALUES
                                        (
                                              @CODMINISTERIO,
                                              @TITULO,
                                              @DESCRICAO,
                                              @DATA,
                                              @LOCAL,
                                              @HORARIO,
                                              @BANNER,
                                              @PRIVADO,
                                              @PASTORPRESENTE)", eventos);

                    return conn.QueryFirst<Eventos>(@"SELECT ID,
                                                        CODMINISTERIO,
                                                        TITULO,
                                                        DESCRICAO,
                                                        DATA,
                                                        LOCAL,
                                                        HORARIO,
                                                        BANNER,
                                                        PRIVADO,
                                                        PASTORPRESENTE
                                                    FROM EVENTOS", eventos);
                    }
                    catch (Exception e)
                    {
                        return new Eventos();
                    }
                }
                else
                try
                {
                    var retorno =
                    conn.Execute(@"UPDATE EVENTOS
                                       SET CODMINISTERIO = @CODMINISTERIO,
                                          TITULO = @TITULO,
                                          DESCRICAO = @DESCRICAO,
                                          DATA = @DATA,
                                          LOCAL = @LOCAL,
                                          HORARIO = @HORARIO,
                                          BANNER = @BANNER,
                                          PRIVADO = @PRIVADO,
                                          PASTORPRESENTE = @PASTORPRESENTE
                                     WHERE id = @id", eventos);

                    return conn.QueryFirst<Eventos>(@"SELECT ID,
                                                              CODMINISTERIO,
                                                              TITULO,
                                                              DESCRICAO,
                                                              DATA,
                                                              LOCAL,
                                                              HORARIO,
                                                              BANNER,
                                                              PRIVADO,
                                                              PASTORPRESENTE
                                                          FROM EVENTOS", eventos);
                }
                catch (Exception)
                {
                    return new Eventos();
                }
            }
        }

        public Eventos BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Eventos>(@"SELECT ID,
                                                              CODMINISTERIO,
                                                              TITULO,
                                                              DESCRICAO,
                                                              DATA,
                                                              LOCAL,
                                                              HORARIO,
                                                              BANNER,
                                                              PRIVADO,
                                                              PASTORPRESENTE
                                                          FROM EVENTOS", new { Id = id });


                }
                catch (Exception)
                {

                    return new Eventos();
                }
            }
        }

        public bool Deleta(Eventos eventos)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Eventos>(@"DELETE FROM Eventos                                                         
                                                        WHERE ID = @id", eventos);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<Eventos> ListaEventos()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Eventos>(@"SELECT ID,
                                                          CODMINISTERIO,
                                                          TITULO,
                                                          DESCRICAO,
                                                          DATA,
                                                          LOCAL,
                                                          HORARIO,
                                                          BANNER,
                                                          PRIVADO,
                                                          PASTORPRESENTE
                                                      FROM EVENTOS");

                return (List<Eventos>)retorno;
            }
        }
    }
}