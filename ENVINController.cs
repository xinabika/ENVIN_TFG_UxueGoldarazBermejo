using SICCATransversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SICCATransversal.wsENVIN;

namespace SICCA_IC_Mobile.Controllers
{
    public class ENVINController : Controller
    {
        public string idEjecucion = Util.id_Ejecucion("SILINK_ENVIN");

        //comprobacion fechas
        public static DateTime compruebaFecha(String fecha)
        {

            DateTime res = new DateTime();
            if (fecha != "--" && fecha != null && fecha != "")
            {
                res = Convert.ToDateTime(fecha);
            }
            else
            {
                res = new DateTime(1971, 1, 1, 0, 0, 0, 0);//fecha nula
            }

            return res;
        }

        /* Regiones:
           ++ nombre pantalla 
                +++ vista principal
                +++ obtencion de desplegables (maestros): Obtener+[nombreControl]
                +++ obtencion de datos: getters GET+[NOMBRE TIPO RESULTADO] y setters: SET+[NOMBRE TIPO RESULTADO]
        */
        #region Index BusquedaPacientes
        //vista principal
        public ActionResult FiltradoPacientes()
        {//aqui añadir la linea con el viewmodel y devuelvo dentro del view()
            return View();
        }
        //obtencion de desplegables
        public ActionResult ObtenerUnidades()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerUnidades", new List<SICCA_Log.parametros>(), "Obteniendo unidades ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            ResultadoDameLogicalUnits result = new ResultadoDameLogicalUnits();

            try
            {
                wcfUsuariosHCI.WcfServiceClient wsServiceUnidades = new wcfUsuariosHCI.WcfServiceClient();
                var resultado = wsServiceUnidades.DameLogicalUnits(codigoPrograma);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.listaDameLogicalUnits != null && resultado.listaDameLogicalUnits.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerUnidades", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente las unidades");

                        result.listaDameLogicalUnits = resultado.listaDameLogicalUnits.Where(b=>b.Version==6).OrderBy(a => a.Name).ToList();
                        result.listaDameLogicalUnits.RemoveAll(b => b.Unidad != "IC" && b.Name == "CHN");
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerUnidades", new List<SICCA_Log.parametros>(), "No se han encontrado unidades");

                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerUnidades", new List<SICCA_Log.parametros>(), "No se han obtenido infecciones: " + resultado.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerUnidades", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin obtenerUnidades


        public ActionResult ObtenerTiposEstadoInforme()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerTiposEstadoInforme", new List<SICCA_Log.parametros>(), "Obteniendo tipos estado informe");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_TiposEstadoInforme result = new Resultado_TiposEstadoInforme();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();

                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme(codigoPrograma, idEjecucion,0);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme != null && resultado.get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerTiposEstadoInforme", new List<SICCA_Log.parametros>(), "Obtenidos los estados de informe correctamente");
                        result.get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme = resultado.get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerTiposEstadoInforme", new List<SICCA_Log.parametros>(), "No se han encontrado estados de informe");

                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerTiposEstadoInforme", new List<SICCA_Log.parametros>(), "No se han obtenido los estados de informe: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerInfeccionesPaciente", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin ObtenerEstadosInforme

        //obtencion de datos GETTERS Y SETTERS
        public ActionResult GET_ENVIN_Pacientes_Ingresados(DateTime fechaInicio, DateTime fechaFin, int logicalUnitID, int EstadoInforme, String nombre, String apellidos, String nhc)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_ENVIN_Pacientes_Ingresados", new List<SICCA_Log.parametros>(), "Obteniendo pacientes ingresados: " );

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_ENVIN_Pacientes_Ingresados result = new Resultado_ENVIN_Pacientes_Ingresados();

            try
            {
                if (nombre == "")
                {
                    nombre = null;
                }
                if (apellidos == "")
                {
                    apellidos = null;
                }
                if (nhc == "")
                {
                    nhc = null;
                }
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();

                var resultado = wsENVIN.get_wsENVIN_Web_Pacientes_Filtrado(codigoPrograma, idEjecucion, fechaInicio, fechaFin, logicalUnitID, EstadoInforme, nombre, apellidos, nhc);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Pacientes_Filtrado != null && resultado.get_wsENVIN_Web_Pacientes_Filtrado.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_ENVIN_Pacientes_Ingresados", new List<SICCA_Log.parametros>(), "PAcientes obtenidos correctamente");
                         result.get_wsENVIN_Web_Pacientes_Filtrado = resultado.get_wsENVIN_Web_Pacientes_Filtrado;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_ENVIN_Pacientes_Ingresados", new List<SICCA_Log.parametros>(), "No se han encontrado pacientes");

                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_ENVIN_Pacientes_Ingresados", new List<SICCA_Log.parametros>(), "No se han obtenido pacientes: " + resultado.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_ENVIN_Pacientes_Ingresados", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin ObtenerEstadosInforme

        public ActionResult GET_ENVIN_Pacientes(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_ENVIN_Pacientes", new List<SICCA_Log.parametros>(), "Obteniendo paciente: ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_ENVIN_Paciente result = new Resultado_ENVIN_Paciente();

            try
            {
                
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();

                var resultado = wsENVIN.get_wsENVIN_Web_Pacientes(codigoPrograma, idEjecucion,  wsENVIN_Web_Pacientes_ID);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Pacientes != null && resultado.get_wsENVIN_Web_Pacientes.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_ENVIN_Pacientes", new List<SICCA_Log.parametros>(), "PAciente obtenidos correctamente");
                        result.get_wsENVIN_Web_Pacientes = resultado.get_wsENVIN_Web_Pacientes;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_ENVIN_Pacientes", new List<SICCA_Log.parametros>(), "No se han encontrado paciente");

                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_ENVIN_Pacientes", new List<SICCA_Log.parametros>(), "No se ha obtenido paciente: " + resultado.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_ENVIN_Pacientes", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin GET_ENVIN_Pacientes


        public ActionResult SET_Pacientes(int PatientID, int id_wsLEIRE_Datos_Ingresos, String NHC, short LogicalUnitID, short wsENVIN_Web_Maestro_Pacientes_ORStatus_ID,
                short wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID, Boolean EsCargaManual, String FechaCargaManual,
                String FirstName, String LastName, String FechaNacimiento, short wsENVIN_Web_Maestro_Pacientes_Sexo_ID, short NumHabitacion,
                String AddmissionDate, String FechaIngresoHospital, String DischargeDate, String FechaAltaHospital,
                Boolean Exitus, String FechaExitus, String IdUsuarioUltimaModificacion, int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_Pacientes", new List<SICCA_Log.parametros>(), "Inicio seteo de paciente: " + wsENVIN_Web_Pacientes_ID);

            Resultado_FichaIngresoSPwebPacientes result = new Resultado_FichaIngresoSPwebPacientes();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_Web_Pacientes(codigoPrograma, idEjecucion, PatientID, id_wsLEIRE_Datos_Ingresos,
                    NHC, LogicalUnitID, wsENVIN_Web_Maestro_Pacientes_ORStatus_ID,
                  wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID, EsCargaManual, compruebaFecha(FechaCargaManual),
                  FirstName, LastName, compruebaFecha(FechaNacimiento), wsENVIN_Web_Maestro_Pacientes_Sexo_ID, NumHabitacion,
                  compruebaFecha(AddmissionDate), compruebaFecha(FechaIngresoHospital), compruebaFecha(DischargeDate), compruebaFecha(FechaAltaHospital),
                  Exitus, compruebaFecha(FechaExitus), IdUsuarioUltimaModificacion, wsENVIN_Web_Pacientes_ID);
                if (resultado.EsCorrecto && resultado.wsENVIN_Web_Pacientes_ID > 0)
                {

                    result.EsCorrecto = true;
                    result.wsENVIN_Web_Pacientes_ID = resultado.wsENVIN_Web_Pacientes_ID;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_Pacientes", new List<SICCA_Log.parametros>(), "Se ha seteado correctamente el paciente:  " + result.wsENVIN_Web_Pacientes_ID);

                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_Pacientes", new List<SICCA_Log.parametros>(), "No se ha seteado correctamente el paciente: " + resultado.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "SET_Pacientes", new List<SICCA_Log.parametros>(), msg);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//SET_FichaIngresoSPPAcientes



        public ActionResult SET_wsENVIN_ActualizarEstadoPaciente(int wsENVIN_Web_Pacientes_ID)
        {
           
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_wsENVIN_ActualizarEstadoPaciente", new List<SICCA_Log.parametros>(), "Inicio actualizacion estado informe del paciente: " + wsENVIN_Web_Pacientes_ID);

            Resultado_SP_ActualizarEstadoPaciente result = new Resultado_SP_ActualizarEstadoPaciente();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_ActualizarEstadoPaciente(codigoPrograma, idEjecucion, wsENVIN_Web_Pacientes_ID);
                if (resultado.EsCorrecto && resultado.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID > 0)
                {

                    result.EsCorrecto = true;
                    result.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID = resultado.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_wsENVIN_ActualizarEstadoPaciente", new List<SICCA_Log.parametros>(), "Se ha actualizado correctamente el paciente. El id wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID nuevo es:  " + result.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID);

                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_wsENVIN_ActualizarEstadoPaciente", new List<SICCA_Log.parametros>(), "No se ha actualizado correctamente el paciente: " + resultado.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "SET_wsENVIN_ActualizarEstadoPaciente", new List<SICCA_Log.parametros>(), msg);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//SET_wsENVIN_ActualizarEstadoPaciente


        #endregion

        #region Ficha de ingreso
        //vista principal
        public ActionResult FichaDeIngreso()
        {
            return View();
        }
        //obtencion de desplegables
        public ActionResult FichaIngreso_ObtenerControles()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "Obteniendo controles de ficha de ingreso ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_FichaIngresoDatos result = new Resultado_FichaIngresoDatos();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();

                
                var resultadoDiagnosticosENVIN = wsENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN(codigoPrograma, idEjecucion, 0);
                if (resultadoDiagnosticosENVIN.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoDiagnosticosENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN != null && resultadoDiagnosticosENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles de ficha de ingreso: diagnosticos envin");
                        result.get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN = resultadoDiagnosticosENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado los controles de ficha de ingreso: diagnosticos envin");

                    }
                }
                if (!resultadoDiagnosticosENVIN.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido los controles de ficha de ingreso: diagnosticos envin: " + resultadoDiagnosticosENVIN.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoDiagnosticosENVIN.MensajeError;
                }


                var resultadoOrigenPaciente = wsENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente(codigoPrograma, idEjecucion, 0);
                if (resultadoOrigenPaciente.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoOrigenPaciente.get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente != null && resultadoOrigenPaciente.get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles de ficha de ingreso: origen paciente");

                        result.get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente = resultadoOrigenPaciente.get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado los controles de ficha de ingreso: origen paciente");

                    }
                }
                if (!resultadoOrigenPaciente.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido los controles de ficha de ingreso: origen paciente: " + resultadoDiagnosticosENVIN.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoOrigenPaciente.MensajeError;
                }

                var resultadoTipoDeAdmision = wsENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision(codigoPrograma, idEjecucion, 0);
                if (resultadoTipoDeAdmision.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoTipoDeAdmision.get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision != null && resultadoTipoDeAdmision.get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles de ficha de ingreso: tipo de admision");

                        result.get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision = resultadoTipoDeAdmision.get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado los controles de ficha de ingreso: tipo de admision");

                    }
                }
                if (!resultadoTipoDeAdmision.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido los controles de ficha de ingreso: tipo de admision: " + resultadoDiagnosticosENVIN.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoTipoDeAdmision.MensajeError;
                }


                var resultadoCirugiaPrevia = wsENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia(codigoPrograma, idEjecucion, 0);
                if (resultadoCirugiaPrevia.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoCirugiaPrevia.get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia != null && resultadoCirugiaPrevia.get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles de ficha de ingreso: CirugiaPrevia");

                        result.get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia = resultadoCirugiaPrevia.get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado los controles de ficha de ingreso: CirugiaPrevia");

                    }
                }
                if (!resultadoCirugiaPrevia.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido los controles de ficha de ingreso: CirugiaPrevia: " + resultadoDiagnosticosENVIN.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoCirugiaPrevia.MensajeError;
                }

                var resultadoColonizacionInfeccion = wsENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion(codigoPrograma, idEjecucion, 0);
                if (resultadoColonizacionInfeccion.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoColonizacionInfeccion.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion != null && resultadoColonizacionInfeccion.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles de ficha de ingreso: ColonizacionInfeccion");

                        result.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion = resultadoColonizacionInfeccion.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado los controles de ficha de ingreso: ColonizacionInfeccion");

                    }
                }
                if (!resultadoColonizacionInfeccion.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido los controles de ficha de ingreso: ColonizacionInfeccion: " + resultadoDiagnosticosENVIN.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoColonizacionInfeccion.MensajeError;
                }

                var resultadoColonizacionInfeccion_Cuando = wsENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando(codigoPrograma, idEjecucion, 0);
                if (resultadoColonizacionInfeccion_Cuando.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoColonizacionInfeccion_Cuando.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando != null && resultadoColonizacionInfeccion_Cuando.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles de ficha de ingreso: ColonizacionInfeccion_Cuando");

                        result.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando = resultadoColonizacionInfeccion_Cuando.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado los controles de ficha de ingreso: ColonizacionInfeccion_Cuando");

                    }
                }
                if (!resultadoColonizacionInfeccion_Cuando.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido los controles de ficha de ingreso: ColonizacionInfeccion_Cuando: " + resultadoDiagnosticosENVIN.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoColonizacionInfeccion_Cuando.MensajeError;
                }


                var resultadoColonizacionInfeccion_Localizacion = wsENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion(codigoPrograma, idEjecucion, 0);
                if (resultadoColonizacionInfeccion_Localizacion.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoColonizacionInfeccion_Localizacion.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion != null && resultadoColonizacionInfeccion_Localizacion.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles de ficha de ingreso: ColonizacionInfeccion_Localizacion");

                        result.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion = resultadoColonizacionInfeccion_Localizacion.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado los controles de ficha de ingreso: ColonizacionInfeccion_Localizacion");

                    }
                }
                if (!resultadoColonizacionInfeccion_Localizacion.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido los controles de ficha de ingreso: ColonizacionInfeccion_Localizacion: " + resultadoDiagnosticosENVIN.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoColonizacionInfeccion_Localizacion.MensajeError;
                }


