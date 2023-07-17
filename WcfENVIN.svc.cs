using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SICCAWcfExt;
using static SICCATransversal.wsENVIN;

namespace SICCAWcf
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WcfENVIN" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WcfENVIN.svc o WcfENVIN.svc.cs en el Explorador de soluciones e inicie la depuración.
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class WcfENVIN : IWcfENVIN

    {
        #region funciones
        //getters: funciones bbdd DESTINO
       public Resultado_ENVIN_Pacientes_Ingresados get_wsENVIN_Web_Pacientes_Filtrado(String codigoPrograma, String id_ejecucion, DateTime fechaInicio, DateTime fechaFin, int logicalUnitID, int EstadoInforme, String nombre, String apellidos, String nhc)
        {
            Resultado_ENVIN_Pacientes_Ingresados result = new Resultado_ENVIN_Pacientes_Ingresados();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("fechaInicio", fechaInicio.ToString()));
            lista.Add(new SICCA_Log.parametros("fechaFin", fechaFin.ToString()));
            lista.Add(new SICCA_Log.parametros("logicalUnitID", logicalUnitID.ToString()));
            lista.Add(new SICCA_Log.parametros("EstadoInforme", EstadoInforme.ToString()));
            lista.Add(new SICCA_Log.parametros("nombre", nombre));
            lista.Add(new SICCA_Log.parametros("apellidos", apellidos));
            lista.Add(new SICCA_Log.parametros("nhc", nhc));
            #endregion

            SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Pacientes_Filtrado", lista, "----------------------------------INICIO----------------------------------------");

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                
                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Pacientes_Filtrado( fechaInicio,  fechaFin,  logicalUnitID,  EstadoInforme,  nombre,  apellidos,  nhc);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Pacientes_Filtrado", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Pacientes_Filtrado", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Pacientes_Filtrado", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Pacientes_Filtrado", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }//fin get_wsENVIN_Web_Pacientes_Filtrado

        public Resultado_ENVIN_Paciente get_wsENVIN_Web_Pacientes(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_ENVIN_Paciente result = new Resultado_ENVIN_Paciente();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Pacientes", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Pacientes(wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Pacientes", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Pacientes", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Pacientes", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Pacientes", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        public Resultado_TiposEstadoInforme get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID)
        {
            Resultado_TiposEstadoInforme result = new Resultado_TiposEstadoInforme();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID", wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme(wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        #region Funciones FichaIngreso
        #region Funciones FichaIngreso obtener datos

       

        public Resultado_FichaIngresoDatosAdmin get_wsENVIN_Web_FichaIngreso_DatosAdministrativos(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_FichaIngresoDatosAdmin result = new Resultado_FichaIngresoDatosAdmin();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_DatosAdministrativos", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_FichaIngreso_DatosAdministrativos(wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_DatosAdministrativos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_DatosAdministrativos", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_DatosAdministrativos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_DatosAdministrativos", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_FichaIngresoGeneral get_wsENVIN_Web_FichaIngreso_General(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_FichaIngresoGeneral result = new Resultado_FichaIngresoGeneral();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_General", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_FichaIngreso_General(wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_General", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_General", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_General", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_General", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_FichaIngresoComorbilidadesPrevias get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_FichaIngresoComorbilidadesPrevias result = new Resultado_FichaIngresoComorbilidadesPrevias();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_FichaIngresoFactoresDeRiesgo get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_FichaIngresoFactoresDeRiesgo result = new Resultado_FichaIngresoFactoresDeRiesgo();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_FichaIngresoColonizacionInfeccion get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_FichaIngresoColonizacionInfeccion result = new Resultado_FichaIngresoColonizacionInfeccion();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }
        #endregion


        #region Funciones FichaIngreso maestros

        public Resultado_FichaIngresoMaestroDiagnostico get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID)
        {
            Resultado_FichaIngresoMaestroDiagnostico result = new Resultado_FichaIngresoMaestroDiagnostico();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID", wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN(wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        public Resultado_FichaIngresoMaestroOrigenPaciente get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID)
        {
            Resultado_FichaIngresoMaestroOrigenPaciente result = new Resultado_FichaIngresoMaestroOrigenPaciente();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID", wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente(wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }



        public Resultado_FichaIngresoMaestroTipoAdmision get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID)
        {
            Resultado_FichaIngresoMaestroTipoAdmision result = new Resultado_FichaIngresoMaestroTipoAdmision();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID", wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision(wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_FichaIngresoMaestroCirugiaPrevia get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID)
        {
            Resultado_FichaIngresoMaestroCirugiaPrevia result = new Resultado_FichaIngresoMaestroCirugiaPrevia();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID", wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENget_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPreviaVIN_Web_Maestro_FichaIngreso_TipoDeAdmision", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia(wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        public Resultado_FichaIngresoMaestroColonizacionInfeccion get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID)
        {
            Resultado_FichaIngresoMaestroColonizacionInfeccion result = new Resultado_FichaIngresoMaestroColonizacionInfeccion();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID", wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion(wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_FichaIngresoMaestroColonizacionInfeccionCuando get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID)
        {
            Resultado_FichaIngresoMaestroColonizacionInfeccionCuando result = new Resultado_FichaIngresoMaestroColonizacionInfeccionCuando();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID", wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando(wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        public Resultado_FichaIngresoMaestroColonizacionInfeccionLocalizacion get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID)
        {
            Resultado_FichaIngresoMaestroColonizacionInfeccionLocalizacion result = new Resultado_FichaIngresoMaestroColonizacionInfeccionLocalizacion();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID", wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion(wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_FichaIngresoMaestroColonizacionInfeccionTipo get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID)
        {
            Resultado_FichaIngresoMaestroColonizacionInfeccionTipo result = new Resultado_FichaIngresoMaestroColonizacionInfeccionTipo();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID", wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo(wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        #endregion

        #endregion

        #region Factores de Riesgo Individual

        #region funciones factores de riesgo individual obtener datos

        public Resultado_FactoresRiesgoIndividual get_wsENVIN_Web_FactoresRiesgoIndividual(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_FactoresRiesgoIndividual result = new Resultado_FactoresRiesgoIndividual();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresRiesgoIndividual", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_FactoresRiesgoIndividual(wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresRiesgoIndividual", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresRiesgoIndividual", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresRiesgoIndividual", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresRiesgoIndividual", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        #endregion


        #region funciones factores de riesgo individual maestros

        public Resultado_BloquesControles get_wsENVIN_Web_Bloques_Controles(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Bloques_ID , int wsENVIN_Web_Controles_Grupos_ID )
        {
            Resultado_BloquesControles result = new Resultado_BloquesControles();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Bloques_ID", wsENVIN_Web_Bloques_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Controles_Grupos_ID", wsENVIN_Web_Controles_Grupos_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Bloques_Controles", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Bloques_Controles(wsENVIN_Web_Bloques_ID,wsENVIN_Web_Controles_Grupos_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Bloques_Controles", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Bloques_Controles", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Bloques_Controles", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Bloques_Controles", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        #endregion

        #endregion

        #region Antibioticos 

        #region antibioticos obtener datos

        public Resultado_Antibioticos get_wsENVIN_Web_Antibioticos(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_Antibioticos result = new Resultado_Antibioticos();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Antibioticos", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Antibioticos(wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Antibioticos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Antibioticos", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Antibioticos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Antibioticos", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        #endregion

        #region antibioticos maestros

        public Resultado_MaestroAntibioticosCambioDeAntibiotico get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID)
        {
            Resultado_MaestroAntibioticosCambioDeAntibiotico result = new Resultado_MaestroAntibioticosCambioDeAntibiotico();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID", wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico(wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        public Resultado_MaestroAntibioticosConfirmacion get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID)
        {
            Resultado_MaestroAntibioticosConfirmacion result = new Resultado_MaestroAntibioticosConfirmacion();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID", wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion(wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        public Resultado_MaestroAntibioticosIndicacion get_wsENVIN_Web_Maestro_Antibioticos_Indicacion(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID)
        {
            Resultado_MaestroAntibioticosIndicacion result = new Resultado_MaestroAntibioticosIndicacion();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID", wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Indicacion", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Antibioticos_Indicacion(wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Indicacion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Indicacion", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Indicacion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Indicacion", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        public Resultado_MaestroAntibioticosMotivo get_wsENVIN_Web_Maestro_Antibioticos_Motivo(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Antibioticos_Motivo_ID)
        {
            Resultado_MaestroAntibioticosMotivo result = new Resultado_MaestroAntibioticosMotivo();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibioticos_Motivo_ID", wsENVIN_Web_Maestro_Antibioticos_Motivo_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Motivo", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Antibioticos_Motivo(wsENVIN_Web_Maestro_Antibioticos_Motivo_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Motivo", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Motivo", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Motivo", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_Motivo", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        public Resultado_MaestroAntibioticosMotivoDelCambio get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID)
        {
            Resultado_MaestroAntibioticosMotivoDelCambio result = new Resultado_MaestroAntibioticosMotivoDelCambio();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID", wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio(wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        #endregion


        #endregion

        #region Infecciones
        public Resultado_ENVINInfecciones get_wsENVIN_Web_Infecciones(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_ENVINInfecciones result = new Resultado_ENVINInfecciones();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Infecciones", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Infecciones(wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Infecciones", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Infecciones", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Infecciones", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Infecciones", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_DiagnosticoClinico get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico(String codigoPrograma, String id_ejecucion)
        {
            Resultado_ENVINMaestro_DiagnosticoClinico result = new Resultado_ENVINMaestro_DiagnosticoClinico();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico();

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_Localizacion get_wsENVIN_Web_Maestro_Infecciones_Localizacion(String codigoPrograma, String id_ejecucion)
        {
            Resultado_ENVINMaestro_Localizacion result = new Resultado_ENVINMaestro_Localizacion();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Localizacion", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Infecciones_Localizacion();

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Localizacion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Localizacion", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Localizacion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Localizacion", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_Muestra get_wsENVIN_Web_Maestro_Infecciones_Muestra(String codigoPrograma, String id_ejecucion)
        {
            Resultado_ENVINMaestro_Muestra result = new Resultado_ENVINMaestro_Muestra();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Muestra", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Infecciones_Muestra();

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Muestra", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Muestra", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Muestra", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Muestra", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_OrigenInfeccion get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion(String codigoPrograma, String id_ejecucion)
        {
            Resultado_ENVINMaestro_OrigenInfeccion result = new Resultado_ENVINMaestro_OrigenInfeccion();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion();

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_RespuestaInflamatoria get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria(String codigoPrograma, String id_ejecucion)
        {
            Resultado_ENVINMaestro_RespuestaInflamatoria result = new Resultado_ENVINMaestro_RespuestaInflamatoria();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria();

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_TipoCateter get_wsENVIN_Web_Maestro_Infecciones_TipoCateter(String codigoPrograma, String id_ejecucion)
        {
            Resultado_ENVINMaestro_TipoCateter result = new Resultado_ENVINMaestro_TipoCateter();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_TipoCateter", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Infecciones_TipoCateter();

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_TipoCateter", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_TipoCateter", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_TipoCateter", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_TipoCateter", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_Lugar get_wsENVIN_Web_Maestro_Infecciones_Lugar(String codigoPrograma, String id_ejecucion)
        {
            Resultado_ENVINMaestro_Lugar result = new Resultado_ENVINMaestro_Lugar();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Lugar", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Infecciones_LugarInsercion();

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Lugar", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Lugar", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Lugar", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Infecciones_Lugar", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_Microorganismos get_wsENVIN_Web_Maestro_Microorganismos(String codigoPrograma, String id_ejecucion)
        {
            Resultado_ENVINMaestro_Microorganismos result = new Resultado_ENVINMaestro_Microorganismos();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Microorganismos();

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_MicroorganismosGrupoMicroorganismosAntibiogramasIDGrupo get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID)
        {
            Resultado_ENVINMaestro_MicroorganismosGrupoMicroorganismosAntibiogramasIDGrupo result = new Resultado_ENVINMaestro_MicroorganismosGrupoMicroorganismosAntibiogramasIDGrupo();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDAnt", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo(wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDAnt", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDAnt", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDAnt", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDAnt", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_MicroorganismosUFC10 get_wsENVIN_Web_Maestro_Microorganismos_UFC_10(String codigoPrograma, String id_ejecucion)
        {
            Resultado_ENVINMaestro_MicroorganismosUFC10 result = new Resultado_ENVINMaestro_MicroorganismosUFC10();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos_UFC_10", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Microorganismos_UFC_10();

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos_UFC_10", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos_UFC_10", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos_UFC_10", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Microorganismos_UFC_10", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMicroorganismos get_wsENVIN_Web_Microorganismos(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Infecciones_ID)
        {
            Resultado_ENVINMicroorganismos result = new Resultado_ENVINMicroorganismos();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Infecciones_ID", wsENVIN_Web_Infecciones_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Microorganismos", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Microorganismos(wsENVIN_Web_Infecciones_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Microorganismos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Microorganismos", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Microorganismos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Microorganismos", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINInfecciones_Antibiogramas get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Infecciones_Microorganismos_ID)
        {
            Resultado_ENVINInfecciones_Antibiogramas result = new Resultado_ENVINInfecciones_Antibiogramas();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Infecciones_Microorganismos_ID", wsENVIN_Web_Infecciones_Microorganismos_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo(wsENVIN_Web_Infecciones_Microorganismos_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_ENVINMaestro_Antibiogramas_Resistencia get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia(String codigoPrograma, String id_ejecucion)
        {
            Resultado_ENVINMaestro_Antibiogramas_Resistencia result = new Resultado_ENVINMaestro_Antibiogramas_Resistencia();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia", lista, "---------------------------------- INICIO ----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia();

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }
        #endregion

        #region tabla de factores mensuales
        public Resultado_FactoresMensuales get_wsENVIN_Web_FactoresMensuales(String codigoPrograma, String id_ejecucion, int LogicalUnitID , int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID)
        {
            Resultado_FactoresMensuales result = new Resultado_FactoresMensuales();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("LogicalUnitID", LogicalUnitID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID", wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID", wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresMensuales", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_FactoresMensuales( LogicalUnitID, wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresMensuales", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresMensuales", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresMensuales", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresMensuales", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        public Resultado_FactoresMensuales_SumatorioMensual get_wsENVIN_Web_FactoresMensuales_SumatorioMensual(String codigoPrograma, String id_ejecucion, int LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID)
        {
            Resultado_FactoresMensuales_SumatorioMensual result = new Resultado_FactoresMensuales_SumatorioMensual();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("LogicalUnitID", LogicalUnitID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID", wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID", wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresMensuales_SumatorioMensual", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_FactoresMensuales_SumatorioMensual(LogicalUnitID, wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresMensuales_SumatorioMensual", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresMensuales_SumatorioMensual", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresMensuales_SumatorioMensual", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_FactoresMensuales_SumatorioMensual", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_MaestroFactoresMensualesMeses get_wsENVIN_Web_Maestro_FactoresMensuales_Meses(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID)
        {
            Resultado_MaestroFactoresMensualesMeses result = new Resultado_MaestroFactoresMensualesMeses();
            

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID", wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FactoresMensuales_Meses", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_FactoresMensuales_Meses(wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FactoresMensuales_Meses", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FactoresMensuales_Meses", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FactoresMensuales_Meses", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FactoresMensuales_Meses", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }


        public Resultado_MaestroFactoresMensualesAnnos get_wsENVIN_Web_Maestro_FactoresMensuales_Annos(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID)
        {
            Resultado_MaestroFactoresMensualesAnnos result = new Resultado_MaestroFactoresMensualesAnnos();


            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID", wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FactoresMensuales_Annos", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.get_wsENVIN_Web_Maestro_FactoresMensuales_Annos(wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FactoresMensuales_Annos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FactoresMensuales_Annos", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FactoresMensuales_Annos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "get_wsENVIN_Web_Maestro_FactoresMensuales_Annos", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        #endregion

        #endregion

        #region SPS

        public Resultado_SP_ActualizarEstadoPaciente set_SP_wsENVIN_ActualizarEstadoPaciente(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_SP_ActualizarEstadoPaciente result = new Resultado_SP_ActualizarEstadoPaciente();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_ActualizarEstadoPaciente", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_ActualizarEstadoPaciente( wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_ActualizarEstadoPaciente", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_ActualizarEstadoPaciente", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_ActualizarEstadoPaciente", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_ActualizarEstadoPaciente", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;

        }


        #region SP FichaIngreso
        //Setters: SP bbdd DESTINO

        public Resultado_FichaIngresoSPwebPacientes set_SP_wsENVIN_Web_Pacientes(String codigoPrograma, String id_ejecucion,
                 int PatientID, int id_wsLEIRE_Datos_Ingresos, String NHC, short LogicalUnitID, short wsENVIN_Web_Maestro_Pacientes_ORStatus_ID,
                 short wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID, Boolean EsCargaManual, DateTime FechaCargaManual,
                 String FirstName, String LastName, DateTime FechaNacimiento, short wsENVIN_Web_Maestro_Pacientes_Sexo_ID, short NumHabitacion,
                 DateTime AddmissionDate, DateTime FechaIngresoHospital, DateTime DischargeDate, DateTime FechaAltaHospital,
                 Boolean Exitus, DateTime FechaExitus, String IdUsuarioUltimaModificacion, int wsENVIN_Web_Pacientes_ID)
        {
            Resultado_FichaIngresoSPwebPacientes result = new Resultado_FichaIngresoSPwebPacientes();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("PatientID", PatientID.ToString()));
            lista.Add(new SICCA_Log.parametros("id_wsLEIRE_Datos_Ingresos", id_wsLEIRE_Datos_Ingresos.ToString()));
            lista.Add(new SICCA_Log.parametros("NHC", NHC));
            lista.Add(new SICCA_Log.parametros("LogicalUnitID", LogicalUnitID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Pacientes_ORStatus_ID", wsENVIN_Web_Maestro_Pacientes_ORStatus_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID", wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("EsCargaManual", EsCargaManual.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaCargaManual", FechaCargaManual.ToString()));
            lista.Add(new SICCA_Log.parametros("FirstName", FirstName));
            lista.Add(new SICCA_Log.parametros("LastName", LastName));
            lista.Add(new SICCA_Log.parametros("FechaNacimiento", FechaNacimiento.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Pacientes_Sexo_ID", wsENVIN_Web_Maestro_Pacientes_Sexo_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("NumHabitacion", NumHabitacion.ToString()));
            lista.Add(new SICCA_Log.parametros("AddmissionDate", AddmissionDate.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaIngresoHospital", FechaIngresoHospital.ToString()));
            lista.Add(new SICCA_Log.parametros("DischargeDate", DischargeDate.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaAltaHospital", FechaAltaHospital.ToString()));
            lista.Add(new SICCA_Log.parametros("Exitus", Exitus.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaExitus", FechaExitus.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioUltimaModificacion", IdUsuarioUltimaModificacion.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Pacientes", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_Pacientes(PatientID, id_wsLEIRE_Datos_Ingresos, NHC, LogicalUnitID, wsENVIN_Web_Maestro_Pacientes_ORStatus_ID,
                 wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID, EsCargaManual, FechaCargaManual,
                 FirstName, LastName, FechaNacimiento, wsENVIN_Web_Maestro_Pacientes_Sexo_ID, NumHabitacion,
                 AddmissionDate, FechaIngresoHospital, DischargeDate, FechaAltaHospital,
                 Exitus, FechaExitus, IdUsuarioUltimaModificacion, wsENVIN_Web_Pacientes_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Pacientes", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Pacientes", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Pacientes", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Pacientes", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;

        }

        public Resultado_FichaIngresoSPFichaIngresoGeneral set_SP_wsENVIN_Web_FichaIngreso_General(String codigoPrograma, String id_ejecucion,
                int wsENVIN_Web_Pacientes_ID, short Apache_II, short Glasgow, Boolean PacienteTraumatizado, Boolean PacienteCoronario,
                Boolean ATB48hPrevias, Boolean PacienteCovid19, short wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID,
                short wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID, short wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID, short wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID,
                String IdUsuarioUltimaModificacion, DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_General_ID)
        {
            Resultado_FichaIngresoSPFichaIngresoGeneral result = new Resultado_FichaIngresoSPFichaIngresoGeneral();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("Apache_II", Apache_II.ToString()));
            lista.Add(new SICCA_Log.parametros("Glasgow", Glasgow.ToString()));
            lista.Add(new SICCA_Log.parametros("PacienteCoronario", PacienteCoronario.ToString()));
            lista.Add(new SICCA_Log.parametros("ATB48hPrevias", ATB48hPrevias.ToString()));
            lista.Add(new SICCA_Log.parametros("PacienteCovid19", PacienteCovid19.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID", wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID", wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID", wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID", wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioUltimaModificacion", IdUsuarioUltimaModificacion.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaValidacion", FechaValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioValidacion", IdUsuarioValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_FichaIngreso_General_ID", wsENVIN_Web_FichaIngreso_General_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Pacientes", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_FichaIngreso_General(wsENVIN_Web_Pacientes_ID, Apache_II, Glasgow, PacienteTraumatizado, PacienteCoronario,
                                            ATB48hPrevias, PacienteCovid19, wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID,
                                            wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID, wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID, wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID,
                                            IdUsuarioUltimaModificacion, FechaValidacion, IdUsuarioValidacion, wsENVIN_Web_FichaIngreso_General_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_General", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_General", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_General", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_General", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;

        }

        public Resultado_FichaIngresoSPFichaIngresoComorbilidades set_SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(String codigoPrograma, String id_ejecucion,
                int wsENVIN_Web_Pacientes_ID, Boolean Diabetes, Boolean InsuficienciaRenal, Boolean Inmunodepresion, Boolean Neoplasia, Boolean Cirrosis,
                Boolean EPOC, Boolean DesnutricionHipoalbuminemia, Boolean TransplanteOrganoSolido, String IdUsuarioUltimaModificacion, DateTime FechaValidacion,
                String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID)
        {
            Resultado_FichaIngresoSPFichaIngresoComorbilidades result = new Resultado_FichaIngresoSPFichaIngresoComorbilidades();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("Diabetes", Diabetes.ToString()));
            lista.Add(new SICCA_Log.parametros("InsuficienciaRenal", InsuficienciaRenal.ToString()));
            lista.Add(new SICCA_Log.parametros("Inmunodepresion", Inmunodepresion.ToString()));
            lista.Add(new SICCA_Log.parametros("Neoplasia", Neoplasia.ToString()));
            lista.Add(new SICCA_Log.parametros("Cirrosis", Cirrosis.ToString()));
            lista.Add(new SICCA_Log.parametros("EPOC", EPOC.ToString()));
            lista.Add(new SICCA_Log.parametros("DesnutricionHipoalbuminemia", DesnutricionHipoalbuminemia.ToString()));
            lista.Add(new SICCA_Log.parametros("TransplanteOrganoSolido", TransplanteOrganoSolido.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioUltimaModificacion", IdUsuarioUltimaModificacion.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaValidacion", FechaValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioValidacion", IdUsuarioValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID", wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(wsENVIN_Web_Pacientes_ID, Diabetes, InsuficienciaRenal, 
                                                        Inmunodepresion, Neoplasia, Cirrosis,
                                                    EPOC, DesnutricionHipoalbuminemia, TransplanteOrganoSolido, IdUsuarioUltimaModificacion, FechaValidacion,
                                                       IdUsuarioValidacion, wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;

        }

        public Resultado_FichaIngresoSPFichaIngresoFactoresDeRiesgo set_SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(String codigoPrograma, String id_ejecucion,
               int wsENVIN_Web_Pacientes_ID, Boolean CirugiaUrgente, Boolean DerivacionVentricularExterna, Boolean DepuracionExtrarrenal,
               Boolean NutricionParenteral, Boolean Neutropenia, Boolean ECMO, Boolean CateterVenosoCentral, Boolean ViaAereaArtificial,
               Boolean SondaUrinaria, Boolean Impella, Boolean AsistenciaVentricular, Boolean BCIA, String IdUsuarioUltimaModificacion,
               DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID)
        {
            Resultado_FichaIngresoSPFichaIngresoFactoresDeRiesgo result = new Resultado_FichaIngresoSPFichaIngresoFactoresDeRiesgo();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("CirugiaUrgente", CirugiaUrgente.ToString()));
            lista.Add(new SICCA_Log.parametros("DerivacionVentricularExterna", DerivacionVentricularExterna.ToString()));
            lista.Add(new SICCA_Log.parametros("DepuracionExtrarrenal", DepuracionExtrarrenal.ToString()));
            lista.Add(new SICCA_Log.parametros("NutricionParenteral", NutricionParenteral.ToString()));
            lista.Add(new SICCA_Log.parametros("Neutropenia", Neutropenia.ToString()));
            lista.Add(new SICCA_Log.parametros("ECMO", ECMO.ToString()));
            lista.Add(new SICCA_Log.parametros("CateterVenosoCentral", CateterVenosoCentral.ToString()));
            lista.Add(new SICCA_Log.parametros("ViaAereaArtificial", ViaAereaArtificial.ToString()));
            lista.Add(new SICCA_Log.parametros("SondaUrinaria", SondaUrinaria.ToString()));
            lista.Add(new SICCA_Log.parametros("Impella", Impella.ToString()));
            lista.Add(new SICCA_Log.parametros("AsistenciaVentricular", AsistenciaVentricular.ToString()));
            lista.Add(new SICCA_Log.parametros("BCIA", BCIA.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioUltimaModificacion", IdUsuarioUltimaModificacion.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaValidacion", FechaValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioValidacion", IdUsuarioValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID", wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(wsENVIN_Web_Pacientes_ID, CirugiaUrgente, DerivacionVentricularExterna, DepuracionExtrarrenal,
                                            NutricionParenteral, Neutropenia, ECMO, CateterVenosoCentral, ViaAereaArtificial,
                                            SondaUrinaria, Impella, AsistenciaVentricular, BCIA, IdUsuarioUltimaModificacion,
                                            FechaValidacion, IdUsuarioValidacion, wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;

        }

        public Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccion set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(String codigoPrograma, String id_ejecucion,
               int wsENVIN_Web_Pacientes_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID, 
               int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID,
               DateTime Fecha, String IdUsuarioUltimaModificacion,
               DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID)
        {
            Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccion result = new Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccion();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID", wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID", wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID", wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID", wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("Fecha", Fecha.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioUltimaModificacion", IdUsuarioUltimaModificacion.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaValidacion", FechaValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioValidacion", IdUsuarioValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID", wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(wsENVIN_Web_Pacientes_ID,  wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID,  wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID,
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID,  wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID,
                Fecha,  IdUsuarioUltimaModificacion,
                FechaValidacion,  IdUsuarioValidacion,  wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;

        }


        public Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccionDel set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID)
        {
            Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccionDel result = new Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccionDel();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID", wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del( wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        #endregion

        #region SP Factores de riesgo individual

        public Resultado_SPFactoresRiesgoIndividual set_SP_wsENVIN_Web_FactoresRiesgoIndividual(String codigoPrograma, String id_ejecucion,
                int wsENVIN_Web_Pacientes_ID, DateTime Periodo1ViaAereaArtificial_Inicio, DateTime Periodo1ViaAereaArtificial_Fin, DateTime Periodo2ViaAereaArtificial_Inicio, DateTime Periodo2ViaAereaArtificial_Fin,
                DateTime Periodo3ViaAereaArtificial_Inicio, DateTime Periodo3ViaAereaArtificial_Fin, DateTime FechaInicioTraqueostomia,
                DateTime Periodo1VMNI_Inicio, DateTime Periodo1VMNI_Fin, DateTime Periodo2VMNI_Inicio,DateTime Periodo2VMNI_Fin, DateTime Periodo3VMNI_Inicio,
                DateTime Periodo3VMNI_Fin, DateTime Fecha1Reintubacion, DateTime Fecha2Reintubacion, DateTime PeriodoSondaUrinaria_Inicio, DateTime PeriodoSondaUrinaria_Fin,
                DateTime Periodo1CVC_Inicio, DateTime Periodo1CVC_Fin, DateTime Periodo2CVC_Inicio, DateTime Periodo2CVC_Fin,
                DateTime Periodo3CVC_Inicio, DateTime Periodo3CVC_Fin, DateTime PeriodoCateterArterial_Inicio, DateTime PeriodoCateterArterial_Fin,
                DateTime PeriodoNutricionParenteral_Inicio, DateTime PeriodoNutricionParenteral_Fin, DateTime PeriodoNutricionEnteral_Inicio, DateTime PeriodoNutricionEnteral_Fin,
                DateTime ECMO_Inicio, DateTime ECMO_Fin, String IdUsuarioUltimaModificacion, DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FactoresRiesgoIndividual_ID)
        {
            Resultado_SPFactoresRiesgoIndividual result = new Resultado_SPFactoresRiesgoIndividual();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo1ViaAereaArtificial_Inicio", Periodo1ViaAereaArtificial_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo1ViaAereaArtificial_Fin", Periodo1ViaAereaArtificial_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo2ViaAereaArtificial_Inicio", Periodo2ViaAereaArtificial_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo2ViaAereaArtificial_Fin", Periodo2ViaAereaArtificial_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo3ViaAereaArtificial_Inicio", Periodo3ViaAereaArtificial_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo3ViaAereaArtificial_Fin", Periodo3ViaAereaArtificial_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaInicioTraqueostomia", FechaInicioTraqueostomia.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo1VMNI_Inicio", Periodo1VMNI_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo1VMNI_Fin", Periodo1VMNI_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo2VMNI_Inicio", Periodo2VMNI_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo3VMNI_Inicio", Periodo3VMNI_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo3VMNI_Fin", Periodo3VMNI_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("Fecha1Reintubacion", Fecha1Reintubacion.ToString()));
            lista.Add(new SICCA_Log.parametros("Fecha2Reintubacion", Fecha2Reintubacion.ToString()));
            lista.Add(new SICCA_Log.parametros("PeriodoSondaUrinaria_Inicio", PeriodoSondaUrinaria_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("PeriodoSondaUrinaria_Fin", PeriodoSondaUrinaria_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo1CVC_Inicio", Periodo1CVC_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo1CVC_Fin", Periodo1CVC_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo2CVC_Inicio", Periodo2CVC_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo2CVC_Fin", Periodo2CVC_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo3CVC_Inicio", Periodo3CVC_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("Periodo3CVC_Fin", Periodo3CVC_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("PeriodoCateterArterial_Inicio", PeriodoCateterArterial_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("PeriodoCateterArterial_Fin", PeriodoCateterArterial_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("PeriodoNutricionParenteral_Inicio", PeriodoNutricionParenteral_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("PeriodoNutricionParenteral_Fin", PeriodoNutricionParenteral_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("PeriodoNutricionEnteral_Inicio", PeriodoNutricionEnteral_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("PeriodoNutricionEnteral_Fin", PeriodoNutricionEnteral_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("ECMO_Inicio", ECMO_Inicio.ToString()));
            lista.Add(new SICCA_Log.parametros("ECMO_Fin", ECMO_Fin.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioUltimaModificacion", IdUsuarioUltimaModificacion));
            lista.Add(new SICCA_Log.parametros("FechaValidacion", FechaValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioValidacion", IdUsuarioValidacion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_FactoresRiesgoIndividual_ID", wsENVIN_Web_FactoresRiesgoIndividual_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresRiesgoIndividual", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_FactoresRiesgoIndividual( wsENVIN_Web_Pacientes_ID,  Periodo1ViaAereaArtificial_Inicio,  Periodo1ViaAereaArtificial_Fin,  Periodo2ViaAereaArtificial_Inicio,  Periodo2ViaAereaArtificial_Fin,
                 Periodo3ViaAereaArtificial_Inicio,  Periodo3ViaAereaArtificial_Fin,  FechaInicioTraqueostomia,
                 Periodo1VMNI_Inicio,  Periodo1VMNI_Fin,  Periodo2VMNI_Inicio,  Periodo2VMNI_Fin,  Periodo3VMNI_Inicio,
                 Periodo3VMNI_Fin,  Fecha1Reintubacion,  Fecha2Reintubacion,  PeriodoSondaUrinaria_Inicio,  PeriodoSondaUrinaria_Fin,
                 Periodo1CVC_Inicio,  Periodo1CVC_Fin,  Periodo2CVC_Inicio,  Periodo2CVC_Fin,
                 Periodo3CVC_Inicio,  Periodo3CVC_Fin,  PeriodoCateterArterial_Inicio,  PeriodoCateterArterial_Fin,
                 PeriodoNutricionParenteral_Inicio,  PeriodoNutricionParenteral_Fin,  PeriodoNutricionEnteral_Inicio,  PeriodoNutricionEnteral_Fin,
                 ECMO_Inicio,  ECMO_Fin,  IdUsuarioUltimaModificacion,  FechaValidacion,  IdUsuarioValidacion,  wsENVIN_Web_FactoresRiesgoIndividual_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresRiesgoIndividual", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresRiesgoIndividual", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresRiesgoIndividual", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresRiesgoIndividual", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;

        }



        public Resultado_SPFactoresRiesgoIndividualDel set_SP_wsENVIN_Web_FactoresRiesgoIndividual_Del(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_FactoresRiesgoIndividual_ID)
        {
            Resultado_SPFactoresRiesgoIndividualDel result = new Resultado_SPFactoresRiesgoIndividualDel();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_FactoresRiesgoIndividual_ID", wsENVIN_Web_FactoresRiesgoIndividual_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresRiesgoIndividual_Del", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_FactoresRiesgoIndividual_Del(wsENVIN_Web_FactoresRiesgoIndividual_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresRiesgoIndividual_Del", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresRiesgoIndividual_Del", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresRiesgoIndividual_Del", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresRiesgoIndividual_Del", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        #endregion

        #region SP Antibioticos
        public Resultado_SPAntibioticos set_SP_wsENVIN_Web_Antibioticos(String codigoPrograma, String id_ejecucion,
                 int wsENVIN_Web_Pacientes_ID, int LogicalUnitID, int PlannedOrderID, String Antibiotico, DateTime FechaInicio,
                 DateTime FechaFin, int wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID, int wsENVIN_Web_Maestro_Infecciones_Localizacion_ID,
                 int wsENVIN_Web_Maestro_Antibioticos_Motivo_ID, int wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID, int wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID,
                 int wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID, String IdUsuarioUltimaModificacion,
                 DateTime FechaValidacion, String IdUsuarioValidacion, bool Estado, int wsENVIN_Web_Antibioticos_ID)
        {
            Resultado_SPAntibioticos result = new Resultado_SPAntibioticos();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("LogicalUnitID", LogicalUnitID.ToString()));
            lista.Add(new SICCA_Log.parametros("PlannedOrderID", PlannedOrderID.ToString()));
            lista.Add(new SICCA_Log.parametros("Antibiotico", Antibiotico));
            lista.Add(new SICCA_Log.parametros("FechaInicio", FechaInicio.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaFin", FechaFin.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID", wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Infecciones_Localizacion_ID", wsENVIN_Web_Maestro_Infecciones_Localizacion_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibioticos_Motivo_ID", wsENVIN_Web_Maestro_Antibioticos_Motivo_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID", wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID", wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID", wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioUltimaModificacion", IdUsuarioUltimaModificacion));
            lista.Add(new SICCA_Log.parametros("FechaValidacion", FechaValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioValidacion", IdUsuarioValidacion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Antibioticos_ID", wsENVIN_Web_Antibioticos_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Antibioticos", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_Antibioticos(wsENVIN_Web_Pacientes_ID,  LogicalUnitID,  PlannedOrderID,  Antibiotico,  FechaInicio,
                  FechaFin,  wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID,  wsENVIN_Web_Maestro_Infecciones_Localizacion_ID,
                  wsENVIN_Web_Maestro_Antibioticos_Motivo_ID,  wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID,  wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID,
                  wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID,  IdUsuarioUltimaModificacion,
                  FechaValidacion,  IdUsuarioValidacion, Estado,  wsENVIN_Web_Antibioticos_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Antibioticos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Antibioticos", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Antibioticos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Antibioticos", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;

        }


        public Resultado_SPAntibioticosDel set_SP_wsENVIN_Web_Antibioticos_Del(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Antibioticos_ID)
        {
            Resultado_SPAntibioticosDel result = new Resultado_SPAntibioticosDel();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Antibioticos_ID", wsENVIN_Web_Antibioticos_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Antibioticos_Del", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_Antibioticos_Del(wsENVIN_Web_Antibioticos_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Antibioticos_Del", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Antibioticos_Del", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Antibioticos_Del", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_Antibioticos_Del", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        #endregion

        #region Infecciones
        public Resultado_SPInfecciones set_wsENVIN_Infecciones(string codigoPrograma, string id_ejecucion, int wsENVIN_Web_Pacientes_ID, short wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID, short? wsENVIN_Web_Maestro_Infecciones_Localizacion_ID, bool? bacteriemia, short wsENVIN_Web_Maestro_Infecciones_Muestra_ID, short wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID, bool exposicion48hprevias, bool? tratamientoAntibiotico, bool? tratamientoApropiado, bool? ajusteTratamiento, short? wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID, short wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID, short wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID, string idUsuarioUltimaModificacion, DateTime fechaValidacion, string idUsuarioValidacion, DateTime fechaInfeccion, int? wsENVIN_Web_Infecciones_ID)
        {
            Resultado_SPInfecciones result = new Resultado_SPInfecciones();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID", wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Infecciones_Localizacion_ID", wsENVIN_Web_Maestro_Infecciones_Localizacion_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("bacteriemia", bacteriemia.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Infecciones_Muestra_ID", wsENVIN_Web_Maestro_Infecciones_Muestra_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID", wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("exposicion48hprevias", exposicion48hprevias.ToString()));
            lista.Add(new SICCA_Log.parametros("tratamientoAntibiotico", tratamientoAntibiotico.ToString()));
            lista.Add(new SICCA_Log.parametros("tratamientoApropiado", tratamientoApropiado.ToString()));
            lista.Add(new SICCA_Log.parametros("ajusteTratamiento", ajusteTratamiento.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID", wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID", wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID", wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("idUsuarioUltimaModificacion", idUsuarioUltimaModificacion));
            lista.Add(new SICCA_Log.parametros("fechaValidacion", fechaValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("idUsuarioValidacion", idUsuarioValidacion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Infecciones_ID", wsENVIN_Web_Infecciones_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_wsENVIN_Infecciones(wsENVIN_Web_Pacientes_ID, wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID, wsENVIN_Web_Maestro_Infecciones_Localizacion_ID,
                            bacteriemia, wsENVIN_Web_Maestro_Infecciones_Muestra_ID, wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID, exposicion48hprevias, tratamientoAntibiotico,
                            tratamientoApropiado, ajusteTratamiento, wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID, wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID,
                            wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID, idUsuarioUltimaModificacion, fechaValidacion, idUsuarioValidacion, fechaInfeccion, wsENVIN_Web_Infecciones_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_SPInfeccionesDel set_wsENVIN_Infecciones_Del(string codigoPrograma, string id_ejecucion, int wsENVIN_Web_Infecciones_ID)
        {
            Resultado_SPInfeccionesDel result = new Resultado_SPInfeccionesDel();
            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Infecciones_ID", wsENVIN_Web_Infecciones_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Del", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_wsENVIN_Infecciones_Del(wsENVIN_Web_Infecciones_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Del", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Del", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Del", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Del", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_SPAntibiograma set_wsENVIN_Infecciones_Antibiograma(string codigoPrograma, string id_ejecucion, int wsENVIN_Web_Infecciones_Microorganismos_ID, short wsENVIN_Web_Maestro_Antibiogramas_ID, short wsENVIN_Web_Pacientes_ID, short wsENVN_Web_Maestro_Antibiogramas_Resistencia_ID,
               String idUsuarioUltimaModificacion, DateTime fechaValidacion, String idUsuarioValidacion, int? wsENVIN_Web_Infecciones_Antibiogramas_ID)
        {
            Resultado_SPAntibiograma result = new Resultado_SPAntibiograma();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ID", wsENVN_Web_Maestro_Antibiogramas_Resistencia_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Infecciones_Microorganismos_ID", wsENVIN_Web_Infecciones_Microorganismos_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Antibiogramas_ID", wsENVIN_Web_Maestro_Antibiogramas_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioUltimaModificacion", idUsuarioUltimaModificacion));
            lista.Add(new SICCA_Log.parametros("FechaValidacion", fechaValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioValidacion", idUsuarioValidacion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Infecciones_Antibiogramas_ID", wsENVIN_Web_Infecciones_Antibiogramas_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Antibiograma", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_wsENVIN_Antibiograma(wsENVIN_Web_Infecciones_Microorganismos_ID, wsENVIN_Web_Maestro_Antibiogramas_ID, wsENVIN_Web_Pacientes_ID, wsENVN_Web_Maestro_Antibiogramas_Resistencia_ID,
                 idUsuarioUltimaModificacion, fechaValidacion, idUsuarioValidacion, wsENVIN_Web_Infecciones_Antibiogramas_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Antibiograma", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Antibiograma", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Antibiograma", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Antibiograma", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }
                
        public Resultado_SPMicroorganismoDel set_wsENVIN_Infecciones_Microrgarnismos_Del(string codigoPrograma, string id_ejecucion, int wsENVIN_Web_Infecciones_Microorganismos_ID)
        {
            Resultado_SPMicroorganismoDel result = new Resultado_SPMicroorganismoDel();
            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Infecciones_Microorganismos_ID", wsENVIN_Web_Infecciones_Microorganismos_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Microrgarnismos_Del", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_wsENVIN_Microorganismo_Del(wsENVIN_Web_Infecciones_Microorganismos_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Microrgarnismos_Del", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Microrgarnismos_Del", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Microrgarnismos_Del", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Microrgarnismos_Del", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
        }

        public Resultado_SPMicroorganismo set_wsENVIN_Infecciones_Microrgarnismos(string codigoPrograma, string id_ejecucion, int wsENVIN_Web_Infecciones_ID, short wsENVIN_Web_Maestro_Microorganismos_ID, short wsENVIN_Web_Pacientes_ID, int wsENVIN_Web_Maestro_Microorganismos_UFC_ID, String idUsuarioUltimaModificacion,
               DateTime fechaValidacion, String idUsuarioValidacion, int wsENVIN_Web_Infecciones_Microorganismos_ID)
        {
            Resultado_SPMicroorganismo result = new Resultado_SPMicroorganismo();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Pacientes_ID", wsENVIN_Web_Pacientes_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Infecciones_ID", wsENVIN_Web_Infecciones_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Microorganismos_ID", wsENVIN_Web_Maestro_Microorganismos_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_Microorganismos_UFC_ID", wsENVIN_Web_Maestro_Microorganismos_UFC_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("idUsuarioUltimaModificacion", idUsuarioUltimaModificacion));
            lista.Add(new SICCA_Log.parametros("fechaValidacion", fechaValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("idUsuarioValidacion", idUsuarioValidacion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Infecciones_Microorganismos_ID", wsENVIN_Web_Infecciones_Microorganismos_ID.ToString()));
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Microrgarnismos", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_wsENVIN_Microorganismo(wsENVIN_Web_Infecciones_ID, wsENVIN_Web_Maestro_Microorganismos_ID, wsENVIN_Web_Pacientes_ID, wsENVIN_Web_Maestro_Microorganismos_UFC_ID,
                 idUsuarioUltimaModificacion, fechaValidacion, idUsuarioValidacion, wsENVIN_Web_Infecciones_Microorganismos_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Microrgarnismos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Microrgarnismos", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Microrgarnismos", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_wsENVIN_Infecciones_Microrgarnismos", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;
           
        }
        #endregion

        #region factores mensuales
        public Resultado_SPFactoresMensualesSumatorioMensual set_SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual(String codigoPrograma, String id_ejecucion,
               short LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID,
               short NumPacientesIngresados , short NumPacientesNuevos ,
                short NumPacientesConATB ,
                short NumPacientesConBMR ,
                short NumPacientesAislados ,
                short NumPacientesA_PreventivoContacto ,
                short NumPacientesA_Contacto ,
                short NumPacientesA_Protector ,
                short NumPacientesA_Gotas ,
                short NumPacientesA_GotasContacto ,
                short NumPacientesA_Aereo ,
                short NumPacientesA_AereoContacto ,
                short NumPacientesConViaAerea ,
                short NumPacientesConSondaUrinaria ,
                short NumPacientesConArteria ,
                short NumPacientesConViaCentral ,
                DateTime FechaComputo ,
                String IdUsuarioUltimaModificacion ,
                DateTime FechaValidacion ,
               String IdUsuarioValidacion ,
                int wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID  )
        {
            Resultado_SPFactoresMensualesSumatorioMensual result = new Resultado_SPFactoresMensualesSumatorioMensual();

            #region Log parametros
            List<SICCA_Log.parametros> lista = new List<SICCA_Log.parametros>();
            lista.Add(new SICCA_Log.parametros("codigoPrograma", codigoPrograma));
            lista.Add(new SICCA_Log.parametros("id_ejecucion", id_ejecucion));
            lista.Add(new SICCA_Log.parametros("LogicalUnitID", LogicalUnitID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID", wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID", wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesIngresados", NumPacientesIngresados.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesNuevos", NumPacientesNuevos.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesConATB", NumPacientesConATB.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesConBMR", NumPacientesConBMR.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesAislados", NumPacientesAislados.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesA_PreventivoContacto", NumPacientesA_PreventivoContacto.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesA_Contacto", NumPacientesA_Contacto.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesA_Protector", NumPacientesA_Protector.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesA_Gotas", NumPacientesA_Gotas.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesA_GotasContacto", NumPacientesA_GotasContacto.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesA_Aereo", NumPacientesA_Aereo.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesA_AereoContacto", NumPacientesA_AereoContacto.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesConViaAerea", NumPacientesConViaAerea.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesConSondaUrinaria", NumPacientesConSondaUrinaria.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesConArteria", NumPacientesConArteria.ToString()));
            lista.Add(new SICCA_Log.parametros("NumPacientesConViaCentral", NumPacientesConViaCentral.ToString()));
            lista.Add(new SICCA_Log.parametros("FechaComputo", FechaComputo.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioUltimaModificacion", IdUsuarioUltimaModificacion));
            lista.Add(new SICCA_Log.parametros("FechaValidacion", FechaValidacion.ToString()));
            lista.Add(new SICCA_Log.parametros("IdUsuarioValidacion", IdUsuarioValidacion));
            lista.Add(new SICCA_Log.parametros("wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID", wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID.ToString()));
            
            #endregion

            if (codigoPrograma == System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"])
            {
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "T", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual", lista, "----------------------------------INICIO----------------------------------------");

                wsENVIN ENVIN = new wsENVIN(id_ejecucion);
                result = ENVIN.set_SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual( LogicalUnitID,  wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID,  wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID,
                NumPacientesIngresados,  NumPacientesNuevos,
                 NumPacientesConATB,
                 NumPacientesConBMR,
                 NumPacientesAislados,
                 NumPacientesA_PreventivoContacto,
                 NumPacientesA_Contacto,
                 NumPacientesA_Protector,
                 NumPacientesA_Gotas,
                 NumPacientesA_GotasContacto,
                 NumPacientesA_Aereo,
                 NumPacientesA_AereoContacto,
                 NumPacientesConViaAerea,
                 NumPacientesConSondaUrinaria,
                 NumPacientesConArteria,
                 NumPacientesConViaCentral,
                 FechaComputo,
                 IdUsuarioUltimaModificacion,
                 FechaValidacion,
                IdUsuarioValidacion,
                 wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID);

                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 0, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual", lista, "result.MensajeError: " + result.MensajeError);
            }
            else
            {
                result.EsCorrecto = false;
                result.MensajeError = "Código de programa no es correcto";
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual", lista, "result.EsCorrecto:" + result.EsCorrecto.ToString());
                SICCA_Log.Log.SP_SIC_Sistema_Log(id_ejecucion, "L", 1, "SICCAWcf", "WcfENVIN", "set_SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual", lista, "result.MensajeError: " + result.MensajeError);
            }

            return result;

        }


        #endregion

        #endregion
    }
}
