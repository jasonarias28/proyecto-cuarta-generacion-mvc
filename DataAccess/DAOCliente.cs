using DataAccess.Contract;
using DataAccess.Repository;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAOCliente : OracleConexion, IOperacionesCRUD<ClienteBO>
    {
        public string Actualizar(ClienteBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection con = new OracleConnection(strOracle))
                {
                    con.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_USUARIO", con))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure; //POR SER PROCEDIMIENTO ALMACENADO PERO TAMBIEN SE PUEDEN OTRAS OPCIONES
                        command.Parameters.Add(new OracleParameter("V_USER_ID", OracleType.VarChar)).Value = dto.USER_ID;
                        command.Parameters.Add(new OracleParameter("V_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("V_APELLIDO", OracleType.VarChar)).Value = dto.APELLIDO;
                        command.Parameters.Add(new OracleParameter("V_CORREO", OracleType.VarChar)).Value = dto.CORREO;
                        command.Parameters.Add(new OracleParameter("V_TELEFONO", OracleType.Number)).Value = dto.TELEFONO;
                        command.Parameters.Add(new OracleParameter("V_RESULT", OracleType.VarChar, 50)).Direction = System.Data.ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        result = command.Parameters["V_RESULT"].Value.ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public string Eliminar(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection con = new OracleConnection(strOracle))
                {
                    con.Open();
                    using (OracleCommand command = new OracleCommand("SP_DELETE_USUARIO", con))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("V_USER_ID", OracleType.VarChar)).Value = dto;
                        command.Parameters.Add(new OracleParameter("V_RESULT", OracleType.VarChar, 50)).Direction = System.Data.ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        result = command.Parameters["V_RESULT"].Value.ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public string Insertar(ClienteBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection con = new OracleConnection(strOracle))
                {
                    con.Open();
                    using (OracleCommand command = new OracleCommand("SP_INSERT_USUARIO", con))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("V_USER_ID", OracleType.VarChar)).Value = dto.USER_ID;
                        command.Parameters.Add(new OracleParameter("V_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("V_APELLIDO", OracleType.VarChar)).Value = dto.APELLIDO;
                        command.Parameters.Add(new OracleParameter("V_CORREO", OracleType.VarChar)).Value = dto.CORREO;
                        command.Parameters.Add(new OracleParameter("V_TELEFONO", OracleType.Number)).Value = dto.TELEFONO;
                        command.Parameters.Add(new OracleParameter("V_RESULT", OracleType.VarChar, 50)).Direction = System.Data.ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        result = command.Parameters["V_RESULT"].Value.ToString();
                    }
                    con.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ClienteBO> Listar()
        {
            List<ClienteBO> list = new List<ClienteBO>();
            ClienteBO dto = null;
            try
            {
                using (OracleConnection con = new OracleConnection(strOracle))
                {
                    con.Open();
                    using (OracleCommand command = new OracleCommand("SP_SELECT_USUARIOS", con))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction = System.Data.ParameterDirection.Output;
                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                dto = new ClienteBO();
                                dto.USER_ID = dr["USER_ID"].ToString();
                                dto.NOMBRE = dr["NOMBRE"].ToString();
                                dto.APELLIDO = dr["APELLIDO"].ToString();
                                dto.CORREO = dr["CORREO"].ToString();
                                dto.TELEFONO = Convert.ToInt32(dr["TELEFONO"]);
                                list.Add(dto);
                            }
                        }
                    }    
                }
            }
            catch (Exception ex)
            {
                new Exception("Error en el metodo Listar: " + ex.Message);
            }
            return list;
        }
    }
}
