using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubDeportivo.Config;

namespace ClubDeportivo.Services
{
    public class Cobros
    {
        public DataTable ListarCuotasPorPagar()
        {
            DataTable tabla = new DataTable();
            try
            {
                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();

                using var cmd = new MySqlCommand("sp_cuotas_pendientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_fecha", MySqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("p_incluir_por_vencer", MySqlDbType.Bit).Value = true;

                MySqlDataReader resultado = cmd.ExecuteReader();
                tabla.Load(resultado);

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar vencimientos: " + ex.Message);
            }
        }
        public DataTable ListarCuotasVencidas()
        {
            DataTable tabla = new DataTable();
            try
            {
                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();

                using var cmd = new MySqlCommand("sp_cuotas_pendientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_fecha", MySqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("p_incluir_por_vencer", MySqlDbType.Bit).Value = false;

                MySqlDataReader resultado = cmd.ExecuteReader();
                tabla.Load(resultado);

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar vencimientos: " + ex.Message);
            }
        }


        public DataTable ListarVencimientosPorFecha(DateTime fecha)
        {
            DataTable tablaVencimientos = new DataTable();
            try
            {
                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();

                using var cmd = new MySqlCommand("sp_cuotas_pendientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                
                // Usamos la 'fecha' recibida como parámetro en lugar de DateTime.Now
                cmd.Parameters.Add("p_fecha", MySqlDbType.DateTime).Value = fecha;

                cmd.Parameters.Add("p_incluir_por_vencer", MySqlDbType.Bit).Value = true;

                MySqlDataReader resultado = cmd.ExecuteReader();
                tablaVencimientos.Load(resultado);

                return tablaVencimientos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar vencimientos por fecha: " + ex.Message);
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
        public bool RegistrarPagoCuota(int idSocio, string periodo, string medio)
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

                MessageBox.Show("Pago registrado correctamente",
                               "Éxito",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar pago: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
        }

        public bool RegistrarPagoActividad(int idNoSocio, DateTime fecha, double monto, string medio)
        {
            if (YaPagoActividad(idNoSocio, fecha)) return false;           
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

                MessageBox.Show("Pago de actividad registrado correctamente",
                               "Éxito",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar pago: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
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
                    MessageBox.Show("La persona ya tiene habilitada una actividad para este día",
                               "Validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                    return true;
                }
                else return false;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar pago: " + ex.Message);
            }
        }
        public int GenerarCuotas(string periodo, double monto)
        {
            try
            {
                using var cn = Conexion.getInstancia().CrearConcexion();
                cn.Open();

                using var cmd = new MySqlCommand("sp_generar_cuotas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_periodo", MySqlDbType.VarChar).Value = periodo;
                cmd.Parameters.Add("p_dia_vencimiento", MySqlDbType.Int32).Value = ValoresCuotas.DiaVencimiento;
                cmd.Parameters.Add("p_monto", MySqlDbType.Double).Value = monto != ValoresCuotas.MontoCuota ? monto : ValoresCuotas.MontoCuota;
                cmd.Parameters.Add("p_usuario", MySqlDbType.VarChar).Value = SesionUsuario.Usuario;

                object? result = cmd.ExecuteScalar(); // obtiene la primera celda del primer SELECT
                int cuotasGeneradas = Convert.ToInt32(result);

                return cuotasGeneradas; 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar cuota: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return -1;
            }
        }
    }
}
