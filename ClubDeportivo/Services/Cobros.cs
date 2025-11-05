using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Services
{
    public class Cobros
    {
        DataTable tabla = new DataTable();

        public DataTable ListarVencimientos()
        {
            try
            {
                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();

                using var cmd = new MySqlCommand("sp_cuotas_pendientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_fecha", MySqlDbType.DateTime).Value = DateTime.Now;

                MySqlDataReader resultado = cmd.ExecuteReader();
                tabla.Load(resultado);

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar vencimientos: " + ex.Message);
            }
        }
        public DataTable ListarMediosPago()
        {
            DataTable tabla = new DataTable();

            try
            {
                tabla.Columns.Add("id", typeof(string));
                tabla.Columns.Add("medio", typeof(string));

                tabla.Rows.Add(1,"Efectivo");
                tabla.Rows.Add(2,"Virtual");
                tabla.Rows.Add(3,"Debito");
                tabla.Rows.Add(4,"Credito");

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar medios de pago: " + ex.Message);
            }
        }
        public void RegistrarPagoCuota(int idSocio, string periodo, string medio)
        {
            try
            {
                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();

                using var cmd = new MySqlCommand("sp_pago_cuota", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_socio", MySqlDbType.Int32).Value = idSocio;
                cmd.Parameters.Add("p_periodo", MySqlDbType.VarChar).Value = periodo;
                cmd.Parameters.Add("p_medio", MySqlDbType.VarChar).Value = medio;
                cmd.Parameters.Add("p_usuario", MySqlDbType.VarChar).Value = SesionUsuario.Usuario;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Pago registrado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public void RegistrarPagoActividad(int idNoSocio, DateTime fecha, double monto, string medio)
        {
            if (YaPagoActividad(idNoSocio, fecha)) return;           
            try
            {
                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();
                using var cmd = new MySqlCommand("sp_pago_actividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_no_socio", MySqlDbType.Int32).Value = idNoSocio;
                cmd.Parameters.Add("p_fecha", MySqlDbType.Date).Value = fecha;
                cmd.Parameters.Add("p_monto", MySqlDbType.Double).Value = monto;
                cmd.Parameters.Add("p_medio", MySqlDbType.VarChar).Value = medio;
                cmd.Parameters.Add("p_usuario", MySqlDbType.VarChar).Value = SesionUsuario.Usuario;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Pago registrado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        public bool YaPagoActividad(int idNoSocio, DateTime fecha)
        {
            try
            {
                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();
                using var cmd = new MySqlCommand("sp_actividad_search", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_no_socio", MySqlDbType.Int32).Value = idNoSocio;
                cmd.Parameters.Add("p_fecha", MySqlDbType.Date).Value = fecha.Date;

                object resultado = cmd.ExecuteScalar();
                int cantidad = Convert.ToInt32(resultado);

                if (cantidad > 0) {
                    MessageBox.Show("La persona ya tiene habilitada una actividad para este día");
                    return true;
                }
                else return false;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar pago: " + ex.Message);
            }
        }
    }
}
