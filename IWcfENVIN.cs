using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static SICCATransversal.wsENVIN;

namespace SICCAWcf
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWcfENVIN" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWcfENVIN
    {
        //getters: funciones bbdd DESTINO

        [OperationContract]
        Resultado_ENVIN_Pacientes_Ingresados get_wsENVIN_Web_Pacientes_Filtrado(String codigoPrograma, String id_ejecucion, DateTime fechaInicio , DateTime fechaFin , int logicalUnitID , int EstadoInforme , String nombre , String apellidos , String nhc );
        
        [OperationContract]
        Resultado_ENVIN_Paciente get_wsENVIN_Web_Pacientes(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID);

        [OperationContract]
        Resultado_TiposEstadoInforme get_wsENVIN_Web_Maestro_Pacientes_EstadosInforme(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID);
        [OperationContract]
        Resultado_SP_ActualizarEstadoPaciente set_SP_wsENVIN_ActualizarEstadoPaciente(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID);



        #region ficha ingreso
        #region funciones ficha ingreso


        [OperationContract]
        Resultado_FichaIngresoDatosAdmin get_wsENVIN_Web_FichaIngreso_DatosAdministrativos(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID);

        [OperationContract]
        Resultado_FichaIngresoGeneral get_wsENVIN_Web_FichaIngreso_General(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID);

        [OperationContract]
        Resultado_FichaIngresoComorbilidadesPrevias get_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID);

        [OperationContract]
        Resultado_FichaIngresoFactoresDeRiesgo get_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID);

        [OperationContract]
        Resultado_FichaIngresoColonizacionInfeccion get_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID);
        #endregion

        #region funciones ficha ingreso Maestros

        [OperationContract]
        Resultado_FichaIngresoMaestroDiagnostico get_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID);

        [OperationContract]
        Resultado_FichaIngresoMaestroOrigenPaciente get_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID);

        [OperationContract]
        Resultado_FichaIngresoMaestroTipoAdmision get_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID);

        [OperationContract]
        Resultado_FichaIngresoMaestroCirugiaPrevia get_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID);

        [OperationContract]
        Resultado_FichaIngresoMaestroColonizacionInfeccion get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID);
       
        [OperationContract]
        Resultado_FichaIngresoMaestroColonizacionInfeccionCuando get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID);

        [OperationContract]
        Resultado_FichaIngresoMaestroColonizacionInfeccionLocalizacion get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID);

        [OperationContract]
        Resultado_FichaIngresoMaestroColonizacionInfeccionTipo get_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID);

        #endregion




        //setters: SP bbdd DESTINO
        #region SP ficha ingreso 

        [OperationContract]
        Resultado_FichaIngresoSPwebPacientes set_SP_wsENVIN_Web_Pacientes(String codigoPrograma, String id_ejecucion,
                 int PatientID, int id_wsLEIRE_Datos_Ingresos, String NHC, short LogicalUnitID, short wsENVIN_Web_Maestro_Pacientes_ORStatus_ID,
                 short wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID, Boolean EsCargaManual, DateTime FechaCargaManual,
                 String FirstName, String LastName, DateTime FechaNacimiento, short wsENVIN_Web_Maestro_Pacientes_Sexo_ID, short NumHabitacion,
                 DateTime AddmissionDate, DateTime FechaIngresoHospital, DateTime DischargeDate, DateTime FechaAltaHospital,
                 Boolean Exitus, DateTime FechaExitus, String IdUsuarioUltimaModificacion, int wsENVIN_Web_Pacientes_ID);

        [OperationContract]
        Resultado_FichaIngresoSPFichaIngresoGeneral set_SP_wsENVIN_Web_FichaIngreso_General(String codigoPrograma, String id_ejecucion,
                 int wsENVIN_Web_Pacientes_ID, short Apache_II, short Glasgow, Boolean PacienteTraumatizado, Boolean PacienteCoronario,
                 Boolean ATB48hPrevias, Boolean PacienteCovid19, short wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID,
                 short wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID, short wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID, short wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID,
                 String IdUsuarioUltimaModificacion, DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_General_ID);

        [OperationContract]
        Resultado_FichaIngresoSPFichaIngresoComorbilidades set_SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(String codigoPrograma, String id_ejecucion,
                int wsENVIN_Web_Pacientes_ID, Boolean Diabetes, Boolean InsuficienciaRenal, Boolean Inmunodepresion, Boolean Neoplasia, Boolean Cirrosis,
                Boolean EPOC, Boolean DesnutricionHipoalbuminemia, Boolean TransplanteOrganoSolido, String IdUsuarioUltimaModificacion, DateTime FechaValidacion,
                String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID);


        [OperationContract]
        Resultado_FichaIngresoSPFichaIngresoFactoresDeRiesgo set_SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(String codigoPrograma, String id_ejecucion,
               int wsENVIN_Web_Pacientes_ID, Boolean CirugiaUrgente, Boolean DerivacionVentricularExterna, Boolean DepuracionExtrarrenal,
               Boolean NutricionParenteral, Boolean Neutropenia, Boolean ECMO, Boolean CateterVenosoCentral, Boolean ViaAereaArtificial,
               Boolean SondaUrinaria, Boolean Impella, Boolean AsistenciaVentricular, Boolean BCIA, String IdUsuarioUltimaModificacion,
               DateTime  FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID);

        [OperationContract]
        Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccion set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(String codigoPrograma, String id_ejecucion,
               int wsENVIN_Web_Pacientes_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID,
               int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID,
               DateTime Fecha, String IdUsuarioUltimaModificacion,
               DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID);

        [OperationContract]
        Resultado_FichaIngresoSPFichaIngresoColonizacionInfeccionDel set_SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID);
        #endregion

        #endregion


        #region factores de riesgo individual

        #region factores de riesgo individual funciones obtener datos
        [OperationContract]
        Resultado_FactoresRiesgoIndividual get_wsENVIN_Web_FactoresRiesgoIndividual(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID);

        #endregion

        #region factores de riesgo individual funciones maestros
        [OperationContract]
        Resultado_BloquesControles get_wsENVIN_Web_Bloques_Controles(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Bloques_ID, int wsENVIN_Web_Controles_Grupos_ID);
        #endregion

        #region SP factores de riesgo individual

        [OperationContract]
        Resultado_SPFactoresRiesgoIndividual set_SP_wsENVIN_Web_FactoresRiesgoIndividual(String codigoPrograma, String id_ejecucion,
                int wsENVIN_Web_Pacientes_ID, DateTime Periodo1ViaAereaArtificial_Inicio, DateTime Periodo1ViaAereaArtificial_Fin, DateTime Periodo2ViaAereaArtificial_Inicio, DateTime Periodo2ViaAereaArtificial_Fin,
                DateTime Periodo3ViaAereaArtificial_Inicio, DateTime Periodo3ViaAereaArtificial_Fin, DateTime FechaInicioTraqueostomia,
                DateTime Periodo1VMNI_Inicio, DateTime Periodo1VMNI_Fin, DateTime Periodo2VMNI_Inicio, DateTime Periodo2VMNI_Fin, DateTime Periodo3VMNI_Inicio,
                DateTime Periodo3VMNI_Fin, DateTime Fecha1Reintubacion, DateTime Fecha2Reintubacion, DateTime PeriodoSondaUrinaria_Inicio, DateTime PeriodoSondaUrinaria_Fin,
                DateTime Periodo1CVC_Inicio, DateTime Periodo1CVC_Fin, DateTime Periodo2CVC_Inicio, DateTime Periodo2CVC_Fin,
                DateTime Periodo3CVC_Inicio, DateTime Periodo3CVC_Fin, DateTime PeriodoCateterArterial_Inicio, DateTime PeriodoCateterArterial_Fin,
                DateTime PeriodoNutricionParenteral_Inicio, DateTime PeriodoNutricionParenteral_Fin, DateTime PeriodoNutricionEnteral_Inicio, DateTime PeriodoNutricionEnteral_Fin,
                DateTime ECMO_Inicio, DateTime ECMO_Fin, String IdUsuarioUltimaModificacion, DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FactoresRiesgoIndividual_ID);
        
        
        [OperationContract]
        Resultado_SPFactoresRiesgoIndividualDel set_SP_wsENVIN_Web_FactoresRiesgoIndividual_Del(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_FactoresRiesgoIndividual_ID);

        #endregion

        #endregion


        #region antibioticos 

        #region antibioticos obtener datos
        [OperationContract]
        Resultado_Antibioticos get_wsENVIN_Web_Antibioticos(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID);

        #endregion 

        #region antibioticos maestros
        [OperationContract]
        Resultado_MaestroAntibioticosCambioDeAntibiotico get_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID);

        [OperationContract]
        Resultado_MaestroAntibioticosConfirmacion get_wsENVIN_Web_Maestro_Antibioticos_Confirmacion(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID);

        [OperationContract]
        Resultado_MaestroAntibioticosIndicacion get_wsENVIN_Web_Maestro_Antibioticos_Indicacion(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID);

        [OperationContract]
        Resultado_MaestroAntibioticosMotivo get_wsENVIN_Web_Maestro_Antibioticos_Motivo(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Antibioticos_Motivo_ID);

        [OperationContract]
        Resultado_MaestroAntibioticosMotivoDelCambio get_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID);

        #endregion

        //setters: SP bbdd DESTINO
        #region SP antibioticos

        [OperationContract]
        Resultado_SPAntibioticos set_SP_wsENVIN_Web_Antibioticos(String codigoPrograma, String id_ejecucion,
                 int wsENVIN_Web_Pacientes_ID, int LogicalUnitID, int PlannedOrderID, String Antibiotico, DateTime FechaInicio,
                 DateTime FechaFin, int wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID, int wsENVIN_Web_Maestro_Infecciones_Localizacion_ID,
                 int wsENVIN_Web_Maestro_Antibioticos_Motivo_ID, int wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID, int wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID,
                 int wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID, String IdUsuarioUltimaModificacion,
                 DateTime FechaValidacion, String IdUsuarioValidacion, bool Estado, int wsENVIN_Web_Antibioticos_ID);

        [OperationContract]
        Resultado_SPAntibioticosDel set_SP_wsENVIN_Web_Antibioticos_Del(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Antibioticos_ID);


        #endregion


        #endregion

        #region Infecciones
        [OperationContract]
        Resultado_ENVINInfecciones get_wsENVIN_Web_Infecciones(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID);

        [OperationContract]
        Resultado_ENVINMaestro_DiagnosticoClinico get_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico(String codigoPrograma, String id_ejecucion);
        
        [OperationContract]
        Resultado_ENVINMaestro_Localizacion get_wsENVIN_Web_Maestro_Infecciones_Localizacion(String codigoPrograma, String id_ejecucion);
        
        [OperationContract]
        Resultado_ENVINMaestro_Muestra get_wsENVIN_Web_Maestro_Infecciones_Muestra(String codigoPrograma, String id_ejecucion);
        
        [OperationContract]
        Resultado_ENVINMaestro_OrigenInfeccion get_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion(String codigoPrograma, String id_ejecucion);
        
        [OperationContract]
        Resultado_ENVINMaestro_RespuestaInflamatoria get_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria(String codigoPrograma, String id_ejecucion);
        
        [OperationContract]
        Resultado_ENVINMaestro_TipoCateter get_wsENVIN_Web_Maestro_Infecciones_TipoCateter(String codigoPrograma, String id_ejecucion);

        [OperationContract]
        Resultado_ENVINMaestro_Lugar get_wsENVIN_Web_Maestro_Infecciones_Lugar(String codigoPrograma, String id_ejecucion);

        [OperationContract]
        Resultado_ENVINMaestro_Microorganismos get_wsENVIN_Web_Maestro_Microorganismos(String codigoPrograma, String id_ejecucion);
        
        [OperationContract]
        Resultado_ENVINMaestro_MicroorganismosGrupoMicroorganismosAntibiogramasIDGrupo get_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID);
        
        [OperationContract]
        Resultado_ENVINMaestro_MicroorganismosUFC10 get_wsENVIN_Web_Maestro_Microorganismos_UFC_10(String codigoPrograma, String id_ejecucion);

        [OperationContract]
        Resultado_SPInfecciones set_wsENVIN_Infecciones(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Pacientes_ID, short wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID, short? wsENVIN_Web_Maestro_Infecciones_Localizacion_ID, bool? bacteriemia, short wsENVIN_Web_Maestro_Infecciones_Muestra_ID,
               short wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID, bool exposicion48hprevias, bool? tratamientoAntibiotico,
               bool? tratamientoApropiado, bool? ajusteTratamiento, short? wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID, short wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID, short wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID,
               String idUsuarioUltimaModificacion, DateTime fechaValidacion, String idUsuarioValidacion, DateTime fechaInfeccion, int? wsENVIN_Web_Infecciones_ID);

        [OperationContract]
        Resultado_SPInfeccionesDel set_wsENVIN_Infecciones_Del(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Infecciones_ID);

        [OperationContract]
        Resultado_SPAntibiograma set_wsENVIN_Infecciones_Antibiograma(string codigoPrograma, string id_ejecucion, int wsENVIN_Web_Infecciones_Microorganismos_ID, short wsENVIN_Web_Maestro_Antibiogramas_ID, short wsENVIN_Web_Pacientes_ID, short wsENVN_Web_Maestro_Antibiogramas_Resistencia_ID,
               String idUsuarioUltimaModificacion, DateTime fechaValidacion, String idUsuarioValidacion, int? wsENVIN_Web_Infecciones_Antibiogramas_ID);
               
        [OperationContract]
        Resultado_SPMicroorganismoDel set_wsENVIN_Infecciones_Microrgarnismos_Del(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Infecciones_Microorganismos_ID);

        [OperationContract]
        Resultado_SPMicroorganismo set_wsENVIN_Infecciones_Microrgarnismos(string codigoPrograma, string id_ejecucion, int wsENVIN_Web_Infecciones_ID, short wsENVIN_Web_Maestro_Microorganismos_ID, short wsENVIN_Web_Pacientes_ID, int wsENVIN_Web_Maestro_Microorganismos_UFC_ID, String idUsuarioUltimaModificacion,
               DateTime fechaValidacion, String idUsuarioValidacion, int wsENVIN_Web_Infecciones_Microorganismos_ID);

        [OperationContract]
        Resultado_ENVINMicroorganismos get_wsENVIN_Web_Microorganismos(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Infecciones_ID);

        [OperationContract]
        Resultado_ENVINInfecciones_Antibiogramas get_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Infecciones_Microorganismos_ID);

        [OperationContract]
        Resultado_ENVINMaestro_Antibiogramas_Resistencia get_wsENVIN_Web_Maestro_Antibiogramas_Resistencia(String codigoPrograma, String id_ejecucion);
        #endregion

        #region tabla de factores mensuales

        [OperationContract]
        Resultado_FactoresMensuales get_wsENVIN_Web_FactoresMensuales(String codigoPrograma, String id_ejecucion, int LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);
        [OperationContract]
        Resultado_FactoresMensuales_SumatorioMensual get_wsENVIN_Web_FactoresMensuales_SumatorioMensual(String codigoPrograma, String id_ejecucion, int LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);
        [OperationContract]
        Resultado_MaestroFactoresMensualesMeses get_wsENVIN_Web_Maestro_FactoresMensuales_Meses(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID);
        [OperationContract]
        Resultado_MaestroFactoresMensualesAnnos get_wsENVIN_Web_Maestro_FactoresMensuales_Annos(String codigoPrograma, String id_ejecucion, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);
        [OperationContract]
        Resultado_SPFactoresMensualesSumatorioMensual set_SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual(String codigoPrograma, String id_ejecucion,
               short LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID,
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
                DateTime FechaComputo,
                String IdUsuarioUltimaModificacion,
                DateTime FechaValidacion,
               String IdUsuarioValidacion,
                int wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID);
        #endregion
    }
}
