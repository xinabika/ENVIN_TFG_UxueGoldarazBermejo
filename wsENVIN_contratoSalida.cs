using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICCATransversal
{
        public class wsENVIN
    {

        #region funciones 

       
        #region busqueda pacientes

        #region busqueda pacientes obtener datos


        public class Resultado_ENVIN_Pacientes_Ingresados : ResultadoICBase
        {
            public Resultado_ENVIN_Pacientes_Ingresados()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Pacientes_Filtrado_ViewModel> get_wsENVIN_Web_Pacientes_Filtrado { get; set; }


        }

       

        public class Resultado_ENVIN_Paciente : ResultadoICBase
        {
            public Resultado_ENVIN_Paciente()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Pacientes_ViewModel> get_wsENVIN_Web_Pacientes { get; set; }


        }


        #endregion

        #region busqueda pacientes funciones Maestro
        public class Resultado_TiposEstadoInforme : ResultadoICBase
        {
            public Resultado_TiposEstadoInforme()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ViewModel> get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme { get; set; }

        }

        #endregion

        #endregion


        #region Funciones FichaIngreso
        #region Funciones FichaIngreso obtener datos
        public class Resultado_FichaIngresoDatosAdmin : ResultadoICBase
        {
            public Resultado_FichaIngresoDatosAdmin()
                : base()
            {

            }

            public List<F_wsENVIN_Web_FichaIngreso_DatosAdministrativos_ViewModel> get_wsENVIN_Web_FichaIngreso_DatosAdministrativos { get; set; }


        }

        public class Resultado_FichaIngresoGeneral : ResultadoICBase
        {
            public Resultado_FichaIngresoGeneral()
                : base()
            {

            }

            public List<F_wsENVIN_Web_FichaIngreso_General_ViewModel> get_wsENVIN_Web_FichaIngreso_General { get; set; }


        }

        public class Resultado_FichaIngresoComorbilidadesPrevias : ResultadoICBase
        {
            public Resultado_FichaIngresoComorbilidadesPrevias()
                : base()
            {

            }

            public List<F_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ViewModel> get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias { get; set; }


        }

        public class Resultado_FichaIngresoFactoresDeRiesgo : ResultadoICBase
        {
            public Resultado_FichaIngresoFactoresDeRiesgo()
                : base()
            {

            }

            public List<F_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ViewModel> get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo { get; set; }


        }

        public class Resultado_FichaIngresoColonizacionInfeccion : ResultadoICBase
        {
            public Resultado_FichaIngresoColonizacionInfeccion()
                : base()
            {

            }

            public List<F_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ViewModel> get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion { get; set; }


        }

        #endregion

        #region funciones FichaIngreso Maestro
        public class Resultado_FichaIngresoMaestroDiagnostico : ResultadoICBase
        {
            public Resultado_FichaIngresoMaestroDiagnostico()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN { get; set; }


        }

        public class Resultado_FichaIngresoMaestroOrigenPaciente : ResultadoICBase
        {
            public Resultado_FichaIngresoMaestroOrigenPaciente()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente { get; set; }


        }

        public class Resultado_FichaIngresoMaestroTipoAdmision : ResultadoICBase
        {
            public Resultado_FichaIngresoMaestroTipoAdmision()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision { get; set; }


        }


        public class Resultado_FichaIngresoMaestroCirugiaPrevia : ResultadoICBase
        {
            public Resultado_FichaIngresoMaestroCirugiaPrevia()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia { get; set; }


        }

        public class Resultado_FichaIngresoMaestroColonizacionInfeccion : ResultadoICBase
        {
            public Resultado_FichaIngresoMaestroColonizacionInfeccion()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion { get; set; }


        }

        public class Resultado_FichaIngresoMaestroColonizacionInfeccionCuando : ResultadoICBase
        {
            public Resultado_FichaIngresoMaestroColonizacionInfeccionCuando()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando { get; set; }


        }

        public class Resultado_FichaIngresoMaestroColonizacionInfeccionLocalizacion : ResultadoICBase
        {
            public Resultado_FichaIngresoMaestroColonizacionInfeccionLocalizacion()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion { get; set; }


        }

        public class Resultado_FichaIngresoMaestroColonizacionInfeccionTipo : ResultadoICBase
        {
            public Resultado_FichaIngresoMaestroColonizacionInfeccionTipo()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo { get; set; }


        }

        public class Resultado_FichaIngresoDatos : ResultadoICBase
        {
            public Resultado_FichaIngresoDatos()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN { get; set; }
            public List<F_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente { get; set; }
            public List<F_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision { get; set; }
            
            public List<F_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia { get; set; }
            public List<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion { get; set; }
            public List<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando { get; set; }
            public List<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion { get; set; }
            public List<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ViewModel> get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo { get; set; }


        }

        #endregion
        #endregion


        #region factores de riesgo individual

        #region factores de riesgo individual obtener datos
        public class Resultado_FactoresRiesgoIndividual : ResultadoICBase
        {
            public Resultado_FactoresRiesgoIndividual()
                : base()
            {

            }

            public List<F_wsENVIN_Web_FactoresRiesgoIndividual_ViewModel> get_wsENVIN_Web_FactoresRiesgoIndividual { get; set; }

        }

        #endregion


        #region factores de riesgo individual maestros




        public class Resultado_BloquesControles : ResultadoICBase
        {
            public Resultado_BloquesControles()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Bloques_Controles_ViewModel> get_wsENVIN_Web_Bloques_Controles { get; set; }


        }

        #endregion

        #endregion

        #region antibioticos

        #region funciones antibioticos obtener datos



        public class Resultado_Antibioticos : ResultadoICBase
        {
            public Resultado_Antibioticos()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Antibioticos_ViewModel> get_wsENVIN_Web_Antibioticos { get; set; }


        }


        #endregion

        #region funciones antibioticos maestros

        public class Resultado_MaestroAntibioticosCambioDeAntibiotico : ResultadoICBase
        {
            public Resultado_MaestroAntibioticosCambioDeAntibiotico()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ViewModel> get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico { get; set; }

        }


        public class Resultado_MaestroAntibioticosConfirmacion : ResultadoICBase
        {
            public Resultado_MaestroAntibioticosConfirmacion()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ViewModel> get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion { get; set; }

        }


        public class Resultado_MaestroAntibioticosIndicacion : ResultadoICBase
        {
            public Resultado_MaestroAntibioticosIndicacion()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_Antibioticos_Indicacion_ViewModel> get_wsENVIN_Web_Maestro_Antibioticos_Indicacion { get; set; }

        }


        public class Resultado_MaestroAntibioticosMotivo : ResultadoICBase
        {
            public Resultado_MaestroAntibioticosMotivo()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_Antibioticos_Motivo_ViewModel> get_wsENVIN_Web_Maestro_Antibioticos_Motivo { get; set; }

        }


        public class Resultado_MaestroAntibioticosMotivoDelCambio : ResultadoICBase
        {
            public Resultado_MaestroAntibioticosMotivoDelCambio()
                : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ViewModel> get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio { get; set; }

        }

        public class Resultado_Antibioticos_ObtenerControlesListas : ResultadoICBase
        {

            public Resultado_Antibioticos_ObtenerControlesListas()
               : base()
            {

            }

            public List<F_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ViewModel> get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico { get; set; }
            public List<F_wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ViewModel> get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion { get; set; }
            public List<F_wsENVIN_Web_Maestro_Antibioticos_Indicacion_ViewModel> get_wsENVIN_Web_Maestro_Antibioticos_Indicacion { get; set; }
            public List<F_wsENVIN_Web_Maestro_Antibioticos_Motivo_ViewModel> get_wsENVIN_Web_Maestro_Antibioticos_Motivo { get; set; }
            public List<F_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ViewModel> get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio { get; set; }
            public List<F_wsENVIN_Web_Maestro_Infecciones_Localizacion_ViewModel> get_wsENVIN_Web_Maestro_Infecciones_Localizacion { get; set; }

        }

        #endregion



        #endregion

        #region Infecciones

        public class Resultado_ENVINInfecciones : ResultadoICBase
        {
            public Resultado_ENVINInfecciones()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Infecciones_ViewModel> get_wsENVIN_Web_Infecciones { get; set; }
        }

        public class Resultado_ENVINMaestro_DiagnosticoClinico : ResultadoICBase
        {
            public Resultado_ENVINMaestro_DiagnosticoClinico()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ViewModel> get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico { get; set; }
        }

        public class Resultado_ENVINMaestro_Localizacion : ResultadoICBase
        {
            public Resultado_ENVINMaestro_Localizacion()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Infecciones_Localizacion_ViewModel> get_wsENVIN_Web_Maestro_Infecciones_Localizacion { get; set; }
        }

        public class Resultado_ENVINMaestro_Muestra : ResultadoICBase
        {
            public Resultado_ENVINMaestro_Muestra()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Infecciones_Muestra_ViewModel> get_wsENVIN_Web_Maestro_Infecciones_Muestra { get; set; }
        }

        public class Resultado_ENVINMaestro_OrigenInfeccion : ResultadoICBase
        {
            public Resultado_ENVINMaestro_OrigenInfeccion()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ViewModel> get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion { get; set; }
        }

        public class Resultado_ENVINMaestro_RespuestaInflamatoria : ResultadoICBase
        {
            public Resultado_ENVINMaestro_RespuestaInflamatoria()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ViewModel> get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria { get; set; }
        }

        public class Resultado_ENVINMaestro_TipoCateter : ResultadoICBase
        {
            public Resultado_ENVINMaestro_TipoCateter()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Infecciones_TipoCateter_ViewModel> get_wsENVIN_Web_Maestro_Infecciones_TipoCateter { get; set; }
        }

        public class Resultado_ENVINMaestro_Lugar : ResultadoICBase
        {
            public Resultado_ENVINMaestro_Lugar()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ViewModel> get_wsENVIN_Web_Maestro_Infecciones_Lugar { get; set; }
        }

        public class Resultado_ENVINMaestro_Microorganismos : ResultadoICBase
        {
            public Resultado_ENVINMaestro_Microorganismos()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Microorganismos_ViewModel> get_wsENVIN_Web_Maestro_Microorganismos { get; set; }
        }

        public class Resultado_ENVINMaestro_MicroorganismosGrupoMicroorganismosAntibiogramasIDGrupo : ResultadoICBase
        {
            public Resultado_ENVINMaestro_MicroorganismosGrupoMicroorganismosAntibiogramasIDGrupo()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo_ViewModel> get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo { get; set; }
        }

        public class Resultado_ENVINMaestro_MicroorganismosUFC10 : ResultadoICBase
        {
            public Resultado_ENVINMaestro_MicroorganismosUFC10()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Microorganismos_UFC_10_ViewModel> get_wsENVIN_Web_Maestro_Microorganismos_UFC_10 { get; set; }
        }

        public class Resultado_ENVINMaestro_Antibiogramas_Resistencia : ResultadoICBase
        {
            public Resultado_ENVINMaestro_Antibiogramas_Resistencia()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ViewModel> get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia { get; set; }
        }

        public class Resultado_ENVINInfecciones_Antibiogramas : ResultadoICBase
        {
            public Resultado_ENVINInfecciones_Antibiogramas()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo_ViewModel> get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo { get; set; }
        }


        public class Resultado_ENVINMicroorganismos : ResultadoICBase
        {
            public Resultado_ENVINMicroorganismos()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion_ViewModel> get_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion { get; set; }
        }

        #endregion

        #region tabla de factores mensuales


        public class Resultado_FactoresMensuales : ResultadoICBase
        {
            public Resultado_FactoresMensuales()
                : base()
            {

            }
            public List<F_wsENVIN_Web_FactoresMensuales_ViewModel> get_wsENVIN_Web_FactoresMensuales { get; set; }
        }

        public class Resultado_FactoresMensuales_SumatorioMensual : ResultadoICBase
        {
            public Resultado_FactoresMensuales_SumatorioMensual()
                : base()
            {

            }
            public List<F_wsENVIN_Web_FactoresMensuales_SumatorioMensual_ViewModel> get_wsENVIN_Web_FactoresMensuales_SumatorioMensual { get; set; }
        }

        public class Resultado_MaestroFactoresMensualesMeses : ResultadoICBase
        {
            public Resultado_MaestroFactoresMensualesMeses()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_FactoresMensuales_Meses_ViewModel> get_wsENVIN_Web_Maestro_FactoresMensuales_Meses { get; set; }
        }

        public class Resultado_MaestroFactoresMensualesAnnos : ResultadoICBase
        {
            public Resultado_MaestroFactoresMensualesAnnos()
                : base()
            {

            }
            
            public List<F_wsENVIN_Web_Maestro_FactoresMensuales_Annos_ViewModel> get_wsENVIN_Web_Maestro_FactoresMensuales_Annos { get; set; }
        }

        public class Resultado_MaestroFactoresMensuales : ResultadoICBase
        {
            public Resultado_MaestroFactoresMensuales()
                : base()
            {

            }
            public List<F_wsENVIN_Web_Maestro_FactoresMensuales_Meses_ViewModel> get_wsENVIN_Web_Maestro_FactoresMensuales_Meses { get; set; }
            public List<F_wsENVIN_Web_Maestro_FactoresMensuales_Annos_ViewModel> get_wsENVIN_Web_Maestro_FactoresMensuales_Annos { get; set; }
        }


        #endregion

        #endregion






        #region SP

        public class Resultado_SP_ActualizarEstadoPaciente : ResultadoICBase
        {
            public Resultado_SP_ActualizarEstadoPaciente()
                : base()
            {
            }
            public int wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID { get; set; }

        }

        #region SP ficha ingreso

        public class Resultado_FichaIngresoSPwebPacientes : ResultadoICBase
        {
            public Resultado_FichaIngresoSPwebPacientes()
                : base()
            {
            }
            public int wsENVIN_Web_Pacientes_ID { get; set; }

        }


        public class Resultado_FichaIngresoSPFichaIngresoGeneral : ResultadoICBase
        {
            public Resultado_FichaIngresoSPFichaIngresoGeneral()
                : base()
            {
            }
            public int wsENVIN_Web_FichaIngreso_General_ID { get; set; }

        }

        public class Resultado_FichaIngresoSPFichaIngresoComorbilidades : ResultadoICBase
        {
            public Resultado_FichaIngresoSPFichaIngresoComorbilidades()
                : base()
            {
            }
            public int wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID { get; set; }

        }

        public class Resultado_FichaIngresoSPFichaIngresoFactoresDeRiesgo : ResultadoICBase
        {
            public Resultado_FichaIngresoSPFichaIngresoFactoresDeRiesgo()
                : base()
            {
            }
            public int wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID { get; set; }

        }


        public class Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccion : ResultadoICBase
        {
            public Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccion()
                : base()
            {
            }
            public int wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID { get; set; }

        }

        public class Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccionDel : ResultadoICBase
        {
            public Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccionDel()
                : base()
            {
            }
            public int countRegistrosAfectados { get; set; }

        }

        #endregion

        #region SP antibioticos

        public class Resultado_SPAntibioticos : ResultadoICBase
        {
            public Resultado_SPAntibioticos()
                : base()
            {
            }
            public int wsENVIN_Web_Antibioticos_ID { get; set; }

        }

        public class Resultado_SPAntibioticosDel : ResultadoICBase
        {
            public Resultado_SPAntibioticosDel()
                : base()
            {
            }
            public int countRegistrosAfectados { get; set; }

        }

        #endregion

        #region SP factores de riesgo individual

        public class Resultado_SPFactoresRiesgoIndividual : ResultadoICBase
        {
            public Resultado_SPFactoresRiesgoIndividual()
                : base()
            {
            }
            public int wsENVIN_Web_FactoresRiesgoIndividual_ID { get; set; }

        }


        public class Resultado_SPFactoresRiesgoIndividualDel : ResultadoICBase
        {
            public Resultado_SPFactoresRiesgoIndividualDel()
                : base()
            {
            }
            public int countRegistrosAfectados { get; set; }

        }

        #endregion

        #region Infecciones
        public class Resultado_SPInfecciones : ResultadoICBase
        {
            public Resultado_SPInfecciones()
                : base()
            {
            }
            public int wsENVIN_Web_Infecciones_ID { get; set; }
        }

        public class Resultado_SPInfeccionesDel : ResultadoICBase
        {
            public Resultado_SPInfeccionesDel()
                : base()
            {
            }
            public int countRegistrosAfectados { get; set; }
        }

        public class Resultado_SPAntibiograma : ResultadoICBase
        {
            public Resultado_SPAntibiograma()
                : base()
            {
            }
            public int wsENVIN_Web_Infecciones_Antibiogramas_ID { get; set; }
        }

        public class Resultado_SPAntibiogramaDel : ResultadoICBase
        {
            public Resultado_SPAntibiogramaDel()
                : base()
            {
            }
            public int countRegistrosAfectados { get; set; }
        }

        public class Resultado_SPMicroorganismo : ResultadoICBase
        {
            public Resultado_SPMicroorganismo()
                : base()
            {
            }
            public int wsENVIN_Web_Infecciones_Microorganismos_ID { get; set; }
        }

        public class Resultado_SPMicroorganismoDel : ResultadoICBase
        {
            public Resultado_SPMicroorganismoDel()
                : base()
            {
            }
            public int countRegistrosAfectados { get; set; }
        }
        #endregion


        #region tabla de factores mensuales
        public class Resultado_SPFactoresMensualesSumatorioMensual : ResultadoICBase
        {
            public Resultado_SPFactoresMensualesSumatorioMensual()
                : base()
            {
            }
            public int wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID { get; set; }

        }

        #endregion

        #endregion


    }
}