                var resultadoColonizacionInfeccion_Tipo = wsENVIN.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo(codigoPrograma, idEjecucion, 0);
                if (resultadoColonizacionInfeccion_Tipo.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoColonizacionInfeccion_Tipo.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo != null && resultadoColonizacionInfeccion_Tipo.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles de ficha de ingreso: ColonizacionInfeccion_Tipo");

                        result.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo = resultadoColonizacionInfeccion_Tipo.get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado los controles de ficha de ingreso: ColonizacionInfeccion_Tipo");

                    }
                }
                if (!resultadoColonizacionInfeccion_Tipo.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido los controles de ficha de ingreso: ColonizacionInfeccion_Tipo: " + resultadoDiagnosticosENVIN.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoColonizacionInfeccion_Tipo.MensajeError;
                }

            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "FichaIngreso_ObtenerControles", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin FichaIngreso_ObtenerControles

        //obtencion de datos GETTERS Y SETTERS
        public ActionResult GET_FichaIngresoDatosAdmin(int idPaciente)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoDatosAdmin", new List<SICCA_Log.parametros>(), "Obteniendo datos administrativos de la ficha de ingreso ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_ENVIN_Paciente result = new Resultado_ENVIN_Paciente();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                if (idPaciente > 0) {//esto es para evitar que la funcion devuelva varios pacientes
                    var resultado = wsENVIN.get_wsENVIN_Web_Pacientes(codigoPrograma, idEjecucion, idPaciente);
                    if (resultado.EsCorrecto)
                    {
                        result.EsCorrecto = true;
                        if (resultado.get_wsENVIN_Web_Pacientes != null && resultado.get_wsENVIN_Web_Pacientes.Any())
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoDatosAdmin", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los datos administrativos");

                            result.get_wsENVIN_Web_Pacientes = resultado.get_wsENVIN_Web_Pacientes;
                            foreach (F_wsENVIN_Web_Pacientes_ViewModel elem in result.get_wsENVIN_Web_Pacientes)
                            {
                                elem.fechaNacimientoString = elem.FechaNacimiento.ToString("dd-MM-yyyy");//se pone el orden año mes dia para que el datepicker coja bien los datos
                            }
                        }
                        else
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoDatosAdmin", new List<SICCA_Log.parametros>(), "No se han encontrado los datos administrativos");

                        }
                    }
                    if (!resultado.EsCorrecto)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoDatosAdmin", new List<SICCA_Log.parametros>(), "No se han obtenido los datos administrativos: " + resultado.MensajeError);

                        result.EsCorrecto = false;
                        result.MensajeError = resultado.MensajeError;
                    }
                }
                else
                {
                    
                    result.EsCorrecto = false;
                    result.MensajeError = "Se debe proporcionar un id del paciente válido. ID proporcionado: " + idPaciente;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoDatosAdmin", new List<SICCA_Log.parametros>(), result.MensajeError);

                }

            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoDatosAdmin", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin GET_FichaIngresoDatosAdmin

        public ActionResult GET_FichaIngresoGeneral(int idPaciente)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoGeneral", new List<SICCA_Log.parametros>(), "Obteniendo datos generales de la ficha de ingreso ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_FichaIngresoGeneral result = new Resultado_FichaIngresoGeneral();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                if (idPaciente > 0)//esto es para evitar que la funcion devuelva varios pacientes
                {
                    var resultado = wsENVIN.get_wsENVIN_Web_FichaIngreso_General(codigoPrograma, idEjecucion, idPaciente);
                    if (resultado.EsCorrecto)
                    {
                        
                        result.EsCorrecto = true;
                        if (resultado.get_wsENVIN_Web_FichaIngreso_General != null && resultado.get_wsENVIN_Web_FichaIngreso_General.Any())
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoGeneral", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los datos generales");

                            result.get_wsENVIN_Web_FichaIngreso_General = resultado.get_wsENVIN_Web_FichaIngreso_General;
                        }
                        else
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoGeneral", new List<SICCA_Log.parametros>(), "No se han encontrado los datos generales");

                        }
                    }
                  
                    if (!resultado.EsCorrecto)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoGeneral", new List<SICCA_Log.parametros>(), "No se han obtenido los datos generales: " + resultado.MensajeError);

                        result.EsCorrecto = false;
                        result.MensajeError = resultado.MensajeError;
                    }
                }
                else
                {
                    result.EsCorrecto = false;
                    result.MensajeError = "Se debe proporcionar un id del paciente válido. ID proporcionado: " + idPaciente;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoGeneral", new List<SICCA_Log.parametros>(), result.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoGeneral", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin GET_FichaIngresoGeneral

        public ActionResult GET_FichaIngresoFactoresDeRiesgo(int idPaciente)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoFactoresDeRiesgo", new List<SICCA_Log.parametros>(), "Obteniendo factores de riesgo de la ficha de ingreso ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_FichaIngresoFactoresDeRiesgo result = new Resultado_FichaIngresoFactoresDeRiesgo();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                if (idPaciente > 0)//esto es para evitar que la funcion devuelva varios pacientes
                {
                    var resultado = wsENVIN.get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(codigoPrograma, idEjecucion, idPaciente);
                    if (resultado.EsCorrecto)
                    {
                        result.EsCorrecto = true;
                        if (resultado.get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo != null && resultado.get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo.Any())
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoFactoresDeRiesgo", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los factores de riesgo");

                            result.get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo = resultado.get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo;
                        }
                        else
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoFactoresDeRiesgo", new List<SICCA_Log.parametros>(), "No se han encontrado los factores de riesgo");

                        }
                    }
                    
                    if (!resultado.EsCorrecto)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoFactoresDeRiesgo", new List<SICCA_Log.parametros>(), "No se han obtenido los factores de riesgo: " + resultado.MensajeError);

                        result.EsCorrecto = false;
                        result.MensajeError = resultado.MensajeError;
                    }
                }
                else
                {

                    result.EsCorrecto = false;
                    result.MensajeError = "Se debe proporcionar un id del paciente válido. ID proporcionado: " + idPaciente;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoFactoresDeRiesgo", new List<SICCA_Log.parametros>(), result.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoFactoresDeRiesgo", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin GET_FichaIngresoFactoresDeRiesgo

        public ActionResult GET_FichaIngresoComorbilidadesPrevias(int idPaciente)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoComorbilidadesPrevias", new List<SICCA_Log.parametros>(), "Obteniendo comorbilidades previas de la ficha de ingreso ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_FichaIngresoComorbilidadesPrevias result = new Resultado_FichaIngresoComorbilidadesPrevias();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                if (idPaciente > 0)//esto es para evitar que la funcion devuelva varios pacientes
                {
                    var resultado = wsENVIN.get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(codigoPrograma, idEjecucion, idPaciente);
                    if (resultado.EsCorrecto)
                    {
                        result.EsCorrecto = true;
                        if (resultado.get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias != null && resultado.get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias.Any())
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoComorbilidadesPrevias", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente las comorbilidades previas");

                            result.get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias = resultado.get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias;
                        }
                        else
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoComorbilidadesPrevias", new List<SICCA_Log.parametros>(), "No se han encontrado las comorbilidades previas");

                        }
                    }
                    
                    if (!resultado.EsCorrecto)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoComorbilidadesPrevias", new List<SICCA_Log.parametros>(), "No se han obtenido las comorbilidades previas: " + resultado.MensajeError);

                        result.EsCorrecto = false;
                        result.MensajeError = resultado.MensajeError;
                    }
                }
                else
                {
                    result.EsCorrecto = false;
                    result.MensajeError = "Se debe proporcionar un id del paciente válido. ID proporcionado: "+idPaciente;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoComorbilidadesPrevias", new List<SICCA_Log.parametros>(), result.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoComorbilidadesPrevias", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin GET_FichaIngresoComorbilidadesPrevias


        public ActionResult GET_FichaIngresoColonizacionInfeccion(int idPaciente)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), "Obteniendo ColonizacionInfeccion de la ficha de ingreso ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_FichaIngresoColonizacionInfeccion result = new Resultado_FichaIngresoColonizacionInfeccion();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                if (idPaciente > 0)//esto es para evitar que la funcion devuelva varios pacientes
                {
                    var resultado = wsENVIN.get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(codigoPrograma, idEjecucion, idPaciente);
                    if (resultado.EsCorrecto)
                    {
                        result.EsCorrecto = true;
                        if (resultado.get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion != null && resultado.get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion.Any())
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente la ColonizacionInfeccion");

                            result.get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion = resultado.get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion;
                        }
                        else
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), "No se han encontrado la ColonizacionInfeccion");

                        }
                    }
                    
                    if (!resultado.EsCorrecto)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), "No se han obtenido la ColonizacionInfeccion: " + resultado.MensajeError);

                        result.EsCorrecto = false;
                        result.MensajeError = resultado.MensajeError;
                    }
                }
                else
                {
                    result.EsCorrecto = false;
                    result.MensajeError = "Se debe proporcionar un id del paciente válido. ID proporcionado: " + idPaciente;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), result.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin GET_FichaIngresoComorbilidadesPrevias


        //SPS
       


        public ActionResult SET_FichaIngresoSPFichaIngresoGeneral(int wsENVIN_Web_Pacientes_ID, short Apache_II, short Glasgow, Boolean PacienteTraumatizado, Boolean PacienteCoronario,
                Boolean ATB48hPrevias, Boolean PacienteCovid19, short wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID,
                short wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID, short wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID, short wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID,
                String IdUsuarioUltimaModificacion, String FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_General_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoGeneral", new List<SICCA_Log.parametros>(), "Inicio seteo de wsENVIN_Web_FichaIngreso_General: " + wsENVIN_Web_FichaIngreso_General_ID);

            Resultado_FichaIngresoSPFichaIngresoGeneral result = new Resultado_FichaIngresoSPFichaIngresoGeneral();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            
            
            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_Web_FichaIngreso_General(codigoPrograma, idEjecucion,  wsENVIN_Web_Pacientes_ID,  Apache_II,  Glasgow,  PacienteTraumatizado,  PacienteCoronario,
                 ATB48hPrevias,  PacienteCovid19,  wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID,
                 wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID,  wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID,  wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID,
                 IdUsuarioUltimaModificacion, compruebaFecha(FechaValidacion),  IdUsuarioValidacion,  wsENVIN_Web_FichaIngreso_General_ID);
                if (resultado.EsCorrecto && resultado.wsENVIN_Web_FichaIngreso_General_ID > 0)
                {
                    result.EsCorrecto = true;
                    result.wsENVIN_Web_FichaIngreso_General_ID = resultado.wsENVIN_Web_FichaIngreso_General_ID;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoGeneral", new List<SICCA_Log.parametros>(), "Se ha seteado correctamente el dato:  " + result.wsENVIN_Web_FichaIngreso_General_ID);

                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoGeneral", new List<SICCA_Log.parametros>(), "No se ha seteado correctamente el dato: " + resultado.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoGeneral", new List<SICCA_Log.parametros>(), msg);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//SET_FichaIngresoSPFichaIngresoGeneral


        public ActionResult SET_FichaIngresoSPFichaIngresoComorbilidades(int wsENVIN_Web_Pacientes_ID, Boolean Diabetes, Boolean InsuficienciaRenal, Boolean Inmunodepresion, Boolean Neoplasia, Boolean Cirrosis,
                Boolean EPOC, Boolean DesnutricionHipoalbuminemia, Boolean TransplanteOrganoSolido, String IdUsuarioUltimaModificacion, String FechaValidacion,
                String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoComorbilidades", new List<SICCA_Log.parametros>(), "Inicio seteo del dato: " + wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID);

            Resultado_FichaIngresoSPFichaIngresoComorbilidades result = new Resultado_FichaIngresoSPFichaIngresoComorbilidades();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
        

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(codigoPrograma, idEjecucion, wsENVIN_Web_Pacientes_ID, Diabetes, InsuficienciaRenal,
                                                        Inmunodepresion, Neoplasia, Cirrosis,
                                                    EPOC, DesnutricionHipoalbuminemia, TransplanteOrganoSolido, IdUsuarioUltimaModificacion, compruebaFecha(FechaValidacion),
                                                       IdUsuarioValidacion, wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID);
                if (resultado.EsCorrecto && resultado.wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID > 0)
                {
                    result.EsCorrecto = true;
                    result.wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID = resultado.wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoComorbilidades", new List<SICCA_Log.parametros>(), "Se ha seteado correctamente el dato:  " + result.wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID);

                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoComorbilidades", new List<SICCA_Log.parametros>(), "No se ha seteado correctamente el dato: " + resultado.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "SET_Pacientes", new List<SICCA_Log.parametros>(), msg);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//fin SET_FichaIngresoSPFichaIngresoComorbilidades

        public ActionResult SET_FichaIngresoSPFichaIngresoFactoresDeRiesgo(int wsENVIN_Web_Pacientes_ID, Boolean CirugiaUrgente, Boolean DerivacionVentricularExterna, Boolean DepuracionExtrarrenal,
               Boolean NutricionParenteral, Boolean Neutropenia, Boolean ECMO, Boolean CateterVenosoCentral, Boolean ViaAereaArtificial,
               Boolean SondaUrinaria, Boolean Impella, Boolean AsistenciaVentricular, Boolean BCIA, String IdUsuarioUltimaModificacion,
               String FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoFactoresDeRiesgo", new List<SICCA_Log.parametros>(), "Inicio seteo del dato: " + wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID);

            Resultado_FichaIngresoSPFichaIngresoFactoresDeRiesgo result = new Resultado_FichaIngresoSPFichaIngresoFactoresDeRiesgo();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
        

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(codigoPrograma, idEjecucion, wsENVIN_Web_Pacientes_ID, CirugiaUrgente, DerivacionVentricularExterna, DepuracionExtrarrenal,
                                            NutricionParenteral, Neutropenia, ECMO, CateterVenosoCentral, ViaAereaArtificial,
                                            SondaUrinaria, Impella, AsistenciaVentricular, BCIA, IdUsuarioUltimaModificacion,
                                             compruebaFecha(FechaValidacion), IdUsuarioValidacion, wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID);
                if (resultado.EsCorrecto && resultado.wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID > 0)
                {
                    result.EsCorrecto = true;
                    result.wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID = resultado.wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoFactoresDeRiesgo", new List<SICCA_Log.parametros>(), "Se ha seteado correctamente el dato:  " + result.wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID);

                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoFactoresDeRiesgo", new List<SICCA_Log.parametros>(), "No se ha seteado correctamente el dato: " + resultado.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "SET_Pacientes", new List<SICCA_Log.parametros>(), msg);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//fin SET_FichaIngresoSPFichaIngresoFactoresDeRiesgo


        public ActionResult SET_FichaIngresoSPFichaIngresoColonizacionInfeccion(int wsENVIN_Web_Pacientes_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID,
               int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID,
               String Fecha, String IdUsuarioUltimaModificacion,
               String FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), "Inicio seteo del dato: " + wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID);

            Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccion result = new Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccion();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
          

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(codigoPrograma, idEjecucion, wsENVIN_Web_Pacientes_ID, wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID, wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID,
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID, wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID,
                compruebaFecha(Fecha), IdUsuarioUltimaModificacion,
                 compruebaFecha(FechaValidacion), IdUsuarioValidacion, wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID);
                if (resultado.EsCorrecto && resultado.wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID > 0)
                {
                    result.EsCorrecto = true;
                    result.wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID = resultado.wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), "Se ha seteado correctamente el dato:  " + result.wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID);

                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), "No se ha seteado correctamente el dato: " + resultado.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), msg);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//fin SET_FichaIngresoSPFichaIngresoColonizacionInfeccion


        public ActionResult SET_FichaIngresoSPFichaIngresoColonizacionInfeccionDel( int wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoColonizacionInfeccionDel", new List<SICCA_Log.parametros>(), "Inicio borrado del dato: " + wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID);

            Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccionDel result = new Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccionDel();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
           

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del(codigoPrograma, idEjecucion, wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID);
                if (resultado.EsCorrecto && resultado.countRegistrosAfectados > 0)
                {
                    result.EsCorrecto = true;
                    result.countRegistrosAfectados = resultado.countRegistrosAfectados;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoColonizacionInfeccionDel", new List<SICCA_Log.parametros>(), "Se ha borrado correctamente el dato, numero de registros afectados :  " + result.countRegistrosAfectados);

                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FichaIngresoSPFichaIngresoColonizacionInfeccionDel", new List<SICCA_Log.parametros>(), "No se ha borrado correctamente el dato: " + resultado.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "SET_Pacientes", new List<SICCA_Log.parametros>(), msg);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//fin SET_FichaIngresoSPFichaIngresoColonizacionInfeccionDel

        #endregion

        #region Factores de riesgo individual

        public ActionResult ViewFactoresRiesgoIndividual()
        {
            return View();
        }//fin ViewFactoresRiesgoIndividual


        public ActionResult FactoresRiesgoIndividual_ObtenerControles(int wsENVIN_Web_Bloques_ID, int wsENVIN_Web_Controles_Grupos_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresRiesgoIndividual_ObtenerControles", new List<SICCA_Log.parametros>(), "Obteniendo controles de factoresde riesgo individual ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_BloquesControles result = new Resultado_BloquesControles();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();


                var resultadoBloquesControles = wsENVIN.get_wsENVIN_Web_Bloques_Controles(codigoPrograma, idEjecucion, wsENVIN_Web_Bloques_ID, wsENVIN_Web_Controles_Grupos_ID);
                if (resultadoBloquesControles.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoBloquesControles.get_wsENVIN_Web_Bloques_Controles != null && resultadoBloquesControles.get_wsENVIN_Web_Bloques_Controles.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresRiesgoIndividual_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles");

                        result.get_wsENVIN_Web_Bloques_Controles = resultadoBloquesControles.get_wsENVIN_Web_Bloques_Controles;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresRiesgoIndividual_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado los controles");

                    }
                }
               
                if (!resultadoBloquesControles.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresRiesgoIndividual_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido los controles: " + resultadoBloquesControles.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoBloquesControles.MensajeError;
                }


            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "FactoresRiesgoIndividual_ObtenerControles", new List<SICCA_Log.parametros>(), msg);
            }


            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin FactoresRiesgoIndividual_ObtenerControles

        public ActionResult GET_FactoresRiesgoIndividual(int idPaciente)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FactoresRiesgoIndividual", new List<SICCA_Log.parametros>(), "Obteniendo los factores de riesgo individual ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_FactoresRiesgoIndividual result = new Resultado_FactoresRiesgoIndividual();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                if (idPaciente > 0)//esto es para evitar que la funcion devuelva varios pacientes
                {
                    var resultado = wsENVIN.get_wsENVIN_Web_FactoresRiesgoIndividual(codigoPrograma, idEjecucion, idPaciente);
                    if (resultado.EsCorrecto)
                    {
                        result.EsCorrecto = true;
                        if (resultado.get_wsENVIN_Web_FactoresRiesgoIndividual != null && resultado.get_wsENVIN_Web_FactoresRiesgoIndividual.Any())
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FactoresRiesgoIndividual", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los factores de riesgo individual");

                            result.get_wsENVIN_Web_FactoresRiesgoIndividual = resultado.get_wsENVIN_Web_FactoresRiesgoIndividual;
                        }
                        else
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FactoresRiesgoIndividual", new List<SICCA_Log.parametros>(), "No se han encontrado factores de riesgo individual");

                        }
                    }
                    if (!resultado.EsCorrecto)
                    {
                        result.EsCorrecto = false;
                        result.MensajeError = resultado.MensajeError;
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FactoresRiesgoIndividual", new List<SICCA_Log.parametros>(), "No se han obtenido factores de riesgo individual: " + resultado.MensajeError);

                    }

                }
                else
                {
                    result.EsCorrecto = false;
                    result.MensajeError = "Se debe proporcionar un id del paciente válido. ID proporcionado: " + idPaciente;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_FactoresRiesgoIndividual", new List<SICCA_Log.parametros>(), result.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_FactoresRiesgoIndividual", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin GET_FichaIngresoGeneral

        public ActionResult SET_FactoresRiesgoIndividual(int wsENVIN_Web_Pacientes_ID, String Periodo1ViaAereaArtificial_Inicio, String Periodo1ViaAereaArtificial_Fin, String Periodo2ViaAereaArtificial_Inicio, String Periodo2ViaAereaArtificial_Fin,
                String Periodo3ViaAereaArtificial_Inicio, String Periodo3ViaAereaArtificial_Fin, String FechaInicioTraqueostomia,
                String Periodo1VMNI_Inicio, String Periodo1VMNI_Fin, String Periodo2VMNI_Inicio, String Periodo2VMNI_Fin, String Periodo3VMNI_Inicio,
                String Periodo3VMNI_Fin, String Fecha1Reintubacion, String Fecha2Reintubacion, String PeriodoSondaUrinaria_Inicio, String PeriodoSondaUrinaria_Fin,
                String Periodo1CVC_Inicio, String Periodo1CVC_Fin, String Periodo2CVC_Inicio, String Periodo2CVC_Fin,
                String Periodo3CVC_Inicio, String Periodo3CVC_Fin, String PeriodoCateterArterial_Inicio, String PeriodoCateterArterial_Fin,
                String PeriodoNutricionParenteral_Inicio, String PeriodoNutricionParenteral_Fin, String PeriodoNutricionEnteral_Inicio, String PeriodoNutricionEnteral_Fin,
                String ECMO_Inicio, String ECMO_Fin, String IdUsuarioUltimaModificacion, String FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FactoresRiesgoIndividual_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FactoresRiesgoIndividual", new List<SICCA_Log.parametros>(), "Inicio seteo de factores de riesgo individual: " + wsENVIN_Web_FactoresRiesgoIndividual_ID);

            Resultado_SPFactoresRiesgoIndividual result = new Resultado_SPFactoresRiesgoIndividual();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_Web_FactoresRiesgoIndividual(codigoPrograma, idEjecucion, wsENVIN_Web_Pacientes_ID,
                 compruebaFecha(Periodo1ViaAereaArtificial_Inicio), compruebaFecha(Periodo1ViaAereaArtificial_Fin), compruebaFecha(Periodo2ViaAereaArtificial_Inicio), compruebaFecha(Periodo2ViaAereaArtificial_Fin),
                 compruebaFecha(Periodo3ViaAereaArtificial_Inicio), compruebaFecha(Periodo3ViaAereaArtificial_Fin), compruebaFecha(FechaInicioTraqueostomia),
                 compruebaFecha(Periodo1VMNI_Inicio), compruebaFecha(Periodo1VMNI_Fin), compruebaFecha(Periodo2VMNI_Inicio), compruebaFecha(Periodo2VMNI_Fin), compruebaFecha(Periodo3VMNI_Inicio),
                 compruebaFecha(Periodo3VMNI_Fin), compruebaFecha(Fecha1Reintubacion), compruebaFecha(Fecha2Reintubacion), compruebaFecha(PeriodoSondaUrinaria_Inicio), compruebaFecha(PeriodoSondaUrinaria_Fin),
                 compruebaFecha(Periodo1CVC_Inicio), compruebaFecha(Periodo1CVC_Fin), compruebaFecha(Periodo2CVC_Inicio), compruebaFecha(Periodo2CVC_Fin),
                 compruebaFecha(Periodo3CVC_Inicio), compruebaFecha(Periodo3CVC_Fin), compruebaFecha(PeriodoCateterArterial_Inicio), compruebaFecha(PeriodoCateterArterial_Fin),
                 compruebaFecha(PeriodoNutricionParenteral_Inicio), compruebaFecha(PeriodoNutricionParenteral_Fin), compruebaFecha(PeriodoNutricionEnteral_Inicio), compruebaFecha(PeriodoNutricionEnteral_Fin),
                 compruebaFecha(ECMO_Inicio), compruebaFecha(ECMO_Fin), IdUsuarioUltimaModificacion, compruebaFecha(FechaValidacion), IdUsuarioValidacion, wsENVIN_Web_FactoresRiesgoIndividual_ID);
                if (resultado.EsCorrecto && resultado.wsENVIN_Web_FactoresRiesgoIndividual_ID > 0)
                {
                    result.EsCorrecto = true;
                    result.wsENVIN_Web_FactoresRiesgoIndividual_ID = resultado.wsENVIN_Web_FactoresRiesgoIndividual_ID;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FactoresRiesgoIndividual", new List<SICCA_Log.parametros>(), "Se ha seteado correctamente los factores de riesgo individual:  " + result.wsENVIN_Web_FactoresRiesgoIndividual_ID);

                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FactoresRiesgoIndividual", new List<SICCA_Log.parametros>(), "No se ha seteado correctamente los factores de riesgo individual: " + resultado.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "SET_Pacientes", new List<SICCA_Log.parametros>(), msg);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//SET_FactoresRiesgoIndividual


        #endregion

        #region Antibioticos

       

        public ActionResult ViewAntibioticos()
        {//aqui añadir la linea con el viewmodel y devuelvo dentro del view()
            return View();
        }
        public ActionResult Antibioticos_ObtenerControlesListas()
        {
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_Antibioticos_ObtenerControlesListas result = new Resultado_Antibioticos_ObtenerControlesListas();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();


                var resultadoListaCambioDeAntibiotico = wsENVIN.get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico(codigoPrograma, idEjecucion, 0);
                if (resultadoListaCambioDeAntibiotico.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoListaCambioDeAntibiotico.get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico != null && resultadoListaCambioDeAntibiotico.get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico.Any())
                    {
                        result.get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico = resultadoListaCambioDeAntibiotico.get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico;
                    }
                }
                if (!resultadoListaCambioDeAntibiotico.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultadoListaCambioDeAntibiotico.MensajeError;
                }

                var resultadoListaATBconfirmacion = wsENVIN.get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion(codigoPrograma, idEjecucion, 0);
                if (resultadoListaATBconfirmacion.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoListaATBconfirmacion.get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion != null && resultadoListaATBconfirmacion.get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion.Any())
                    {
                        result.get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion = resultadoListaATBconfirmacion.get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion;
                    }
                }
                if (!resultadoListaATBconfirmacion.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultadoListaATBconfirmacion.MensajeError;
                }


                var resultadoListaATBindicacion = wsENVIN.get_wsENVIN_Web_Maestro_Antibioticos_Indicacion(codigoPrograma, idEjecucion, 0);
                if (resultadoListaATBindicacion.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoListaATBindicacion.get_wsENVIN_Web_Maestro_Antibioticos_Indicacion != null && resultadoListaATBindicacion.get_wsENVIN_Web_Maestro_Antibioticos_Indicacion.Any())
                    {
                        result.get_wsENVIN_Web_Maestro_Antibioticos_Indicacion = resultadoListaATBindicacion.get_wsENVIN_Web_Maestro_Antibioticos_Indicacion;
                    }
                }
                if (!resultadoListaATBindicacion.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultadoListaATBindicacion.MensajeError;
                }

                var resultadoATBmotivo = wsENVIN.get_wsENVIN_Web_Maestro_Antibioticos_Motivo(codigoPrograma, idEjecucion, 0);
                if (resultadoATBmotivo.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoATBmotivo.get_wsENVIN_Web_Maestro_Antibioticos_Motivo != null && resultadoATBmotivo.get_wsENVIN_Web_Maestro_Antibioticos_Motivo.Any())
                    {
                        result.get_wsENVIN_Web_Maestro_Antibioticos_Motivo = resultadoATBmotivo.get_wsENVIN_Web_Maestro_Antibioticos_Motivo;
                    }
                }
                if (!resultadoATBmotivo.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultadoATBmotivo.MensajeError;
                }

                var resultadoATBmotivoCambio = wsENVIN.get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio(codigoPrograma, idEjecucion, 0);
                if (resultadoATBmotivoCambio.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoATBmotivoCambio.get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio != null && resultadoATBmotivoCambio.get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio.Any())
                    {
                        result.get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio = resultadoATBmotivoCambio.get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio;
                    }
                }
                if (!resultadoATBmotivoCambio.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultadoATBmotivoCambio.MensajeError;
                }


                var resultadoListaInfeccionesLocalizacion = wsENVIN.get_wsENVIN_Web_Maestro_Infecciones_Localizacion(codigoPrograma, idEjecucion);
                if (resultadoListaInfeccionesLocalizacion.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoListaInfeccionesLocalizacion.get_wsENVIN_Web_Maestro_Infecciones_Localizacion != null && resultadoListaInfeccionesLocalizacion.get_wsENVIN_Web_Maestro_Infecciones_Localizacion.Any())
                    {
                        result.get_wsENVIN_Web_Maestro_Infecciones_Localizacion = resultadoListaInfeccionesLocalizacion.get_wsENVIN_Web_Maestro_Infecciones_Localizacion;
                    }
                }
                if (!resultadoListaInfeccionesLocalizacion.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultadoListaInfeccionesLocalizacion.MensajeError;
                }

            }
            catch (Exception e)
            {
                result.EsCorrecto = false;
                result.MensajeError = e.Message;
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin FichaIngreso_ObtenerControles

        public ActionResult GET_Antibioticos(int idPaciente)
        {
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_Antibioticos result = new Resultado_Antibioticos();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                if (idPaciente > 0)
                {//esto es para evitar que la funcion devuelva varios pacientes
                    var resultado = wsENVIN.get_wsENVIN_Web_Antibioticos(codigoPrograma, idEjecucion, idPaciente);
                    if (resultado.EsCorrecto)
                    {
                        result.EsCorrecto = true;
                        if (resultado.get_wsENVIN_Web_Antibioticos != null && resultado.get_wsENVIN_Web_Antibioticos.Any())
                        {
                            result.get_wsENVIN_Web_Antibioticos = resultado.get_wsENVIN_Web_Antibioticos;
                           
                        }
                    }
                    if (!resultado.EsCorrecto)
                    {
                        result.EsCorrecto = false;
                        result.MensajeError = resultado.MensajeError;
                    }
                }
                else
                {
                    result.EsCorrecto = false;
                    result.MensajeError = "Se debe proporcionar un id del paciente válido. ID proporcionado: " + idPaciente;
                }

            }
            catch (Exception e)
            {
                result.EsCorrecto = false;
                result.MensajeError = e.Message;
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin GET_FichaIngresoDatosAdmin

        public ActionResult SET_Antibioticos(int wsENVIN_Web_Pacientes_ID, int LogicalUnitID, int PlannedOrderID, String Antibiotico, String FechaInicio,
                 String FechaFin, int wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID, int wsENVIN_Web_Maestro_Infecciones_Localizacion_ID,
                 int wsENVIN_Web_Maestro_Antibioticos_Motivo_ID, int wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID, int wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID,
                 int wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID, String IdUsuarioUltimaModificacion,
                 String FechaValidacion, String IdUsuarioValidacion, bool Estado, int wsENVIN_Web_Antibioticos_ID)
        {

            Resultado_SPAntibioticos result = new Resultado_SPAntibioticos();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];


            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_Web_Antibioticos(codigoPrograma, idEjecucion, wsENVIN_Web_Pacientes_ID, LogicalUnitID, PlannedOrderID, Antibiotico, compruebaFecha(FechaInicio),
                  compruebaFecha(FechaFin), wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID, wsENVIN_Web_Maestro_Infecciones_Localizacion_ID,
                  wsENVIN_Web_Maestro_Antibioticos_Motivo_ID, wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID, wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID,
                  wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID, IdUsuarioUltimaModificacion,
                  compruebaFecha(FechaValidacion), IdUsuarioValidacion, Estado, wsENVIN_Web_Antibioticos_ID);
                if (resultado.EsCorrecto && resultado.wsENVIN_Web_Antibioticos_ID > 0)
                {
                    result.EsCorrecto = true;
                    result.wsENVIN_Web_Antibioticos_ID = resultado.wsENVIN_Web_Antibioticos_ID;
                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                result.EsCorrecto = false;
                result.MensajeError = e.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//SET_Antibioticos


        //esto he hecho nuevo porque faltaba el DEL
        public ActionResult SET_AntibioticosDel(int wsENVIN_Web_Antibioticos_ID)
        {

            Resultado_SPAntibioticosDel result = new Resultado_SPAntibioticosDel();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];


            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_Web_Antibioticos_Del(codigoPrograma, idEjecucion, wsENVIN_Web_Antibioticos_ID);
                if (resultado.EsCorrecto && resultado.countRegistrosAfectados > 0)
                {
                    result.EsCorrecto = true;
                    result.countRegistrosAfectados = resultado.countRegistrosAfectados;
                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                result.EsCorrecto = false;
                result.MensajeError = e.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//fin SET_AntibioticosDel


        #endregion

        #region Infecciones
        public ActionResult ViewInfecciones()
        {//aqui añadir la linea con el viewmodel y devuelvo dentro del view()
            return View();
        }

        public ActionResult ObtenerInfeccionesPaciente(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerInfeccionesPaciente", new List<SICCA_Log.parametros>(), "Obteniendo infecciones de paciente: " + wsENVIN_Web_Pacientes_ID);
            Resultado_ENVINInfecciones result = new Resultado_ENVINInfecciones();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Infecciones(codigoPrograma, idEjecucion, wsENVIN_Web_Pacientes_ID);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Infecciones != null && resultado.get_wsENVIN_Web_Infecciones.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerInfeccionesPaciente", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Infecciones.Count + " infecciones");
                        result.get_wsENVIN_Web_Infecciones = resultado.get_wsENVIN_Web_Infecciones;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerInfeccionesPaciente", new List<SICCA_Log.parametros>(), "No se han obtenido infecciones: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerInfeccionesPaciente", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;  
        }

        public ActionResult ObtenerMaestroOrigenInfeccion()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroOrigenInfeccion", new List<SICCA_Log.parametros>(), "Obteniendo maestro origen infeccion ");
            Resultado_ENVINMaestro_OrigenInfeccion result = new Resultado_ENVINMaestro_OrigenInfeccion();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion(codigoPrograma, idEjecucion);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion != null && resultado.get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroOrigenInfeccion", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion.Count + " opciones");
                        result.get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion = resultado.get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroOrigenInfeccion", new List<SICCA_Log.parametros>(), "No se han obtenido maestro origen infección: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroOrigenInfeccion", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerMaestroLocalizacionInfeccion()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroLocalizacionInfeccion", new List<SICCA_Log.parametros>(), "Obteniendo maestro localizacion infeccion");
            Resultado_ENVINMaestro_Localizacion result = new Resultado_ENVINMaestro_Localizacion();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Infecciones_Localizacion(codigoPrograma, idEjecucion);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Infecciones_Localizacion != null && resultado.get_wsENVIN_Web_Maestro_Infecciones_Localizacion.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroLocalizacionInfeccion", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Infecciones_Localizacion.Count + " opciones");
                        result.get_wsENVIN_Web_Maestro_Infecciones_Localizacion = resultado.get_wsENVIN_Web_Maestro_Infecciones_Localizacion;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroLocalizacionInfeccion", new List<SICCA_Log.parametros>(), "No se han obtenido maestro localizacion infeccion: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroLocalizacionInfeccion", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerMaestroMuestraInfeccion(int tipoMuestra)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMuestraInfeccion", new List<SICCA_Log.parametros>(), "Obteniendo maestro muestra infeccion");
            Resultado_ENVINMaestro_Muestra result = new Resultado_ENVINMaestro_Muestra();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Infecciones_Muestra(codigoPrograma, idEjecucion);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Infecciones_Muestra != null && resultado.get_wsENVIN_Web_Maestro_Infecciones_Muestra.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMuestraInfeccion", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Infecciones_Muestra.Count + " opciones");
                        var filtradoMuestra = resultado.get_wsENVIN_Web_Maestro_Infecciones_Muestra.Where(a => a.TipoMuestra == tipoMuestra).ToList();
                        result.get_wsENVIN_Web_Maestro_Infecciones_Muestra = filtradoMuestra;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMuestraInfeccion", new List<SICCA_Log.parametros>(), "No se han obtenido maestro muestra infeccion: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMuestraInfeccion", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerMaestroDiagnosticoClinico()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroDiagnosticoClinico", new List<SICCA_Log.parametros>(), "Obteniendo maestro diagnostico clinico");
            Resultado_ENVINMaestro_DiagnosticoClinico result = new Resultado_ENVINMaestro_DiagnosticoClinico();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico(codigoPrograma, idEjecucion);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico != null && resultado.get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroDiagnosticoClinico", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico.Count + " opciones");
                        result.get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico = resultado.get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroDiagnosticoClinico", new List<SICCA_Log.parametros>(), "No se han obtenido maestro diagnostico clinico: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroDiagnosticoClinico", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerMaestroRespuestaInflamatoria()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroRespuestaInflamatoria", new List<SICCA_Log.parametros>(), "Obteniendo maestro respuesta inflamatoria");
            Resultado_ENVINMaestro_RespuestaInflamatoria result = new Resultado_ENVINMaestro_RespuestaInflamatoria();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria(codigoPrograma, idEjecucion);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria != null && resultado.get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroRespuestaInflamatoria", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria.Count + " opciones");
                        result.get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria = resultado.get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroRespuestaInflamatoria", new List<SICCA_Log.parametros>(), "No se han obtenido maestro respuesta inflamatoria: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroRespuestaInflamatoria", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerMaestroTipoCateter()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroTipoCateter", new List<SICCA_Log.parametros>(), "Obteniendo maestro tipo cateter");
            Resultado_ENVINMaestro_TipoCateter result = new Resultado_ENVINMaestro_TipoCateter();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Infecciones_TipoCateter(codigoPrograma, idEjecucion);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Infecciones_TipoCateter != null && resultado.get_wsENVIN_Web_Maestro_Infecciones_TipoCateter.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroTipoCateter", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Infecciones_TipoCateter.Count + " infecciones");
                        result.get_wsENVIN_Web_Maestro_Infecciones_TipoCateter = resultado.get_wsENVIN_Web_Maestro_Infecciones_TipoCateter;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroTipoCateter", new List<SICCA_Log.parametros>(), "No se han obtenido maestro tipo cateter: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroTipoCateter", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerMaestroLugarInsercion()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroLugarInsercion", new List<SICCA_Log.parametros>(), "Obteniendo maestro lugar insercion");
            Resultado_ENVINMaestro_Lugar result = new Resultado_ENVINMaestro_Lugar();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Infecciones_Lugar(codigoPrograma, idEjecucion);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Infecciones_Lugar != null && resultado.get_wsENVIN_Web_Maestro_Infecciones_Lugar.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroLugarInsercion", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Infecciones_Lugar.Count + " opciones");
                        result.get_wsENVIN_Web_Maestro_Infecciones_Lugar = resultado.get_wsENVIN_Web_Maestro_Infecciones_Lugar;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroLugarInsercion", new List<SICCA_Log.parametros>(), "No se han obtenido maestro lugar insercion: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroLugarInsercion", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerMaestroMicroorganismos()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMicroorganismos", new List<SICCA_Log.parametros>(), "Obteniendo maestro microorganismos");
            Resultado_ENVINMaestro_Microorganismos result = new Resultado_ENVINMaestro_Microorganismos();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Microorganismos(codigoPrograma, idEjecucion);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Microorganismos != null && resultado.get_wsENVIN_Web_Maestro_Microorganismos.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMicroorganismos", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Microorganismos.Count + " opciones");
                        result.get_wsENVIN_Web_Maestro_Microorganismos = resultado.get_wsENVIN_Web_Maestro_Microorganismos;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMicroorganismos", new List<SICCA_Log.parametros>(), "No se han obtenido maestro microorganismos: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMicroorganismos", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerMaestroMicroorganismosUFC10()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMicroorganismosUFC10", new List<SICCA_Log.parametros>(), "Obteniendo maestro microorganismos UFC10");
            Resultado_ENVINMaestro_MicroorganismosUFC10 result = new Resultado_ENVINMaestro_MicroorganismosUFC10();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Microorganismos_UFC_10(codigoPrograma, idEjecucion);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Microorganismos_UFC_10 != null && resultado.get_wsENVIN_Web_Maestro_Microorganismos_UFC_10.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMicroorganismosUFC10", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Microorganismos_UFC_10.Count + " opciones");
                        result.get_wsENVIN_Web_Maestro_Microorganismos_UFC_10 = resultado.get_wsENVIN_Web_Maestro_Microorganismos_UFC_10;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMicroorganismosUFC10", new List<SICCA_Log.parametros>(), "No se han obtenido maestro microorganismos UFC10: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroMicroorganismosUFC10", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerMaestroResistencia()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroResistencia", new List<SICCA_Log.parametros>(), "Obteniendo maestro resistencia de antibiogramas");
            Resultado_ENVINMaestro_Antibiogramas_Resistencia result = new Resultado_ENVINMaestro_Antibiogramas_Resistencia();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia(codigoPrograma, idEjecucion);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia != null && resultado.get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroResistencia", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia.Count + " opciones");
                        result.get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia = resultado.get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroResistencia", new List<SICCA_Log.parametros>(), "No se han obtenido maestro resistencia de antibiogramas: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMaestroResistencia", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerMicroorganismosInfeccion(int wsENVIN_Web_Infecciones_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMicroorganismosInfeccion", new List<SICCA_Log.parametros>(), "Obteniendo microorganismos de la infección");
            Resultado_ENVINMicroorganismos result = new Resultado_ENVINMicroorganismos();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Microorganismos(codigoPrograma, idEjecucion, wsENVIN_Web_Infecciones_ID);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion != null && resultado.get_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMicroorganismosInfeccion", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion.Count + " opciones");
                        result.get_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion = resultado.get_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerMicroorganismosInfeccion", new List<SICCA_Log.parametros>(), "No se han obtenido maestro microorganismos UFC10: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerMicroorganismosInfeccion", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerAntibiograma(int wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismos)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerAntibiograma", new List<SICCA_Log.parametros>(), "Obteniendo antibiograma del microorganismo");
            Resultado_ENVINInfecciones_Antibiogramas result = new Resultado_ENVINInfecciones_Antibiogramas();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo(codigoPrograma, idEjecucion, wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismos);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo != null && resultado.get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerAntibiograma", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo.Count + " opciones");
                        result.get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo = resultado.get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo;
                    }
                    else
                    {
                        result.get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo = new List<F_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo_ViewModel>();
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerAntibiograma", new List<SICCA_Log.parametros>(), "No se han obtenido maestro microorganismos UFC10: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerAntibiograma", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult ObtenerGrupoMicroorganismo(int wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerGrupoMicroorganismo", new List<SICCA_Log.parametros>(), "Obteniendo grupo de microorganismos para antibiograma");
            Resultado_ENVINMaestro_MicroorganismosGrupoMicroorganismosAntibiogramasIDGrupo result = new Resultado_ENVINMaestro_MicroorganismosGrupoMicroorganismosAntibiogramasIDGrupo();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo(codigoPrograma, idEjecucion, wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo != null && resultado.get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerGrupoMicroorganismo", new List<SICCA_Log.parametros>(), "Obtenidas: " + resultado.get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo.Count + " opciones");
                        result.get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo = resultado.get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "ObtenerGrupoMicroorganismo", new List<SICCA_Log.parametros>(), "No se han obtenido grupo de microorganismos para antibiograma: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "ObtenerGrupoMicroorganismo", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }
        
        public ActionResult GuardarInfeccion(int wsENVIN_Web_Pacientes_ID, short wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID, short wsENVIN_Web_Maestro_Infecciones_Localizacion_ID, bool bacteriemia, short wsENVIN_Web_Maestro_Infecciones_Muestra_ID,
                                            short wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID, bool exposicion48hprevias, bool tratamientoAntibiotico, bool tratamientoApropiado, bool ajusteTratamiento, short wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID,
                                            short wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID, short wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID, String idUsuarioUltimaModificacion, String fechaValidacion, String idUsuarioValidacion, String fechaInfeccion, int wsENVIN_Web_Infecciones_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GuardarInfeccion", new List<SICCA_Log.parametros>(), "Guardando infeccion");
            Resultado_SPInfecciones result = new Resultado_SPInfecciones();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            DateTime fechaInfeccionDT = compruebaFecha(fechaInfeccion);
            DateTime fechaValidacionDT = compruebaFecha(fechaValidacion);
            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_wsENVIN_Infecciones(codigoPrograma, idEjecucion, wsENVIN_Web_Pacientes_ID, wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID, wsENVIN_Web_Maestro_Infecciones_Localizacion_ID, bacteriemia, wsENVIN_Web_Maestro_Infecciones_Muestra_ID,
                    wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID, exposicion48hprevias, tratamientoAntibiotico, tratamientoApropiado, ajusteTratamiento, wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID,
                    wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID, wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID, idUsuarioUltimaModificacion, fechaValidacionDT, idUsuarioValidacion, fechaInfeccionDT, wsENVIN_Web_Infecciones_ID);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.wsENVIN_Web_Infecciones_ID > 0)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GuardarInfeccion", new List<SICCA_Log.parametros>(), "Guardada infección: " + resultado.wsENVIN_Web_Infecciones_ID);
                        result.wsENVIN_Web_Infecciones_ID = resultado.wsENVIN_Web_Infecciones_ID;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GuardarInfeccion", new List<SICCA_Log.parametros>(), "No se ha guardado la infección: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GuardarInfeccion", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult GuardarAntibiograma(int wsENVIN_Web_Infecciones_Microorganismos_ID, short wsENVIN_Web_Maestro_Antibiogramas_ID, short wsENVIN_Web_Pacientes_ID, short wsENVN_Web_Maestro_Antibiogramas_Resistencia_ID,
               String idUsuarioUltimaModificacion, String fechaValidacion, String idUsuarioValidacion, int? wsENVIN_Web_Infecciones_Antibiogramas_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GuardarAntibiograma", new List<SICCA_Log.parametros>(), "Guardando antibiograma");
            Resultado_SPAntibiograma result = new Resultado_SPAntibiograma();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            DateTime fechaValidacionDT = fechaValidacion == "" ? new DateTime(1971, 1, 1, 0, 0, 0) : Convert.ToDateTime(fechaValidacion);
            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_wsENVIN_Infecciones_Antibiograma(codigoPrograma, idEjecucion, wsENVIN_Web_Infecciones_Microorganismos_ID, wsENVIN_Web_Maestro_Antibiogramas_ID, wsENVIN_Web_Pacientes_ID, wsENVN_Web_Maestro_Antibiogramas_Resistencia_ID,
                                                                            idUsuarioUltimaModificacion, fechaValidacionDT, idUsuarioValidacion, wsENVIN_Web_Infecciones_Antibiogramas_ID);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.wsENVIN_Web_Infecciones_Antibiogramas_ID > 0)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GuardarAntibiograma", new List<SICCA_Log.parametros>(), "Guardado antibiograma: " + resultado.wsENVIN_Web_Infecciones_Antibiogramas_ID);
                        result.wsENVIN_Web_Infecciones_Antibiogramas_ID = resultado.wsENVIN_Web_Infecciones_Antibiogramas_ID;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GuardarAntibiograma", new List<SICCA_Log.parametros>(), "No se ha guardado el antibiograma: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GuardarAntibiograma", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult GuardarMicroorganismo(int wsENVIN_Web_Infecciones_ID, short wsENVIN_Web_Maestro_Microorganismos_ID, short wsENVIN_Web_Pacientes_ID, int wsENVIN_Web_Maestro_Microorganismos_UFC_ID, String idUsuarioUltimaModificacion,
               String fechaValidacion, String idUsuarioValidacion, int wsENVIN_Web_Infecciones_Microorganismos_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GuardarMicroorganismo", new List<SICCA_Log.parametros>(), "Guardando antibiograma");
            Resultado_SPMicroorganismo result = new Resultado_SPMicroorganismo();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            DateTime fechaValidacionDT = fechaValidacion == "" ? new DateTime(1971, 1, 1, 0, 0, 0) : Convert.ToDateTime(fechaValidacion);
            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_wsENVIN_Infecciones_Microrgarnismos(codigoPrograma, idEjecucion, wsENVIN_Web_Infecciones_ID, wsENVIN_Web_Maestro_Microorganismos_ID, wsENVIN_Web_Pacientes_ID, wsENVIN_Web_Maestro_Microorganismos_UFC_ID,
                                                                                idUsuarioUltimaModificacion, fechaValidacionDT, idUsuarioValidacion, wsENVIN_Web_Infecciones_Microorganismos_ID);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.wsENVIN_Web_Infecciones_Microorganismos_ID > 0)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GuardarMicroorganismo", new List<SICCA_Log.parametros>(), "Guardado antibiograma: " + resultado.wsENVIN_Web_Infecciones_Microorganismos_ID);
                        result.wsENVIN_Web_Infecciones_Microorganismos_ID = resultado.wsENVIN_Web_Infecciones_Microorganismos_ID;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GuardarMicroorganismo", new List<SICCA_Log.parametros>(), "No se ha guardado el antibiograma: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GuardarMicroorganismo", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult BorrarInfeccion(int wsENVIN_Web_Infecciones_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "BorrarInfeccion", new List<SICCA_Log.parametros>(), "Borrando infeccion: " + wsENVIN_Web_Infecciones_ID);
            Resultado_SPInfeccionesDel result = new Resultado_SPInfeccionesDel();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_wsENVIN_Infecciones_Del(codigoPrograma, idEjecucion, wsENVIN_Web_Infecciones_ID);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.countRegistrosAfectados > 0)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "BorrarInfeccion", new List<SICCA_Log.parametros>(), "Borrados: " + resultado.countRegistrosAfectados + " registros");
                        result.countRegistrosAfectados = resultado.countRegistrosAfectados;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "BorrarInfeccion", new List<SICCA_Log.parametros>(), "No se ha borrado la infección: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "BorrarInfeccion", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }

        public ActionResult BorrarMicroorganismo(int wsENVIN_Web_Infecciones_Microorganismo_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "BorrarMicroorganismo", new List<SICCA_Log.parametros>(), "Borrando microorganismo: " + wsENVIN_Web_Infecciones_Microorganismo_ID);
            Resultado_SPInfeccionesDel result = new Resultado_SPInfeccionesDel();
            result.EsCorrecto = false;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_wsENVIN_Infecciones_Microrgarnismos_Del(codigoPrograma, idEjecucion, wsENVIN_Web_Infecciones_Microorganismo_ID);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.countRegistrosAfectados > 0)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "BorrarMicroorganismo", new List<SICCA_Log.parametros>(), "Borrados: " + resultado.countRegistrosAfectados + " registros");
                        result.countRegistrosAfectados = resultado.countRegistrosAfectados;
                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "BorrarMicroorganismo", new List<SICCA_Log.parametros>(), "No se ha borrado el microorganismo: " + resultado.MensajeError);
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "BorrarMicroorganismo", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }
        #endregion
        #region tabla de factores mensuales

        public ActionResult ViewTablaFactoresMensuales()
        {
            return View();
        }//fin ViewTablaFactoresMensuales


        public ActionResult FactoresMensuales_ObtenerControles()
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresMensuales_ObtenerControles", new List<SICCA_Log.parametros>(), "Obteniendo controles de tabla mensual de factores ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_MaestroFactoresMensuales result = new Resultado_MaestroFactoresMensuales();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();

                var resultadoMeses = wsENVIN.get_wsENVIN_Web_Maestro_FactoresMensuales_Meses(codigoPrograma, idEjecucion, 0);
                if (resultadoMeses.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoMeses.get_wsENVIN_Web_Maestro_FactoresMensuales_Meses != null && resultadoMeses.get_wsENVIN_Web_Maestro_FactoresMensuales_Meses.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresMensuales_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles de meses");

                        result.get_wsENVIN_Web_Maestro_FactoresMensuales_Meses = resultadoMeses.get_wsENVIN_Web_Maestro_FactoresMensuales_Meses;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresMensuales_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado controles de meses");

                    }
                }
                if (!resultadoMeses.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresMensuales_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido controles de meses: " + resultadoMeses.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoMeses.MensajeError;
                }

                var resultadoAnnos = wsENVIN.get_wsENVIN_Web_Maestro_FactoresMensuales_Annos(codigoPrograma, idEjecucion, 0);
                if (resultadoAnnos.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultadoAnnos.get_wsENVIN_Web_Maestro_FactoresMensuales_Annos != null && resultadoAnnos.get_wsENVIN_Web_Maestro_FactoresMensuales_Annos.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresMensuales_ObtenerControles", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los controles de annos");
                        result.get_wsENVIN_Web_Maestro_FactoresMensuales_Annos = resultadoAnnos.get_wsENVIN_Web_Maestro_FactoresMensuales_Annos;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresMensuales_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han encontrado controles de annos");

                    }
                }
                if (!resultadoAnnos.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "FactoresMensuales_ObtenerControles", new List<SICCA_Log.parametros>(), "No se han obtenido controles de annos: " + resultadoAnnos.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultadoAnnos.MensajeError;
                }

            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_FichaIngresoColonizacionInfeccion", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin FactoresMensuales_ObtenerControles

        public ActionResult GET_wsENVIN_Web_FactoresMensuales( int LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_wsENVIN_Web_FactoresMensuales", new List<SICCA_Log.parametros>(), "Obteniendo factores mensuales ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_FactoresMensuales result = new Resultado_FactoresMensuales();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
               
                    var resultado = wsENVIN.get_wsENVIN_Web_FactoresMensuales(codigoPrograma, idEjecucion, LogicalUnitID, wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);
                    if (resultado.EsCorrecto)
                    {
                        result.EsCorrecto = true;
                        if (resultado.get_wsENVIN_Web_FactoresMensuales != null && resultado.get_wsENVIN_Web_FactoresMensuales.Any()){
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_wsENVIN_Web_FactoresMensuales", new List<SICCA_Log.parametros>(), "Se han obtenido correctamente los factores mensuales");

                            result.get_wsENVIN_Web_FactoresMensuales = resultado.get_wsENVIN_Web_FactoresMensuales;
                        }
                        else
                        {
                            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_wsENVIN_Web_FactoresMensuales", new List<SICCA_Log.parametros>(), "No se han encontrado los factores mensuales");

                        }
                    }
                    if (!resultado.EsCorrecto)
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_wsENVIN_Web_FactoresMensuales", new List<SICCA_Log.parametros>(), "No se han obtenido los factores mensuales: " + resultado.MensajeError);

                        result.EsCorrecto = false;
                        result.MensajeError = resultado.MensajeError;
                    }
                
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_wsENVIN_Web_FactoresMensuales", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin GET_wsENVIN_Web_FactoresMensuales


        public ActionResult GET_wsENVIN_Web_FactoresMensuales_SumatorioMensual(int LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_wsENVIN_Web_FactoresMensuales_SumatorioMensual", new List<SICCA_Log.parametros>(), "Obteniendo el sumatorio de factores mensuales ");

            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];
            Resultado_FactoresMensuales_SumatorioMensual result = new Resultado_FactoresMensuales_SumatorioMensual();

            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();

                var resultado = wsENVIN.get_wsENVIN_Web_FactoresMensuales_SumatorioMensual(codigoPrograma, idEjecucion, LogicalUnitID, wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);
                if (resultado.EsCorrecto)
                {
                    result.EsCorrecto = true;
                    if (resultado.get_wsENVIN_Web_FactoresMensuales_SumatorioMensual != null && resultado.get_wsENVIN_Web_FactoresMensuales_SumatorioMensual.Any())
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_wsENVIN_Web_FactoresMensuales_SumatorioMensual", new List<SICCA_Log.parametros>(), "Se ha obtenido correctamente el sumatorio de factores mensuales ");

                        result.get_wsENVIN_Web_FactoresMensuales_SumatorioMensual = resultado.get_wsENVIN_Web_FactoresMensuales_SumatorioMensual;
                    }
                    else
                    {
                        SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_wsENVIN_Web_FactoresMensuales_SumatorioMensual", new List<SICCA_Log.parametros>(), "No se han encontrado el sumatorio de factores mensuales ");

                    }
                }
                if (!resultado.EsCorrecto)
                {
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "GET_wsENVIN_Web_FactoresMensuales_SumatorioMensual", new List<SICCA_Log.parametros>(), "No se han obtenido el sumatorio de factores mensuales : " + resultado.MensajeError);

                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                }

            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "GET_wsENVIN_Web_FactoresMensuales_SumatorioMensual", new List<SICCA_Log.parametros>(), msg);
            }

            JsonResult json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 867530900;
            return json;
        }//fin GET_wsENVIN_Web_FactoresMensuales_SumatorioMensual


        public ActionResult SET_FactoresMensualesSumatorioMensual(short LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID,
               short NumPacientesIngresados, short NumPacientesNuevos,
                short NumPacientesConATB,
                short NumPacientesConBMR,
                short NumPacientesAislados,
                short NumPacientesA_PreventivoContacto,
                short NumPacientesA_Contacto,
                short NumPacientesA_Protector,
                short NumPacientesA_Gotas,
                short NumPacientesA_GotasContacto,
                short NumPacientesA_Aereo,
                short NumPacientesA_AereoContacto,
                short NumPacientesConViaAerea,
                short NumPacientesConSondaUrinaria,
                short NumPacientesConArteria,
                short NumPacientesConViaCentral,
                String FechaComputo,
                String IdUsuarioUltimaModificacion,
                String FechaValidacion,
               String IdUsuarioValidacion,
                int wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID)
        {
            SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FactoresMensualesSumatorioMensual", new List<SICCA_Log.parametros>(), "Inicio seteo de sumatorio mensual: " + wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID);

            Resultado_SPFactoresMensualesSumatorioMensual result = new Resultado_SPFactoresMensualesSumatorioMensual();
            result.EsCorrecto = true;
            result.MensajeError = "";
            String codigoPrograma = System.Configuration.ConfigurationManager.AppSettings["ExternoSICCA"];


            try
            {
                wcfENVIN.WcfENVINClient wsENVIN = new wcfENVIN.WcfENVINClient();
                var resultado = wsENVIN.set_SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual(codigoPrograma, idEjecucion, LogicalUnitID, wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID,
                 wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID,
                 NumPacientesIngresados,
                 NumPacientesNuevos,
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
                 compruebaFecha(FechaComputo),
                 IdUsuarioUltimaModificacion,
                 compruebaFecha(FechaValidacion),
                IdUsuarioValidacion,
                 wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID);
                if (resultado.EsCorrecto && resultado.wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID > 0)
                {
                    result.EsCorrecto = true;
                    result.wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID = resultado.wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FactoresMensualesSumatorioMensual", new List<SICCA_Log.parametros>(), "Se ha seteado correctamente el sumatorio mensual:  " + result.wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID);

                }
                if (!resultado.EsCorrecto)
                {
                    result.EsCorrecto = false;
                    result.MensajeError = resultado.MensajeError;
                    SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 0, "SICCA_IC_Mobile", "ENVINController", "SET_FactoresMensualesSumatorioMensual", new List<SICCA_Log.parametros>(), "No se ha seteado correctamente el sumatorio mensual: " + resultado.MensajeError);

                }
            }
            catch (Exception e)
            {
                String msg = e.InnerException != null ? e.InnerException.Message : e.Message;
                result.EsCorrecto = false;
                result.MensajeError = msg;
                SICCA_Log.Log.SP_SIC_Sistema_Log(idEjecucion, "L", 1, "SICCA_IC_Mobile", "ENVINController", "SET_FactoresMensualesSumatorioMensual", new List<SICCA_Log.parametros>(), msg);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }//SET_FactoresMensualesSumatorioMensual



        #endregion


    }
}