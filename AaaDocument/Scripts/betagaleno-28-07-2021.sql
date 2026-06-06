# SQL Manager 2005 for MySQL 3.6.5.8
# ---------------------------------------
# Host     : localhost
# Port     : 3306
# Database : betagaleno


SET FOREIGN_KEY_CHECKS=0;

DROP DATABASE IF EXISTS `betagaleno`;

CREATE DATABASE `betagaleno`
    CHARACTER SET 'latin1'
    COLLATE 'latin1_swedish_ci';

USE `betagaleno`;

#
# Structure for the `admcausaexterna` table : 
#

DROP TABLE IF EXISTS `admcausaexterna`;

CREATE TABLE `admcausaexterna` (
  `adm_codcex_tcex` varchar(2) NOT NULL DEFAULT '' COMMENT 'Causa Externa Origen que origina la atencion según Resolución: 3374 RIPS',
  `adm_descex_tcex` varchar(40) DEFAULT NULL COMMENT 'Descripcion textual causa externa que origina la admision o atencion medica',
  PRIMARY KEY (`adm_codcex_tcex`),
  KEY `tcex02` (`adm_descex_tcex`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `admdestinosalir` table : 
#

DROP TABLE IF EXISTS `admdestinosalir`;

CREATE TABLE `admdestinosalir` (
  `adm_coddsa_tdsa` varchar(1) NOT NULL DEFAULT '' COMMENT 'Código destino salida',
  `adm_desdsa_tdsa` varchar(40) DEFAULT NULL COMMENT 'Descripcióndel Destino al salir',
  PRIMARY KEY (`adm_coddsa_tdsa`),
  KEY `tdes02` (`adm_desdsa_tdsa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `admordendsalida` table : 
#

DROP TABLE IF EXISTS `admordendsalida`;

CREATE TABLE `admordendsalida` (
  `adm_secaut_aegr` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial Autorización de egreso paciente (generado por el sistema)',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente al cual se realizara la orden de salida',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de d atos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `adm_fecsol_aegr` date DEFAULT NULL COMMENT 'Fecha solicitud salida',
  `adm_fecsal_aegr` date DEFAULT NULL COMMENT 'Fecha autorización salida',
  `adm_horsal_aegr` decimal(5,2) DEFAULT NULL COMMENT 'Hora autorización salida  formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(4) DEFAULT NULL COMMENT 'Código Profesional Que Autoriza salida del paciente',
  `adm_observ_aegr` text COMMENT 'Nota u Observación para el la salida',
  `adm_estreg_aegr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro autorizacion salida: 1 =Abierta 2=Confirmada 3 = Anulada',
  PRIMARY KEY (`adm_secaut_aegr`),
  KEY `aegr02` (`adm_secadm_rgad`),
  KEY `aegr03` (`sia_idesec_usua`),
  KEY `aegr04` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `admregadmision` table : 
#

DROP TABLE IF EXISTS `admregadmision`;

CREATE TABLE `admregadmision` (
  `adm_secadm_rgad` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial de Admisión',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `hcl_nrohis_hicl` varchar(20) DEFAULT NULL COMMENT 'Numero o código de la Ficha de Historias Clínicas',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `adm_fecadm_rgad` date DEFAULT NULL COMMENT 'Fecha de la Admisión o del registro de atención ambulatoria',
  `adm_horadm_rgad` decimal(5,2) DEFAULT NULL COMMENT 'Hora de Admisión o atención ambulatoria en formato militar  (HH) ejm: 16',
  `adm_pacemb_rgad` varchar(1) DEFAULT NULL COMMENT 'La paciente esta embarazada : 1=SI 2=NO',
  `adm_reingr_rgad` varchar(1) DEFAULT NULL COMMENT 'Para saber si el registro de atención o admisión es un reingreso antes de 48 horas de haberse dado de alta previamente al   paciente: SI/NO',
  `adm_admadr_rgad` varchar(20) DEFAULT NULL COMMENT 'Numero registro admisión de la madre, cuando se trata de NACIDOS EN LA INSTITUCION',
  `adm_codoad_toad` varchar(1) DEFAULT NULL COMMENT 'Código Origen de Admisión o vía de ingreso a la institución (desde la tabla origen admisión o vía de ingreso a la institución)',
  `adm_nroreg_tria` varchar(20) DEFAULT NULL COMMENT 'Codigo del registro evaluacion Triage de Urgencia cuando aplica',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `sia_areing_aser` varchar(3) DEFAULT NULL COMMENT 'Código Área de Servicio Donde Ingresa o presta atención inicial, (este dato no cambia cuando hay traslados de área)',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Código del centro de producción (en Admision solo para atencion ambulatoria)',
  `adm_codtat_tatn` varchar(1) DEFAULT NULL COMMENT 'Código Tipo de Atención o ámbito donde se prestara el servicio :1=Ambulatoria 2=Hospitalización 3=Urgencia',
  `adm_codcex_tcex` varchar(2) DEFAULT NULL COMMENT 'Causa Externa Origen que origina la atención según Resolución: 3374 RIPS',
  `hos_codcam_caho` varchar(10) DEFAULT NULL COMMENT 'Código Cama  Hospitalización u Observación de urgencia donde ingresa',
  `hos_codsec_hsec` varchar(10) DEFAULT NULL COMMENT 'Código seccionpara las subdivisiones de Hospitalización y Urgencias con observación donde esta la cama asignada EJM:S001= Hospitalización Mujeres, S002 =Hospitalización Niños y otras',
  `sia_dixing_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico de Ingreso a hospitalización/Urgencias con Observación (si no se digito en admisión)',
  `adm_caucon_rgad` varchar(150) DEFAULT NULL COMMENT 'Causa Textual de Consulta',
  `adm_fechos_rgad` date DEFAULT NULL COMMENT 'Fecha en que Inicia Hospitalización',
  `adm_horhos_rgad` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que Inicia Hospitalización',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Único de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Código de Eps o Asegurador según códigos asignados por la supersalud',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Codigo de Empresa tercero contable o asegurador según módulos administrativos',
  `sia_edapac_usua` int(3) DEFAULT NULL COMMENT 'Edad Paciente al Momento de Admisión',
  `sia_codmed_tmed` varchar(1) DEFAULT NULL COMMENT 'Unidad Medida Edad Paciente 1=Año 2=Mes 3=Día',
  `sia_edaano_usua` int(3) DEFAULT NULL COMMENT 'Edad en años',
  `sia_edames_usua` int(4) DEFAULT NULL COMMENT 'Edad en meses',
  `sia_edadia_usua` int(5) DEFAULT NULL COMMENT 'Edad en días',
  `sia_edaymd_usua` varchar(30) DEFAULT NULL COMMENT 'Edad en formato largo ejemplo: (20 años 8 meses 16 días)',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código Profesional Que Autoriza Admisión o presta servicio ambulatorio',
  `adm_nroaut_rgad` varchar(40) DEFAULT NULL COMMENT 'Numero Autorización Admisión solicitada a la EPS o Asegurador',
  `adm_nropol_rgad` varchar(40) DEFAULT NULL COMMENT 'Numero de poliza de seguro cuando es un accidente SOAT o algun seguro especial',
  `sia_tipusu_regi` varchar(1) DEFAULT NULL COMMENT 'Tipo Usuario según régimen 1=Contributivo 2=Subsidiado y otros(Resol: 3374 RIPS)',
  `sia_tipafi_tafi` varchar(1) DEFAULT NULL COMMENT 'Tipo Afiliado: C=Cotizante B=Beneficiario A=Adicional',
  `sia_nivsbn_nsbn` varchar(1) DEFAULT NULL COMMENT 'Código Nivel Sisben para cobro de copagos  según Resolución: 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N',
  `sia_tippob_tpob` varchar(2) DEFAULT NULL COMMENT 'Código del tipo poblacional especial para subsidiado, según normas de base de datos Resol: 1344 de 2012  BDUA',
  `sia_nivcon_ncon` varchar(1) DEFAULT NULL COMMENT 'Código Nivel Contributivo 1,2,3... para Calcular cuotas Moderadoras y copagos',
  `sis_codocu_ocup` varchar(4) DEFAULT NULL COMMENT 'Código ocupación o profesion usuario atendido',
  `adm_nomaco_rgad` varchar(40) DEFAULT NULL COMMENT 'Nombre del Acompañante (Familia Paciente)',
  `adm_diraco_rgad` varchar(30) DEFAULT NULL COMMENT 'Dirección Acompañante',
  `adm_telaco_rgad` varchar(30) DEFAULT NULL COMMENT 'Teléfono del Acompañante',
  `adm_nrorem_rgad` varchar(20) DEFAULT NULL COMMENT 'Numero de la Remisión',
  `sis_idemun_muni` varchar(5) DEFAULT NULL COMMENT 'Id Único Municipio origen Remisión',
  `sia_codips_tips` varchar(40) DEFAULT NULL COMMENT 'IPS Origen Remisión',
  `adm_fecrem_rgad` date DEFAULT NULL COMMENT 'Fecha de Remisión',
  `adm_secite_rgad` int(5) DEFAULT NULL COMMENT 'Secuencial de Item en Facturación desde aquí se generan los Id únicos  para detalles en servicios',
  `sia_regate_rgat` varchar(1) DEFAULT NULL COMMENT 'Tipo Registro  de Atención: 1 = Admitidos 2=Ambulatoria',
  `adm_estfac_rgad` varchar(1) DEFAULT NULL COMMENT 'Estado de la Facturación Para este Paciente 1=Abierta 2=Cerrada',
  `adm_estrad_rgad` varchar(1) DEFAULT NULL COMMENT 'Estado de datos  atención medica para este Paciente 1=Abierta 2=Cerrada',
  `adm_liqest_rgad` varchar(1) DEFAULT NULL COMMENT 'Liquidado Estancias Para Hospitalización/Urgencias 1=SI 2=No',
  `adm_ctarip_rgad` varchar(1) DEFAULT NULL COMMENT 'Marca de Rips Completado 1=No Completado 2=Rips Completado 3=No Requiere Completado',
  `adm_finate_rgad` varchar(1) DEFAULT NULL COMMENT '1= Registro Activo en la vista admitido 2= Registro Finalizado (no visible en vista admitido)',
  `sia_codfco_fcon` varchar(2) DEFAULT NULL COMMENT 'SIA_REGATE_RGAT = 2 (registro atencion ambulatoria)  Finalidad de la consulta:01=Atención del Parto 02=Atencion del Recien Nacido y demas  según Resolucion 3374 RIPS',
  `sia_coddia_tdia` varchar(4) DEFAULT NULL COMMENT 'SIA_REGATE_RGAT = 2 (registro atencion ambulatoria) Diagnostico  de  según CIE-10 ',
  `sia_tipdxp_tdix` varchar(1) DEFAULT NULL COMMENT 'SIA_REGATE_RGAT = 2 (registro atencion ambulatoria) Tipo de diagnostico principal',
  `adm_dessal_regr` varchar(1) DEFAULT NULL COMMENT 'SIA_REGATE_RGAT = 2 (registro atencion ambulatoria)  Destino al salir: 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion',
  `sia_dixre1_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 1 según CIE-10',
  `sia_dixre2_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 2 según CIE-10',
  `sia_dixre3_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 3 según CIE-10',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atención  cuando hay varias sedes',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del Digitador Usuario del sistema que diligencia el registro de atención o admisión',
  `adm_conest_rgad` int(5) DEFAULT NULL COMMENT 'Contador para generar los registros únicos de estancias y traslados de camas del paciente',
  `adm_fecedt_rgad` date DEFAULT NULL COMMENT 'Fecha ultima edición',
  `adm_fllave_rgad` int(10) DEFAULT NULL COMMENT 'llave de gestion generada desde fecha admision',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado de la Admisión o atención ambulatoria  1=Abierta 2=Cerrada 3=Anulada',
  PRIMARY KEY (`adm_secadm_rgad`),
  KEY `rgad02` (`sia_idesec_usua`),
  KEY `rgad03` (`hcl_nrohis_hicl`),
  KEY `rgad04` (`sia_nroide_usua`),
  KEY `rgad05` (`sia_codeps_teps`),
  KEY `rgad06` (`adm_nroreg_tria`),
  KEY `rgad07` (`adm_fllave_rgad`),
  KEY `rgad08` (`sis_idterc_sitr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `admregistegreso` table : 
#

DROP TABLE IF EXISTS `admregistegreso`;

CREATE TABLE `admregistegreso` (
  `adm_secegr_regr` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial registro de egreso',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificacion del usuario o Paciente  según las normas vigentes para gestion de d atos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `hcl_nrohis_hicl` varchar(20) DEFAULT NULL COMMENT 'Numero o codigo de la Ficha de Historias Clinicas',
  `adm_codtat_tatn` varchar(1) DEFAULT NULL COMMENT 'Código Tipo de Atención o ámbito donde se prestara el servicio :1=Ambulatoria 2=Hospitalización 3=Urgencia',
  `adm_fecegr_regr` date DEFAULT NULL COMMENT 'Fecha de egreso del servicio de hospitalizacion u Observacion en urgencia',
  `adm_horegr_regr` decimal(5,2) DEFAULT NULL COMMENT 'Hora  egreso en formato militar  (HH) ejm: 16',
  `adm_secaut_aegr` varchar(20) DEFAULT NULL COMMENT 'Numero Secuencial Autorizacion de egreso paciente',
  `sia_codpfa_prof` varchar(4) DEFAULT NULL COMMENT 'Codigo Profesional Que Autoriza egreso o presta servicio ambulatorio',
  `sia_dixing_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico de Ingreso a hospitalizacion/Urgencias con Observacion (si no se digito en admision) según CIE-10',
  `sia_dixsal_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico de salida de hospitalizacion/Urgencias con Observacion según CIE-10',
  `sia_tipdxp_tdix` varchar(1) DEFAULT NULL COMMENT 'Tipo de diagnostico principal',
  `sia_dixre1_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 1 según CIE-10',
  `sia_dixre2_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 2 según CIE-10',
  `sia_dixre3_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 2 según CIE-10',
  `sia_dixcom_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico de la complicacion cuando exista según CIE-10',
  `adm_estsal_regr` varchar(1) DEFAULT NULL COMMENT 'Estado al salir: 1=Vivo 2= Muerto',
  `adm_dessal_regr` varchar(1) DEFAULT NULL COMMENT 'Destino al salir: 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion',
  `sia_tipdis_tdis` varchar(2) DEFAULT NULL COMMENT 'Tipo de Discapacidad postenfermedad al momento de la salida cuando aplique ejm: 1=Visual, 2=Motriz y mas',
  `adm_tipmue_regr` varchar(1) DEFAULT NULL COMMENT 'Muerte intrahospitalaria de pacientes admitidos: 1=En las primeras 48 horas 2= Despues de 48 horas',
  `sia_dixmue_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico de causa muerte cuando exista según CIE-10',
  `adm_fecmue_regr` date DEFAULT NULL COMMENT 'Fecha muerte dentro del servicio de hospitalizacion u Observacion en urgencia',
  `adm_hormue_regr` decimal(5,2) DEFAULT NULL COMMENT 'Hora  muerte en formato militar  (HH) ejm: 16',
  `adm_diases_regr` int(4) DEFAULT NULL COMMENT 'Numero dias de estancia en la IPS',
  `adm_horase_regr` int(4) DEFAULT NULL COMMENT 'Numero hora total  en estancia en la IPS',
  `adm_aparto_regr` varchar(1) DEFAULT NULL COMMENT 'Hubo atencion del parto : 1=SI 2=NO',
  `adm_tippar_regr` varchar(1) DEFAULT NULL COMMENT 'Tipo atencion del parto : 1=Parto 2=Aborto',
  `adm_actpar_regr` varchar(1) DEFAULT NULL COMMENT 'Tipo acto asistencia del parto : 1=Asistencia parto  normal  2=Parto quirugico (cesarea)',
  `adm_semges_regr` int(2) DEFAULT NULL COMMENT 'Numero semanas de gestación',
  `adm_fecpar_regr` date DEFAULT NULL COMMENT 'Fecha en que se realizo la atencion del parto',
  `adm_contrl_regr` varchar(1) DEFAULT NULL COMMENT 'se realizo control penatal 1=SI,2=No',
  `adm_conest_regr` int(5) DEFAULT NULL COMMENT 'Contador para generar los registros unicos de la tabla de nacimientos',
  `adm_observ_regr` text COMMENT 'Nota u observación del egreso',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro de egreso para admitidos   1=Abierta 2=Cerrada 3=Anulada',
  PRIMARY KEY (`adm_secegr_regr`),
  KEY `regr02` (`adm_secadm_rgad`),
  KEY `regr03` (`sia_idesec_usua`),
  KEY `regr04` (`hcl_nrohis_hicl`),
  KEY `regr05` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `admregnacimient` table : 
#

DROP TABLE IF EXISTS `admregnacimient`;

CREATE TABLE `admregnacimient` (
  `adm_secegr_regn` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial registro de naciemiento (generado por el sistema)',
  `adm_secegr_regr` varchar(20) DEFAULT NULL COMMENT 'Secuencial registro de egreso',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema (la madre del recien nacido)',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificacion del usuario o Paciente  según las normas vigentes para gestion de d atos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion del paciente: Registro civil, Cedula, Tarjeta de identidad y otros  (madre)',
  `adm_fecnac_regn` date DEFAULT NULL COMMENT 'Fecha de nacimiento del recien nacido',
  `sis_codsex_sexo` varchar(1) DEFAULT NULL COMMENT 'Sexo del del recien nacido',
  `adm_hornac_regn` decimal(5,2) DEFAULT NULL COMMENT 'Hora  del nacimiento recien nacido en formato militar  (HH) ejm: 16',
  `adm_peson_regn` int(5) DEFAULT NULL COMMENT 'Peso recien nacido, en gramos',
  `adm_tallan_regn` int(2) DEFAULT NULL COMMENT 'Talla recien nacido, en centimetros',
  `adm_semges_regr` int(2) DEFAULT NULL COMMENT 'Numero semanas de gestación al nacer',
  `sia_dixnac_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico de nacimiento según CIE-10',
  `adm_estnac_regn` varchar(1) DEFAULT NULL COMMENT 'Estado al nacer: 1=Vivo 2= Muerto',
  `adm_tipmue_regn` varchar(1) DEFAULT NULL COMMENT 'Muerte despues del nacimiento: 1=En las primeras 48 horas 2= Despues de 48 horas',
  `sia_dixmue_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico de causa muerte cuando exista según CIE-10',
  `adm_fecmue_regn` date DEFAULT NULL COMMENT 'Fecha muerte recien nacido dentro del servicio de hospitalizacion u Observacion en urgencia',
  `adm_hormue_regn` decimal(5,2) DEFAULT NULL COMMENT 'Hora  muerte recien nacido en formato militar  (HH) ejm: 16',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro de egreso para admitidos   1=Abierto 2=Cerrado 3=Anulado',
  PRIMARY KEY (`adm_secegr_regn`),
  KEY `regn02` (`adm_secegr_regr`),
  KEY `regn03` (`adm_secadm_rgad`),
  KEY `regn04` (`sia_idesec_usua`),
  KEY `regn06` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `admregurgencias` table : 
#

DROP TABLE IF EXISTS `admregurgencias`;

CREATE TABLE `admregurgencias` (
  `adm_secegr_regu` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial registro de egreso urgencias',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificacion del usuario o Paciente  según las normas vigentes para gestion de d atos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `hcl_nrohis_hicl` varchar(20) DEFAULT NULL COMMENT 'Numero o codigo de la Ficha de Historias Clinicas',
  `adm_fecegr_regu` date DEFAULT NULL COMMENT 'Fecha de egreso del servicio observacion en urgencias',
  `adm_horegr_regu` decimal(5,2) DEFAULT NULL COMMENT 'Hora  egreso en formato militar  (HH) ejm: 16',
  `adm_diases_regu` int(4) DEFAULT NULL COMMENT 'Numero dias de estancia en la IPS',
  `adm_horase_regu` int(4) DEFAULT NULL COMMENT 'Numero hora total  en estancia en la IPS',
  `adm_secaut_aegr` varchar(20) DEFAULT NULL COMMENT 'Numero Secuencial Autorizacion de egreso paciente',
  `hos_codesp_espa` varchar(20) DEFAULT NULL COMMENT 'Codigo registro traslado intrahospitalario cuando la salida de urgencias es un traslado a hospitalizacion',
  `sia_codpfa_prof` varchar(4) DEFAULT NULL COMMENT 'Codigo Profesional Que Autoriza salida o traslado a hospitalización',
  `sia_dixsal_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico de salida de urgencias con observacion según CIE-10',
  `sia_dixre1_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 1 según CIE-10',
  `sia_dixre2_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 2 según CIE-10',
  `sia_dixre3_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 2 según CIE-10',
  `adm_estsal_regu` varchar(1) DEFAULT NULL COMMENT 'Estado al salir: 1=Vivo 2= Muerto',
  `adm_dessal_regr` varchar(1) DEFAULT NULL COMMENT 'Destino al salir: 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion',
  `adm_tipmue_regu` varchar(1) DEFAULT NULL COMMENT 'Muerte intrahospitalaria de pacientes admitidos: 1=En las primeras 48 horas 2= Despues de 48 horas',
  `sia_dixmue_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico de causa muerte cuando exista según CIE-10',
  `adm_fecmue_regu` date DEFAULT NULL COMMENT 'Fecha muerte dentro del servicio de hospitalizacion u Observacion en urgencia',
  `adm_hormue_regu` decimal(5,2) DEFAULT NULL COMMENT 'Hora  muerte en formato militar  (HH) ejm: 16',
  `adm_observ_regu` text COMMENT 'Nota u observación del egreso',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro egreso urgencias  1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`adm_secegr_regu`),
  KEY `regu03` (`adm_secadm_rgad`),
  KEY `regu04` (`sia_idesec_usua`),
  KEY `regu05` (`hcl_nrohis_hicl`),
  KEY `regu06` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `admtipoatencion` table : 
#

DROP TABLE IF EXISTS `admtipoatencion`;

CREATE TABLE `admtipoatencion` (
  `adm_codtat_tatn` varchar(1) NOT NULL COMMENT 'Codigo Tipo de Atencion:1=Ambulatoria 2=Hospitalizacion 3=Urgencia',
  `adm_destat_tatn` varchar(20) DEFAULT NULL COMMENT 'Descripcion del tipo de Atencion según RIPS: Ambulatoria, Hospitalizacion y Urgencias',
  PRIMARY KEY (`adm_codtat_tatn`),
  KEY `tpat02` (`adm_destat_tatn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `admtriagemaconf` table : 
#

DROP TABLE IF EXISTS `admtriagemaconf`;

CREATE TABLE `admtriagemaconf` (
  `adm_nroreg_adct` varchar(3) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del registro triage',
  `adm_clasif_tria` varchar(1) DEFAULT NULL COMMENT 'Clasificacion de evaluacion Triage : 1= TRIAGE I  2= TRIAGE II  3= TRIAGE III  4= TRIAGE IV  5= TRIAGE V',
  `adm_remisi_tria` varchar(1) DEFAULT NULL COMMENT 'Destino remisión paciente despues de evaluación : 1 = Consulta Externa  2 = Consulta prioritaria  3 = Urgencia',
  `adm_titcla_adct` varchar(30) DEFAULT NULL COMMENT 'Titulo o nombre clasificacion Triage',
  `adm_descla_adct` text COMMENT 'Descripcion de clasificacion Triage según caracteristicas de la condicion clinica y fisiologica del paciente al llegar  y referencia en la normatividad',
  `adm_tiempo_adct` varchar(80) DEFAULT NULL COMMENT 'Descripcion corta del tiempo minimo o maximo  para que el paciente reciba atencion  medica según la conducta tommada, Ejemplo: Atencion medica ambulatoria antes de 72 horas',
  `adm_imagen_adct` varchar(60) DEFAULT NULL COMMENT 'Nombre de la imagen que representa el registro de clasificacion',
  `adm_icolor_adct` varchar(20) DEFAULT NULL COMMENT 'Color según codigo clasificacion triage',
  `adm_codoad_toad` varchar(1) DEFAULT NULL COMMENT 'Código Origen de Admisión o vía de ingreso a la institución (desde la tabla origen admisión o vía de ingreso a la institución):1=Urgencias 2=Consulta externa 3=Remitido 4=Nacido en la institución',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `sia_areing_aser` varchar(3) DEFAULT NULL COMMENT 'Código Área de Servicio Donde Ingresa o presta atención inicial, (este dato no cambia cuando hay traslados de área)',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo del centro de producción generado por el sistema',
  `adm_codtat_tatn` varchar(1) DEFAULT NULL COMMENT 'Código Tipo de Atención o ámbito donde se prestara el servicio :1=Ambulatoria 2=Hospitalización 3=Urgencia',
  `adm_codcex_tcex` varchar(2) DEFAULT NULL COMMENT 'Causa Externa Origen que origina la atención según Resolución: 3374 RIPS',
  `adm_estreg_adct` varchar(1) DEFAULT NULL COMMENT 'Estado del registro : 1= Activo  2=Inactivo',
  PRIMARY KEY (`adm_nroreg_adct`),
  KEY `adct02` (`adm_titcla_adct`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `admtriagemaestr` table : 
#

DROP TABLE IF EXISTS `admtriagemaestr`;

CREATE TABLE `admtriagemaestr` (
  `adm_nroreg_tria` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del registro triage',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo único de paciente en el sistema, se genera al crear el registro de usuario o cuando la base de datos es cargada en el sistema',
  `hcl_nrohis_hicl` varchar(20) DEFAULT NULL COMMENT 'Numero o código de la Ficha de Historias Clínicas electronica',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión paciente',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula, RC= Registro Civil, TI = Tarjeta de Identidad  AS= Adulto sin identificación y otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `sia_priape_usua` varchar(20) DEFAULT NULL COMMENT 'Primer apellido del usuario o paciente',
  `sia_segape_usua` varchar(30) DEFAULT NULL COMMENT 'Segundo apellido del usuario o paciente',
  `sia_prinom_usua` varchar(20) DEFAULT NULL COMMENT 'Primer nombre del usuario o paciente',
  `sia_segnom_usua` varchar(30) DEFAULT NULL COMMENT 'Segundo nombre del usuario o paciente',
  `sia_fecnac_usua` date DEFAULT NULL COMMENT 'Fecha nacimiento del usuario o paciente',
  `sis_codsex_sexo` varchar(1) DEFAULT NULL COMMENT 'Sexo del  usuario o paciente',
  `sia_nomusu_usua` varchar(50) DEFAULT NULL COMMENT 'Nombre concatenado del paciente (Apellidos y Nombres)',
  `sia_edapac_usua` int(3) DEFAULT NULL COMMENT 'Edad Paciente al momento de la atención',
  `sia_codmed_tmed` varchar(1) DEFAULT NULL COMMENT 'Unidad Medida Edad Paciente 1=Año 2=Mes 3=Día',
  `adm_gesfec_tria` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `adm_geshor_tria` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `adm_frecar_tria` float(5,2) DEFAULT NULL COMMENT 'Toma de signo vital frecuencia cardiaca',
  `adm_freres_tria` float(5,2) DEFAULT NULL COMMENT 'Toma de signo vital frecuencia respiratoria',
  `adm_tasist_tria` float(5,2) DEFAULT NULL COMMENT 'Tensión arterial sistolica',
  `adm_tadias_tria` float(5,2) DEFAULT NULL COMMENT 'Tensión arterial diastolica',
  `adm_temper_tria` float(5,2) DEFAULT NULL COMMENT 'Toma de signo vital Temperatura corporal',
  `adm_pesokg_tria` float(5,2) DEFAULT NULL COMMENT 'Peso corporal dado en kilogramos',
  `adm_tallac_tria` float(5,2) DEFAULT NULL COMMENT 'Talla (estatura del paciente) en centimetros',
  `adm_tiplle_tria` varchar(1) DEFAULT NULL COMMENT 'Tipo llegada para recibir la atencion: 1 =Caminando,2=Vehiculo particular,3= Ambulancia  y otros',
  `adm_motcon_tria` text COMMENT 'Motivo textual de consulta',
  `adm_clasif_tria` varchar(1) DEFAULT NULL COMMENT 'Clasificacion de evaluacion Triage : 1= TRIAGE I  2= TRIAGE II  3= TRIAGE III',
  `adm_remisi_tria` varchar(1) DEFAULT NULL COMMENT 'Destino remisión paciente despues de evaluación : 1 = Consulta Externa  2 = Consulta prioritaria  3 = Urgencia',
  `sia_coddia_tdia` varchar(4) DEFAULT NULL COMMENT 'Codgo del diagnostico según la tabla CIE-10 que determina el resultado de la evaluacion triage',
  `adm_observ_tria` text COMMENT 'Nota de observación',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Código de Eps o Asegurador según códigos asignados por la supersalud',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción en el cual se produce el evento',
  `sis_idemun_muni` varchar(5) DEFAULT NULL COMMENT 'Id Único Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio',
  `sis_codmun_muni` varchar(3) DEFAULT NULL COMMENT 'Código Municipio según DANE',
  `sis_coddep_dpto` varchar(2) DEFAULT NULL COMMENT 'Código  del departamento DANE',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atención  cuando hay varias sedes',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código Profesional que presta servicio',
  `sia_llaveb_usua` varchar(90) DEFAULT NULL COMMENT 'llave de búsqueda avanzada concatena:tipo ide+ identificacion+apellidos+nombres+eps',
  `adm_tipreg_tria` varchar(1) DEFAULT NULL COMMENT 'Tipo registro según destino valoracion inicial: 1 = Es valoración inicial 2 = Evaluación completa en consultorio triage',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado de procesos en atencion asistencial : 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`adm_nroreg_tria`),
  KEY `tria02` (`sia_idesec_usua`),
  KEY `tria03` (`hcl_nrohis_hicl`),
  KEY `tria04` (`sia_nroide_usua`),
  KEY `tria05` (`sia_priape_usua`),
  KEY `tria06` (`sia_segape_usua`),
  KEY `tria07` (`sia_prinom_usua`),
  KEY `tria08` (`sia_segnom_usua`),
  KEY `tria09` (`sia_codeps_teps`),
  KEY `tria10` (`sia_llaveb_usua`),
  KEY `tria11` (`sia_coddia_tdia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `admviaingreso` table : 
#

DROP TABLE IF EXISTS `admviaingreso`;

CREATE TABLE `admviaingreso` (
  `adm_codoad_toad` varchar(1) NOT NULL DEFAULT '' COMMENT 'Codigo Origen de Admision o via de ingreso a la institucion (desde la tabla origen admision o via de ingreso a la institución)',
  `adm_desoad_toad` varchar(40) DEFAULT NULL COMMENT 'Descripcion textual del origen de la admision o Via de Ingreso a la istitución',
  PRIMARY KEY (`adm_codoad_toad`),
  KEY `toad02` (`adm_desoad_toad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `carconceptfact` table : 
#

DROP TABLE IF EXISTS `carconceptfact`;

CREATE TABLE `carconceptfact` (
  `car_seccon_cacf` varchar(10) NOT NULL COMMENT 'Codigo unico del concepto generado por el sistema',
  `car_codcon_cacf` varchar(20) DEFAULT NULL COMMENT 'Codigo unico del concepto venta  según tarifario propio o según UNSPSC',
  `car_descon_cacf` varchar(240) DEFAULT NULL COMMENT 'Descripcion del concepto de venta facturacion',
  `fcm_valser_cacf` float(17,2) DEFAULT NULL COMMENT 'Valor base del  Servicio o producto para venta sin descuento y sin impuestos',
  `fcm_edtval_cacf` varchar(1) DEFAULT NULL COMMENT 'Editar el valor del servicio en la vista de facturacion, sin tener en cuenta valor fijado: 1=SI 2=No',
  `fcm_tiptar_dfac` varchar(4) DEFAULT NULL COMMENT 'Tipo codigo usado en Tarifario de venta servicios o productos: 001= UNSPSC Codificacion Colombiaa compra Eficiente 010 = GTIN Numeros Globales  Identificacion Productos 020 = Partida Arancelaria 999=Esntandar Propio Adoptado por el contribuyente',
  `fcm_codpro_fcpr` varchar(10) DEFAULT NULL COMMENT 'Codigo Producto segun clasificacion UNSPSC',
  `sis_coddes_side` varchar(6) DEFAULT NULL COMMENT 'Codigo tarifa  descuento aplicado al prodcuto en venta',
  `fcm_pordes_dfac` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de descuento aplicada (cuando el descuento se haya calculado en porcentaje)',
  `fcm_valbsi_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor de la base Imponible (base para el calculo de impuesto) este campo asume el valor mayor según los tipos de impustos aplicados',
  `car_conest_cacf` int(5) DEFAULT NULL COMMENT 'Contador para generar los registros únicos  detalles',
  `car_estreg_cacf` varchar(1) DEFAULT NULL COMMENT 'Estado registro: 1=Activo 2=Inactivo',
  PRIMARY KEY (`car_seccon_cacf`),
  KEY `cacf02` (`car_codcon_cacf`),
  KEY `cacf03` (`car_descon_cacf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `carconceptfactmd` table : 
#

DROP TABLE IF EXISTS `carconceptfactmd`;

CREATE TABLE `carconceptfactmd` (
  `car_seccon_cacd` varchar(10) NOT NULL COMMENT 'Codigo unico registro impuesto generado por el sistema',
  `car_seccon_cacf` varchar(10) DEFAULT NULL COMMENT 'Codigo unico del concepto venta al cual se aplicara el impuesto',
  `sis_tipoca_cacd` varchar(1) DEFAULT NULL COMMENT 'Tipo calculo al aplicar el impuesto: 1=Calcular antes del descuento 2=Calcular despues del descuento',
  `sis_tipapl_cacd` varchar(1) DEFAULT NULL COMMENT 'Tipo aplicación del impuesto 1=Aplicar Calculo del porcentaje 2=Aplicar Valor fijo sin deducción',
  `sis_codtar_simi` varchar(6) DEFAULT NULL COMMENT 'Codigo tarifa tipo impuesto viene de la tabla: SISMAESIMPUESMD',
  `sis_codimp_siim` varchar(3) DEFAULT NULL COMMENT 'Codigo tipo impuesto según tabla: SISMAESIMPUESMA',
  `fcm_valapl_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor del impuesto aplicado según SIS_TIPAPL_CACD  cuando se aplica valor y no el porcentaje',
  `car_estreg_cacd` varchar(1) DEFAULT NULL COMMENT 'Estado registro: 1=Activo 2=Inactivo',
  PRIMARY KEY (`car_seccon_cacd`),
  KEY `cacd02` (`car_seccon_cacf`),
  KEY `cacd03` (`sis_codtar_simi`),
  KEY `cacd04` (`sis_codimp_siim`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `carfemailgestioma` table : 
#

DROP TABLE IF EXISTS `carfemailgestioma`;

CREATE TABLE `carfemailgestioma` (
  `car_secreg_cagm` varchar(20) NOT NULL COMMENT 'Secuencial unico registro',
  `fcm_secraz_fcem` varchar(10) DEFAULT NULL COMMENT 'Codigo unico Razon Social empresa para gestion documentos DIAN',
  `car_gresum_cagm` varchar(1) DEFAULT NULL COMMENT 'Generar o no generar un archvo comprimido con todos los archivos marcados como incluidos que pertenencen a las facturas incluidas: 1=Generar Archivo Resumen 2=No generar archivo resumen',
  `car_arcnom_cagm` varchar(80) DEFAULT NULL COMMENT 'Nombre del archivo Resumen que se genarará, no incluir extencion sin espeacios y sin caracteres especiales',
  `car_gesori_cagm` varchar(2) DEFAULT NULL COMMENT 'Origen gestion correo: NA=Llamado desde el modulo gestion correo 01=Desde Gestion Cartera (cuenta de cobro) 02=Desde Facturacion Ventas (punto pos) 03=Desde Facturacion Medica',
  `car_secref_cagm` varchar(20) DEFAULT NULL COMMENT 'Codigo unico registro referencia: documento factura  cuenta de cobro  y otros según el tipo origen gestion  (campo CAR_GESORI_CAGM)',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero del documento o  factura generada y recibida en con éxito en DIAN',
  `car_tphost_caml` varchar(1) DEFAULT NULL COMMENT 'Tipo servidor de correo con el cual se realiza el envio: 1=Servidor de correo de Hotmail 2=Servidor de correo Gmail',
  `car_faddre_caml` varchar(150) DEFAULT NULL COMMENT 'Cuenta de correo desde el cual se envia el mail (se asme por defecto el que esta registrado en la razon social de la empresa)',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Código de Adquirente o Empresa cliente y/o tercero EPS o asegurador según módulos administrativos',
  `car_taddre_caml` varchar(150) DEFAULT NULL COMMENT 'Cuenta de correo destino al cual se envia el correo (se asme por defecto el que esta registrado en la razon social del adquirente)',
  `car_caddre_caml` varchar(150) DEFAULT NULL COMMENT 'Cuenta de correo segundo destinatario al cual se envia el mensaje de correo',
  `car_subjec_caml` varchar(150) DEFAULT NULL COMMENT 'Asunto del correo',
  `car_bodyms_caml` text COMMENT 'Texto (Body) cuerpo del mensaje (puede venir de una plantilla)',
  `car_envfec_caml` date DEFAULT NULL COMMENT 'Fecha del envio al adquirente',
  `car_envhor_caml` decimal(5,2) DEFAULT NULL COMMENT 'Hora de envio correo al adquirente',
  `car_estenv_caml` varchar(1) DEFAULT NULL COMMENT 'Estado del envio: 1=Recibido con éxito, 2=Hubo algun error al enviar el correo 3=Pendiente para enviar',
  `car_merror_caml` varchar(180) DEFAULT NULL COMMENT 'Descripcion del error de envio cuando este ocurra',
  `car_secdet_cagm` int(8) DEFAULT NULL COMMENT 'Campo para generar el secuencial de los registros detalles',
  `car_estpro_cagm` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado y enviado al menos una vez',
  PRIMARY KEY (`car_secreg_cagm`),
  KEY `cagm02` (`fcm_secraz_fcem`),
  KEY `cagm03` (`sis_idterc_sitr`),
  KEY `cagm04` (`car_subjec_caml`),
  KEY `cagm05` (`car_envfec_caml`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `carfemailgestiomd` table : 
#

DROP TABLE IF EXISTS `carfemailgestiomd`;

CREATE TABLE `carfemailgestiomd` (
  `car_secreg_camx` varchar(20) NOT NULL COMMENT 'Secuencial unico registro (generado por el sistema)',
  `car_gestor_camx` varchar(1) DEFAULT NULL COMMENT 'Para saber si pertence al gestor de correos o a la gestion de un solo documento desde facturacion: 1=Pertenece al Gestor de correos 2=Pertenece a un documento factura',
  `car_secreg_cagm` varchar(20) DEFAULT NULL COMMENT 'Secuencial registro cuando el documento pertenece al gestor de correo',
  `fcm_secreg_mfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico facturada-Nota Credito-Nota Debito (generado por el sistema)',
  `car_incarc_camx` varchar(1) DEFAULT NULL COMMENT 'Marcado como incluido o excluido para el envio: 1=Incluido 2=Excluido',
  `car_tiparc_camx` varchar(5) DEFAULT NULL COMMENT 'Tipo archivo: ZIP/DOC/XML/XLS/  y otros',
  `car_orgarc_camx` varchar(1) DEFAULT NULL COMMENT 'Origen del archivo 1=Generado desde gestion Facturacion eletronica 2=Agregado como Adjunto',
  `car_arcnom_camx` varchar(80) DEFAULT NULL COMMENT 'Nombre del archivo fisico con extencion pero sin la ruta de acceso a el',
  `car_arpath_camx` varchar(200) DEFAULT NULL COMMENT 'Nombre del archivo fisico con extencion  y con ruta fisica donde esta localizado',
  `car_genfec_camx` date DEFAULT NULL COMMENT 'Fecha de generacion o cuando fue cargado como adjunto',
  `car_genhor_camx` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que fue generado o cargado como adjunto',
  `car_estreg_camx` varchar(1) DEFAULT NULL COMMENT 'Estado del registro según envio : 1=Activo 2=InactivoEnviado a dian con Éxito',
  PRIMARY KEY (`car_secreg_camx`),
  KEY `camx02` (`car_secreg_cagm`),
  KEY `camx03` (`fcm_secreg_mfac`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `carfemailgestiomf` table : 
#

DROP TABLE IF EXISTS `carfemailgestiomf`;

CREATE TABLE `carfemailgestiomf` (
  `car_secreg_cagf` varchar(20) NOT NULL COMMENT 'Secuencial unico registro email para evio (generado por el sistema)',
  `car_secreg_cagm` varchar(20) DEFAULT NULL COMMENT 'Secuencial registro maestro gestor de correos',
  `fcm_secreg_mfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico de la orden Factura-Nota Debito-Nota-Credito (generado por el sistema)',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero Dian del documento generado al confirmar el documento y enviado a DIAN (aceptado con éxito en DIAN)',
  `car_estreg_cagf` varchar(1) DEFAULT NULL COMMENT 'Estado del registro según envio : 1=Activo 2=InactivoEnviado a dian con Éxito',
  PRIMARY KEY (`car_secreg_cagf`),
  KEY `cagf02` (`car_secreg_cagm`),
  KEY `cagf03` (`fcm_secreg_mfac`),
  KEY `cagf04` (`fcm_numfac_mfac`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `carmaesfactuma` table : 
#

DROP TABLE IF EXISTS `carmaesfactuma`;

CREATE TABLE `carmaesfactuma` (
  `car_secfac_camf` varchar(20) NOT NULL COMMENT 'Codigo unico secuencial registro',
  `fcm_typdoc_fctd` varchar(3) DEFAULT NULL COMMENT 'Tipos de documentos para envio a Dian: 01=Factura electrónica de Venta 02=Factura electrónica venta-xportación 91=Nota Credito 92=Nota Debito y otros',
  `car_prnobs_camf` varchar(1) DEFAULT NULL COMMENT 'Enviar la observacion a la factura impresa: 1=Imprimir la observacion 2=No imprimir la observacion',
  `car_observ_camf` varchar(240) DEFAULT NULL COMMENT 'Nota de Observación',
  `car_prnnot_camf` varchar(1) DEFAULT NULL COMMENT 'Enviar la nota inferior a factura  impresa: 1=Imprimir la nota inferior 2=No imprimir la la nota inferior',
  `car_medpag_camf` varchar(240) DEFAULT NULL COMMENT 'Descripcion y numeros de cuentas bancarias (Nota de pago en factura)',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Codigo de Eps o Asegurador según codigos asignados por la supersalud',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Código de Empresa cliente y/o tercero EPS o asegurador según módulos administrativos',
  `fcm_secraz_fcem` varchar(10) DEFAULT NULL COMMENT 'Codigo unico Razon Social empresa para gestion documentos DIAN',
  `fcm_secres_srfa` varchar(10) DEFAULT NULL COMMENT 'Codigo relacion con resolución Dian con la cual se genera la factura',
  `car_nrofac_camf` varchar(20) DEFAULT NULL COMMENT 'Numero de factura generado con resolucion Dian',
  `car_fecfac_camf` date DEFAULT NULL COMMENT 'Fecha de la factura (fecha en que fue cerrada y generado el secuencial de factrua)',
  `car_diavfa_camf` int(5) DEFAULT NULL COMMENT 'Numero de dias para vigencia de factura de venta el sistema realiza el calculo del dia final',
  `fcm_horfac_camf` decimal(5,2) DEFAULT NULL COMMENT 'Hora emision de la factura',
  `fcm_valbru_camf` decimal(17,2) DEFAULT NULL COMMENT 'Valor total  bruto facturado del servicio sin ninguna deducción: FCM_VALSER_SIPS x FCM_TOTUNI_DFAC',
  `car_valfac_camf` decimal(17,2) DEFAULT NULL COMMENT 'Valor total a cobrar de la factura generada con codigo DIAN',
  `fcm_codest_fcws` varchar(3) DEFAULT NULL COMMENT 'Estado gestion WS Dian: R01=Enviada y aceptada con Éxito R02=Enviada con errores en validacion C01=El Servicio Dian no respondio /... Otros',
  `fcm_valbsi_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor de la base Imponible (base para el calculo de impuesto)',
  `fcm_valiva_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IVA aplicado',
  `fcm_valicd_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IC - Impuesto al Consumo Departamental Nomianl',
  `fcm_valica_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor ICA - Impuesto de Industria, Comercio y Aviso',
  `fcm_valinc_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor INC Impuesto Nacional al Consumo',
  `fcm_valrti_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor RetVA Retención sobre el IVA',
  `fcm_valrtf_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor ReteFuente (reteción en la fuente)',
  `fcm_valrtc_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del ReteICA aplicado',
  `fcm_valcre_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del ReteCRE aplicado',
  `fcm_valfth_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del FtoHorticultura aplicado',
  `fcm_valtim_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del Timbre aplicado',
  `fcm_valbol_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor Impuesto Bolsas aplicado',
  `fcm_valicr_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IVA aplicado',
  `fcm_valicb_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del INCombustibles aplicado',
  `fcm_valscb_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor de Sobretasa Combustibles aplicado',
  `fcm_valsco_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del Sordicom aplicado',
  `fcm_valftr_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor figura tributaria aplicada',
  `fcm_metpag_mfac` varchar(1) DEFAULT NULL COMMENT 'Metodo de pago 1=Contado 2=Credito',
  `fcm_codmpg_fcmp` varchar(7) DEFAULT NULL COMMENT 'FAN02: Codigo secuencial medios de pago según  cuadro  No: 6.3.4.2 - Medios de Pago: cbc:PaymentMeansCode : 1=Medio no definido  hasta … ZZZ=Acuerdo mutuo',
  `fcm_fecven_mfac` date DEFAULT NULL COMMENT 'Fecha vencimiento factura contada desde el momento que fue  generado el secuencial factrua Dian',
  `car_tipfac_camf` varchar(1) DEFAULT NULL COMMENT 'incluye cuenta de cobro facutracion 1=Incluye  cuenta de cobro 2=No Incluye cuenta de cobro',
  `fcm_secreg_mfcb` varchar(20) DEFAULT NULL COMMENT 'codigo cuenta de cobro realizada en facturacion que esta asociada a esta factura de venta',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero de la factura generada al confirmar la factura o cuenta de cobro',
  `fcm_fecfac_mfac` date DEFAULT NULL COMMENT 'Fecha de la factura (fecha en que fue confirmada y generado el secuencial de factrua)',
  `fcm_valbru_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total  bruto facturado del servicio sin ninguna deducción: FCM_VALSER_SIPS x FCM_TOTUNI_DFAC',
  `fcm_valdes_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total del descuento realizado al cliente',
  `fcm_valcpa_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total del copago y o cuota moderadora recudado en  servicios',
  `fcm_valfac_dfac` decimal(17,3) DEFAULT NULL COMMENT 'Valor total del servicio facturado incluyendo el IVA  y con las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DFAC+FCM_VALCOM_DFAC',
  `fcm_sercre_mfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico Documento Factura o  Documento Nota Credito  de referencia por la cual se genera este documento',
  `fcm_idrcre_mfac` varchar(20) DEFAULT NULL COMMENT 'Prefijo + Número de la nota crédito  (se escribe numero de factura cuando este documento es nota credito) referenciada: Se debe diligenciar únicamente cuando la FE se origina a partir de la corrección ajuste que se da mediante un Nota Crédito',
  `fcm_serdeb_mfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico Documento Factura o  Documento Nota Debito  de referencia por la cual se genera este documento',
  `fcm_idrdeb_mfac` varchar(20) DEFAULT NULL COMMENT 'Prefijo + Número de la nota debito referenciada (se escribe numero de factura cuando este documento es nota debito),  Se debe diligenciar únicamente cuando la FE se origina a partir de la correcció o ajuste que se da mediante un Nota Debito',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del factuador  usuario del sistema que que realiza la ultima modificacion',
  `car_conest_camf` int(5) DEFAULT NULL COMMENT 'Contador para generar los registros únicos detalles conceptos de la factura',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`car_secfac_camf`),
  KEY `camf02` (`car_observ_camf`),
  KEY `camf03` (`cto_seccon_cont`),
  KEY `camf04` (`sia_codeps_teps`),
  KEY `camf05` (`fcm_secreg_mfcb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `carmaesfactumd` table : 
#

DROP TABLE IF EXISTS `carmaesfactumd`;

CREATE TABLE `carmaesfactumd` (
  `car_secreg_cadf` varchar(20) NOT NULL COMMENT 'Codigo unico secuencial registro',
  `car_secfac_camf` varchar(10) DEFAULT NULL COMMENT 'Codigo relacion con maestro facturas',
  `car_seccon_cacf` varchar(10) DEFAULT NULL COMMENT 'Codigo unico del conceptoen maestro conceptos de venta',
  `car_codcon_cacf` varchar(10) DEFAULT NULL COMMENT 'Codigo unico del concepto venta  según tarifario propio o según UNSPSC',
  `fcm_codpro_fcpr` varchar(10) DEFAULT NULL COMMENT 'Codigo Producto segun clasificacion UNSPSC',
  `car_descon_cadf` varchar(240) DEFAULT NULL COMMENT 'Descripcion concepto detalle del cobro y valor facturado',
  `car_totuni_cadf` int(6) DEFAULT NULL COMMENT 'Total cantidad del item concepto facturado',
  `car_valuni_cadf` decimal(17,2) DEFAULT NULL COMMENT 'Valor unitario del item concepto',
  `fcm_valbru_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total  bruto facturado del servicio sin ninguna deducción: FCM_VALSER_SIPS x FCM_TOTUNI_DFAC',
  `fcm_valbsi_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor de la base Imponible (base para el calculo de impuesto)',
  `sis_coddes_side` varchar(6) DEFAULT NULL COMMENT 'Codigo tarifa  descuento aplicado al prodcuto en venta',
  `fcm_pordes_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje de descuento aplicada (cuando el descuento se haya calculado en porcentaje)',
  `fcm_valdes_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total del descuento realizado al cliente',
  `fcm_poriva_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación IVA',
  `fcm_valiva_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IVA aplicado',
  `fcm_poricd_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación IC -Impuesto al consumo departamental',
  `fcm_valicd_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IC - IImpuesto al consumo departamental',
  `fcm_porica_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ICA Impuesto de Industria Comercio y Aviso',
  `fcm_valica_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor ICA ICA Impuesto de Industria Comercio y Aviso',
  `fcm_porinc_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación INC Impuesto Nacional al Consumo',
  `fcm_valinc_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor INC Impuesto Nacional al Consumo',
  `fcm_porrti_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación RetVA Retención sobre el IVA',
  `fcm_valrti_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor RetVA Retención sobre el IVA',
  `fcm_porrtf_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ReteFuente (reteción en la fuente)',
  `fcm_valrtf_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor ReteFuente (reteción en la fuente)',
  `fcm_porrtc_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ReteICA',
  `fcm_valrtc_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del ReteICA aplicado',
  `fcm_porcre_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ReteCree',
  `fcm_valcre_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del ReteCRE aplicado',
  `fcm_porfth_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación FtoHorticultura',
  `fcm_valfth_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del FtoHorticultura aplicado',
  `fcm_portim_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Timbre',
  `fcm_valtim_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del Timbre aplicado',
  `fcm_porbol_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Bolsas',
  `fcm_valbol_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor Impuesto Bolsas aplicado',
  `fcm_poricr_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación INCarbono',
  `fcm_valicr_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IVA aplicado',
  `fcm_poricb_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicado INCombustibles',
  `fcm_valicb_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del INCombustibles aplicado',
  `fcm_porscb_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Sobretasa Combustibles',
  `fcm_valscb_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor de Sobretasa Combustibles aplicado',
  `fcm_porsco_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Sordicom',
  `fcm_valsco_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del Sordicom aplicado',
  `fcm_porftr_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación figura tributaria',
  `fcm_valftr_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor figura tributaria aplicada',
  `fcm_subtot_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor subtotal del registro item',
  `fcm_valfac_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total del servicio facturado incluyendo el IVA  y con las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DFAC+FCM_VALCOM_DFAC',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`car_secreg_cadf`),
  KEY `cadf02` (`car_secfac_camf`),
  KEY `cadf03` (`car_seccon_cacf`),
  KEY `cadf04` (`car_codcon_cacf`),
  KEY `cadf05` (`fcm_codpro_fcpr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `citcausacancita` table : 
#

DROP TABLE IF EXISTS `citcausacancita`;

CREATE TABLE `citcausacancita` (
  `cit_caucan_ccan` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo unico del registro digitado por el usuario',
  `cit_descan_ccan` varchar(40) DEFAULT NULL COMMENT 'Decripcion de la cuasa cancelacion cita',
  PRIMARY KEY (`cit_caucan_ccan`),
  KEY `ccan02` (`cit_descan_ccan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `citestadoascita` table : 
#

DROP TABLE IF EXISTS `citestadoascita`;

CREATE TABLE `citestadoascita` (
  `cit_estcit_easi` varchar(1) NOT NULL DEFAULT '' COMMENT 'Estado de la cita o espacio de tiempo: 1=Libre 2=Asignada 3=Confirmada o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algún motivo)',
  `cit_descit_easi` varchar(40) DEFAULT NULL COMMENT 'Descripción del estado asignación cita',
  PRIMARY KEY (`cit_estcit_easi`),
  KEY `easi02` (`cit_descit_easi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `citmaesasigcita` table : 
#

DROP TABLE IF EXISTS `citmaesasigcita`;

CREATE TABLE `citmaesasigcita` (
  `cit_codasi_mcit` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo unico del registro asignacion de cita a paciente (generado por el sistema)',
  `cit_codtur_turn` varchar(20) DEFAULT NULL COMMENT 'Codigo unico del turno medico que realizara la atencion',
  `cit_ordvis_mcit` int(5) DEFAULT NULL COMMENT 'Orden visualizacion del registro de turno',
  `cit_ordcon_mcit` int(5) DEFAULT NULL COMMENT 'Orden de confirmacion en facturacion o llegada a consultorio',
  `cit_codspr_spro` varchar(5) DEFAULT NULL COMMENT 'Codigo unico del servicio para programacion y gestion en citas medicas y otros ejm =S001 = Consulta externa S003=Consulta Control pyp Adulto joven',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atencion  cuando hay varias sedes',
  `sia_codpfa_prof` varchar(4) DEFAULT NULL COMMENT 'Codigo del Profesional que presta servicio medico',
  `sia_codcon_ctor` varchar(10) DEFAULT NULL COMMENT 'Codigo del consultorio donde se prestara el servicio',
  `sia_codesp_esme` varchar(10) DEFAULT NULL COMMENT 'Codigo de la especialidad medica que aplica al  servicio',
  `cit_proqrx_mcit` varchar(1) DEFAULT NULL COMMENT 'Cita para progracion de Cirugia: 1=Cirugia 2=Cita no Quirurgica',
  `adm_codtat_tatn` varchar(1) DEFAULT NULL COMMENT 'Codigo ambito dende se prestara el servicio :1=Ambulatoria 2=Hospitalizacion 3=Urgencia',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificacion del usuario o Paciente  según las normas vigentes para gestion de d atos ejm: CC= Cedula, RC= Rgistro Civil, TI = Tarjeta de Identidad  AS= Adulto sin idetificacion y otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Registro de atencion o Admisión del paciente, cuando cumple la cita',
  `cit_fecsol_mcit` date DEFAULT NULL COMMENT 'Fecha solicitud de cita por parte del usuario',
  `cit_horsol_mcit` decimal(5,2) DEFAULT NULL COMMENT 'Hora solicitud de cita (en formato militar) ejemplo:  14.00 (dos de la tarde)',
  `cit_fecreq_mcit` date DEFAULT NULL COMMENT 'Fecha para la cual el usuario requiere la cita (esta puede ser igual a la fecha de programacion cita cuando hay espacio para la asignacion)',
  `cit_feccit_mcit` date DEFAULT NULL COMMENT 'Fecha programada para la cita',
  `cit_horcon_mcit` decimal(5,2) DEFAULT NULL COMMENT 'Hora llegada del usuario a confirmacion de cita (en formato militar) ejemplo: 14.00  (dos de la tarde)',
  `cit_mindur_turn` int(3) DEFAULT NULL COMMENT 'Numero minutos que demora la prestacion del servicio ejm 30 es un servicio que demora treinta minutos',
  `cit_horini_mcit` decimal(5,2) DEFAULT NULL COMMENT 'Hora programada para el inicio de la atencion medica (en formato militar) ejemplo:  14.00  (dos de la tarde)',
  `cit_horfni_mcit` decimal(5,2) DEFAULT NULL COMMENT 'Hora programada para finalizar la atencion medica (en formato militar) ejemplo:  14.00  (dos de la tarde)',
  `cit_horina_mcit` decimal(5,2) DEFAULT NULL COMMENT 'Hora real en que inicio la atencion medica (en formato militar)',
  `cit_horfna_mcit` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que finaliza la atencion medica (en formato militar)',
  `cit_idehin_mcit` int(12) DEFAULT NULL COMMENT 'Id o llave unica generada a partir de hora inicio cita,  para validacion rango o  vista en Browser formato: AñoInicio+MesInicio+DiaInicio+HoraInicio+MinutoInicio',
  `cit_idehfn_mcit` int(12) DEFAULT NULL COMMENT 'Id o llave unica generada a partir de hora fin cita,  para validacion rango  formato: AñoFin+MesFin+DiaFin+HoraFin+MinutoFin',
  `cit_tipsol_mcit` varchar(1) DEFAULT NULL COMMENT 'Tipo de solicitud de la Cita o programacion: 1= Solicitada en Ventanilla 2= Telefonica 3= Programa de control 4= Asiganacion por cirugia o especialidad',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Codigo de Eps o Asegurador según codigos asignados por la supersalud',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo centro de produccion donde se presta el servicio solo aplicable para tipo de registros evolucion (para envio a facturacion)',
  `cit_caucan_ccan` varchar(2) DEFAULT NULL COMMENT 'Causa de Cancelacion de la Cita medica',
  `cit_feccan_mcit` date DEFAULT NULL COMMENT 'Fecha canelacion de cita por parte del usuario',
  `cit_horcan_mcit` decimal(5,2) DEFAULT NULL COMMENT 'Hora cancelacion de cita (en formato militar) ejemplo: 14.00 (dos de la tarde)',
  `cit_notcan_mcit` varchar(90) DEFAULT NULL COMMENT 'Nota textual cancelacion cita, cuando sea requerida',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código de  usuario facturador asigna la cita al paciente',
  `sys_codusc_usux` varchar(5) DEFAULT NULL COMMENT 'Código de  usuario facturador que confirma la cita al paciente',
  `cit_estcit_easi` varchar(1) DEFAULT NULL COMMENT 'Estado de la cita o espacio de tiempo: 1=Libre 2=Asignada 3=Confirmada o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algun motivo)',
  `sis_estpro_espr` varchar(20) DEFAULT NULL COMMENT 'Descripcion textual del estado de turno  1= Abierto, 2= Cerrado  Y 3= Anulado',
  PRIMARY KEY (`cit_codasi_mcit`),
  KEY `mcit02` (`cit_idehin_mcit`),
  KEY `mcit03` (`cit_idehfn_mcit`),
  KEY `mcit04` (`sia_idesec_usua`),
  KEY `mcit05` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `citmaesdetacita` table : 
#

DROP TABLE IF EXISTS `citmaesdetacita`;

CREATE TABLE `citmaesdetacita` (
  `cit_codspt_cide` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código único del registro (generado por el sistema)',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código único del registro asignación de cita a paciente (generado por el sistema)',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Código único secuencial del servicio IPS con el que esta relacionado (es obligatorio)',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (puede ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `sia_tipact_tsac` varchar(1) DEFAULT NULL COMMENT 'Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial 2=Promoción y Prevención 3=Salud publica 4= todas o General',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Código del centro de producción dentro de las diferentes áreas de servicios (para registro de facturación)',
  `fcm_totuni_dfac` int(10) DEFAULT NULL COMMENT 'Total de unidades para facturar o receta medica del servicio o suministro',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Generar registro actividad en historial clinico: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1 =Activo 2=Inactivo',
  PRIMARY KEY (`cit_codspt_cide`),
  KEY `cide02` (`cit_codasi_mcit`),
  KEY `cide03` (`fcm_idesec_sips`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `citmaestroturno` table : 
#

DROP TABLE IF EXISTS `citmaestroturno`;

CREATE TABLE `citmaestroturno` (
  `cit_codtur_turn` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo unico del registro turno medico  (generado por el sistema)',
  `cit_destur_turn` varchar(80) DEFAULT NULL COMMENT 'Descripcion textual del turno, requerido para  filtro de busquedas ejm: Lunes 10 marzo de 2013 07:00:AM - 12:00:PM',
  `cit_secfpr_turn` int(15) DEFAULT NULL COMMENT 'llave unica fin del turno para validacion rango horas del turno formato: AñoFin+MesFin+DiaDia+HoraFin+MinutoFin',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atencion  cuando hay varias sedes',
  `sia_codpfa_prof` varchar(4) DEFAULT NULL COMMENT 'Codigo del Profesional que presta servicio medico',
  `sia_codcon_ctor` varchar(10) DEFAULT NULL COMMENT 'Codigo del consultorio donde se prestara el servicio',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `cit_fecitr_turn` date DEFAULT NULL COMMENT 'Fecha inicio del turno laboral',
  `cit_horini_turn` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que inicio la atencion medica (en formato militar)',
  `cit_fecftr_turn` date DEFAULT NULL COMMENT 'Fecha fin del turno laboral',
  `cit_horfin_turn` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que finaliza la atencion medica (en formato militar)',
  `cit_idehin_turn` int(12) DEFAULT NULL COMMENT 'Id o llave unica generada a partir de hora inicio atencion ,  para validacion rango o  vista en Browser formato: AñoInicio+MesInicio+DiaInicio+HoraInicio+MinutoInicio',
  `cit_idehfn_turn` int(12) DEFAULT NULL COMMENT 'Id o llave unica generada a partir de hora fin turno,  para validacion rango  formato AñoFin+MesFin+DiaFin+HoraFin+MinutoFin',
  `cit_mindur_turn` int(3) DEFAULT NULL COMMENT 'Numero minutos que demora cada servicio a un paciente ejemplo: 30 es un servicio que demora treinta minutos',
  `cit_hortdt_turn` float(5,2) DEFAULT NULL COMMENT 'Numero de Horas totales que demora el turno  (hacer deduccion según hora inicio y hora fin) ejm: 8.20 => ocho horas con veinte minutos',
  `cit_totcit_turn` int(4) DEFAULT NULL COMMENT 'Total de espacios de citas que se atenderan en el turno, (resulta de dividir tiempo total del turno entre minutos de una cita)',
  `cit_conasi_turn` int(4) DEFAULT NULL COMMENT 'Contador para generar numero orden  de asiganacion del turno (orden secuencial), cuando es solicitado por un paciente',
  `cit_totasi_turn` int(4) DEFAULT NULL COMMENT 'Contador de citas asignadas (para saber cuantas ya estan asignadas)',
  `cit_concit_turn` int(4) DEFAULT NULL COMMENT 'Contador para generar los codigos de citas asignadas en el turno',
  `cit_concon_turn` int(4) DEFAULT NULL COMMENT 'Contador para generar orden de confirmacion en facturacion o llegada a consultorio',
  `sis_estpro_espr` varchar(20) DEFAULT NULL COMMENT 'Descripcion textual del estado de turno  1= Abierto, 2= Cerrado  Y 3= Anulado',
  PRIMARY KEY (`cit_codtur_turn`),
  KEY `turn02` (`cit_idehin_turn`),
  KEY `turn03` (`cit_idehfn_turn`),
  KEY `turn04` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `citservicioprog` table : 
#

DROP TABLE IF EXISTS `citservicioprog`;

CREATE TABLE `citservicioprog` (
  `cit_codspr_spro` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico del servicio para programacion y gestion en citas medicas y otros (Generado por el sistema) ejm =S001 = Consulta externa S003=Consulta Control pyp Adulto joven',
  `cit_desspr_spro` varchar(80) DEFAULT NULL COMMENT 'Descripcion o nombre del servicio a programar',
  `cit_indspr_spro` varchar(1) DEFAULT NULL COMMENT 'Servicio para programacion individual o grupal (aplica para un  o un grupo de pacientes) : 1= Individual 2=Grupal',
  `cit_nropas_spro` int(3) DEFAULT NULL COMMENT 'Numero total de pacientes que cubre el servicio en la programacion (uno es el minimo)',
  `cit_indmed_spro` varchar(250) DEFAULT NULL COMMENT 'Indicaciones medicas para el paciente (se imprimen en el reporte de asigancion cita que se entrega al paciente)',
  `cit_hordur_spro` int(3) DEFAULT NULL COMMENT 'Numero de  minutos que demora la prestacion del servicio por cada paciente ejm 00:30 es un servicio que demora treinta minutos',
  `sia_codesp_esme` varchar(10) DEFAULT NULL COMMENT 'Codigo de la especialidad medica que aplica al  servicio',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS con el que esta relacionado (no es obligatorio)',
  `adm_codtat_tatn` varchar(1) DEFAULT NULL COMMENT 'Codigo Tipo de Atencion o ambito dende se prestara el servicio :1=Ambulatoria 2=Hospitalizacion 3=Urgencia',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo del centro de producción dentro de las diferentes areas de servicos (para registro de facturacion)',
  `cit_incali_spro` varchar(2) DEFAULT NULL COMMENT 'Informe indicador calida citas : NA = No aplica 1=Cita primera vez medicina interna (Resolución 0256 de 2016)',
  `fcm_tiprfa_mfac` varchar(1) DEFAULT NULL COMMENT 'Tipo registro factura generada: 1= Registro ordenes de servicios(pre factura) 2= Numero de Factura Valida Dian',
  `cit_contad_spro` int(5) DEFAULT NULL COMMENT 'Contador para generar codigos unicos  registros de servicios incluidos en el protocolo medico',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del programa: 1 =Activo 2=Inactivo',
  PRIMARY KEY (`cit_codspr_spro`),
  KEY `spro02` (`cit_desspr_spro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `citservprotocol` table : 
#

DROP TABLE IF EXISTS `citservprotocol`;

CREATE TABLE `citservprotocol` (
  `cit_codspt_sprt` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo unico del registro (generado por el sistema)',
  `cit_codspr_spro` varchar(5) DEFAULT NULL COMMENT 'Codigo unico del servicio para programacion y gestion en citas medicas y otros ejm =S001 = Consulta externa S003=Consulta Control pyp Adulto joven',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS con el que esta relacionado (es obligatorio)',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (puede ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `sia_tipact_tsac` varchar(1) DEFAULT NULL COMMENT 'Tipo servicio o actividad según manual de Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial 2=Promoción y Prevención 3=Salud publica 4= todas o General',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo del centro de producción al cual esta asociado el servicio por defecto',
  `fcm_totuni_dfac` int(10) DEFAULT NULL COMMENT 'Total de unidades para facturar o receta medica del servicio o suministro',
  `cit_incrme_sprt` varchar(1) DEFAULT NULL COMMENT 'Incluir en receta medica: 1 =SI 2=NO',
  `cit_incfac_sprt` varchar(1) DEFAULT NULL COMMENT 'Incluir en servicios para facturación: 1 =SI 2=NO',
  `cit_incfrm_sprt` varchar(1) DEFAULT NULL COMMENT 'Incluir en servicios para entrega en farmacia: 1 =SI 2=NO',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Generar Registro actividad en historial clinico: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1 =Activo 2=Inactivo',
  PRIMARY KEY (`cit_codspt_sprt`),
  KEY `sprt02` (`cit_codspr_spro`),
  KEY `sprt03` (`fcm_idesec_sips`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `conareasfuncion` table : 
#

DROP TABLE IF EXISTS `conareasfuncion`;

CREATE TABLE `conareasfuncion` (
  `con_codafu_afun` varchar(3) NOT NULL DEFAULT '' COMMENT 'Codigo area funcional de la empresa',
  `con_desafu_afun` varchar(30) DEFAULT NULL COMMENT 'Nombre del Area funcional',
  PRIMARY KEY (`con_codafu_afun`),
  KEY `afun02` (`con_desafu_afun`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `concentrodcosto` table : 
#

DROP TABLE IF EXISTS `concentrodcosto`;

CREATE TABLE `concentrodcosto` (
  `con_codsco_ccos` varchar(6) NOT NULL DEFAULT '' COMMENT 'Codgio del centro de costo generado por el sistema',
  `con_dessco_ccos` varchar(40) DEFAULT NULL COMMENT 'Nombre o descripción del centro de costo',
  `con_estsco_ccos` varchar(1) DEFAULT NULL COMMENT 'Estado  del centro de costo: 1=Activo  2=Inactivo',
  PRIMARY KEY (`con_codsco_ccos`),
  KEY `ccos02` (`con_dessco_ccos`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `conclasecuentas` table : 
#

DROP TABLE IF EXISTS `conclasecuentas`;

CREATE TABLE `conclasecuentas` (
  `con_codcla_ccue` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo según clases contables',
  `con_descla_ccue` varchar(30) DEFAULT NULL COMMENT 'Descripcion de la clase contable',
  `con_natcla_ccue` varchar(10) DEFAULT NULL COMMENT 'Naturaleza de la clase contable: DEBITO o CREDITO',
  `con_tipcla_ccue` varchar(10) DEFAULT NULL COMMENT 'Tipo de documento al que pertenecerá la clase contable',
  PRIMARY KEY (`con_codcla_ccue`),
  KEY `ccue02` (`con_descla_ccue`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `connivelcuentas` table : 
#

DROP TABLE IF EXISTS `connivelcuentas`;

CREATE TABLE `connivelcuentas` (
  `con_codniv_ncue` varchar(1) NOT NULL DEFAULT '' COMMENT 'Codigo nivel de la cuenta contable  según normas',
  `con_desniv_ncue` varchar(20) DEFAULT NULL COMMENT 'Descripcion nivel cuenta contable',
  PRIMARY KEY (`con_codniv_ncue`),
  KEY `ncue02` (`con_desniv_ncue`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `conplancuentas` table : 
#

DROP TABLE IF EXISTS `conplancuentas`;

CREATE TABLE `conplancuentas` (
  `con_codcue_tpuc` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo cuenta contable según el PUC',
  `con_descue_tpuc` varchar(50) DEFAULT NULL COMMENT 'Descripcion de la cuenta según el PUC',
  `con_cuemay_tpuc` varchar(20) DEFAULT NULL COMMENT 'Codigo de la cuenta mayor, es decir la que esta en un nivel superior a la actual según la tabla: CONNIVELCUENTAS',
  `con_codniv_ncue` varchar(1) DEFAULT NULL COMMENT 'Codigo nivel de la cuenta contable  según normas',
  `con_codcla_ccue` varchar(2) DEFAULT NULL COMMENT 'Codigo según clases contables',
  `con_natcla_ccue` varchar(10) DEFAULT NULL COMMENT 'Naturaleza de la clase contable: DEBITO o CREDITO',
  `con_estreg_tpuc` varchar(1) DEFAULT NULL COMMENT 'Estado registro: 1=Activa  2=Inactiva',
  PRIMARY KEY (`con_codcue_tpuc`),
  KEY `tpuc02` (`con_descue_tpuc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `conterceros` table : 
#

DROP TABLE IF EXISTS `conterceros`;

CREATE TABLE `conterceros` (
  `con_idesec_mter` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del tercero generado por el sistema',
  `con_tipide_tido` varchar(20) DEFAULT NULL COMMENT 'Tipo identificacion de documento del tercero :1= Nit, 2= Cedula, 3=Cedula de Extranjería, 4= Tarjeta  de Identidad, 5=Pasaporte 6=Otros documento extranjero',
  `con_numide_mter` varchar(20) DEFAULT NULL COMMENT 'Numero docuemto de identificacion del tercero',
  `con_lugexp_mter` varchar(30) DEFAULT NULL COMMENT 'lugar de expedicion del documento de identidad',
  `con_priape_mter` varchar(20) DEFAULT NULL COMMENT 'Primer apellido del tercero (cuando se trata de persona natural)',
  `con_segape_mter` varchar(20) DEFAULT NULL COMMENT 'segundo apellido del tercero (cuando se trata de persona natural)',
  `con_prinom_mter` varchar(20) DEFAULT NULL COMMENT 'Primer nombre del tercero (cuando se trata de persona natural)',
  `con_segnom_mter` varchar(20) DEFAULT NULL COMMENT 'Segundo nombre del tercero (cuando se trata de persona natural)',
  `con_razsoc_mter` varchar(50) DEFAULT NULL COMMENT 'Razon social de la empresa o nombre completo concatenado cuando es persona natural',
  `con_tipper_mter` varchar(1) DEFAULT NULL COMMENT 'Tipo persona 1=Juridica 2= Pesona natural',
  `sis_idemun_muni` varchar(5) DEFAULT NULL COMMENT 'Id Unico Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio',
  `sis_codmun_muni` varchar(3) DEFAULT NULL COMMENT 'Codigo Municipio según DANE',
  `sis_coddep_dpto` varchar(2) DEFAULT NULL COMMENT 'Codigo  del departamento DANE',
  `con_codact_mter` varchar(40) DEFAULT NULL COMMENT 'Codigo CIU de la actividad econnomica',
  `con_tipcnt_mter` varchar(1) DEFAULT NULL COMMENT 'Tipo de regimen contribuyente para el manejo de retencion: 1=Regimen comun 2=Simplificado 3=Gran contribuyente 4 = Empresa del estado',
  `con_relret_mter` varchar(1) DEFAULT NULL COMMENT 'Realizacion de retencion 1= Realizar retencion 2= Es autoretenedor 3= No realizar',
  `con_tipter_tter` varchar(1) DEFAULT NULL COMMENT 'Tipo de tercero : 1= Cliente 2=Proveedor 3=Empleado 4=contribuyente 5=Pensionados 6=Otros',
  `con_telefo_mter` varchar(40) DEFAULT NULL COMMENT 'Numeros de Telefono del tecrcero',
  `con_direcc_mter` varchar(80) DEFAULT NULL COMMENT 'Direccion domicilio del tercero',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del item o registro: 1=Activo  2=Inactivo',
  PRIMARY KEY (`con_idesec_mter`),
  KEY `mter02` (`con_numide_mter`),
  KEY `mter03` (`con_razsoc_mter`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `ctomaeafiliados` table : 
#

DROP TABLE IF EXISTS `ctomaeafiliados`;

CREATE TABLE `ctomaeafiliados` (
  `cto_idesec_ctou` varchar(20) NOT NULL COMMENT 'Consecutivo Único del registro de afiliado se genera al cargar la base de datos en el sistema',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Código de Eps o Asegurador según Listado EPS Ministerio Protección social',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula, RC= Registro Civil, TI = Tarjeta de Identidad  AS= Adulto sin identificación y otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `sia_priape_usua` varchar(20) DEFAULT NULL COMMENT 'Primer apellido del usuario o paciente',
  `sia_segape_usua` varchar(30) DEFAULT NULL COMMENT 'Segundo apellido del usuario o paciente',
  `sia_prinom_usua` varchar(20) DEFAULT NULL COMMENT 'Primer nombre del usuario o paciente',
  `sia_segnom_usua` varchar(30) DEFAULT NULL COMMENT 'Segundo nombre del usuario o paciente',
  `sia_fecnac_usua` date DEFAULT NULL COMMENT 'Fecha nacimiento del usuario o paciente',
  `sis_codsex_sexo` varchar(1) DEFAULT NULL COMMENT 'Sexo del  usuario o paciente',
  `sis_coddep_dpto` varchar(2) DEFAULT NULL COMMENT 'Código  del departamento DANE',
  `sis_idemun_muni` varchar(5) DEFAULT NULL COMMENT 'Id Único Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio',
  `sis_codmun_muni` varchar(3) DEFAULT NULL COMMENT 'Código Municipio según DANE',
  `sis_zonres_tzon` varchar(1) DEFAULT NULL COMMENT 'Zona de residencia según norma U=Urbana R= Rural',
  `sia_feceps_usua` date DEFAULT NULL COMMENT 'Fecha afiliación a EPS o asegurador',
  `sia_tippob_tpob` varchar(2) DEFAULT NULL COMMENT 'Código del tipo poblacional especial para subsidiado, según normas de base de datos Resol: 1344 de 2012  BDUA: 1= Habitante de la calle 2= Población Infantil y mas',
  `sia_codper_pret` varchar(2) DEFAULT NULL COMMENT 'Código pertenencia etnica',
  `sia_nivsbn_nsbn` varchar(1) DEFAULT NULL COMMENT 'Código Nivel Sisben para cobro de copagos  según Resolución: 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N',
  `sia_modsub_usua` varchar(2) DEFAULT NULL COMMENT 'Modalidad del subsidio para el régimen subsidiado: ST =Subsidio total',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Único de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato',
  `sia_nivcon_ncon` varchar(1) DEFAULT NULL COMMENT 'Código Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y copagos según Acuerdo 260 de 2004',
  `sia_telres_usua` varchar(50) DEFAULT NULL COMMENT 'Teléfono del usuario o paciente',
  `sia_dirres_usua` varchar(70) DEFAULT NULL COMMENT 'Dirección de residencia del usuario o paciente',
  `sia_correo_usua` varchar(60) DEFAULT NULL COMMENT 'Correo electrónico del usuario o paciente',
  `sis_codocu_ocup` varchar(4) DEFAULT NULL COMMENT 'Código ocupación o profesion usuario atendido',
  `hcl_nrohis_hicl` varchar(20) DEFAULT NULL COMMENT 'Numero o código de la Ficha de Historias Clínicas',
  `sia_nomusu_usua` varchar(50) DEFAULT NULL COMMENT 'Nombre concatenado del paciente (Apellidos y Nombres)',
  `sia_tipusu_regi` varchar(1) DEFAULT NULL COMMENT 'Tipo Usuario según régimen 1=Contributivo 2=Subsidiado y otros(Resol: 3374 RIPS)',
  `sia_tipcot_tcot` varchar(2) DEFAULT NULL COMMENT 'Tipo Afiliado cotizante para el contributivo según Resolución: 1344 de 2012 BDUA',
  `sia_tipafi_tafi` varchar(1) DEFAULT NULL COMMENT 'Tipo Afiliado contributivo: C=Cotizante B=Beneficiario A=Adicional',
  `sia_valibc_usua` int(10) DEFAULT NULL COMMENT 'Valor ingreso base de cotizacion para usuarios contributivos',
  `sia_tpidap_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del aportante para contributivo',
  `sia_ideapo_usua` varchar(20) DEFAULT NULL COMMENT 'Numero identificación del aportante',
  `sia_discap_usua` varchar(2) DEFAULT NULL COMMENT 'Alguna discapacidad SI/NO',
  `sia_tipdis_tdis` varchar(2) DEFAULT NULL COMMENT 'Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Visual, 2=Motriz y mas',
  `sia_edapac_usua` int(3) DEFAULT NULL COMMENT 'Edad Paciente al Momento de Admisión',
  `sia_codmed_tmed` varchar(1) DEFAULT NULL COMMENT 'Unidad Medida Edad Paciente 1=Año 2=Mes 3=Día',
  `sia_edaano_usua` int(3) DEFAULT NULL COMMENT 'Edad en años',
  `sia_edames_usua` int(4) DEFAULT NULL COMMENT 'Edad en meses',
  `sia_edadia_usua` int(5) DEFAULT NULL COMMENT 'Edad en días',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atención  (cuando hay varias sedes) donde el usuario debe recibir la atención',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del Digitador Usuario del sistema que diligencia el registro de atención o admisión',
  `sia_fecedt_usua` date DEFAULT NULL COMMENT 'Fecha ultima edición',
  `sia_llaveb_usua` varchar(90) DEFAULT NULL COMMENT 'llave de búsqueda avanzada concatena:tipo ide+ identificacion+apellidos+nombres+fecha nacimiento+eps',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`cto_idesec_ctou`),
  KEY `ctou02` (`hcl_nrohis_hicl`),
  KEY `ctou03` (`sia_nroide_usua`),
  KEY `ctou04` (`sia_priape_usua`),
  KEY `ctou05` (`sia_segape_usua`),
  KEY `ctou06` (`sia_prinom_usua`),
  KEY `ctou07` (`sia_segnom_usua`),
  KEY `ctou08` (`sia_codeps_teps`),
  KEY `ctou09` (`sia_llaveb_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `ctomaescontrato` table : 
#

DROP TABLE IF EXISTS `ctomaescontrato`;

CREATE TABLE `ctomaescontrato` (
  `cto_seccon_cont` varchar(10) NOT NULL DEFAULT '' COMMENT 'Secuencial Unico de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato según documento firmado en acuerdo de voluntades',
  `cto_modeps_cont` varchar(1) DEFAULT NULL COMMENT 'Modificar Código  EPS que esta asociado al contrato en el momento de realizar admisión o facturar servicios 1=SI 2=NO',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Codigo de Eps o Asegurador según codigos asignados por la supersalud',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Codigo de Empresa cliente y/o tercero EPS o asegurador según modulos adminstrativos',
  `cto_fecico_cont` date DEFAULT NULL COMMENT 'Fecha Inicio vigencia del contrato',
  `cto_fecfco_cont` date DEFAULT NULL COMMENT 'Fecha finalizacion vigencia contrato',
  `cto_descon_cont` varchar(30) DEFAULT NULL COMMENT 'Descripcion textual del contrato',
  `fcm_codman_mans` varchar(3) DEFAULT NULL COMMENT 'Codigo del manual tarifario de servicios (SOAT ISS o CUPS)  ejm: 01=SOAT mas el 10 para la empresa XX',
  `cto_plaben_cont` varchar(30) DEFAULT NULL COMMENT 'Descripción textual del plan de beneficios ejm: Pos Contributivo, Pos Subsidiado y otros',
  `sia_tipusu_regi` varchar(1) DEFAULT NULL COMMENT 'tipo usuarioso pacientes que cubre el contrato segun regimen 1=Contributivo 2=Subsidiado y otros(Resol: 3374 RIPS)',
  `cto_polcon_cont` varchar(10) DEFAULT NULL COMMENT 'Numero de la poliza aseguramiento del contrato',
  `cto_codtco_cont` varchar(1) DEFAULT NULL COMMENT 'Codigo tipo de contrato : 1=Capitado 2=Contrato por evento',
  `cto_tipact_cont` varchar(1) DEFAULT NULL COMMENT 'Tipo de actividades o servicios que cubre el contrato: 1=Asistenciales 2= Promoción y Prevención 3=Ambas',
  `cto_sepser_cont` varchar(1) DEFAULT NULL COMMENT 'Separar servicios por Asistencial y PyP para generar facturas por separado, cuando el contrato cubre ambos tipos de servicios: 1=Si 2=No',
  `cto_gruite_cont` varchar(1) DEFAULT NULL COMMENT 'Agrupar los Servicios En Facturación por: 1=Código del Servicio 2=Código Servicio y Fecha de Prestación',
  `cto_fcdian_cont` varchar(1) DEFAULT NULL COMMENT 'Generar Numeros de factura desde Secuencial autorizado DIAN: 1=SI 2=NO',
  `fcm_secraz_fcem` varchar(10) DEFAULT NULL COMMENT 'Codigo unico Razon social Empresa',
  `cto_ajupre_cont` int(4) DEFAULT NULL COMMENT 'Ajuste del precio de servicios a: 10,20,50,100,100 y otros',
  `cto_frecus_cont` varchar(1) DEFAULT NULL COMMENT 'Aplicar Validacion de frecuencia de uso de servicio: 1=Si 2=No',
  `cto_porrec_cont` float(6,2) DEFAULT NULL COMMENT 'Prcentaje incremento precios de Venta  o descuento (Recargo o descuento en precios) ejm: tarifa servicio +10, tarifa servicio- 5',
  `cto_porcub_cont` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de cubrimento o amparo del contrato',
  `cto_cubniv_cont` varchar(7) DEFAULT NULL COMMENT 'Cubre servicios según niveles de complejidad 1 hasta el 7',
  `cto_vibaud_cont` varchar(1) DEFAULT NULL COMMENT 'Requiere visto bueno de auditar para asi poder generar numero de factura y confirmar : 1=Si 2=No',
  `cto_porcn1_cont` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de cubrimento para Nivel 1',
  `cto_porcn2_cont` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de cubrimento para Nivel 2',
  `cto_porcn3_cont` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de cubrimento para Nivel 3',
  `cto_porcn4_cont` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de cubrimento para Nivel 4',
  `cto_porcn5_cont` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de cubrimento para Nivel 5',
  `cto_porcn6_cont` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de cubrimento para Nivel 6',
  `cto_totafi_cont` int(12) DEFAULT NULL COMMENT 'Total afiliados asegurados en el contrato',
  `cto_prnord_cont` varchar(1) DEFAULT NULL COMMENT 'Imprimir por defecto la orden de prestacion de servicios medicos: 1= Si 2=No',
  `cto_prnrca_cont` varchar(1) DEFAULT NULL COMMENT 'Imprimir por defecto recibo de caja  por valores pagados en efectivo : 1= Si 2=No',
  `cto_apldes_cont` varchar(1) DEFAULT NULL COMMENT 'Aplicar Descuento: 1=Si 2=No',
  `cto_cobser_cont` varchar(1) DEFAULT NULL COMMENT 'Realizar cobros en efectivo de valores servicios: 1=Si 2=No (para mostrar la Ventana Cobro en efectivo al Facturar)',
  `cto_cobcop_cont` varchar(1) DEFAULT NULL COMMENT 'Realizar cobros en efectivo del Copago: 1=Si 2=No (para mostrar la Ventana Cobro en efectivo al Facturar)',
  `cto_cobmod_cont` varchar(1) DEFAULT NULL COMMENT 'Realizar cobros en efectivo cuota moderadora: 1=Si 2=No (para mostrar la Ventana Cobro en efectivo al Facturar)',
  `cto_cobcus_cont` varchar(1) DEFAULT NULL COMMENT 'Realizar cobros en efectivo del cargo a usuario por no cubrimiento del amparo contrato: 1=Si 2=No (para mostrar la Ventana Cobro en efectivo al Facturar)',
  `cto_liqcop_cont` varchar(1) DEFAULT NULL COMMENT 'Cobrar Copago: 1=Si 2=No',
  `cto_liqmod_cont` varchar(1) DEFAULT NULL COMMENT 'Cobrar Cuota moderadora: 1=Si 2=No',
  `cto_tiplcp_cont` varchar(1) DEFAULT NULL COMMENT 'Tipo liquidacion copagos y cuotas moderadoras: 1= Liquidacion según Acuerdo 264 y  2= Cobrar valor fijo desde manual tarifario',
  `cto_dedcop_cont` varchar(1) DEFAULT NULL COMMENT 'Deducir (descontar) copago cobrado del valor servicio : 1=Descontar copago de valor servicio  2=No descontar copago del valor servicio',
  `cto_sepcon_cont` varchar(1) DEFAULT NULL COMMENT 'Permitir que los servicios se liquiden y se generen facturas separadas para cada contrato 1=SI 2=NO',
  `cto_posnpo_cont` varchar(1) DEFAULT NULL COMMENT 'Servicios permitidos en factruacion 1=POS 2=NO POS 3=Ambos',
  `cto_genrip_cont` varchar(1) DEFAULT NULL COMMENT 'Generar planos RIPS 1=Si 2=No',
  `cto_gcorip_cont` varchar(1) DEFAULT NULL COMMENT 'Generar valores de copagos en planos RIPS 1=Si 2=No',
  `sia_tipase_sita` varchar(2) DEFAULT NULL COMMENT 'Código tipo asegurador de salud:  01=Adminstradora  de Riesgos laborales 02=Entidades aseguradoras regimen subsidiado … otros',
  `cto_gestho_cont` int(2) DEFAULT NULL COMMENT 'Horas minimas para generar cobro estancia en hopitalización',
  `cto_gestur_cont` int(2) DEFAULT NULL COMMENT 'Horas minimas para generar cobro estancia en Urgencias',
  `cto_esthos_cont` int(5) DEFAULT NULL COMMENT 'Numero de horas permitidas que el paciente puede permanecer recluido en estancia hospitalización',
  `cto_esturg_cont` int(5) DEFAULT NULL COMMENT 'Numero de horas permitidas que el paciente puede permanecer recluido urgencias',
  `cto_autrad_cont` varchar(1) DEFAULT NULL COMMENT 'Se requeriere solicitar numero de autorizacion para pacientes admitidos: 1=Si 2=No',
  `cto_autadh_cont` int(4) DEFAULT NULL COMMENT 'Numero de horas disponibles para realizar solicitud autorizacion servicios a la EPS del paciente admitido',
  `cto_autram_cont` varchar(1) DEFAULT NULL COMMENT 'Se requeriere solicitar numero de autorizacion para pacientes en atención ambulatoria: 1=Si 2=No',
  `cto_autamh_cont` int(4) DEFAULT NULL COMMENT 'Numero de horas disponibles para realizar solicitud autorizacion servicios a la EPS del paciente en atención ambulatoria',
  `cto_serper_cont` varchar(1) DEFAULT NULL COMMENT 'Utilizar servicios personalizados  del tarifario para el contrato: 1= Usar servicios personalizados y del tarifario 2 = Usar solo servicios perzonalizados  3= No usar servicios personalizados',
  `cto_idvalc_cont` varchar(1) DEFAULT NULL COMMENT 'Validar identificaciones de usuarios ya atendidos en maestro usuarios del contrato: 1= Validar usuarios en maestro contrato 2 =  No validar usuarios en maestro',
  `cto_suminv_cont` varchar(1) DEFAULT NULL COMMENT 'Traer suministros medicamentos y materiales desde inventarios y afectar existencias: 1=SI 2=NO',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén desde el cual se entregan medicamentos y suministros en consulta externa para el contrato',
  `cto_liqvsm_cont` varchar(1) DEFAULT NULL COMMENT 'Cuando se descarga de inventarios, liquidar valores suministro desde Manual de servicios o desde valores en inventarios: 1=Manual Servicios 2=Desde Inventarios',
  `cto_topval_cont` varchar(1) DEFAULT NULL COMMENT 'Activar validacion por topes de servicios: 1=SI 2=NO',
  `cto_maxpdx_cont` int(12) DEFAULT NULL COMMENT 'Tope Maximo Mensual para Procedimeintos de diagnostico',
  `cto_maxpnq_cont` int(12) DEFAULT NULL COMMENT 'Tope Maximo Mensual para Procedimeintos no quirurgicos',
  `cto_maxpqx_cont` int(12) DEFAULT NULL COMMENT 'Tope Maximo Mensual para Procedimeintos quirurgicos',
  `cto_maxpyp_cont` int(12) DEFAULT NULL COMMENT 'Tope Maximo Mensual para Procedimeintos de PyP',
  `cto_maxcns_cont` int(12) DEFAULT NULL COMMENT 'Tope Maximo Mensual para Consultas',
  `cto_maxmps_cont` int(12) DEFAULT NULL COMMENT 'Tope Maximo Medicamentos pos',
  `cto_maxmnp_cont` int(12) DEFAULT NULL COMMENT 'Tope Maximo Medicamentos no pos',
  `cto_maxots_cont` int(12) DEFAULT NULL COMMENT 'Tope Maximo otros servicios',
  `cto_secdet_cont` int(10) DEFAULT NULL COMMENT 'Campo para generar el secuencial de registros servicios del tarifario personalizados del contrato',
  `cto_estcon_cont` varchar(1) DEFAULT NULL COMMENT 'Estado del Contrato: 1=Activo 2=Inactivo 3=Suspendido',
  PRIMARY KEY (`cto_seccon_cont`),
  KEY `cto02` (`cto_nrocon_cont`),
  KEY `cto03` (`sia_codeps_teps`),
  KEY `cto04` (`sis_idterc_sitr`),
  KEY `cto05` (`cto_descon_cont`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `ctomanservicios` table : 
#

DROP TABLE IF EXISTS `ctomanservicios`;

CREATE TABLE `ctomanservicios` (
  `cto_idesec_cspr` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del servicio personalizado  (generado por el sistema)',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato al cual pertenece el servicio personalizado',
  `fcm_codman_mans` varchar(3) DEFAULT NULL COMMENT 'Codigo del manual tarifario de servicios (SOAT ISS o CUPS) ejm: 01=SOAT mas el 10 para la empresa XX',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS habilitado',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (pude ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `fcm_codser_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo en tarifario del servicio para venta y RIPS, pude ser codigo SOAT ISS o CUPS (es modificable)',
  `fcm_desser_mant` varchar(250) DEFAULT NULL COMMENT 'Descripción textual del servicio en el manual',
  `fcm_valser_mant` float(17,2) DEFAULT NULL COMMENT 'Valor del servicio para venta',
  `fcm_punuvr_mant` float(12,6) DEFAULT NULL COMMENT 'Puntajes o UVR según manual SOAT o ISS para calcular valor servicios con base en salarios minimos vigentes',
  `fcm_valren_mant` int(14) DEFAULT NULL COMMENT 'Valor del recargo nocturno (cuando aplique)',
  `fcm_tipccp_mant` varchar(1) DEFAULT NULL COMMENT 'Tipo Liquidacion copago o cuota moderadora 1=Liquidado 2= Valor fijo',
  `fcm_vficop_mant` int(12) DEFAULT NULL COMMENT 'Valor del copago o cuota moderadora cuando es fijo',
  `fcm_facvmc_mant` varchar(1) DEFAULT NULL COMMENT 'Verificacion para permitir valores de servicios en cero: 1=No permitir valores en cero 2=Permitir valores en cero',
  `fcm_estser_mant` varchar(1) DEFAULT NULL COMMENT 'Estado del servicio dentro la IPS: 1=Activo 2=Inactivo',
  PRIMARY KEY (`cto_idesec_cspr`),
  KEY `cspr02` (`fcm_idesec_sips`),
  KEY `cspr03` (`fcm_desser_mant`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `estplangr2193ma` table : 
#

DROP TABLE IF EXISTS `estplangr2193ma`;

CREATE TABLE `estplangr2193ma` (
  `est_nroreg_esgr` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código único grupo del informe',
  `est_codinf_esin` varchar(5) DEFAULT NULL COMMENT 'Código único del informe o plantilla',
  `est_nomgru_esgr` varchar(200) DEFAULT NULL COMMENT 'Nombre del grupo de registro en el informe',
  `est_ordgru_esgr` int(3) DEFAULT NULL COMMENT 'Orden para organizar grupos dentro del informe',
  `est_ordvis_esgr` int(3) DEFAULT NULL COMMENT 'Orden visualizacion del grupo dentro del informe',
  `est_codcon_esgr` varchar(1) DEFAULT NULL COMMENT '1=Generar Según Norma 2=Ecepción según grupo 3=Ecepción según grupo 4=Ecepción según grupo...',
  `est_descon_esgr` varchar(250) DEFAULT NULL COMMENT 'Codigo condiciones cada grupo de registros  1= Generar Según Norma 2=Segun condicion o ecepción grupo 3=otros',
  `est_secdet_esgr` int(6) DEFAULT NULL COMMENT 'Campo para generar el secuencial de registros detalles',
  `est_estreg_esgr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro  1= Activo 2= Inactivo',
  PRIMARY KEY (`est_nroreg_esgr`),
  KEY `esgr02` (`est_codinf_esin`),
  KEY `esgr03` (`est_nomgru_esgr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `estplangr2193md` table : 
#

DROP TABLE IF EXISTS `estplangr2193md`;

CREATE TABLE `estplangr2193md` (
  `est_nroreg_essr` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código único del registro',
  `est_nroreg_esgr` varchar(10) DEFAULT NULL COMMENT 'Código único grupo del informe',
  `fcm_codser_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo del servicio para venta y RIPS, pude ser codigo SOAT ISS o CUPS (es modificable en configuración)',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (pude ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `sia_codrip_trip` varchar(2) DEFAULT NULL COMMENT 'Codigo clasificacion  servicio según Resolucion 3374 RIPS: 01=Consulta 02= Procedimientos y mas',
  `sia_codfpr_fpro` varchar(20) DEFAULT NULL COMMENT 'Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Diagnostico 2=Terapéutico 3=Protección Especifica 4=Detección temprana de Enfermedad General 5=Detección especifica de Enfermedad Profesional según Resolucion 3374 RIPS',
  `sia_codfco_fcon` varchar(40) DEFAULT NULL COMMENT 'Finalidad de la consulta: 01=Atención del Parto 02=Atencion del Recien Nacido y demas según Resolucion 3374RIPS',
  `adm_codcex_tcex` varchar(40) DEFAULT NULL COMMENT 'Causa Externa Origen que origina la atención según Resolución: 3374 RIPS',
  `fcm_mededi_sips` varchar(1) DEFAULT NULL COMMENT 'Medida edad inicial a la cual aplica el servicio, para validación pertinencia: 1=Años 2=Meses 3=Días',
  `fcm_edaini_sips` int(6) DEFAULT NULL COMMENT 'Edad inicial para la cual aplica la validación de pertinencia',
  `fcm_mededf_sips` varchar(1) DEFAULT NULL COMMENT 'Medida edad fina a la cual aplica el servicio, para validación pertinencia:1=Años 2=Meses 3=Días',
  `fcm_edafin_sips` int(6) DEFAULT NULL COMMENT 'Edad final para la cual aplica la validación de pertinencia',
  `fcm_sexapl_sips` varchar(1) DEFAULT NULL COMMENT 'Sexo al cual aplica el servicio:1=Masculino 2=Femenino 3=Ambos',
  `fcm_coddia_sips` text COMMENT 'Lista de diagnosticos CIE -10 permitidos, separados por (punto y coma)  para validacion en prestacion de servicios y  Gestion foramtos de Historias clinicas',
  `est_ordvis_esgr` int(3) DEFAULT NULL COMMENT 'Orden visualizacion del registro dentro del grupo en informe',
  `est_estreg_esgr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=activo 2=Inactivo',
  PRIMARY KEY (`est_nroreg_essr`),
  KEY `esgr02` (`est_nroreg_esgr`),
  KEY `esgr03` (`fcm_coddig_mant`),
  KEY `esgr05` (`fcm_codser_sips`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `estplaninformes` table : 
#

DROP TABLE IF EXISTS `estplaninformes`;

CREATE TABLE `estplaninformes` (
  `est_nroreg_esin` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código único del registro, generado por el sistema',
  `est_codinf_esin` varchar(5) DEFAULT NULL COMMENT 'Código único del informe o plantilla',
  `sys_codmod_modu` varchar(5) DEFAULT NULL COMMENT 'Código único del Modulo digitado por el usuario',
  `est_nominf_esin` varchar(50) DEFAULT NULL COMMENT 'Nombre del informe o plantilla',
  `est_plaxml_esin` mediumtext COMMENT 'Texto XML de la plantilla generada desde el editor de plantillas',
  `est_parame_esin` text COMMENT 'Parametros predeterminados en formato XML al cargar la vista del reporte',
  `est_script_esin` mediumtext COMMENT 'Codigo fuente del informe para generar consultas',
  `est_estreg_esin` varchar(1) DEFAULT NULL COMMENT 'Estado del formato  1= Activo 2= Inactivo',
  PRIMARY KEY (`est_nroreg_esin`),
  KEY `esin02` (`est_codinf_esin`),
  KEY `esin03` (`sys_codmod_modu`),
  KEY `esin04` (`est_nominf_esin`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farexpedmedicma` table : 
#

DROP TABLE IF EXISTS `farexpedmedicma`;

CREATE TABLE `farexpedmedicma` (
  `far_expedi_fama` varchar(20) NOT NULL DEFAULT '' COMMENT 'Numero del registro expediente INVIMA',
  `far_desexp_fama` varchar(200) DEFAULT NULL COMMENT 'Descripcion del producto comercial según expediente INVIMA',
  `far_codatc_fatc` varchar(20) DEFAULT NULL COMMENT 'Codigo ATC ejemplo: A01AB01 según tabla Maestro clasificacion ATC',
  `far_grufar_fagf` varchar(3) DEFAULT NULL COMMENT 'Grupo farmacologico según principos ATC',
  `far_sugfar_fasg` varchar(5) DEFAULT NULL COMMENT 'Subgrupo farmacologico del medicamento',
  `far_unimed_faum` varchar(2) DEFAULT NULL COMMENT 'Codigo unidad medida del medicamento',
  `far_viaadm_fava` varchar(2) DEFAULT NULL COMMENT 'Codigo via de adminstracion del medicamento (ORAL, CUTANEA, INTRAMUSCULAR Y OTRAS)',
  `far_invima_fama` varchar(20) DEFAULT NULL COMMENT 'Numero registro sanitario INVIMA',
  `far_fecexp_fama` date DEFAULT NULL COMMENT 'Fecha expedicion del registro sanitario INVIMA',
  `far_fecven_fama` date DEFAULT NULL COMMENT 'Fecha vencimiento del registro sanitario INVIMA',
  `far_codlab_falb` varchar(5) DEFAULT NULL COMMENT 'Codigo del laboratorio que lo fabrica',
  `far_comerc_falb` varchar(5) DEFAULT NULL COMMENT 'Codigo del laboratorio o quien realiza comercializacion del producto',
  `far_tiprol_fama` varchar(1) DEFAULT NULL COMMENT 'Tipo rol del comerciante (puede ser el mismo que fabrica): FABRICANTE o IMPORTADOR',
  `far_modcom_famc` varchar(2) DEFAULT NULL COMMENT 'Modalidad comercial del fabricante o comerciante: FABRICAR Y VENDER, IMPORTAR SEMIELABORAR Y VENDER … y otras',
  `far_forfar_fama` varchar(20) DEFAULT NULL COMMENT 'Forma farmaceutica del medicamento para RIPS',
  `far_concen_fama` varchar(20) DEFAULT NULL COMMENT 'Concentracion del medicamento para RIPS',
  `far_unimed_fama` varchar(20) DEFAULT NULL COMMENT 'Descripcion Unidad medida del medicamento para RIPS',
  `far_secdet_fama` int(6) DEFAULT NULL COMMENT 'Campo para generar el secuencial de registros serviciosdetalles',
  `far_estreg_fama` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Vigente 2=Vencido',
  PRIMARY KEY (`far_expedi_fama`),
  KEY `fama02` (`far_desexp_fama`),
  KEY `fama03` (`far_codatc_fatc`),
  KEY `fama04` (`far_invima_fama`),
  KEY `fama05` (`far_grufar_fagf`),
  KEY `fama06` (`far_sugfar_fasg`),
  KEY `fama07` (`far_unimed_faum`),
  KEY `fama08` (`far_viaadm_fava`),
  KEY `fama09` (`far_codlab_falb`),
  KEY `fama10` (`far_comerc_falb`),
  KEY `fama11` (`far_modcom_famc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farexpedmedicmd` table : 
#

DROP TABLE IF EXISTS `farexpedmedicmd`;

CREATE TABLE `farexpedmedicmd` (
  `far_secreg_famd` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico del registro (generado por el sistema)',
  `far_expedi_fama` varchar(20) DEFAULT NULL COMMENT 'Numero del registro expediente INVIMA',
  `far_concum_famd` int(4) DEFAULT NULL COMMENT 'Consecutivo del regitro según presentacion que hace parte del codigo para generar el CUM',
  `far_codcum_famd` varchar(20) DEFAULT NULL COMMENT 'Codigo CUM del medicamento (clasificacion unica de medicamentos) según expediente INVIMA y presentacion comercial',
  `far_cancum_famd` int(4) DEFAULT NULL COMMENT 'Cantidade de unidades o contenidos según presentacion CUM ejemplo: Caja X 10 Unidades',
  `far_precom_famd` varchar(250) DEFAULT NULL COMMENT 'Descripcion presentacion comercial del producto según expediente',
  `far_secimg_faim` varchar(10) DEFAULT NULL COMMENT 'Codgo imagen JPG o PNG (por defecto) que representa el medicamento',
  `far_fecact_famd` date DEFAULT NULL COMMENT 'Fecha activacion del registro presentacion',
  `far_fecina_famd` date DEFAULT NULL COMMENT 'Fecha inactivacion registro presentacion',
  `far_gencom_famd` varchar(1) DEFAULT NULL COMMENT 'Medicamento es  generico (para el POS) o es medicamento de mayor concentracion (comercial) : 1=Medicamento Generico 2=Medicamento comercial',
  `far_estreg_famd` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Vigente 2=Vencido',
  PRIMARY KEY (`far_secreg_famd`),
  KEY `famd02` (`far_expedi_fama`),
  KEY `famd03` (`far_codcum_famd`),
  KEY `famd04` (`far_precom_famd`),
  KEY `famd05` (`far_secimg_faim`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farexpedpriacmd` table : 
#

DROP TABLE IF EXISTS `farexpedpriacmd`;

CREATE TABLE `farexpedpriacmd` (
  `far_secreg_fapa` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico del registro (generado por el sistema)',
  `far_expedi_fama` varchar(20) DEFAULT NULL COMMENT 'Numero del registro expediente INVIMA',
  `far_despac_fapa` varchar(200) DEFAULT NULL COMMENT 'Descripcion principio activo',
  `far_unimed_fapa` varchar(20) DEFAULT NULL COMMENT 'Unidad medida concentracion del principio activo (mg=Miligramos, ml=Mililitros, g=Gramos y otras)',
  `far_cancon_fapa` float(7,4) DEFAULT NULL COMMENT 'Cantidad concentracion del principio activo en medicamento Ejemplo: 50 mg',
  `far_uniref_fapa` varchar(150) DEFAULT NULL COMMENT 'Unidad medida referencia textual ejemplo: GRAGEA,CAPSULA,70 g DE POLVO PARA RECONSTITUIR A 100mL, SUSPENSIÓN … Y otras',
  PRIMARY KEY (`far_secreg_fapa`),
  KEY `farpa02` (`far_expedi_fama`),
  KEY `farpa03` (`far_despac_fapa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fargrufarmacoma` table : 
#

DROP TABLE IF EXISTS `fargrufarmacoma`;

CREATE TABLE `fargrufarmacoma` (
  `far_grufar_fagf` varchar(3) NOT NULL DEFAULT '' COMMENT 'Grupo farmacologico del medicamento',
  `far_idegru_fagf` varchar(3) DEFAULT NULL COMMENT 'Identificador del grupo farmacologico',
  `far_desgru_fagf` varchar(100) DEFAULT NULL COMMENT 'Descripcion grupo farmacologico del medicamento',
  `far_ordvis_fagf` int(2) DEFAULT NULL COMMENT 'Orden vizualizacion de los registros en vistas',
  `far_estreg_fagf` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2= Inactivo',
  PRIMARY KEY (`far_grufar_fagf`),
  KEY `fargf02` (`far_desgru_fagf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fargrufarmacomd` table : 
#

DROP TABLE IF EXISTS `fargrufarmacomd`;

CREATE TABLE `fargrufarmacomd` (
  `far_sugfar_fasg` varchar(5) NOT NULL DEFAULT '' COMMENT 'Subgrupo farmacologico del medicamento',
  `far_grufar_fagf` varchar(3) DEFAULT NULL COMMENT 'Grupo farmacologico del medicamento',
  `far_idesgr_fasg` varchar(5) DEFAULT NULL COMMENT 'Identificador del subgrupo farmacologico',
  `far_desgru_fasg` varchar(150) DEFAULT NULL COMMENT 'Descripcion del subgrupo farmacologico del medicamento',
  `far_ordvis_fasg` int(3) DEFAULT NULL COMMENT 'Orden vizualizacion de los registros en vistas',
  `far_estreg_fasg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2= Inactivo',
  PRIMARY KEY (`far_sugfar_fasg`),
  KEY `farsg02` (`far_grufar_fagf`),
  KEY `farsg03` (`far_idesgr_fasg`),
  KEY `farsg04` (`far_desgru_fasg`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farlaboratorios` table : 
#

DROP TABLE IF EXISTS `farlaboratorios`;

CREATE TABLE `farlaboratorios` (
  `far_codlab_falb` varchar(5) NOT NULL COMMENT 'Codigo del laboratorio que lo fabrica (Secuencial generado por el sistema',
  `far_deslab_falb` varchar(150) DEFAULT NULL COMMENT 'Nombre o descripcion del laboratorio que fabrica o comercializa medicamentos',
  `far_estreg_falb` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`far_codlab_falb`),
  KEY `falb02` (`far_deslab_falb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farmaeclasifatc` table : 
#

DROP TABLE IF EXISTS `farmaeclasifatc`;

CREATE TABLE `farmaeclasifatc` (
  `far_codatc_fatc` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo ATC ejemplo: A01AB01 según tabla Maestro clasificacion ATC',
  `far_desatc_fatc` varchar(250) DEFAULT NULL COMMENT 'Nombre o descripcion del medicamento según clasificacion ATC',
  `far_estreg_fatc` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`far_codatc_fatc`),
  KEY `fatc02` (`far_desatc_fatc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farmedicamimage` table : 
#

DROP TABLE IF EXISTS `farmedicamimage`;

CREATE TABLE `farmedicamimage` (
  `far_secimg_faim` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codgo unico registro  de imagen generado por el sistema',
  `far_codcum_famd` varchar(20) DEFAULT NULL COMMENT 'Codigo CUM del medicamento (clasificacion unica de medicamentos) según expediente INVIMA y presentacion comercial',
  `far_nomimg_faim` varchar(50) DEFAULT NULL COMMENT 'Nombre completo de la imagene con extencion ejemplo: IMG-0000012255-01-V01.PNG',
  `far_estreg_faim` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`far_secimg_faim`),
  KEY `fami02` (`far_codcum_famd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farmedicamviadm` table : 
#

DROP TABLE IF EXISTS `farmedicamviadm`;

CREATE TABLE `farmedicamviadm` (
  `far_viaadm_fava` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo via de adminstracion del medicamento (ORAL, CUTANEA, INTRAMUSCULAR Y OTRAS)',
  `far_desvia_fava` varchar(60) DEFAULT NULL COMMENT 'Descripcion via adminstracion medicamentos',
  PRIMARY KEY (`far_viaadm_fava`),
  KEY `fava02` (`far_desvia_fava`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farmodalicomerc` table : 
#

DROP TABLE IF EXISTS `farmodalicomerc`;

CREATE TABLE `farmodalicomerc` (
  `far_modcom_famc` varchar(2) NOT NULL DEFAULT '' COMMENT 'Modalidad comercial del fabricante o comerciante: FABRICAR Y VENDER, IMPORTAR SEMIELABORAR Y VENDER … y otras',
  `far_desmod_famc` varchar(50) DEFAULT NULL COMMENT 'Descripcion modalidad comercializacion',
  PRIMARY KEY (`far_modcom_famc`),
  KEY `famc02` (`far_desmod_famc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farmovmedicamma` table : 
#

DROP TABLE IF EXISTS `farmovmedicamma`;

CREATE TABLE `farmovmedicamma` (
  `far_nroreg_fams` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico registro maestro',
  `hcl_nroreg_hcms` varchar(20) DEFAULT NULL COMMENT 'Código registro entrega Formula media /Hoja de consumo intrahospitalaria en maestro HCLREGORDESERMS',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Codigo de Eps o Asegurador según codigos asignados por la supersalud',
  `far_gesfec_fams` date DEFAULT NULL COMMENT 'Fecha solicitud del suministro al paciente',
  `far_geshor_fams` decimal(5,2) DEFAULT NULL COMMENT 'Hora solicitud del servicio para el paciente en formato militar  (HH) ejm: 16',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `far_tipreg_fams` varchar(1) DEFAULT NULL COMMENT 'Tipo registro salida medicamentos 1=Entrega de formulas medicas 2=Suministro intrahospitalario a pacientes internados',
  `far_tipges_fams` varchar(1) DEFAULT NULL COMMENT 'Tipo registro gestion 1=Solicitud inicial de suministro medicamentos (Valor por defecto)  2=Gestion para completar entrega de pendientes',
  `far_observ_fams` varchar(150) DEFAULT NULL COMMENT 'Nota detalle u observacion del registro',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo del centro de producción',
  `hcl_tiptur_hctu` varchar(3) DEFAULT NULL COMMENT 'Codigo clasificacion turnos diarios para la prestacion de servicios medicos (mañana tarde noche)',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que autoriza el servicio o medicamento',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Usuario del sistema que realiza gestion del registro de solicitud desde modulo clinico',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén para el cual se realiza el movimiento',
  `far_entreg_fams` varchar(1) DEFAULT NULL COMMENT 'Para saber si  los medicamento en farmacia/almacen fueron entregados completos  1=Entrega realizada sin pendientes 2=Entrega realizada con medicamentos pendientes 3=Pendiente entregados totalmente',
  `far_entrex_fams` varchar(1) DEFAULT NULL COMMENT 'Medicamento pendientes fueron entregados:  1=Entrega realizada sin pendientes 2=Pendientes no entregados 3=Pendientes entregados parcialmente 4 = Pendientes entregados totalmente',
  `sys_codusx_usux` varchar(5) DEFAULT NULL COMMENT 'Usuario del sistema que realiza gestion en almacen',
  `far_secdet_fams` int(6) DEFAULT NULL COMMENT 'Campo para generar el secuencial de registros serviciosdetalles',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`far_nroreg_fams`),
  KEY `farms02` (`hcl_nroreg_hcms`),
  KEY `farms03` (`adm_secadm_rgad`),
  KEY `farms04` (`far_observ_fams`),
  KEY `farms05` (`sia_idesec_usua`),
  KEY `farms06` (`sia_nroide_usua`),
  KEY `farms07` (`far_gesfec_fams`),
  KEY `farms08` (`inv_codalm_inal`),
  KEY `farms09` (`cto_seccon_cont`),
  KEY `farms10` (`sia_codeps_teps`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farmovmedicammd` table : 
#

DROP TABLE IF EXISTS `farmovmedicammd`;

CREATE TABLE `farmovmedicammd` (
  `far_nroreg_fads` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro detalle',
  `far_nroreg_fams` varchar(20) DEFAULT NULL COMMENT 'Código secuencial unico registro maestro',
  `hcl_nroreg_hcms` varchar(20) DEFAULT NULL COMMENT 'Código registro entrega Formula media /Hoja de consumo intrahospitalaria en maestro HCLREGORDESERMS',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `far_gesfec_fams` date DEFAULT NULL COMMENT 'Fecha solicitud del suministro al paciente',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `far_tipreg_fams` varchar(1) DEFAULT NULL COMMENT 'Tipo registro salida medicamentos 1=Entrega de formulas medicas 2=Suministro intrahospitalario a pacientes internados',
  `far_tipges_fams` varchar(1) DEFAULT NULL COMMENT 'Tipo registro gestion 1=Solicitud inicial de suministro medicamentos (Valor por defecto)  2=Gestion para completar entrega de pendientes',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén para el cual se realiza el movimiento',
  `inv_secart_inar` varchar(20) DEFAULT NULL COMMENT 'Secuencial de articulo generado por el sistema viene de la tabla:',
  `inv_codaux_inar` varchar(20) DEFAULT NULL COMMENT 'Código Auxiliar del articulo puede ser digitado por el usuario',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS  para relacion con facturacion medica',
  `far_codcum_famd` varchar(20) DEFAULT NULL COMMENT 'Codigo CUM del medicamento (clasificacion unica de medicamentos)',
  `sis_codgme_sigr` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)',
  `sis_codume_sium` varchar(2) DEFAULT NULL COMMENT 'Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,Litros,Gramos y otros',
  `far_unisol_fads` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES SOLICITADAS, cantidad de unidades solicitadas en la orden medica',
  `far_unient_fads` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES ENTREGADAS,  unidades entregadas en farmacia,  es posible que sea una cantidad menor a la solicitada, esto generara cantidad pendiente',
  `far_unipen_fads` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES PENDIENTES, unidades pendientes por entregar se genera del calculo: UnidadesSolicitadas menos Unidades entrregadas',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'VALOR INGRESO COMPRA, Valor Ingreso unidad de articulos en inventario es la base para calculo valor salida',
  `inv_valmov_inar` float(17,2) DEFAULT NULL COMMENT 'VALOR SALIDA VENTA, Valor Movimiento de salida (valor venta) cada unidad',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`far_nroreg_fads`),
  KEY `fards02` (`far_nroreg_fams`),
  KEY `fards03` (`hcl_nroreg_hcms`),
  KEY `fards04` (`adm_secadm_rgad`),
  KEY `fards05` (`sia_idesec_usua`),
  KEY `fards06` (`sia_nroide_usua`),
  KEY `fards07` (`far_gesfec_fams`),
  KEY `fards08` (`inv_codalm_inal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `farunidadmedida` table : 
#

DROP TABLE IF EXISTS `farunidadmedida`;

CREATE TABLE `farunidadmedida` (
  `far_unimed_faum` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo unidad medida del medicamento',
  `far_desmed_faum` varchar(60) DEFAULT NULL COMMENT 'Descripcion unidad de medida medicamentos',
  PRIMARY KEY (`far_unimed_faum`),
  KEY `faum02` (`far_desmed_faum`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmactquirurgic` table : 
#

DROP TABLE IF EXISTS `fcmactquirurgic`;

CREATE TABLE `fcmactquirurgic` (
  `fcm_codaqx_aqir` varchar(1) NOT NULL DEFAULT '' COMMENT 'Codigo forma de realizacion del acto quirurgico (cuando aplique) ejm: 1=Unico 2=Bilateral misma via y otros',
  `fcm_desaqx_aqir` varchar(50) DEFAULT NULL COMMENT 'Dscripción forma de realizacion del acto quirúrgico',
  PRIMARY KEY (`fcm_codaqx_aqir`),
  KEY `aqir02` (`fcm_desaqx_aqir`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmcenproduccio` table : 
#

DROP TABLE IF EXISTS `fcmcenproduccio`;

CREATE TABLE `fcmcenproduccio` (
  `fcm_codcpr_cpro` varchar(6) NOT NULL DEFAULT '' COMMENT 'Codgio del centro de producción generado por el sistema',
  `fcm_descpr_cpro` varchar(80) DEFAULT NULL COMMENT 'Nombre o descripción del centro de produccion en prestacion de servicios medicos',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Codigo area prestacion de servicios medicos  a la cual pertenece el centro de producción',
  `con_codafu_afun` varchar(3) DEFAULT NULL COMMENT 'Codigo area funcional de la empresa',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atencion  cuando hay varias sedes',
  `con_codsco_ccos` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de costo para manejo contable',
  `fcm_genhis_cpro` varchar(1) DEFAULT NULL COMMENT 'Generar registro para actividad en historia clinica del paciente al facturar: 1=Si 2=NO',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo formato plantilla historia clinica asociada al programa o centro de produccion para generar registro actividad en historia clinica',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Código único secuencial del servicio IPS con el que esta relacionado (es obligatorio)',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (puede ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado  del centro produccion: 1=Activo  2=Inactivo',
  PRIMARY KEY (`fcm_codcpr_cpro`),
  KEY `cpro02` (`fcm_descpr_cpro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmcuentacobrde` table : 
#

DROP TABLE IF EXISTS `fcmcuentacobrde`;

CREATE TABLE `fcmcuentacobrde` (
  `fcm_secreg_mfcd` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico detalles facturas en cuenta de cobro (generado por el sistema)',
  `fcm_secreg_mfcb` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico de la cuenta de cobro relacion R1',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo unico de paciente en el sistema',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero de factura (desde maestro de facturas) relacionado como detalles de cuentra de cobro',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro según estado de la cuenta de cobro: 1=Abierta 2=Confirmada 3=Anulada',
  PRIMARY KEY (`fcm_secreg_mfcd`),
  KEY `mfcd02` (`fcm_secreg_mfcb`),
  KEY `mfcd03` (`sia_idesec_usua`),
  KEY `mfcd04` (`fcm_numfac_mfac`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmcuentacobrms` table : 
#

DROP TABLE IF EXISTS `fcmcuentacobrms`;

CREATE TABLE `fcmcuentacobrms` (
  `fcm_secreg_mfcb` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico de la cuenta de cobro (generado por el sistema)',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero de la factura generada al confirmar la factura o cuenta de cobro',
  `fcm_secres_srfa` varchar(10) DEFAULT NULL COMMENT 'Secuencial unico de la resolución Dian en el sistema (generado por el sistema), cuando aplique',
  `fcm_tipfac_mfcb` varchar(1) DEFAULT NULL COMMENT 'Tipo factura a generar 1=Numero Factura Dian autorizada 2=Secuencial del Sistema',
  `fcm_fecfac_mfac` date DEFAULT NULL COMMENT 'Fecha de la factura (fecha en que fue confirmada y generado el secuencial de factrua)',
  `sia_fecini_mfcb` date DEFAULT NULL COMMENT 'Fecha inicial periodo facturacion',
  `sia_fecfin_mfcb` date DEFAULT NULL COMMENT 'Fecha final periodo facturacion',
  `fcm_descue_mfcb` varchar(60) DEFAULT NULL COMMENT 'Descripcion o nota de la cuanta de cobro',
  `fcm_notcue_mfcb` text COMMENT 'Nota detallada para el formato impreso',
  `fcm_firmar_mfcb` varchar(50) DEFAULT NULL COMMENT 'Nombre de la persona que firma el formato impreso',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Codigo de Eps o Asegurador según codigos asignados por la supersalud',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Código de Empresa cliente y/o tercero EPS o asegurador según módulos administrativos',
  `fcm_valbru_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total  bruto facturado del servicio sin ninguna deducción: FCM_VALSER_SIPS x FCM_TOTUNI_DFAC',
  `fcm_pordes_dfac` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de descuento aplicada (cuando el descuento se haya calculado en porcentaje)',
  `fcm_valdes_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del descuento realizado al cliente',
  `fcm_poriva_dfac` float(6,2) DEFAULT NULL COMMENT 'Porcentaje del IVA aplicado al servicio',
  `fcm_valiva_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del IVA recuadado en la factura',
  `fcm_valcpa_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del copago recudado en el srvicio como tal, suma en factura',
  `fcm_valcmo_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total de cuota moderadora recudada en servico y suma en la factura',
  `fcm_valusu_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor cargo al usuario, cobrado al paciente por porcentajes no cubiertos en el seguro',
  `fcm_valsub_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor subtotal del servicio facturado haciendo deducciones: FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VALDES_DFAC)',
  `fcm_valfac_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del servicio facturado incluyendo el IVA  y con las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DFAC+FCM_VALCOM_DFAC',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del facturador usuario del sistema que que realiza la ultima modificacion',
  `fcm_conest_mfcb` int(5) DEFAULT NULL COMMENT 'Contador para generar los registros únicos  detalles cada factura relacionada',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro según estado de la cuenta de cobro: 1=Abierta 2=Confirmada 3=Anulada',
  PRIMARY KEY (`fcm_secreg_mfcb`),
  KEY `mfcb02` (`fcm_descue_mfcb`),
  KEY `mfcb03` (`cto_seccon_cont`),
  KEY `mfcb04` (`fcm_fecfac_mfac`),
  KEY `mfcb05` (`fcm_secres_srfa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmdatoscontrol` table : 
#

DROP TABLE IF EXISTS `fcmdatoscontrol`;

CREATE TABLE `fcmdatoscontrol` (
  `fcm_contrl_fcmc` varchar(10) NOT NULL DEFAULT '' COMMENT 'Secuencial unico del registro de control',
  `fcm_desctr_fcmc` varchar(60) DEFAULT NULL COMMENT 'Descripción Archivo de Control',
  `fcm_secres_srfa` varchar(10) DEFAULT NULL COMMENT 'Secuencial unico de Resolución Dian para secuencial facturacion',
  `fcm_carg1_fcmc` varchar(40) DEFAULT NULL COMMENT 'Nombre del cargo para funcionario que firma en reportes y facturas firma Numero 1',
  `fcm_firma1_fcmc` varchar(60) DEFAULT NULL COMMENT 'Nombre completo de funcionario 1 que aparece para firmar en reportes, facturas y otros',
  `fcm_carg2_fcmc` varchar(40) DEFAULT NULL COMMENT 'Nombre del cargo para funcionario que firma en reportes y facturas firma Numero 2',
  `fcm_firma2_fcmc` varchar(60) DEFAULT NULL COMMENT 'Nombre completo de funcionario 2 que aparece para firmar en reportes, facturas y otros',
  `fcm_carg3_fcmc` varchar(40) DEFAULT NULL COMMENT 'Nombre del cargo para funcionario que firma en reportes y facturas firma Numero 3',
  `fcm_firma3_fcmc` varchar(60) DEFAULT NULL COMMENT 'Nombre completo de funcionario 3 que aparece para firmar en reportes, facturas y otros',
  PRIMARY KEY (`fcm_contrl_fcmc`),
  KEY `fcmc02` (`fcm_desctr_fcmc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmdescueautori` table : 
#

DROP TABLE IF EXISTS `fcmdescueautori`;

CREATE TABLE `fcmdescueautori` (
  `fcm_autdes_ades` varchar(10) NOT NULL DEFAULT '' COMMENT 'Numero de autorizacion  del descuento aprobado para el momento del pago (generado por el sistema)',
  `fcm_ordvis_ades` int(5) DEFAULT NULL COMMENT 'Orden visualización en browser: 1 =Solicitud abierta sin aprobar o negar 2=Confirmada o aprobada 3=Aplicada al usuario o Negada',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente o usuario que realiza el pago y solicita descuento',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `fcm_fecsol_ades` date DEFAULT NULL COMMENT 'Fecha solicitud del descuento',
  `fcm_horsol_ades` decimal(5,2) DEFAULT NULL COMMENT 'Hora solicitud del descuento en formato 12 horas ejm: 10:20:AM',
  `fcm_fecaut_ades` date DEFAULT NULL COMMENT 'Fecha Autorizacion del descuento',
  `fcm_horaut_ades` decimal(5,2) DEFAULT NULL COMMENT 'Hora autorizacion descuento en formato 12 horas ejm: 10:20:AM',
  `fcm_valref_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor a cobrar en efectivo antes del descuento por cobros de copagos o valor total de la factura (no siempre representa el valor total facturado)',
  `fcm_valdes_ades` float(17,2) DEFAULT NULL COMMENT 'Valor total del descuento solicitado',
  `fcm_valdes_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del descuento realizado al cliente',
  `fcm_pordes_dfac` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de descuento aplicada (cuando el descuento se haya calculado en porcentaje)',
  `fcm_valefe_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor recuadado en efectivo con el descuento realizado  por cobros de copagos o valor total de la factura (no siempre representa el valor total facturado)',
  `fcm_notaut_ades` varchar(150) DEFAULT NULL COMMENT 'Nota textual de la autorización',
  `sys_ususol_usux` varchar(5) DEFAULT NULL COMMENT 'CCódigo del facturador usuario del sistema que realiza la solicitud ',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del usuario o adminstrativo que autoriza el descuento',
  `fcm_aplcad_ades` varchar(1) DEFAULT NULL COMMENT 'Autorizacion aplicada en descuento al paciente: 1=SI, 2=NO',
  `fcm_estaut_ades` varchar(1) DEFAULT NULL COMMENT 'Estado de autorizacion: 1 =Abierta 2=Autorizada 3=Aplicada a descuento 4=Negada o anulada',
  PRIMARY KEY (`fcm_autdes_ades`),
  KEY `ades02` (`adm_secadm_rgad`),
  KEY `ades03` (`fcm_notaut_ades`),
  KEY `ades04` (`sia_idesec_usua`),
  KEY `ades05` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfeenviosdianma` table : 
#

DROP TABLE IF EXISTS `fcmfeenviosdianma`;

CREATE TABLE `fcmfeenviosdianma` (
  `fcm_secreg_fcpq` varchar(20) NOT NULL COMMENT 'Secuencial unico de la cuenta de cobro (generado por el sistema)',
  `fcm_envfec_mfac` date DEFAULT NULL COMMENT 'Fecha del envio paquete fcturas a la Dian',
  `fcm_envhor_mfac` decimal(5,2) DEFAULT NULL COMMENT 'Hroa de envio paquete de facturas a la Dian',
  `sia_fecini_fcpq` date DEFAULT NULL COMMENT 'Fecha inicial periodo facturacion a enviar',
  `sia_fecfin_fcpq` date DEFAULT NULL COMMENT 'Fecha final periodo facturacion a enviar',
  `fcm_descue_fcpq` varchar(60) DEFAULT NULL COMMENT 'Descripcion o nota del paquete',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Código de Empresa cliente y/o tercero EPS o asegurador según módulos administrativos',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del factuador  usuario del sistema que que realiza la ultima modificacion',
  `fcm_conest_fcpq` int(5) DEFAULT NULL COMMENT 'Contador para generar los registros únicos  detalles cada factura relacionada',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro según estado de la cuenta de cobro: 1=Abierta 2=Confirmada 3=Anulada',
  PRIMARY KEY (`fcm_secreg_fcpq`),
  KEY `fcpq02` (`fcm_descue_fcpq`),
  KEY `fcpq03` (`cto_seccon_cont`),
  KEY `fcpq04` (`sia_fecini_fcpq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfeenviosdianmd` table : 
#

DROP TABLE IF EXISTS `fcmfeenviosdianmd`;

CREATE TABLE `fcmfeenviosdianmd` (
  `fcm_secreg_fccd` varchar(20) NOT NULL COMMENT 'Secuencial unico detalles facturas en cuenta de cobro (generado por el sistema)',
  `fcm_secreg_fcpq` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico del paquete R1',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo unico de paciente en el sistema',
  `fcm_secreg_mfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico registro maestro factura (generado por el sistema)',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Código Adquirente - Empresa cliente y/o tercero EPS o asegurador según módulos administrativos',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero de factura (desde maestro de facturas)',
  `fcm_codest_fcws` varchar(3) DEFAULT NULL COMMENT 'Estado gestion WS Dian: R01=Enviada y aceptada con Éxito R02=Enviada con errores en validacion C01=El Servicio Dian no respondio /... Otros',
  `fcm_trakid_mfac` varchar(120) DEFAULT NULL COMMENT 'TrackId: Con el trackId obtenido en el método, se consume otro método de consulta para obtener el resultado de las validaciones posteriores realizadas a la factura',
  `fcm_codest_fcaq` varchar(3) DEFAULT NULL COMMENT 'Estado envio al adquirente: A01=Pendiente por enviar al Adquirente A02=Enviada al Adquirente por correo',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro según estado de la cuenta de cobro: 1=Abierta 2=Confirmada 3=Anulada',
  PRIMARY KEY (`fcm_secreg_fccd`),
  KEY `fccd02` (`fcm_secreg_fcpq`),
  KEY `fccd03` (`sia_idesec_usua`),
  KEY `fccd04` (`fcm_secreg_mfac`),
  KEY `fccd05` (`sis_idterc_sitr`),
  KEY `fccd06` (`fcm_numfac_mfac`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfeestadoresadqu` table : 
#

DROP TABLE IF EXISTS `fcmfeestadoresadqu`;

CREATE TABLE `fcmfeestadoresadqu` (
  `fcm_codest_fcaq` varchar(3) NOT NULL COMMENT 'Estado envio al adquirente: A01=Pendiente por enviar al Adquirente A02=Enviada al Adquirente por correo',
  `fcm_desest_fcaq` varchar(50) DEFAULT NULL COMMENT 'Descripción estado gestion WS Dian',
  PRIMARY KEY (`fcm_codest_fcaq`),
  KEY `fcaq02` (`fcm_desest_fcaq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfeestadoresdian` table : 
#

DROP TABLE IF EXISTS `fcmfeestadoresdian`;

CREATE TABLE `fcmfeestadoresdian` (
  `fcm_codest_fcws` varchar(3) NOT NULL COMMENT 'Estado gestion WS Dian: R01=Enviada y aceptada con Éxito R02=Enviada con errores en validacion C01=El Servicio Dian no respondio',
  `fcm_desest_fcws` varchar(50) DEFAULT NULL COMMENT 'Descripción estado gestion WS Dian',
  PRIMARY KEY (`fcm_codest_fcws`),
  KEY `fcws02` (`fcm_desest_fcws`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Data for the `fcmfeestadoresdian` table  (LIMIT 0,500)
#

INSERT INTO `fcmfeestadoresdian` (`fcm_codest_fcws`, `fcm_desest_fcws`) VALUES 
  ('C01','El Servicio Dian no respondio'),
  ('R01','Enviada y aceptada con Exito '),
  ('C02','Error de conexión'),
  ('R02','Rechazada por errores en Validación'),
  ('P01','Sin Enviar');

COMMIT;

#
# Structure for the `fcmfemaescontrato` table : 
#

DROP TABLE IF EXISTS `fcmfemaescontrato`;

CREATE TABLE `fcmfemaescontrato` (
  `cto_seccon_cont` varchar(10) NOT NULL COMMENT 'Secuencial Unico de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato según documento firmado en acuerdo de voluntades',
  `cto_modter_cont` varchar(1) DEFAULT NULL COMMENT 'Modificar Código  del tercero asociado al contrato en el momento de facturar servicios 1=SI 2=NO',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Codigo de Empresa cliente y/o tercero EPS o asegurador según modulos adminstrativos',
  `cto_fecico_cont` date DEFAULT NULL COMMENT 'Fecha Inicio vigencia del contrato',
  `cto_fecfco_cont` date DEFAULT NULL COMMENT 'Fecha finalizacion vigencia contrato',
  `cto_descon_cont` varchar(50) DEFAULT NULL COMMENT 'Descripcion textual del contrato',
  `fcm_codman_mans` varchar(3) DEFAULT NULL COMMENT 'Codigo del manual tarifario de servicios productos',
  `cto_ajupre_cont` int(4) DEFAULT NULL COMMENT 'Ajuste del precio de servicios a: 10,20,50,100,100 y otros',
  `cto_porrec_cont` float(6,2) DEFAULT NULL COMMENT 'Prcentaje incremento precios de Venta  o descuento (Recargo o descuento en precios) ejm: tarifa servicio +10, tarifa servicio- 5',
  `cto_fcdian_cont` varchar(1) DEFAULT NULL COMMENT 'Generar Numeros de factura desde Secuencial autorizado DIAN: 1=SI 2=NO',
  `cto_dianev_cont` varchar(1) DEFAULT NULL COMMENT 'Enviar automaticamente las facturas y Notas debito y credito a la Dian: 1=Enviar Automaticamente 2=Enviar de forma Manual 3=No aplica',
  `cto_dianet_cont` int(6) DEFAULT NULL COMMENT 'Tiempo en minutos para que el sistema haga el envio de factura a la Dian despues de generada en facturacion',
  `cto_prnord_cont` varchar(1) DEFAULT NULL COMMENT 'Imprimir por defecto la orden de prestacion de servicios medicos: 1= Si 2=No',
  `cto_prnrca_cont` varchar(1) DEFAULT NULL COMMENT 'Imprimir por defecto recibo de caja  por valores pagados en efectivo : 1= Si 2=No',
  `cto_apldes_cont` varchar(1) DEFAULT NULL COMMENT 'Aplicar Descuento: 1=Si 2=No',
  `cto_cobser_cont` varchar(1) DEFAULT NULL COMMENT 'Realizar cobros en efectivo de valores servicios: 1=Si 2=No (para mostrar la Ventana Cobro en efectivo al Facturar)',
  `cto_secdet_cont` int(10) DEFAULT NULL COMMENT 'Campo para generar el secuencial de registros servicios del tarifario personalizados del contrato',
  `cto_estcon_cont` varchar(1) DEFAULT NULL COMMENT 'Estado del Contrato: 1=Activo 2=Inactivo 3=Suspendido',
  PRIMARY KEY (`cto_seccon_cont`),
  KEY `cto02` (`cto_nrocon_cont`),
  KEY `cto03` (`sis_idterc_sitr`),
  KEY `cto04` (`cto_descon_cont`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfemaesfactefma` table : 
#

DROP TABLE IF EXISTS `fcmfemaesfactefma`;

CREATE TABLE `fcmfemaesfactefma` (
  `fcm_secreg_mfac` varchar(20) NOT NULL COMMENT 'Secuencial unico facturada-Nota Credito-Nota Debito (generado por el sistema)',
  `fcm_secraz_fcem` varchar(10) DEFAULT NULL COMMENT 'Codigo unico Razon Social empresa para gestion documentos DIAN',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero de factura generada /Invoice/cbc:ID - Número de documento: Número de factura o factura cambiaria. Incluye prefijo + consecutivo de factura autorizados por la DIAN',
  `fcm_fecfac_mfac` date DEFAULT NULL COMMENT 'Fecha de la factura (fecha en que fue cerrada y generado el secuencial de factrua)',
  `fcm_horfac_mfac` decimal(5,2) DEFAULT NULL COMMENT 'Hora emision de la factura',
  `fcm_typdoc_fctd` varchar(3) DEFAULT NULL COMMENT 'Tipos de documentos para envio a Dian: 01=Factura electrónica de Venta 02=Factura electrónica venta-xportación 91=Nota Credito 92=Nota Debito y otros',
  `fcm_notdoc_mfac` varchar(200) DEFAULT NULL COMMENT 'Nota Textual del documento',
  `fcm_forpag_mfac` varchar(1) DEFAULT NULL COMMENT 'Forma de pago: 1=Contado 2=Crédito',
  `fcm_facori_mfac` varchar(2) DEFAULT NULL COMMENT 'Origen gestion de la factura: 01=Desde Gestion Cartera (cuenta de cobro) 02=Desde Facturacion Ventas a personas juridicas 03=Desde Facturacion Ventas a personas naturales',
  `fcm_secres_srfa` varchar(10) DEFAULT NULL COMMENT 'Secuencial unico  en el sistema (maestro de resoluciones para rangos de facturacion DIAN ) para referenciar de la resolución Dian',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión o del registro de atencion ambulatoria',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Codigo de Eps o Asegurador según codigos asignados por la supersalud',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Código de Empresa cliente y/o tercero EPS o asegurador según módulos administrativos',
  `fcm_sercre_mfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico Documento Factura o  Documento Nota Credito de referencia por la cual se genera este documento',
  `fcm_idrcre_mfac` varchar(20) DEFAULT NULL COMMENT 'Opcional cuando el documento es factura, se referencia la nota crédito y se referencia numero de factura cuando este documento es nota credito (obligatorio), Se debe diligenciar únicamente cuando la FE se origina a partir de la corrección ajuste que se da mediante un Nota Crédito',
  `fcm_serdeb_mfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico Documento Factura o  Documento Nota Debito de referencia por la cual se genera este documento',
  `fcm_idrdeb_mfac` varchar(20) DEFAULT NULL COMMENT 'Opcional cuando el documento es factura, se referencia la nota debito y se referencia numero de factura cuando este documento es nota debito (obligatorio), Se debe diligenciar únicamente cuando la FE se origina a partir de la corrección ajuste que se da mediante un Nota Debito',
  `fcm_valbsi_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor de la base Imponible (base para el calculo de impuesto)',
  `fcm_valiva_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IVA aplicado',
  `fcm_valicd_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IC - Impuesto de Industria, Comercio y Aviso',
  `fcm_valica_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor ICA Impuesto Nacional al Consumo',
  `fcm_valinc_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor INC Impuesto Nacional al Consumo',
  `fcm_valrti_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor RetVA Retención sobre el IVA',
  `fcm_valrtf_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor ReteFuente (reteción en la fuente)',
  `fcm_valrtc_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del ReteICA aplicado',
  `fcm_valcre_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del ReteCRE aplicado',
  `fcm_valfth_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del FtoHorticultura aplicado',
  `fcm_valtim_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del Timbre aplicado',
  `fcm_valbol_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor Impuesto Bolsas aplicado',
  `fcm_valicr_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IVA aplicado',
  `fcm_valicb_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del INCombustibles aplicado',
  `fcm_valscb_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor de Sobretasa Combustibles aplicado',
  `fcm_valsco_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del Sordicom aplicado',
  `fcm_valftr_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor figura tributaria aplicada',
  `fcm_pordes_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje de descuento aplicada (cuando el descuento se haya calculado en porcentaje)',
  `fcm_valdes_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total del descuento realizado al cliente',
  `fcm_valcpa_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total del copago recudado en el srvicio como tal, suma en factura',
  `fcm_valcmo_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total de cuota moderadora recudada en servico y suma en la factura',
  `fcm_valusu_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor cargo al usuario, cobrado al paciente por porcentajes no cubiertos en el seguro',
  `fcm_valbru_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total  bruto facturado del servicio sin ninguna deducción: FCM_VALSER_SIPS x FCM_TOTUNI_DFAC',
  `fcm_valsub_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor subtotal del servicio facturado haciendo deducciones: FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VALDES_DFAC)',
  `fcm_valfac_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total del servicio facturado incluyendo impuestos (IVA y otros impuestos)  y con las anteriores  valor a entidad deducciones:FCM_VALSUB_DFAC+IMPUESTOS',
  `fcm_valref_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor recuadado en efectivo (solo valor cobrado en efectivo) por cobros de copagos o valor total del servicio (no siempre representa el valor total del servicio)',
  `fcm_valefe_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor final recuadado en efectivo con el descuento realizado',
  `fcm_idcufe_mfac` varchar(110) DEFAULT NULL COMMENT 'Numero unico CUFE o CUDE según el tipo de documento generado ',
  `fcm_diafec_mfac` date DEFAULT NULL COMMENT 'Fecha radicacion factura en Dian  y es recibida correcta en la validacion',
  `fcm_diahor_mfac` decimal(5,2) DEFAULT NULL COMMENT 'Hora radicacion factura en Dian y es recibida correcta en validacion',
  `fcm_codest_fcws` varchar(3) DEFAULT NULL COMMENT 'Estado gestion WS Dian: R01=Enviada y aceptada con Éxito R02=Enviada con errores en validacion C01=El Servicio Dian no respondio /... Otros',
  `fcm_errore_mfac` text COMMENT 'Listado de errores en validación Dian',
  `fcm_nomarc_mfac` varchar(40) DEFAULT NULL COMMENT 'Nombre del archivo fisico sin ninguna extension generado y enviado a la DIAN',
  `fcm_secrad_mfac` int(6) DEFAULT NULL COMMENT 'Numero secuencial del radicado, generado por el contador del sistema, corresponde al numero secuencial de envios a la DIAN',
  `fcm_trakid_mfac` varchar(80) DEFAULT NULL COMMENT 'TrackId: Con el trackId obtenido en el método, se consume otro método de consulta para obtener el resultado de las validaciones posteriores realizadas a la factura',
  `fcm_adqfec_mfac` date DEFAULT NULL COMMENT 'Fecha envio al adquirente a travez de correo electronico',
  `fcm_adqhor_mfac` decimal(5,2) DEFAULT NULL COMMENT 'Hora envio adquirente a travez de correo electronico',
  `fcm_codest_fcaq` varchar(3) DEFAULT NULL COMMENT 'Estado envio al adquirente: A01=Pendiente por enviar al Adquirente A02=Enviada al Adquirente por correo',
  `fcm_metpag_mfac` varchar(1) DEFAULT NULL COMMENT 'Metodo de pago 1=Contado 2=Credito',
  `fcm_codmpg_fcmp` varchar(7) DEFAULT NULL COMMENT 'FAN02: Codigo secuencial medios de pago según  cuadro  No: 6.3.4.2 - Medios de Pago: cbc:PaymentMeansCode',
  `fcm_fecven_mfac` date DEFAULT NULL COMMENT 'Fecha vencimiento factura contada desde el momento que fue  generado el secuencial factrua Dian',
  `fcm_idepag_fcmp` varchar(20) DEFAULT NULL COMMENT 'FAN05: Identificador del pago',
  `fcm_fecanu_mfac` date DEFAULT NULL COMMENT 'Fecha en que la cual se anulo la factura confirmada (estado 2)',
  `fcm_horanu_mfac` decimal(5,2) DEFAULT NULL COMMENT 'Hora en la cual fue anulada la factura',
  `sys_usuanu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del factuador  usuario del sistema que que anula',
  `fcm_notanu_mfac` varchar(200) DEFAULT NULL COMMENT 'Motivo textual por el cual se anula la factura',
  `fcm_algori_mfac` varchar(10) DEFAULT NULL COMMENT 'Algoritmo utilizado para generar CUDE o el CUFE  (se usa como referencia): SHA384 - SHA512 pero  por defecto SHA384',
  `fcm_conest_mfac` int(5) DEFAULT NULL COMMENT 'Contador para generar los registros únicos  detalles',
  `fcm_fecedt_mfac` date DEFAULT NULL COMMENT 'Fecha ultima modificacion realizada por un usario o facturador',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del factuador  usuario del sistema que que realiza la ultima modificacion',
  `fcm_tiprfa_mfac` varchar(1) DEFAULT NULL COMMENT 'Tipo registro factura generada: 1= Registro ordenes de servicios  (pre factura) 2= Numero de Factura Valida Dian',
  `fcm_estfac_mfac` varchar(1) DEFAULT NULL COMMENT 'Estado de la factura 1=Abierta 2=Cerrada 3=Anulada',
  PRIMARY KEY (`fcm_secreg_mfac`),
  KEY `mfac02` (`fcm_numfac_mfac`),
  KEY `mfac03` (`adm_secadm_rgad`),
  KEY `mfac04` (`sia_idesec_usua`),
  KEY `mfac05` (`cto_seccon_cont`),
  KEY `mfac06` (`sis_idterc_sitr`),
  KEY `mfac07` (`fcm_fecfac_mfac`),
  KEY `mfac08` (`fcm_fecven_mfac`),
  KEY `mfac09` (`fcm_secres_srfa`),
  KEY `mfac10` (`fcm_sercre_mfac`),
  KEY `mfac11` (`fcm_serdeb_mfac`),
  KEY `mfac12` (`fcm_secraz_fcem`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfemaesfactefmd` table : 
#

DROP TABLE IF EXISTS `fcmfemaesfactefmd`;

CREATE TABLE `fcmfemaesfactefmd` (
  `fcm_secreg_dfac` varchar(20) NOT NULL COMMENT 'Secuencial unico del registro o servicio facturado , generado por el sistema',
  `fcm_secreg_mfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico de la orden Factura-Nota Debito-Nota-Credito (generado por el sistema)',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero de la factura generada en el cierre de facturación',
  `fcm_idesec_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo unico del servicio para venta con manual tarifario (generado por el sistema)',
  `fcm_codpro_fcpr` varchar(10) DEFAULT NULL COMMENT 'Codigo Producto segun clasificacion UNSPSC',
  `fcm_codbar_mant` varchar(30) DEFAULT NULL COMMENT 'Codigo de Barras del Servicio suministro o medicamento (opcional)',
  `fcm_tiptar_dfac` varchar(4) DEFAULT NULL COMMENT 'Tipo codigo en Tarifario productos: 001=UNSPSC Codificacion Colombiaa compra Eficiente 010=GTIN Numeros Globales  Identificacion Productos 020=Partida Arancelaria 999=Esntandar Propio Adoptado por el contribuyente',
  `fcm_codser_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo del servicio o producto  según estandar propio del contribuyente:(schemeID = 999 campo: FAZ10 Resolucion facturacion eletronica DIAN',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (puede ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `fcm_codman_mans` varchar(4) DEFAULT NULL COMMENT 'Codigo del manual tarifario de servicios configurados para ventas ejm: M01=Ventas a particulares  M02=Manual para ventas empresas contratistas',
  `fcm_desser_dfac` varchar(240) DEFAULT NULL COMMENT 'Descripcion textual del servicio o producto para incluir en la factura item de ',
  `fcm_fecser_dfac` date DEFAULT NULL COMMENT 'Fecha de prestacion del servicio o fecha venta del producto',
  `fcm_horser_dfac` decimal(5,2) DEFAULT NULL COMMENT 'Hora  digitacion del servicio en facturacion en formato militar',
  `fcm_valser_mant` decimal(17,2) DEFAULT NULL COMMENT 'Valor del servicio para venta según manual tarifario',
  `fcm_totuni_dfac` int(10) DEFAULT NULL COMMENT 'Total de unidades facturadas del servicio',
  `fcm_valbru_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total  bruto facturado del servicio sin ninguna deducción: FCM_VALSER_SIPS x FCM_TOTUNI_DFAC',
  `fcm_valbsi_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor de la base Imponible (base para el calculo de impuesto)',
  `fcm_poriva_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación IVA',
  `fcm_valiva_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IVA aplicado',
  `fcm_poricd_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación IC -Impuesto al consumo departamental',
  `fcm_valicd_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IC - Impuesto de Industria, Comercio y Aviso',
  `fcm_porica_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ICA Impuesto de Industria Comercio y Aviso',
  `fcm_valica_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor ICA Impuesto Nacional al Consumo',
  `fcm_porinc_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación INC Impuesto Nacional al Consumo',
  `fcm_valinc_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor INC Impuesto Nacional al Consumo',
  `fcm_porrti_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación RetVA Retención sobre el IVA',
  `fcm_valrti_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor RetVA Retención sobre el IVA',
  `fcm_porrtf_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ReteFuente (reteción en la fuente)',
  `fcm_valrtf_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor ReteFuente (reteción en la fuente)',
  `fcm_porrtc_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ReteICA',
  `fcm_valrtc_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del ReteICA aplicado',
  `fcm_porcre_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ReteCree',
  `fcm_valcre_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del ReteCRE aplicado',
  `fcm_porfth_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación FtoHorticultura',
  `fcm_valfth_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del FtoHorticultura aplicado',
  `fcm_portim_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Timbre',
  `fcm_valtim_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del Timbre aplicado',
  `fcm_porbol_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Bolsas',
  `fcm_valbol_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor Impuesto Bolsas aplicado',
  `fcm_poricr_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación INCarbono',
  `fcm_valicr_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del IVA aplicado',
  `fcm_poricb_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicado INCombustibles',
  `fcm_valicb_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del INCombustibles aplicado',
  `fcm_porscb_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Sobretasa Combustibles',
  `fcm_valscb_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor de Sobretasa Combustibles aplicado',
  `fcm_porsco_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Sordicom',
  `fcm_valsco_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor del Sordicom aplicado',
  `fcm_porftr_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación figura tributaria',
  `fcm_valftr_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor figura tributaria aplicada',
  `sis_coddes_side` varchar(6) DEFAULT NULL COMMENT 'Codigo tarifa  descuento aplicado al prodcuto en venta',
  `fcm_pordes_dfac` decimal(6,2) DEFAULT NULL COMMENT 'Porcentaje de descuento aplicada (cuando el descuento se haya calculado en porcentaje)',
  `fcm_valdes_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total del descuento realizado al cliente',
  `fcm_valsub_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor subtotal del servicio facturado haciendo deducciones: FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VALDES_DFAC)',
  `fcm_valfac_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor total del servicio facturado incluyendo el IVA  y con las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DFAC+FCM_VALCOM_DFAC',
  `fcm_valref_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor recuadado en efectivo (solo valor cobrado en efectivo) por cobros de copagos o valor total del servicio (no siempre representa el valor total del servicio)',
  `fcm_valefe_dfac` decimal(17,2) DEFAULT NULL COMMENT 'Valor final recuadado en efectivo con el descuento realizado',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro según estado de la admision: 1=Abierto 2=Cerrado 3=Anulado',
  PRIMARY KEY (`fcm_secreg_dfac`),
  KEY `dfac03` (`fcm_numfac_mfac`),
  KEY `dfac04` (`fcm_fecser_dfac`),
  KEY `dfac05` (`fcm_codpro_fcpr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfemaesrazsocma` table : 
#

DROP TABLE IF EXISTS `fcmfemaesrazsocma`;

CREATE TABLE `fcmfemaesrazsocma` (
  `fcm_secraz_fcem` varchar(10) NOT NULL COMMENT 'Codigo secuencial unico razon social empresa',
  `fcm_tipjur_fcem` varchar(1) DEFAULT NULL COMMENT 'Identificador de tipo de organización jurídica de la de persona: 1=Persona Juridica 2=Persona natural',
  `fcm_tipdoc_fctn` varchar(2) DEFAULT NULL COMMENT 'Tipo numero documento Nit: Registro civil-Tarjeta de identidad,Cédula de ciudadanía-Tarjeta de extranjería-Cédula de extranjería-NIT-Pasaporte-Documento de identificación extranjero-NIT de otro país-NUIP',
  `fcm_numdoc_fcem` varchar(15) DEFAULT NULL COMMENT 'Numero del Nit de la empresa',
  `fcm_digver_fcem` varchar(1) DEFAULT NULL COMMENT 'Digito de verifcacion del Nit',
  `fcm_numprn_fcem` varchar(20) DEFAULT NULL COMMENT 'Numero del Nit de la empresa con puntos separadores y digito deverifiacion ejemplo:  854.000.235-9',
  `fcm_codips_fcem` varchar(20) DEFAULT NULL COMMENT 'Codigo prestador de servicios de salud y de habilitacion según Ministerio de Salud de Colombia',
  `fcm_nomcom_fcem` varchar(150) DEFAULT NULL COMMENT 'Nombre comercial de la empresa',
  `fcm_razsoc_fcem` varchar(240) DEFAULT NULL COMMENT 'Nombre o Razón Social (para inforamción tributaria) informacion legal',
  `fcm_slogan_fcem` varchar(150) DEFAULT NULL COMMENT 'Texto slogan de la empresa, para impresión en documentos',
  `fcm_notpag_fcem` text COMMENT 'Texto largo para impresión en pie de pagina en documentos',
  `fcm_codres_fcrf` varchar(150) DEFAULT NULL COMMENT 'Responsabilidades fiscales de la empresa según lista  Dian Resolucion Facturacion Eletronica FAJ26',
  `sis_codact_sitr` varchar(40) DEFAULT NULL COMMENT 'Lista de códigos de actividad económica CIIU según Dian FAJ04 (separados por punto y coma)',
  `fcm_imglog_fcem` varchar(80) DEFAULT NULL COMMENT 'Imagen (tipo JPG o PNG) logotipo de la empresa guardado en la ruta de reportes',
  `fcm_imgcab_fcem` varchar(80) DEFAULT NULL COMMENT 'Imagen (tipo JPG o PNG) logotipo para encabezado de documentos y otros  guardado en la ruta de reportes',
  `sis_idemun_muni` varchar(5) DEFAULT NULL COMMENT 'Codigo DANE Municipio de residencia  donde ejerce la activid (Id Unico Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio)',
  `fcm_dirres_fcem` varchar(150) DEFAULT NULL COMMENT 'Direccion de residencia comercial',
  `fcm_nrotel_fcem` varchar(40) DEFAULT NULL COMMENT 'Telefonos para contacto',
  `fcm_correo_fcem` varchar(80) DEFAULT NULL COMMENT 'Correo eletronico  empresarial para recibir notificaciones legales',
  `sis_codpos_sicp` varchar(10) DEFAULT NULL COMMENT 'Codigo postal según lugar de Residencia',
  `fcm_reptdo_fcem` varchar(2) DEFAULT NULL COMMENT 'Tipo documento de indentificacion del Representante legal: CC=Cedula de ciudadania  CE=Cedula de Extranjeria PA=Pasaporte',
  `fcm_repndo_fcem` varchar(20) DEFAULT NULL COMMENT 'Numero docuemtno de identidad del responsable de facturacion',
  `fcm_repnom_fcem` varchar(40) DEFAULT NULL COMMENT 'Nombre del Usuario facturador o contacto',
  `fcm_reptel_fcem` varchar(40) DEFAULT NULL COMMENT 'Telefono del representante legal de la empresa',
  `fcm_repema_fcem` varchar(80) DEFAULT NULL COMMENT 'Correo eletronico representante legal de la empresa',
  `fcm_repimg_fcem` varchar(80) DEFAULT NULL COMMENT 'Imagen (tipo JPG o PNG) para mostrar la firma del representante legal de la empresa',
  `fcm_ctotdo_fcem` varchar(2) DEFAULT NULL COMMENT 'Tipo documento de indentificacion del responsable de facturacion: CC=Cedula de ciudadania  CE=Cedula de Extranjeria PA=Pasaporte',
  `fcm_ctondo_fcem` varchar(20) DEFAULT NULL COMMENT 'Numero docuemtno de identidad del responsable de facturacion',
  `fcm_ctonom_fcem` varchar(40) DEFAULT NULL COMMENT 'Nombre del Usuario facturador o contacto',
  `fcm_ctotel_fcem` varchar(40) DEFAULT NULL COMMENT 'Telefono del Area de Facturacion o contacto con la empresa',
  `fcm_ctoema_fcem` varchar(80) DEFAULT NULL COMMENT 'Correo eletronico para contacto con Facturación',
  `fcm_ctoimg_fcem` varchar(80) DEFAULT NULL COMMENT 'Imagen (tipo JPG o PNG) para mostrar la firma del encargado de firmar facturas',
  `fcm_ambien_fcem` varchar(1) DEFAULT NULL COMMENT 'Ambiente facturación Produccion o Ambiente de Pruebas',
  `fcm_sofnom_fcem` varchar(70) DEFAULT NULL COMMENT 'Nombre del Software tal como quedo registrado en la plataforma de Facturación Electrónica de la DIAN',
  `fcm_sofide_fcem` varchar(80) DEFAULT NULL COMMENT 'Codigo unico registro del Software en la plataforma de Facturación Electrónica de DIAN',
  `fcm_sofpin_fcem` varchar(20) DEFAULT NULL COMMENT 'Numero de Pin dado en el registro DIAN del Software',
  `fcm_setpru_fcem` varchar(80) DEFAULT NULL COMMENT 'Numero del set de pruebas (TestSetId) dado por DIAN para el Software',
  `fcm_urlset_fcem` varchar(80) DEFAULT NULL COMMENT 'Url del Web Service para conexión y envio del set de facturas del software en ambiente de pruebas para habilitación',
  `fcm_urlpro_fcem` varchar(80) DEFAULT NULL COMMENT 'Url del Web Service para conexión y envio de facturas en Ambiente de Producción del software habilitado',
  `fcm_clatec_fcem` varchar(80) DEFAULT NULL COMMENT 'Codigo clave Tecnica del Software al momento de ser habilitado para pasar al Ambiente Producción',
  `fcm_conser_fcem` int(6) DEFAULT NULL COMMENT 'Contador para envios de documentos a la DIAN, se utiliza para generar el nombre del archivo a enviar',
  `fcm_certip_fcem` varchar(5) DEFAULT NULL COMMENT 'Tipo de certificado digital expedido por la DIAN (PFX o P12)',
  `fcm_cerarc_fcem` varchar(50) DEFAULT NULL COMMENT 'Nombre del archivo fisico del certificado digital con extencion para ser localizado por la aplicación',
  `fcm_cerark_fcem` varchar(50) DEFAULT NULL COMMENT 'Nombre del archivo fisico  que contiene la  clave de apertura del  archivo certificado digital',
  `fcm_cerkey_fcem` varchar(40) DEFAULT NULL COMMENT 'Clave en base64  del certificado Contenido Hash  guardado en la base de datos',
  `fcm_cerhas_fcem` text COMMENT 'Contenido Hash del certificado digital guardado en la base de datos en base64  para evitar el uso de archivos fisicos',
  `fcm_secres_srfa` varchar(10) DEFAULT NULL COMMENT 'Secuencial unico  en el sistema (maestro de resoluciones para rangos de facturacion DIAN) para referenciar de la resolución Dian',
  `fcm_congen_fcem` int(6) DEFAULT NULL COMMENT 'Contador  para generar registros tipo detalles cuando se requiera',
  `fcm_estreg_fcem` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=inactivo',
  PRIMARY KEY (`fcm_secraz_fcem`),
  KEY `fcem02` (`fcm_numdoc_fcem`),
  KEY `fcem03` (`fcm_nomcom_fcem`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfemaestarifama` table : 
#

DROP TABLE IF EXISTS `fcmfemaestarifama`;

CREATE TABLE `fcmfemaestarifama` (
  `fcm_codman_mans` varchar(4) NOT NULL COMMENT 'Codigo del manual tarifario de servicios configurados para ventas ejm: M01=Ventas a particulares  M02=Manual para ventas empresas contratistas',
  `fcm_desman_mans` varchar(50) DEFAULT NULL COMMENT 'Descripcion manual tarifario',
  `fcm_conser_mans` int(6) DEFAULT NULL COMMENT 'Contador para generar registros detalles del manual de servicios y para registros en paquetes',
  `fcm_estman_mans` varchar(1) DEFAULT NULL COMMENT 'Estado del manual venta productos: 1= Activo  2= Inactivo',
  PRIMARY KEY (`fcm_codman_mans`),
  KEY `mans02` (`fcm_desman_mans`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfemaestarifamd` table : 
#

DROP TABLE IF EXISTS `fcmfemaestarifamd`;

CREATE TABLE `fcmfemaestarifamd` (
  `fcm_idesec_mant` varchar(20) NOT NULL COMMENT 'Codigo unico secuencial del servicio para venta con manual tarifario (generado por el sistema)',
  `fcm_codman_mans` varchar(3) DEFAULT NULL COMMENT 'Codigo del manual tarifario de servicios configurados para ventas ejm: M01=Ventas a particulares  M02=Manual para ventas empresas contratistas',
  `fcm_codpro_fcpr` varchar(10) DEFAULT NULL COMMENT 'Codigo Producto segun clasificacion UNSPSC',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del producto o servicio en facturacion es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `fcm_codbar_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo de Barras del Servicio suministro o medicamento (opcional)',
  `fcm_despro_mant` varchar(250) DEFAULT NULL COMMENT 'Descripción textual del servicio en el manual',
  `fcm_valpro_mant` float(17,2) DEFAULT NULL COMMENT 'Valor del servicio o producto  para venta',
  `sis_codiva_simi` varchar(6) DEFAULT NULL COMMENT 'Porcentaje aplicación IVA',
  `sis_codicd_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación IC -Impuesto al consumo departamental',
  `sis_codica_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ICA Impuesto de Industria Comercio y Aviso',
  `sis_codinc_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación INC Impuesto Nacional al Consumo',
  `sis_codrti_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación RetVA Retención sobre el IVA',
  `sis_codrtf_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ReteFuente (reteción en la fuente)',
  `sis_codrtc_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ReteICA',
  `sis_codcre_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación ReteCree',
  `sis_codfth_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación FtoHorticultura',
  `sis_codtim_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Timbre',
  `sis_codbol_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Bolsas',
  `sis_codicr_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación INCarbono',
  `sis_codicb_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicado INCombustibles',
  `sis_codscb_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Sobretasa Combustibles',
  `sis_codsco_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación Sordicom',
  `sis_codftr_simi` float(6,2) DEFAULT NULL COMMENT 'Porcentaje aplicación figura tributaria',
  `fcm_fecinv_mant` date DEFAULT NULL COMMENT 'Fecha en la cual inicia vigencia el servicio (cuando no hay fechas no aplica)',
  `fcm_fecfiv_mant` date DEFAULT NULL COMMENT 'Fecha en la cual finaliza vigencia el servicio (cuando no hay fechas no aplica)',
  `fcm_estpro_mant` varchar(1) DEFAULT NULL COMMENT 'Estado del servicio dentro la IPS: 1=Activo 2=Inactivo',
  PRIMARY KEY (`fcm_idesec_mant`),
  KEY `mant02` (`fcm_coddig_mant`),
  KEY `mant03` (`fcm_codman_mans`),
  KEY `mant04` (`fcm_codbar_mant`),
  KEY `mant05` (`fcm_despro_mant`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfemediosdepago` table : 
#

DROP TABLE IF EXISTS `fcmfemediosdepago`;

CREATE TABLE `fcmfemediosdepago` (
  `fcm_codmpg_fcmp` varchar(7) NOT NULL COMMENT 'FAN03: Codigo secuencial medios de pago según  cuadro  No: 6.3.4.2 - Medios de Pago: cbc:PaymentMeansCode',
  `fcm_desmpg_fcmp` varchar(90) DEFAULT NULL COMMENT 'FAN03: Descripcion medios de pago según  cuadro  No: 6.3.4.2 - Medios de Pago: cbc:PaymentMeansCode',
  PRIMARY KEY (`fcm_codmpg_fcmp`),
  KEY `fcmp02` (`fcm_desmpg_fcmp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfesecrfacturas` table : 
#

DROP TABLE IF EXISTS `fcmfesecrfacturas`;

CREATE TABLE `fcmfesecrfacturas` (
  `fcm_secres_srfa` varchar(10) NOT NULL COMMENT 'Secuencial unico de la resolución Dian en el sistema (generado por el sistema)',
  `fcm_numres_srfa` varchar(20) DEFAULT NULL COMMENT 'InvoiceAuthorization: Número autorización Dian: Número del código de la resolución otorgada para la numeración',
  `fcm_desres_srfa` varchar(40) DEFAULT NULL COMMENT 'Descripcion o nota  de la resolucion Dian',
  `fcm_notenc_srfa` text COMMENT 'Nota para el encabezado de pagina en factura impresa',
  `fcm_noppag_srfa` text COMMENT 'Nota para el pie de pagina en factura impresa',
  `fcm_fecini_srfa` date DEFAULT NULL COMMENT 'StartDate:Fecha de inicio de la autorización de la numeración',
  `fcm_fecfin_srfa` date DEFAULT NULL COMMENT 'EndDate: Fecha finalizacion de la autorización de la numeración',
  `fcm_prefij_srfa` varchar(5) DEFAULT NULL COMMENT 'Prefix: Prefijo de la autorización de numeración de facturación dado por el SIE de Numeración',
  `fcm_facini_srfa` int(15) DEFAULT NULL COMMENT 'From: Numero secuencial de factura donde inicia el consecutivo',
  `fcm_facfin_srfa` int(15) DEFAULT NULL COMMENT 'To: Numero secuencial de factura donde finaliza el consecutivo',
  `fcm_ultgen_srfa` int(15) DEFAULT NULL COMMENT 'Ultimo Numero de factura generado (se utiliza como base para generar el siguiente)',
  `fcm_maxsec_srfa` int(2) DEFAULT NULL COMMENT 'Inidica el tamaño maximo en caracteres para el secuencial generado como numero de factura',
  `fcm_alrsec_srfa` int(5) DEFAULT NULL COMMENT 'Indica cuantos numeros secuenciales antes se emite mensaje de alarma de que se cumpla el limite',
  `fcm_relcer_srfa` varchar(1) DEFAULT NULL COMMENT 'Inidica si se rellena el nuevo secuencial con ceros a la izquierda 1 =Si 2=No',
  `fcm_estreg_srfa` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1 =Activo 2=Inactivo',
  PRIMARY KEY (`fcm_secres_srfa`),
  KEY `srfa02` (`fcm_numres_srfa`),
  KEY `srfa03` (`fcm_desres_srfa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfetipodocument` table : 
#

DROP TABLE IF EXISTS `fcmfetipodocument`;

CREATE TABLE `fcmfetipodocument` (
  `fcm_typdoc_fctd` varchar(3) NOT NULL COMMENT 'Tipos de documentos para envio a Dian: 01=Factura electrónica de Venta 02=Factura electrónica venta-xportación 91=Nota Credito 92=Nota Debito y otros',
  `fcm_destyp_fctd` varchar(50) DEFAULT NULL COMMENT 'Descripcion tipo documento',
  PRIMARY KEY (`fcm_typdoc_fctd`),
  KEY `fctd02` (`fcm_destyp_fctd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfeunspscasegme` table : 
#

DROP TABLE IF EXISTS `fcmfeunspscasegme`;

CREATE TABLE `fcmfeunspscasegme` (
  `fcm_codseg_fcsg` varchar(3) NOT NULL COMMENT 'Codigo clasificacion segmento de mercado UNSPSC para el producto',
  `fcm_desseg_fcsg` varchar(90) DEFAULT NULL COMMENT 'Descripcion segmento UNSPSC para el producto',
  PRIMARY KEY (`fcm_codseg_fcsg`),
  KEY `fcsg02` (`fcm_desseg_fcsg`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfeunspscbfamil` table : 
#

DROP TABLE IF EXISTS `fcmfeunspscbfamil`;

CREATE TABLE `fcmfeunspscbfamil` (
  `fcm_codfam_fcfa` varchar(5) NOT NULL COMMENT 'Codigo clasificacion familia UNSPSC para el producto',
  `fcm_codseg_fcsg` varchar(3) DEFAULT NULL COMMENT 'Codigo clasificacion segmento de mercado UNSPSC para clasificacion base del producto',
  `fcm_desfam_fcfa` varchar(90) DEFAULT NULL COMMENT 'Descripcion familia UNSPSC para el producto',
  PRIMARY KEY (`fcm_codfam_fcfa`),
  KEY `fcfa02` (`fcm_codseg_fcsg`),
  KEY `fcfa03` (`fcm_desfam_fcfa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfeunspsccclase` table : 
#

DROP TABLE IF EXISTS `fcmfeunspsccclase`;

CREATE TABLE `fcmfeunspsccclase` (
  `fcm_codcla_fccl` varchar(7) NOT NULL COMMENT 'Codigo clases UNSPSC para el producto',
  `fcm_codseg_fcsg` varchar(3) DEFAULT NULL COMMENT 'Codigo claseificacion segmento de mercado UNSPSC para clasificacion base del producto',
  `fcm_codfam_fcfa` varchar(5) DEFAULT NULL COMMENT 'Codigo clasificacion familia UNSPSC para el producto',
  `fcm_descla_fccl` varchar(90) DEFAULT NULL COMMENT 'Descripcion clases UNSPSC para el producto',
  PRIMARY KEY (`fcm_codcla_fccl`),
  KEY `fccl03` (`fcm_codfam_fcfa`),
  KEY `fccl04` (`fcm_descla_fccl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfeunspscdprodu` table : 
#

DROP TABLE IF EXISTS `fcmfeunspscdprodu`;

CREATE TABLE `fcmfeunspscdprodu` (
  `fcm_codpro_fcpr` varchar(10) NOT NULL COMMENT 'Codigo Producto UNSPSC',
  `fcm_despro_fcpr` varchar(120) DEFAULT NULL COMMENT 'Descripcion UNSPSC para el producto',
  `sis_codume_sium` varchar(6) DEFAULT NULL COMMENT 'Código unidad de medida',
  `fcm_codseg_fcsg` varchar(3) DEFAULT NULL COMMENT 'Codigo claseificacion segmento de mercado UNSPSC para clasificacion base del producto',
  `fcm_codfam_fcfa` varchar(5) DEFAULT NULL COMMENT 'Codigo clasificacion familia UNSPSC para el producto',
  `fcm_codcla_fccl` varchar(7) DEFAULT NULL COMMENT 'Codigo clases UNSPSC para el producto',
  `fcm_estpro_fcpr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo  2= Inactivo',
  PRIMARY KEY (`fcm_codpro_fcpr`),
  KEY `fcpr03` (`fcm_codseg_fcsg`),
  KEY `fcpr05` (`fcm_codcla_fccl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmfrecuenciuso` table : 
#

DROP TABLE IF EXISTS `fcmfrecuenciuso`;

CREATE TABLE `fcmfrecuenciuso` (
  `fcm_idesec_fcfu` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del registro generado por el sistema',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial Admisión con con el cual se registro ultima prestacion del servicio',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS habilitado',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (pude ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `fcm_totuni_dfac` int(10) DEFAULT NULL COMMENT 'Sumatoria total de unidades facturadas del servicio',
  `fcm_fecser_dfac` date DEFAULT NULL COMMENT 'Fecha ultima prestacion del servicio (Viene del maestro detalles facturacion)',
  `fcm_fecpro_fcfu` date DEFAULT NULL COMMENT 'Fecha futura o proxima activacion para uso del servicio según frecuencia configurada en maestro de servicios IPS',
  `fcm_estaux_fcfu` varchar(10) DEFAULT NULL COMMENT 'Campo auxiliar para procesos de actualizacion y utilidades',
  `fcm_estreg_fcfu` varchar(1) DEFAULT NULL COMMENT 'Estado del Registro: 1=Activo 2=Inactivo',
  PRIMARY KEY (`fcm_idesec_fcfu`),
  KEY `fcfu02` (`sia_idesec_usua`),
  KEY `fcfu03` (`fcm_idesec_sips`),
  KEY `fcfu04` (`fcm_coddig_mant`),
  KEY `fcfu05` (`fcm_fecser_dfac`),
  KEY `fcfu06` (`fcm_fecpro_fcfu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmgrquirurgico` table : 
#

DROP TABLE IF EXISTS `fcmgrquirurgico`;

CREATE TABLE `fcmgrquirurgico` (
  `fcm_codgqx_grqx` varchar(3) NOT NULL DEFAULT '' COMMENT 'Identificador del Grupo quirurgico (para servicios a que aplique)según manual SOAT o ISS',
  `fcm_desgqx_grqx` varchar(60) DEFAULT NULL COMMENT 'Descripción grupo quirurgico (para servicios quirurgicos) según manual SOAT  ISS CUPS',
  `fcm_estser_grqx` varchar(1) DEFAULT NULL COMMENT 'Estado del Registro: 1=Activo 2=Inactivo',
  PRIMARY KEY (`fcm_codgqx_grqx`),
  KEY `grqx02` (`fcm_desgqx_grqx`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmmaedetallfac` table : 
#

DROP TABLE IF EXISTS `fcmmaedetallfac`;

CREATE TABLE `fcmmaedetallfac` (
  `fcm_secreg_dfac` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico del registro o servicio facturado , generado por el sistema',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admision o del registro de atencion ambulatoria',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificacion del usuario o Paciente  segun las normas vigentes para gestion de d atos ejm: CC= Cedula, RC= Rgistro Civil, TI = Tarjeta de Identidad  AS= Adulto sin idetificacion y otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Codigo de Eps o Asegurador segun codigos asignados por la supersalud',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Codigo de Empresa cliente y/o tercero EPS o asegurador segun modulos administrativos',
  `fcm_secreg_mfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico de la orden medica facturada (generado por el sistema)',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero de la factura generada en el cierre de facturacion',
  `fcm_tiprfa_mfac` varchar(1) DEFAULT NULL COMMENT 'Tipo registro factura generada: 1= Registro ordenes de servicios (pre factura) 2= Numero de Factura Valida Dian',
  `fcm_fecfac_mfac` date DEFAULT NULL COMMENT 'Fecha de la factura (fecha en que fue cerrada y generado el secuencial de factrua)',
  `fcm_estfac_mfac` varchar(1) DEFAULT NULL COMMENT 'Estado de la factura 1=Abierta 2=Cerrada 3=Anulada',
  `adm_nroaut_rgad` varchar(40) DEFAULT NULL COMMENT 'Numero Autorizacion solicitada a la EPS o Asegurador para adimision o servicio que requiera autorizacion',
  `sia_codrip_trip` varchar(2) DEFAULT NULL COMMENT 'Codigo clasificacion  servicio segun Resolucion 3374 RIPS: 01=Consulta 02= Procedimientos y mas',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS habilitado para referencia y validacion de pertinencia',
  `fcm_codbar_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo de Barras del Servicio suministro o medicamento (opcional)',
  `fcm_idesec_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo unico del servicio para venta con manual tarifario (generado por el sistema)',
  `fcm_codser_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo en tarifario del servicio para venta y RIPS, pude ser codigo SOAT ISS o CUPS',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (puede ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `con_codsco_ccos` varchar(6) DEFAULT NULL COMMENT 'Para identificar Servicios por centro de costos (desde contabilidad)',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo del centro de produccion donde se presta el servicio',
  `fcm_desser_dfac` varchar(250) DEFAULT NULL COMMENT 'Descripcion textual del servicio IPS',
  `fcm_codman_mans` varchar(3) DEFAULT NULL COMMENT 'Codigo del manual tarifario de servicios configurados para ventas ejm: M01=Manual SOAT para ventas  a particulares  M02=Manual SOAT para ventas contributivo (se todam desde el contrato)',
  `fcm_fecser_dfac` date DEFAULT NULL COMMENT 'Fecha de prestacion del servicio',
  `fcm_horser_dfac` decimal(5,2) DEFAULT NULL COMMENT 'Hora  digitacion del servicio en facturacion en formato militar',
  `fcm_perman_sips` varchar(1) DEFAULT NULL COMMENT 'Identificador  para saber si el codigo del servicio es Realmente del manual asignado (soat,iss,cups) o fue creado al azar (para tener presente en planos RIPS): 1=Pertenece al manual 2=Creado al azar o pertenece a otro manual',
  `far_codcum_famd` varchar(20) DEFAULT NULL COMMENT 'Codigo CUM del medicamento (clasificacion unica de medicamentos) con el cual fue facturado',
  `fcm_forfar_sips` varchar(20) DEFAULT NULL COMMENT 'Forma farmaceutica del medicamento (cuando el servicio sea un medicamento)',
  `fcm_conmed_sips` varchar(20) DEFAULT NULL COMMENT 'Concentracion del medicamento (cuando el servicio sea un medicamento)',
  `fcm_unimed_sips` varchar(20) DEFAULT NULL COMMENT 'Unidad medica del medicamento (cuando el servicio sea un medicamento)',
  `fcm_autdes_ades` varchar(20) DEFAULT NULL COMMENT 'Numero de autorizacion dada para realizar el descuento (dada desde adminstracion)',
  `fcm_valser_mant` float(17,2) DEFAULT NULL COMMENT 'Valor del servicio para venta segun manual tarifario',
  `fcm_totuni_dfac` int(10) DEFAULT NULL COMMENT 'Total de unidades facturadas del servicio',
  `fcm_valbru_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total  bruto facturado del servicio sin ninguna deduccion: FCM_VALSER_SIPS x FCM_TOTUNI_DFAC',
  `fcm_pordes_dfac` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de descuento aplicada (cuando el descuento se haya calculado en porcentaje)',
  `fcm_valdes_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del descuento realizado al cliente',
  `fcm_poriva_dfac` float(6,2) DEFAULT NULL COMMENT 'Porcentaje del IVA aplicado al servicio',
  `fcm_valiva_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del IVA recuadado en la factura',
  `fcm_valcpa_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del copago recudado en el srvicio como tal, suma en factura',
  `fcm_valcmo_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total de cuota moderadora recudada en servico y suma en la factura',
  `fcm_valusu_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor cargo al usuario, cobrado al paciente por porcentajes no cubiertos en el seguro',
  `fcm_valcom_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor comision',
  `fcm_valsub_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor subtotal del servicio facturado haciendo deducciones: FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VALDES_DFAC)',
  `fcm_valfac_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del servicio facturado incluyendo el IVA  y con las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DFAC+FCM_VALCOM_DFAC',
  `fcm_valref_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor recuadado en efectivo (solo valor cobrado en efectivo) por cobros de copagos o valor total del servicio (no siempre representa el valor total del servicio)',
  `fcm_valefe_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor final recuadado en efectivo con el descuento realizado ',
  `fcm_codtse_sips` varchar(1) DEFAULT NULL COMMENT 'Codigo tipo procedimiento o servicio:  1=Procedimiento  No Quirurgico 2= Procedimiento  Quirurgico 3=Paquete de servicios 4=No procedimientos',
  `fcm_codaqx_aqir` varchar(1) DEFAULT NULL COMMENT 'Codigo forma de realizacion del acto quirurgico (cuando aplique) ejm: 1=Unico 2=Bilateral misma via y otros',
  `sia_tipact_tsac` varchar(1) DEFAULT NULL COMMENT 'Tipo servicio o actividad segun manual de servicio IPS: 1=Asistencial 2=Promocion y Prevencion 3=Salud Publica 4=Todas',
  `adm_codtat_tatn` varchar(1) DEFAULT NULL COMMENT 'Codigo Tipo de Atencion o ambito del servicio:1=Ambulatoria 2=Hospitalizacion 3=Urgencia',
  `sia_codfpr_fpor` varchar(1) DEFAULT NULL COMMENT 'Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Diagnostico 2=Terapeutico 3=Proteccion Especifica 4=Deteccion temprana de Enfermedad General 5=Deteccion especifica de Enfermedad Profesional segun Resolucion 3374 RIPS',
  `sia_codfco_fcon` varchar(2) DEFAULT NULL COMMENT 'Finalidad de la consulta:01=Atencion del Parto',
  `adm_codcex_tcex` varchar(2) DEFAULT NULL COMMENT 'Causa Externa Origen que origina la atencion segun Resolucion: 3374 RIPS',
  `sia_coddia_tdia` varchar(4) DEFAULT NULL COMMENT 'Codigo del diagnostico principal (para Rips AP o AC cuando sea requerido)  segun la CIE 10, desde la tabla maestra de diagnosticos',
  `sia_tipdxp_tdix` varchar(1) DEFAULT NULL COMMENT 'Tipo de diagnostico segun CIE 10: 1=impresion diagnostica 2=Confirmado nuevo y otros',
  `sia_coddx1_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 1 desde tabla CIE 10',
  `sia_coddx2_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 2 desde tabla CIE 10',
  `sia_coddx3_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico relacionado 3 desde tabla CIE 10',
  `sia_coddxc_tdia` varchar(4) DEFAULT NULL COMMENT 'Diagnostico de la complizacion segun tabla CIE10',
  `sia_codgac_gpyp` varchar(3) DEFAULT NULL COMMENT 'Grupo de actividades de PyP para generar estadisticas y cumplimiento en metas  segun resolucion 0412',
  `sia_codact_apyp` varchar(3) DEFAULT NULL COMMENT 'actividades de PyP para generar estadisticas y cumplimiento en metas  segun resolucion 0412',
  `fcm_serpos_sips` varchar(1) DEFAULT NULL COMMENT 'Saber si el servicio esta dentro del POS: 1=SI 2=NO',
  `cto_tipact_cont` varchar(1) DEFAULT NULL COMMENT 'Tipo de actividades o servicios que cubre el contrato: 1=Asistenciales 2= Promocion y Prevencion 3=Salud Publica 4 =Todas',
  `sia_codpat_tpat` varchar(1) DEFAULT NULL COMMENT 'Tipo de profesional que atiende el servicio segun resolucion 3374 RIPS: 1=Medico  2= Enfermera y otros',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Codigo del Profesional que presta servicio medico',
  `fac_horprs_dfac` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que recibe la prestacion del servicio (lo atiende el profesional) en formato militar  (HH) ejm: 16',
  `fcm_atepro_dfac` varchar(1) DEFAULT NULL COMMENT 'Para confirmar si el servicio ya fue antendido por el profesional o esta pendiente para ser realizado 1= Servicio pendiente para profesional 2= Servicio atendido por profesional',
  `sia_aresol_aser` varchar(3) DEFAULT NULL COMMENT 'Codigo area que solicita el servicio',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Codigo area donde se presta el servicio',
  `fcm_tipser_sips` varchar(1) DEFAULT NULL COMMENT 'Para diferencia servicios de  medicamentos  y materiales:  1=Servicio 2=Suministro',
  `fcm_fecedt_dfac` date DEFAULT NULL COMMENT 'Fecha ultima modificacion realizada por un usario o facturador',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Codigo del factuador  usuario del sistema que que realiza la ultima modificacion',
  `fcm_otserv_sips` varchar(1) DEFAULT NULL COMMENT 'Tipo Rips otros servicios: 1= Materiales e Insumos 2= Traslados 3= Estancia 4 = Honorarios',
  `sia_regate_rgat` varchar(1) DEFAULT NULL COMMENT 'Tipo Registro  de Atencion: 1 = Admitidos 2=Ambulatoria 3=PyP-Hospitalario 4=PyP-Extramural',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atencion  cuando hay varias sedes',
  `fcm_ripsco_dfac` varchar(1) DEFAULT NULL COMMENT 'Marca para saber si los datos del RIPS fueron completados por el profesional en la atencion medica: 1=Sin completar 2= Rips completados',
  `far_nroreg_fads` varchar(20) DEFAULT NULL COMMENT 'Código secuencial registro detalle desde modulo farmacia cuando no aplica debe contener el valor NA',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Codigo del almacen (desde inventario) desde el cual se descargan los suministros facturados (cuando aplique segun tipo servicio y el contrato)',
  `inv_secart_inar` varchar(20) DEFAULT NULL COMMENT 'Codigo unico del articulo relacionado con el inventario generado por el sistema  NA cuando no aplica',
  `inv_codaux_inar` varchar(20) DEFAULT NULL COMMENT 'Código Auxiliar de digitacion del articulo',
  `inv_codgme_mgme` varchar(2) DEFAULT NULL COMMENT 'Patron Unidad de Medida (Masa, Volumen, etc) Viene del  almacen de donde se tome, desde el maestro grupos de medidas',
  `inv_coduma_muma` varchar(2) DEFAULT NULL COMMENT 'Unidad de medida para descargar desde  almacen (litros, gramos, centilitros) Viene del Almacen de donde se tome',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro segun estado de la admision: 1=Abierto 2=Cerrado 3=Anulado',
  PRIMARY KEY (`fcm_secreg_dfac`),
  KEY `dfac02` (`fcm_numfac_mfac`),
  KEY `dfac03` (`adm_secadm_rgad`),
  KEY `dfac04` (`sia_idesec_usua`),
  KEY `dfac05` (`sia_nroide_usua`),
  KEY `dfac06` (`cto_seccon_cont`),
  KEY `dfac07` (`sia_codeps_teps`),
  KEY `dfac08` (`sis_idterc_sitr`),
  KEY `dfac09` (`fcm_desser_dfac`),
  KEY `dfac10` (`far_nroreg_fads`),
  KEY `dfac11` (`fcm_codcpr_cpro`),
  KEY `dfac12` (`fcm_fecser_dfac`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmmaescajadeta` table : 
#

DROP TABLE IF EXISTS `fcmmaescajadeta`;

CREATE TABLE `fcmmaescajadeta` (
  `fcm_codrca_rcad` varchar(15) NOT NULL COMMENT 'Codgio del recibo de caja  generado por el sistema',
  `fcm_codtra_mtrc` varchar(10) DEFAULT NULL COMMENT 'Codgio del recibo de caja  generado por el sistema',
  `fcm_secreg_mfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico de la orden medica facturada (generado por el sistema)',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero de la factura generada en la confirmación de facturas',
  `fcm_desser_sips` varchar(250) DEFAULT NULL COMMENT 'Descripción textual de lso servicios IPS  que son cobrados',
  `fcm_valref_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor recuadado en efectivo (solo valor cobrado en efectivo) por cobros de copagos o valor total del servicio (no siempre representa el valor total del servicio)',
  `fcm_pordes_dfac` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de descuento aplicada (cuando el descuento se haya calculado en porcentaje)',
  `fcm_valdes_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del descuento realizado al cliente',
  `fcm_valefe_dfac` float(17,3) DEFAULT NULL COMMENT 'Valor final recuadado en efectivo con el descuento realizado',
  `fcm_tippag_rcad` varchar(90) DEFAULT NULL COMMENT 'Tipo pago en efectivo textual asi: VALOR-SERVICIO,  COPAGO, CUOTA-MODERADORA, CARGO-USUARIO y OTROS',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Codigo de Empresa cliente/tercero EPS o asegurador según modulos adminstrativos',
  `fcm_estreg_rcad` varchar(1) DEFAULT NULL COMMENT 'Estado del recibo:  2=Confirmado 3=Anulado',
  PRIMARY KEY (`fcm_codrca_rcad`),
  KEY `rcad02` (`fcm_codtra_mtrc`),
  KEY `rcad04` (`fcm_desser_sips`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmmaescajatran` table : 
#

DROP TABLE IF EXISTS `fcmmaescajatran`;

CREATE TABLE `fcmmaescajatran` (
  `fcm_codtra_mtrc` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codgio del recibo de caja  generado por el sistema',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente o usuario que realiza el pago',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero factura generada puede ser tambien un consecutivo Dian para el recibo de caja',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `fcm_autdes_ades` varchar(10) DEFAULT NULL COMMENT 'Numero de autorizacion del descuento aprobado para el momento del pago (cuando aplique)',
  `fcm_descon_mtrc` varchar(150) DEFAULT NULL COMMENT 'descripción del concepto o pago por el cual se dio el recibo de caja',
  `fcm_rfecha_mtrc` date DEFAULT NULL COMMENT 'Fecha del recibo de caja',
  `fcm_rehora_mtrc` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que se genero el recibo, hora en formato 12 ejem: 10:25:AM',
  `fcm_tipefe_mtrc` char(20) DEFAULT NULL COMMENT 'tipo de efectivo utlizado par el pago: efectivo, tarjeta,cheque,efectivo-y-tarjeta,efectivo-y-cheque,cheque-y-tarjeta',
  `fcm_valref_dfac` float(17,3) DEFAULT NULL COMMENT 'Valor a recaudar en efectivo sin el descuento (solo valor cobrado en efectivo) por cobros de copagos o valor total del servicio (no siempre representa el valor total del servicio)',
  `fcm_valdes_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del descuento realizado al cliente cuando exista',
  `fcm_valefe_mtrc` int(12) DEFAULT NULL COMMENT 'Efectivo (Billete) presentado en ventanilla por el cliente, de este se hara la deduccion del pago',
  `fcm_valcam_mtrc` int(12) DEFAULT NULL COMMENT 'Valor del cambio cuando despues de la transaccion se debe un valor cambio: FCM_VALCAM_MTRC=FCM_VALEFE_MTRC-FCM_VALPAG_MTRC',
  `fcm_valefe_dfac` float(17,3) DEFAULT NULL COMMENT 'Valor pagado en efectivo correspondiente al servicio, con el descuento',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atencion  cuando hay varias sedes',
  `fcm_secdet_mtrc` int(10) DEFAULT NULL COMMENT 'Campo para generar el secuencial de los registros detalles de la transaccion',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del Digitador Usuario del sistema que diligencia el registro de atencion o admision',
  `sis_estreg_mtrc` varchar(1) DEFAULT NULL COMMENT 'Estado  del recibo:  2=Confirmado 3=Anulado',
  PRIMARY KEY (`fcm_codtra_mtrc`),
  KEY `mtrc02` (`fcm_descon_mtrc`),
  KEY `mtrc03` (`adm_secadm_rgad`),
  KEY `mtrc04` (`sia_idesec_usua`),
  KEY `mtrc05` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmmaesfacturas` table : 
#

DROP TABLE IF EXISTS `fcmmaesfacturas`;

CREATE TABLE `fcmmaesfacturas` (
  `fcm_secreg_mfac` varchar(20) NOT NULL COMMENT 'Secuencial unico de la orden medica facturada (generado por el sistema)',
  `fcm_numfac_mfac` varchar(20) DEFAULT NULL COMMENT 'Numero de la factura generada en el cierre de facturación',
  `fcm_typdoc_fctd` varchar(3) DEFAULT NULL COMMENT 'Tipos de documentos para envio a Dian: 01=Factura electrónica de Venta 02=Factura electrónica venta-xportación 91=Nota Credito 92=Nota Debito y otros',
  `fcm_secraz_fcem` varchar(10) DEFAULT NULL COMMENT 'Codigo unico Razon Social empresa para gestion documentos DIAN',
  `fcm_secres_srfa` varchar(10) DEFAULT NULL COMMENT 'Secuencial unico de la resolución Dian en el sistema (generado por el sistema), cuando aplique',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión o del registro de atencion ambulatoria',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificacion del usuario o Paciente  según las normas vigentes para gestion de d atos ejm: CC= Cedula, RC= Rgistro Civil, TI = Tarjeta de Identidad  AS= Adulto sin idetificacion y otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Codigo de Eps o Asegurador según codigos asignados por la supersalud',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Código de Empresa cliente y/o tercero EPS o asegurador según módulos administrativos',
  `fcm_fecfac_mfac` date DEFAULT NULL COMMENT 'Fecha de la factura (fecha en que fue cerrada y generado el secuencial de factrua)',
  `fcm_diavfa_mfac` int(5) DEFAULT NULL COMMENT 'Numero de dias para vigencia de factura de venta el sistema realiza el calculo del dia final',
  `fcm_horfac_mfac` decimal(5,2) DEFAULT NULL COMMENT 'Hora emision de la factura',
  `fcm_metpag_mfac` varchar(1) DEFAULT NULL COMMENT 'Metodo de pago 1=Contado 2=Credito',
  `fcm_codmpg_fcmp` varchar(7) DEFAULT NULL COMMENT 'FAN02: Codigo secuencial medios de pago según  cuadro  No: 6.3.4.2 - Medios de Pago: cbc:PaymentMeansCode : 1=Medio no definido  hasta … ZZZ=Acuerdo mutuo',
  `fcm_fecven_mfac` date DEFAULT NULL COMMENT 'Fecha vencimiento factura contada desde el momento que fue  generado el secuencial factrua Dian',
  `fcm_codest_fcws` varchar(3) DEFAULT NULL COMMENT 'Estado gestion WS Dian: R01=Enviada y aceptada con Éxito R02=Enviada con errores en validacion C01=El Servicio Dian no respondio /... Otros',
  `fcm_autdes_ades` varchar(10) DEFAULT NULL COMMENT 'Numero de autorizacion  del descuento aprobado para el momento del pago (generado por el sistema dada por un usuario autorizado)',
  `fcm_valbru_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total  bruto facturado del servicio sin ninguna deducción: FCM_VALSER_SIPS x FCM_TOTUNI_DFAC',
  `fcm_valbsi_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor de la base Imponible (base para el calculo de impuesto)',
  `fcm_pordes_dfac` float(6,2) DEFAULT NULL COMMENT 'Porcentaje de descuento aplicada (cuando el descuento se haya calculado en porcentaje)',
  `fcm_valdes_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del descuento realizado al cliente',
  `fcm_poriva_dfac` float(6,2) DEFAULT NULL COMMENT 'Porcentaje del IVA aplicado al servicio',
  `fcm_valiva_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del IVA recuadado en la factura',
  `fcm_valcpa_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del copago recudado en el srvicio como tal, suma en factura',
  `fcm_valcmo_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total de cuota moderadora recudada en servico y suma en la factura',
  `fcm_valusu_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor cargo al usuario, cobrado al paciente por porcentajes no cubiertos en el seguro',
  `fcm_valcom_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor comision',
  `fcm_valsub_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor subtotal del servicio facturado haciendo deducciones: FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VALDES_DFAC)',
  `fcm_valfac_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor total del servicio facturado incluyendo el IVA  y con las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DFAC+FCM_VALCOM_DFAC',
  `fcm_valref_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor recuadado en efectivo (solo valor cobrado en efectivo) por cobros de copagos o valor total del servicio (no siempre representa el valor total del servicio)',
  `fcm_valefe_dfac` float(17,2) DEFAULT NULL COMMENT 'Valor final recuadado en efectivo con el descuento realizado',
  `fcm_fecedt_mfac` date DEFAULT NULL COMMENT 'Fecha ultima modificacion realizada por un usario o facturador',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del factuador  usuario del sistema que que realiza la ultima modificacion',
  `fcm_tiprfa_mfac` varchar(1) DEFAULT NULL COMMENT 'Tipo registro factura generada: 1= Registro ordenes de servicios  (pre factura) 2= Numero de Factura Valida Dian',
  `sia_tipact_tsac` varchar(1) DEFAULT NULL COMMENT 'Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial 2=Promocion y Prevencion 3=Salud Publica 4=Todas',
  `sia_regate_rgat` varchar(1) DEFAULT NULL COMMENT 'Tipo Registro  de Atencion: 1 = Admitidos 2=Ambulatoria 3=PyP-Hospitalario 4=PyP-Extramural',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atencion  cuando hay varias sedes',
  `fcm_fecanu_mfac` date DEFAULT NULL COMMENT 'Fecha en que la cual se anulo la factura confirmada (estado 2)',
  `fcm_horanu_mfac` decimal(5,2) DEFAULT NULL COMMENT 'Hora en la cual fue anulada la factura',
  `sys_usuanu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del factuador  usuario del sistema que que anula',
  `fcm_notanu_mfac` varchar(200) DEFAULT NULL COMMENT 'Motivo textual por el cual se anula la factura',
  `fcm_estfac_mfac` varchar(1) DEFAULT NULL COMMENT 'Estado de la factura 1=Abierta 2=Cerrada 3=Anulada',
  PRIMARY KEY (`fcm_secreg_mfac`),
  KEY `mfac02` (`fcm_numfac_mfac`),
  KEY `mfac03` (`adm_secadm_rgad`),
  KEY `mfac04` (`sia_idesec_usua`),
  KEY `mfac05` (`sia_nroide_usua`),
  KEY `mfac06` (`cto_seccon_cont`),
  KEY `mfac07` (`sia_codeps_teps`),
  KEY `mfac08` (`sis_idterc_sitr`),
  KEY `mfac09` (`fcm_secres_srfa`),
  KEY `mfac10` (`fcm_codest_fcws`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmmansercompaq` table : 
#

DROP TABLE IF EXISTS `fcmmansercompaq`;

CREATE TABLE `fcmmansercompaq` (
  `fcm_idesec_copq` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del servicio generado por el sistema',
  `fcm_idesec_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio para venta con manual tarifario (generado por el sistema)',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS habilitado',
  `fcm_numuni_copq` int(6) DEFAULT NULL COMMENT 'Total unidades del servicio que se incluyen el paquete',
  `fcm_estser_copq` varchar(1) DEFAULT NULL COMMENT 'Estado del servicio dentro del paquete: 1=Activo 2=Inactivo',
  PRIMARY KEY (`fcm_idesec_copq`),
  KEY `copq02` (`fcm_idesec_mant`),
  KEY `copq03` (`fcm_idesec_sips`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmmanservicate` table : 
#

DROP TABLE IF EXISTS `fcmmanservicate`;

CREATE TABLE `fcmmanservicate` (
  `fcm_idesec_fcct` varchar(5) NOT NULL COMMENT 'Codigo unico secuencial del registro generado por el sistema',
  `fcm_descat_fcct` varchar(80) DEFAULT NULL COMMENT 'Descripcion Categoria de servicios IPS',
  PRIMARY KEY (`fcm_idesec_fcct`),
  KEY `fcct02` (`fcm_descat_fcct`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmmanservicios` table : 
#

DROP TABLE IF EXISTS `fcmmanservicios`;

CREATE TABLE `fcmmanservicios` (
  `fcm_idesec_mant` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del servicio para venta con manual tarifario (generado por el sistema)',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS habilitado',
  `fcm_codman_mans` varchar(3) DEFAULT NULL COMMENT 'Codigo del manual tarifario de servicios configurados para ventas ejm: M01=Manual SOAT para ventas  a particulares  M02=Manual SOAT para ventas contributivo',
  `fcm_codbar_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo de Barras del Servicio suministro o medicamento (opcional)',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (pude ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `fcm_codser_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo en tarifario del servicio para venta y RIPS, pude ser codigo SOAT ISS o CUPS (es modificable en configuracion)',
  `fcm_desser_mant` varchar(250) DEFAULT NULL COMMENT 'Descripcion textual del servicio en el manual de venta',
  `fcm_valser_mant` float(17,2) DEFAULT NULL COMMENT 'Valor del servicio para venta',
  `fcm_punuvr_mant` float(12,6) DEFAULT NULL COMMENT 'Puntajes o UVR segun manual SOAT o ISS para calcular valor servicios con base en salarios minimos vigentes',
  `fcm_valren_mant` int(14) DEFAULT NULL COMMENT 'Valor del recargo nocturno (cuando aplique)',
  `fcm_fecinv_mant` date DEFAULT NULL COMMENT 'Fecha en la cual inicia vigencia el servicio (cuando no hay fechas no aplica)',
  `fcm_fecfiv_mant` date DEFAULT NULL COMMENT 'Fecha en la cual finaliza vigencia el servicio (cuando no hay fechas no aplica)',
  `fcm_tipccp_mant` varchar(1) DEFAULT NULL COMMENT 'Tipo Liquidacion copago o cuota moderadora 1=Liquidado 2= Valor fijo',
  `fcm_vficop_mant` int(12) DEFAULT NULL COMMENT 'Valor del copago o cuota moderadora cuando es fijo',
  `fcm_facpln_mant` varchar(1) DEFAULT NULL COMMENT 'Permitir recalcular segun porcentajes y cubrimientos del contrato: 1=Permitir recalcular según contrato 2=Cobrar Tarifa plena',
  `fcm_facvmc_mant` varchar(1) DEFAULT NULL COMMENT 'Verificacion para permitir valores de servicios en cero: 1=No permitir valores en cero 2=Permitir valores en cero',
  `fcm_perman_mant` varchar(1) DEFAULT NULL COMMENT 'Identificador  para saber si el codigo del servicio es Realmente del manual asignado (soat,iss,cups) o fue creado al azar (para tener presente en planos RIPS): 1=Pertenece al manual 2=Creado al azar o pertenece a otro manual',
  `fcm_alcamb_mant` varchar(1) DEFAULT NULL COMMENT 'Alcance del servicio en ambulatoria: 1= Es Pos 2= No es pos',
  `fcm_alcurg_mant` varchar(1) DEFAULT NULL COMMENT 'Alcance del servicio en urgencia: 1= Es Pos 2= No es pos',
  `fcm_alchos_mant` varchar(1) DEFAULT NULL COMMENT 'Alcance del servicio en Hospitalizacion: 1= Es Pos 2= No es pos',
  `fcm_aplfus_sips` varchar(1) DEFAULT NULL COMMENT 'Aplicar frecuencia de uso al servicio: 1=SI 2=NO',
  `fcm_estser_mant` varchar(1) DEFAULT NULL COMMENT 'Estado del servicio dentro la IPS: 1=Activo 2=Inactivo',
  PRIMARY KEY (`fcm_idesec_mant`),
  KEY `mant02` (`fcm_idesec_sips`),
  KEY `mant03` (`fcm_codman_mans`),
  KEY `mant04` (`fcm_codbar_sips`),
  KEY `mant05` (`fcm_desser_mant`),
  KEY `mant06` (`fcm_coddig_mant`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmmanservicips` table : 
#

DROP TABLE IF EXISTS `fcmmanservicips`;

CREATE TABLE `fcmmanservicips` (
  `fcm_idesec_sips` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del servicio IPS habilitado (generado por el sistema)',
  `fcm_codser_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo del servicio para venta y RIPS, pude ser codigo SOAT ISS o CUPS (es modificable en configuración)',
  `fcm_codser_soat` varchar(20) DEFAULT NULL COMMENT 'Codigo SOAT del servicio para gestion de actualizacion de precios',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (pude ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `fcm_codbar_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo de Barras del Servicio suministro o medicamento (opcional)',
  `fcm_codcum_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo CUM del medicamento',
  `fcm_idesec_fcct` varchar(5) DEFAULT NULL COMMENT 'Codigo categegoria del servicio IPS',
  `fcm_desser_sips` varchar(250) DEFAULT NULL COMMENT 'Descripción textual del servicio IPS',
  `fcm_codtse_sips` varchar(1) DEFAULT NULL COMMENT 'Código tipo procedimiento o servicio:  1=Procedimiento  No Quirúrgico 2= Procedimiento  Quirúrgico 3=Paquete de servicios 4=No procedimientos',
  `fcm_claser_sips` varchar(1) DEFAULT NULL COMMENT 'Clasificacion del servicio cuando hace parte de un paquete o procedimiento quirurgico: 1=Ninguno 2=Cirujano 3=Anestesiólogo 4=Ayudante 5=derecho de Sala 6=materiales e Insumos 7=Instrumentador  Quirúrgico',
  `fcm_codgqx_grqx` varchar(3) DEFAULT NULL COMMENT 'Grupo quirurgico (para procedimientos quirurgicos)según manual SOAT o ISS',
  `fcm_punuvr_sips` float(12,6) DEFAULT NULL COMMENT 'Puntajes o UVR según manual SOAT o ISS para calcular valor servicios con base en salarios minimos vigentes',
  `fcm_valser_sips` float(17,2) DEFAULT NULL COMMENT 'Valor del servicio para venta',
  `fcm_edtval_sips` varchar(1) DEFAULT NULL COMMENT 'Editar el valor del servicio en la vista de factruacion sin tener en cuenta proceso de liquidacion del tarifario: 1=SI 2=No',
  `fcm_liqval_sips` varchar(1) DEFAULT NULL COMMENT 'Si liquidar valor servicio ejecutando liquidacion con Puntaje: 1=Liquidar con puntaje 2=Facturar con solo valor dado (no liquidar)',
  `fcm_lamccp_sips` varchar(1) DEFAULT NULL COMMENT 'Liquidar copagos o cuotas moderadoras en atencion ambulatoria: 1=Copago 2=Cuota Moderadora  3=Copago y C.Moderadora   4=Ninguna',
  `fcm_lhoccp_sips` varchar(1) DEFAULT NULL COMMENT 'Liquidar copagos o cuotas moderadoras en atencion hospitalizacion: 1=Copago 2=Cuota Moderadora 3=Copago y C.Moderadora   4=Ninguna',
  `fcm_luoccp_sips` varchar(1) DEFAULT NULL COMMENT 'Liquidar copagos o cuotas moderadoras en atencion urgencias: 1=Copago 2=Cuota Moderadora  3=Copago y C.Moderadora   4=Ninguna',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo del centro de producción al cual esta asociado el servicio por defecto',
  `sia_codfpr_fpro` varchar(1) DEFAULT NULL COMMENT 'Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Diagnostico 2=Terapéutico 3=Protección Especifica 4=Detección temprana de Enfermedad General 5=Detección especifica de Enfermedad Profesional según Resolucion 3374 RIPS',
  `sia_codfco_fcon` varchar(2) DEFAULT NULL COMMENT 'Finalidad de la consulta: 01=Atención del Parto 02=Atencion del Recien Nacido y demas según Resolucion 3374RIPS',
  `adm_codcex_tcex` varchar(2) DEFAULT NULL COMMENT 'Causa Externa Origen que origina la atención según Resolución: 3374 RIPS',
  `fcm_mededi_sips` varchar(1) DEFAULT NULL COMMENT 'Medida edad inicial a la cual aplica el servicio, para validación pertinencia: 1=Años 2=Meses 3=Días',
  `fcm_edaini_sips` int(6) DEFAULT NULL COMMENT 'Edad inicial para la cual aplica la validación de pertinencia',
  `fcm_mededf_sips` varchar(1) DEFAULT NULL COMMENT 'Medida edad fina a la cual aplica el servicio, para validación pertinencia:1=Años 2=Meses 3=Días',
  `fcm_edafin_sips` int(6) DEFAULT NULL COMMENT 'Edad final para la cual aplica la validación de pertinencia',
  `fcm_mededp_sips` varchar(1) DEFAULT NULL COMMENT 'Medida edad puntual la cual aplica el servicio, para validación pertinencia:1=Años 2=Meses 3=Días,4=No Aplica edad puntual',
  `fcm_edapun_sips` varchar(240) DEFAULT NULL COMMENT 'Edad puntal para la cual aplica la validación de pertinencia, separados por punto y coma (;) , Adulto mayor ejemplo: 45;50;55;60;65;70+ (el signo mas es para el resto de 70 en adelante)',
  `fcm_sexapl_sips` varchar(1) DEFAULT NULL COMMENT 'Sexo al cual aplica el servicio:1=Masculino 2=Femenino 3=Ambos',
  `fcm_nivcom_sips` varchar(1) DEFAULT NULL COMMENT 'Nivel de complejidad del servicio: 1,2,3,4 5,y 6',
  `sia_codrip_trip` varchar(2) DEFAULT NULL COMMENT 'Codigo clasificacion  servicio según Resolucion 3374 RIPS: 01=Consulta 02= Procedimientos y mas',
  `fcm_semeps_sips` int(6) DEFAULT NULL COMMENT 'Semanas minimas cotizadas en la EPS para acceder al servicio',
  `fcm_semsss_sips` int(6) DEFAULT NULL COMMENT 'Semanas minimas cotizadas en SSS para acceder al servicio',
  `fcm_aplfus_sips` varchar(1) DEFAULT NULL COMMENT 'Aplicar frecuencia de uso al servicio: 1=SI 2=NO',
  `fcm_intser_sips` int(6) DEFAULT NULL COMMENT 'Intervalo en dias para la nueva orden del servicio ejm: cada 15 o 3 dias , cada 90 dias es decir intser= 15 intser=30 intser=90',
  `fcm_perfus_sips` varchar(1) DEFAULT NULL COMMENT 'Periodo en el que aplicar frecuencia de uso servicio: 1=Aplica el corte en año calendario 2=Hasta que se cumpla la Fecha nueva de uso',
  `fcm_maxord_sips` int(4) DEFAULT NULL COMMENT 'Cantidad maxima por orden en un registro de facturacion del servicio o suministro',
  `fcm_maxint_sips` int(4) DEFAULT NULL COMMENT 'Cantidad maxima dentro del intervalo de dias ejm: en 90 dias solo se pude facturar 150 unidades es decir canmax= 150',
  `sis_codiva_tiva` varchar(2) DEFAULT NULL COMMENT 'Codigo del porcentaje de Iva que se aplicara al servicio',
  `sia_tipact_tsac` varchar(1) DEFAULT NULL COMMENT 'Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial 2=Promocion y Prevencion',
  `fcm_otserv_sips` varchar(1) DEFAULT NULL COMMENT 'Tipo rips otros servicios: 1= Materiales e Insumos 2= Traslados 3= Estancia 4 = Honorarios',
  `fcm_forfar_sips` varchar(20) DEFAULT NULL COMMENT 'Forma farmaceutica del medicamento (cuando el servicio sea un medicamento)',
  `fcm_conmed_sips` varchar(20) DEFAULT NULL COMMENT 'Concentración del medicamento (cuando el servicio sea un medicamento)',
  `fcm_unimed_sips` varchar(20) DEFAULT NULL COMMENT 'Unidad medica del medicamento (cuando el servicio sea un medicamento)',
  `far_grufar_fagf` varchar(3) DEFAULT NULL COMMENT 'Grupo farmacologico cuando el articulos es un medicamento, NA Cuando no no aplique',
  `far_sugfar_fasg` varchar(5) DEFAULT NULL COMMENT 'Subgrupo farmacologico del medicamento, NA cuando no aplique',
  `sia_codpat_tpat` varchar(1) DEFAULT NULL COMMENT 'Tipo de profesional que atiende el servicio según resolucion 3374 RIPS: 1=Medico  2= Enfermera y otros',
  `fcm_serpos_sips` varchar(1) DEFAULT NULL COMMENT 'Saber si el servicio esta dentro del POS: 1=SI 2=NO',
  `fcm_tipser_sips` varchar(1) DEFAULT NULL COMMENT 'Para diferencia servicios de  medicamentos  y materiales:  1=Servicio 2=Suministro',
  `fcm_numuni_sips` int(17) DEFAULT NULL COMMENT 'Numero de unidades descargadas desd almacen',
  `ssp_codcam_resc` varchar(15) DEFAULT NULL COMMENT 'Campo o nombre al cual aplica para informe 4505  (ejemplo: SSP_CAM025_SPRO)',
  `ssp_tipval_resc` varchar(1) DEFAULT NULL COMMENT 'Tipo de valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico',
  `ssp_camdig_resc` varchar(1) DEFAULT NULL COMMENT 'Campo digitable: 1=Si 2=No',
  `ssp_valper_resc` varchar(240) DEFAULT NULL COMMENT 'Valore permitido o reportado al momento de facturar el servicio (cuando es digitable debe estar vacio)',
  `fcm_genhis_sips` varchar(1) DEFAULT NULL COMMENT 'Generar registro para actividad en historia clinica del paciente al facturar: 1=Si 2=NO',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo formato plantilla historia clinica asociada al programa o centro de produccion para generar registro actividad en historia clinica',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad medica ejemplo: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia y otras',
  `sia_coddia_tdia` varchar(10) DEFAULT NULL COMMENT 'Codgo del diagnostico según la tabla CIE-10',
  `sia_tipdxp_tdix` varchar(1) DEFAULT NULL COMMENT 'Tipo diagnostico principal: segun CIE 10: 1=impresion diagnostica 2=Confirmado nuevo 3=Confirmado repetido',
  `fcm_coddia_sips` varchar(240) DEFAULT NULL COMMENT 'Lista de diagnosticos CIE -10 permitidos, separados por punto y coma (;) para validacion en prestacion de servicios y  Gestion foramtos de Historias clinicas',
  `fcm_codpro_fcpr` varchar(10) DEFAULT NULL COMMENT 'Codigo UNSPSC Estandar de Productos y Servicios de Naciones Unidas',
  `fcm_estser_sips` varchar(1) DEFAULT NULL COMMENT 'Estado del servicio dentro la IPS: 1=Activo 2=Inactivo',
  PRIMARY KEY (`fcm_idesec_sips`),
  KEY `sips02` (`fcm_codser_sips`),
  KEY `sips03` (`fcm_coddig_mant`),
  KEY `sips04` (`fcm_codbar_sips`),
  KEY `sips05` (`fcm_desser_sips`),
  KEY `sips06` (`far_grufar_fagf`),
  KEY `sips07` (`far_sugfar_fasg`),
  KEY `sips08` (`sia_coddia_tdia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmmantarifario` table : 
#

DROP TABLE IF EXISTS `fcmmantarifario`;

CREATE TABLE `fcmmantarifario` (
  `fcm_codman_mans` varchar(3) NOT NULL DEFAULT '' COMMENT 'Codigo del manual tarifario de servicios configurados para ventas ejm: M01=Manual SOAT para ventas  a particulares  M02=Manual SOAT para ventas contributivo',
  `fcm_codtar_ttar` varchar(1) DEFAULT NULL COMMENT 'Codigo tipo manual tarifario: 1=SOAT 2=ISS 3=CUPS',
  `fcm_desman_mans` varchar(50) DEFAULT NULL COMMENT 'Descripcion manual tarifario',
  `fcm_conser_mans` int(6) DEFAULT NULL COMMENT 'Contador para generar registros detalles del manual de servicios',
  `fcm_estman_mans` varchar(1) DEFAULT NULL COMMENT 'Estado del maual de servicios: 1= Activo  2= Inactivo',
  PRIMARY KEY (`fcm_codman_mans`),
  KEY `mans02` (`fcm_desman_mans`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmsecrfacturas` table : 
#

DROP TABLE IF EXISTS `fcmsecrfacturas`;

CREATE TABLE `fcmsecrfacturas` (
  `fcm_secres_srfa` varchar(10) NOT NULL DEFAULT '' COMMENT 'Secuencial unico de la resolución Dian en el sistema (generado por el sistema)',
  `fcm_numres_srfa` varchar(20) DEFAULT NULL COMMENT 'Numero de la resolucion Dian',
  `fcm_desres_srfa` varchar(40) DEFAULT NULL COMMENT 'Descripcion o nota  de la resolucion Dian',
  `fcm_notenc_srfa` text COMMENT 'Nota para el encabezado de pagina en factura impresa',
  `fcm_noppag_srfa` text COMMENT 'Nota para el pie de pagina en factura impresa',
  `fcm_fecini_srfa` date DEFAULT NULL COMMENT 'Fecha en que inicia vigencia para ser utilzada por el sistema',
  `fcm_fecfin_srfa` date DEFAULT NULL COMMENT 'Fecha en que finaliza vigencia para ser utilizada por el sistema',
  `fcm_facini_srfa` int(15) DEFAULT NULL COMMENT 'Numero secuencial de factura donde inicia el consecutivo',
  `fcm_facfin_srfa` int(15) DEFAULT NULL COMMENT 'Numero secuencial de factura donde finaliza el consecutivo',
  `fcm_ultgen_srfa` int(15) DEFAULT NULL COMMENT 'Ultimo Numero de factura generado (se utiliza como base para generar el siguiente)',
  `fcm_prefij_srfa` varchar(5) DEFAULT NULL COMMENT 'Prefijo para el numero de generado',
  `fcm_maxsec_srfa` int(2) DEFAULT NULL COMMENT 'Inidica el tamaño maximo en caracteres para el secuencial generado como numero de factura',
  `fcm_alrsec_srfa` int(5) DEFAULT NULL COMMENT 'Indica cuantos numeros secuenciales antes se emite mensaje de alarma de que se cumpla el limite',
  `fcm_relcer_srfa` varchar(1) DEFAULT NULL COMMENT 'Inidica si se rellena el nuevo secuencial con ceros a la izquierda 1 =Si 2=No',
  `fcm_estreg_srfa` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1 =Activo 2=Inactivo',
  PRIMARY KEY (`fcm_secres_srfa`),
  KEY `srfa02` (`fcm_numres_srfa`),
  KEY `srfa03` (`fcm_desres_srfa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmsoatmanualma` table : 
#

DROP TABLE IF EXISTS `fcmsoatmanualma`;

CREATE TABLE `fcmsoatmanualma` (
  `fcm_codser_soat` varchar(20) NOT NULL DEFAULT '' COMMENT 'Codigo SOAT del servicio para gestion de actualizacion de precios',
  `fcm_desman_soat` text COMMENT 'Descripcion del servicio',
  `fcm_punuvr_sips` float(12,6) DEFAULT NULL COMMENT 'Puntajes o UVR según manual SOAT o ISS para calcular valor servicios con base en salarios minimos vigentes',
  `fcm_valser_sips` float(17,2) DEFAULT NULL COMMENT 'Valor del servicio para venta',
  `fcm_deskey_soat` varchar(250) DEFAULT NULL COMMENT 'Campo llave de busqueda sin tildes y solo 250 catacteres',
  `fcm_valkey_soat` int(10) DEFAULT NULL COMMENT 'Total caracteres que contiene el campo descripcion servicio',
  PRIMARY KEY (`fcm_codser_soat`),
  KEY `soat02` (`fcm_deskey_soat`),
  KEY `soat03` (`fcm_valkey_soat`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `fcmtiptarifario` table : 
#

DROP TABLE IF EXISTS `fcmtiptarifario`;

CREATE TABLE `fcmtiptarifario` (
  `fcm_codtar_ttar` varchar(1) NOT NULL DEFAULT '' COMMENT 'Codigo tipo manual tarifario: 1=SOAT 2=ISS 3=CUPS',
  `fcm_destar_ttar` varchar(20) DEFAULT NULL COMMENT 'Descripcion tipo manual tarifario',
  PRIMARY KEY (`fcm_codtar_ttar`),
  KEY `ttar02` (`fcm_destar_ttar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grccategoriarec` table : 
#

DROP TABLE IF EXISTS `grccategoriarec`;

CREATE TABLE `grccategoriarec` (
  `grc_idecat_grcc` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código unico categoria  para organizar los recursos (generado por el sistema)',
  `grc_descat_grcc` varchar(60) DEFAULT NULL COMMENT 'Descripcion de la categoria',
  PRIMARY KEY (`grc_idecat_grcc`),
  KEY `grcc02` (`grc_descat_grcc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grcestandarespe` table : 
#

DROP TABLE IF EXISTS `grcestandarespe`;

CREATE TABLE `grcestandarespe` (
  `grc_codesp_grep` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo especificacion del formato según  estandar: NA=Formato normal de origen (sin estandar) , HL7-CDA-R2=Especifiacionresultados de laboratorio, HL7-444 …',
  `grc_ideesp_grep` varchar(30) DEFAULT NULL COMMENT 'Codigo del formato dentro de la especificacion del estandar ejemplo: R2V454545_58F',
  `grc_codest_gres` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo formato o estandar XML en el cual se guarda el archivo: NA=Formato normal de origen , HL7, OOXML, OASIS,ISO 19005 PDF(A) y otros',
  `grc_descri_grep` varchar(60) DEFAULT NULL COMMENT 'Titulo o descripcion especificacion o del formato',
  `grc_modxml_grep` text COMMENT 'Modelo del formato en xml',
  PRIMARY KEY (`grc_codesp_grep`),
  KEY `grep02` (`grc_ideesp_grep`),
  KEY `grep03` (`grc_codest_gres`),
  KEY `grep04` (`grc_descri_grep`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grcestandargest` table : 
#

DROP TABLE IF EXISTS `grcestandargest`;

CREATE TABLE `grcestandargest` (
  `grc_codest_gres` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo tipo formato o estandar XML en el cual se guarda el archivo: NA=Formato normal de origen , HL7, OOXML, OASIS,ISO 19005 PDF(A) y otros',
  `grc_descri_gres` varchar(60) DEFAULT NULL COMMENT 'Titulo o descripcion del estandar',
  PRIMARY KEY (`grc_codest_gres`),
  KEY `gres02` (`grc_descri_gres`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grcmaesrecursos` table : 
#

DROP TABLE IF EXISTS `grcmaesrecursos`;

CREATE TABLE `grcmaesrecursos` (
  `grc_iderec_grcm` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código unico del archivo de recurso (generado por el sistema)',
  `grc_desrec_grcm` varchar(60) DEFAULT NULL COMMENT 'Titulo o descripción textual corta  del recurso  imagen, video, audio  capturada',
  `grc_tiprec_grcm` varchar(30) DEFAULT NULL COMMENT 'Tipo archivo recurso : IMAGEN, VIDEO, AUDIO, WORD, EXCEL, PDF, XML Yotros',
  `grc_fecrec_grcm` date DEFAULT NULL COMMENT 'Fecha en la que fue capturada la imagen',
  `grc_nomarc_grcm` varchar(60) DEFAULT NULL COMMENT 'Nombre fisico del archivo con la extencion',
  `grc_extarc_grcm` varchar(10) DEFAULT NULL COMMENT 'Extencion del archivo de recurso ejemplo: DOC, DOCX, PDF, XLS,  XLSX, JPG, JPEG, PNG ,BMP y Otros',
  `grc_rutarc_grcm` varchar(250) DEFAULT NULL COMMENT 'Ruta de acceso al archivo de recurso, dentro de la galeria .',
  `grc_origen_grcm` varchar(20) DEFAULT NULL COMMENT 'Origen del recurso: ESCANNER, CAMARA, EQUIPOMEDICO,  EMAIL,  HISTORIA-PAPEL, OTRO',
  `grc_idecat_grcc` varchar(10) DEFAULT NULL COMMENT 'Código unico categoria para organizar los recursos dentro de la galeria',
  `sia_estreg_imus` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`grc_iderec_grcm`),
  KEY `grcm02` (`grc_desrec_grcm`),
  KEY `grcm03` (`grc_nomarc_grcm`),
  KEY `grcm04` (`grc_tiprec_grcm`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grctiporecursos` table : 
#

DROP TABLE IF EXISTS `grctiporecursos`;

CREATE TABLE `grctiporecursos` (
  `grc_tiprec_grtr` varchar(5) NOT NULL DEFAULT '' COMMENT 'Tipo recurso cargado según software origen: DOC = Word, PPT=Powert Ponit, XLS,IMG=Imágenes,PDF,VID=Videos y otros',
  `grc_titulo_grtr` varchar(60) DEFAULT NULL COMMENT 'Titulo del recursos',
  `grc_descri_grtr` text COMMENT 'Descripcion amplia del tipo recurso',
  `grc_extarc_grtr` varchar(80) DEFAULT NULL COMMENT 'Lista de extencion compatibles que maneja el tipo recurso ejemplo: DOC, DOCX, PDF, XLS,  XLSX, JPG, JPEG, PNG ,BMP,MOV,AVI,MP4 y Otros',
  `grc_imagen_grtr` varchar(60) DEFAULT NULL COMMENT 'Nombre de la imagen que representa el registro de actividad en las diferentes vistas',
  `grc_icolor_grtr` varchar(20) DEFAULT NULL COMMENT 'Color vista del fondo en navegacion donde sea requerido',
  `grc_estado_grtr` varchar(1) DEFAULT NULL COMMENT 'Estado del tipo recurso o disponiblidad 1=Activo 2=Inactivo',
  PRIMARY KEY (`grc_tiprec_grtr`),
  KEY `grtr02` (`grc_titulo_grtr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grpformatoplant` table : 
#

DROP TABLE IF EXISTS `grpformatoplant`;

CREATE TABLE `grpformatoplant` (
  `grp_idefor_grfp` varchar(20) NOT NULL DEFAULT '' COMMENT 'Consecutivo Único del formato',
  `grp_desfor_grfp` varchar(80) DEFAULT NULL COMMENT 'Nombre  o descripcion del nuevo formato al generar plantilla',
  `grp_hojalt_grpv` int(5) DEFAULT NULL COMMENT 'Alto hojas de la plantilla',
  `grp_hojanc_grpv` int(5) DEFAULT NULL COMMENT 'Ancho Hojas de la plantilla',
  `grp_marver_grpv` int(5) DEFAULT NULL COMMENT 'Margen vertical de la plantilla',
  `grp_marhor_grpv` int(5) DEFAULT NULL COMMENT 'Margen horizontal de la plantilla',
  `grp_xmlpla_grpv` text COMMENT 'Codigo XML formato basico de  plantilla',
  `grp_idegru_grpg` varchar(10) DEFAULT NULL COMMENT 'Codigos Grupos de plantillas (GF001 = Formato para Gestion medica GF002=Formatos para reportes ...)',
  `grp_epapel_grpv` varchar(20) DEFAULT NULL COMMENT 'Nombre de la presentacion estilo del papel: OFICIO, CARTA, MEDIACARTA, ETIQUETA,PERSONALIZADO',
  `grp_tipfor_grpl` varchar(20) DEFAULT NULL COMMENT 'Tipo formato: PLANTILLA,ETIQUETA,REPORTES y Otros',
  `grp_estilo_grpv` varchar(20) DEFAULT NULL COMMENT 'Referenicia al estilo o tema del diseño  y presentacion de plantilla (para el futuro)',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`grp_idefor_grfp`),
  KEY `grfp02` (`grp_desfor_grfp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grpgrupoplantil` table : 
#

DROP TABLE IF EXISTS `grpgrupoplantil`;

CREATE TABLE `grpgrupoplantil` (
  `grp_idegru_grpg` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigos Grupos de plantillas (generado por el sistema)',
  `grp_desgru_grpg` varchar(40) DEFAULT NULL COMMENT 'Descripción textual  del grupo plantilla',
  PRIMARY KEY (`grp_idegru_grpg`),
  KEY `grpg02` (`grp_desgru_grpg`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grpmaeplantilla` table : 
#

DROP TABLE IF EXISTS `grpmaeplantilla`;

CREATE TABLE `grpmaeplantilla` (
  `grp_idepla_grpl` varchar(20) NOT NULL DEFAULT '' COMMENT 'Consecutivo Único de la plantilla (generado por el sistema)',
  `grp_despla_grpl` varchar(80) DEFAULT NULL COMMENT 'Nombre  o descripcion de la plantilla según su uso',
  `grp_hl7for_grpl` varchar(10) DEFAULT NULL COMMENT 'Código del formato HL7 que homologa la plantilla',
  `grp_idegru_grpg` varchar(10) DEFAULT NULL COMMENT 'Codigos Grupos de plantillas (generado por el sistema)',
  `grp_tipfor_grpl` varchar(20) DEFAULT NULL COMMENT 'Tipo formato: GENERAL, RIPS, LECTURAS, ODONTOGRAMA',
  `grc_iderec_grcm` varchar(20) DEFAULT NULL COMMENT 'Codigo recurso imagen en la galeria de recursos, que representa el icono de la plantilla',
  `grp_conver_grpl` int(5) DEFAULT NULL COMMENT 'Contador para generar versiones plantilla',
  `grp_conobj_grpl` int(5) DEFAULT NULL COMMENT 'Contador para generar Nombres unicos de los objetos en la plantilla',
  `grp_prefij_grpl` varchar(3) DEFAULT NULL COMMENT 'Prefijo para  generar Nombres unicos de los objetos en la plantilla ejemplo: EX, FR, OBJ …',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Codigo unico de la version del formato que esta en uso (util para formatos de Historia clinica que se modifican con el tiempo)',
  `grp_tippla_grpl` varchar(1) DEFAULT NULL COMMENT 'Tipo plantilla: 1=Plantillas del sistema 2= Plantillas personalizadas',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`grp_idepla_grpl`),
  KEY `grpl02` (`grp_despla_grpl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grpmaeversplant` table : 
#

DROP TABLE IF EXISTS `grpmaeversplant`;

CREATE TABLE `grpmaeversplant` (
  `grp_idepla_grpv` varchar(20) NOT NULL DEFAULT '' COMMENT 'Consecutivo Único de la version plantilla (generado por el sistema)',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_verpla_grpv` varchar(5) DEFAULT NULL COMMENT 'Numero de la Version plantilla ejemplo: 10,11,12…',
  `grp_xmlpla_grpv` longtext COMMENT 'Codigo XML formato plantilla',
  `grp_xmlplb_grpv` longtext COMMENT 'Codigo XML formato plantilla continuacion parte 2',
  `grp_xmlplc_grpv` longtext COMMENT 'Codigo XML formato plantilla continuacion parte 3',
  `grp_xmlpld_grpv` longtext COMMENT 'Codigo XML formato plantilla continuacion parte 4',
  `grp_fcodig_grpv` longtext COMMENT 'Codigo fuente para gestion en formatos diseñados',
  `grp_numver_grpv` int(5) DEFAULT NULL COMMENT 'Numero (en formato numerico) de la Version plantilla para  organizar en consultas ejemplo: 10,11,12…',
  `grp_hojalt_grpv` int(5) DEFAULT NULL COMMENT 'Alto hojas de la plantilla',
  `grp_hojanc_grpv` int(5) DEFAULT NULL COMMENT 'Ancho Hojas de la plantilla',
  `grp_marver_grpv` int(5) DEFAULT NULL COMMENT 'Margen vertical de la plantilla',
  `grp_marhor_grpv` int(5) DEFAULT NULL COMMENT 'Margen horizontal de la plantilla',
  `grp_epapel_grpv` varchar(20) DEFAULT NULL COMMENT 'Nombre de la presentacion estilo del papel: OFICIO, CARTA, MEDIACARTA, ETIQUETA,PERSONALIZADO',
  `grp_estilo_grpv` varchar(20) DEFAULT NULL COMMENT 'Referenicia al estilo o tema del diseño  y presentacion de plantilla (para el futuro)',
  `grp_decima_grpv` varchar(1) DEFAULT NULL COMMENT 'Carácter separador decimal utilizado en el diseño de la plantilla.',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`grp_idepla_grpv`),
  KEY `grpv02` (`grp_idepla_grpl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grpplantvistcam` table : 
#

DROP TABLE IF EXISTS `grpplantvistcam`;

CREATE TABLE `grpplantvistcam` (
  `grp_idereg_grob` varchar(30) NOT NULL DEFAULT '' COMMENT 'Codgo registro GRP_IDEPLA_GRPV + R + Contador_de_objetos',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla (generado por el sistema)',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_nomobj_grob` varchar(60) DEFAULT NULL COMMENT 'Nombre interno del objeto en el formato diseñado desde el editor ejemplo:  txtTextBoxEX153, cboComboBoxEX25 y otros',
  `grp_desobj_grob` varchar(150) DEFAULT NULL COMMENT 'Descripción textual o titulo del objeto',
  `grp_varobj_grob` varchar(30) DEFAULT NULL COMMENT 'Nombre de la variable que acompaña al objeto en el diseño del formato',
  `grp_claseb_grob` varchar(30) DEFAULT NULL COMMENT 'Clase base nativa (C.NET) del objeto ejemplo: TextBox, ComboBox, DateTime,UserControl y otros',
  `grp_claseg_grob` varchar(50) DEFAULT NULL COMMENT 'Clase gestion vista objeto ejemplo: TextBoxFecha, ListComboBox, TextBoxDateTime,UserControlAdmision  y otros',
  `grp_codsec_grse` varchar(3) DEFAULT NULL COMMENT 'Codigo seccion a la cual pertenece el objeto dentro de las diferentes secciones creadas en el formato',
  `grp_ordvis_grob` int(3) DEFAULT NULL COMMENT 'Orden visualizacion del objeto dentro de  la seccion en informes',
  `hcl_nomcam_hccm` varchar(20) DEFAULT NULL COMMENT 'Nombre del campo en la base de datos donde se guardaran los datos capturados desde el objeto, ejemplo: HCL_TXT018_HCTX, es un campo texto corto (char 130)  en el maestro HCLREGISEXTXA.',
  `hcl_camdes_hccm` varchar(20) DEFAULT NULL COMMENT 'Opcional - Nombre del campo descripcion en la base de datos donde se guardaran las decripciones del campo codigo, para Combobox TextBoxRel y otros',
  `hcl_nomvar_hcvr` varchar(30) DEFAULT NULL COMMENT 'Nombre unico identificador de la variable publica, para referencia dentro del sistema, este nombre debe incluir nombre identificador del grupo al que pertenece, ejemplo variables : VACUNACION_NIÑO_DPT_DOSIS1, JOVEN_PLANIFICACION_SI_NO',
  `grp_repcam_grob` varchar(1) DEFAULT NULL COMMENT 'Tipo uso que se puede hacer con el  campo para generacion de reporte: 1= Solo Reporte 2=Reporte y Estadisticas 3= Solo Estadisticas 4 =Ninguno',
  PRIMARY KEY (`grp_idereg_grob`),
  KEY `grob02` (`grp_idepla_grpv`),
  KEY `grob03` (`grp_idepla_grpl`),
  KEY `grob04` (`grp_nomobj_grob`),
  KEY `grob05` (`grp_desobj_grob`),
  KEY `grob06` (`hcl_nomvar_hcvr`),
  KEY `grob07` (`grp_varobj_grob`),
  KEY `grob08` (`hcl_nomcam_hccm`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `grpplantvistsec` table : 
#

DROP TABLE IF EXISTS `grpplantvistsec`;

CREATE TABLE `grpplantvistsec` (
  `grp_idesec_grse` varchar(30) NOT NULL DEFAULT '' COMMENT 'Codgo registro GRP_IDEPLA_GRPV + R +GRP_CODSEC_GRSE',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla (generado por el sistema)',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_codsec_grse` varchar(3) DEFAULT NULL COMMENT 'Codigo seccion de las diferentes secciones creadas en el formato, en cada formato existe la seccion por defecto  NA= General',
  `grp_dessec_grse` varchar(150) DEFAULT NULL COMMENT 'Descripción textual o titulo de la seccion',
  `grp_ordvis_grse` int(3) DEFAULT NULL COMMENT 'Orden visualizacion de la seccion en informes',
  `grp_numcol_grse` int(2) DEFAULT NULL COMMENT 'Numero de columnas en la vista de informe',
  `grp_titvis_grse` varchar(1) DEFAULT NULL COMMENT 'Titulo de la seccion es visible en informe impreso: 1= Si es visible 2=No es visible',
  PRIMARY KEY (`grp_idesec_grse`),
  KEY `grse02` (`grp_idepla_grpv`),
  KEY `grse03` (`grp_idepla_grpl`),
  KEY `grse04` (`grp_dessec_grse`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclformatguiama` table : 
#

DROP TABLE IF EXISTS `hclformatguiama`;

CREATE TABLE `hclformatguiama` (
  `hcl_secreg_hcga` varchar(5) NOT NULL DEFAULT '' COMMENT 'Código único guia de atencion generado por el sistema',
  `hcl_desgui_hcga` varchar(60) DEFAULT NULL COMMENT 'Descripcion textual de guia de atencion medica',
  `hcl_tipgui_hcga` varchar(1) DEFAULT NULL COMMENT 'Tipo guia de atencion :1= Guia de atencion por defecto  del sistema 2= Guia de atencion generadas',
  `hcl_estreg_hcga` varchar(1) DEFAULT NULL COMMENT 'Estado de la guia 1= Activa 2= Inactiva',
  PRIMARY KEY (`hcl_secreg_hcga`),
  KEY `hcga02` (`hcl_desgui_hcga`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclformatguiamd` table : 
#

DROP TABLE IF EXISTS `hclformatguiamd`;

CREATE TABLE `hclformatguiamd` (
  `hcl_secreg_hcgb` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código único del registro generado por el sistema',
  `hcl_secreg_hcga` varchar(5) DEFAULT NULL COMMENT 'Codigos único guia de atencion generado por el sistema',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad medica: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia desde la tabla: HCLTIPOREGACTIV',
  `adm_codtat_tatn` varchar(1) DEFAULT NULL COMMENT 'Tipo de Atención o ámbito prestaracion  servicio (Viene del campo ADM_CODTAT_TATN) :1=Ambulatoria 2=Hospitalización 3=Urgencia A= Aplica para todos los ambitos de atencion',
  `fcm_codcpr_cpro` varchar(50) DEFAULT NULL COMMENT 'Lista codigo centro de producción (separada por coma (,))  a los cuales estan asociadas las actividades medicas que se deben cumplir',
  `hcl_mededi_hcgb` varchar(1) DEFAULT NULL COMMENT 'Medida edad inicial a la cual aplica la actividad medica para validación pertinencia: 1=Años 2=Meses 3=Días',
  `hcl_edaini_hcgb` int(6) DEFAULT NULL COMMENT 'Edad inicial para la cual aplica la validación de pertinencia',
  `hcl_mededf_hcgb` varchar(1) DEFAULT NULL COMMENT 'Medida edad fina a la cual aplica el servicio, para validación pertinencia actividad medica:1=Años 2=Meses 3=Días',
  `hcl_edafin_hcgb` int(6) DEFAULT NULL COMMENT 'Edad final para la cual aplica la validación de pertinencia',
  `hcl_sexapl_hcgb` varchar(1) DEFAULT NULL COMMENT 'Sexo al cual aplica la actividad medica: 1=Masculino 2=Femenino 3=Ambos',
  `hcl_mededl_hcgb` varchar(1) DEFAULT NULL COMMENT 'Medida edad validacion para lista valores permitidos pertinencia: 1=Años 2=Meses 3=Días',
  `hcl_listar_hcgb` varchar(250) DEFAULT NULL COMMENT 'Lista valores permitidos validacion edad según rango separados por el carácter COMA',
  `hcl_estreg_hcgb` varchar(1) DEFAULT NULL COMMENT 'Estado del formato para cumplimiento en centro de produccion:1= Activo 2= Inactivo',
  PRIMARY KEY (`hcl_secreg_hcgb`),
  KEY `hcgb02` (`hcl_secreg_hcga`),
  KEY `hcgb03` (`fcm_codcpr_cpro`),
  KEY `hcgb04` (`hcl_codreg_hcca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclformatperfil` table : 
#

DROP TABLE IF EXISTS `hclformatperfil`;

CREATE TABLE `hclformatperfil` (
  `hcl_codreg_hcpr` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código único del registro generado por el sistema',
  `sys_codper_perf` varchar(5) DEFAULT NULL COMMENT 'Código del perfil usuario del sistema',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia desde la tabla: HCLTIPOREGACTIV',
  `hcl_accvis_hcpr` varchar(1) DEFAULT NULL COMMENT 'Acceso al modo vista del formato, sin permiso para modificaciones: 1=Activo 2=Inactivo',
  `hcl_accedt_hcpr` varchar(1) DEFAULT NULL COMMENT 'Acceso al modo EDT o edicion, permite al usuario realizar cambios en contenidos del formato: 1=Activo 2=Inactivo',
  `hcl_accprn_hcpr` varchar(1) DEFAULT NULL COMMENT 'Acceso para imprimir, permite al usuario imprimir valores contenidos del formato: 1=Activo 2=Inactivo',
  `hcl_accges_hcpr` varchar(1) DEFAULT NULL COMMENT 'Acceso a otras gestiones, permitir al usuario  acceder a funcionalidad o procesos adicionales del formato: 1=Activo 2=Inactivo',
  `hcl_estfor_hcpr` varchar(1) DEFAULT NULL COMMENT 'Estado del formato dentro del perfil  1= Activo 2= Inactivo',
  PRIMARY KEY (`hcl_codreg_hcpr`),
  KEY `hcpr02` (`sys_codper_perf`),
  KEY `hcpr03` (`hcl_codreg_hcca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclformatvistma` table : 
#

DROP TABLE IF EXISTS `hclformatvistma`;

CREATE TABLE `hclformatvistma` (
  `hcl_codreg_hcra` varchar(4) NOT NULL DEFAULT '' COMMENT 'Codigo unico registro del grupo actividad para vista captura Historia clinica',
  `hcl_desgru_hcra` varchar(80) DEFAULT NULL COMMENT 'Descripcion grupo actividades clasificadas para vista en captura historias clinicas',
  `hcl_tipvis_hcra` varchar(1) DEFAULT NULL COMMENT 'Saber si se muestra el grupo según el tipo de registro de atencion activo: 1= Solo en pacientes admitidos 2=Solo en Pacientes ambulatoria 3= Ambos casos',
  `hcl_ordvis_hcra` int(3) DEFAULT NULL COMMENT 'Orden visualizacion dentro de lista grupos',
  `hcl_imagen_hcra` varchar(60) DEFAULT NULL COMMENT 'Nombre de la imagen que representa el grupo',
  `hcl_conreg_hcra` int(5) DEFAULT NULL COMMENT 'Contador para generar el secuencial unico de registros en detalle (gestion interna)',
  `hcl_estreg_hcra` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1= Activo 2= Inactivo',
  PRIMARY KEY (`hcl_codreg_hcra`),
  KEY `hcra02` (`hcl_desgru_hcra`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclframghamctrl` table : 
#

DROP TABLE IF EXISTS `hclframghamctrl`;

CREATE TABLE `hclframghamctrl` (
  `hcl_nroreg_hcfc` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del registro genrado por el sistema',
  `hcl_tipcol_hcfc` varchar(2) DEFAULT NULL COMMENT 'Codigo tipo colesterol: 1= Colesterol HDL 2= Colesterol Total',
  `sis_codsex_sexo` varchar(1) DEFAULT NULL COMMENT 'Codigo tipo Sexo Generado por el sistema F=Femenino M=Masculino A=Ambos Sexos',
  `hcl_medini_hcfc` float(6,2) DEFAULT NULL COMMENT 'Rango inicial valores colesterol',
  `hcl_medfin_hcfc` float(6,2) DEFAULT NULL COMMENT 'Rango final valores colesterol',
  `hcl_puntos_hcfc` float(6,2) DEFAULT NULL COMMENT 'Puntaje del registro',
  `hcl_observ_hcfc` text COMMENT 'Nota u observacion para cuando sea requerida',
  `hcl_ordvis_hcfc` int(3) DEFAULT NULL COMMENT 'Orden vizualizacion del registro en la vista',
  `hcl_estreg_hcfc` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2=Inactivo',
  PRIMARY KEY (`hcl_nroreg_hcfc`),
  KEY `hcfc02` (`hcl_tipcol_hcfc`),
  KEY `hcfc03` (`hcl_medini_hcfc`),
  KEY `hcfc04` (`hcl_medfin_hcfc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclframghamedad` table : 
#

DROP TABLE IF EXISTS `hclframghamedad`;

CREATE TABLE `hclframghamedad` (
  `hcl_nroreg_hcfe` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del registro genrado por el sistema',
  `sis_codsex_sexo` varchar(1) DEFAULT NULL COMMENT 'Codigo tipo Sexo Generado por el sistema F=Femenino M=Masculino',
  `hcl_edaini_hcfe` int(3) DEFAULT NULL COMMENT 'Rango inicial edad',
  `hcl_edafin_hcfe` int(3) DEFAULT NULL COMMENT 'Rango final edad',
  `hcl_puntos_hcfe` float(6,2) DEFAULT NULL COMMENT 'Puntaje del registro',
  `hcl_observ_hcfe` text COMMENT 'Nota u observacion para cuando sea requerida',
  `hcl_ordvis_hcfe` int(3) DEFAULT NULL COMMENT 'Orden vizualizacion del registro en la vista',
  `hcl_estreg_hcfe` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2=Inactivo',
  PRIMARY KEY (`hcl_nroreg_hcfe`),
  KEY `hcfe02` (`sis_codsex_sexo`),
  KEY `hcfe03` (`hcl_edaini_hcfe`),
  KEY `hcfe04` (`hcl_edafin_hcfe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclframghamnive` table : 
#

DROP TABLE IF EXISTS `hclframghamnive`;

CREATE TABLE `hclframghamnive` (
  `hcl_nroreg_hcfn` varchar(3) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del registro genrado por el sistema',
  `sis_codsex_sexo` varchar(1) DEFAULT NULL COMMENT 'Codigo tipo Sexo Generado por el sistema F=Femenino M=Masculino',
  `hcl_porini_hcfn` float(6,2) DEFAULT NULL COMMENT 'Porcentaje incial del rango que indica el nivel',
  `hcl_porfin_hcfn` float(6,2) DEFAULT NULL COMMENT 'Porcentaje final del rango que indica el nivel',
  `hcl_titulo_hcft` varchar(30) DEFAULT NULL COMMENT 'Titulo o descripcion breve del nivel de riesgo',
  `hcl_observ_hcfn` text COMMENT 'Nota u observacion para cuando sea requerida',
  `hcl_ordvis_hcfn` int(3) DEFAULT NULL COMMENT 'Orden vizualizacion del registro en la vista',
  `hcl_vcolor_hcfn` varchar(20) DEFAULT NULL COMMENT 'Color en formato Hexadecimal para mostrar como un fondo',
  `hcl_imagen_hcfn` varchar(40) DEFAULT NULL COMMENT 'Imagen en formato jpg o png para ilistrar la vista',
  `hcl_estreg_hcfn` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2=Inactivo',
  PRIMARY KEY (`hcl_nroreg_hcfn`),
  KEY `hcfn02` (`hcl_porini_hcfn`),
  KEY `hcfn03` (`hcl_porfin_hcfn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclframghamotrs` table : 
#

DROP TABLE IF EXISTS `hclframghamotrs`;

CREATE TABLE `hclframghamotrs` (
  `hcl_nroreg_hcft` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del registro genrado por el sistema',
  `hcl_tipcol_hcft` varchar(2) DEFAULT NULL COMMENT 'Codigo tipo riesgo: 1= Dabetes SI/NO 2=Tabaco ..',
  `sis_codsex_sexo` varchar(1) DEFAULT NULL COMMENT 'Codigo tipo Sexo Generado por el sistema F=Femenino M=Masculino A=Ambos Sexos',
  `hcl_respue_hcft` varchar(2) DEFAULT NULL COMMENT 'Respuesta a la pregunta SI/NO',
  `hcl_puntos_hcft` float(6,2) DEFAULT NULL COMMENT 'Puntaje del registro',
  `hcl_observ_hcft` text COMMENT 'Nota u observacion para cuando sea requerida',
  `hcl_ordvis_hcft` int(3) DEFAULT NULL COMMENT 'Orden vizualizacion del registro en la vista',
  `hcl_estreg_hcft` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2=Inactivo',
  PRIMARY KEY (`hcl_nroreg_hcft`),
  KEY `hcft02` (`hcl_tipcol_hcft`),
  KEY `hcft03` (`sis_codsex_sexo`),
  KEY `hcft04` (`hcl_respue_hcft`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclframghampart` table : 
#

DROP TABLE IF EXISTS `hclframghampart`;

CREATE TABLE `hclframghampart` (
  `hcl_nroreg_hcfp` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del registro genrado por el sistema',
  `sis_codsex_sexo` varchar(1) DEFAULT NULL COMMENT 'Codigo tipo Sexo Generado por el sistema F=Femenino M=Masculino',
  `hcl_edaini_hcfp` int(3) DEFAULT NULL COMMENT 'Rango inicial edad',
  `hcl_edafin_hcfp` int(3) DEFAULT NULL COMMENT 'Rango final edad',
  `hcl_prsini_hcfp` int(3) DEFAULT NULL COMMENT 'Rango presion sistolica incicial',
  `hcl_prsfin_hcfp` int(3) DEFAULT NULL COMMENT 'Rango presion sistolica final',
  `hcl_puntos_hcfp` float(6,2) DEFAULT NULL COMMENT 'Puntaje del registro',
  `hcl_observ_hcfp` text COMMENT 'Nota u observacion para cuando sea requerida',
  `hcl_ordvis_hcfp` int(3) DEFAULT NULL COMMENT 'Orden vizualizacion del registro en la vista',
  `hcl_estreg_hcfp` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2=Inactivo',
  PRIMARY KEY (`hcl_nroreg_hcfp`),
  KEY `hcfp02` (`sis_codsex_sexo`),
  KEY `hcfp03` (`hcl_edaini_hcfp`),
  KEY `hcfp04` (`hcl_edafin_hcfp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclframghamr10a` table : 
#

DROP TABLE IF EXISTS `hclframghamr10a`;

CREATE TABLE `hclframghamr10a` (
  `hcl_nroreg_hcfr` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del registro genrado por el sistema',
  `sis_codsex_sexo` varchar(1) DEFAULT NULL COMMENT 'Codigo tipo Sexo Generado por el sistema F=Femenino M=Masculino',
  `hcl_punini_hcfr` float(6,2) DEFAULT NULL COMMENT 'Puntaje del test rango inicial valores',
  `hcl_punfin_hcfr` float(6,2) DEFAULT NULL COMMENT 'Puntaje del test rango final valores',
  `hcl_riesgo_hcfr` float(6,2) DEFAULT NULL COMMENT 'Valor en porcentaje del riesgo según puntaje obtenido en el test',
  `hcl_observ_hcfr` text COMMENT 'Nota u observacion para cuando sea requerida',
  `hcl_ordvis_hcfr` int(3) DEFAULT NULL COMMENT 'Orden vizualizacion del registro en la vista',
  `hcl_estreg_hcfr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2=Inactivo',
  PRIMARY KEY (`hcl_nroreg_hcfr`),
  KEY `hcfr02` (`hcl_punini_hcfr`),
  KEY `hcfr03` (`hcl_punfin_hcfr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclhistarchivos` table : 
#

DROP TABLE IF EXISTS `hclhistarchivos`;

CREATE TABLE `hclhistarchivos` (
  `hcl_iderec_hclr` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código registro archivo de recurso utilizado en la HC (generado por el sistema)',
  `hcl_nroreg_hcms` varchar(20) DEFAULT NULL COMMENT 'Código registro maestro (HCLREGORDESERMS) que agrupa relacionado con el maestro de eventos medicos',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código del evento medico que asocia el recurso en la vista historial clinico',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `hcl_nrohis_hicl` varchar(20) DEFAULT NULL COMMENT 'Numero o código de la Ficha de Historias Clínicas (generado por el sistema)',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional del turno de servicio medicamento',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `grc_codest_gres` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo formato o estandar XML en el cual se guarda el archivo: NA=Formato normal de origen , HL7, OOXML, OASIS,ISO 19005 PDF(A) y otros',
  `grc_codesp_grep` varchar(10) DEFAULT NULL COMMENT 'Codigo especificacion del formato según  estandar: NA=Formato normal de origen (sin estandar) , HL7-CDA-R2=Especifiacionresultados de laboratorio, HL7-444 …',
  `grc_tiprec_grtr` varchar(5) DEFAULT NULL COMMENT 'Tipo recurso cargado según software origen: RDOC = Word, RHL7=Estandar HL7, RXLS,RIMG=Imágenes,RPDF,RVID=Videos y otros',
  `hcl_extarc_hclr` varchar(5) DEFAULT NULL COMMENT 'Extencion del archivo cargado emplo: DOC, DOCX, PDF, XLS,  XLSX, JPG, JPEG, PNG ,BMP,MOV,AVI,MP4 y Otros',
  `hcl_nomarc_hclr` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo destino con extencion incluida',
  `hcl_rutarc_hclr` varchar(90) DEFAULT NULL COMMENT 'Ruta fisica donde se almacenara el archivo',
  `hcl_texcon_hclr` text COMMENT 'Texto transcripcion del contenido en la imagen o del PDF',
  `hcl_texkey_hclr` text COMMENT 'Texto transcripcion del contenido en la imagen o del PDF, abreviado para usar como llave de busqueda',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`hcl_iderec_hclr`),
  KEY `hclr02` (`hcl_nroreg_hcev`),
  KEY `hclr03` (`hcl_nroreg_hcms`),
  KEY `hclr04` (`hcl_nrohis_hicl`),
  KEY `hclr05` (`sia_idesec_usua`),
  KEY `hclr06` (`grc_codest_gres`),
  KEY `hclr07` (`grc_tiprec_grtr`),
  KEY `hclr08` (`adm_secadm_rgad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclmaestrohiscl` table : 
#

DROP TABLE IF EXISTS `hclmaestrohiscl`;

CREATE TABLE `hclmaestrohiscl` (
  `hcl_nrohis_hicl` varchar(20) NOT NULL DEFAULT '' COMMENT 'Numero o código de la Ficha de Historias Clínicas (generado por el sistema)',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `hcl_fecapp_hicl` date DEFAULT NULL COMMENT 'Fecha apertura de la historia clinica por primera vez (puede ser no electronica)',
  `hcl_fecape_hicl` date DEFAULT NULL COMMENT 'Fecha apertura de la historia clinica electronica',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la apertura de la historia electronica',
  `hcl_hpapel_hicl` varchar(1) DEFAULT NULL COMMENT 'Historia clinica anterior en papel: 1=Si 2=No',
  `hcl_papeld_hicl` varchar(1) DEFAULT NULL COMMENT 'Historia clinica anterior escaneada : 1=Si 2=No',
  `hcl_ncarpe_hicl` varchar(20) DEFAULT NULL COMMENT 'Numero de la carpeta, cuando existe histiria clinica en papel.',
  `hcl_nestan_hicl` varchar(20) DEFAULT NULL COMMENT 'Numero del estante donde se encuentra la carpeta, cuando existe histiria clinica en papel.',
  `grc_iderec_grcm` varchar(20) DEFAULT NULL COMMENT 'Código unico  de la imagen (foto)  perfil del paciente desde la galeria de recursos',
  `hcl_notape_hicl` varchar(200) DEFAULT NULL COMMENT 'Nota de apertura electronica de la historia clinica.',
  `grp_coneve_hicl` int(6) DEFAULT NULL COMMENT 'Contador secuencial para eventos que se generan en el historial del paciente',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`hcl_nrohis_hicl`),
  KEY `hicl02` (`sia_idesec_usua`),
  KEY `hicl03` (`sia_nroide_usua`),
  KEY `hicl04` (`hcl_notape_hicl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregbliqidode` table : 
#

DROP TABLE IF EXISTS `hclregbliqidode`;

CREATE TABLE `hclregbliqidode` (
  `hcl_nroreg_hcbd` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico  registro liquidos adminstrados o eliminados',
  `hcl_nroreg_hcbm` varchar(20) DEFAULT NULL COMMENT 'Código secuencial unico registro maestro balance de liquidos',
  `hcl_secreg_hcbd` int(10) DEFAULT NULL COMMENT 'Numero secuencial del registro medico  para organizar la vista cronologica',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_codliq_hctl` varchar(2) DEFAULT NULL COMMENT 'Codigo tipo liquido administrado o eliminado',
  `hcl_vialiq_hcvl` varchar(2) DEFAULT NULL COMMENT 'Via administracion liquido o eliminacion de liquido',
  `hcl_gesfec_hcbd` date DEFAULT NULL COMMENT 'Fecha registro actividad',
  `hcl_tipreg_hcbd` varchar(1) DEFAULT NULL COMMENT 'Tipo registro: 1= Indicados 2 = Administrado 3=Eliminado',
  `hcl_cantid_hcbd` decimal(6,0) DEFAULT NULL COMMENT 'Cantidad de liquido administrado o eliminado',
  `hcl_horini_hcbd` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que inicia suministro de liquido al paciente en formato militar  (HH) ejm: 16',
  `hcl_horfin_hcbd` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que finaliza el suministro de liquido al paciente en formato militar  (HH) ejm: 16',
  `hcl_horeli_hcbd` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que paciente elimina  liquido formato militar  (HH) ejm: 16',
  `hcl_tiptur_hctu` varchar(3) DEFAULT NULL COMMENT 'Codigo clasificacion turnos diarios para la prestacion de servicios medicos',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional del turno de servicio medicamento',
  `hcl_sisfec_hcbd` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando se genera registro del evento',
  `hcl_sishor_hcbd` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema al generar registro de evento en formato militar  (HH) ejm: 16',
  `hcl_notreg_hcbd` text COMMENT 'Nota de la actividad',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`hcl_nroreg_hcbd`),
  KEY `hcbd02` (`hcl_nroreg_hcbm`),
  KEY `hcbd03` (`adm_secadm_rgad`),
  KEY `hcbd04` (`sia_idesec_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregbliqidoms` table : 
#

DROP TABLE IF EXISTS `hclregbliqidoms`;

CREATE TABLE `hclregbliqidoms` (
  `hcl_nroreg_hcbm` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico registro maestro balance de liquidos',
  `hcl_secreg_hcbm` int(10) DEFAULT NULL COMMENT 'Numero secuencial del registro medico  para organizar la vista cronologica',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial actividad medica en historial medico del paciente',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_nrorea_hcbm` varchar(20) DEFAULT NULL COMMENT 'Código registro maestro balance de liquidos anterior (turno que entrega para darle paso a apertura actual)',
  `hcl_fecape_hcbm` date DEFAULT NULL COMMENT 'Fecha apertura del turno o inicio del turno',
  `hcl_tiptur_hctu` varchar(3) DEFAULT NULL COMMENT 'Codigo clasificacion turnos diarios para la prestacion de servicios medicos',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `hcl_horini_hcbm` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que inicia suministro de liquido al paciente en formato militar  (HH) ejm: 16 (hora inicia turno)',
  `hcl_horfin_hcbm` decimal(5,2) DEFAULT NULL COMMENT 'Hora en que finaliza el suministro de liquido al paciente en formato militar  (HH) ejm: 16 (hora fin del turno)',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional del turno de servicio medicamento',
  `hcl_sisfec_hcbm` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando se genera registro del evento',
  `hcl_sishor_hcbm` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema al generar registro de evento en formato militar  (HH) ejm: 16',
  `hcl_totape_hcbm` decimal(6,0) DEFAULT NULL COMMENT 'Cantidad total pendiente por administrar al momento de la apertura del turno',
  `hcl_obsape_hcbm` text COMMENT 'Observacion para apertura del turno',
  `hcl_feccie_hcbm` date DEFAULT NULL COMMENT 'Datos del cierre  - Fecha cierre o entrega del turno',
  `hcl_horcie_hcbm` decimal(5,2) DEFAULT NULL COMMENT 'Datos del cierre  - Hora en que se entrega el turno en formato militar  (HH) ejm: 16',
  `hcl_totind_hcbm` decimal(6,0) DEFAULT NULL COMMENT 'Datos del cierre  - Cantidad total de liquido indicados durante el turno al momento del cierre',
  `hcl_totadm_hcbm` decimal(6,0) DEFAULT NULL COMMENT 'Datos del cierre  - Cantidad total de liquido administrado durante el turno al momento del cierre',
  `hcl_toteli_hcbm` decimal(6,0) DEFAULT NULL COMMENT 'Datos del cierre  - Cantidad total de liquido eliminados durante el turno al momento del cierre',
  `hcl_result_hcbm` decimal(6,0) DEFAULT NULL COMMENT 'Datos del cierre  - Resultado final del turno al momento del cierre (Resultado = Administrados - Eliminados)',
  `hcl_totpen_hcbm` decimal(6,0) DEFAULT NULL COMMENT 'Datos del cierre  - Cantidad total pendiente por  administrar al momento del cierre',
  `hcl_obscie_hcbm` text COMMENT 'Observacion para cierre del turno del turno',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`hcl_nroreg_hcbm`),
  KEY `hcbm02` (`hcl_nroreg_hcev`),
  KEY `hcbm03` (`adm_secadm_rgad`),
  KEY `hcbm04` (`sia_idesec_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisevcampo` table : 
#

DROP TABLE IF EXISTS `hclregisevcampo`;

CREATE TABLE `hclregisevcampo` (
  `hcl_nomcam_hccm` varchar(20) NOT NULL DEFAULT '' COMMENT 'Nombre del campo en la base de datos ejemplo: HCL_TXT018_HCTX',
  `hcl_dattip_hccm` varchar(10) DEFAULT NULL COMMENT 'Tipo dato que contiene: CHAR, DATE, NUMERICO y otros.',
  `hcl_datanc_hccm` varchar(10) DEFAULT NULL COMMENT 'Descripcion del valor digitado como dato actualizado de la variable',
  `adm_datdec_hccm` varchar(5) DEFAULT NULL COMMENT 'Numero de caracteres decimales para tipo de datos mumericos, flotantes y otros',
  `hcl_descri_hccm` varchar(80) DEFAULT NULL COMMENT 'Descripcion larga del campo',
  `hcl_titulo_hccm` varchar(40) DEFAULT NULL COMMENT 'Titulo corto del campo, para mostrar el listas de selección',
  `hcl_grupos_hccm` varchar(60) DEFAULT NULL COMMENT 'Identificador del grupo de objetos que pueden referenciar el campo para guardar datos',
  `hcl_idecam_hccm` varchar(5) DEFAULT NULL COMMENT 'Numero de orden o identificador del campo o campos cuando se guardan valores compuestos, codigos y campos descripcion que conservan una relacion estrecha.',
  `hcl_tipcam_hccm` varchar(20) DEFAULT NULL COMMENT 'Tipo campo según relacion con datos compuestos guardados, para saber si el dato es el codigo o la descripcion de un dato guardado o talvez la ruta de un recurso, etc. Ejemplo: VALOR, CODIGO, DESCRIPCION… Y OTROS',
  `hcl_nomarc_hccm` varchar(20) DEFAULT NULL COMMENT 'Nombre del archivo historico al cual pertence el campo ejemplo: HCLREGISEXTXA,HCLREGISEXFEC y otros',
  `hcl_ordvis_hccm` int(5) DEFAULT NULL COMMENT 'Orden vista secuencial de  la lista de campos',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`hcl_nomcam_hccm`),
  KEY `hccm02` (`hcl_titulo_hccm`),
  KEY `hccm03` (`hcl_grupos_hccm`),
  KEY `hccm04` (`hcl_nomarc_hccm`),
  KEY `hccm05` (`hcl_ordvis_hccm`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregiseventos` table : 
#

DROP TABLE IF EXISTS `hclregiseventos`;

CREATE TABLE `hclregiseventos` (
  `hcl_nroreg_hcev` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial del evento medico  (generado por el sistema)',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia',
  `hcl_desreg_hcev` varchar(200) DEFAULT NULL COMMENT 'Descripcion evento medico',
  `hcl_secreg_hcev` int(10) DEFAULT NULL COMMENT 'Numero secuencial del evento medico, generado desde el contador en registro maestro de historia clinica del paciente',
  `hcl_nrohis_hicl` varchar(20) DEFAULT NULL COMMENT 'Numero o código de la Ficha de Historias Clínicas (generado por el sistema)',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `fcm_secreg_dfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial único del registro desde servicios facturados del modulo Facturación (cuando aplique)',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `hcl_codaux_hcev` varchar(20) DEFAULT NULL COMMENT 'Codigo auxiliar requerido por algun registro de actividad (puede contener codigo unicos provenientes de otras tablas)',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se genero el registro para historial',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `hcl_sisfec_hcev` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando se genera registro del evento',
  `hcl_sishor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema al generar registro de evento en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_keydat_hcev` text COMMENT 'Palabras claves para usar como llaves de busqueda',
  `hcl_xmldat_hcev` mediumtext COMMENT 'Datos en formato XML diligenciados en el formato o plantilla (incluye imágenes y objetos vistas del muro)',
  `hcl_xmltmp_hcev` text COMMENT 'Datos en formato XML diligenciados guardados de manera temporal por el sistema como respaldo de digitacion',
  `hcl_xmlcom_hcev` text COMMENT 'Datos en formato XML comentarios realizados al registro',
  `hcl_conobj_hcev` int(6) DEFAULT NULL COMMENT 'Contador para generar Nombres unicos de objetos se agregan como etiquetas imágenes videos y otros',
  `hcl_archiv_hcev` varchar(2) DEFAULT NULL COMMENT 'Indica tipo destino guardado registro datos del evento XM=Formato XML 01=Grupo archivos01 02=Grupos archivos02 03=Grupos hasta ...10',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado de procesos en atencion asistencial : 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`hcl_nroreg_hcev`),
  KEY `hcev02` (`adm_secadm_rgad`),
  KEY `hcev03` (`hcl_nrohis_hicl`),
  KEY `hcev04` (`sia_idesec_usua`),
  KEY `hcev05` (`sia_nroide_usua`),
  KEY `hcev06` (`hcl_codaux_hcev`),
  KEY `hcev07` (`hcl_gesfec_hcev`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexcbo01` table : 
#

DROP TABLE IF EXISTS `hclregisexcbo01`;

CREATE TABLE `hclregisexcbo01` (
  `hcl_nroreg_hccb` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_cbo001_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 001',
  `hcl_cbd001_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 001',
  `hcl_cbo002_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 002',
  `hcl_cbd002_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 002',
  `hcl_cbo003_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 003',
  `hcl_cbd003_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 003',
  `hcl_cbo004_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 004',
  `hcl_cbd004_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 004',
  `hcl_cbo005_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 005',
  `hcl_cbd005_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 005',
  `hcl_cbo006_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 006',
  `hcl_cbd006_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 006',
  `hcl_cbo007_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 007',
  `hcl_cbd007_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 007',
  `hcl_cbo008_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 008',
  `hcl_cbd008_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 008',
  `hcl_cbo009_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 009',
  `hcl_cbd009_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 009',
  `hcl_cbo010_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 010',
  `hcl_cbd010_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 010',
  `hcl_cbo011_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 011',
  `hcl_cbd011_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 011',
  `hcl_cbo012_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 012',
  `hcl_cbd012_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 012',
  `hcl_cbo013_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 013',
  `hcl_cbd013_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 013',
  `hcl_cbo014_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 014',
  `hcl_cbd014_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 014',
  `hcl_cbo015_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 015',
  `hcl_cbd015_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 015',
  `hcl_cbo016_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 016',
  `hcl_cbd016_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 016',
  `hcl_cbo017_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 017',
  `hcl_cbd017_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 017',
  `hcl_cbo018_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 018',
  `hcl_cbd018_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 018',
  `hcl_cbo019_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 019',
  `hcl_cbd019_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 019',
  `hcl_cbo020_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 020',
  `hcl_cbd020_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 020',
  `hcl_cbo021_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 021',
  `hcl_cbd021_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 021',
  `hcl_cbo022_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 022',
  `hcl_cbd022_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 022',
  `hcl_cbo023_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 023',
  `hcl_cbd023_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 023',
  `hcl_cbo024_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 024',
  `hcl_cbd024_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 024',
  `hcl_cbo025_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 025',
  `hcl_cbd025_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 025',
  `hcl_cbo026_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 026',
  `hcl_cbd026_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 026',
  `hcl_cbo027_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 027',
  `hcl_cbd027_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 027',
  `hcl_cbo028_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 028',
  `hcl_cbd028_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 028',
  `hcl_cbo029_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 029',
  `hcl_cbd029_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 029',
  `hcl_cbo030_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 030',
  `hcl_cbd030_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 030',
  `hcl_cbo031_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 031',
  `hcl_cbd031_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 031',
  `hcl_cbo032_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 032',
  `hcl_cbd032_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 032',
  `hcl_cbo033_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 033',
  `hcl_cbd033_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 033',
  `hcl_cbo034_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 034',
  `hcl_cbd034_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 034',
  `hcl_cbo035_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 035',
  `hcl_cbd035_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 035',
  `hcl_cbo036_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 036',
  `hcl_cbd036_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 036',
  `hcl_cbo037_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 037',
  `hcl_cbd037_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 037',
  `hcl_cbo038_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 038',
  `hcl_cbd038_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 038',
  `hcl_cbo039_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 039',
  `hcl_cbd039_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 039',
  `hcl_cbo040_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 040',
  `hcl_cbd040_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 040',
  `hcl_cbo041_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 041',
  `hcl_cbd041_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 041',
  `hcl_cbo042_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 042',
  `hcl_cbd042_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 042',
  `hcl_cbo043_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 043',
  `hcl_cbd043_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 043',
  `hcl_cbo044_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 044',
  `hcl_cbd044_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 044',
  `hcl_cbo045_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 045',
  `hcl_cbd045_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 045',
  `hcl_cbo046_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 046',
  `hcl_cbd046_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 046',
  `hcl_cbo047_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 047',
  `hcl_cbd047_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 047',
  `hcl_cbo048_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 048',
  `hcl_cbd048_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 048',
  `hcl_cbo049_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 049',
  `hcl_cbd049_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 049',
  `hcl_cbo050_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 050',
  `hcl_cbd050_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 050',
  `hcl_cbo051_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 051',
  `hcl_cbd051_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 051',
  `hcl_cbo052_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 052',
  `hcl_cbd052_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 052',
  `hcl_cbo053_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 053',
  `hcl_cbd053_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 053',
  `hcl_cbo054_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 054',
  `hcl_cbd054_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 054',
  `hcl_cbo055_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 055',
  `hcl_cbd055_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 055',
  `hcl_cbo056_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 056',
  `hcl_cbd056_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 056',
  `hcl_cbo057_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 057',
  `hcl_cbd057_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 057',
  `hcl_cbo058_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 058',
  `hcl_cbd058_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 058',
  `hcl_cbo059_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 059',
  `hcl_cbd059_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 059',
  `hcl_cbo060_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 060',
  `hcl_cbd060_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 060',
  PRIMARY KEY (`hcl_nroreg_hccb`),
  KEY `hccb01x02` (`hcl_nroreg_hcev`),
  KEY `hccb01x03` (`grp_idepla_grpl`),
  KEY `hccb01x04` (`grp_idepla_grpv`),
  KEY `hccb01x05` (`hcl_codreg_hcca`),
  KEY `hccb01x06` (`adm_secadm_rgad`),
  KEY `hccb01x07` (`cit_codasi_mcit`),
  KEY `hccb01x08` (`fcm_codcpr_cpro`),
  KEY `hccb01x09` (`sia_idesec_usua`),
  KEY `hccb01x10` (`hcl_gesfec_hcev`),
  KEY `hccb01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexcbx01` table : 
#

DROP TABLE IF EXISTS `hclregisexcbx01`;

CREATE TABLE `hclregisexcbx01` (
  `hcl_nroreg_hcbx` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_cbo061_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 001',
  `hcl_cbd061_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 001',
  `hcl_cbo062_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 002',
  `hcl_cbd062_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 002',
  `hcl_cbo063_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 003',
  `hcl_cbd063_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 003',
  `hcl_cbo064_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 004',
  `hcl_cbd064_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 004',
  `hcl_cbo065_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 005',
  `hcl_cbd065_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 005',
  `hcl_cbo066_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 006',
  `hcl_cbd066_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 006',
  `hcl_cbo067_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 007',
  `hcl_cbd067_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 007',
  `hcl_cbo068_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 008',
  `hcl_cbd068_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 008',
  `hcl_cbo069_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 009',
  `hcl_cbd069_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 009',
  `hcl_cbo070_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 010',
  `hcl_cbd070_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 010',
  `hcl_cbo071_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 011',
  `hcl_cbd071_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 011',
  `hcl_cbo072_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 012',
  `hcl_cbd072_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 012',
  `hcl_cbo073_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 013',
  `hcl_cbd073_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 013',
  `hcl_cbo074_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 014',
  `hcl_cbd074_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 014',
  `hcl_cbo075_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 015',
  `hcl_cbd075_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 015',
  `hcl_cbo076_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 016',
  `hcl_cbd076_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 016',
  `hcl_cbo077_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 017',
  `hcl_cbd077_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 017',
  `hcl_cbo078_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 018',
  `hcl_cbd078_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 018',
  `hcl_cbo079_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 019',
  `hcl_cbd079_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 019',
  `hcl_cbo080_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 020',
  `hcl_cbd080_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 020',
  `hcl_cbo081_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 021',
  `hcl_cbd081_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 021',
  `hcl_cbo082_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 022',
  `hcl_cbd082_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 022',
  `hcl_cbo083_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 023',
  `hcl_cbd083_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 023',
  `hcl_cbo084_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 024',
  `hcl_cbd084_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 024',
  `hcl_cbo085_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 025',
  `hcl_cbd085_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 025',
  `hcl_cbo086_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 026',
  `hcl_cbd086_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 026',
  `hcl_cbo087_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 027',
  `hcl_cbd087_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 027',
  `hcl_cbo088_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 028',
  `hcl_cbd088_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 028',
  `hcl_cbo089_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 029',
  `hcl_cbd089_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 029',
  `hcl_cbo090_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 030',
  `hcl_cbd090_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 030',
  `hcl_cbo091_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 031',
  `hcl_cbd091_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 031',
  `hcl_cbo092_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 032',
  `hcl_cbd092_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 032',
  `hcl_cbo093_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 033',
  `hcl_cbd093_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 033',
  `hcl_cbo094_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 034',
  `hcl_cbd094_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 034',
  `hcl_cbo095_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 035',
  `hcl_cbd095_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 035',
  `hcl_cbo096_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 036',
  `hcl_cbd096_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 036',
  `hcl_cbo097_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 037',
  `hcl_cbd097_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 037',
  `hcl_cbo098_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 038',
  `hcl_cbd098_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 038',
  `hcl_cbo099_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 039',
  `hcl_cbd099_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 039',
  `hcl_cbo100_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 040',
  `hcl_cbd100_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 040',
  `hcl_cbo101_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 041',
  `hcl_cbd101_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 041',
  `hcl_cbo102_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 042',
  `hcl_cbd102_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 042',
  `hcl_cbo103_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 043',
  `hcl_cbd103_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 043',
  `hcl_cbo104_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 044',
  `hcl_cbd104_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 044',
  `hcl_cbo105_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 045',
  `hcl_cbd105_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 045',
  `hcl_cbo106_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 046',
  `hcl_cbd106_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 046',
  `hcl_cbo107_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 047',
  `hcl_cbd107_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 047',
  `hcl_cbo108_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 048',
  `hcl_cbd108_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 048',
  `hcl_cbo109_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 049',
  `hcl_cbd109_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 049',
  `hcl_cbo110_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 050',
  `hcl_cbd110_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 050',
  `hcl_cbo111_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 051',
  `hcl_cbd111_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 051',
  `hcl_cbo112_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 052',
  `hcl_cbd112_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 052',
  `hcl_cbo113_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 053',
  `hcl_cbd113_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 053',
  `hcl_cbo114_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 054',
  `hcl_cbd114_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 054',
  `hcl_cbo115_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 055',
  `hcl_cbd115_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 055',
  `hcl_cbo116_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 056',
  `hcl_cbd116_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 056',
  `hcl_cbo117_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 057',
  `hcl_cbd117_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 057',
  `hcl_cbo118_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 058',
  `hcl_cbd118_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 058',
  `hcl_cbo119_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 059',
  `hcl_cbd119_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 059',
  `hcl_cbo120_hccb` varchar(20) DEFAULT NULL COMMENT 'Campo Id o codigo ComboBox 060',
  `hcl_cbd120_hccb` varchar(90) DEFAULT NULL COMMENT 'Campo descripcion ComboBox 060',
  PRIMARY KEY (`hcl_nroreg_hcbx`),
  KEY `hcbx1x02` (`hcl_nroreg_hcev`),
  KEY `hcbx1x03` (`grp_idepla_grpl`),
  KEY `hcbx1x04` (`grp_idepla_grpv`),
  KEY `hcbx1x05` (`hcl_codreg_hcca`),
  KEY `hcbx1x06` (`adm_secadm_rgad`),
  KEY `hcbx1x07` (`cit_codasi_mcit`),
  KEY `hcbx1x08` (`fcm_codcpr_cpro`),
  KEY `hcbx1x09` (`sia_idesec_usua`),
  KEY `hcbx1x10` (`hcl_gesfec_hcev`),
  KEY `hcbx1x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexchk01` table : 
#

DROP TABLE IF EXISTS `hclregisexchk01`;

CREATE TABLE `hclregisexchk01` (
  `hcl_nroreg_hchk` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_chk001_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 001',
  `hcl_chk002_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 002',
  `hcl_chk003_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 003',
  `hcl_chk004_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 004',
  `hcl_chk005_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 005',
  `hcl_chk006_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 006',
  `hcl_chk007_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 007',
  `hcl_chk008_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 008',
  `hcl_chk009_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 009',
  `hcl_chk010_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 010',
  `hcl_chk011_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 011',
  `hcl_chk012_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 012',
  `hcl_chk013_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 013',
  `hcl_chk014_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 014',
  `hcl_chk015_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 015',
  `hcl_chk016_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 016',
  `hcl_chk017_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 017',
  `hcl_chk018_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 018',
  `hcl_chk019_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 019',
  `hcl_chk020_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 020',
  `hcl_chk021_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 021',
  `hcl_chk022_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 022',
  `hcl_chk023_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 023',
  `hcl_chk024_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 024',
  `hcl_chk025_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 025',
  `hcl_chk026_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 026',
  `hcl_chk027_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 027',
  `hcl_chk028_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 028',
  `hcl_chk029_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 029',
  `hcl_chk030_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 030',
  `hcl_chk031_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 031',
  `hcl_chk032_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 032',
  `hcl_chk033_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 033',
  `hcl_chk034_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 034',
  `hcl_chk035_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 035',
  `hcl_chk036_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 036',
  `hcl_chk037_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 037',
  `hcl_chk038_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 038',
  `hcl_chk039_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 039',
  `hcl_chk040_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 040',
  `hcl_chk041_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 041',
  `hcl_chk042_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 042',
  `hcl_chk043_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 043',
  `hcl_chk044_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 044',
  `hcl_chk045_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 045',
  `hcl_chk046_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 046',
  `hcl_chk047_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 047',
  `hcl_chk048_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 048',
  `hcl_chk049_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 049',
  `hcl_chk050_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 050',
  `hcl_chk051_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 051',
  `hcl_chk052_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 052',
  `hcl_chk053_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 053',
  `hcl_chk054_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 054',
  `hcl_chk055_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 055',
  `hcl_chk056_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 056',
  `hcl_chk057_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 057',
  `hcl_chk058_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 058',
  `hcl_chk059_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 059',
  `hcl_chk060_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 060',
  `hcl_chk061_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 061',
  `hcl_chk062_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 062',
  `hcl_chk063_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 063',
  `hcl_chk064_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 064',
  `hcl_chk065_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 065',
  `hcl_chk066_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 066',
  `hcl_chk067_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 067',
  `hcl_chk068_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 068',
  `hcl_chk069_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 069',
  `hcl_chk070_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 070',
  `hcl_chk071_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 071',
  `hcl_chk072_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 072',
  `hcl_chk073_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 073',
  `hcl_chk074_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 074',
  `hcl_chk075_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 075',
  `hcl_chk076_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 076',
  `hcl_chk077_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 077',
  `hcl_chk078_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 078',
  `hcl_chk079_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 079',
  `hcl_chk080_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 080',
  `hcl_chk081_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 081',
  `hcl_chk082_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 082',
  `hcl_chk083_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 083',
  `hcl_chk084_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 084',
  `hcl_chk085_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 085',
  `hcl_chk086_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 086',
  `hcl_chk087_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 087',
  `hcl_chk088_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 088',
  `hcl_chk089_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 089',
  `hcl_chk090_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 090',
  `hcl_chk091_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 091',
  `hcl_chk092_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 092',
  `hcl_chk093_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 093',
  `hcl_chk094_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 094',
  `hcl_chk095_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 095',
  `hcl_chk096_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 096',
  `hcl_chk097_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 097',
  `hcl_chk098_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 098',
  `hcl_chk099_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 099',
  `hcl_chk100_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 100',
  `hcl_chk101_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 101',
  `hcl_chk102_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 102',
  `hcl_chk103_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 103',
  `hcl_chk104_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 104',
  `hcl_chk105_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 105',
  `hcl_chk106_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 106',
  `hcl_chk107_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 107',
  `hcl_chk108_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 108',
  `hcl_chk109_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 109',
  `hcl_chk110_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 110',
  `hcl_chk111_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 111',
  `hcl_chk112_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 112',
  `hcl_chk113_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 113',
  `hcl_chk114_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 114',
  `hcl_chk115_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 115',
  `hcl_chk116_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 116',
  `hcl_chk117_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 117',
  `hcl_chk118_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 118',
  `hcl_chk119_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 119',
  `hcl_chk120_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 120',
  `hcl_chk121_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 121',
  `hcl_chk122_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 122',
  `hcl_chk123_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 123',
  `hcl_chk124_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 124',
  `hcl_chk125_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 125',
  `hcl_chk126_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 126',
  `hcl_chk127_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 127',
  `hcl_chk128_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 128',
  `hcl_chk129_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 129',
  `hcl_chk130_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 130',
  `hcl_chk131_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 131',
  `hcl_chk132_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 132',
  `hcl_chk133_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 133',
  `hcl_chk134_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 134',
  `hcl_chk135_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 135',
  `hcl_chk136_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 136',
  `hcl_chk137_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 137',
  `hcl_chk138_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 138',
  `hcl_chk139_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 139',
  `hcl_chk140_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 140',
  `hcl_chk141_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 141',
  `hcl_chk142_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 142',
  `hcl_chk143_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 143',
  `hcl_chk144_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 144',
  `hcl_chk145_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 145',
  `hcl_chk146_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 146',
  `hcl_chk147_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 147',
  `hcl_chk148_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 148',
  `hcl_chk149_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 149',
  `hcl_chk150_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 150',
  `hcl_chk151_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 151',
  `hcl_chk152_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 152',
  `hcl_chk153_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 153',
  `hcl_chk154_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 154',
  `hcl_chk155_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 155',
  `hcl_chk156_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 156',
  `hcl_chk157_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 157',
  `hcl_chk158_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 158',
  `hcl_chk159_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 159',
  `hcl_chk160_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 160',
  `hcl_chk161_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 161',
  `hcl_chk162_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 162',
  `hcl_chk163_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 163',
  `hcl_chk164_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 164',
  `hcl_chk165_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 165',
  `hcl_chk166_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 166',
  `hcl_chk167_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 167',
  `hcl_chk168_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 168',
  `hcl_chk169_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 169',
  `hcl_chk170_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 170',
  `hcl_chk171_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 171',
  `hcl_chk172_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 172',
  `hcl_chk173_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 173',
  `hcl_chk174_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 174',
  `hcl_chk175_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 175',
  `hcl_chk176_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 176',
  `hcl_chk177_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 177',
  `hcl_chk178_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 178',
  `hcl_chk179_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 179',
  `hcl_chk180_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 180',
  `hcl_chk181_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 181',
  `hcl_chk182_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 182',
  `hcl_chk183_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 183',
  `hcl_chk184_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 184',
  `hcl_chk185_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 185',
  `hcl_chk186_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 186',
  `hcl_chk187_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 187',
  `hcl_chk188_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 188',
  `hcl_chk189_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 189',
  `hcl_chk190_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 190',
  `hcl_chk191_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 191',
  `hcl_chk192_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 192',
  `hcl_chk193_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 193',
  `hcl_chk194_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 194',
  `hcl_chk195_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 195',
  `hcl_chk196_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 196',
  `hcl_chk197_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 197',
  `hcl_chk198_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 198',
  `hcl_chk199_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 199',
  `hcl_chk200_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 200',
  `hcl_chk201_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 201',
  `hcl_chk202_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 202',
  `hcl_chk203_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 203',
  `hcl_chk204_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 204',
  `hcl_chk205_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 205',
  `hcl_chk206_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 206',
  `hcl_chk207_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 207',
  `hcl_chk208_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 208',
  `hcl_chk209_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 209',
  `hcl_chk210_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 210',
  `hcl_chk211_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 211',
  `hcl_chk212_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 212',
  `hcl_chk213_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 213',
  `hcl_chk214_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 214',
  `hcl_chk215_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 215',
  `hcl_chk216_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 216',
  `hcl_chk217_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 217',
  `hcl_chk218_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 218',
  `hcl_chk219_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 219',
  `hcl_chk220_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 220',
  PRIMARY KEY (`hcl_nroreg_hchk`),
  KEY `hchk01x02` (`hcl_nroreg_hcev`),
  KEY `hchk01x03` (`grp_idepla_grpl`),
  KEY `hchk01x04` (`grp_idepla_grpv`),
  KEY `hchk01x05` (`hcl_codreg_hcca`),
  KEY `hchk01x06` (`adm_secadm_rgad`),
  KEY `hchk01x07` (`cit_codasi_mcit`),
  KEY `hchk01x08` (`fcm_codcpr_cpro`),
  KEY `hchk01x09` (`sia_idesec_usua`),
  KEY `hchk01x10` (`hcl_gesfec_hcev`),
  KEY `hchk01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexchl01` table : 
#

DROP TABLE IF EXISTS `hclregisexchl01`;

CREATE TABLE `hclregisexchl01` (
  `hcl_nroreg_hchl` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_chk221_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 221',
  `hcl_chk222_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 222',
  `hcl_chk223_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 223',
  `hcl_chk224_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 224',
  `hcl_chk225_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 225',
  `hcl_chk226_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 226',
  `hcl_chk227_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 227',
  `hcl_chk228_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 228',
  `hcl_chk229_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 229',
  `hcl_chk230_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 230',
  `hcl_chk231_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 231',
  `hcl_chk232_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 232',
  `hcl_chk233_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 233',
  `hcl_chk234_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 234',
  `hcl_chk235_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 235',
  `hcl_chk236_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 236',
  `hcl_chk237_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 237',
  `hcl_chk238_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 238',
  `hcl_chk239_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 239',
  `hcl_chk240_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 240',
  `hcl_chk241_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 241',
  `hcl_chk242_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 242',
  `hcl_chk243_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 243',
  `hcl_chk244_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 244',
  `hcl_chk245_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 245',
  `hcl_chk246_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 246',
  `hcl_chk247_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 247',
  `hcl_chk248_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 248',
  `hcl_chk249_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 249',
  `hcl_chk250_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 250',
  `hcl_chk251_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 251',
  `hcl_chk252_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 252',
  `hcl_chk253_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 253',
  `hcl_chk254_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 254',
  `hcl_chk255_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 255',
  `hcl_chk256_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 256',
  `hcl_chk257_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 257',
  `hcl_chk258_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 258',
  `hcl_chk259_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 259',
  `hcl_chk260_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 260',
  `hcl_chk261_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 261',
  `hcl_chk262_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 262',
  `hcl_chk263_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 263',
  `hcl_chk264_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 264',
  `hcl_chk265_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 265',
  `hcl_chk266_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 266',
  `hcl_chk267_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 267',
  `hcl_chk268_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 268',
  `hcl_chk269_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 269',
  `hcl_chk270_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 270',
  `hcl_chk271_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 271',
  `hcl_chk272_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 272',
  `hcl_chk273_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 273',
  `hcl_chk274_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 274',
  `hcl_chk275_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 275',
  `hcl_chk276_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 276',
  `hcl_chk277_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 277',
  `hcl_chk278_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 278',
  `hcl_chk279_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 279',
  `hcl_chk280_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 280',
  `hcl_chk281_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 281',
  `hcl_chk282_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 282',
  `hcl_chk283_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 283',
  `hcl_chk284_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 284',
  `hcl_chk285_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 285',
  `hcl_chk286_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 286',
  `hcl_chk287_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 287',
  `hcl_chk288_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 288',
  `hcl_chk289_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 289',
  `hcl_chk290_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 290',
  `hcl_chk291_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 291',
  `hcl_chk292_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 292',
  `hcl_chk293_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 293',
  `hcl_chk294_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 294',
  `hcl_chk295_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 295',
  `hcl_chk296_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 296',
  `hcl_chk297_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 297',
  `hcl_chk298_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 298',
  `hcl_chk299_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 299',
  `hcl_chk300_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 300',
  `hcl_chk301_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 301',
  `hcl_chk302_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 302',
  `hcl_chk303_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 303',
  `hcl_chk304_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 304',
  `hcl_chk305_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 305',
  `hcl_chk306_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 306',
  `hcl_chk307_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 307',
  `hcl_chk308_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 308',
  `hcl_chk309_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 309',
  `hcl_chk310_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 310',
  `hcl_chk311_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 311',
  `hcl_chk312_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 312',
  `hcl_chk313_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 313',
  `hcl_chk314_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 314',
  `hcl_chk315_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 315',
  `hcl_chk316_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 316',
  `hcl_chk317_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 317',
  `hcl_chk318_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 318',
  `hcl_chk319_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 319',
  `hcl_chk320_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 320',
  `hcl_chk321_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 321',
  `hcl_chk322_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 322',
  `hcl_chk323_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 323',
  `hcl_chk324_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 324',
  `hcl_chk325_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 325',
  `hcl_chk326_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 326',
  `hcl_chk327_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 327',
  `hcl_chk328_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 328',
  `hcl_chk329_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 329',
  `hcl_chk330_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 330',
  `hcl_chk331_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 331',
  `hcl_chk332_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 332',
  `hcl_chk333_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 333',
  `hcl_chk334_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 334',
  `hcl_chk335_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 335',
  `hcl_chk336_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 336',
  `hcl_chk337_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 337',
  `hcl_chk338_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 338',
  `hcl_chk339_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 339',
  `hcl_chk340_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 340',
  `hcl_chk341_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 341',
  `hcl_chk342_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 342',
  `hcl_chk343_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 343',
  `hcl_chk344_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 344',
  `hcl_chk345_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 345',
  `hcl_chk346_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 346',
  `hcl_chk347_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 347',
  `hcl_chk348_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 348',
  `hcl_chk349_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 349',
  `hcl_chk350_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 350',
  `hcl_chk351_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 351',
  `hcl_chk352_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 352',
  `hcl_chk353_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 353',
  `hcl_chk354_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 354',
  `hcl_chk355_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 355',
  `hcl_chk356_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 356',
  `hcl_chk357_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 357',
  `hcl_chk358_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 358',
  `hcl_chk359_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 359',
  `hcl_chk360_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 360',
  `hcl_chk361_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 361',
  `hcl_chk362_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 362',
  `hcl_chk363_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 363',
  `hcl_chk364_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 364',
  `hcl_chk365_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 365',
  `hcl_chk366_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 366',
  `hcl_chk367_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 367',
  `hcl_chk368_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 368',
  `hcl_chk369_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 369',
  `hcl_chk370_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 370',
  `hcl_chk371_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 371',
  `hcl_chk372_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 372',
  `hcl_chk373_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 373',
  `hcl_chk374_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 374',
  `hcl_chk375_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 375',
  `hcl_chk376_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 376',
  `hcl_chk377_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 377',
  `hcl_chk378_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 378',
  `hcl_chk379_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 379',
  `hcl_chk380_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 380',
  `hcl_chk381_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 381',
  `hcl_chk382_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 382',
  `hcl_chk383_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 383',
  `hcl_chk384_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 384',
  `hcl_chk385_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 385',
  `hcl_chk386_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 386',
  `hcl_chk387_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 387',
  `hcl_chk388_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 388',
  `hcl_chk389_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 389',
  `hcl_chk390_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 390',
  `hcl_chk391_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 391',
  `hcl_chk392_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 392',
  `hcl_chk393_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 393',
  `hcl_chk394_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 394',
  `hcl_chk395_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 395',
  `hcl_chk396_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 396',
  `hcl_chk397_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 397',
  `hcl_chk398_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 398',
  `hcl_chk399_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 399',
  `hcl_chk400_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 400',
  `hcl_chk401_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 401',
  `hcl_chk402_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 402',
  `hcl_chk403_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 403',
  `hcl_chk404_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 404',
  `hcl_chk405_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 405',
  `hcl_chk406_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 406',
  `hcl_chk407_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 407',
  `hcl_chk408_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 408',
  `hcl_chk409_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 409',
  `hcl_chk410_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 410',
  `hcl_chk411_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 411',
  `hcl_chk412_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 412',
  `hcl_chk413_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 413',
  `hcl_chk414_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 414',
  `hcl_chk415_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 415',
  `hcl_chk416_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 416',
  `hcl_chk417_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 417',
  `hcl_chk418_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 418',
  `hcl_chk419_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 419',
  `hcl_chk420_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 420',
  `hcl_chk421_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 421',
  `hcl_chk422_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 422',
  `hcl_chk423_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 423',
  `hcl_chk424_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 424',
  `hcl_chk425_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 425',
  `hcl_chk426_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 426',
  `hcl_chk427_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 427',
  `hcl_chk428_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 428',
  `hcl_chk429_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 429',
  `hcl_chk430_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 430',
  `hcl_chk431_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 431',
  `hcl_chk432_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 432',
  `hcl_chk433_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 433',
  `hcl_chk434_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 434',
  `hcl_chk435_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 435',
  `hcl_chk436_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 436',
  `hcl_chk437_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 437',
  `hcl_chk438_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 438',
  `hcl_chk439_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 439',
  `hcl_chk440_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 440',
  PRIMARY KEY (`hcl_nroreg_hchl`),
  KEY `hchl01x02` (`hcl_nroreg_hcev`),
  KEY `hchl01x03` (`grp_idepla_grpl`),
  KEY `hchl01x04` (`grp_idepla_grpv`),
  KEY `hchl01x05` (`hcl_codreg_hcca`),
  KEY `hchl01x06` (`adm_secadm_rgad`),
  KEY `hchl01x07` (`cit_codasi_mcit`),
  KEY `hchl01x08` (`fcm_codcpr_cpro`),
  KEY `hchl01x09` (`sia_idesec_usua`),
  KEY `hchl01x10` (`hcl_gesfec_hcev`),
  KEY `hchl01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexchm01` table : 
#

DROP TABLE IF EXISTS `hclregisexchm01`;

CREATE TABLE `hclregisexchm01` (
  `hcl_nroreg_hchm` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_chk441_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 441',
  `hcl_chk442_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 442',
  `hcl_chk443_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 443',
  `hcl_chk444_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 444',
  `hcl_chk445_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 445',
  `hcl_chk446_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 446',
  `hcl_chk447_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 447',
  `hcl_chk448_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 448',
  `hcl_chk449_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 449',
  `hcl_chk450_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 450',
  `hcl_chk451_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 451',
  `hcl_chk452_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 452',
  `hcl_chk453_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 453',
  `hcl_chk454_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 454',
  `hcl_chk455_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 455',
  `hcl_chk456_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 456',
  `hcl_chk457_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 457',
  `hcl_chk458_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 458',
  `hcl_chk459_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 459',
  `hcl_chk460_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 460',
  `hcl_chk461_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 461',
  `hcl_chk462_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 462',
  `hcl_chk463_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 463',
  `hcl_chk464_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 464',
  `hcl_chk465_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 465',
  `hcl_chk466_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 466',
  `hcl_chk467_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 467',
  `hcl_chk468_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 468',
  `hcl_chk469_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 469',
  `hcl_chk470_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 470',
  `hcl_chk471_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 471',
  `hcl_chk472_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 472',
  `hcl_chk473_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 473',
  `hcl_chk474_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 474',
  `hcl_chk475_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 475',
  `hcl_chk476_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 476',
  `hcl_chk477_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 477',
  `hcl_chk478_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 478',
  `hcl_chk479_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 479',
  `hcl_chk480_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 480',
  `hcl_chk481_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 481',
  `hcl_chk482_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 482',
  `hcl_chk483_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 483',
  `hcl_chk484_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 484',
  `hcl_chk485_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 485',
  `hcl_chk486_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 486',
  `hcl_chk487_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 487',
  `hcl_chk488_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 488',
  `hcl_chk489_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 489',
  `hcl_chk490_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 490',
  `hcl_chk491_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 491',
  `hcl_chk492_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 492',
  `hcl_chk493_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 493',
  `hcl_chk494_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 494',
  `hcl_chk495_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 495',
  `hcl_chk496_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 496',
  `hcl_chk497_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 497',
  `hcl_chk498_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 498',
  `hcl_chk499_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 499',
  `hcl_chk500_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 500',
  `hcl_chk501_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 501',
  `hcl_chk502_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 502',
  `hcl_chk503_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 503',
  `hcl_chk504_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 504',
  `hcl_chk505_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 505',
  `hcl_chk506_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 506',
  `hcl_chk507_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 507',
  `hcl_chk508_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 508',
  `hcl_chk509_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 509',
  `hcl_chk510_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 510',
  `hcl_chk511_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 511',
  `hcl_chk512_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 512',
  `hcl_chk513_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 513',
  `hcl_chk514_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 514',
  `hcl_chk515_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 515',
  `hcl_chk516_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 516',
  `hcl_chk517_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 517',
  `hcl_chk518_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 518',
  `hcl_chk519_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 519',
  `hcl_chk520_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 520',
  `hcl_chk521_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 521',
  `hcl_chk522_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 522',
  `hcl_chk523_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 523',
  `hcl_chk524_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 524',
  `hcl_chk525_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 525',
  `hcl_chk526_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 526',
  `hcl_chk527_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 527',
  `hcl_chk528_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 528',
  `hcl_chk529_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 529',
  `hcl_chk530_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 530',
  `hcl_chk531_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 531',
  `hcl_chk532_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 532',
  `hcl_chk533_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 533',
  `hcl_chk534_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 534',
  `hcl_chk535_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 535',
  `hcl_chk536_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 536',
  `hcl_chk537_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 537',
  `hcl_chk538_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 538',
  `hcl_chk539_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 539',
  `hcl_chk540_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 540',
  `hcl_chk541_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 541',
  `hcl_chk542_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 542',
  `hcl_chk543_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 543',
  `hcl_chk544_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 544',
  `hcl_chk545_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 545',
  `hcl_chk546_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 546',
  `hcl_chk547_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 547',
  `hcl_chk548_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 548',
  `hcl_chk549_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 549',
  `hcl_chk550_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 550',
  `hcl_chk551_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 551',
  `hcl_chk552_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 552',
  `hcl_chk553_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 553',
  `hcl_chk554_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 554',
  `hcl_chk555_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 555',
  `hcl_chk556_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 556',
  `hcl_chk557_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 557',
  `hcl_chk558_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 558',
  `hcl_chk559_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 559',
  `hcl_chk560_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 560',
  `hcl_chk561_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 561',
  `hcl_chk562_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 562',
  `hcl_chk563_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 563',
  `hcl_chk564_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 564',
  `hcl_chk565_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 565',
  `hcl_chk566_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 566',
  `hcl_chk567_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 567',
  `hcl_chk568_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 568',
  `hcl_chk569_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 569',
  `hcl_chk570_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 570',
  `hcl_chk571_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 571',
  `hcl_chk572_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 572',
  `hcl_chk573_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 573',
  `hcl_chk574_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 574',
  `hcl_chk575_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 575',
  `hcl_chk576_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 576',
  `hcl_chk577_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 577',
  `hcl_chk578_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 578',
  `hcl_chk579_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 579',
  `hcl_chk580_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 580',
  `hcl_chk581_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 581',
  `hcl_chk582_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 582',
  `hcl_chk583_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 583',
  `hcl_chk584_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 584',
  `hcl_chk585_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 585',
  `hcl_chk586_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 586',
  `hcl_chk587_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 587',
  `hcl_chk588_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 588',
  `hcl_chk589_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 589',
  `hcl_chk590_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 590',
  `hcl_chk591_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 591',
  `hcl_chk592_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 592',
  `hcl_chk593_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 593',
  `hcl_chk594_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 594',
  `hcl_chk595_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 595',
  `hcl_chk596_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 596',
  `hcl_chk597_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 597',
  `hcl_chk598_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 598',
  `hcl_chk599_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 599',
  `hcl_chk600_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 600',
  `hcl_chk601_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 601',
  `hcl_chk602_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 602',
  `hcl_chk603_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 603',
  `hcl_chk604_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 604',
  `hcl_chk605_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 605',
  `hcl_chk606_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 606',
  `hcl_chk607_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 607',
  `hcl_chk608_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 608',
  `hcl_chk609_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 609',
  `hcl_chk610_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 610',
  `hcl_chk611_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 611',
  `hcl_chk612_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 612',
  `hcl_chk613_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 613',
  `hcl_chk614_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 614',
  `hcl_chk615_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 615',
  `hcl_chk616_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 616',
  `hcl_chk617_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 617',
  `hcl_chk618_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 618',
  `hcl_chk619_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 619',
  `hcl_chk620_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 620',
  `hcl_chk621_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 621',
  `hcl_chk622_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 622',
  `hcl_chk623_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 623',
  `hcl_chk624_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 624',
  `hcl_chk625_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 625',
  `hcl_chk626_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 626',
  `hcl_chk627_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 627',
  `hcl_chk628_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 628',
  `hcl_chk629_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 629',
  `hcl_chk630_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 630',
  `hcl_chk631_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 631',
  `hcl_chk632_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 632',
  `hcl_chk633_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 633',
  `hcl_chk634_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 634',
  `hcl_chk635_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 635',
  `hcl_chk636_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 636',
  `hcl_chk637_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 637',
  `hcl_chk638_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 638',
  `hcl_chk639_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 639',
  `hcl_chk640_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 640',
  `hcl_chk641_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 641',
  `hcl_chk642_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 642',
  `hcl_chk643_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 643',
  `hcl_chk644_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 644',
  `hcl_chk645_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 645',
  `hcl_chk646_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 646',
  `hcl_chk647_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 647',
  `hcl_chk648_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 648',
  `hcl_chk649_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 649',
  `hcl_chk650_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 650',
  `hcl_chk651_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 651',
  `hcl_chk652_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 652',
  `hcl_chk653_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 653',
  `hcl_chk654_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 654',
  `hcl_chk655_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 655',
  `hcl_chk656_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 656',
  `hcl_chk657_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 657',
  `hcl_chk658_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 658',
  `hcl_chk659_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 659',
  `hcl_chk660_hchk` varchar(1) DEFAULT NULL COMMENT 'Campo estado seleccion del checkbox 1=Seleccionado 660',
  PRIMARY KEY (`hcl_nroreg_hchm`),
  KEY `hchm01x02` (`hcl_nroreg_hcev`),
  KEY `hchm01x03` (`grp_idepla_grpl`),
  KEY `hchm01x04` (`grp_idepla_grpv`),
  KEY `hchm01x05` (`hcl_codreg_hcca`),
  KEY `hchm01x06` (`adm_secadm_rgad`),
  KEY `hchm01x07` (`cit_codasi_mcit`),
  KEY `hchm01x08` (`fcm_codcpr_cpro`),
  KEY `hchm01x09` (`sia_idesec_usua`),
  KEY `hchm01x10` (`hcl_gesfec_hcev`),
  KEY `hchm01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexfec01` table : 
#

DROP TABLE IF EXISTS `hclregisexfec01`;

CREATE TABLE `hclregisexfec01` (
  `hcl_nroreg_hcfc` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_fec001_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 001',
  `hcl_fec002_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 002',
  `hcl_fec003_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 003',
  `hcl_fec004_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 004',
  `hcl_fec005_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 005',
  `hcl_fec006_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 006',
  `hcl_fec007_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 007',
  `hcl_fec008_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 008',
  `hcl_fec009_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 009',
  `hcl_fec010_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 010',
  `hcl_fec011_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 011',
  `hcl_fec012_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 012',
  `hcl_fec013_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 013',
  `hcl_fec014_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 014',
  `hcl_fec015_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 015',
  `hcl_fec016_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 016',
  `hcl_fec017_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 017',
  `hcl_fec018_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 018',
  `hcl_fec019_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 019',
  `hcl_fec020_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 020',
  `hcl_fec021_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 021',
  `hcl_fec022_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 022',
  `hcl_fec023_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 023',
  `hcl_fec024_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 024',
  `hcl_fec025_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 025',
  `hcl_fec026_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 026',
  `hcl_fec027_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 027',
  `hcl_fec028_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 028',
  `hcl_fec029_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 029',
  `hcl_fec030_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 030',
  `hcl_fec031_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 031',
  `hcl_fec032_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 032',
  `hcl_fec033_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 033',
  `hcl_fec034_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 034',
  `hcl_fec035_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 035',
  `hcl_fec036_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 036',
  `hcl_fec037_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 037',
  `hcl_fec038_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 038',
  `hcl_fec039_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 039',
  `hcl_fec040_hcfc` varchar(20) DEFAULT NULL COMMENT 'Campo tipo fecha 040',
  PRIMARY KEY (`hcl_nroreg_hcfc`),
  KEY `hcfc01x02` (`hcl_nroreg_hcev`),
  KEY `hcfc01x03` (`grp_idepla_grpl`),
  KEY `hcfc01x04` (`grp_idepla_grpv`),
  KEY `hcfc01x05` (`hcl_codreg_hcca`),
  KEY `hcfc01x06` (`adm_secadm_rgad`),
  KEY `hcfc01x07` (`cit_codasi_mcit`),
  KEY `hcfc01x08` (`fcm_codcpr_cpro`),
  KEY `hcfc01x09` (`sia_idesec_usua`),
  KEY `hcfc01x10` (`hcl_gesfec_hcev`),
  KEY `hcfc01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexmem01` table : 
#

DROP TABLE IF EXISTS `hclregisexmem01`;

CREATE TABLE `hclregisexmem01` (
  `hcl_nroreg_hcme` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_rix001_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  001',
  `hcl_rix002_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  002',
  `hcl_rix003_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  003',
  `hcl_rix004_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  004',
  `hcl_rix005_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  005',
  `hcl_rix006_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  006',
  `hcl_rix007_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  007',
  `hcl_rix008_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  008',
  `hcl_rix009_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  009',
  `hcl_rix010_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  010',
  `hcl_rix011_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  011',
  `hcl_rix012_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  012',
  `hcl_rix013_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  013',
  `hcl_rix014_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  014',
  `hcl_rix015_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  015',
  `hcl_rix016_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  016',
  `hcl_rix017_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  017',
  `hcl_rix018_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  018',
  `hcl_rix019_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  019',
  `hcl_rix020_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  020',
  `hcl_rix021_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  021',
  `hcl_rix022_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  022',
  `hcl_rix023_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  023',
  `hcl_rix024_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  024',
  `hcl_rix025_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  025',
  `hcl_rix026_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  026',
  `hcl_rix027_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  027',
  `hcl_rix028_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  028',
  `hcl_rix029_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  029',
  `hcl_rix030_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  030',
  PRIMARY KEY (`hcl_nroreg_hcme`),
  KEY `hcme01x02` (`hcl_nroreg_hcev`),
  KEY `hcme01x03` (`grp_idepla_grpl`),
  KEY `hcme01x04` (`grp_idepla_grpv`),
  KEY `hcme01x05` (`hcl_codreg_hcca`),
  KEY `hcme01x06` (`adm_secadm_rgad`),
  KEY `hcme01x07` (`cit_codasi_mcit`),
  KEY `hcme01x08` (`fcm_codcpr_cpro`),
  KEY `hcme01x09` (`sia_idesec_usua`),
  KEY `hcme01x10` (`hcl_gesfec_hcev`),
  KEY `hcme01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexmen01` table : 
#

DROP TABLE IF EXISTS `hclregisexmen01`;

CREATE TABLE `hclregisexmen01` (
  `hcl_nroreg_hcmn` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_rix031_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  031',
  `hcl_rix032_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  032',
  `hcl_rix033_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  033',
  `hcl_rix034_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  034',
  `hcl_rix035_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  035',
  `hcl_rix036_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  036',
  `hcl_rix037_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  037',
  `hcl_rix038_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  038',
  `hcl_rix039_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  039',
  `hcl_rix040_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  040',
  `hcl_rix041_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  041',
  `hcl_rix042_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  042',
  `hcl_rix043_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  043',
  `hcl_rix044_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  044',
  `hcl_rix045_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  045',
  `hcl_rix046_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  046',
  `hcl_rix047_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  047',
  `hcl_rix048_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  048',
  `hcl_rix049_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  049',
  `hcl_rix050_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  050',
  `hcl_rix051_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  051',
  `hcl_rix052_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  052',
  `hcl_rix053_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  053',
  `hcl_rix054_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  054',
  `hcl_rix055_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  055',
  `hcl_rix056_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  056',
  `hcl_rix057_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  057',
  `hcl_rix058_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  058',
  `hcl_rix059_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  059',
  `hcl_rix060_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  060',
  PRIMARY KEY (`hcl_nroreg_hcmn`),
  KEY `hcmn01x02` (`hcl_nroreg_hcev`),
  KEY `hcmn01x03` (`grp_idepla_grpl`),
  KEY `hcmn01x04` (`grp_idepla_grpv`),
  KEY `hcmn01x05` (`hcl_codreg_hcca`),
  KEY `hcmn01x06` (`adm_secadm_rgad`),
  KEY `hcmn01x07` (`cit_codasi_mcit`),
  KEY `hcmn01x08` (`fcm_codcpr_cpro`),
  KEY `hcmn01x09` (`sia_idesec_usua`),
  KEY `hcmn01x10` (`hcl_gesfec_hcev`),
  KEY `hcmn01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexmeo01` table : 
#

DROP TABLE IF EXISTS `hclregisexmeo01`;

CREATE TABLE `hclregisexmeo01` (
  `hcl_nroreg_hcmo` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_rix061_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  061',
  `hcl_rix062_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  062',
  `hcl_rix063_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  063',
  `hcl_rix064_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  064',
  `hcl_rix065_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  065',
  `hcl_rix066_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  066',
  `hcl_rix067_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  067',
  `hcl_rix068_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  068',
  `hcl_rix069_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  069',
  `hcl_rix070_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  070',
  `hcl_rix071_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  071',
  `hcl_rix072_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  072',
  `hcl_rix073_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  073',
  `hcl_rix074_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  074',
  `hcl_rix075_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  075',
  `hcl_rix076_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  076',
  `hcl_rix077_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  077',
  `hcl_rix078_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  078',
  `hcl_rix079_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  079',
  `hcl_rix080_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  080',
  `hcl_rix081_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  081',
  `hcl_rix082_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  082',
  `hcl_rix083_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  083',
  `hcl_rix084_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  084',
  `hcl_rix085_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  085',
  `hcl_rix086_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  086',
  `hcl_rix087_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  087',
  `hcl_rix088_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  088',
  `hcl_rix089_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  089',
  `hcl_rix090_hcrt` text COMMENT 'Campo tipo texto largo (memo) para gestion con el editor  090',
  PRIMARY KEY (`hcl_nroreg_hcmo`),
  KEY `hcmo01x02` (`hcl_nroreg_hcev`),
  KEY `hcmo01x03` (`grp_idepla_grpl`),
  KEY `hcmo01x04` (`grp_idepla_grpv`),
  KEY `hcmo01x05` (`hcl_codreg_hcca`),
  KEY `hcmo01x06` (`adm_secadm_rgad`),
  KEY `hcmo01x07` (`cit_codasi_mcit`),
  KEY `hcmo01x08` (`fcm_codcpr_cpro`),
  KEY `hcmo01x09` (`sia_idesec_usua`),
  KEY `hcmo01x10` (`hcl_gesfec_hcev`),
  KEY `hcmo01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexnum01` table : 
#

DROP TABLE IF EXISTS `hclregisexnum01`;

CREATE TABLE `hclregisexnum01` (
  `hcl_nroreg_hcnu` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_val001_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 001',
  `hcl_val002_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 002',
  `hcl_val003_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 003',
  `hcl_val004_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 004',
  `hcl_val005_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 005',
  `hcl_val006_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 006',
  `hcl_val007_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 007',
  `hcl_val008_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 008',
  `hcl_val009_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 009',
  `hcl_val010_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 010',
  `hcl_val011_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 011',
  `hcl_val012_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 012',
  `hcl_val013_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 013',
  `hcl_val014_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 014',
  `hcl_val015_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 015',
  `hcl_val016_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 016',
  `hcl_val017_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 017',
  `hcl_val018_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 018',
  `hcl_val019_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 019',
  `hcl_val020_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 020',
  `hcl_val021_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 021',
  `hcl_val022_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 022',
  `hcl_val023_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 023',
  `hcl_val024_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 024',
  `hcl_val025_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 025',
  `hcl_val026_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 026',
  `hcl_val027_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 027',
  `hcl_val028_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 028',
  `hcl_val029_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 029',
  `hcl_val030_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 030',
  `hcl_val031_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 031',
  `hcl_val032_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 032',
  `hcl_val033_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 033',
  `hcl_val034_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 034',
  `hcl_val035_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 035',
  `hcl_val036_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 036',
  `hcl_val037_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 037',
  `hcl_val038_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 038',
  `hcl_val039_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 039',
  `hcl_val040_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 040',
  `hcl_val041_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 041',
  `hcl_val042_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 042',
  `hcl_val043_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 043',
  `hcl_val044_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 044',
  `hcl_val045_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 045',
  `hcl_val046_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 046',
  `hcl_val047_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 047',
  `hcl_val048_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 048',
  `hcl_val049_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 049',
  `hcl_val050_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 050',
  `hcl_val051_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 051',
  `hcl_val052_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 052',
  `hcl_val053_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 053',
  `hcl_val054_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 054',
  `hcl_val055_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 055',
  `hcl_val056_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 056',
  `hcl_val057_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 057',
  `hcl_val058_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 058',
  `hcl_val059_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 059',
  `hcl_val060_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 060',
  `hcl_val061_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 061',
  `hcl_val062_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 062',
  `hcl_val063_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 063',
  `hcl_val064_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 064',
  `hcl_val065_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 065',
  `hcl_val066_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 066',
  `hcl_val067_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 067',
  `hcl_val068_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 068',
  `hcl_val069_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 069',
  `hcl_val070_hcnu` varchar(20) DEFAULT NULL COMMENT 'Campo numerico/decimal/hora 070',
  PRIMARY KEY (`hcl_nroreg_hcnu`),
  KEY `hcnu01x02` (`hcl_nroreg_hcev`),
  KEY `hcnu01x03` (`grp_idepla_grpl`),
  KEY `hcnu01x04` (`grp_idepla_grpv`),
  KEY `hcnu01x05` (`hcl_codreg_hcca`),
  KEY `hcnu01x06` (`adm_secadm_rgad`),
  KEY `hcnu01x07` (`cit_codasi_mcit`),
  KEY `hcnu01x08` (`fcm_codcpr_cpro`),
  KEY `hcnu01x09` (`sia_idesec_usua`),
  KEY `hcnu01x10` (`hcl_gesfec_hcev`),
  KEY `hcnu01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexrbm01` table : 
#

DROP TABLE IF EXISTS `hclregisexrbm01`;

CREATE TABLE `hclregisexrbm01` (
  `hcl_nroreg_hcbm` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_ide061_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 061',
  `hcl_des061_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 061',
  `hcl_ide062_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 062',
  `hcl_des062_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 062',
  `hcl_ide063_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 063',
  `hcl_des063_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 063',
  `hcl_ide064_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 064',
  `hcl_des064_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 064',
  `hcl_ide065_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 065',
  `hcl_des065_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 065',
  `hcl_ide066_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 066',
  `hcl_des066_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 066',
  `hcl_ide067_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 067',
  `hcl_des067_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 067',
  `hcl_ide068_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 068',
  `hcl_des068_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 068',
  `hcl_ide069_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 069',
  `hcl_des069_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 069',
  `hcl_ide070_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 070',
  `hcl_des070_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 070',
  `hcl_ide071_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 071',
  `hcl_des071_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 071',
  `hcl_ide072_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 072',
  `hcl_des072_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 072',
  `hcl_ide073_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 073',
  `hcl_des073_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 073',
  `hcl_ide074_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 074',
  `hcl_des074_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 074',
  `hcl_ide075_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 075',
  `hcl_des075_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 075',
  `hcl_ide076_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 076',
  `hcl_des076_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 076',
  `hcl_ide077_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 077',
  `hcl_des077_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 077',
  `hcl_ide078_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 078',
  `hcl_des078_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 078',
  `hcl_ide079_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 079',
  `hcl_des079_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 079',
  `hcl_ide080_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 080',
  `hcl_des080_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 080',
  `hcl_ide081_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 081',
  `hcl_des081_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 081',
  `hcl_ide082_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 082',
  `hcl_des082_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 082',
  `hcl_ide083_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 083',
  `hcl_des083_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 083',
  `hcl_ide084_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 084',
  `hcl_des084_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 084',
  `hcl_ide085_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 085',
  `hcl_des085_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 085',
  `hcl_ide086_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 086',
  `hcl_des086_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 086',
  `hcl_ide087_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 087',
  `hcl_des087_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 087',
  `hcl_ide088_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 088',
  `hcl_des088_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 088',
  `hcl_ide089_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 089',
  `hcl_des089_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 089',
  `hcl_ide090_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 090',
  `hcl_des090_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 090',
  `hcl_ide091_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 091',
  `hcl_des091_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 091',
  `hcl_ide092_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 092',
  `hcl_des092_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 092',
  `hcl_ide093_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 093',
  `hcl_des093_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 093',
  `hcl_ide094_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 094',
  `hcl_des094_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 094',
  `hcl_ide095_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 095',
  `hcl_des095_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 095',
  `hcl_ide096_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 096',
  `hcl_des096_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 096',
  `hcl_ide097_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 097',
  `hcl_des097_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 097',
  `hcl_ide098_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 098',
  `hcl_des098_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 098',
  `hcl_ide099_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 099',
  `hcl_des099_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 099',
  `hcl_ide100_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 100',
  `hcl_des100_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 100',
  `hcl_ide101_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 101',
  `hcl_des101_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 101',
  `hcl_ide102_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 102',
  `hcl_des102_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 102',
  `hcl_ide103_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 103',
  `hcl_des103_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 103',
  `hcl_ide104_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 104',
  `hcl_des104_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 104',
  `hcl_ide105_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 105',
  `hcl_des105_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 105',
  `hcl_ide106_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 106',
  `hcl_des106_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 106',
  `hcl_ide107_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 107',
  `hcl_des107_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 107',
  `hcl_ide108_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 108',
  `hcl_des108_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 108',
  `hcl_ide109_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 109',
  `hcl_des109_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 109',
  `hcl_ide110_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 110',
  `hcl_des110_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 110',
  `hcl_ide111_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 111',
  `hcl_des111_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 111',
  `hcl_ide112_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 112',
  `hcl_des112_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 112',
  `hcl_ide113_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 113',
  `hcl_des113_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 113',
  `hcl_ide114_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 114',
  `hcl_des114_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 114',
  `hcl_ide115_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 115',
  `hcl_des115_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 115',
  `hcl_ide116_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 116',
  `hcl_des116_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 116',
  `hcl_ide117_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 117',
  `hcl_des117_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 117',
  `hcl_ide118_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 118',
  `hcl_des118_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 118',
  `hcl_ide119_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 119',
  `hcl_des119_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 119',
  `hcl_ide120_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 120',
  `hcl_des120_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 120',
  PRIMARY KEY (`hcl_nroreg_hcbm`),
  KEY `hcbm02x02` (`hcl_nroreg_hcev`),
  KEY `hcbm02x03` (`grp_idepla_grpl`),
  KEY `hcbm02x04` (`grp_idepla_grpv`),
  KEY `hcbm02x05` (`hcl_codreg_hcca`),
  KEY `hcbm02x06` (`adm_secadm_rgad`),
  KEY `hcbm02x07` (`cit_codasi_mcit`),
  KEY `hcbm02x08` (`fcm_codcpr_cpro`),
  KEY `hcbm02x09` (`sia_idesec_usua`),
  KEY `hcbm02x10` (`hcl_gesfec_hcev`),
  KEY `hcbm02x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexrbn01` table : 
#

DROP TABLE IF EXISTS `hclregisexrbn01`;

CREATE TABLE `hclregisexrbn01` (
  `hcl_nroreg_hcbn` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_ide121_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 061',
  `hcl_des121_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 061',
  `hcl_ide122_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 062',
  `hcl_des122_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 062',
  `hcl_ide123_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 063',
  `hcl_des123_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 063',
  `hcl_ide124_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 064',
  `hcl_des124_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 064',
  `hcl_ide125_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 065',
  `hcl_des125_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 065',
  `hcl_ide126_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 066',
  `hcl_des126_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 066',
  `hcl_ide127_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 067',
  `hcl_des127_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 067',
  `hcl_ide128_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 068',
  `hcl_des128_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 068',
  `hcl_ide129_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 069',
  `hcl_des129_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 069',
  `hcl_ide130_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 070',
  `hcl_des130_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 070',
  `hcl_ide131_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 071',
  `hcl_des131_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 071',
  `hcl_ide132_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 072',
  `hcl_des132_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 072',
  `hcl_ide133_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 073',
  `hcl_des133_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 073',
  `hcl_ide134_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 074',
  `hcl_des134_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 074',
  `hcl_ide135_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 075',
  `hcl_des135_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 075',
  `hcl_ide136_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 076',
  `hcl_des136_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 076',
  `hcl_ide137_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 077',
  `hcl_des137_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 077',
  `hcl_ide138_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 078',
  `hcl_des138_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 078',
  `hcl_ide139_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 079',
  `hcl_des139_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 079',
  `hcl_ide140_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 080',
  `hcl_des140_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 080',
  `hcl_ide141_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 081',
  `hcl_des141_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 081',
  `hcl_ide142_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 082',
  `hcl_des142_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 082',
  `hcl_ide143_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 083',
  `hcl_des143_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 083',
  `hcl_ide144_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 084',
  `hcl_des144_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 084',
  `hcl_ide145_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 085',
  `hcl_des145_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 085',
  `hcl_ide146_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 086',
  `hcl_des146_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 086',
  `hcl_ide147_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 087',
  `hcl_des147_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 087',
  `hcl_ide148_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 088',
  `hcl_des148_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 088',
  `hcl_ide149_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 089',
  `hcl_des149_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 089',
  `hcl_ide150_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 090',
  `hcl_des150_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 090',
  `hcl_ide151_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 091',
  `hcl_des151_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 091',
  `hcl_ide152_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 092',
  `hcl_des152_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 092',
  `hcl_ide153_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 093',
  `hcl_des153_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 093',
  `hcl_ide154_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 094',
  `hcl_des154_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 094',
  `hcl_ide155_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 095',
  `hcl_des155_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 095',
  `hcl_ide156_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 096',
  `hcl_des156_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 096',
  `hcl_ide157_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 097',
  `hcl_des157_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 097',
  `hcl_ide158_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 098',
  `hcl_des158_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 098',
  `hcl_ide159_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 099',
  `hcl_des159_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 099',
  `hcl_ide160_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 100',
  `hcl_des160_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 100',
  `hcl_ide161_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 101',
  `hcl_des161_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 101',
  `hcl_ide162_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 102',
  `hcl_des162_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 102',
  `hcl_ide163_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 103',
  `hcl_des163_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 103',
  `hcl_ide164_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 104',
  `hcl_des164_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 104',
  `hcl_ide165_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 105',
  `hcl_des165_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 105',
  `hcl_ide166_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 106',
  `hcl_des166_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 106',
  `hcl_ide167_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 107',
  `hcl_des167_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 107',
  `hcl_ide168_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 108',
  `hcl_des168_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 108',
  `hcl_ide169_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 109',
  `hcl_des169_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 109',
  `hcl_ide170_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 110',
  `hcl_des170_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 110',
  `hcl_ide171_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 111',
  `hcl_des171_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 111',
  `hcl_ide172_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 112',
  `hcl_des172_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 112',
  `hcl_ide173_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 113',
  `hcl_des173_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 113',
  `hcl_ide174_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 114',
  `hcl_des174_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 114',
  `hcl_ide175_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 115',
  `hcl_des175_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 115',
  `hcl_ide176_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 116',
  `hcl_des176_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 116',
  `hcl_ide177_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 117',
  `hcl_des177_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 117',
  `hcl_ide178_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 118',
  `hcl_des178_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 118',
  `hcl_ide179_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 119',
  `hcl_des179_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 119',
  `hcl_ide180_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 120',
  `hcl_des180_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 120',
  PRIMARY KEY (`hcl_nroreg_hcbn`),
  KEY `hcbn02x02` (`hcl_nroreg_hcev`),
  KEY `hcbn02x03` (`grp_idepla_grpl`),
  KEY `hcbn02x04` (`grp_idepla_grpv`),
  KEY `hcbn02x05` (`hcl_codreg_hcca`),
  KEY `hcbn02x06` (`adm_secadm_rgad`),
  KEY `hcbn02x07` (`cit_codasi_mcit`),
  KEY `hcbn02x08` (`fcm_codcpr_cpro`),
  KEY `hcbn02x09` (`sia_idesec_usua`),
  KEY `hcbn02x10` (`hcl_gesfec_hcev`),
  KEY `hcbn02x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexrbo01` table : 
#

DROP TABLE IF EXISTS `hclregisexrbo01`;

CREATE TABLE `hclregisexrbo01` (
  `hcl_nroreg_hcbo` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_ide181_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 061',
  `hcl_des181_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 061',
  `hcl_ide182_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 062',
  `hcl_des182_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 062',
  `hcl_ide183_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 063',
  `hcl_des183_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 063',
  `hcl_ide184_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 064',
  `hcl_des184_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 064',
  `hcl_ide185_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 065',
  `hcl_des185_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 065',
  `hcl_ide186_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 066',
  `hcl_des186_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 066',
  `hcl_ide187_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 067',
  `hcl_des187_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 067',
  `hcl_ide188_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 068',
  `hcl_des188_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 068',
  `hcl_ide189_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 069',
  `hcl_des189_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 069',
  `hcl_ide190_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 070',
  `hcl_des190_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 070',
  `hcl_ide191_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 071',
  `hcl_des191_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 071',
  `hcl_ide192_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 072',
  `hcl_des192_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 072',
  `hcl_ide193_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 073',
  `hcl_des193_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 073',
  `hcl_ide194_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 074',
  `hcl_des194_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 074',
  `hcl_ide195_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 075',
  `hcl_des195_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 075',
  `hcl_ide196_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 076',
  `hcl_des196_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 076',
  `hcl_ide197_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 077',
  `hcl_des197_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 077',
  `hcl_ide198_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 078',
  `hcl_des198_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 078',
  `hcl_ide199_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 079',
  `hcl_des199_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 079',
  `hcl_ide200_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 080',
  `hcl_des200_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 080',
  `hcl_ide201_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 081',
  `hcl_des201_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 081',
  `hcl_ide202_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 082',
  `hcl_des202_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 082',
  `hcl_ide203_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 083',
  `hcl_des203_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 083',
  `hcl_ide204_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 084',
  `hcl_des204_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 084',
  `hcl_ide205_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 085',
  `hcl_des205_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 085',
  `hcl_ide206_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 086',
  `hcl_des206_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 086',
  `hcl_ide207_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 087',
  `hcl_des207_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 087',
  `hcl_ide208_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 088',
  `hcl_des208_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 088',
  `hcl_ide209_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 089',
  `hcl_des209_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 089',
  `hcl_ide210_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 090',
  `hcl_des210_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 090',
  `hcl_ide211_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 091',
  `hcl_des211_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 091',
  `hcl_ide212_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 092',
  `hcl_des212_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 092',
  `hcl_ide213_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 093',
  `hcl_des213_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 093',
  `hcl_ide214_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 094',
  `hcl_des214_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 094',
  `hcl_ide215_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 095',
  `hcl_des215_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 095',
  `hcl_ide216_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 096',
  `hcl_des216_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 096',
  `hcl_ide217_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 097',
  `hcl_des217_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 097',
  `hcl_ide218_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 098',
  `hcl_des218_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 098',
  `hcl_ide219_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 099',
  `hcl_des219_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 099',
  `hcl_ide220_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 100',
  `hcl_des220_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 100',
  `hcl_ide221_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 101',
  `hcl_des221_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 101',
  `hcl_ide222_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 102',
  `hcl_des222_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 102',
  `hcl_ide223_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 103',
  `hcl_des223_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 103',
  `hcl_ide224_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 104',
  `hcl_des224_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 104',
  `hcl_ide225_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 105',
  `hcl_des225_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 105',
  `hcl_ide226_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 106',
  `hcl_des226_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 106',
  `hcl_ide227_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 107',
  `hcl_des227_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 107',
  `hcl_ide228_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 108',
  `hcl_des228_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 108',
  `hcl_ide229_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 109',
  `hcl_des229_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 109',
  `hcl_ide230_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 110',
  `hcl_des230_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 110',
  `hcl_ide231_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 111',
  `hcl_des231_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 111',
  `hcl_ide232_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 112',
  `hcl_des232_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 112',
  `hcl_ide233_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 113',
  `hcl_des233_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 113',
  `hcl_ide234_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 114',
  `hcl_des234_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 114',
  `hcl_ide235_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 115',
  `hcl_des235_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 115',
  `hcl_ide236_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 116',
  `hcl_des236_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 116',
  `hcl_ide237_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 117',
  `hcl_des237_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 117',
  `hcl_ide238_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 118',
  `hcl_des238_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 118',
  `hcl_ide239_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 119',
  `hcl_des239_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 119',
  `hcl_ide240_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 120',
  `hcl_des240_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 120',
  PRIMARY KEY (`hcl_nroreg_hcbo`),
  KEY `hcbo02x02` (`hcl_nroreg_hcev`),
  KEY `hcbo02x03` (`grp_idepla_grpl`),
  KEY `hcbo02x04` (`grp_idepla_grpv`),
  KEY `hcbo02x05` (`hcl_codreg_hcca`),
  KEY `hcbo02x06` (`adm_secadm_rgad`),
  KEY `hcbo02x07` (`cit_codasi_mcit`),
  KEY `hcbo02x08` (`fcm_codcpr_cpro`),
  KEY `hcbo02x09` (`sia_idesec_usua`),
  KEY `hcbo02x10` (`hcl_gesfec_hcev`),
  KEY `hcbo02x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexrbt01` table : 
#

DROP TABLE IF EXISTS `hclregisexrbt01`;

CREATE TABLE `hclregisexrbt01` (
  `hcl_nroreg_hcrb` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_ide001_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 001',
  `hcl_des001_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 001',
  `hcl_ide002_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 002',
  `hcl_des002_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 002',
  `hcl_ide003_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 003',
  `hcl_des003_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 003',
  `hcl_ide004_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 004',
  `hcl_des004_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 004',
  `hcl_ide005_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 005',
  `hcl_des005_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 005',
  `hcl_ide006_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 006',
  `hcl_des006_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 006',
  `hcl_ide007_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 007',
  `hcl_des007_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 007',
  `hcl_ide008_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 008',
  `hcl_des008_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 008',
  `hcl_ide009_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 009',
  `hcl_des009_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 009',
  `hcl_ide010_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 010',
  `hcl_des010_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 010',
  `hcl_ide011_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 011',
  `hcl_des011_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 011',
  `hcl_ide012_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 012',
  `hcl_des012_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 012',
  `hcl_ide013_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 013',
  `hcl_des013_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 013',
  `hcl_ide014_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 014',
  `hcl_des014_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 014',
  `hcl_ide015_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 015',
  `hcl_des015_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 015',
  `hcl_ide016_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 016',
  `hcl_des016_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 016',
  `hcl_ide017_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 017',
  `hcl_des017_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 017',
  `hcl_ide018_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 018',
  `hcl_des018_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 018',
  `hcl_ide019_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 019',
  `hcl_des019_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 019',
  `hcl_ide020_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 020',
  `hcl_des020_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 020',
  `hcl_ide021_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 021',
  `hcl_des021_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 021',
  `hcl_ide022_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 022',
  `hcl_des022_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 022',
  `hcl_ide023_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 023',
  `hcl_des023_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 023',
  `hcl_ide024_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 024',
  `hcl_des024_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 024',
  `hcl_ide025_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 025',
  `hcl_des025_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 025',
  `hcl_ide026_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 026',
  `hcl_des026_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 026',
  `hcl_ide027_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 027',
  `hcl_des027_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 027',
  `hcl_ide028_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 028',
  `hcl_des028_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 028',
  `hcl_ide029_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 029',
  `hcl_des029_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 029',
  `hcl_ide030_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 030',
  `hcl_des030_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 030',
  `hcl_ide031_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 031',
  `hcl_des031_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 031',
  `hcl_ide032_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 032',
  `hcl_des032_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 032',
  `hcl_ide033_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 033',
  `hcl_des033_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 033',
  `hcl_ide034_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 034',
  `hcl_des034_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 034',
  `hcl_ide035_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 035',
  `hcl_des035_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 035',
  `hcl_ide036_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 036',
  `hcl_des036_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 036',
  `hcl_ide037_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 037',
  `hcl_des037_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 037',
  `hcl_ide038_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 038',
  `hcl_des038_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 038',
  `hcl_ide039_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 039',
  `hcl_des039_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 039',
  `hcl_ide040_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 040',
  `hcl_des040_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 040',
  `hcl_ide041_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 041',
  `hcl_des041_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 041',
  `hcl_ide042_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 042',
  `hcl_des042_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 042',
  `hcl_ide043_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 043',
  `hcl_des043_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 043',
  `hcl_ide044_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 044',
  `hcl_des044_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 044',
  `hcl_ide045_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 045',
  `hcl_des045_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 045',
  `hcl_ide046_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 046',
  `hcl_des046_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 046',
  `hcl_ide047_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 047',
  `hcl_des047_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 047',
  `hcl_ide048_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 048',
  `hcl_des048_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 048',
  `hcl_ide049_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 049',
  `hcl_des049_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 049',
  `hcl_ide050_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 050',
  `hcl_des050_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 050',
  `hcl_ide051_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 051',
  `hcl_des051_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 051',
  `hcl_ide052_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 052',
  `hcl_des052_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 052',
  `hcl_ide053_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 053',
  `hcl_des053_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 053',
  `hcl_ide054_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 054',
  `hcl_des054_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 054',
  `hcl_ide055_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 055',
  `hcl_des055_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 055',
  `hcl_ide056_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 056',
  `hcl_des056_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 056',
  `hcl_ide057_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 057',
  `hcl_des057_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 057',
  `hcl_ide058_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 058',
  `hcl_des058_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 058',
  `hcl_ide059_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 059',
  `hcl_des059_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 059',
  `hcl_ide060_hcrb` varchar(3) DEFAULT NULL COMMENT 'Campo id de la opcion RadioButton marcada como seleccionada 060',
  `hcl_des060_hcrb` varchar(70) DEFAULT NULL COMMENT 'Campo del texto descripcion opcion RadioButton marcada como seleccionada 060',
  PRIMARY KEY (`hcl_nroreg_hcrb`),
  KEY `hcrb01x02` (`hcl_nroreg_hcev`),
  KEY `hcrb01x03` (`grp_idepla_grpl`),
  KEY `hcrb01x04` (`grp_idepla_grpv`),
  KEY `hcrb01x05` (`hcl_codreg_hcca`),
  KEY `hcrb01x06` (`adm_secadm_rgad`),
  KEY `hcrb01x07` (`cit_codasi_mcit`),
  KEY `hcrb01x08` (`fcm_codcpr_cpro`),
  KEY `hcrb01x09` (`sia_idesec_usua`),
  KEY `hcrb01x10` (`hcl_gesfec_hcev`),
  KEY `hcrb01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexrec01` table : 
#

DROP TABLE IF EXISTS `hclregisexrec01`;

CREATE TABLE `hclregisexrec01` (
  `hcl_nroreg_hcrc` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_obj001_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 001',
  `hcl_tip001_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 001',
  `hcl_cod001_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 001',
  `hcl_nom001_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 001',
  `hcl_uri001_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 001',
  `hcl_obj002_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 002',
  `hcl_tip002_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 002',
  `hcl_cod002_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 002',
  `hcl_nom002_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 002',
  `hcl_uri002_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 002',
  `hcl_obj003_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 003',
  `hcl_tip003_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 003',
  `hcl_cod003_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 003',
  `hcl_nom003_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 003',
  `hcl_uri003_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 003',
  `hcl_obj004_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 004',
  `hcl_tip004_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 004',
  `hcl_cod004_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 004',
  `hcl_nom004_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 004',
  `hcl_uri004_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 004',
  `hcl_obj005_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 005',
  `hcl_tip005_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 005',
  `hcl_cod005_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 005',
  `hcl_nom005_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 005',
  `hcl_uri005_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 005',
  `hcl_obj006_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 006',
  `hcl_tip006_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 006',
  `hcl_cod006_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 006',
  `hcl_nom006_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 006',
  `hcl_uri006_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 006',
  `hcl_obj007_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 007',
  `hcl_tip007_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 007',
  `hcl_cod007_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 007',
  `hcl_nom007_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 007',
  `hcl_uri007_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 007',
  `hcl_obj008_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 008',
  `hcl_tip008_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 008',
  `hcl_cod008_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 008',
  `hcl_nom008_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 008',
  `hcl_uri008_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 008',
  `hcl_obj009_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 009',
  `hcl_tip009_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 009',
  `hcl_cod009_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 009',
  `hcl_nom009_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 009',
  `hcl_uri009_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 009',
  `hcl_obj010_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 010',
  `hcl_tip010_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 010',
  `hcl_cod010_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 010',
  `hcl_nom010_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 010',
  `hcl_uri010_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 010',
  `hcl_obj011_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 011',
  `hcl_tip011_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 011',
  `hcl_cod011_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 011',
  `hcl_nom011_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 011',
  `hcl_uri011_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 011',
  `hcl_obj012_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 012',
  `hcl_tip012_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 012',
  `hcl_cod012_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 012',
  `hcl_nom012_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 012',
  `hcl_uri012_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 012',
  `hcl_obj013_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 013',
  `hcl_tip013_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 013',
  `hcl_cod013_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 013',
  `hcl_nom013_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 013',
  `hcl_uri013_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 013',
  `hcl_obj014_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 014',
  `hcl_tip014_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 014',
  `hcl_cod014_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 014',
  `hcl_nom014_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 014',
  `hcl_uri014_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 014',
  `hcl_obj015_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 015',
  `hcl_tip015_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 015',
  `hcl_cod015_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 015',
  `hcl_nom015_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 015',
  `hcl_uri015_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 015',
  `hcl_obj016_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 016',
  `hcl_tip016_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 016',
  `hcl_cod016_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 016',
  `hcl_nom016_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 016',
  `hcl_uri016_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 016',
  `hcl_obj017_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 017',
  `hcl_tip017_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 017',
  `hcl_cod017_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 017',
  `hcl_nom017_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 017',
  `hcl_uri017_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 017',
  `hcl_obj018_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 018',
  `hcl_tip018_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 018',
  `hcl_cod018_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 018',
  `hcl_nom018_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 018',
  `hcl_uri018_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 018',
  `hcl_obj019_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 019',
  `hcl_tip019_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 019',
  `hcl_cod019_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 019',
  `hcl_nom019_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 019',
  `hcl_uri019_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 019',
  `hcl_obj020_hcrc` varchar(30) DEFAULT NULL COMMENT 'Nombre del objeto que genera el sistema para mostrar el recurso imagen/video y otros 020',
  `hcl_tip020_hcrc` varchar(10) DEFAULT NULL COMMENT 'Codigo tipo recurso en galeria IMAGEN/VIDEO/HUELLA/PDF/DOC/XLS/PPT/... 020',
  `hcl_cod020_hcrc` varchar(20) DEFAULT NULL COMMENT 'Codigo del recurso en galeria imagen/Videos y otros 020',
  `hcl_nom020_hcrc` varchar(60) DEFAULT NULL COMMENT 'Nombre del archivo de recurso imagen/Video y otros 020',
  `hcl_uri020_hcrc` varchar(90) DEFAULT NULL COMMENT 'Ruta del archivo de recurso imagen/Video y otros 020',
  PRIMARY KEY (`hcl_nroreg_hcrc`),
  KEY `hcrc01x02` (`hcl_nroreg_hcev`),
  KEY `hcrc01x03` (`grp_idepla_grpl`),
  KEY `hcrc01x04` (`grp_idepla_grpv`),
  KEY `hcrc01x05` (`hcl_codreg_hcca`),
  KEY `hcrc01x06` (`adm_secadm_rgad`),
  KEY `hcrc01x07` (`cit_codasi_mcit`),
  KEY `hcrc01x08` (`fcm_codcpr_cpro`),
  KEY `hcrc01x09` (`sia_idesec_usua`),
  KEY `hcrc01x10` (`hcl_gesfec_hcev`),
  KEY `hcrc01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisexrel01` table : 
#

DROP TABLE IF EXISTS `hclregisexrel01`;

CREATE TABLE `hclregisexrel01` (
  `hcl_nroreg_hcre` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_cod001_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 001',
  `hcl_des001_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 001',
  `hcl_cod002_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 002',
  `hcl_des002_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 002',
  `hcl_cod003_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 003',
  `hcl_des003_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 003',
  `hcl_cod004_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 004',
  `hcl_des004_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 004',
  `hcl_cod005_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 005',
  `hcl_des005_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 005',
  `hcl_cod006_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 006',
  `hcl_des006_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 006',
  `hcl_cod007_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 007',
  `hcl_des007_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 007',
  `hcl_cod008_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 008',
  `hcl_des008_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 008',
  `hcl_cod009_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 009',
  `hcl_des009_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 009',
  `hcl_cod010_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 010',
  `hcl_des010_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 010',
  `hcl_cod011_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 011',
  `hcl_des011_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 011',
  `hcl_cod012_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 012',
  `hcl_des012_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 012',
  `hcl_cod013_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 013',
  `hcl_des013_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 013',
  `hcl_cod014_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 014',
  `hcl_des014_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 014',
  `hcl_cod015_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 015',
  `hcl_des015_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 015',
  `hcl_cod016_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 016',
  `hcl_des016_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 016',
  `hcl_cod017_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 017',
  `hcl_des017_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 017',
  `hcl_cod018_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 018',
  `hcl_des018_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 018',
  `hcl_cod019_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 019',
  `hcl_des019_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 019',
  `hcl_cod020_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 020',
  `hcl_des020_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 020',
  `hcl_cod021_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 021',
  `hcl_des021_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 021',
  `hcl_cod022_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 022',
  `hcl_des022_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 022',
  `hcl_cod023_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 023',
  `hcl_des023_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 023',
  `hcl_cod024_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 024',
  `hcl_des024_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 024',
  `hcl_cod025_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 025',
  `hcl_des025_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 025',
  `hcl_cod026_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 026',
  `hcl_des026_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 026',
  `hcl_cod027_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 027',
  `hcl_des027_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 027',
  `hcl_cod028_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 028',
  `hcl_des028_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 028',
  `hcl_cod029_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 029',
  `hcl_des029_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 029',
  `hcl_cod030_hcre` varchar(20) DEFAULT NULL COMMENT 'Campo codigo relacion tabla 030',
  `hcl_des030_hcre` varchar(200) DEFAULT NULL COMMENT 'Campo del texto descripcion relacion tabla 030',
  PRIMARY KEY (`hcl_nroreg_hcre`),
  KEY `hcre01x02` (`hcl_nroreg_hcev`),
  KEY `hcre01x03` (`grp_idepla_grpl`),
  KEY `hcre01x04` (`grp_idepla_grpv`),
  KEY `hcre01x05` (`hcl_codreg_hcca`),
  KEY `hcre01x06` (`adm_secadm_rgad`),
  KEY `hcre01x07` (`cit_codasi_mcit`),
  KEY `hcre01x08` (`fcm_codcpr_cpro`),
  KEY `hcre01x09` (`sia_idesec_usua`),
  KEY `hcre01x10` (`hcl_gesfec_hcev`),
  KEY `hcre01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisextxa01` table : 
#

DROP TABLE IF EXISTS `hclregisextxa01`;

CREATE TABLE `hclregisextxa01` (
  `hcl_nroreg_hctx` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_txt001_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 001',
  `hcl_txt002_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 002',
  `hcl_txt003_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 003',
  `hcl_txt004_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 004',
  `hcl_txt005_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 005',
  `hcl_txt006_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 006',
  `hcl_txt007_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 007',
  `hcl_txt008_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 008',
  `hcl_txt009_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 009',
  `hcl_txt010_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 010',
  `hcl_txt011_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 011',
  `hcl_txt012_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 012',
  `hcl_txt013_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 013',
  `hcl_txt014_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 014',
  `hcl_txt015_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 015',
  `hcl_txt016_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 016',
  `hcl_txt017_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 017',
  `hcl_txt018_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 018',
  `hcl_txt019_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 019',
  `hcl_txt020_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 020',
  `hcl_txt021_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 021',
  `hcl_txt022_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 022',
  `hcl_txt023_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 023',
  `hcl_txt024_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 024',
  `hcl_txt025_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 025',
  `hcl_txt026_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 026',
  `hcl_txt027_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 027',
  `hcl_txt028_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 028',
  `hcl_txt029_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 029',
  `hcl_txt030_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 030',
  `hcl_txt031_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 031',
  `hcl_txt032_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 032',
  `hcl_txt033_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 033',
  `hcl_txt034_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 034',
  `hcl_txt035_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 035',
  `hcl_txt036_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 036',
  `hcl_txt037_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 037',
  `hcl_txt038_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 038',
  `hcl_txt039_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 039',
  `hcl_txt040_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 040',
  `hcl_txt041_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 041',
  `hcl_txt042_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 042',
  `hcl_txt043_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 043',
  `hcl_txt044_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 044',
  `hcl_txt045_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 045',
  `hcl_txt046_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 046',
  `hcl_txt047_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 047',
  `hcl_txt048_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 048',
  `hcl_txt049_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 049',
  `hcl_txt050_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 050',
  `hcl_txt051_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 051',
  `hcl_txt052_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 052',
  `hcl_txt053_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 053',
  `hcl_txt054_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 054',
  `hcl_txt055_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 055',
  `hcl_txt056_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 056',
  `hcl_txt057_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 057',
  `hcl_txt058_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 058',
  `hcl_txt059_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 059',
  `hcl_txt060_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 060',
  `hcl_txt061_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 061',
  `hcl_txt062_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 062',
  `hcl_txt063_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 063',
  `hcl_txt064_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 064',
  `hcl_txt065_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 065',
  `hcl_txt066_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 066',
  `hcl_txt067_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 067',
  `hcl_txt068_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 068',
  `hcl_txt069_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 069',
  `hcl_txt070_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 070',
  `hcl_txt071_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 071',
  `hcl_txt072_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 072',
  `hcl_txt073_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 073',
  `hcl_txt074_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 074',
  `hcl_txt075_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 075',
  `hcl_txt076_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 076',
  `hcl_txt077_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 077',
  `hcl_txt078_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 078',
  `hcl_txt079_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 079',
  `hcl_txt080_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 080',
  `hcl_txt081_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 081',
  `hcl_txt082_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 082',
  `hcl_txt083_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 083',
  `hcl_txt084_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 084',
  `hcl_txt085_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 085',
  `hcl_txt086_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 086',
  `hcl_txt087_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 087',
  `hcl_txt088_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 088',
  `hcl_txt089_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 089',
  `hcl_txt090_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 090',
  `hcl_txt091_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 091',
  `hcl_txt092_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 092',
  `hcl_txt093_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 093',
  `hcl_txt094_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 094',
  `hcl_txt095_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 095',
  `hcl_txt096_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 096',
  `hcl_txt097_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 097',
  `hcl_txt098_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 098',
  `hcl_txt099_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 099',
  `hcl_txt100_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 100',
  `hcl_txt101_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 101',
  `hcl_txt102_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 102',
  `hcl_txt103_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 103',
  `hcl_txt104_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 104',
  `hcl_txt105_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 105',
  `hcl_txt106_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 106',
  `hcl_txt107_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 107',
  `hcl_txt108_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 108',
  `hcl_txt109_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 109',
  `hcl_txt110_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 110',
  `hcl_txt111_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 111',
  `hcl_txt112_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 112',
  `hcl_txt113_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 113',
  `hcl_txt114_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 114',
  `hcl_txt115_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 115',
  `hcl_txt116_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 116',
  `hcl_txt117_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 117',
  `hcl_txt118_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 118',
  `hcl_txt119_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 119',
  `hcl_txt120_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 120',
  `hcl_txt121_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 121',
  `hcl_txt122_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 122',
  `hcl_txt123_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 123',
  `hcl_txt124_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 124',
  `hcl_txt125_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 125',
  `hcl_txt126_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 126',
  `hcl_txt127_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 127',
  `hcl_txt128_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 128',
  `hcl_txt129_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 129',
  `hcl_txt130_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 130',
  `hcl_txt131_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 131',
  `hcl_txt132_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 132',
  `hcl_txt133_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 133',
  `hcl_txt134_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 134',
  `hcl_txt135_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 135',
  `hcl_txt136_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 136',
  `hcl_txt137_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 137',
  `hcl_txt138_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 138',
  `hcl_txt139_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 139',
  `hcl_txt140_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 140',
  `hcl_txt141_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 141',
  `hcl_txt142_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 142',
  `hcl_txt143_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 143',
  `hcl_txt144_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 144',
  `hcl_txt145_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 145',
  `hcl_txt146_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 146',
  `hcl_txt147_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 147',
  `hcl_txt148_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 148',
  `hcl_txt149_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 149',
  `hcl_txt150_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 150',
  PRIMARY KEY (`hcl_nroreg_hctx`),
  KEY `hcta01x02` (`hcl_nroreg_hcev`),
  KEY `hcta01x03` (`grp_idepla_grpl`),
  KEY `hcta01x04` (`grp_idepla_grpv`),
  KEY `hcta01x05` (`hcl_codreg_hcca`),
  KEY `hcta01x06` (`adm_secadm_rgad`),
  KEY `hcta01x07` (`cit_codasi_mcit`),
  KEY `hcta01x08` (`fcm_codcpr_cpro`),
  KEY `hcta01x09` (`sia_idesec_usua`),
  KEY `hcta01x10` (`hcl_gesfec_hcev`),
  KEY `hcta01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisextxb01` table : 
#

DROP TABLE IF EXISTS `hclregisextxb01`;

CREATE TABLE `hclregisextxb01` (
  `hcl_nroreg_hcta` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_txt151_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 151',
  `hcl_txt152_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 152',
  `hcl_txt153_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 153',
  `hcl_txt154_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 154',
  `hcl_txt155_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 155',
  `hcl_txt156_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 156',
  `hcl_txt157_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 157',
  `hcl_txt158_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 158',
  `hcl_txt159_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 159',
  `hcl_txt160_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 160',
  `hcl_txt161_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 161',
  `hcl_txt162_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 162',
  `hcl_txt163_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 163',
  `hcl_txt164_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 164',
  `hcl_txt165_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 165',
  `hcl_txt166_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 166',
  `hcl_txt167_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 167',
  `hcl_txt168_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 168',
  `hcl_txt169_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 169',
  `hcl_txt170_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 170',
  `hcl_txt171_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 171',
  `hcl_txt172_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 172',
  `hcl_txt173_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 173',
  `hcl_txt174_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 174',
  `hcl_txt175_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 175',
  `hcl_txt176_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 176',
  `hcl_txt177_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 177',
  `hcl_txt178_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 178',
  `hcl_txt179_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 179',
  `hcl_txt180_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 180',
  `hcl_txt181_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 181',
  `hcl_txt182_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 182',
  `hcl_txt183_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 183',
  `hcl_txt184_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 184',
  `hcl_txt185_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 185',
  `hcl_txt186_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 186',
  `hcl_txt187_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 187',
  `hcl_txt188_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 188',
  `hcl_txt189_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 189',
  `hcl_txt190_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 190',
  `hcl_txt191_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 191',
  `hcl_txt192_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 192',
  `hcl_txt193_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 193',
  `hcl_txt194_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 194',
  `hcl_txt195_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 195',
  `hcl_txt196_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 196',
  `hcl_txt197_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 197',
  `hcl_txt198_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 198',
  `hcl_txt199_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 199',
  `hcl_txt200_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 200',
  `hcl_txt201_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 201',
  `hcl_txt202_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 202',
  `hcl_txt203_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 203',
  `hcl_txt204_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 204',
  `hcl_txt205_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 205',
  `hcl_txt206_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 206',
  `hcl_txt207_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 207',
  `hcl_txt208_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 208',
  `hcl_txt209_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 209',
  `hcl_txt210_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 210',
  `hcl_txt211_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 211',
  `hcl_txt212_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 212',
  `hcl_txt213_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 213',
  `hcl_txt214_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 214',
  `hcl_txt215_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 215',
  `hcl_txt216_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 216',
  `hcl_txt217_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 217',
  `hcl_txt218_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 218',
  `hcl_txt219_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 219',
  `hcl_txt220_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 220',
  `hcl_txt221_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 221',
  `hcl_txt222_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 222',
  `hcl_txt223_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 223',
  `hcl_txt224_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 224',
  `hcl_txt225_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 225',
  `hcl_txt226_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 226',
  `hcl_txt227_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 227',
  `hcl_txt228_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 228',
  `hcl_txt229_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 229',
  `hcl_txt230_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 230',
  `hcl_txt231_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 231',
  `hcl_txt232_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 232',
  `hcl_txt233_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 233',
  `hcl_txt234_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 234',
  `hcl_txt235_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 235',
  `hcl_txt236_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 236',
  `hcl_txt237_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 237',
  `hcl_txt238_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 238',
  `hcl_txt239_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 239',
  `hcl_txt240_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 240',
  `hcl_txt241_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 241',
  `hcl_txt242_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 242',
  `hcl_txt243_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 243',
  `hcl_txt244_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 244',
  `hcl_txt245_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 245',
  `hcl_txt246_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 246',
  `hcl_txt247_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 247',
  `hcl_txt248_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 248',
  `hcl_txt249_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 249',
  `hcl_txt250_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 250',
  `hcl_txt251_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 251',
  `hcl_txt252_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 252',
  `hcl_txt253_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 253',
  `hcl_txt254_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 254',
  `hcl_txt255_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 255',
  `hcl_txt256_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 256',
  `hcl_txt257_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 257',
  `hcl_txt258_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 258',
  `hcl_txt259_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 259',
  `hcl_txt260_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 260',
  `hcl_txt261_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 261',
  `hcl_txt262_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 262',
  `hcl_txt263_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 263',
  `hcl_txt264_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 264',
  `hcl_txt265_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 265',
  `hcl_txt266_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 266',
  `hcl_txt267_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 267',
  `hcl_txt268_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 268',
  `hcl_txt269_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 269',
  `hcl_txt270_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 270',
  `hcl_txt271_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 271',
  `hcl_txt272_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 272',
  `hcl_txt273_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 273',
  `hcl_txt274_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 274',
  `hcl_txt275_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 275',
  `hcl_txt276_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 276',
  `hcl_txt277_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 277',
  `hcl_txt278_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 278',
  `hcl_txt279_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 279',
  `hcl_txt280_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 280',
  `hcl_txt281_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 281',
  `hcl_txt282_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 282',
  `hcl_txt283_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 283',
  `hcl_txt284_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 284',
  `hcl_txt285_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 285',
  `hcl_txt286_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 286',
  `hcl_txt287_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 287',
  `hcl_txt288_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 288',
  `hcl_txt289_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 289',
  `hcl_txt290_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 290',
  `hcl_txt291_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 291',
  `hcl_txt292_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 292',
  `hcl_txt293_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 293',
  `hcl_txt294_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 294',
  `hcl_txt295_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 295',
  `hcl_txt296_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 296',
  `hcl_txt297_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 297',
  `hcl_txt298_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 298',
  `hcl_txt299_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 299',
  `hcl_txt300_hctx` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 300',
  PRIMARY KEY (`hcl_nroreg_hcta`),
  KEY `hctb01x02` (`hcl_nroreg_hcev`),
  KEY `hctb01x03` (`grp_idepla_grpl`),
  KEY `hctb01x04` (`grp_idepla_grpv`),
  KEY `hctb01x05` (`hcl_codreg_hcca`),
  KEY `hctb01x06` (`adm_secadm_rgad`),
  KEY `hctb01x07` (`cit_codasi_mcit`),
  KEY `hctb01x08` (`fcm_codcpr_cpro`),
  KEY `hctb01x09` (`sia_idesec_usua`),
  KEY `hctb01x10` (`hcl_gesfec_hcev`),
  KEY `hctb01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregisextxc01` table : 
#

DROP TABLE IF EXISTS `hclregisextxc01`;

CREATE TABLE `hclregisextxc01` (
  `hcl_nroreg_hctc` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial registro, igual al codigo del historial de eventos medicos general',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_txt301_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 301',
  `hcl_txt302_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 302',
  `hcl_txt303_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 303',
  `hcl_txt304_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 304',
  `hcl_txt305_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 305',
  `hcl_txt306_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 306',
  `hcl_txt307_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 307',
  `hcl_txt308_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 308',
  `hcl_txt309_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 309',
  `hcl_txt310_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 310',
  `hcl_txt311_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 311',
  `hcl_txt312_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 312',
  `hcl_txt313_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 313',
  `hcl_txt314_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 314',
  `hcl_txt315_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 315',
  `hcl_txt316_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 316',
  `hcl_txt317_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 317',
  `hcl_txt318_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 318',
  `hcl_txt319_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 319',
  `hcl_txt320_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 320',
  `hcl_txt321_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 321',
  `hcl_txt322_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 322',
  `hcl_txt323_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 323',
  `hcl_txt324_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 324',
  `hcl_txt325_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 325',
  `hcl_txt326_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 326',
  `hcl_txt327_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 327',
  `hcl_txt328_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 328',
  `hcl_txt329_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 329',
  `hcl_txt330_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 330',
  `hcl_txt331_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 331',
  `hcl_txt332_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 332',
  `hcl_txt333_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 333',
  `hcl_txt334_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 334',
  `hcl_txt335_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 335',
  `hcl_txt336_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 336',
  `hcl_txt337_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 337',
  `hcl_txt338_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 338',
  `hcl_txt339_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 339',
  `hcl_txt340_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 340',
  `hcl_txt341_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 341',
  `hcl_txt342_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 342',
  `hcl_txt343_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 343',
  `hcl_txt344_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 344',
  `hcl_txt345_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 345',
  `hcl_txt346_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 346',
  `hcl_txt347_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 347',
  `hcl_txt348_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 348',
  `hcl_txt349_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 349',
  `hcl_txt350_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 350',
  `hcl_txt351_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 351',
  `hcl_txt352_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 352',
  `hcl_txt353_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 353',
  `hcl_txt354_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 354',
  `hcl_txt355_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 355',
  `hcl_txt356_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 356',
  `hcl_txt357_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 357',
  `hcl_txt358_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 358',
  `hcl_txt359_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 359',
  `hcl_txt360_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 360',
  `hcl_txt361_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 361',
  `hcl_txt362_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 362',
  `hcl_txt363_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 363',
  `hcl_txt364_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 364',
  `hcl_txt365_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 365',
  `hcl_txt366_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 366',
  `hcl_txt367_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 367',
  `hcl_txt368_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 368',
  `hcl_txt369_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 369',
  `hcl_txt370_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 370',
  `hcl_txt371_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 371',
  `hcl_txt372_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 372',
  `hcl_txt373_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 373',
  `hcl_txt374_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 374',
  `hcl_txt375_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 375',
  `hcl_txt376_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 376',
  `hcl_txt377_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 377',
  `hcl_txt378_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 378',
  `hcl_txt379_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 379',
  `hcl_txt380_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 380',
  `hcl_txt381_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 381',
  `hcl_txt382_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 382',
  `hcl_txt383_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 383',
  `hcl_txt384_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 384',
  `hcl_txt385_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 385',
  `hcl_txt386_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 386',
  `hcl_txt387_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 387',
  `hcl_txt388_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 388',
  `hcl_txt389_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 389',
  `hcl_txt390_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 390',
  `hcl_txt391_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 391',
  `hcl_txt392_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 392',
  `hcl_txt393_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 393',
  `hcl_txt394_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 394',
  `hcl_txt395_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 395',
  `hcl_txt396_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 396',
  `hcl_txt397_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 397',
  `hcl_txt398_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 398',
  `hcl_txt399_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 399',
  `hcl_txt400_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 400',
  `hcl_txt401_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 401',
  `hcl_txt402_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 402',
  `hcl_txt403_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 403',
  `hcl_txt404_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 404',
  `hcl_txt405_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 405',
  `hcl_txt406_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 406',
  `hcl_txt407_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 407',
  `hcl_txt408_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 408',
  `hcl_txt409_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 409',
  `hcl_txt410_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 410',
  `hcl_txt411_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 411',
  `hcl_txt412_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 412',
  `hcl_txt413_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 413',
  `hcl_txt414_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 414',
  `hcl_txt415_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 415',
  `hcl_txt416_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 416',
  `hcl_txt417_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 417',
  `hcl_txt418_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 418',
  `hcl_txt419_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 419',
  `hcl_txt420_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 420',
  `hcl_txt421_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 421',
  `hcl_txt422_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 422',
  `hcl_txt423_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 423',
  `hcl_txt424_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 424',
  `hcl_txt425_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 425',
  `hcl_txt426_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 426',
  `hcl_txt427_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 427',
  `hcl_txt428_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 428',
  `hcl_txt429_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 429',
  `hcl_txt430_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 430',
  `hcl_txt431_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 431',
  `hcl_txt432_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 432',
  `hcl_txt433_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 433',
  `hcl_txt434_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 434',
  `hcl_txt435_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 435',
  `hcl_txt436_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 436',
  `hcl_txt437_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 437',
  `hcl_txt438_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 438',
  `hcl_txt439_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 439',
  `hcl_txt440_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 440',
  `hcl_txt441_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 441',
  `hcl_txt442_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 442',
  `hcl_txt443_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 443',
  `hcl_txt444_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 444',
  `hcl_txt445_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 445',
  `hcl_txt446_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 446',
  `hcl_txt447_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 447',
  `hcl_txt448_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 448',
  `hcl_txt449_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 449',
  `hcl_txt450_hctc` varchar(130) DEFAULT NULL COMMENT 'Campo tipo texto 450',
  PRIMARY KEY (`hcl_nroreg_hctc`),
  KEY `hctc01x02` (`hcl_nroreg_hcev`),
  KEY `hctc01x03` (`grp_idepla_grpl`),
  KEY `hctc01x04` (`grp_idepla_grpv`),
  KEY `hctc01x05` (`hcl_codreg_hcca`),
  KEY `hctc01x06` (`adm_secadm_rgad`),
  KEY `hctc01x07` (`cit_codasi_mcit`),
  KEY `hctc01x08` (`fcm_codcpr_cpro`),
  KEY `hctc01x09` (`sia_idesec_usua`),
  KEY `hctc01x10` (`hcl_gesfec_hcev`),
  KEY `hctc01x11` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregnotasmedi` table : 
#

DROP TABLE IF EXISTS `hclregnotasmedi`;

CREATE TABLE `hclregnotasmedi` (
  `hcl_nroreg_hcnm` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico  registro servicio o medicamento',
  `hcl_notreg_hcnm` text COMMENT 'Cuerpo de la evolución medica o nota de enfermeria',
  `hcl_nroreg_hcms` varchar(20) DEFAULT NULL COMMENT 'Código secuencial unico registro maestro en la orden que los agrupa',
  `hcl_secreg_hcnm` int(10) DEFAULT NULL COMMENT 'Numero secuencial del registro medico  para organizar la vista cronologica',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_tipreg_hcnm` varchar(1) DEFAULT NULL COMMENT 'Tipo registro: 1 = Evolucion medica 2=Notas de enfermeria',
  `hcl_gesfec_hcnm` date DEFAULT NULL COMMENT 'Fecha solicitud del servicio al paciente',
  `hcl_geshor_hcnm` decimal(5,2) DEFAULT NULL COMMENT 'Hora solicitud del servicio al paciente en formato militar  (HH) ejm: 16',
  `hcl_tiptur_hctu` varchar(3) DEFAULT NULL COMMENT 'Codigo clasificacion turnos diarios para la prestacion de servicios medicos',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que autoriza el servicio o medicamento',
  `hcl_sisfec_hcnm` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando se genera registro del evento',
  `hcl_sishor_hcnm` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema al generar registro de evento en formato militar  (HH) ejm: 16',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`hcl_nroreg_hcnm`),
  KEY `hcnm02` (`hcl_nroreg_hcms`),
  KEY `hcnm03` (`adm_secadm_rgad`),
  KEY `hcnm04` (`sia_idesec_usua`),
  KEY `hcnm05` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregordeserde` table : 
#

DROP TABLE IF EXISTS `hclregordeserde`;

CREATE TABLE `hclregordeserde` (
  `hcl_nroreg_hcor` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico  registro servicio o medicamento',
  `hcl_nroreg_hcms` varchar(20) DEFAULT NULL COMMENT 'Código secuencial unico registro maestro en la orden que los agrupa',
  `hcl_secreg_hcor` int(10) DEFAULT NULL COMMENT 'Numero secuencial del registro medico  para organizar la vista cronologica',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_tipreg_hcor` varchar(1) DEFAULT NULL COMMENT 'Tipo registro: 1 = Servicio 2=Medicamento',
  `fcm_secreg_dfac` varchar(20) DEFAULT NULL COMMENT 'Secuencial único del registro desde servicios facturados del modulo Facturación (cuando el registro se facture)',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS configurado (codigo CUPS)',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (pude ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `hcl_totuni_hcor` int(10) DEFAULT NULL COMMENT 'Total de unidades autorizadas en la orden servicio',
  `inv_secart_mart` varchar(20) DEFAULT NULL COMMENT 'Codigo del articulo medicamento relacionado con el inventario para realizar descargas cuando se suminstra medicamentos o materiales a pacientes',
  `hcl_aplmed_hcor` varchar(1) DEFAULT NULL COMMENT 'Via de aplicación del medicamento: 1=Oral 2= Intramuscular 3=Intravenosa 4=Topica 5= Otras',
  `hcl_termed_hcor` varchar(1) DEFAULT NULL COMMENT 'Termino de uso del medicamento (en dias): 1=Indefeinido 2=Definido',
  `hcl_nrodia_hcor` int(3) DEFAULT NULL COMMENT 'Numero de dias para uso del medicamento cuando el termino es definido según : HCL_TERMED_HCOR',
  `hcl_gesfec_hcor` date DEFAULT NULL COMMENT 'Fecha solicitud del servicio al paciente',
  `hcl_geshor_hcor` decimal(5,2) DEFAULT NULL COMMENT 'Hora solicitud del servicio al paciente en formato militar  (HH) ejm: 16',
  `hcl_tiptur_hctu` varchar(3) DEFAULT NULL COMMENT 'Codigo clasificacion turnos diarios para la prestacion de servicios medicos',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que autoriza el servicio o medicamento',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo del centro de produccion donde se presta el servicio',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Codigo area donde se presta el servicio ',
  `hcl_sisfec_hcor` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando se genera registro del evento',
  `hcl_sishor_hcor` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema al generar registro de evento en formato militar  (HH) ejm: 16',
  `hcl_notreg_hcor` text COMMENT 'Nota justificacion del servicio y para los medicamentos se ecriber dosificacion  para el paciente',
  `hcl_tipser_hcor` varchar(1) DEFAULT NULL COMMENT 'Tipo servicio: 1 = Servicio o medicamento 2= Indicacion medica',
  `hcl_tserax_hcor` varchar(10) DEFAULT NULL COMMENT 'Tipo servicio auxiliar para multiples usos: NA = No aplica 1= Medicamentos desde ademecum (solo para formulacion medica)',
  `hcl_envfac_hcor` varchar(1) DEFAULT NULL COMMENT 'Enviar el registro para generar facturacion 1=Si 2= No',
  `hcl_envalm_hcor` varchar(1) DEFAULT NULL COMMENT 'Enviar el registro para descargar de stock farmacia  o almacen 1=Si 2= No',
  `hcl_confac_hcor` varchar(1) DEFAULT NULL COMMENT 'Pendiente por confiramar registro en facturacion 1=Si 2= No',
  `hcl_conalm_hcor` varchar(1) DEFAULT NULL COMMENT 'Pendiente por confiramr registro en farmacia 1=Si 2= No',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`hcl_nroreg_hcor`),
  KEY `hcor02` (`hcl_nroreg_hcms`),
  KEY `hcor03` (`adm_secadm_rgad`),
  KEY `hcor04` (`sia_idesec_usua`),
  KEY `hcor05` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclregordeserms` table : 
#

DROP TABLE IF EXISTS `hclregordeserms`;

CREATE TABLE `hclregordeserms` (
  `hcl_nroreg_hcms` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico registro maestro en la orden que los agrupa',
  `hcl_secreg_hcms` int(10) DEFAULT NULL COMMENT 'Numero secuencial del registro medico  para organizar la vista cronologica',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial actividad medica en historial medico del paciente',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `hcl_tipreg_hctr` varchar(4) DEFAULT NULL COMMENT 'Codigo clasificacion tipo registro actividad registrada al paciente en ordenes medicas',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `hcl_gesfec_hcms` date DEFAULT NULL COMMENT 'Fecha solicitud del servicio al paciente',
  `hcl_geshor_hcms` decimal(5,2) DEFAULT NULL COMMENT 'Hora solicitud del servicio al paciente en formato militar  (HH) ejm: 16.25',
  `hcl_tiptur_hctu` varchar(3) DEFAULT NULL COMMENT 'Codigo clasificacion turnos diarios para la prestacion de servicios medicos',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que autoriza el servicio o medicamento',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`hcl_nroreg_hcms`),
  KEY `hcms02` (`hcl_nroreg_hcev`),
  KEY `hcms03` (`adm_secadm_rgad`),
  KEY `hcms04` (`sia_idesec_usua`),
  KEY `hcms05` (`sia_nroide_usua`),
  KEY `hcms06` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hcltesteadareas` table : 
#

DROP TABLE IF EXISTS `hcltesteadareas`;

CREATE TABLE `hcltesteadareas` (
  `hcl_nroreg_hcea` varchar(6) NOT NULL DEFAULT '' COMMENT 'Codigo unico area del desarrollo evaluada',
  `hcl_desreg_hcea` varchar(80) DEFAULT NULL COMMENT 'Descripcion area del desarrollo evaluada',
  `hcl_conser_hcea` int(6) DEFAULT NULL COMMENT 'Contador para generar registros detalles',
  `hcl_estreg_hcea` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2=Inactivo',
  PRIMARY KEY (`hcl_nroreg_hcea`),
  KEY `hcea02` (`hcl_desreg_hcea`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hcltesteadescal` table : 
#

DROP TABLE IF EXISTS `hcltesteadescal`;

CREATE TABLE `hcltesteadescal` (
  `hcl_nroreg_hceb` varchar(6) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial del registro generado por el sistema',
  `hcl_nroreg_hcea` varchar(3) DEFAULT NULL COMMENT 'Area del desarrollo evaluada',
  `hcl_nroreg_hcer` varchar(5) DEFAULT NULL COMMENT 'Rango según area y edad ejemplo (de un mes y un dia hasta 60 dias)',
  `hcl_puntos_hceb` float(6,2) DEFAULT NULL COMMENT 'Puntuacion directa obtenida en el test según area evaluada',
  `hcl_medini_hceb` float(6,2) DEFAULT NULL COMMENT 'Rango edad inicial valores en dias',
  `hcl_medfin_hceb` float(6,2) DEFAULT NULL COMMENT 'Rango edad final valores en dias',
  `hcl_valran_hceb` int(4) DEFAULT NULL COMMENT 'Valor obtenido según rango edad y puntacion directa',
  `hcl_estreg_hceb` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2=Inactivo',
  PRIMARY KEY (`hcl_nroreg_hceb`),
  KEY `hceb02` (`hcl_nroreg_hcea`),
  KEY `hceb03` (`hcl_nroreg_hcer`),
  KEY `hceb04` (`hcl_puntos_hceb`),
  KEY `hceb05` (`hcl_medini_hceb`),
  KEY `hceb06` (`hcl_medfin_hceb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hcltesteadrango` table : 
#

DROP TABLE IF EXISTS `hcltesteadrango`;

CREATE TABLE `hcltesteadrango` (
  `hcl_nroreg_hcer` varchar(6) NOT NULL DEFAULT '' COMMENT 'Codigo unico rango según area del desarrollo evaluada',
  `hcl_nroreg_hcea` varchar(6) DEFAULT NULL COMMENT 'Codigo unico area del desarrollo evaluada',
  `hcl_nroran_hcer` int(2) DEFAULT NULL COMMENT 'Numero del rango para gestion en la grafica',
  `hcl_desreg_hcer` varchar(80) DEFAULT NULL COMMENT 'Descripcion Rango edad area del desarrollo evaluada',
  `hcl_estreg_hcer` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Activo 2=Inactivo',
  PRIMARY KEY (`hcl_nroreg_hcer`),
  KEY `hcer02` (`hcl_nroreg_hcea`),
  KEY `hcer03` (`hcl_desreg_hcer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hcltipodocument` table : 
#

DROP TABLE IF EXISTS `hcltipodocument`;

CREATE TABLE `hcltipodocument` (
  `hcl_coddoc_htdo` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo clasificacion tipo docuemtno de historia clinica',
  `hcl_desdoc_htdo` varchar(80) DEFAULT NULL COMMENT 'Descripcion  clasificada  tipo documento en historial del paciente',
  `hcl_ordvis_htdo` int(2) DEFAULT NULL COMMENT 'Orden visualizacion del docuemtno en historial medico',
  PRIMARY KEY (`hcl_coddoc_htdo`),
  KEY `htdo02` (`hcl_desdoc_htdo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hcltipoliquidos` table : 
#

DROP TABLE IF EXISTS `hcltipoliquidos`;

CREATE TABLE `hcltipoliquidos` (
  `hcl_codliq_hctl` varchar(2) NOT NULL DEFAULT '' COMMENT 'Tipo liquido administrado o eliminado',
  `hcl_desliq_hctl` varchar(30) DEFAULT NULL COMMENT 'Descripcion  del liquido administrado o eliminado',
  `hcl_tipliq_hctl` varchar(1) DEFAULT NULL COMMENT 'Tipo liquido: 1=Administrable  2= Eliminable',
  PRIMARY KEY (`hcl_codliq_hctl`),
  KEY `hctl02` (`hcl_desliq_hctl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hcltiporegactiv` table : 
#

DROP TABLE IF EXISTS `hcltiporegactiv`;

CREATE TABLE `hcltiporegactiv` (
  `hcl_secreg_hcca` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo unico secuencial registro en la tabla (generado por el sistema)',
  `hcl_codreg_hcra` varchar(4) DEFAULT NULL COMMENT 'Codigo unico registro del grupo actividad para vista captura Historia clinica',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia',
  `hcl_desreg_hcca` varchar(80) DEFAULT NULL COMMENT 'Descripcion  Tipo de registro actividad clasificada en historial del paciente',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo formato plantilla asociada para generar registro actividad en historia clinica',
  `sys_codtip_sytm` varchar(10) DEFAULT NULL COMMENT 'Codigo unico tipos de mensaje que desencadena en el adminstrador de mensajeria del sistema',
  `hcl_imagen_hcca` varchar(60) DEFAULT NULL COMMENT 'Nombre de la imagen que representa el registro de actividad en las diferentes vistas',
  `hcl_icolor_hcca` varchar(20) DEFAULT NULL COMMENT 'Color del fondo en la vista navegacion del historial clinico',
  `hcl_rutarc_hcca` varchar(90) DEFAULT NULL COMMENT 'Ruta en historial clinico de archivos generados por el grupo de actividad',
  `hcl_ordvis_hcca` int(3) DEFAULT NULL COMMENT 'Orden visualizacion dentro de lista grupos',
  `hcl_psubgr_hcca` varchar(1) DEFAULT NULL COMMENT 'Primer registro cada subgrupo cuando dentro de un grupo hay varios sugrupos: 1= Primer registro 2=No es primero',
  `hcl_mededi_hcca` varchar(1) DEFAULT NULL COMMENT 'Medida edad inicial a la cual aplica la actividad medica para validación pertinencia: 1=Años 2=Meses 3=Días',
  `hcl_edaini_hcca` int(6) DEFAULT NULL COMMENT 'Edad inicial para la cual aplica la validación de pertinencia',
  `hcl_mededf_hcca` varchar(1) DEFAULT NULL COMMENT 'Medida edad fina a la cual aplica el servicio, para validación pertinencia actividad medica:1=Años 2=Meses 3=Días',
  `hcl_edafin_hcca` int(6) DEFAULT NULL COMMENT 'Edad final para la cual aplica la validación de pertinencia',
  `hcl_sexapl_hcca` varchar(1) DEFAULT NULL COMMENT 'Sexo al cual aplica la actividad medica: 1=Masculino 2=Femenino 3=Ambos',
  `hcl_mededl_hcca` varchar(1) DEFAULT NULL COMMENT 'Medida edad validacion para lista valores permitidos pertinencia: 1=Años 2=Meses 3=Días',
  `hcl_listar_hcca` varchar(250) DEFAULT NULL COMMENT 'Lista valores permitidos validacion edad según rango separados por el carácter COMA',
  `hcl_parxml_hcca` text COMMENT 'Lista parametros en formato XML para los objetos que esten marcados para cargar Valores personalizados al gestionar los formatos en vista historias clinicas',
  `hcl_estreg_hcca` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1= Activo 2= Inactivo',
  PRIMARY KEY (`hcl_secreg_hcca`),
  KEY `hcca02` (`hcl_codreg_hcra`),
  KEY `hcca03` (`hcl_codreg_hcca`),
  KEY `hcca04` (`hcl_desreg_hcca`),
  KEY `hcca05` (`sys_codtip_sytm`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hcltiporegserms` table : 
#

DROP TABLE IF EXISTS `hcltiporegserms`;

CREATE TABLE `hcltiporegserms` (
  `hcl_tipreg_hctr` varchar(4) NOT NULL DEFAULT '' COMMENT 'Codigo clasificacion tipo registro actividad registrada al paciente en ordenes medicas',
  `hcl_desreg_hctr` varchar(80) DEFAULT NULL COMMENT 'Descripcion  clasificacion tipo registro actividad registrada al paciente en ordenes medicas',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'lasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia',
  PRIMARY KEY (`hcl_tipreg_hctr`),
  KEY `hctr02` (`hcl_desreg_hctr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hcltiporegturno` table : 
#

DROP TABLE IF EXISTS `hcltiporegturno`;

CREATE TABLE `hcltiporegturno` (
  `hcl_tiptur_hctu` varchar(3) NOT NULL DEFAULT '' COMMENT 'Codigo clasificacion turnos diarios para la prestacion de servicios medicos',
  `hcl_destur_hctu` varchar(20) DEFAULT NULL COMMENT 'Descripcion  clasificacion turnos diarios',
  `hcl_horini_hctu` decimal(5,2) DEFAULT NULL COMMENT 'Hora inicio del turno en formato militar  (HH) ejm: 16',
  `hcl_horfin_hctu` decimal(5,2) DEFAULT NULL COMMENT 'Hora fin del turno en formato militar  (HH) ejm: 16',
  PRIMARY KEY (`hcl_tiptur_hctu`),
  KEY `hctu02` (`hcl_destur_hctu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclvariabactual` table : 
#

DROP TABLE IF EXISTS `hclvariabactual`;

CREATE TABLE `hclvariabactual` (
  `hcl_nroreg_hcva` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico registro maestro variables publicas actualizadas',
  `hcl_nomvar_hcvr` varchar(30) DEFAULT NULL COMMENT 'Nombre unico identificador de la variable, para referencia dentro del sistema, este nombre debe incluir nombre identificador del grupo al que pertenece, ejemplo variables : VACUNACION_NIÑO_DPT_DOSIS1, JOVEN_PLANIFICACION_SI_NO',
  `hcl_nivvar_hcvr` varchar(1) DEFAULT NULL COMMENT 'Nivel gestion variable (1,2,3) : 1= Unica permanente en historia clinica, ejemplo: Numero admision activa 2=Unica tmporal en evento de admision, ejemplo: Diagnostico de ingreso, 3= Variable temporal gestion evento, ejemplo: resultado de laboratorios',
  `hcl_valvar_hcvr` text COMMENT 'Valor digitado como dato actualizado de la variable',
  `hcl_valdes_hcva` text COMMENT 'Descripcion del valor digitado como dato actualizado de la variable',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `hcl_fecges_hcva` date DEFAULT NULL COMMENT 'Fecha gestion cuando se actualizo el valor de la variable',
  `hcl_horges_hcva` decimal(5,2) DEFAULT NULL COMMENT 'Hora gestion al cuando se actualizo el valor,  en formato militar  (HH) ejm: 16',
  `hcl_auxges_hcva` varchar(30) DEFAULT NULL COMMENT 'Campo auxiliar, para realizar marcas y procesos en gestion de variables, poner estados y demas',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`hcl_nroreg_hcva`),
  KEY `hcva02` (`hcl_nomvar_hcvr`),
  KEY `hcva03` (`adm_secadm_rgad`),
  KEY `hcva04` (`sia_idesec_usua`),
  KEY `hcva05` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclvariabgrupos` table : 
#

DROP TABLE IF EXISTS `hclvariabgrupos`;

CREATE TABLE `hclvariabgrupos` (
  `hcl_secgru_hcgv` varchar(5) NOT NULL COMMENT 'Codigo grupo de variables, generado por el sistema',
  `hcl_desgru_hcgv` varchar(40) DEFAULT NULL COMMENT 'Descripcion de la clasificacion grupo de variables',
  `hcl_nomvar_hcgv` varchar(10) DEFAULT NULL COMMENT 'Nombre de la variable que representa el grupo, este nombre se usara como prefijo en todas las variables que esten asociadas al grupo, ejemplo: c',
  `hcl_conobj_hcgv` int(6) DEFAULT NULL COMMENT 'Contador para generar id unicos de registros',
  `hcl_sisgru_hcgv` varchar(1) DEFAULT NULL COMMENT 'Grupo del sistema: 1= Grupo protegido de sistema 2=Grupo normal no protegido',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`hcl_secgru_hcgv`),
  KEY `hcgv02` (`hcl_desgru_hcgv`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclvariabmaestr` table : 
#

DROP TABLE IF EXISTS `hclvariabmaestr`;

CREATE TABLE `hclvariabmaestr` (
  `hcl_nroreg_hcvr` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico registro maestro variables publicas de gestion',
  `hcl_secgru_hcgv` varchar(5) DEFAULT NULL COMMENT 'Codigo grupo, al cual se asocia la variable',
  `hcl_ordvis_hcvr` int(5) DEFAULT NULL COMMENT 'Numero para orden vista en gestion impresión en formatos dentro del grupo al que pertenece',
  `hcl_titulo_hcvr` varchar(150) DEFAULT NULL COMMENT 'Titulo de la variable',
  `hcl_descri_hcvr` varchar(240) DEFAULT NULL COMMENT 'Descripción larga de la variable',
  `hcl_nomvar_hcvr` varchar(30) DEFAULT NULL COMMENT 'Nombre unico identificador de la variable, para referencia dentro del sistema, este nombre debe incluir nombre identificador del grupo al que pertenece, ejemplo variables : VACUNACION_NIÑO_DPT_DOSIS1, JOVEN_PLANIFICACION_SI_NO',
  `hcl_tipval_hcvr` varchar(1) DEFAULT NULL COMMENT 'Tipo valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico,F=Flotante,E=Decimal',
  `hcl_valper_hcvr` text COMMENT 'Valores permitidos para el campo',
  `hcl_valvar_hcvr` text COMMENT 'Valor por defecto al iniciar captura de datos en la variable',
  `hcl_camdig_hcvr` varchar(1) DEFAULT NULL COMMENT 'Campo digitable: 1=Valor es modificable  2=Valor modficable desde procesos para variables resumen y otros, 3=Valor protegido.',
  `hcl_ranini_hcvr` varchar(15) DEFAULT NULL COMMENT 'Rango inicial general del valor digitable',
  `hcl_ranfin_hcvr` varchar(15) DEFAULT NULL COMMENT 'Rango final general del valor digitable',
  `hcl_raninr_hcvr` varchar(15) DEFAULT NULL COMMENT 'Rango inicial valores normales dentro del rango general (para gestion posibles alarmas)',
  `hcl_ranfnr_hcvr` varchar(15) DEFAULT NULL COMMENT 'Rango final valores normales dentro del rango general (para gestion posibles alarmas)',
  `hcl_nivvar_hcvr` varchar(1) DEFAULT NULL COMMENT 'Nivel gestion variable (1,2,3) : 1= Varable unica en la historia clinica, ejemplo: numero de admision activa 2=Variables unica en un evento de admision, ejemplo: el diagnostico de ingreso, 3= Varables de gestion evento, ejemplo: resultado de laborato',
  `hcl_sistem_hcvr` varchar(1) DEFAULT NULL COMMENT 'Evaluar gestion de datos y notifcar alarma para valores referenciados como anormales: 1= Variable normal 2=Genera notificacion cuando hay valores anormales',
  `hcl_modoca_hcvr` varchar(1) DEFAULT NULL COMMENT 'Modo captura de datos: 1=Variable simple captura de datos 2=Resumen general todas las variables del grupo 3=Resumen variables del grupo que contengan datos',
  `hcl_resume_hcvr` varchar(1) DEFAULT NULL COMMENT 'Incluir valor capturado en variable resumen: 1=Incluir en Variables resumen 2= No incluir en variables resumen',
  `hcl_siresu_hcvr` varchar(1) DEFAULT NULL COMMENT 'Saber si Incuir lista variables del campo HCL_VRESUM_HCVR en resumen: 1=Incluir solo lista variables en resumen 2= No incluir lista variables en resumen',
  `hcl_vresum_hcvr` text COMMENT 'Lista separada por comas para Nombre de variables que se tendran en cuenta en el resumen, cuando esta vacia se asume todo el grupo de variables',
  `hcl_tvigen_hcvr` varchar(1) DEFAULT NULL COMMENT 'Vigencia en tiempo de la variable: 1= Indefinido 2=Dias 3=Meses 4 =Años',
  `hcl_vvigen_hcvr` int(6) DEFAULT NULL COMMENT 'Cantidad de tiempo según vigencia de la variable (por defecto cero cuando es indefinido), aplica solo cuando es diferente de indefinido ',
  `hcl_varray_hcvr` varchar(1) DEFAULT NULL COMMENT 'Variable es tipo pila (array): 1=La variable es tipo Array 2=No es tipo array (valor por defecto)',
  `hcl_tmaray_hcvr` int(2) DEFAULT NULL COMMENT 'Tamaño en lista de valores que puede contener la pila (valores de la variable en diferentes tiempos)',
  `hcl_sisvar_hcvr` varchar(1) DEFAULT NULL COMMENT 'Variable protegida del sistema: 1= Protegida 2=Variable no protegida',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`hcl_nroreg_hcvr`),
  KEY `hcvr02` (`hcl_titulo_hcvr`),
  KEY `hcvr03` (`hcl_ordvis_hcvr`),
  KEY `hcvr04` (`hcl_nomvar_hcvr`),
  KEY `hcvr05` (`hcl_secgru_hcgv`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hclviasliquidos` table : 
#

DROP TABLE IF EXISTS `hclviasliquidos`;

CREATE TABLE `hclviasliquidos` (
  `hcl_vialiq_hcvl` varchar(2) NOT NULL DEFAULT '' COMMENT 'Via administracion o eliminacion de liquido',
  `hcl_desvia_hcvl` varchar(30) DEFAULT NULL COMMENT 'Descripcion vias de administracion o eliminacion de liquidos',
  `hcl_tipliq_hcvl` varchar(1) DEFAULT NULL COMMENT 'Tipo via liquido: 1=Administrable  2= Eliminable',
  PRIMARY KEY (`hcl_vialiq_hcvl`),
  KEY `hcvl02` (`hcl_desvia_hcvl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hoscamasareas` table : 
#

DROP TABLE IF EXISTS `hoscamasareas`;

CREATE TABLE `hoscamasareas` (
  `hos_codcam_caho` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo Cama generado por el sistema',
  `hos_nrohab_habi` varchar(10) DEFAULT NULL COMMENT 'Codigo o numero de habitacion en area de servicios donde se encuentra la cama: N201= Segundo piso Neonatos habitacion 201',
  `hos_descam_caho` varchar(40) DEFAULT NULL COMMENT 'Descripcion cama según area funcional',
  `hos_tipcam_tcam` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo cama : 01 =Reclinable electronica   2=Reclinable Mecanica, otras',
  `hos_camaux_caho` varchar(1) DEFAULT NULL COMMENT 'Cama adecuada o auxiliar imporvisada, cuando   no hay camas disponibles (en casos de urgencia), se utilizan camas no adecuadas: 1=Cama Adecuada 2=Cama Auxiliar',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS con el cual se realiza el cobro de la estancia en la cama',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Area prestacion de servicios',
  `hos_codsec_hsec` varchar(10) DEFAULT NULL COMMENT 'Codigo seccion para las subdiviciones de Hopitalización y Urgencias con observación EJM:S001= Hospitalizacion Mujeres, S002 =Hospitalizacion Niños y otras',
  `hos_estcam_ecam` varchar(1) DEFAULT NULL COMMENT 'Codigo estado cama 1-Libre 2-Ocupada 3-Reserva 4-Reparacion 5-Inactiva',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro',
  PRIMARY KEY (`hos_codcam_caho`),
  KEY `caho02` (`hos_descam_caho`),
  KEY `caho03` (`hos_nrohab_habi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hosconfigmodulo` table : 
#

DROP TABLE IF EXISTS `hosconfigmodulo`;

CREATE TABLE `hosconfigmodulo` (
  `hos_codsys_hoxx` varchar(2) CHARACTER SET utf8 NOT NULL COMMENT 'Codigo unico del registro configuración del modulo',
  `hos_epicri_hoxx` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Configuracion obligatoriedad gestion de la epicrisis: 1 = Obligatoria 2=Opcional (no es obligatria) 3= Obligatoria según horas Minimas campo (HOS_EPICRH_HOXX)',
  `hos_epicrh_hoxx` int(2) DEFAULT NULL COMMENT 'Numero de horas minimas en estancia para que la epicrisis se haga obligatoria',
  `hos_autegr_hoxx` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Gestion de autorizacion de egreso hospitalario: 1=No permitir antes de registro egreso urgencias/hospitalización 2=Permitir despues de registro egreso urgencias/Hospitalización',
  `hos_format_hoxx` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Gestion formatos al finalizar atención medica 1= Confirmar formatos abiertos al finalizar atención 2= No finalizar atencion cuando hay formatos abiertos',
  PRIMARY KEY (`hos_codsys_hoxx`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Structure for the `hosestadocama` table : 
#

DROP TABLE IF EXISTS `hosestadocama`;

CREATE TABLE `hosestadocama` (
  `hos_estcam_ecam` varchar(1) NOT NULL DEFAULT '' COMMENT 'Codigo estado cama 1-Libre 2-Ocupada 3-Reserva 4-Reparacion 5-Inactiva',
  `hos_desest_ecam` varchar(40) DEFAULT NULL COMMENT 'Descripcion textual del estado de la cama',
  PRIMARY KEY (`hos_estcam_ecam`),
  KEY `ecam02` (`hos_desest_ecam`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hosestanciapaci` table : 
#

DROP TABLE IF EXISTS `hosestanciapaci`;

CREATE TABLE `hosestanciapaci` (
  `hos_codesp_espa` varchar(20) NOT NULL COMMENT 'Codigo unico del registro de estancia hospitalaria generado por el sistema',
  `hos_vistar_espa` int(5) DEFAULT NULL COMMENT 'Orden generado del registro para manejo de datos relacionados con registros anteriores de traslados',
  `hos_tipesp_espa` varchar(1) DEFAULT NULL COMMENT 'Tipo traslado para saber si es incial desde urgencias: 1=Traslado de Urgencias a Hospitalizacion 2=Traslado intrahospitalario',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Unico de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificacion del usuario o Paciente  según las normas vigentes para gestion de datos ejm: CC= Cedula, RC= Rgistro Civil',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `hos_codant_caho` varchar(10) DEFAULT NULL COMMENT 'Codigo Cama anterior es la cama que tenia antes del traslado',
  `hos_codcam_caho` varchar(10) DEFAULT NULL COMMENT 'Codigo nueva cama asignada o actual en la cual queda instalado el paciente',
  `hos_fecing_espa` date DEFAULT NULL COMMENT 'Fecha en que inicia en la nueva cama asignada',
  `hos_horing_espa` decimal(5,2) DEFAULT NULL COMMENT 'Hora de ingreso formato militar ejm: 15.45',
  `hos_fecsal_espa` date DEFAULT NULL COMMENT 'Fecha en la que sale (sea por egreso hospitalario) o pasa a ocupar una nueva cama',
  `hos_horsal_espa` decimal(5,2) DEFAULT NULL COMMENT 'Hora de de salida o finaliza la estancia en la cama, formato militar ejm: 15.45',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código Profesional que autoriza traslado del paciente',
  `hos_diaest_espa` int(4) DEFAULT NULL COMMENT 'Total dias de estancia que se generaron durante la estadia en la cama (se calculan al momento de ir a otro traslado o egreso de la IPS',
  `hos_horest_espa` int(5) DEFAULT NULL COMMENT 'Total hora de  estancia que se generaron durante la estadia en la cama (se calculan al momento de ir a otro traslado o egreso de la IPS)',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro de estancia: 1=Abierto 2=confirmado 3= Anulado',
  PRIMARY KEY (`hos_codesp_espa`),
  KEY `espa02` (`adm_secadm_rgad`),
  KEY `espa03` (`sia_idesec_usua`),
  KEY `espa04` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hoshabitaciones` table : 
#

DROP TABLE IF EXISTS `hoshabitaciones`;

CREATE TABLE `hoshabitaciones` (
  `hos_nrohab_habi` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo de habitacion generado por el sistema',
  `hos_deshab_habi` varchar(30) DEFAULT NULL COMMENT 'Numero de habitacion según la seccion fisica donde se encuentre ejm: 201 es la primera habitacion del segundo piso de hospitalizacion mujeres',
  `hos_codsec_hsec` varchar(10) DEFAULT NULL COMMENT 'Codigo seccion de Hopitalización y Urgencias con observación a la cual pertenece la habitacion  Ejm: S001= Hospitalizacion Mujeres, S002 =Hospitalizacion Niños y otras',
  `hos_tiphab_habi` varchar(1) DEFAULT NULL COMMENT 'Tipo habitacion (para saber si es unipersonal o para varias personas) asi: 1= Unipersonal 2=Varias personas',
  `hos_concam_habi` int(5) DEFAULT NULL COMMENT 'Contador para generar el secuencial unico de las camas asignadas en la habitacion',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Codigo estado habItacion  1= Activa 2=Inactiva',
  PRIMARY KEY (`hos_nrohab_habi`),
  KEY `habi02` (`hos_deshab_habi`),
  KEY `habi03` (`hos_codsec_hsec`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hosseccionareas` table : 
#

DROP TABLE IF EXISTS `hosseccionareas`;

CREATE TABLE `hosseccionareas` (
  `hos_codsec_hsec` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo seccion (generado por el sistema)  para las subdiviciones de Hopitalización y Urgencias con observación',
  `hos_dessec_hsec` varchar(40) DEFAULT NULL COMMENT 'Descripcion de la seccion de hospitalización o Urgencias con observación',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Codigo area prestacion de servicios medicos ejm: 002 = Hospitalizacion  003 = Urgencias',
  `hos_estsec_hsec` varchar(1) DEFAULT NULL COMMENT 'Codigo estado seccion: 1=Activa 2= Inactiva',
  PRIMARY KEY (`hos_codsec_hsec`),
  KEY `hsec02` (`hos_dessec_hsec`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `hostipocamas` table : 
#

DROP TABLE IF EXISTS `hostipocamas`;

CREATE TABLE `hostipocamas` (
  `hos_tipcam_tcam` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo Tipo cama : 1 = Cama Metaica de somier Rigido 2 = Cama articulada 3 = Cama electronica motorizada',
  `hos_destip_tcam` varchar(40) DEFAULT NULL COMMENT 'Descripcion Tipos de camas hospitalarias: Cama Metaica de somier Rigido,  Cama articulada, Cama electronica motorizada, Camas Ortopedicas y  mas',
  `sis_codimg_gale` varchar(10) DEFAULT NULL COMMENT 'Codigo de la Imagen PNG/JPG que representa la cama desde la galeria de imágenes ejm: IMG010',
  PRIMARY KEY (`hos_tipcam_tcam`),
  KEY `tcam02` (`hos_destip_tcam`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invajusteconcep` table : 
#

DROP TABLE IF EXISTS `invajusteconcep`;

CREATE TABLE `invajusteconcep` (
  `inv_conaju_incp` varchar(3) NOT NULL DEFAULT '' COMMENT 'Código concepto de Ajuste inventario: 01=Por reconteo inventario 02=Aprovechamiento sobrantes 03= Reingreso prestamos 04=Deterioro del producto y otros',
  `inv_desaju_incp` varchar(50) DEFAULT NULL COMMENT 'Descripción concepto de Ajuste',
  `inv_tipaju_incp` varchar(1) DEFAULT NULL COMMENT 'Tipo ajuste 1= Reconteo Total inventario 2= Por suma o Resta de Unidades',
  `inv_conmov_incm` varchar(4) DEFAULT NULL COMMENT 'Concepto movimiento: E11= Entradas compras E12= Entrada Traslado interno E13=Entradas por ajustes  S21= Salidas Ventas 22= Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida entrega formula A30=Ajuste de inventarios y otros',
  `inv_estreg_incp` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`inv_conaju_incp`),
  KEY `invaj02` (`inv_desaju_incp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invajustesmaema` table : 
#

DROP TABLE IF EXISTS `invajustesmaema`;

CREATE TABLE `invajustesmaema` (
  `inv_secreg_inja` varchar(10) NOT NULL DEFAULT '' COMMENT 'Secuencial unico para cada registro maestro ajuste inventario (generado por el sistema)',
  `inv_fecges_inja` date DEFAULT NULL COMMENT 'Fecha gestion registro ajuste y  movimientos al inventario',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén para el que se realiza el ajuste',
  `inv_conaju_incp` varchar(3) DEFAULT NULL COMMENT 'Código concepto de Ajuste inventario: 01=Por reconteo inventario 02=Aprovechamiento sobrantes 03= Reingreso prestamos 04=Deterioro del producto y otros',
  `inv_conmov_incm` varchar(4) DEFAULT NULL COMMENT 'Concepto movimiento diario: E11 =Entrada saldo inicial inventario o del mes E12= Entradas compras ...  S21= Salidas Ventas 22= Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida entrega formula A30=Ajuste de inventarios y otros',
  `inv_desaju_inja` varchar(150) DEFAULT NULL COMMENT 'Descripcion detalle para nota sobre el proceso de ajuste',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo del centro de producción para contabilizacion de gastos',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atención  cuando hay varias sedes',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código usuario del sistema para los personas que lo requieran (no obligatorio) , NA = cuando no sea requerido',
  `inv_conreg_inja` int(5) DEFAULT NULL COMMENT 'Contador para generar el secuencial unico de registros en detalle (gestion interna)',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`inv_secreg_inja`),
  KEY `inja02` (`inv_codalm_inal`),
  KEY `inja03` (`inv_fecges_inja`),
  KEY `inja04` (`inv_desaju_inja`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invajustesmaemd` table : 
#

DROP TABLE IF EXISTS `invajustesmaemd`;

CREATE TABLE `invajustesmaemd` (
  `inv_secreg_injd` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico para cada registro detalles ajuste inventario (generado por el sistema)',
  `inv_secreg_inja` varchar(10) DEFAULT NULL COMMENT 'Secuencial unico para cada registro maestro ajuste inventario viene de la tabla  INVAJUSTESMAEMA',
  `inv_fecges_inja` date DEFAULT NULL COMMENT 'Fecha gestion registro ajuste y  movimientos al inventario',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén para el que se realiza el ajuste',
  `inv_secart_inar` varchar(20) DEFAULT NULL COMMENT 'Secuencial de articulo generado por el sistema',
  `inv_codaux_inar` varchar(20) DEFAULT NULL COMMENT 'Código Auxiliar del articulo puede ser digitado por el usuario',
  `sis_codgme_sigr` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)',
  `inv_totuni_inex` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES EN ALMACEN, cantidad de unidades en existencias fisicas desde almacen (teniendo en cuenta el lote)',
  `inv_totuni_injd` int(10) DEFAULT NULL COMMENT 'NUEVO TOTAL EXISTENCIAS ALAMACEN, despues de haber realizado el calculo de ajuste este campo contiene la nueva cantidad existencias almacen para el lote',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'Ultimo valor Ingreso unidad de articulos en inventario, por compras',
  `inv_valmov_inar` float(17,2) DEFAULT NULL COMMENT 'ultimo Valor Movimiento de salida (valor venta) cada unidad',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`inv_secreg_injd`),
  KEY `injd02` (`inv_secreg_inja`),
  KEY `injd03` (`inv_codalm_inal`),
  KEY `injd04` (`inv_fecges_inja`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invajustesmaemr` table : 
#

DROP TABLE IF EXISTS `invajustesmaemr`;

CREATE TABLE `invajustesmaemr` (
  `inv_secreg_injr` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico registro lote referencia',
  `inv_secreg_injd` varchar(20) DEFAULT NULL COMMENT 'Secuencial unico para cada registro detalles ajuste inventario, referencia del ajuste articulo',
  `inv_secreg_inja` varchar(10) DEFAULT NULL COMMENT 'Secuencial unico para cada registro maestro ajuste inventario viene de la tabla  INVAJUSTESMAEMA',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén para el que se realiza el ajuste',
  `inv_tipmov_intr` varchar(1) DEFAULT NULL COMMENT 'Tipo registro movimiento inventarios: 1= Entradas 2= Salidas desde tabla: INVTIPOREGIMOVI, este campo se cambia al realizar el calculo de cantidad en sistema y cantidad digitada para ajuste',
  `inv_seckar_inka` varchar(20) DEFAULT NULL COMMENT 'Referencia al Secuencial unico del registro en maestro kardex INVKARDEXMAESTR, que se afecta con el ajuste',
  `inv_secart_inar` varchar(20) DEFAULT NULL COMMENT 'Secuencial de articulo generado por el sistema',
  `inv_codaux_inar` varchar(20) DEFAULT NULL COMMENT 'Código Auxiliar del articulo puede ser digitado por el usuario',
  `inv_lotref_inar` varchar(30) DEFAULT NULL COMMENT 'Lote o Referencia del articulo Artículo',
  `inv_fecven_inka` date DEFAULT NULL COMMENT 'Fecha vencimiento del producto, cuando sea perecedero (Verdura/Medicamentos y otros)',
  `inv_codest_ines` varchar(10) DEFAULT NULL COMMENT 'Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos de control',
  `inv_seccio_ines` varchar(10) DEFAULT NULL COMMENT 'Lista de secciones del estante para validacion (generada por el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones que contenga el estante',
  `inv_totuni_inex` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES EN ALMACEN, cantidad de unidades en existencias fisicas desde almacen (teniendo en cuenta el lote)',
  `inv_totaju_injd` int(10) DEFAULT NULL COMMENT 'UNIDADES DIGITADAS, cantidad de unidades digitadas para realizar calculo según tipo ajuste 1= Reconteo Total inventario 2= Por suma o Resta de Unidades',
  `inv_totmov_injd` int(10) DEFAULT NULL COMMENT 'UNIDADES MOVIMIENTO, Cantidad movimiento para Kardex, según tipo ajuste (1=reconteo/2=suma o resta unidades) si es reconteo:  INV_TOTUNI_INEX - INV_TOTAJU_INJD, Cuando es suma o resta viene de cantidad de unidades digitadas INV_TOTAJU_INJD',
  `inv_totuni_injd` int(10) DEFAULT NULL COMMENT 'NUEVO TOTAL EXISTENCIAS ALAMACEN, despues de haber realizado el calculo de ajuste este campo contiene la nueva cantidad existencias almacen para el lote',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'Ultimo valor Ingreso unidad de articulos en inventario, por compras',
  `inv_valmov_inar` float(17,2) DEFAULT NULL COMMENT 'ultimo Valor Movimiento de salida (valor venta) cada unidad',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`inv_secreg_injr`),
  KEY `injr02` (`inv_secreg_injd`),
  KEY `injr03` (`inv_secreg_inja`),
  KEY `injr04` (`inv_seckar_inka`),
  KEY `injr05` (`inv_codalm_inal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invalmacenestan` table : 
#

DROP TABLE IF EXISTS `invalmacenestan`;

CREATE TABLE `invalmacenestan` (
  `inv_secest_ines` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codgo unico registro del estante generado por el sistema',
  `inv_codest_ines` varchar(10) DEFAULT NULL COMMENT 'Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos de control',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código almacén desde tabla almacenes',
  `inv_desest_ines` varchar(30) DEFAULT NULL COMMENT 'Descripción del estante',
  `inv_numsec_ines` int(2) DEFAULT NULL COMMENT 'Cantidad secciones del estante que contiene el estante (puestos)',
  `inv_seccio_ines` varchar(100) DEFAULT NULL COMMENT 'Lista de secciones del estante para validacion (generada por el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones que contenga el estante',
  `inv_estreg_ines` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`inv_secest_ines`),
  KEY `ines02` (`inv_codest_ines`),
  KEY `ines03` (`inv_desest_ines`),
  KEY `ines04` (`inv_codalm_inal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invalmacenmaest` table : 
#

DROP TABLE IF EXISTS `invalmacenmaest`;

CREATE TABLE `invalmacenmaest` (
  `inv_codalm_inal` varchar(4) NOT NULL DEFAULT '' COMMENT 'Código del Almacén',
  `inv_desalm_inal` varchar(60) DEFAULT NULL COMMENT 'Descripción del almacén',
  `inv_polpre_inal` varchar(1) DEFAULT NULL COMMENT 'Configruacion orgen gestion precio de Venta: 1= Precio según configuracion Maestro almacen (aqui) 2= Precio desde Valores Configuracion en Manual tarifario 3=Precio desde  Configuracion en manual de cada articulo',
  `inv_polppi_inal` varchar(1) DEFAULT NULL COMMENT 'Políticas Precios para calcular Valor venta articulos Almacén: 1=Costo ultima compra mas incremento  2= Precio desde manual articulos',
  `inv_porive_inal` float(5,2) DEFAULT NULL COMMENT 'Porcentaje Incremento para Precios de Venta  Cuando se Controle desde Aquí',
  `inv_redapl_inal` varchar(1) DEFAULT NULL COMMENT 'Aplicar redondeo al generar precio venta de articulos: 1=Aplicar redondeo 2=No aplicar redondeo',
  `inv_redtip_inal` varchar(1) DEFAULT NULL COMMENT 'Tipo ajuste del redondeo:1=Redondeo valor Medio 2=Redondeo superior (llevar al siguente valor) 3=Redondeo inferior (llevar al menor valor)',
  `inv_redval_inal` int(5) DEFAULT NULL COMMENT 'Valor del redondeo que aplicable para generar precio venta articulos, debe ser un valor multiplo de 5, (5,10,15,20,40,50,100,1000…)',
  `inv_gesfar_inal` varchar(1) DEFAULT NULL COMMENT 'Realiza entrega de formulas medicas (medicamentos consulta externa) 1= Entrega de formulas medicas 2= No entrega formulas medicas',
  `inv_geshos_inal` varchar(1) DEFAULT NULL COMMENT 'Gestiona medicamentos intrahospitalarios a pacientes  internados: 1= Gestiona medicamentos a pacientes internados 2= No gestiona medicamentos intrahospitalarios',
  `inv_genfac_inal` varchar(1) DEFAULT NULL COMMENT 'Generar registro facturacion de servicios medicos al entregar medicamentos: 1= Generar facturacion medica al entregar medicamentos 2=No generar registro en facturacion medica',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Codigo area prestacion de servicios medicos  a la cual pertenece el centro de producción',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo del centro de producción para contabilizacion de gastos',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atención  cuando hay varias sedes',
  `inv_conreg_inal` int(5) DEFAULT NULL COMMENT 'Contador para generar el secuencial unico de registros en detalle (gestion interna)',
  `inv_estalm_inal` varchar(1) DEFAULT NULL COMMENT 'Estado del Almacén 1=Activo 2=Inactivo',
  PRIMARY KEY (`inv_codalm_inal`),
  KEY `inval02` (`inv_desalm_inal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invalmacenusuar` table : 
#

DROP TABLE IF EXISTS `invalmacenusuar`;

CREATE TABLE `invalmacenusuar` (
  `inv_codreg_inau` varchar(15) NOT NULL DEFAULT '' COMMENT 'Código registro (generado por el sistema)',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código usuario administrador: Usuario del sistema que realiza gestion del almacen',
  `inv_estreg_inau` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`inv_codreg_inau`),
  KEY `invau02` (`inv_codalm_inal`),
  KEY `invau03` (`sys_codusu_usux`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invalmacexisten` table : 
#

DROP TABLE IF EXISTS `invalmacexisten`;

CREATE TABLE `invalmacexisten` (
  `inv_secreg_incx` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico para cada registro detalle de la tabla (generado por el sistema)',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén que realiza el movimiento',
  `inv_secart_inar` varchar(20) DEFAULT NULL COMMENT 'Secuencial de articulo generado por el sistema',
  `inv_codaux_inar` varchar(20) DEFAULT NULL COMMENT 'Código Auxiliar del articulo puede ser digitado por el usuario',
  `sis_codgme_sigr` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)',
  `sis_codume_sium` varchar(2) DEFAULT NULL COMMENT 'Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,Litros,Gramos y otros',
  `inv_totuni_inex` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES EN EXISTENCIAS, cantidad de unidades en existencias (suma todos los lotes del articulo cuando existen)',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'VALOR INGRESO, Valor Ingreso unidad de articulos en inventario',
  `inv_valmov_inar` float(17,2) DEFAULT NULL COMMENT 'VALOR SALIDA UNIDAD, Valor Movimiento de salida (venta) cada unidad',
  `inv_valcos_inex` float(17,2) DEFAULT NULL COMMENT 'Valor total en costo de compra de actuales existencias en almacen',
  `inv_codest_ines` varchar(10) DEFAULT NULL COMMENT 'Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos de control',
  `inv_seccio_ines` varchar(10) DEFAULT NULL COMMENT 'Lista de secciones del estante para validacion (generada por el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones que contenga el estante',
  `inv_estant_ines` varchar(20) DEFAULT NULL COMMENT 'Codigo del estante sumado con la seccion, para llave de organización vista ejemplo: Estante = E01  y Seccion = S05  queda asi: E01S05',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`inv_secreg_incx`),
  KEY `invex02` (`inv_codalm_inal`),
  KEY `invex03` (`inv_secart_inar`),
  KEY `invex04` (`inv_codaux_inar`),
  KEY `invex05` (`inv_codest_ines`),
  KEY `invex06` (`inv_totuni_inex`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invcontenedores` table : 
#

DROP TABLE IF EXISTS `invcontenedores`;

CREATE TABLE `invcontenedores` (
  `inv_codctn_intc` varchar(2) NOT NULL COMMENT 'Código tipo de contenedor o presentación',
  `inv_desctn_intc` varchar(30) DEFAULT NULL COMMENT 'Descripción del contenedor de Artículo o presentación',
  `inv_estreg_intc` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`inv_codctn_intc`),
  KEY `intc02` (`inv_desctn_intc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invinventgrupos` table : 
#

DROP TABLE IF EXISTS `invinventgrupos`;

CREATE TABLE `invinventgrupos` (
  `inv_codgru_ingr` varchar(5) NOT NULL COMMENT 'Grupo de articulos para gestion contable y clasificacion de inventarios',
  `inv_desgru_ingr` varchar(40) DEFAULT NULL COMMENT 'Descripcion grupo de articulos para gestion contable y clasificacion de inventarios',
  `inv_ordvis_ingr` int(3) DEFAULT NULL COMMENT 'Orden vizualizacion de los registros en vistas',
  `inv_estreg_ingr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`inv_codgru_ingr`),
  KEY `invgr02` (`inv_desgru_ingr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invinventsubgru` table : 
#

DROP TABLE IF EXISTS `invinventsubgru`;

CREATE TABLE `invinventsubgru` (
  `inv_codsub_insg` varchar(6) NOT NULL COMMENT 'Codigo subgrupo de articulos para gestion contable y clasificacion de inventarios',
  `inv_codgru_ingr` varchar(5) DEFAULT NULL COMMENT 'Grupo grupo  de articulos para gestion contable y clasificacion de inventarios',
  `inv_dessub_insg` varchar(40) DEFAULT NULL COMMENT 'Descripcion subgrupo de articulos para gestion contable y clasificacion de inventarios',
  `inv_sifecv_insg` varchar(1) DEFAULT NULL COMMENT 'Activar si el articulo requiere fecha vencimiento al realizar el ingreso a inventario: 1=Requiere Fecha vencimiento  2=No requiere fecha vencimiento',
  `inv_silote_insg` varchar(1) DEFAULT NULL COMMENT 'Activar si el articulo requiere manejo de lote o referencias al realizar el ingreso a inventario: 1=Requiere manejo Lote 2=No requiere Numero Lote',
  `inv_sivida_insg` varchar(1) DEFAULT NULL COMMENT 'Activar si el articulo maneja vida util al realizar el ingreso a inventario: 1=Requiere manejo Vida util 2=No requiere manejo vida util',
  `inv_ordvis_insg` int(3) DEFAULT NULL COMMENT 'Orden vizualizacion de los registros en vistas',
  `inv_estreg_insg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`inv_codsub_insg`),
  KEY `insg02` (`inv_codgru_ingr`),
  KEY `insg03` (`inv_dessub_insg`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invkardexcierre` table : 
#

DROP TABLE IF EXISTS `invkardexcierre`;

CREATE TABLE `invkardexcierre` (
  `inv_seckar_inkc` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico para cada registro detalle de la tabla (generado por el sistema)',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén que realiza el movimiento',
  `inv_codper_inpe` varchar(6) DEFAULT NULL COMMENT 'Perido gestion datos (suma año + mes) ejemplo:  año 2016 mes febrero = 201602',
  `inv_llavkr_inkc` varchar(20) DEFAULT NULL COMMENT 'Llave gestion del registro kardex, suma: Almacen+P+Periodo',
  `inv_fecges_inkc` date DEFAULT NULL COMMENT 'Fecha del registro Cierre: para registro tipo 1 es el prmer dia del mes, para tipo 2 es el ultimo dia del mes',
  `inv_tipreg_inkc` varchar(1) DEFAULT NULL COMMENT 'Tipo registro cierre: 1=Saldo Inicial 2=Saldo Final',
  `inv_secart_inar` varchar(20) DEFAULT NULL COMMENT 'Secuencial de articulo generado por el sistema viene de la tabla:',
  `inv_codaux_inar` varchar(20) DEFAULT NULL COMMENT 'Código Auxiliar del articulo puede ser digitado por el usuario',
  `sis_codgme_sigr` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)',
  `sis_codume_sium` varchar(2) DEFAULT NULL COMMENT 'Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,Litros,Gramos y otros',
  `inv_totuni_inex` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES EXISTENCIAS, cantidad de unidades en existencias',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'ultimo Valor Ingreso unidad de articulos en inventario',
  `inv_valmov_inar` float(17,2) DEFAULT NULL COMMENT 'ultimo Valor Movimiento de salida (venta) cada unidad',
  `inv_unient_inex` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES ENTRADAS en registros de entrada durante el periodo',
  `inv_unisal_inex` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES SALIDAS, en registros de salida durante el periodo',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del usuario que realiza proceso',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro periodo: 1=Abierto 2=Cerrado 3=Anulado',
  PRIMARY KEY (`inv_seckar_inkc`),
  KEY `invkc02` (`inv_codper_inpe`),
  KEY `invkc03` (`inv_llavkr_inkc`),
  KEY `invkc04` (`inv_fecges_inkc`),
  KEY `invkc05` (`inv_secart_inar`),
  KEY `invkc06` (`inv_codaux_inar`),
  KEY `invkc07` (`inv_codalm_inal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invkardexmaestr` table : 
#

DROP TABLE IF EXISTS `invkardexmaestr`;

CREATE TABLE `invkardexmaestr` (
  `inv_seckar_inka` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico para cada registro detalle de la tabla (generado por el sistema)',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén que realiza el movimiento',
  `inv_codper_inpe` varchar(6) DEFAULT NULL COMMENT 'Perido gestion datos (suma año + mes) ejemplo:  año 2016 mes febrero = 201602',
  `inv_llavkr_inka` varchar(20) DEFAULT NULL COMMENT 'Llave gestion del registro kardex, suma: Almacen+P+Periodo',
  `inv_tiparc_inag` varchar(2) DEFAULT NULL COMMENT 'Tipo archivo gestion origen del movimiento en maestro kardex: 01=Registro Inventario inicial 02=Saldo Diario Articulo 03=Gestion compras 04=Movimiento diario (traslado/gasto interno y otros) 05=Entrega medicamento 06=Ajuste inventario 07=Otros',
  `inv_fecges_inka` date DEFAULT NULL COMMENT 'Fecha gestion registro o Movimiento',
  `inv_numdoc_inka` varchar(20) DEFAULT NULL COMMENT 'Numero Registro/documento de gestion movimiento (numero registro entradas por compra, Registro entrega medicamentos a pacientes en farmacia y otros) NA = Para registros entradas por compras',
  `inv_refkar_inka` varchar(20) DEFAULT NULL COMMENT 'Referencia (en esta misma tabla) a registro INV_SECKAR_INKA  en existencias de articulo de donde se toman las unidades para llevarlas a registros de entradas/salida, NA= Cuando no aplica.',
  `inv_tipmov_intr` varchar(1) DEFAULT NULL COMMENT 'Tipo registro movimiento inventarios: 1= Entradas 2= Salidas desde tabla: INVTIPOREGIMOVI',
  `inv_tipreg_inka` varchar(1) DEFAULT NULL COMMENT 'Tipo registro gestion kardex: 1= Saldo inicial del perido 2= Saldo diario 3= Movimientos de entradas o salidas',
  `inv_conmov_incm` varchar(4) DEFAULT NULL COMMENT 'Concepto movimiento: E11= Entradas compras E12= Entrada Traslado interno E13=Entradas por ajustes  S21= Salidas Ventas 22= Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida entrega formula A30=Ajuste de inventarios y otros',
  `inv_secart_inar` varchar(20) DEFAULT NULL COMMENT 'Secuencial de articulo generado por el sistema viene de la tabla Maestro de Articulos',
  `inv_codaux_inar` varchar(20) DEFAULT NULL COMMENT 'Código Auxiliar del articulo puede ser digitado por el usuario',
  `inv_lotref_inar` varchar(30) DEFAULT NULL COMMENT 'Lote o Referencia del articulo Artículo',
  `inv_fecven_inka` date DEFAULT NULL COMMENT 'Fecha vencimiento del producto, cuando sea perecedero (Verdura/Medicamentos y otros)',
  `sis_codgme_sigr` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)',
  `sis_codume_sium` varchar(2) DEFAULT NULL COMMENT 'Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,Litros,Gramos y otros',
  `inv_totuni_inex` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES EXISTENCIAS, cantidad de unidades en existencias en los movimientos de ingreso, se disminuyen hasta cero para cuando hay salidas',
  `inv_tottra_inex` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES TRANSACCION, en transacciones en general del movimiento Entrada/Salida',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'VALOR INGRESO EN COMPRAS, valor Ingreso unidad por compras de articulos en inventario',
  `inv_valmov_inar` float(17,2) DEFAULT NULL COMMENT 'VALOR EN SALIDA VENTA, valor Movimiento de salida (valor venta) cada unidad',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del usuario que realiza el ajuste',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`inv_seckar_inka`),
  KEY `invka02` (`inv_codper_inpe`),
  KEY `invka03` (`inv_llavkr_inka`),
  KEY `invka04` (`inv_fecges_inka`),
  KEY `invka05` (`inv_secart_inar`),
  KEY `invka06` (`inv_codaux_inar`),
  KEY `invka07` (`inv_codalm_inal`),
  KEY `invka08` (`inv_tiparc_inag`),
  KEY `invka09` (`inv_tipmov_intr`),
  KEY `invka10` (`inv_totuni_inex`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invmaearticulos` table : 
#

DROP TABLE IF EXISTS `invmaearticulos`;

CREATE TABLE `invmaearticulos` (
  `inv_secart_inar` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial de articulo generado por el sistema',
  `inv_tipart_inar` varchar(1) DEFAULT NULL COMMENT 'Tipo de articulo: 1=Suministro 2=Medicamentos',
  `inv_codgru_ingr` varchar(5) DEFAULT NULL COMMENT 'Grupo de articulos para gestion contable y clasificacion de inventarios',
  `inv_codsub_insg` varchar(6) DEFAULT NULL COMMENT 'Codigo subgrupo de articulos para gestion contable y clasificacion de inventarios',
  `inv_codaux_inar` varchar(20) DEFAULT NULL COMMENT 'Código Auxiliar del articulo puede ser digitado por el usuario',
  `inv_codbar_inar` varchar(20) DEFAULT NULL COMMENT 'Código de Barra Artículo',
  `inv_lotref_inar` varchar(30) DEFAULT NULL COMMENT 'Lote o Referencia del articulo Artículo',
  `inv_regsan_inar` varchar(30) DEFAULT NULL COMMENT 'Registro sanitario (IMVIMA)',
  `inv_nomart_inar` varchar(80) DEFAULT NULL COMMENT 'Nombre del artículo para vista en informes y gestion',
  `inv_desart_inar` varchar(250) DEFAULT NULL COMMENT 'Descripción del larga del artículo 250 caracteres',
  `inv_secimg_inaj` varchar(10) DEFAULT NULL COMMENT 'Codgo imagen JPG o PNG que representa la grafica del articulo en vista por defecto',
  `inv_simcrt_inar` varchar(1) DEFAULT NULL COMMENT 'Activar si el medicamento es de control: 1=Medicamento Es de control 2=Medicamento no es de control 3=No es medicamento',
  `far_forfar_fama` varchar(20) DEFAULT NULL COMMENT 'Forma farmaceutica del medicamento para RIPS',
  `far_concen_fama` varchar(20) DEFAULT NULL COMMENT 'Concentracion del medicamento para RIPS',
  `far_unimed_fama` varchar(20) DEFAULT NULL COMMENT 'Descripcion Unidad medida del medicamento para RIPS',
  `far_codcum_famd` varchar(20) DEFAULT NULL COMMENT 'Codigo CUM del medicamento (clasificacion unica de medicamentos)',
  `inv_gesips_inar` varchar(1) DEFAULT NULL COMMENT 'Activar gestion de servicios IPS, para enlace con manuales tarifarios y facturacion: 1= Activar referencia a servicio IPS 2= Inactivar referencia a servicio IPS',
  `fcm_idesec_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS para referencia a gestion con modulo facturacion medica NA cuando no aplique',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio IPS facturacion (codigo en tarifario y maestro servicios IPS) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `far_grufar_fagf` varchar(3) DEFAULT NULL COMMENT 'Grupo farmaceutico cuando el articulos es un medicamento, NA Cuando no no aplique',
  `far_sugfar_fasg` varchar(5) DEFAULT NULL COMMENT 'Subgrupo farmacologico del medicamento, NA cuando no aplique',
  `sis_codgme_sigr` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)',
  `sis_codume_sium` varchar(2) DEFAULT NULL COMMENT 'Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,Litros,Gramos y otros',
  `inv_codctn_intc` varchar(2) DEFAULT NULL COMMENT 'Tipo de Contenedor para gestion entradas y salidas del Inventario',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'Valor  al Ingreso a Inventario o costo de compra unidad',
  `inv_uvalin_inar` float(17,2) DEFAULT NULL COMMENT 'Ultimo valor costo de ingreso por compra (costo inmediatamente anterior)',
  `inv_porive_inar` float(5,2) DEFAULT NULL COMMENT 'Porcentaje de Incremento para Generar Precio de Venta (con Base  en Precio de Compra)',
  `inv_valred_inar` float(6,2) DEFAULT NULL COMMENT 'Valor descontado o sumado para ajustar el redondeo al generar el precio de venta, puede ser positivo o negativo',
  `inv_valmov_inar` float(17,2) DEFAULT NULL COMMENT 'Valor al Movimiento o venta este valor puede incluir porcentaje de incremento venta',
  `sis_codiva_tiva` varchar(2) DEFAULT NULL COMMENT 'Código de IVA aplicable al Artículo',
  `inv_sistok_inar` varchar(1) DEFAULT NULL COMMENT 'Activar si el articulo maneja stock minimo y maximo: 1=Maneja stock minimo y maximo 2=No maneja stock minimo y maximo',
  `inv_stkmin_inar` int(10) DEFAULT NULL COMMENT 'cantidad Stock minimo del articulo en inventario, 1=Manejar Stock minimo 2=No manejar Stock minimo',
  `inv_stkmax_inar` int(10) DEFAULT NULL COMMENT 'Cantidad Stock maximo del articulo en inventario',
  `inv_stkntf_inar` int(6) DEFAULT NULL COMMENT 'Numero de unidades para generar notificacion  antes de llegar a cantidad stock minimo ejemplo:  20 unidades antes',
  `inv_conreg_inar` int(5) DEFAULT NULL COMMENT 'Contador para generar el secuencial unico de registros en detalle (gestion interna)',
  `inv_estart_inar` varchar(1) DEFAULT NULL COMMENT 'Estado Artículo 1=Activo 2=Inactivo',
  PRIMARY KEY (`inv_secart_inar`),
  KEY `invar02` (`inv_codaux_inar`),
  KEY `invar03` (`inv_codbar_inar`),
  KEY `invar04` (`inv_lotref_inar`),
  KEY `invar06` (`inv_nomart_inar`),
  KEY `invar07` (`fcm_idesec_sips`),
  KEY `invar08` (`inv_desart_inar`),
  KEY `invar05` (`far_codcum_famd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invmaeartimagen` table : 
#

DROP TABLE IF EXISTS `invmaeartimagen`;

CREATE TABLE `invmaeartimagen` (
  `inv_secimg_inaj` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codgo unico registro  de imagen generado por el sistema',
  `inv_secart_inar` varchar(20) DEFAULT NULL COMMENT 'Secuencial de articulo al cual pertenecen las imágenes',
  `inv_nomimg_inaj` varchar(50) DEFAULT NULL COMMENT 'Nombre completo de la imagene con extencion ejemplo: A453_ARTICULO_2.PNG',
  `inv_estreg_inaj` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`inv_secimg_inaj`),
  KEY `inaj02` (`inv_secart_inar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invmovcomprasma` table : 
#

DROP TABLE IF EXISTS `invmovcomprasma`;

CREATE TABLE `invmovcomprasma` (
  `inv_secreg_inca` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial  unico registro maestro movimientos por compras',
  `inv_tipmov_intr` varchar(1) DEFAULT NULL COMMENT 'Tipo registro movimiento inventarios: 1= Entradas 2= Salidas desde tabla: INVTIPOREGIMOVI',
  `inv_tipreg_incx` varchar(1) DEFAULT NULL COMMENT 'Tipo registro movimiento o documento  (manejo interno del modulo) compra: 1=Cotizacion compra 2=Ordenes de compra 3=Ingresos por compra 4=Devoluciones por compra',
  `inv_conmov_incm` varchar(4) DEFAULT NULL COMMENT 'Concepto movimiento: E11= Entradas compras E12= Entrada Traslado interno E13=Entradas por ajustes  S21= Salidas Ventas 22= Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida entrega formula A30=Ajuste de inventarios y otros',
  `inv_desreg_inca` varchar(200) DEFAULT NULL COMMENT 'Descripción textual del registro',
  `inv_fecges_inca` date DEFAULT NULL COMMENT 'Fecha del registro, cotizacion, orden de compra o  entrada del pedido',
  `inv_numref_inca` varchar(20) DEFAULT NULL COMMENT 'Numero del registro para referenciar la COTIZACION, ORDEN DE COMPRA O INGRESO A INVENTARIO según sea el tipo registro dado en  campo: INV_TIPREG_INCX del manejo interno del modulo',
  `sis_secpro_sipr` varchar(20) DEFAULT NULL COMMENT 'Código Proveedor cuando es un registro de entradas',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén para el cual se realiza el movimiento',
  `con_codsco_ccos` varchar(6) DEFAULT NULL COMMENT 'Código del centro de costo para gestion contable',
  `inv_numdoc_inca` varchar(50) DEFAULT NULL COMMENT 'Numero Documento o Factura,  con la que reporta el proveedor  la entrada de pedidos, o se relaciona',
  `inv_fecdoc_inca` date DEFAULT NULL COMMENT 'Fecha del documento (Numero factura del proveedor)',
  `inv_fecsol_inca` date DEFAULT NULL COMMENT 'Fecha Solicitud del pedido al proveedor',
  `inv_diapla_inca` int(4) DEFAULT NULL COMMENT 'Dias Plazo para pago factura al proveedor',
  `inv_brufac_incd` float(17,2) DEFAULT NULL COMMENT 'Sumatoria Valor Bruto/Neto Facturado sin ninguna deduccion en entradas por compra es valor de factura cliente sin IVA y otras deducciones',
  `inv_pordes_incd` float(5,2) DEFAULT NULL COMMENT 'Porcentaje Descuento (desde la tabla detalles  movimiento compras)',
  `inv_valdes_incd` float(17,2) DEFAULT NULL COMMENT 'Valor total del descuento facturado (desde tabla detalles movimiento compras)',
  `inv_valiva_incd` float(17,2) DEFAULT NULL COMMENT 'Sumatoria Valor total del IVA pagado en la compra (desde tabla detalles movimiento compras)',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'Sumatoria Total del Valor Ingreso articulos en inventario (desde tabla detalles movimiento compras) /sumatoria de registros para validar contra valor factura del proveedor',
  `inv_valfac_incd` float(17,2) DEFAULT NULL COMMENT 'Valor total factura de compra enviada por el proveedor (desde tabla detalles movimiento compras)',
  `inv_salpag_inca` float(17,2) DEFAULT NULL COMMENT 'Valor del saldo pendiente por pagar al proveedor',
  `inv_valred_inar` float(6,2) DEFAULT NULL COMMENT 'Sumatoria total Valor descontado o sumado para ajustar el redondeo precio venta tabla detalles',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del usuario que realiza proceso',
  `inv_fecanu_inca` date DEFAULT NULL COMMENT 'Fecha anulacion del registro de movimiento',
  `inv_conreg_inca` int(5) DEFAULT NULL COMMENT 'Contador para generar el secuencial unico de registros en detalle',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`inv_secreg_inca`),
  KEY `invco02` (`inv_desreg_inca`),
  KEY `invco03` (`sis_secpro_sipr`),
  KEY `invco04` (`inv_codalm_inal`),
  KEY `invco05` (`con_codsco_ccos`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invmovcomprasmd` table : 
#

DROP TABLE IF EXISTS `invmovcomprasmd`;

CREATE TABLE `invmovcomprasmd` (
  `inv_secreg_incd` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico para cada registro detalle de la tabla (generado por el sistema)',
  `inv_secreg_inca` varchar(20) DEFAULT NULL COMMENT 'Secuencial  unico registro maestro movimientos por compras tabla: INVMOVCOMPRASMA',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén desde el maestro almacen',
  `inv_tipreg_incx` varchar(1) DEFAULT NULL COMMENT 'Tipo registro movimiento o documento  (manejo interno del modulo) compra: 1=Cotizacion compra 2=Ordenes de compra 3=Ingresos por compra 4=Devoluciones por compra',
  `inv_conmov_incm` varchar(4) DEFAULT NULL COMMENT 'Concepto movimiento: 11= Entradas compras 12= Entrada Traslado interno 13=Entradas por ajustes  21= Salidas Ventas 22= Salidas Traslado 23= Salidas Otras Áreas Empresa 24= Salida entrega formula 25=Salida suministro intrahospitalario y otros',
  `inv_secart_inar` varchar(20) DEFAULT NULL COMMENT 'Secuencial de articulo generado por el sistema viene de la tabla: MAESTRO ARTICULOS',
  `inv_codaux_inar` varchar(20) DEFAULT NULL COMMENT 'Código Auxiliar del articulo puede ser digitado por el usuario',
  `inv_lotref_inar` varchar(30) DEFAULT NULL COMMENT 'Lote o Referencia del articulo Artículo, se captura dato cuando el subgrupo de inventario lo requiera según configuracion',
  `inv_regsan_inar` varchar(30) DEFAULT NULL COMMENT 'Registro sanitario (IMVIMA) se captura cuando el articulo lo requiera según configracion en manual de articulos',
  `far_codcum_famd` varchar(20) DEFAULT NULL COMMENT 'Codigo CUM del medicamento (clasificacion unica de medicamentos) según expediente INVIMA y presentacion comercial',
  `inv_fecven_incd` date DEFAULT NULL COMMENT 'Fecha vencimiento del producto, cuando sea perecedero (Verdura/Medicamentos y otros)',
  `sis_codgme_sigr` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)',
  `sis_codume_sium` varchar(2) DEFAULT NULL COMMENT 'Unidad Medida como quedaran las existencias en Inventario (libra, metro, litros etc.)  para consumo/salida',
  `inv_codctn_intc` varchar(10) DEFAULT NULL COMMENT 'Código tipo de contenedor o presentación',
  `inv_totctn_incd` int(6) DEFAULT NULL COMMENT 'Total Contenedores para (realizar calculo de ingreso o salida)',
  `inv_unictn_incd` int(6) DEFAULT NULL COMMENT 'Unidades en un Contenedor: Ejemplo: una caja es un contenedor y tiene 10 unidades.',
  `inv_unisue_incd` int(10) DEFAULT NULL COMMENT 'Cantidad unidades sueltas adicinales que no alcanzan para ser contadas como un contenedor mas',
  `inv_unitot_incd` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES, cantidad de unidades en total de la transaccion (calculo Unidades por  contenedor mas unidades sueltas)',
  `inv_unidev_incd` int(10) DEFAULT NULL COMMENT 'UNIDADES EN DEVOLUCION, cantidad de unidades para una devolucion de compra realizada a un proveedor',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'Valor  al Ingreso a Inventario o costo de compra unidad',
  `inv_brufac_incd` float(17,2) DEFAULT NULL COMMENT 'Valor Bruto/Neto Facturado articulo sin ninguna deduccion (desde la tabla detalles movimiento diario)',
  `inv_pordes_incd` float(5,2) DEFAULT NULL COMMENT 'Porcentaje Descuento (desde la tabla detalles movimiento diario)',
  `inv_valdes_incd` float(17,2) DEFAULT NULL COMMENT 'Valor total del descuento facturado',
  `inv_valiva_incd` float(17,2) DEFAULT NULL COMMENT 'Valor total del IVA pagado en la compra',
  `inv_porive_inar` float(5,2) DEFAULT NULL COMMENT 'Porcentaje de Incremento para Generar Precio de Venta (con Base al Precio de Compra)',
  `inv_valred_inar` float(6,2) DEFAULT NULL COMMENT 'Valor descontado o sumado para ajustar el redondeo al generar el precio de venta, puede ser positivo o negativo',
  `inv_valmov_inar` float(17,2) DEFAULT NULL COMMENT 'Valor al Movimiento o venta este valor puede incluir porcentaje de incremento venta',
  `inv_valfac_incd` float(17,2) DEFAULT NULL COMMENT 'Valor total del registro articulo',
  `inv_codest_ines` varchar(10) DEFAULT NULL COMMENT 'Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos de control',
  `inv_seccio_ines` varchar(10) DEFAULT NULL COMMENT 'Lista de secciones del estante para validacion (generada por el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones que contenga el estante',
  `inv_estant_ines` varchar(20) DEFAULT NULL COMMENT 'Codigo del estante sumado con la seccion, para llave de organización vista ejemplo: Estante = E01  y Seccion = S05  queda asi: E01S05',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del usuario que realiza proceso',
  `inv_fecedt_ines` date DEFAULT NULL COMMENT 'Fecha ultima modificacion realizada por un usario',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`inv_secreg_incd`),
  KEY `incd02` (`inv_secreg_inca`),
  KEY `incd03` (`inv_secart_inar`),
  KEY `incd04` (`inv_codalm_inal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invmovdiariosma` table : 
#

DROP TABLE IF EXISTS `invmovdiariosma`;

CREATE TABLE `invmovdiariosma` (
  `inv_secreg_inma` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial  unico registro maestro movimiento inventario',
  `inv_tipmov_intr` varchar(1) DEFAULT NULL COMMENT 'Tipo Registro maestro: 1=Registro de Entrada 2=Registro de Salida',
  `inv_conmov_incm` varchar(4) DEFAULT NULL COMMENT 'Concepto movimiento diario: E11 =Entrada saldo inicial inventario o del mes E12= Entradas compras ...  S21= Salidas Ventas 22= Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida entrega formula A30=Ajuste de inventarios y otros',
  `inv_desreg_inma` varchar(200) DEFAULT NULL COMMENT 'Descripción textual o detalle de la transaccion',
  `inv_fecges_inma` date DEFAULT NULL COMMENT 'Fecha del registro diario o comprobante del movimiento',
  `inv_secref_inma` varchar(20) DEFAULT NULL COMMENT 'Id que referencia INV_SECREG_INMA creado como registro salida por traslado/devoluciones y otros casos  (para referencia de la contraparte)',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén desde el maestro almacen, que inicia la transaccion',
  `inv_codald_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén Destino (para Traslados) desde maestro almacen',
  `con_codsco_ccos` varchar(6) DEFAULT NULL COMMENT 'Código del centro de costo para gestion contable',
  `inv_fecdoc_inma` date DEFAULT NULL COMMENT 'Fecha del documento traslado o entrega suministro, formula medica etc.)',
  `inv_codres_inre` varchar(5) DEFAULT NULL COMMENT 'Código de la persona responsable o que solicita  pedido para gasto interno de la empresa, viene de la tabla: INVRESPONSABLES',
  `sis_coddep_sidp` varchar(5) DEFAULT NULL COMMENT 'Codigo dependencia o departamento de la empresa',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área servicio para gastos medicamentos intrahospitalarios o entrega formulas, tambien cuando se entregan pedidos para gasto inerno de la empresa',
  `inv_brufac_inmd` float(17,2) DEFAULT NULL COMMENT 'Sumatoria Valor Bruto Facturado sin ninguna deduccion (desde la tabla detalles movimiento diario)',
  `inv_pordes_inmd` float(5,2) DEFAULT NULL COMMENT 'Porcentaje Descuento (desde la tabla detalles movimiento diario)',
  `inv_valiva_inmd` float(17,2) DEFAULT NULL COMMENT 'Sumatoria Valor total del IVA descontado en la transaccion',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'Sumatoria Total del Valor Ingreso de articulos en inventario',
  `inv_valmov_inar` float(17,2) DEFAULT NULL COMMENT 'Sumatoria total valor Movimiento de salida entrega medicamentos intrahospitalario o formula medica',
  `inv_valfac_inmd` float(17,2) DEFAULT NULL COMMENT 'Sumatoria valor total con deducciones de la factura',
  `inv_fecanu_inma` date DEFAULT NULL COMMENT 'Fecha anulacion del registro de movimiento',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del usuario que realiza proceso',
  `inv_conreg_inma` int(5) DEFAULT NULL COMMENT 'Contador para generar el secuencial unico de registros en detalle',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`inv_secreg_inma`),
  KEY `invma02` (`inv_desreg_inma`),
  KEY `invma03` (`inv_secref_inma`),
  KEY `invma04` (`inv_fecges_inma`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invmovdiariosmd` table : 
#

DROP TABLE IF EXISTS `invmovdiariosmd`;

CREATE TABLE `invmovdiariosmd` (
  `inv_secreg_inmd` varchar(20) NOT NULL DEFAULT '' COMMENT 'Secuencial unico para cada registro detalle de la tabla (generado por el sistema)',
  `inv_secreg_inma` varchar(20) DEFAULT NULL COMMENT 'Secuencial  unico registro maestro movimiento inventario, relacion con la tabla: INVMOVIMIENTOMA',
  `inv_fecges_inma` date DEFAULT NULL COMMENT 'Fecha del registro diario o comprobante del movimiento',
  `inv_secart_inar` varchar(20) DEFAULT NULL COMMENT 'Secuencial de articulo generado por el sistema viene de la tabla:',
  `inv_codaux_inar` varchar(20) DEFAULT NULL COMMENT 'Código Auxiliar del articulo puede ser digitado por el usuario',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén que realiza el movimiento',
  `inv_codald_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén Destino (para Traslados)',
  `con_codsco_ccos` varchar(6) DEFAULT NULL COMMENT 'Código del centro de costo generado por el sistema',
  `sis_codgme_sigr` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)',
  `inv_coduma_sium` varchar(2) DEFAULT NULL COMMENT 'Unidad Medida como quedaran las existencias en Inventario (libra, metro, litros etc.)  para consumo/salida',
  `inv_codctn_intc` varchar(10) DEFAULT NULL COMMENT 'Código tipo de contenedor o presentación',
  `inv_totctn_inmd` int(6) DEFAULT NULL COMMENT 'Total Contenedores para (realizar calculo de ingreso o salida)',
  `inv_unictn_inmd` int(6) DEFAULT NULL COMMENT 'Unidades en un Contenedor: Ejemplo: una caja es un contenedor y tiene 10 unidades.',
  `inv_unisue_inmd` int(10) DEFAULT NULL COMMENT 'Cantidad unidades sueltas adicinales que no alcanzan para ser contadas como un contenedor mas',
  `inv_unitot_inmd` int(10) DEFAULT NULL COMMENT 'TOTAL UNIDADES, cantidad de unidades en total de la transaccion (calculo Unidades por  contenedor mas unidades sueltas)',
  `inv_unidev_inmd` int(10) DEFAULT NULL COMMENT 'UNIDADES EN DEVOLUCION, cantidad de unidades para una devolucion de compra realizada a un proveedor',
  `inv_valing_inar` float(17,2) DEFAULT NULL COMMENT 'Valor de la Unidad articulo al Ingreso',
  `inv_brufac_inmd` float(17,2) DEFAULT NULL COMMENT 'Valor Bruto del articulo sin ninguna deduccion',
  `inv_pordes_inmd` float(5,2) DEFAULT NULL COMMENT 'Porcentaje Descuento realizado al articulo',
  `inv_valiva_inmd` float(17,2) DEFAULT NULL COMMENT 'Valor total del IVA descontado en articulo',
  `inv_valmov_inar` float(17,2) DEFAULT NULL COMMENT 'Valor Movimiento de salida cada unidad',
  `inv_valfac_inmd` float(17,2) DEFAULT NULL COMMENT 'Valor total con deducciones de la factura',
  `inv_codest_ines` varchar(10) DEFAULT NULL COMMENT 'Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos de control',
  `inv_seccio_ines` varchar(100) DEFAULT NULL COMMENT 'Lista de secciones del estante para validacion (generada por el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones que contenga el estante',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código del usuario que realiza el ajuste',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1=Abierto 2=Confirmado 3=Anulado',
  PRIMARY KEY (`inv_secreg_inmd`),
  KEY `invmd02` (`inv_secreg_inma`),
  KEY `invmd03` (`inv_secart_inar`),
  KEY `invmd04` (`inv_codaux_inar`),
  KEY `invmd05` (`inv_codalm_inal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invperiodomaest` table : 
#

DROP TABLE IF EXISTS `invperiodomaest`;

CREATE TABLE `invperiodomaest` (
  `inv_codper_inpe` varchar(6) NOT NULL DEFAULT '' COMMENT 'Perido gestion datos (suma año + mes) ejemplo:  año 2016 mes febrero = 201602',
  `inv_desper_inpe` varchar(30) DEFAULT NULL COMMENT 'Descripcion textual del periodo',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Código del Almacén para el cual se realiza el movimiento',
  `inv_fecini_inpe` date DEFAULT NULL COMMENT 'Fecha inicio perodo',
  `inv_fecfin_inpe` date DEFAULT NULL COMMENT 'Fecha fin del perodo',
  `inv_peract_inpe` varchar(1) DEFAULT NULL COMMENT 'Periodo activo gestion actual:  1=Periodo actual de gestion 2=Periodo anterior 3=Cerrado',
  `inv_estreg_inpe` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Abierto 2=Cerrado',
  PRIMARY KEY (`inv_codper_inpe`),
  KEY `invpe02` (`inv_desper_inpe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invresponsables` table : 
#

DROP TABLE IF EXISTS `invresponsables`;

CREATE TABLE `invresponsables` (
  `inv_codres_inre` varchar(5) NOT NULL DEFAULT '' COMMENT 'Código de la persona responsable o que solicita  pedido para gasto interno de la empresa, viene de la tabla: INVRESPONSABLES',
  `inv_nroide_inre` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion de la persona natural',
  `inv_nomres_inre` varchar(50) DEFAULT NULL COMMENT 'Descripción del contenedor de Artículo o presentación',
  `inv_telefo_inre` varchar(50) DEFAULT NULL COMMENT 'Teléfono persona responsable',
  `inv_dirres_inre` varchar(80) DEFAULT NULL COMMENT 'Dirección recidencia persona responsable',
  `inv_correo_inre` varchar(90) DEFAULT NULL COMMENT 'Correo electronico',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código usuario del sistema para los personas que lo requieran (no obligatorio) , NA = cuando no sea requerido',
  `inv_estreg_inre` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`inv_codres_inre`),
  KEY `invre02` (`inv_nomres_inre`),
  KEY `invre03` (`sys_codusu_usux`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invtiparchigest` table : 
#

DROP TABLE IF EXISTS `invtiparchigest`;

CREATE TABLE `invtiparchigest` (
  `inv_tiparc_inag` varchar(2) NOT NULL DEFAULT '' COMMENT 'Tipo archivo gestion origen del movimiento en maestro kardex: 01=Registro Inventario inicial 02=Saldo Diario Articulo 03=Gestion compras 04=Movimiento diario (traslado/gasto interno y otros) 05=Entrega medicamento 06=Ajuste inventario 07=Otros',
  `inv_desarc_inag` varchar(50) DEFAULT NULL COMMENT 'Descripción tipo archivo de gestion que genera movimientos en el kardex diario',
  `inv_ordvis_inag` int(3) DEFAULT NULL COMMENT 'Orden vizualizacion cuando se asuma este campo como criterio de organización',
  PRIMARY KEY (`inv_tiparc_inag`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invtipoconcemov` table : 
#

DROP TABLE IF EXISTS `invtipoconcemov`;

CREATE TABLE `invtipoconcemov` (
  `inv_conmov_incm` varchar(4) NOT NULL DEFAULT '' COMMENT 'Concepto movimiento: E11= Entradas compras E12= Entrada Traslado interno E13=Entradas por ajustes  S21= Salidas Ventas 22= Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida entrega formula A30=Ajuste de inventarios y otros',
  `inv_tipmov_intr` varchar(1) DEFAULT NULL COMMENT 'Tipo registro movimiento inventarios: 1= Entradas 2= Salidas desde tabla: INVTIPOREGIMOVI',
  `inv_descon_incm` varchar(20) DEFAULT NULL COMMENT 'Descripción concepto movimiento diario',
  PRIMARY KEY (`inv_conmov_incm`),
  KEY `invcm01` (`inv_descon_incm`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invtiporecompra` table : 
#

DROP TABLE IF EXISTS `invtiporecompra`;

CREATE TABLE `invtiporecompra` (
  `inv_tipreg_incx` varchar(1) NOT NULL DEFAULT '' COMMENT 'Tipo registro movimiento (manejo interno del modulo) compra: 1=Cotizacion compra 2=Ordenes de compra 3=Ingresos por compra 4=Devoluciones por compra',
  `inv_desreg_incx` varchar(20) DEFAULT NULL COMMENT 'Descripción tipo registro movimiento en compras',
  PRIMARY KEY (`inv_tipreg_incx`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `invtiporegimovi` table : 
#

DROP TABLE IF EXISTS `invtiporegimovi`;

CREATE TABLE `invtiporegimovi` (
  `inv_tipmov_intr` varchar(1) NOT NULL DEFAULT '' COMMENT 'Tipo registro movimiento inventarios: 1= Entradas 2= Salidas desde tabla: INVTIPOREGIMOVI',
  `inv_desreg_intr` varchar(20) DEFAULT NULL COMMENT 'Descripción tipo registro',
  PRIMARY KEY (`inv_tipmov_intr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mcicomponenmeci` table : 
#

DROP TABLE IF EXISTS `mcicomponenmeci`;

CREATE TABLE `mcicomponenmeci` (
  `mci_idesec_mcco` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código de Componente',
  `mci_idesec_mcpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de plantilla en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_idesec_mcmo` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de módulos en el sistema MECI, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_etqcom_mcco` varchar(10) DEFAULT NULL COMMENT 'Etiqueta componente',
  `mci_descom_mcco` varchar(200) DEFAULT NULL COMMENT 'Descripción componente',
  `mci_ordvis_mcco` int(3) DEFAULT NULL COMMENT 'Orden Vista',
  `mci_secdet_mcco` int(10) DEFAULT NULL COMMENT 'Campo para generar el secuencial de los parámetros en componentes',
  `mci_estreg_mcco` varchar(1) DEFAULT NULL COMMENT 'Estado del componente',
  PRIMARY KEY (`mci_idesec_mcco`),
  KEY `mcco02` (`mci_descom_mcco`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mcievaluacionde` table : 
#

DROP TABLE IF EXISTS `mcievaluacionde`;

CREATE TABLE `mcievaluacionde` (
  `mci_idesec_mcdt` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código unico del registro pregunta',
  `mci_idesec_mcms` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de evaluaciones en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_idesec_mcpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo de plantilla de evaluación en el sistema',
  `mci_idesec_mcmo` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de módulos en el sistema MECI, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_idesec_mcco` varchar(20) DEFAULT NULL COMMENT 'Código de Componente',
  `mci_idesec_mcpa` varchar(20) DEFAULT NULL COMMENT 'Código de Parámetro',
  `mci_idesec_mcgr` varchar(20) DEFAULT NULL COMMENT 'Código de Grupo',
  `mci_idesec_mcpr` varchar(20) DEFAULT NULL COMMENT 'Código de Pregunta',
  `mci_idesec_mcmd` varchar(3) DEFAULT NULL COMMENT 'Consecutivo maestro respuesta',
  `mci_respre_mcmd` varchar(3) DEFAULT NULL COMMENT 'Calificación de la pregunta  texto',
  `mci_valpre_mcmd` float(5,2) DEFAULT NULL COMMENT 'Calificación o equivalencia  númerica respuesta de la pregunta',
  `mci_eviora_mcdt` varchar(1) DEFAULT NULL COMMENT 'Existe evidencia Oral 1=SI, 2=NO',
  `mci_evifis_mcdt` varchar(1) DEFAULT NULL COMMENT 'Existe evidencia Física 1=SI, 2=NO',
  `mci_otrevi_mcdt` varchar(150) DEFAULT NULL COMMENT 'Existe otro tipo de evidencia, Cual?',
  `mci_estreg_mcdt` varchar(1) DEFAULT NULL COMMENT 'Estado de la Pregunta evaluada 1= Abierta 2= Confirmada 3= Anulada',
  PRIMARY KEY (`mci_idesec_mcdt`),
  KEY `mcdt02` (`mci_idesec_mcpr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mcievaluacionms` table : 
#

DROP TABLE IF EXISTS `mcievaluacionms`;

CREATE TABLE `mcievaluacionms` (
  `mci_idesec_mcms` varchar(20) NOT NULL DEFAULT '' COMMENT 'Consecutivo Único de evaluaciones en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_deseva_mcms` varchar(80) DEFAULT NULL COMMENT 'Descripción de la Evaluación',
  `mci_feceva_mcms` date DEFAULT NULL COMMENT 'Fecha Evaluación',
  `mci_idepla_mcpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de plantilla en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_estreg_mcms` varchar(1) DEFAULT NULL COMMENT 'Estado evaluación',
  PRIMARY KEY (`mci_idesec_mcms`),
  KEY `mcms02` (`mci_deseva_mcms`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mcigrupoprgmeci` table : 
#

DROP TABLE IF EXISTS `mcigrupoprgmeci`;

CREATE TABLE `mcigrupoprgmeci` (
  `mci_idesec_mcgr` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código de Grupo',
  `mci_idesec_mcpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de plantilla en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_idesec_mcmo` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de módulos en el sistema MECI, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_idesec_mcco` varchar(20) DEFAULT NULL COMMENT 'Código de Componente',
  `mci_idesec_mcpa` varchar(20) DEFAULT NULL COMMENT 'Código de Parámetro',
  `mci_etqgrp_mcgr` varchar(10) DEFAULT NULL COMMENT 'Etiqueta Grupo',
  `mci_desgrp_mcgr` varchar(200) DEFAULT NULL COMMENT 'Descripción Grupo',
  `mci_ordvis_mcgr` int(3) DEFAULT NULL COMMENT 'Orden Vista',
  `mci_secdet_mcgr` int(10) DEFAULT NULL COMMENT 'Campo para generar el secuencial de las preguntas dentro de un grupo',
  `mci_estreg_mcgr` varchar(1) DEFAULT NULL COMMENT 'Estado del grupo',
  PRIMARY KEY (`mci_idesec_mcgr`),
  KEY `mcgr02` (`mci_desgrp_mcgr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mcimoduloevmeci` table : 
#

DROP TABLE IF EXISTS `mcimoduloevmeci`;

CREATE TABLE `mcimoduloevmeci` (
  `mci_idesec_mcmo` varchar(20) NOT NULL DEFAULT '' COMMENT 'Consecutivo Único de módulos en el sistema MECI, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_idesec_mcpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de plantilla en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_etqmod_mcmo` varchar(10) DEFAULT NULL COMMENT 'Descripción periodo',
  `mci_desmod_mcmo` varchar(200) DEFAULT NULL COMMENT 'Descripción',
  `mci_ordvis_mcmo` int(3) DEFAULT NULL COMMENT 'Orden Vista',
  `mci_secdet_mcmo` int(10) DEFAULT NULL COMMENT 'Campo para generar el secuencial de los componentes en módulos',
  `mci_estreg_mcmo` varchar(1) DEFAULT NULL COMMENT 'Estado Módulo',
  PRIMARY KEY (`mci_idesec_mcmo`),
  KEY `mcmo02` (`mci_desmod_mcmo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mciparametrmeci` table : 
#

DROP TABLE IF EXISTS `mciparametrmeci`;

CREATE TABLE `mciparametrmeci` (
  `mci_idesec_mcpa` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código de Parámetro',
  `mci_idesec_mcpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de plantilla en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_idesec_mcmo` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de módulos en el sistema MECI, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_idesec_mcco` varchar(20) DEFAULT NULL COMMENT 'Código de Componente',
  `mci_etqpar_mcpa` varchar(10) DEFAULT NULL COMMENT 'Etiqueta Parámetro',
  `mci_despar_mcpa` varchar(200) DEFAULT NULL COMMENT 'Descripción parámetro',
  `mci_ordvis_mcpa` int(3) DEFAULT NULL COMMENT 'Orden Vista',
  `mci_secdet_mcpa` int(10) DEFAULT NULL COMMENT 'Campo para generar el secuencial de los grupos dentro de parámetros',
  `mci_estreg_mcpa` varchar(1) DEFAULT NULL COMMENT 'Estado del parámetro',
  PRIMARY KEY (`mci_idesec_mcpa`),
  KEY `mcpa02` (`mci_despar_mcpa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mciplantillmeci` table : 
#

DROP TABLE IF EXISTS `mciplantillmeci`;

CREATE TABLE `mciplantillmeci` (
  `mci_idesec_mcpl` varchar(20) NOT NULL DEFAULT '' COMMENT 'Consecutivo Único de plantilla en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_despla_mcpl` varchar(200) DEFAULT NULL COMMENT 'Descripción de la plantilla',
  `mci_secdet_mcpl` int(10) DEFAULT NULL COMMENT 'Campo para generar el secuencial de los módulos de una plantilla',
  `mci_estreg_mcpl` varchar(1) DEFAULT NULL COMMENT 'Estado plantilla',
  PRIMARY KEY (`mci_idesec_mcpl`),
  KEY `mcpl02` (`mci_despla_mcpl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mcipreguntameci` table : 
#

DROP TABLE IF EXISTS `mcipreguntameci`;

CREATE TABLE `mcipreguntameci` (
  `mci_idesec_mcpr` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código de Pregunta',
  `mci_idesec_mcpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de plantilla en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_idesec_mcmo` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de módulos en el sistema MECI, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `mci_idesec_mcco` varchar(20) DEFAULT NULL COMMENT 'Código de Componente',
  `mci_idesec_mcpa` varchar(20) DEFAULT NULL COMMENT 'Código de Parámetro',
  `mci_idesec_mcgr` varchar(20) DEFAULT NULL COMMENT 'Código de Grupo',
  `mci_etqpre_mcpr` varchar(10) DEFAULT NULL COMMENT 'Etiqueta Pregunta',
  `mci_despre_mcpr` text COMMENT 'Descripción Pregunta',
  `mci_ordvis_mcpr` int(3) DEFAULT NULL COMMENT 'Orden Vista',
  `mci_estreg_mcpr` varchar(1) DEFAULT NULL COMMENT 'Estado del Pregunta',
  PRIMARY KEY (`mci_idesec_mcpr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mcitiporespuede` table : 
#

DROP TABLE IF EXISTS `mcitiporespuede`;

CREATE TABLE `mcitiporespuede` (
  `mci_idesec_mcmd` varchar(3) NOT NULL DEFAULT '' COMMENT 'Consecutivo maestro respuesta',
  `mci_idesec_mcmr` varchar(3) DEFAULT NULL COMMENT 'Consecutivo maestro respuesta',
  `mci_desres_mcmd` varchar(70) DEFAULT NULL COMMENT 'Descripcion cada respuestas en  evaluacion ejemplo: 1 = Cumple con modelos en manuales 2=No cumple con planes de trabajo',
  `mci_respre_mcmd` varchar(3) DEFAULT NULL COMMENT 'Calificación de la pregunta  texto',
  `mci_valpre_mcmd` float(5,2) DEFAULT NULL COMMENT 'Calificación o equivalencia  numerica respuesta de la pregunta',
  `mci_estreg_mcmd` varchar(1) DEFAULT NULL COMMENT 'Estado tipo respuestas: 1= Activa 2=Inactiva',
  PRIMARY KEY (`mci_idesec_mcmd`),
  KEY `mcmd02` (`mci_desres_mcmd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mcitiporespuems` table : 
#

DROP TABLE IF EXISTS `mcitiporespuems`;

CREATE TABLE `mcitiporespuems` (
  `mci_idesec_mcmr` varchar(3) NOT NULL DEFAULT '' COMMENT 'Consecutivo maestro respuesta',
  `mci_desres_mcmr` varchar(50) DEFAULT NULL COMMENT 'Descripcion del tipo Respuestas en  evaluacion ejemplo: P01 = Respuestas numericas de 1 a 5 (indicadores)',
  `mci_estreg_mcmr` varchar(1) DEFAULT NULL COMMENT 'Estado tipo respuestas: 1= Activa 2=Inactiva',
  PRIMARY KEY (`mci_idesec_mcmr`),
  KEY `mcmr02` (`mci_desres_mcmr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `mcivistaformato` table : 
#

DROP TABLE IF EXISTS `mcivistaformato`;

CREATE TABLE `mcivistaformato` (
  `mci_secfor_mcvf` varchar(30) NOT NULL DEFAULT '' COMMENT 'Id unico vista formatos ejm: VISTA-CAPTURA-PREGUNTAS = Formato para mostrar los grupos y sus respectivas preguntas',
  `mci_desfor_mcvf` varchar(50) DEFAULT NULL COMMENT 'Descripción vista del  modelo formato (XML)',
  `mci_xmlfor_mcvf` mediumtext COMMENT 'Codigo XML de la vista formato',
  PRIMARY KEY (`mci_secfor_mcvf`),
  KEY `mcvf02` (`mci_desfor_mcvf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odnanatomdiente` table : 
#

DROP TABLE IF EXISTS `odnanatomdiente`;

CREATE TABLE `odnanatomdiente` (
  `odn_codana_odan` varchar(1) NOT NULL DEFAULT '' COMMENT 'Codigo anatomia para caras y detalles del diente asi: 1=Vistibular, 2=Mesial,3=Palatino-Lingual,4=Distal, 5=Oclusal, 6 = corona 7 = Diente, 8 = NA',
  `odn_desana_odan` varchar(30) DEFAULT NULL COMMENT 'Descripcion cara del diente',
  PRIMARY KEY (`odn_codana_odan`),
  KEY `odan02` (`odn_desana_odan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odndiagnosticos` table : 
#

DROP TABLE IF EXISTS `odndiagnosticos`;

CREATE TABLE `odndiagnosticos` (
  `odn_coddia_oddx` varchar(20) NOT NULL DEFAULT '' COMMENT 'codigo de la enfermedad según la tabla de diagnostico de la CIE-10',
  `odn_desdia_oddx` varchar(200) DEFAULT NULL COMMENT 'Descripcion Diagnosticos',
  `sia_coddia_tdia` varchar(10) DEFAULT NULL COMMENT 'codigo de la enfermedad según la tabla de diagnostico de la CIE-10',
  `odn_tipvis_oddx` varchar(1) DEFAULT NULL COMMENT 'Tipo Vista Grafica: 1=Graficar caras corona odontograma, 2= graficar diente odontograma ,3 = Otras graficas',
  `odn_codimg_odim` varchar(20) DEFAULT NULL COMMENT 'Codigo unico de la imagen para graficas',
  `odn_estreg_oddx` varchar(1) DEFAULT NULL COMMENT 'Codigo de Estado del Registro',
  PRIMARY KEY (`odn_coddia_oddx`),
  KEY `oddx02` (`odn_desdia_oddx`),
  KEY `oddx03` (`sia_coddia_tdia`),
  KEY `oddx04` (`odn_codimg_odim`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odneventosactde` table : 
#

DROP TABLE IF EXISTS `odneventosactde`;

CREATE TABLE `odneventosactde` (
  `odn_nroreg_odde` varchar(20) CHARACTER SET utf8 NOT NULL COMMENT 'Código registro detalle actividad',
  `odn_secreg_odde` int(5) DEFAULT NULL COMMENT 'Numero secuencial del registro medico  para organizar la vista en detalles de actividad',
  `odn_nroreg_odac` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Código secuencial unico registro maestro actividad (registro principal)',
  `odn_nroreg_odev` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Código maestro evento medico al cual pertenecen los detalles de esta actividad (ODNEVENTOSMAEST)',
  `sia_idesec_usua` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `odn_tipreg_odac` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo tipo registro actividad: 1= Diagnostico, 2= Plan de tratamiento, 3= Evolucion, 4 =  Toma de imágenes',
  `odn_auxreg_odde` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Registro detalle actividad referenciado como principa, para registros del plan de tratamiento debe ser un diagnostico y para evoluciones es tipo Plan de tratamiento (ODN_NROREG_ODDE)',
  `odn_fecact_odac` date DEFAULT NULL COMMENT 'Fecha registro actividad',
  `odn_coddia_oddx` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo unico registro tabla diagnostico odontologia para CIE-10',
  `sia_coddia_tdia` varchar(10) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo de la enfermedad según la tabla de diagnostico de la CIE-10',
  `odn_codser_odsi` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo  servicio IPS odontológico configurado en odontologia',
  `fcm_idesec_sips` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS habilitado para referencia y validacion de pertinencia',
  `fcm_idesec_mant` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo unico del servicio para venta con manual tarifario (generado por el sistema)',
  `fcm_codser_mant` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo en tarifario del servicio para venta y RIPS, pude ser codigo SOAT ISS o CUPS',
  `fcm_coddig_mant` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (puede ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `odn_desreg_odde` varchar(250) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Descripcion del servicio o diagnostico según el tipo de registro actividad',
  `odn_totuni_odde` int(5) DEFAULT NULL COMMENT 'Total unidades del servicio o procedimiento para efectos de facturacion',
  `odn_coddie_oddi` varchar(2) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo del Diente segun el Odontograma al cual se realiza el servicio',
  `odn_codana_odan` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT '(Para vista en reporte) Anatomia para caras y detalles del diente asi: 1=Vistibular, 2=Mesial,3=Palatino-Lingual,4=Distal, 5=Oclusal, 6 = corona 7 = Diente, 8 = NA',
  `odn_carmar_odde` varchar(5) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Caras marcadas del diente cuando la grafica es en la corona  ejm: 1',
  `odn_fecini_odde` date DEFAULT NULL COMMENT 'Fecha inicia trabajos para la actividad',
  `odn_fecfin_odde` date DEFAULT NULL COMMENT 'Fecha finalización actividad',
  `odn_finpro_odde` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Actividad Finaliza procedimiento relacionado : 1= SI  2= No, solo aplica para Actividades de Evolucion, al confirmar las actividades se deben reflejar en  cada procedimiento del Plan de tratamiento',
  `odn_prexis_odde` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Procedimiento pre existente : 1= SI  2= No, solo aplica para  el Plan de Tratamiento, no se  deben mostrar como relacionados en actividades de evolucion del tratamiento ni se deben facturar',
  `odn_estact_odac` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Estado actividad: 1= Pendiente  2= En proceso 3=Finalizada (cuando este finalizada se envia a facturacion) Para los registros de actividades relacionadas a un plan de tratamiento el valor sera 3 = Finalizada',
  `odn_aplvis_odde` varchar(1) DEFAULT NULL COMMENT 'Aplicar Grafica: 1=Aplicar grafica en lista dientes del odontograma 2=Solo aplicar en registro o diente activo',
  `odn_aplist_odde` varchar(200) DEFAULT NULL COMMENT 'Lista (separada por  gion al medio) de dientes para aplicar grafica según valor parametro del campo ODN_APLVIS_ODDE ejemplo: 21-23-27-22',
  `odn_codimg_odim` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo unico de la imagen para graficar',
  `odn_tipvis_odsi` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Tipo Vista Grafica: 1=Graficar caras corona Odontograma 2= Graficar diente odontograma 3 = Otras graficas',
  `odn_imagen_odde` varchar(60) CHARACTER SET utf8 DEFAULT NULL COMMENT 'nombre de la imagen en formato jpg o png que se utilizo para graficar en odontograma (para poder usarla en vista detalles o browser)',
  `sis_estpro_espr` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`odn_nroreg_odde`),
  KEY `odde02` (`odn_nroreg_odac`),
  KEY `odde03` (`odn_desreg_odde`),
  KEY `odde05` (`sia_idesec_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Structure for the `odneventosactms` table : 
#

DROP TABLE IF EXISTS `odneventosactms`;

CREATE TABLE `odneventosactms` (
  `odn_nroreg_odac` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico registro maestro actividad',
  `odn_secreg_odac` int(10) DEFAULT NULL COMMENT 'Numero secuencial del registro medico  para organizar la vista cronologica',
  `odn_nroreg_odev` varchar(20) DEFAULT NULL COMMENT 'Código maestro evento medico al cual pertenece esta actividad (ODNEVENTOSMAEST)',
  `odn_tipreg_odac` varchar(1) DEFAULT NULL COMMENT 'Codigo tipo registro actividad: 1= Diagnostico, 2= Plan de tratamiento, 3= Evolucion, 4 =  Toma de imágenes',
  `hcl_tipreg_hctr` varchar(4) DEFAULT NULL COMMENT 'Codigo clasificacion tipo registro actividad registrada al paciente en ordenes medicas: MEDI= Medicamentos SERV = Servicios EVOL= Evoluciones NENF = Notas de enfermeria  y otros SVIT,INCO,DIAG,ALIQ,ELIQ…',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial actividad medica en historial medico del paciente (modulo historia clinica)',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Codigo de Eps o Asegurador según codigos asignados por la supersalud',
  `odn_fecact_odac` date DEFAULT NULL COMMENT 'Fecha aregistro de actividad',
  `hcl_tiptur_hctu` varchar(3) DEFAULT NULL COMMENT 'Codigo clasificacion turnos diarios para la prestacion de servicios medicos',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codigo centro de produccion donde se presta el servicio solo aplicable para tipo de registros evolucion (para envio a facturacion)',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional  que realiza actividad',
  `odn_sisfec_odac` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando se genera registro del evento',
  `odn_sishor_odac` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema al generar registro de evento en formato militar  (HH) ejm: 16',
  `odn_observ_odac` text COMMENT 'Observacion de la actividad',
  `odn_secdet_odac` int(5) DEFAULT NULL COMMENT 'Campo para generar el secuencial de los registros detalles de cada actividad',
  `odn_estact_odac` varchar(1) DEFAULT NULL COMMENT 'Estado actividad: 1= Pendiente  2= En proceso 3=Finalizada (cuando este finalizada se envia a facturacion) Para los registros de actividades relacionadas a un plan de tratamiento el valor sera 3 = Finalizada',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`odn_nroreg_odac`),
  KEY `odac02` (`sia_idesec_usua`),
  KEY `odac03` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odneventosmaest` table : 
#

DROP TABLE IF EXISTS `odneventosmaest`;

CREATE TABLE `odneventosmaest` (
  `odn_nroreg_odev` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico registro maestro',
  `odn_secreg_odev` int(10) DEFAULT NULL COMMENT 'Numero secuencial del registro medico  para organizar la vista cronologica',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial actividad medica en historial medico del paciente',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificación del usuario o Paciente  según las normas vigentes para gestión de datos ejm: CC= Cedula,otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `odn_fecape_odev` date DEFAULT NULL COMMENT 'Fecha apertura del evento medico',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que inicia el evento',
  `sia_codare_aser` varchar(3) DEFAULT NULL COMMENT 'Código área de servicio donde se prestan los servicios (puede ser la misma desde el ingreso, cuando no hay traslados internos a otras aéreas)',
  `odn_tgrafi_odev` varchar(1) DEFAULT NULL COMMENT 'Tipo grafica vista actividades para graficar: 1=Odontograma adultos 2=Odontograma niños',
  `odn_tipreg_odev` varchar(1) DEFAULT NULL COMMENT 'Tipo tratamiento odontologico: 1=Tratamiento odontologico 2=Consulta externa o Urgencias',
  `odn_sisfec_odev` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando se genera registro del evento',
  `odn_sishor_odev` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema al generar registro de evento en formato militar  (HH) ejm: 16',
  `odn_obsape_odev` text COMMENT 'Observacion para apertura del evento',
  `odn_feccie_odev` date DEFAULT NULL COMMENT 'Datos del cierre  - Fecha cierre o finalizacion del tratamiento',
  `odn_obscie_odev` text COMMENT 'Observacion para cierre  tratamiento',
  `odn_estado_odev` varchar(1) DEFAULT NULL COMMENT 'Estado del tratamiento : 1= Abierto o en  proceso  2 = Finalizado y completado  3 = Finalizado sin  completar',
  `odn_secdet_odev` int(5) DEFAULT NULL COMMENT 'Campo para generar el secuencial para orden vista cada actividad del tratamiento',
  `sis_estpro_espr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado',
  PRIMARY KEY (`odn_nroreg_odev`),
  KEY `odev02` (`sia_idesec_usua`),
  KEY `odev03` (`sia_nroide_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odngrupovistama` table : 
#

DROP TABLE IF EXISTS `odngrupovistama`;

CREATE TABLE `odngrupovistama` (
  `odn_codgru_odva` varchar(4) NOT NULL DEFAULT '' COMMENT 'codigo del grupo vista generado por el sistema',
  `odn_desgru_odva` varchar(40) DEFAULT NULL COMMENT 'Descripcion grupo vista',
  `odn_tipgru_odva` varchar(1) DEFAULT NULL COMMENT 'Tipo GrupoVista Grafica: 1=Graficar grupos  diagnosticos,  2= Grupo Graficaras Servicios',
  `odn_ordvis_odva` int(3) DEFAULT NULL COMMENT 'Orden visualizacion dentro del a lista',
  `odn_codimg_odim` varchar(20) DEFAULT NULL COMMENT 'codigo unico de la imagen que representa el grupo',
  `odn_secdet_odva` int(5) DEFAULT NULL COMMENT 'Campo para generar el secuencial para detalles registros en vista',
  `odn_estreg_odva` varchar(1) DEFAULT NULL COMMENT 'Codigo  estado del Registro: 1= Activo 2= Inactivo',
  PRIMARY KEY (`odn_codgru_odva`),
  KEY `odva02` (`odn_desgru_odva`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odngrupovistamd` table : 
#

DROP TABLE IF EXISTS `odngrupovistamd`;

CREATE TABLE `odngrupovistamd` (
  `odn_codgru_odvd` varchar(10) NOT NULL DEFAULT '' COMMENT 'codigo del registo detalle grupo vista generado por el sistema',
  `odn_codgru_odva` varchar(4) DEFAULT NULL COMMENT 'Codigo del grupo vista al cual esta asociado el registro',
  `odn_desreg_odvd` varchar(60) DEFAULT NULL COMMENT 'Descripcion del registro en la vista',
  `odn_codaux_odvd` varchar(20) DEFAULT NULL COMMENT 'Codigo auxiliar  registro según tipo grupo  diagnostico/procedimiento es CIE 10 SIA_CODDIA_TDIA o Codigo servicio IPS activo en tarifario de ventas FCM_IDESEC_SIPS',
  `odn_ordvis_odvd` int(3) DEFAULT NULL COMMENT 'Orden visualizacion dentro lista del grupo',
  `odn_codimg_odim` varchar(20) DEFAULT NULL COMMENT 'Codigo imagen que representa el registro (no tiene relacion directa con la grafica que se muestra en odontograma)',
  `odn_estreg_odvd` varchar(1) DEFAULT NULL COMMENT 'Codigo estado del Registro: 1= Activo 2= Inactivo',
  PRIMARY KEY (`odn_codgru_odvd`),
  KEY `odvd02` (`odn_desreg_odvd`),
  KEY `odvd03` (`odn_codgru_odva`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odnimagengrafde` table : 
#

DROP TABLE IF EXISTS `odnimagengrafde`;

CREATE TABLE `odnimagengrafde` (
  `odn_codimg_odid` varchar(20) NOT NULL DEFAULT '' COMMENT 'codigo unico del registro detalle imagen para graficas',
  `odn_codimg_odim` varchar(20) DEFAULT NULL COMMENT 'codigo unico de la imagen para graficas desde maestro de imagenes',
  `odn_tipgra_odid` varchar(2) DEFAULT NULL COMMENT 'tipo graficador donde se representa la imagen : 1= Odontograma 2= Vista Maxilofacial y otros',
  `odn_zongra_odid` varchar(2) DEFAULT NULL COMMENT 'Zona grafica donde se muestra la imagen según el graficador ejm: para odontogramas 1= Primer cuadrante 2 = Segundo Cuadrante y otros',
  `odn_iditem_odid` varchar(2) DEFAULT NULL COMMENT 'Codigo del item (opcional no es obligatorio) para especificar puntualmente como se mostrara la grafica en un item en particular',
  `odn_gravis_odid` varchar(2) DEFAULT NULL COMMENT 'tipo vista grafica para odontograma: 1= Vista Corona, 2=Graficar  Corona diente, 3=Graficar en raiz diente, 4=Diente General, 5 = Base Diente (ensia)',
  `odn_llavei_odid` varchar(20) DEFAULT NULL COMMENT 'llave generada para localizar la imagen asi : ODN_CODIMG_ODIM+ODN_TIPGRA_ODID+ODN_ZONGRA_ODID+ODN_IDITEM_ODDI, codigo item grafica (ODN_IDITEM_ODID) es opcional)',
  `odn_desimg_odid` varchar(200) DEFAULT NULL COMMENT 'Descripcion imagen según su funcion o muestra en la grafica en cuadrantes',
  `odn_image1_odid` varchar(60) DEFAULT NULL COMMENT 'nombre de la imagen en formato jpg o png, para vista en grafica estado',
  `odn_image2_odid` varchar(60) DEFAULT NULL COMMENT 'nombre de la imagen en formato jpg o png, para vista en grafica estado',
  `odn_image3_odid` varchar(60) DEFAULT NULL COMMENT 'nombre de la imagen en formato jpg o png, para vista en grafica estado',
  `odn_estreg_odim` varchar(1) DEFAULT NULL COMMENT 'Codigo de Estado del Registro',
  PRIMARY KEY (`odn_codimg_odid`),
  KEY `odid02` (`odn_codimg_odim`),
  KEY `odid03` (`odn_desimg_odid`),
  KEY `odid04` (`odn_llavei_odid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odnimagengrafms` table : 
#

DROP TABLE IF EXISTS `odnimagengrafms`;

CREATE TABLE `odnimagengrafms` (
  `odn_codimg_odim` varchar(20) NOT NULL DEFAULT '' COMMENT 'codigo unico de la imagen para graficas',
  `odn_desimg_odim` varchar(200) DEFAULT NULL COMMENT 'Descripcion imagen según su funcion o muestra en la grafica',
  `odn_imagen_odim` varchar(60) DEFAULT NULL COMMENT 'nombre de la imagen en formato jpg o png, para vista preliminar',
  `odn_visite_odim` varchar(1) DEFAULT NULL COMMENT 'Ocultar vista del item principal al graficar: 1= Ocultar Vista principal item 2 = no coultar vista principal item',
  `odn_estreg_odim` varchar(1) DEFAULT NULL COMMENT 'Codigo de Estado del Registro',
  PRIMARY KEY (`odn_codimg_odim`),
  KEY `odim02` (`odn_desimg_odim`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odnimgcracorona` table : 
#

DROP TABLE IF EXISTS `odnimgcracorona`;

CREATE TABLE `odnimgcracorona` (
  `odn_codcar_odcr` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo  cara del diente y su respectivo estado ejm: Para la cara 1 y estado finalizado que es 3 el resultado es: 13',
  `odn_imagen_odcr` varchar(60) DEFAULT NULL COMMENT 'nombre de la imagen en formato jpg o png, para vista en corona odontograma según la cara y estado',
  PRIMARY KEY (`odn_codcar_odcr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odnmaestdientes` table : 
#

DROP TABLE IF EXISTS `odnmaestdientes`;

CREATE TABLE `odnmaestdientes` (
  `odn_coddie_oddi` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo del Diente segun el Odontograma',
  `odn_desdie_oddi` varchar(50) DEFAULT NULL COMMENT 'Descripcion Diente',
  `odn_codcte_odcd` varchar(1) DEFAULT NULL COMMENT '1=Cuadrante 1, 2=Cuadrante 2, 3=Cuadrante 3, 4=Cuadrante 4',
  `odn_codtdi_odtd` varchar(2) DEFAULT NULL COMMENT 'Codigo Digitado del  tipo diente ejm:  1=Incisivo, 2=Incisivo lateral …',
  `odn_imagen_oddi` varchar(60) DEFAULT NULL COMMENT 'Nombre de la imagen en formato jpg o png, para vista preliminar del diente',
  `odn_estreg_oddi` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`odn_coddie_oddi`),
  KEY `oddi02` (`odn_desdie_oddi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odnmscuadrantes` table : 
#

DROP TABLE IF EXISTS `odnmscuadrantes`;

CREATE TABLE `odnmscuadrantes` (
  `odn_codcte_odcd` varchar(1) NOT NULL DEFAULT '' COMMENT '1=Cuadrante 1, 2=Cuadrante 2, 3=Cuadrante 3, 4=Cuadrante 4',
  `odn_descte_odcd` varchar(30) DEFAULT NULL COMMENT 'Descripcion Cuadrante de la Boca',
  `odn_cardnt_odcd` varchar(5) DEFAULT NULL COMMENT 'Lista caras de los diente segun Anatomia (Tabla ODNANATOMDIENTE) dependiendo del cuadrante ejm: para el cudarante 2 es : 14325',
  PRIMARY KEY (`odn_codcte_odcd`),
  KEY `odcd02` (`odn_descte_odcd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `odnserviciosips` table : 
#

DROP TABLE IF EXISTS `odnserviciosips`;

CREATE TABLE `odnserviciosips` (
  `odn_codser_odsi` varchar(20) CHARACTER SET utf8 NOT NULL COMMENT 'codigo secuencial del registro',
  `fcm_idesec_sips` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo unico secuencial del servicio IPS habilitado para referencia y validacion de pertinencia',
  `odn_serdnt_odsi` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Servicio realizable:  1= Realizable solo en piezas dentales  2 = En cualquier otro lugar de la boca',
  `odn_desser_odsi` varchar(200) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Descripcion servicio',
  `odn_tipvis_odsi` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Tipo Vista Grafica: 1=Graficar caras corona odontograma, 2= graficar diente odontograma ,3 = Otras graficas',
  `odn_codimg_odim` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo unico de la imagen para graficas',
  `odn_estreg_odsi` varchar(1) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo de Estado del Registro',
  PRIMARY KEY (`odn_codser_odsi`),
  KEY `odsi02` (`odn_desser_odsi`),
  KEY `odsi03` (`fcm_idesec_sips`),
  KEY `odsi04` (`odn_codimg_odim`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Structure for the `odntiposdientes` table : 
#

DROP TABLE IF EXISTS `odntiposdientes`;

CREATE TABLE `odntiposdientes` (
  `odn_codtdi_odtd` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo Digitado del  tipo diente ejm:  1=Incisivo, 2=Incisivo lateral …',
  `odn_destdi_odtd` varchar(30) DEFAULT NULL COMMENT 'Descripcion Tipo Diente',
  PRIMARY KEY (`odn_codtdi_odtd`),
  KEY `odtd02` (`odn_destdi_odtd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siaactividadpyp` table : 
#

DROP TABLE IF EXISTS `siaactividadpyp`;

CREATE TABLE `siaactividadpyp` (
  `sia_codact_apyp` varchar(3) NOT NULL DEFAULT '' COMMENT 'actividades de PyP para generar estadisticas y cumplimiento en metas  según resolucion 0412',
  `sia_desact_apyp` varchar(60) DEFAULT NULL COMMENT 'Descripcion Grupo Actividades de PyP',
  PRIMARY KEY (`sia_codact_apyp`),
  KEY `apyp02` (`sia_desact_apyp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siaareapreservi` table : 
#

DROP TABLE IF EXISTS `siaareapreservi`;

CREATE TABLE `siaareapreservi` (
  `sia_codare_aser` varchar(3) NOT NULL DEFAULT '' COMMENT 'Codigo area prestacion de servicios medicos generada por el sistema',
  `sia_desare_aser` varchar(40) DEFAULT NULL COMMENT 'Descripcion area de prestacion servicios medicos',
  `con_codafu_afun` varchar(3) DEFAULT NULL COMMENT 'Codigo area funcional de la empresa a la cual esta asociada esta area de servicios',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atencion  cuando hay varias sedes',
  `adm_codtat_tatn` varchar(1) DEFAULT NULL COMMENT 'Codigo Tipo de Atencion o ambito dende se prestara el servicio dentro de esta area:1=Ambulatoria 2=Hospitalizacion 3=Urgencia',
  `inv_codalm_inal` varchar(4) DEFAULT NULL COMMENT 'Codigo del almacen (desde inventario) desde el cual se descargan los suministros facturados (cuando aplique según tipo servicio y el contrato)',
  `con_ctaing_tpuc` varchar(20) DEFAULT NULL COMMENT 'Codigo cuenta contable según el PUC donde se debe reflejar los valores  de ingreso por entidad (valor facturado)',
  `con_ctapar_tpuc` varchar(20) DEFAULT NULL COMMENT 'Codigo cuenta contable según el PUC donde se debe reflejar los valores por particulares',
  `con_ctamod_tpuc` varchar(20) DEFAULT NULL COMMENT 'Codigo cuenta contable según el PUC donde se debe reflejar los valores por cuota moderadora',
  `con_ctaiva_tpuc` varchar(20) DEFAULT NULL COMMENT 'Codigo cuenta contable según el PUC donde se debe reflejar los valores por recuado IVA',
  `con_ctasum_tpuc` varchar(20) DEFAULT NULL COMMENT 'Codigo cuenta contable según el PUC donde se debe reflejar los valores por suminstros a pacientes',
  `con_ctades_tpuc` varchar(20) DEFAULT NULL COMMENT 'Codigo cuenta contable según el PUC donde se debe reflejar los valores por desucentos realizados',
  `con_ctahon_tpuc` varchar(20) DEFAULT NULL COMMENT 'Codigo cuenta contable según el PUC donde se debe reflejar los valores por gastos honorarios profesional que presta servicio',
  `sia_consec_aser` int(5) DEFAULT NULL COMMENT 'Contador para generar los codigos de las secciones asociadas al area de servicios',
  `sia_estreg_aser` varchar(1) DEFAULT NULL COMMENT 'Estado  del area de prestacion servicios: 1=Activa  2=Inactiva',
  PRIMARY KEY (`sia_codare_aser`),
  KEY `aser02` (`sia_desare_aser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siacentroaten` table : 
#

DROP TABLE IF EXISTS `siacentroaten`;

CREATE TABLE `siacentroaten` (
  `sia_codcat_ceat` varchar(6) NOT NULL DEFAULT '' COMMENT 'Codigo centro de Atencion',
  `sia_descat_ceat` varchar(40) DEFAULT NULL COMMENT 'Descripcion Centro de Atencion  cuando hay varias sedes',
  `sis_codimg_gale` varchar(10) DEFAULT NULL COMMENT 'Codigo de la Imagen PNG/JPG que representa el centro de atencion desde la galeria de imágenes ejm: IMG010',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`sia_codcat_ceat`),
  KEY `ceat02` (`sia_descat_ceat`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siaconsultorios` table : 
#

DROP TABLE IF EXISTS `siaconsultorios`;

CREATE TABLE `siaconsultorios` (
  `sia_codcon_ctor` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo del consultorio donde se prestara el servicio (codigo generado por el sistema)',
  `sia_descon_ctor` varchar(40) DEFAULT NULL COMMENT 'Nombre o descripcion del consultorio',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro  1 =Activo 2=Inactivo',
  PRIMARY KEY (`sia_codcon_ctor`),
  KEY `ctor02` (`sia_descon_ctor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siacopagcontrib` table : 
#

DROP TABLE IF EXISTS `siacopagcontrib`;

CREATE TABLE `siacopagcontrib` (
  `sia_codcpo_cpcb` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo unico para el registro de rangos de copagos y cuotas moderadoras',
  `sia_descpo_cpcb` varchar(40) DEFAULT NULL COMMENT 'Descripcion del porcentaje copago aplicado: NIVEL1  (IBC) MENOR A 2 SMLMV, NIVEL 2 (IBC) DE 2 A 5  SMLMV y mas',
  `sia_tipafi_tafi` varchar(1) DEFAULT NULL COMMENT 'Tipo Afiliado contributivo textual: COTIZANTE o BENEFICIARIO',
  `sia_nivcon_ncon` varchar(1) DEFAULT NULL COMMENT 'Codigo Nivel Contributivo 1,2,3  para Calcular cuotas Moderadoras y copagos',
  `sia_tipcob_cpcb` varchar(1) DEFAULT NULL COMMENT 'Tipo Cobro: 1= Copago 2= Cuota Moderadora',
  `sia_porapl_cpsb` decimal(5,2) DEFAULT NULL COMMENT 'Porcentaje de aplicación del cobro copago o cuota moderadora',
  `sia_tippor_cpsb` varchar(1) DEFAULT NULL COMMENT 'Tipo porcentaje para aplicar: 1=Sobre tarifa del servicio  2= sobre SMLMV 3= Salario SMLDV',
  `sia_maxeve_cpsb` decimal(6,2) DEFAULT NULL COMMENT 'Maximo Porcentaje de aplicación en un evento en salario mensual legal vigente (SMLMV)',
  `sia_maxano_cpsb` decimal(6,2) DEFAULT NULL COMMENT 'Maximo Porcentaje de aplicación en un mismo año, en salario mensual legal vigente (SMLMV)',
  PRIMARY KEY (`sia_codcpo_cpcb`),
  KEY `cpcb02` (`sia_descpo_cpcb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siacopagosisben` table : 
#

DROP TABLE IF EXISTS `siacopagosisben`;

CREATE TABLE `siacopagosisben` (
  `sia_codcpo_cpsb` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo unico para el registro de rangos de copagos según nivel sisben',
  `sia_descpo_cpsb` varchar(40) DEFAULT NULL COMMENT 'Descripcion del porcentaje copago aplicado',
  `sia_tipcob_cpcb` varchar(1) DEFAULT NULL COMMENT 'Tipo Cobro: 1= Copago 2= Cuota Moderadora',
  `sia_nivsbn_nsbn` varchar(1) DEFAULT NULL COMMENT 'Codigo Nivel Sisben para cobro de copagos y cuotas moderadoras según Resolución: 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N',
  `sia_porapl_cpsb` decimal(5,2) DEFAULT NULL COMMENT 'Porcentaje de aplicación del copago',
  `sia_tippor_cpsb` varchar(1) DEFAULT NULL COMMENT 'Tipo porcentaje para aplicar: 1=Sobre tarifa del servicio  2= sobre SMLMV 3= Salario SMLDV',
  `sia_maxeve_cpsb` decimal(6,2) DEFAULT NULL COMMENT 'Maximo Porcentaje de aplicación en un evento en salario mensual legal vigente (SMLMV)',
  `sia_maxano_cpsb` decimal(6,2) DEFAULT NULL COMMENT 'Maximo Porcentaje de aplicación en un mismo año, en salario mensual legal vigente (SMLMV)',
  PRIMARY KEY (`sia_codcpo_cpsb`),
  KEY `cpsb02` (`sia_descpo_cpsb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siacopagpobespe` table : 
#

DROP TABLE IF EXISTS `siacopagpobespe`;

CREATE TABLE `siacopagpobespe` (
  `sia_codcpo_cppe` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo unico para el registro de rangos de copagos según poblacion especial',
  `sia_descpo_cppe` varchar(40) DEFAULT NULL COMMENT 'Descripcion del porcentaje copago aplicado',
  `sia_tipcob_cpcb` varchar(1) DEFAULT NULL COMMENT 'Tipo Cobro: 1= Copago 2= Cuota Moderadora',
  `sia_tippob_tpob` varchar(2) DEFAULT NULL COMMENT 'Codigo del tipo poblacional especial para subsidiado, según normas de base de datos Resol: 1344 de 2012  BDUA: 1= Habitante de la calle 2= Poblacion Infantil y mas',
  `sia_porapl_cpsb` decimal(5,2) DEFAULT NULL COMMENT 'Porcentaje de aplicación del copago',
  `sia_tippor_cpsb` varchar(1) DEFAULT NULL COMMENT 'Tipo porcentaje para aplicar: 1=Sobre tarifa del servicio  2= sobre SMLMV 3= Salario SMLDV',
  `sia_maxeve_cpsb` decimal(6,2) DEFAULT NULL COMMENT 'Maximo Porcentaje de aplicación en un evento en salario mensual legal vigente (SMLMV)',
  `sia_maxano_cpsb` decimal(6,2) DEFAULT NULL COMMENT 'Maximo Porcentaje de aplicación en un mismo año, en salario mensual legal vigente (SMLMV)',
  PRIMARY KEY (`sia_codcpo_cppe`),
  KEY `cppe02` (`sia_descpo_cppe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siadiagnosticos` table : 
#

DROP TABLE IF EXISTS `siadiagnosticos`;

CREATE TABLE `siadiagnosticos` (
  `sia_coddia_tdia` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codgo del diagnostico según la tabla CIE-10',
  `sia_indice_tdia` int(6) DEFAULT NULL COMMENT 'Indice según tamaño del string texto, para mejorar la busqueda',
  `sia_desdia_tdia` varchar(240) DEFAULT NULL COMMENT 'Descripcion del diagnostico',
  `sia_desaux_tdia` varchar(240) DEFAULT NULL COMMENT 'Descripcion auxiliar o aliasdel diagnostico',
  `sia_altcos_tdia` varchar(1) DEFAULT NULL COMMENT 'Marca para saber si es diagnostico de alto costo:1=SI, 2=No',
  `sia_notifc_tdia` varchar(1) DEFAULT NULL COMMENT 'Marca para saber si es diagnostico de notificacion obligatoria: 1=SI, 2 = No',
  `sia_sexapl_tdia` varchar(1) DEFAULT NULL COMMENT 'Sexo al que aplica el diagnostico: A=Ambos, M=Masculino F=Femenino',
  `sia_edaini_tdia` int(8) DEFAULT NULL COMMENT 'Edad incial para la cual aplica el diagnostico',
  `sia_medini_tdia` varchar(1) DEFAULT NULL COMMENT 'Medida edad inical: 1=Año, 2=Meses, 3=Dias',
  `sia_edafin_tdia` int(8) DEFAULT NULL COMMENT 'Edad final para la cual aplica el diagnostico',
  `sia_medfin_tdia` varchar(1) DEFAULT NULL COMMENT 'Medida edad final: 1=Año, 2=Meses, 3=Dias',
  `pyp_nomcam_resc` varchar(10) DEFAULT NULL COMMENT 'Codigo nombre del campo al cual aplica para la Resolucion 4505',
  `pyp_valper_resc` varchar(20) DEFAULT NULL COMMENT 'Valor permitido (según configuracion del campo en res 4505) o valor que se envia al momento de reportar el diagnostico',
  PRIMARY KEY (`sia_coddia_tdia`),
  KEY `tdia04` (`sia_desaux_tdia`),
  KEY `tdia03` (`sia_desdia_tdia`),
  KEY `tdia02` (`sia_indice_tdia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siaespecialimed` table : 
#

DROP TABLE IF EXISTS `siaespecialimed`;

CREATE TABLE `siaespecialimed` (
  `sia_codesp_esme` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo de la especialidad medica que aplica al  servicio (generada por el sistema)',
  `sia_desesp_esme` varchar(40) DEFAULT NULL COMMENT 'Descripcion o nombre de la especialidad medica',
  `sia_espqui_esme` varchar(2) DEFAULT NULL COMMENT 'Especialidad es quirurgica: SI /NO',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado para utilización: 1=Activa 2=Inactiva',
  PRIMARY KEY (`sia_codesp_esme`),
  KEY `esmeo02` (`sia_desesp_esme`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siafinaliconsul` table : 
#

DROP TABLE IF EXISTS `siafinaliconsul`;

CREATE TABLE `siafinaliconsul` (
  `sia_codfco_fcon` varchar(2) NOT NULL COMMENT 'Id Finalidad de la consulta',
  `sia_desfco_fcon` varchar(80) DEFAULT NULL COMMENT 'Descripción de la finalidad',
  PRIMARY KEY (`sia_codfco_fcon`),
  KEY `fcon02` (`sia_desfco_fcon`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siafinaliproced` table : 
#

DROP TABLE IF EXISTS `siafinaliproced`;

CREATE TABLE `siafinaliproced` (
  `sia_codfpr_fpro` varchar(1) NOT NULL COMMENT 'Finalidad del procedimiento (cuando el servicio es un procedimiento)',
  `sia_desfpr_fpro` varchar(80) DEFAULT NULL COMMENT 'Descripción del Procedimiento',
  PRIMARY KEY (`sia_codfpr_fpro`),
  KEY `fpor02` (`sia_desfpr_fpro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siagrupoactipyp` table : 
#

DROP TABLE IF EXISTS `siagrupoactipyp`;

CREATE TABLE `siagrupoactipyp` (
  `sia_codgac_gpyp` varchar(3) NOT NULL DEFAULT '' COMMENT 'Grupo de actividades de PyP para generar estadisticas y cumplimiento en metas  según resolucion 0412',
  `sia_desgac_gpyp` varchar(60) DEFAULT NULL COMMENT 'Descripcion Grupo Actividades de PyP',
  PRIMARY KEY (`sia_codgac_gpyp`),
  KEY `gpyp02` (`sia_desgac_gpyp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sialaboratorios` table : 
#

DROP TABLE IF EXISTS `sialaboratorios`;

CREATE TABLE `sialaboratorios` (
  `sia_codlab_tlab` varchar(3) NOT NULL DEFAULT '' COMMENT 'Codigo del laboratorio que fabrica el medicamento',
  `sia_deslab_tlab` varchar(40) DEFAULT NULL COMMENT 'Nombre o descripción del  laboratorio que fabrica el medicamento',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro  1 =Activo 2=Inactivo',
  PRIMARY KEY (`sia_codlab_tlab`),
  KEY `tlab02` (`sia_deslab_tlab`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siamaeprofespas` table : 
#

DROP TABLE IF EXISTS `siamaeprofespas`;

CREATE TABLE `siamaeprofespas` (
  `sia_codpfa_proa` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo unico del Registro de asignacion de especialidades  (generado por el sistema)',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Codigo unico del Profesional que presta servicio medico (generado por el sistema)',
  `nom_nroide_nomi` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion en nomina',
  `sia_codesp_esme` varchar(5) DEFAULT NULL COMMENT 'Codigo de la especialidad medica que se asigna al profesional',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro  1 =Activo 2=Inactivo',
  PRIMARY KEY (`sia_codpfa_proa`),
  KEY `proa02` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siamaeprofsalud` table : 
#

DROP TABLE IF EXISTS `siamaeprofsalud`;

CREATE TABLE `siamaeprofsalud` (
  `sia_codpfa_prof` varchar(6) NOT NULL COMMENT 'Codigo unico del Profesional que presta servicio medico (generado por el sistema)',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificacion del usuario o Paciente  según las normas vigentes para gestion de datos ejm: CC= Cedula, RC= Rgistro Civil',
  `nom_nroide_nomi` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion en nomina',
  `sia_rmedic_prof` varchar(30) DEFAULT NULL COMMENT 'Numero del registro profesional de salud ante el ministerio',
  `sia_nompro_prof` varchar(40) DEFAULT NULL COMMENT 'Nombre del profesional',
  `sia_codprm_prom` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo profesion medica o de salud ejm 01= Medico general 02=Medico Especialista 3= Enfermera jefe 4=Nutricionista 5=Odontologo 6=Auxiliar de enfermeria',
  `sia_codpat_tpat` varchar(1) DEFAULT NULL COMMENT 'Tipo de profesional que atiende el servicio según resolucion 3374 RIPS: 1=Medico  2= Enfermera y otros',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Codigo de Empresa cliente y/o tercero EPS o asegurador según modulos adminstrativos',
  `sia_conesp_prof` int(4) DEFAULT NULL COMMENT 'Contador para generar los codigos de  especialidades medicas asignadas al profesional',
  `sia_ifirma_prof` varchar(50) DEFAULT NULL COMMENT 'Imagen en formato jpg o png para la firma en historias clinicas',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código de  usuario en el sistema, correspondiente al codigo asignado al profesional para acceso al sistema al momento de realizar la atencion medica y diligenciamiento de datos',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro  1 =Activo 2=Inactivo',
  PRIMARY KEY (`sia_codpfa_prof`),
  KEY `prof02` (`sia_nompro_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siamedidaedad` table : 
#

DROP TABLE IF EXISTS `siamedidaedad`;

CREATE TABLE `siamedidaedad` (
  `sia_codmed_tmed` varchar(1) NOT NULL DEFAULT '' COMMENT 'Unidad Medida Edad Paciente 1=Año 2=Mes 3=Dia',
  `sia_desmed_tmed` varchar(20) DEFAULT NULL COMMENT 'Descripcion textual  Mediada edad del Usuario/Paciente',
  PRIMARY KEY (`sia_codmed_tmed`),
  KEY `tmed02` (`sia_desmed_tmed`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sianivcontribut` table : 
#

DROP TABLE IF EXISTS `sianivcontribut`;

CREATE TABLE `sianivcontribut` (
  `sia_nivcon_ncon` varchar(1) NOT NULL DEFAULT '' COMMENT 'Código Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y copagos según Acuerdo 260 de 2004',
  `sia_descon_ncon` varchar(20) DEFAULT NULL COMMENT 'Descripción nivel contributivo',
  PRIMARY KEY (`sia_nivcon_ncon`),
  KEY `ncon02` (`sia_descon_ncon`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sianiveleducati` table : 
#

DROP TABLE IF EXISTS `sianiveleducati`;

CREATE TABLE `sianiveleducati` (
  `sia_nivedu_sine` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo nivel educativio según resolucion 4505 para enfoque diferencial: 1-Preescolar  2-Básica Primaria  3-Básica Secundaria …',
  `sia_desedu_sine` varchar(40) DEFAULT NULL COMMENT 'Descripción nivel educativo del usuario paciente',
  PRIMARY KEY (`sia_nivedu_sine`),
  KEY `sine02` (`sia_desedu_sine`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sianivelsisben` table : 
#

DROP TABLE IF EXISTS `sianivelsisben`;

CREATE TABLE `sianivelsisben` (
  `sia_nivsbn_nsbn` varchar(1) NOT NULL DEFAULT '' COMMENT 'Codigo Nivel Sisben para cobro de copagos y cuotas moderadoras según Resolución: 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N',
  `sia_dessbn_nsbn` varchar(20) DEFAULT NULL COMMENT 'Descripcion nivel sisben',
  PRIMARY KEY (`sia_nivsbn_nsbn`),
  KEY `nsbn02` (`sia_dessbn_nsbn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siapertenetnica` table : 
#

DROP TABLE IF EXISTS `siapertenetnica`;

CREATE TABLE `siapertenetnica` (
  `sia_codper_pret` varchar(2) NOT NULL DEFAULT '' COMMENT 'Código pertenencia etnica',
  `sia_desper_pret` varchar(40) DEFAULT NULL COMMENT 'Descripción pertenencia etnica',
  PRIMARY KEY (`sia_codper_pret`),
  KEY `pret02` (`sia_desper_pret`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siaprofesisalud` table : 
#

DROP TABLE IF EXISTS `siaprofesisalud`;

CREATE TABLE `siaprofesisalud` (
  `sia_codprm_prom` varchar(3) NOT NULL COMMENT 'Codigo Tipo profesion medica o de salud ejm 01= Medico general 02=Medico Especialista 3= Enfermera jefe 4=Nutricionista 5=Odontologo 6=Auxiliar de enfermeria',
  `sia_desprm_prom` varchar(150) DEFAULT NULL COMMENT 'Descripcion profesion salud',
  PRIMARY KEY (`sia_codprm_prom`),
  KEY `prom02` (`sia_desprm_prom`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siaregimensalud` table : 
#

DROP TABLE IF EXISTS `siaregimensalud`;

CREATE TABLE `siaregimensalud` (
  `sia_tipusu_regi` varchar(1) NOT NULL DEFAULT '' COMMENT 'Tipo Usuario según régimen 1=Contributivo 2=Subsidiado y otros(Resol: 3374 RIPS)',
  `sia_destip_regi` varchar(40) DEFAULT NULL COMMENT 'Descripción régimen de salud Contributivo, Subsidiado y otros(Resol: 3374 RIPS)',
  PRIMARY KEY (`sia_tipusu_regi`),
  KEY `regi02` (`sia_destip_regi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatablaeps` table : 
#

DROP TABLE IF EXISTS `siatablaeps`;

CREATE TABLE `siatablaeps` (
  `sia_codeps_teps` varchar(6) NOT NULL DEFAULT '' COMMENT 'Código de Eps o Asegurador según códigos asignados por la supersalud',
  `sia_codnit_teps` varchar(20) DEFAULT NULL COMMENT 'Numero del Nit de la EPS o Asegurador',
  `sia_deseps_teps` varchar(200) DEFAULT NULL COMMENT 'Descripción Eps o Asegurador según códigos asignados por la supersalud',
  `sia_tipase_sita` varchar(2) DEFAULT NULL COMMENT 'Código tipo asegurador de salud:  01=Adminstradora  de Riesgos laborales 02=Entidades aseguradoras regimen subsidiado … otros',
  PRIMARY KEY (`sia_codeps_teps`),
  KEY `teps02` (`sia_deseps_teps`),
  KEY `teps03` (`sia_tipase_sita`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatablaips` table : 
#

DROP TABLE IF EXISTS `siatablaips`;

CREATE TABLE `siatablaips` (
  `sia_codips_tips` varchar(20) NOT NULL DEFAULT '' COMMENT 'Código de IPS',
  `sia_desips_tips` varchar(40) DEFAULT NULL COMMENT 'Nombre de la Ips',
  PRIMARY KEY (`sia_codips_tips`),
  KEY `tips02` (`sia_desips_tips`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatablatprips` table : 
#

DROP TABLE IF EXISTS `siatablatprips`;

CREATE TABLE `siatablatprips` (
  `sia_codrip_trip` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo clasificacion  servicio según Resolucion 3374 RIPS: 01=Consulta 02= Procedimientos y mas',
  `sia_desrip_trip` varchar(50) DEFAULT NULL COMMENT 'Nombre o descripción del  laboratorio que fabrica el medicamento',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro  1 =Activo 2=Inactivo',
  PRIMARY KEY (`sia_codrip_trip`),
  KEY `trip02` (`sia_desrip_trip`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatipactividad` table : 
#

DROP TABLE IF EXISTS `siatipactividad`;

CREATE TABLE `siatipactividad` (
  `sia_tipact_tsac` varchar(1) NOT NULL DEFAULT '' COMMENT 'Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial 2=Promocion y Prevencion 3=Salud Publica 4=Todas',
  `sia_desact_tsac` varchar(30) DEFAULT NULL COMMENT 'Descripción Tipo servico o actividad de salud',
  PRIMARY KEY (`sia_tipact_tsac`),
  KEY `tsac02` (`sia_desact_tsac`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatipaficontri` table : 
#

DROP TABLE IF EXISTS `siatipaficontri`;

CREATE TABLE `siatipaficontri` (
  `sia_tipafi_tafi` varchar(1) NOT NULL DEFAULT '' COMMENT 'Tipo Afiliado contributivo: C=Cotizante B=Beneficiario A=Adicional',
  `sia_destaf_tafi` varchar(40) DEFAULT NULL COMMENT 'Descripcion tipo afiliado contributivo',
  PRIMARY KEY (`sia_tipafi_tafi`),
  KEY `tafi02` (`sia_destaf_tafi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatipdiscapaci` table : 
#

DROP TABLE IF EXISTS `siatipdiscapaci`;

CREATE TABLE `siatipdiscapaci` (
  `sia_tipdis_tdis` varchar(2) NOT NULL DEFAULT '' COMMENT 'Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Visual, 2=Motriz y mas',
  `sia_desdis_tdis` varchar(30) DEFAULT NULL COMMENT 'Descripcion tipo discapacidad',
  PRIMARY KEY (`sia_tipdis_tdis`),
  KEY `tdis02` (`sia_desdis_tdis`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatipideusario` table : 
#

DROP TABLE IF EXISTS `siatipideusario`;

CREATE TABLE `siatipideusario` (
  `sia_tipide_tide` varchar(2) NOT NULL DEFAULT '' COMMENT 'Tipo identificacion del usuario o Paciente  ejm: CC= Cedula, RC= Rgistro Civil, TI = Tarjeta de Identidad  AS= Adulto sin idetificacion y otros',
  `sia_deside_tide` varchar(30) DEFAULT NULL COMMENT 'Descripcion textual del Tipo de identificacin para el usuario o paciente',
  PRIMARY KEY (`sia_tipide_tide`),
  KEY `tide02` (`sia_deside_tide`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatipoasegurad` table : 
#

DROP TABLE IF EXISTS `siatipoasegurad`;

CREATE TABLE `siatipoasegurad` (
  `sia_tipase_sita` varchar(2) NOT NULL DEFAULT '' COMMENT 'Código tipo asegurador de salud',
  `sia_desase_sita` varchar(50) DEFAULT NULL COMMENT 'Descripcion tipo asegurador servicios de salud',
  PRIMARY KEY (`sia_tipase_sita`),
  KEY `sita02` (`sia_desase_sita`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatipocotizante` table : 
#

DROP TABLE IF EXISTS `siatipocotizante`;

CREATE TABLE `siatipocotizante` (
  `sia_tipcot_tcot` varchar(2) NOT NULL DEFAULT '' COMMENT 'Tipo Afiliado cotizante para el contributivo según resol: 1344 de 2012 BDUA',
  `sia_descot_tcot` varchar(120) DEFAULT NULL COMMENT 'Descripcion tipo cotizante',
  PRIMARY KEY (`sia_tipcot_tcot`),
  KEY `tcot02` (`sia_descot_tcot`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatipodiagprin` table : 
#

DROP TABLE IF EXISTS `siatipodiagprin`;

CREATE TABLE `siatipodiagprin` (
  `sia_tipdxp_tdix` varchar(1) NOT NULL DEFAULT '' COMMENT 'Tipo de diagnostico principal',
  `sia_desdxp_tdix` varchar(30) DEFAULT NULL COMMENT 'Descripcion tipo diagnostico',
  PRIMARY KEY (`sia_tipdxp_tdix`),
  KEY `tdix02` (`sia_desdxp_tdix`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatippoblacion` table : 
#

DROP TABLE IF EXISTS `siatippoblacion`;

CREATE TABLE `siatippoblacion` (
  `sia_tippob_tpob` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo del tipo poblacional especial para subsidiado, según normas de base de datos Resolución: 1344 de 2012  BDUA',
  `sia_despob_tpob` varchar(90) DEFAULT NULL COMMENT 'Descripcion tipo poblacion especial regimen subsidiado',
  PRIMARY KEY (`sia_tippob_tpob`),
  KEY `tpob02` (`sia_despob_tpob`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatipprofatien` table : 
#

DROP TABLE IF EXISTS `siatipprofatien`;

CREATE TABLE `siatipprofatien` (
  `sia_codpat_tpat` varchar(1) NOT NULL DEFAULT '' COMMENT 'Tipo de profesional que atiende el servicio según resolucion 3374 RIPS: 1=Medico  2= Enfermera y otros',
  `sia_despat_tpat` varchar(40) DEFAULT NULL COMMENT 'Descripcion del tipo profesional que atiende',
  PRIMARY KEY (`sia_codpat_tpat`),
  KEY `tpat02` (`sia_despat_tpat`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siatregatencion` table : 
#

DROP TABLE IF EXISTS `siatregatencion`;

CREATE TABLE `siatregatencion` (
  `sia_regate_rgat` varchar(1) NOT NULL DEFAULT '' COMMENT 'Tipo Registro  de Atención: 1 = Admitidos 2=Ambulatoria',
  `sia_desreg_rgat` varchar(30) DEFAULT NULL COMMENT 'Descripcion registro de atencion',
  PRIMARY KEY (`sia_regate_rgat`),
  KEY `rgat02` (`sia_desreg_rgat`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siausuarioatend` table : 
#

DROP TABLE IF EXISTS `siausuarioatend`;

CREATE TABLE `siausuarioatend` (
  `sia_idesec_usua` varchar(20) NOT NULL DEFAULT '' COMMENT 'Consecutivo Unico de paciente en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `hcl_nrohis_hicl` varchar(20) DEFAULT NULL COMMENT 'Numero o codigo de la Ficha de Historias Clinicas',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Codigo de Eps o Asegurador segun Listado EPS Ministerio Proteccion social',
  `sia_tipide_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificacion del usuario o Paciente  segun las normas vigentes para gestion de d atos ejm: CC= Cedula, RC= Rgistro Civil, TI = Tarjeta de Identidad  AS= Adulto sin idetificacion y otros',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificacion del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `sia_priape_usua` varchar(20) DEFAULT NULL COMMENT 'Primer apellido del usuario o paciente',
  `sia_segape_usua` varchar(30) DEFAULT NULL COMMENT 'Segundo apellido del usuario o paciente',
  `sia_prinom_usua` varchar(20) DEFAULT NULL COMMENT 'Primer nombre del usuario o paciente',
  `sia_segnom_usua` varchar(30) DEFAULT NULL COMMENT 'Segundo nombre del usuario o paciente',
  `sia_fecnac_usua` date DEFAULT NULL COMMENT 'Fecha nacimiento del usuario o paciente',
  `sis_codsex_sexo` varchar(1) DEFAULT NULL COMMENT 'Sexo del  usuario o paciente',
  `sia_nomusu_usua` varchar(50) DEFAULT NULL COMMENT 'Nombre concatenado del paciente (Apellidos y Nombres)',
  `sia_tipusu_regi` varchar(1) DEFAULT NULL COMMENT 'Tipo Usuario segun regimen 1=Contributivo 2=Subsidiado y otros(Resol: 3374 RIPS)',
  `sia_tipcot_tcot` varchar(2) DEFAULT NULL COMMENT 'Tipo Afiliado cotizante para el contributivo segun Resolucion: 1344 de 2012 BDUA',
  `sia_tipafi_tafi` varchar(1) DEFAULT NULL COMMENT 'Tipo Afiliado contributivo: C=Cotizante B=Beneficiario A=Adicional',
  `sia_valibc_usua` int(10) DEFAULT NULL COMMENT 'Valor ingreso base de cotizacion para usuarios contributivos',
  `sia_tippob_tpob` varchar(2) DEFAULT NULL COMMENT 'Codigo del tipo poblacional especial para subsidiado, segun normas de base de datos Resol: 1344 de 2012  BDUA: 1= Habitante de la calle 2= Poblacion Infantil y mas',
  `sia_codper_pret` varchar(2) DEFAULT NULL COMMENT 'Código pertenencia etnica',
  `sia_nivedu_sine` varchar(2) DEFAULT NULL COMMENT 'Codigo nivel educativio según resolucion 4505 para enfoque diferencial: 1-Preescolar  2-Básica Primaria  3-Básica Secundaria …',
  `sia_nivsbn_nsbn` varchar(1) DEFAULT NULL COMMENT 'Codigo Nivel Sisben para cobro de copagos  segun Resolucion: 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N',
  `sia_nivcon_ncon` varchar(1) DEFAULT NULL COMMENT 'Codigo Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y copagos segun Acuerdo 260 de 2004',
  `sis_idemun_muni` varchar(5) DEFAULT NULL COMMENT 'Id Unico Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio',
  `sis_codmun_muni` varchar(3) DEFAULT NULL COMMENT 'Codigo Municipio segun DANE',
  `sis_coddep_dpto` varchar(2) DEFAULT NULL COMMENT 'Codigo  del departamento DANE',
  `sis_zonres_tzon` varchar(1) DEFAULT NULL COMMENT 'Zona de residencia segun norma U=Urbana R= Rural',
  `sia_telres_usua` varchar(50) DEFAULT NULL COMMENT 'Telefono del usuario o paciente',
  `sia_dirres_usua` varchar(70) DEFAULT NULL COMMENT 'Direccion de residencia del usuario o paciente',
  `sia_correo_usua` varchar(60) DEFAULT NULL COMMENT 'Correo electronico del usuario o paciente',
  `sis_codocu_ocup` varchar(4) DEFAULT NULL COMMENT 'Codigo ocupacion o profesion usuario atendido',
  `sia_feceps_usua` date DEFAULT NULL COMMENT 'Fecha afiliacion a EPS o asegurador',
  `cto_seccon_cont` varchar(10) DEFAULT NULL COMMENT 'Secuencial Unico de Contrato',
  `cto_nrocon_cont` varchar(15) DEFAULT NULL COMMENT 'Numero de Contrato',
  `sia_tpidap_tide` varchar(2) DEFAULT NULL COMMENT 'Tipo identificacion del aportante para contributivo',
  `sia_ideapo_usua` varchar(20) DEFAULT NULL COMMENT 'Numero identificaion del aportante',
  `sia_modsub_usua` varchar(2) DEFAULT NULL COMMENT 'Modalidad del subsidio para el regimen subsidiado: ST =Subsidio total',
  `sia_discap_usua` varchar(2) DEFAULT NULL COMMENT 'Aguna discapacidad SI/NO',
  `sia_tipdis_tdis` varchar(2) DEFAULT NULL COMMENT 'Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Visual, 2=Motriz y mas',
  `sia_edapac_usua` int(3) DEFAULT NULL COMMENT 'Edad Paciente al Momento de Admision',
  `sia_codmed_tmed` varchar(1) DEFAULT NULL COMMENT 'Unidad Medida Edad Paciente 1=Año 2=Mes 3=Dia',
  `sia_edaano_usua` int(3) DEFAULT NULL COMMENT 'Edad en años',
  `sia_edames_usua` int(4) DEFAULT NULL COMMENT 'Edad en meses',
  `sia_edadia_usua` int(5) DEFAULT NULL COMMENT 'Edad en dias',
  `sia_edaymd_usua` varchar(30) DEFAULT NULL COMMENT 'Edad en formato largo ejemplo: (20 años 8 meses 16 dias)',
  `sia_codimg_imus` varchar(20) DEFAULT NULL COMMENT 'Codigo de la imagen capturada como foto del perfil del usuario o paciente',
  `sia_codcat_ceat` varchar(6) DEFAULT NULL COMMENT 'Centro de Atencion  cuando hay varias sedes',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Codigo del Digitador Usuario del sistema que diligencia el registro de atencion o admision',
  `sia_fecedt_usua` date DEFAULT NULL COMMENT 'Fecha ultima edicion',
  `sia_llaveb_usua` varchar(90) DEFAULT NULL COMMENT 'llave de busqueda avanzada concatena:tipo ide+ identificacion+apellidos+nombres+fecha nacimiento+eps',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  PRIMARY KEY (`sia_idesec_usua`),
  KEY `usua02` (`hcl_nrohis_hicl`),
  KEY `usua03` (`sia_nroide_usua`),
  KEY `usua04` (`sia_priape_usua`),
  KEY `usua05` (`sia_segape_usua`),
  KEY `usua06` (`sia_prinom_usua`),
  KEY `usua07` (`sia_segnom_usua`),
  KEY `usua08` (`sia_codeps_teps`),
  KEY `usua09` (`sia_codper_pret`),
  KEY `usua10` (`sia_llaveb_usua`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sisactualizarch` table : 
#

DROP TABLE IF EXISTS `sisactualizarch`;

CREATE TABLE `sisactualizarch` (
  `sis_secreg_siaa` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico registro maestro para archivos actualizables',
  `sis_codarc_siaa` varchar(6) DEFAULT NULL COMMENT 'Código identificador del archivo: RIPSAC = Rips consulta, RIPSAP=Rips Procedimiento, RE4505 = Resolucion 4505 y otros',
  `sis_desarc_siaa` varchar(50) DEFAULT NULL COMMENT 'Nombre o descripción del archivo que se pretende actualizar ejmplo: Archivo Rips de Consulta, Archivo Resolucion 4505 y otros',
  `sis_estreg_siaa` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`sis_secreg_siaa`),
  KEY `siaa02` (`sis_desarc_siaa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sisactualizcamp` table : 
#

DROP TABLE IF EXISTS `sisactualizcamp`;

CREATE TABLE `sisactualizcamp` (
  `sis_secreg_siac` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código secuencial detalle id unico para cada registro de campo',
  `sis_secreg_siaa` varchar(10) DEFAULT NULL COMMENT 'secuencial relacionado con la tabla principal R1 maestro para archivos actualizables',
  `sis_codarc_siaa` varchar(6) DEFAULT NULL COMMENT 'Código identificador del archivo: RIPSAC = Rips consulta, RIPSAP=Rips Procedimiento, RE4505 = Resolucion 4505 y otros',
  `sis_codcam_siac` varchar(30) DEFAULT NULL COMMENT 'Nombre único del campo (ejemplo: SSP_CAM025_MS45, HCL_CODREG_HCVD)',
  `sis_nomcam_siac` varchar(150) DEFAULT NULL COMMENT 'titulo o etiqueta del campo (descripcion corta del campo)',
  `sis_ordvis_siac` int(3) DEFAULT NULL COMMENT 'Orden de vista del campo en la resolucion (inicia desde campo cero (0) hasta 118)',
  `sis_descam_siac` varchar(240) DEFAULT NULL COMMENT 'Descripción del Campo',
  `sis_tipval_siac` varchar(1) DEFAULT NULL COMMENT 'Tipo valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico,F=Flotante, H =Hora (Decimal)',
  `sis_valper_siac` text COMMENT 'Valores permitidos para el campo, separados por coma',
  `sis_camdig_siac` varchar(1) DEFAULT NULL COMMENT 'Campo digitable: 1=Si 2=No',
  `sis_ranini_siac` varchar(15) DEFAULT NULL COMMENT 'Rango inicial del valor digitable',
  `sis_ranfin_siac` varchar(15) DEFAULT NULL COMMENT 'Rango final del valor digitable',
  `sis_estreg_siac` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`sis_secreg_siac`),
  KEY `siac02` (`sis_secreg_siaa`),
  KEY `siac03` (`sis_codcam_siac`),
  KEY `siac04` (`sis_nomcam_siac`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sisestadoproces` table : 
#

DROP TABLE IF EXISTS `sisestadoproces`;

CREATE TABLE `sisestadoproces` (
  `sis_estpro_espr` varchar(1) NOT NULL DEFAULT '' COMMENT 'Estado de procesos en atencion asistencial : 1= Abierto(a) 2= Cerrado/Confirmado 3=Anulado(a)',
  `sis_despro_espr` varchar(30) DEFAULT NULL COMMENT 'Descripcion textual del estado de proceso Abierto(a), Cerrado(a) Y Anulado(a)',
  PRIMARY KEY (`sis_estpro_espr`),
  KEY `espr02` (`sis_despro_espr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sisestadoregist` table : 
#

DROP TABLE IF EXISTS `sisestadoregist`;

CREATE TABLE `sisestadoregist` (
  `sis_estreg_esrg` varchar(1) NOT NULL DEFAULT '' COMMENT 'Estado de registros  : 1= Activo 2= Inactivo',
  `sis_desest_esrg` varchar(20) DEFAULT NULL COMMENT 'Descripcion textual del estado de registro: Activo o Inactivo',
  PRIMARY KEY (`sis_estreg_esrg`),
  KEY `esrg02` (`sis_desest_esrg`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sisgrupomedidas` table : 
#

DROP TABLE IF EXISTS `sisgrupomedidas`;

CREATE TABLE `sisgrupomedidas` (
  `sis_codgme_sigr` varchar(2) NOT NULL COMMENT 'Código Grupo de medidas',
  `sis_desgme_sigr` varchar(30) DEFAULT NULL COMMENT 'Descripción del Grupo de Medidas',
  `sis_estreg_sigr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`sis_codgme_sigr`),
  KEY `grme02` (`sis_desgme_sigr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sismadeplavalid` table : 
#

DROP TABLE IF EXISTS `sismadeplavalid`;

CREATE TABLE `sismadeplavalid` (
  `sis_secreg_sivd` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código secuencial detalle id unico para cada registro de campo',
  `sis_secreg_siva` varchar(10) DEFAULT NULL COMMENT 'Secuencial relacionado con la tabla principal R1  maestro para plantillas para validacion',
  `sis_codcam_sivd` varchar(30) DEFAULT NULL COMMENT 'Nombre único del campo (ejemplo: SSP_CAM025_MS45, HCL_CODREG_HCVD)',
  `sis_nomcam_sivd` varchar(150) DEFAULT NULL COMMENT 'Titulo o etiqueta del campo (descripcion corta del campo)',
  `sis_codval_sivd` mediumtext COMMENT 'Codigo fuente para realizar validación personalizada',
  `sis_ordvis_sivd` int(3) DEFAULT NULL COMMENT 'Orden de vista del campo en la resolucion (inicia desde campo cero (0) hasta 118)',
  `sis_estreg_sivd` varchar(1) DEFAULT NULL COMMENT 'Estado del campo para validación: 1=Activo 2=Inactivo',
  PRIMARY KEY (`sis_secreg_sivd`),
  KEY `sivd02` (`sis_secreg_siva`),
  KEY `sivd03` (`sis_codcam_sivd`),
  KEY `sivd04` (`sis_nomcam_sivd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sismaesdependen` table : 
#

DROP TABLE IF EXISTS `sismaesdependen`;

CREATE TABLE `sismaesdependen` (
  `sis_coddep_sidp` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo de la dependencia',
  `sis_nomdep_sidp` varchar(50) DEFAULT NULL COMMENT 'Nombre o descripcion de la dependencia',
  `sis_tipdep_sidp` varchar(1) DEFAULT NULL COMMENT 'Tipo Dependencia 1=Administrativa 2= Operativa (presta servicios medicos)',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro  1 =Activo 2=Inactivo',
  PRIMARY KEY (`sis_coddep_sidp`),
  KEY `sisdp02` (`sis_nomdep_sidp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sismaesimpuesma` table : 
#

DROP TABLE IF EXISTS `sismaesimpuesma`;

CREATE TABLE `sismaesimpuesma` (
  `sis_codimp_siim` varchar(3) NOT NULL COMMENT 'Codigo tipo impuesto',
  `sis_nomimp_siim` varchar(30) DEFAULT NULL COMMENT 'Nombre del impuesto a cobrar',
  `sis_desimp_siim` varchar(80) DEFAULT NULL COMMENT 'Descripción del impuesto a cobrar',
  `sis_conest_siim` int(5) DEFAULT NULL COMMENT 'Contador para generar los registros únicos  detalles',
  `sis_estreg_siim` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`sis_codimp_siim`),
  KEY `siim02` (`sis_nomimp_siim`),
  KEY `siim03` (`sis_desimp_siim`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sismaesimpuesmd` table : 
#

DROP TABLE IF EXISTS `sismaesimpuesmd`;

CREATE TABLE `sismaesimpuesmd` (
  `sis_codtar_simi` varchar(6) NOT NULL COMMENT 'Codigo tarifa tipo impuesto',
  `sis_codimp_siim` varchar(3) DEFAULT NULL COMMENT 'Codigo tipo impuesto',
  `sis_nomtar_simi` varchar(40) DEFAULT NULL COMMENT 'Titulo corto par busquedas y vista de  tarifa aplicada ejemplo: IVA 19%',
  `sis_destar_simi` varchar(180) DEFAULT NULL COMMENT 'Descripción larga de la tarifa aplicada ejemplo: IVA 19%',
  `sis_portar_simi` float(7,2) DEFAULT NULL COMMENT 'Porcentaje tarifa',
  `sis_estreg_simi` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`sis_codtar_simi`),
  KEY `simi02` (`sis_codimp_siim`),
  KEY `simi03` (`sis_nomtar_simi`),
  KEY `simi04` (`sis_destar_simi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sismaesplavalid` table : 
#

DROP TABLE IF EXISTS `sismaesplavalid`;

CREATE TABLE `sismaesplavalid` (
  `sis_secreg_siva` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código secuencial unico registro maestro para plantillas',
  `sis_codarc_siar` varchar(6) DEFAULT NULL COMMENT 'Código identificador clasificacion del archivo: RIPSAC = Rips consulta, RIPSAP=Rips Procedimiento, RE4505 = Resolucion 4505 y otros',
  `sis_despla_siva` varchar(50) DEFAULT NULL COMMENT 'Nombre o descripción de la plantilla ejemplo: Validacion 4505 EPS033 - Saludvida',
  `sis_codval_siva` mediumtext COMMENT 'Codigo fuente base de las funciones de validacion',
  `sis_secdet_siva` int(5) DEFAULT NULL COMMENT 'Campo para generar el secuencial de los registros detalles',
  `sis_tippla_siva` varchar(1) DEFAULT NULL COMMENT 'Tipo plantilla: 1= Plantilla Validacion por defecto  2= Planitlla validacion personalizada',
  `sis_estreg_siva` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`sis_secreg_siva`),
  KEY `siva02` (`sis_despla_siva`),
  KEY `siva03` (`sis_codarc_siar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sismaesterceros` table : 
#

DROP TABLE IF EXISTS `sismaesterceros`;

CREATE TABLE `sismaesterceros` (
  `sis_idterc_sitr` varchar(20) NOT NULL COMMENT 'Codigo unico secuencial del tercero generado por el sistema',
  `sis_tipper_sitr` varchar(1) DEFAULT NULL COMMENT 'FAK02: Tipo persona: 1=Juridica 2= Pesona natural (Res 042 DIAN- Ver lista de valores posibles en el numeral 6.2.3)',
  `sis_tipide_tido` varchar(2) DEFAULT NULL COMMENT 'FAK63: (lista 6.2.1 Tipos Id Fiscal)  Identificador del tipo de documento de identidad, si (@schemeName=31), adquiriente indica que está identificado por NIT y por tanto el DV del NIT debe ser informado en atributo @schemeID.',
  `sis_numide_sitr` varchar(20) DEFAULT NULL COMMENT 'Numero docuemto de identificacion del adquirente o tercero -Nota: Para identificar al consumidor final, se utiliza el siguiente documento (222222222222)',
  `sis_numprn_sitr` varchar(20) DEFAULT NULL COMMENT 'Numero del nit con separadores y digito de verificacion',
  `sis_lugexp_sitr` varchar(30) DEFAULT NULL COMMENT 'lugar de expedicion del documento de identidad',
  `sis_priape_sitr` varchar(20) DEFAULT NULL COMMENT 'Primer apellido del tercero (cuando se trata de persona natural)',
  `sis_segape_sitr` varchar(20) DEFAULT NULL COMMENT 'segundo apellido del tercero (cuando se trata de persona natural)',
  `sis_prinom_sitr` varchar(20) DEFAULT NULL COMMENT 'Primer nombre del tercero (cuando se trata de persona natural)',
  `sis_segnom_sitr` varchar(20) DEFAULT NULL COMMENT 'Segundo nombre del tercero (cuando se trata de persona natural)',
  `sis_razsoc_sitr` varchar(240) DEFAULT NULL COMMENT 'Razon social de la empresa o nombre completo concatenado cuando es persona natural',
  `sis_nomcon_sitr` varchar(60) DEFAULT NULL COMMENT 'Nombre de la persona o funcionario para contacto',
  `sis_telefo_sitr` varchar(40) DEFAULT NULL COMMENT 'Numeros de Telefono del tecrcero',
  `sis_emailc_sitr` varchar(80) DEFAULT NULL COMMENT 'Correo electronico para contacto o envia facturas',
  `sis_direcc_sitr` varchar(80) DEFAULT NULL COMMENT 'Direccion domicilio del tercero',
  `sis_idemun_muni` varchar(5) DEFAULT NULL COMMENT 'Id Unico Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio',
  `sis_codmun_muni` varchar(3) DEFAULT NULL COMMENT 'Codigo Municipio según DANE',
  `sis_coddep_dpto` varchar(2) DEFAULT NULL COMMENT 'Codigo  del departamento DANE',
  `sis_codpos_sicp` varchar(10) DEFAULT NULL COMMENT 'FAK57: Codigo postal según el gobierno Colombiano',
  `sis_codact_sitr` varchar(40) DEFAULT NULL COMMENT 'Codigo CIU de la actividad econnomica',
  `sis_tipcnt_sitr` varchar(1) DEFAULT NULL COMMENT 'Tipo de regimen contribuyente al que pertenece el tercero 1=Regimen comun 2=Simplificado 3=Gran contribuyente 4 = Empresa del estado',
  `sis_relret_sitr` varchar(1) DEFAULT NULL COMMENT 'Realizacion de retencion 1= Realizar retencion 2= Es autoretenedor 3= No realizar',
  `sis_tipter_tter` varchar(1) DEFAULT NULL COMMENT 'Tipo de tercero : 1= Cliente 2=Proveedor 3=Empleado 4=contribuyente 5=Pensionados 6=Otros',
  `sis_codobl_sioc` varchar(150) DEFAULT NULL COMMENT 'FAK26: Codigo obilgacion del contribuyente (se debe incluir como una lista separada por el carácter Punto y Coma)',
  `sis_regfis_sitr` varchar(2) DEFAULT NULL COMMENT 'FAK27 Tipo de régimen fiscal al que pertenece el adquirente (Resolución facturación Tabla 6.2.4 ) : 48=Responsable de impuesto sobre las ventas - IVA 49=No Responsable de IVA',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro  1 =Activo 2=Inactivo',
  PRIMARY KEY (`sis_idterc_sitr`),
  KEY `sistr02` (`sis_numide_sitr`),
  KEY `sistr03` (`sis_razsoc_sitr`),
  KEY `sistr04` (`sis_idemun_muni`),
  KEY `sistr05` (`sis_coddep_dpto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sisocupaciones` table : 
#

DROP TABLE IF EXISTS `sisocupaciones`;

CREATE TABLE `sisocupaciones` (
  `sis_codocu_ocup` varchar(4) NOT NULL DEFAULT '' COMMENT 'Código ocupación o profesion usuario atendido',
  `sis_desocu_ocup` varchar(180) DEFAULT NULL COMMENT 'Descripción ocupacion',
  PRIMARY KEY (`sis_codocu_ocup`),
  KEY `ocup02` (`sis_desocu_ocup`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sisparametroips` table : 
#

DROP TABLE IF EXISTS `sisparametroips`;

CREATE TABLE `sisparametroips` (
  `sis_idereg_pips` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código secuencial detalle id unico para cada registro de campo',
  `sis_razsoc_pips` varchar(80) DEFAULT NULL COMMENT 'Nombre completo razon social razon social IPS',
  `sis_nitips_pips` varchar(20) DEFAULT NULL COMMENT 'Numero del NIT sin separadores decimales',
  `sis_codips_pips` varchar(30) DEFAULT NULL COMMENT 'Codigo prestador de servicios medicos IPS asignado por el Ministerio',
  `sis_nitipx_pips` varchar(20) DEFAULT NULL COMMENT 'Numero del NIT con  separadores decimales para vista en impresión de reportes y otros',
  `sis_dirips_pips` varchar(60) DEFAULT NULL COMMENT 'Direccion sede de la empresa IPS',
  `sis_telefo_pips` varchar(40) DEFAULT NULL COMMENT 'Numero de telefono de la IPS',
  `sis_nomdpt_pips` varchar(30) DEFAULT NULL COMMENT 'Nombre del departamento residencia',
  `sis_nommun_pips` varchar(40) DEFAULT NULL COMMENT 'Nombre  ciudad direccion residencia',
  `sis_eslog_pips` varchar(50) DEFAULT NULL COMMENT 'Eslogan IPS',
  `sis_logtip_pips` varchar(150) DEFAULT NULL COMMENT 'Ruta y nombre del logotipo',
  PRIMARY KEY (`sis_idereg_pips`),
  KEY `pips02` (`sis_razsoc_pips`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sisproveedores` table : 
#

DROP TABLE IF EXISTS `sisproveedores`;

CREATE TABLE `sisproveedores` (
  `sis_secpro_sipr` varchar(10) NOT NULL DEFAULT '' COMMENT 'Secuencial generado por el sistema',
  `sis_idterc_sitr` varchar(20) DEFAULT NULL COMMENT 'Codigo unico secuencial del tercero para procesos contables',
  `sis_nitpro_sipr` varchar(20) DEFAULT NULL COMMENT 'Nit del Proveedor',
  `sis_razsoc_sipr` varchar(80) DEFAULT NULL COMMENT 'Razón Social del Proveedor',
  `sis_tippro_sipr` varchar(1) DEFAULT NULL COMMENT 'Tipo de proveedor 1=Empresa 2=Particular',
  `sis_dirpro_sipr` varchar(80) DEFAULT NULL COMMENT 'Dirección Proveedor',
  `sis_telpro_sipr` varchar(40) DEFAULT NULL COMMENT 'Telefono Proveedor',
  `sis_contac_sipr` varchar(60) DEFAULT NULL COMMENT 'Persona de contacto con la empresa proveedora o para localizar al particular',
  `sis_proinv_sipr` varchar(1) DEFAULT NULL COMMENT 'Es Proveedor de inventarios:1=SI 2=NO',
  `sis_proact_sipr` varchar(1) DEFAULT NULL COMMENT 'Es Proveedor de activos fijos:1=SI 2=NO',
  `sis_prohum_sipr` varchar(1) DEFAULT NULL COMMENT 'Es Proveedor de Recurso Humanos:1=SI 2=NO',
  `sis_prootr_sipr` varchar(1) DEFAULT NULL COMMENT 'Es Proveedor de otros recursos:1=SI 2=NO',
  `sis_coddep_dpto` varchar(2) DEFAULT NULL COMMENT 'Codigo  del departamento DANE',
  `sis_idemun_muni` varchar(5) DEFAULT NULL COMMENT 'Id Unico Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio',
  `sis_estreg_esrg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro  1 =Activo 2=Inactivo',
  PRIMARY KEY (`sis_secpro_sipr`),
  KEY `sispr02` (`sis_idterc_sitr`),
  KEY `sispr03` (`sis_nitpro_sipr`),
  KEY `sispr04` (`sis_razsoc_sipr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sisresponfiscal` table : 
#

DROP TABLE IF EXISTS `sisresponfiscal`;

CREATE TABLE `sisresponfiscal` (
  `sis_codobl_sioc` varchar(10) NOT NULL COMMENT 'FAJ26 - FAK26: Codigo obilgacion del contribuyente',
  `sis_desobl_sioc` varchar(150) DEFAULT NULL COMMENT 'FAJ26 - FAK26: Descripcion textual de la responsabilidad  fiscal del contribuyente',
  PRIMARY KEY (`sis_codobl_sioc`),
  KEY `sissioc02` (`sis_desobl_sioc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sissalariomin` table : 
#

DROP TABLE IF EXISTS `sissalariomin`;

CREATE TABLE `sissalariomin` (
  `sis_codsal_tsal` varchar(3) NOT NULL DEFAULT '' COMMENT 'Código del Salario Mínimo',
  `sis_dessal_tsal` varchar(30) DEFAULT NULL COMMENT 'Descripción del Salario Mínimo',
  `sis_valsal_tsal` int(7) DEFAULT NULL COMMENT 'Valor del Salario Mínimo',
  `sis_feivig_tsal` date DEFAULT NULL COMMENT 'Fecha Inicial Vigencia',
  `sis_fefvig_tsal` date DEFAULT NULL COMMENT 'Fecha Final Vigencia',
  `sis_estreg_tsal` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`sis_codsal_tsal`),
  KEY `tsal02` (`sis_dessal_tsal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sistabdepartame` table : 
#

DROP TABLE IF EXISTS `sistabdepartame`;

CREATE TABLE `sistabdepartame` (
  `sis_coddep_dpto` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo  del departamento DANE',
  `sis_desdep_dpto` varchar(40) DEFAULT NULL COMMENT 'Nombre del departamento',
  PRIMARY KEY (`sis_coddep_dpto`),
  KEY `dpto02` (`sis_desdep_dpto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sistablaiva` table : 
#

DROP TABLE IF EXISTS `sistablaiva`;

CREATE TABLE `sistablaiva` (
  `sis_codiva_tiva` varchar(2) NOT NULL DEFAULT '' COMMENT 'Código del I.V.A',
  `sis_desiva_tiva` varchar(30) DEFAULT NULL COMMENT 'Descripción del I.V.A',
  `sis_poriva_tiva` float(7,2) DEFAULT NULL COMMENT 'Porcentaje del I.V.A',
  `sis_estreg_tiva` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`sis_codiva_tiva`),
  KEY `tiva02` (`sis_desiva_tiva`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sistablasexos` table : 
#

DROP TABLE IF EXISTS `sistablasexos`;

CREATE TABLE `sistablasexos` (
  `sis_codsex_sexo` varchar(1) NOT NULL COMMENT 'Codigo tipo Sexo Generado por el sistema',
  `sis_dessex_sexo` varchar(25) DEFAULT NULL COMMENT 'Descripcion(Masculino,Femenino)',
  PRIMARY KEY (`sis_codsex_sexo`),
  KEY `sexoi02` (`sis_dessex_sexo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sistabmunicipio` table : 
#

DROP TABLE IF EXISTS `sistabmunicipio`;

CREATE TABLE `sistabmunicipio` (
  `sis_idemun_muni` varchar(5) NOT NULL DEFAULT '' COMMENT 'Id Unico Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio',
  `sis_codmun_muni` varchar(3) DEFAULT NULL COMMENT 'Codigo Municipio según DANE',
  `sis_coddep_dpto` varchar(2) DEFAULT NULL COMMENT 'Codigo  del departamento DANE',
  `sis_nommun_muni` varchar(40) DEFAULT NULL COMMENT 'Nombre del Muncipio',
  PRIMARY KEY (`sis_idemun_muni`),
  KEY `muni02` (`sis_nommun_muni`),
  KEY `muni03` (`sis_coddep_dpto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sistipidtercer` table : 
#

DROP TABLE IF EXISTS `sistipidtercer`;

CREATE TABLE `sistipidtercer` (
  `sis_tipide_tido` varchar(2) NOT NULL DEFAULT '' COMMENT 'Tipo identificacion de documento del tercero :1= Nit, 2= Cedula, 3=Cedula de Extranjería, 4= Tarjeta  de Identidad, 5=Pasaporte 6=Otros documento extranjero',
  `sis_deside_tido` varchar(30) DEFAULT NULL COMMENT 'Descripción Tipo identificacion tercero contable',
  PRIMARY KEY (`sis_tipide_tido`),
  KEY `tido02` (`sis_deside_tido`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sistipoarchivos` table : 
#

DROP TABLE IF EXISTS `sistipoarchivos`;

CREATE TABLE `sistipoarchivos` (
  `sis_codarc_siar` varchar(6) NOT NULL DEFAULT '' COMMENT 'Código identificador clasificacion del archivo: RIPSAC = Rips consulta, RIPSAP=Rips Procedimiento, RE4505 = Resolucion 4505 y otros',
  `sis_desarc_siar` varchar(50) DEFAULT NULL COMMENT 'Descripción identificador de archivos',
  PRIMARY KEY (`sis_codarc_siar`),
  KEY `siar02` (`sis_desarc_siar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sisunidadmedida` table : 
#

DROP TABLE IF EXISTS `sisunidadmedida`;

CREATE TABLE `sisunidadmedida` (
  `sis_codume_sium` varchar(6) NOT NULL COMMENT 'Código unidad de medida',
  `sis_desume_sium` varchar(150) DEFAULT NULL COMMENT 'Descripción de la unidad de Medida',
  `sis_codgme_sigr` varchar(2) DEFAULT NULL COMMENT 'Código Grupo de medidas',
  `sis_estreg_sium` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=Activo 2=Inactivo',
  PRIMARY KEY (`sis_codume_sium`),
  KEY `unme02` (`sis_desume_sium`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `siszonaresidenc` table : 
#

DROP TABLE IF EXISTS `siszonaresidenc`;

CREATE TABLE `siszonaresidenc` (
  `sis_zonres_tzon` varchar(1) NOT NULL DEFAULT '' COMMENT 'Zona de residencia según norma U=Urbana R= Rural',
  `sis_deszon_tzon` varchar(20) DEFAULT NULL COMMENT 'Descripcion zona  recidencia',
  PRIMARY KEY (`sis_zonres_tzon`),
  KEY `tzon02` (`sis_deszon_tzon`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `spactivmediceve` table : 
#

DROP TABLE IF EXISTS `spactivmediceve`;

CREATE TABLE `spactivmediceve` (
  `ssp_secreg_ssev` varchar(10) NOT NULL DEFAULT '' COMMENT 'Consecutivo unico del registro generado por el sistema',
  `ssp_codper_peri` varchar(10) DEFAULT NULL COMMENT 'Codigo del periodo informacion en la cual esta relacionado el registro',
  `grp_idereg_grpl` varchar(20) DEFAULT NULL COMMENT 'Codigo identificador del grupo de registros, cuando hay plantilla en navegador Escritorio y etiquetas asociadas a la plantilla',
  `hcl_nroreg_hcev` varchar(20) DEFAULT NULL COMMENT 'Código secuencial del evento medico  desde el historial de eventos medicos',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura Historia clinica odontologia y otras',
  `adm_secadm_rgad` varchar(20) DEFAULT NULL COMMENT 'Secuencial de Admisión del paciente',
  `cit_codasi_mcit` varchar(20) DEFAULT NULL COMMENT 'Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas',
  `fcm_codcpr_cpro` varchar(6) DEFAULT NULL COMMENT 'Codgio del centro de producción donde se realiza la prestaccion del servicio',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema',
  `hcl_gesfec_hcev` date DEFAULT NULL COMMENT 'Fecha del evento o prestacion del servicio al paciente',
  `hcl_geshor_hcev` decimal(5,2) DEFAULT NULL COMMENT 'Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16',
  `sia_codpfa_prof` varchar(6) DEFAULT NULL COMMENT 'Código del Profesional que realiza la atencion del evento',
  PRIMARY KEY (`ssp_secreg_ssev`),
  KEY `ssev02` (`ssp_codper_peri`),
  KEY `ssev03` (`hcl_codreg_hcca`),
  KEY `ssev04` (`adm_secadm_rgad`),
  KEY `ssev05` (`cit_codasi_mcit`),
  KEY `ssev06` (`fcm_codcpr_cpro`),
  KEY `ssev07` (`sia_idesec_usua`),
  KEY `ssev08` (`hcl_gesfec_hcev`),
  KEY `ssev09` (`sia_codpfa_prof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `spactivmedicgen` table : 
#

DROP TABLE IF EXISTS `spactivmedicgen`;

CREATE TABLE `spactivmedicgen` (
  `ssp_secreg_ssam` varchar(10) NOT NULL DEFAULT '' COMMENT 'Consecutivo unico del registro generado por el sistema',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia',
  `ssp_estreg_ssam` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=activo 2=Inactivo',
  PRIMARY KEY (`ssp_secreg_ssam`),
  KEY `ssam02` (`hcl_codreg_hcca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `spactivmedicvar` table : 
#

DROP TABLE IF EXISTS `spactivmedicvar`;

CREATE TABLE `spactivmedicvar` (
  `ssp_secreg_ssvr` varchar(10) NOT NULL DEFAULT '' COMMENT 'Consecutivo unico del registro generado por el sistema',
  `ssp_secreg_sspd` varchar(10) DEFAULT NULL COMMENT 'Codigo id unico campo variable 4505 relacionados con programas de salud',
  `ssp_codpro_sspa` varchar(4) DEFAULT NULL COMMENT 'Codigo unico del programa de salud digitado por el usuario',
  `ssp_codcam_resc` varchar(15) DEFAULT NULL COMMENT 'Consecutivo unico de campo o nombre (ejemplo: SSP_CAM025_MS45) en historicos resolucion 4505',
  `hcl_nomvar_hcvr` varchar(30) DEFAULT NULL COMMENT 'Nombre unico identificador de la variable, para referencia dentro del sistema, este nombre debe incluir nombre identificador del grupo al que pertenece, ejemplo variables : VACUNACION_NIÑO_DPT_DOSIS1, JOVEN_PLANIFICACION_SI_NO',
  `hcl_codreg_hcca` varchar(20) DEFAULT NULL COMMENT 'Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura Historia clinica general APE-HCL-ODON= Apertura Historia clinica odontologia',
  `ssp_parmet_ssvr` text COMMENT 'Parametros especiales de gestion',
  `ssp_estreg_ssvr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=activo 2=Inactivo',
  PRIMARY KEY (`ssp_secreg_ssvr`),
  KEY `ssvr02` (`ssp_secreg_sspd`),
  KEY `ssvr03` (`ssp_codpro_sspa`),
  KEY `ssvr04` (`ssp_codcam_resc`),
  KEY `ssvr05` (`hcl_nomvar_hcvr`),
  KEY `ssvr06` (`hcl_codreg_hcca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `spactivservfact` table : 
#

DROP TABLE IF EXISTS `spactivservfact`;

CREATE TABLE `spactivservfact` (
  `ssp_secreg_ssfc` varchar(10) NOT NULL DEFAULT '' COMMENT 'Consecutivo unico del registro generado por el sistema',
  `ssp_codpro_sspa` varchar(4) DEFAULT NULL COMMENT 'Codigo unico del programa de salud digitado por el usuario',
  `fcm_codser_sips` varchar(20) DEFAULT NULL COMMENT 'Codigo del servicio para venta y RIPS, pude ser codigo SOAT ISS o CUPS (es modificable en configuración)',
  `fcm_coddig_mant` varchar(20) DEFAULT NULL COMMENT 'Codigo para facilitar la digitacion del servicio en facturacion (pude ser el codigo en el tarifario) es un codigo auxiliar  creado por el usuario administrador y unico en la tabla',
  `sia_codrip_trip` varchar(2) DEFAULT NULL COMMENT 'Codigo clasificacion  servicio según Resolucion 3374 RIPS: 01=Consulta 02= Procedimientos y mas',
  `ssp_coddig_ssfc` varchar(150) DEFAULT NULL COMMENT 'Codigo del servicio asociado o relacionado que tambien debe estar en la facturacion, para poder clasifificar el grupo (NA cuando no aplique)',
  `ssp_desser_ssfc` varchar(250) DEFAULT NULL COMMENT 'Descripción textual del servicio IPS',
  `ssp_priori_ssfc` varchar(1) DEFAULT NULL COMMENT 'Prioridad de la actividad Rips en procesos de clasificacion del registro 4505 1=Alta (facturada obligatoria para la actividad) 2=Baja (no existir en lista de servicios)',
  `sia_codfpr_fpro` varchar(20) DEFAULT NULL COMMENT 'Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Diagnostico 2=Terapéutico 3=Protección Especifica 4=Detección temprana de Enfermedad General 5=Detección especifica de Enfermedad Profesional según Resolucion 3374 RIPS',
  `sia_codfco_fcon` varchar(40) DEFAULT NULL COMMENT 'Finalidad de la consulta: 01=Atención del Parto 02=Atencion del Recien Nacido y demas según Resolucion 3374RIPS',
  `adm_codcex_tcex` varchar(40) DEFAULT NULL COMMENT 'Causa Externa Origen que origina la atención según Resolución: 3374 RIPS',
  `fcm_mededi_sips` varchar(1) DEFAULT NULL COMMENT 'Medida edad inicial a la cual aplica el servicio, para validación pertinencia: 1=Años 2=Meses 3=Días',
  `fcm_edaini_sips` int(6) DEFAULT NULL COMMENT 'Edad inicial para la cual aplica la validación de pertinencia',
  `fcm_mededf_sips` varchar(1) DEFAULT NULL COMMENT 'Medida edad fina a la cual aplica el servicio, para validación pertinencia:1=Años 2=Meses 3=Días',
  `fcm_edafin_sips` int(6) DEFAULT NULL COMMENT 'Edad final para la cual aplica la validación de pertinencia',
  `fcm_sexapl_sips` varchar(1) DEFAULT NULL COMMENT 'Sexo al cual aplica el servicio:1=Masculino 2=Femenino 3=Ambos',
  `fcm_coddia_sips` text COMMENT 'Lista de diagnosticos CIE -10 permitidos, separados por punto y coma (;) para validacion en prestacion de servicios y  Gestion foramtos de Historias clinicas',
  `ssp_parmet_ssfc` text COMMENT 'Parametros especiales de gestion',
  `ssp_estreg_ssfc` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=activo 2=Inactivo',
  PRIMARY KEY (`ssp_secreg_ssfc`),
  KEY `ssfc02` (`fcm_coddig_mant`),
  KEY `ssfc03` (`ssp_desser_ssfc`),
  KEY `ssfc04` (`fcm_codser_sips`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `spconfigura4505` table : 
#

DROP TABLE IF EXISTS `spconfigura4505`;

CREATE TABLE `spconfigura4505` (
  `ssp_codcon_sscf` varchar(10) CHARACTER SET utf8 NOT NULL COMMENT 'Código  registro de configuracion',
  `ssp_codips_sscf` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo prestador de servicio IPS asignado para habilitacion',
  `ssp_nitips_sscf` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Nit de la  IPS sin incluir puntos (ejemplo: 845126156-3)',
  `ssp_nomips_sscf` varchar(80) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Nombre Razon social IPS con que aparece registrada ante el Ministerio de Salud',
  `ssp_dirent_sscf` varchar(80) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Direccion ubicación de la sede IPS',
  `ssp_telent_sscf` varchar(40) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Telefono de la entidad IPS',
  `ssp_rutarc_sscf` varchar(80) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Ruta por defecto para generar los archivos planos',
  `sis_secreg_siva` varchar(10) CHARACTER SET utf8 DEFAULT NULL COMMENT 'Codigo secuencial unico registro maestro para plantillas',
  PRIMARY KEY (`ssp_codcon_sscf`),
  UNIQUE KEY `ssp_nomips_sscf` (`ssp_nomips_sscf`),
  KEY `sscf02` (`ssp_nomips_sscf`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Structure for the `spmaestplangest` table : 
#

DROP TABLE IF EXISTS `spmaestplangest`;

CREATE TABLE `spmaestplangest` (
  `ssp_secreg_sppg` varchar(10) NOT NULL DEFAULT '' COMMENT 'Secuencial unico del registro (generado por el sistema)',
  `ssp_despro_sppg` varchar(150) DEFAULT NULL COMMENT 'Descripcion textual de la plantilla de configuracion',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Código de Eps o Asegurador según Listado EPS Ministerio Protección social',
  `sis_secreg_siva` varchar(10) DEFAULT NULL COMMENT 'Maestro de plantillas para configurar validacion personalizada de archivos tales como: Archivos Rips  Archivo Resolución 4505 y otros.',
  `ssp_secreg_spdf` varchar(10) DEFAULT NULL COMMENT 'Codigo maestro valores por defecto, requerido para generar valores registros de pacientes 4505 y para validar cuando in archivo se carga con valores o no según la eps',
  `ssp_estreg_sppg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=activo 2=Inactivo',
  PRIMARY KEY (`ssp_secreg_sppg`),
  KEY `sppr02` (`ssp_despro_sppg`),
  KEY `sppr03` (`sia_codeps_teps`),
  KEY `sppr04` (`sis_secreg_siva`),
  KEY `sppr05` (`ssp_secreg_spdf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `spmaestroprocma` table : 
#

DROP TABLE IF EXISTS `spmaestroprocma`;

CREATE TABLE `spmaestroprocma` (
  `ssp_secreg_sppr` varchar(10) NOT NULL DEFAULT '' COMMENT 'Secuencial unico paquetes de procesos  (generado por el sistema)',
  `ssp_despro_sppr` varchar(150) DEFAULT NULL COMMENT 'Descripcion textual del proceso de gestion',
  `ssp_secreg_sppg` varchar(10) DEFAULT NULL COMMENT 'Secuencial Maestro plantillas configuracion entorno vista gestio',
  `ssp_codper_peri` varchar(10) DEFAULT NULL COMMENT 'Codigo del periodo',
  `ssp_forfec_sscf` varchar(3) DEFAULT NULL COMMENT 'Formato de fecha:  YMD= AÑO/MES/DIA - DMY= DIA/MES/AÑO',
  `ssp_sepfec_sscf` varchar(1) DEFAULT NULL COMMENT 'Separador del formato fecha 1= Barra inclinada(/)  2=Guion medio(-)',
  `ssp_conreg_sppr` int(5) DEFAULT NULL COMMENT 'Contador para generar el secuencial unico de registros en detalle (gestion interna)',
  `ssp_estreg_sppr` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=activo 2=Inactivo',
  PRIMARY KEY (`ssp_secreg_sppr`),
  KEY `sppr02` (`ssp_despro_sppr`),
  KEY `sppr03` (`ssp_secreg_sppg`),
  KEY `sppr04` (`ssp_codper_peri`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `spocupacionciuo` table : 
#

DROP TABLE IF EXISTS `spocupacionciuo`;

CREATE TABLE `spocupacionciuo` (
  `ssp_codocu_ciuo` varchar(4) NOT NULL DEFAULT '' COMMENT 'Código de ocupacion',
  `ssp_desocu_ciuo` varchar(150) DEFAULT NULL COMMENT 'Tipo de identificacion',
  PRIMARY KEY (`ssp_codocu_ciuo`),
  KEY `ciuo02` (`ssp_desocu_ciuo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `spprogramgrupma` table : 
#

DROP TABLE IF EXISTS `spprogramgrupma`;

CREATE TABLE `spprogramgrupma` (
  `ssp_codpro_sspa` varchar(4) NOT NULL DEFAULT '' COMMENT 'Codigo unico del programa de salud digitado por el usuario',
  `ssp_abrevi_sspa` varchar(3) DEFAULT NULL COMMENT 'Letras iniciales o abreviaturas para identificacion grafica del programa',
  `ssp_titpro_sspa` varchar(50) DEFAULT NULL COMMENT 'Titulo del programa o descripcion corta',
  `ssp_despro_sspa` varchar(90) DEFAULT NULL COMMENT 'Descripcion del programa ampliada para mostrar como texto de ayuda',
  `ssp_tipreg_sspa` varchar(1) DEFAULT NULL COMMENT 'Tipo registro: 1= Programa de salud 2=Solo es Grupo para clasificar registros y organizar vistas',
  `ssp_ordvis_sspa` int(3) DEFAULT NULL COMMENT 'Orden vista organización',
  `ssp_ordpri_sspa` int(3) DEFAULT NULL COMMENT 'Orden priopridad para el proceso de clasificacion de registros en en gestion de 4505',
  `ssp_mededi_sspa` varchar(1) DEFAULT NULL COMMENT 'Medida edad inicial a la cual aplica el servicio, para validación pertinencia: 1=Años 2=Meses 3=Días',
  `ssp_edaini_sspa` int(6) DEFAULT NULL COMMENT 'Edad inicial para la cual aplica la validación de pertinencia',
  `ssp_mededf_sspa` varchar(1) DEFAULT NULL COMMENT 'Medida edad fina a la cual aplica el servicio, para validación pertinencia:1=Años 2=Meses 3=Días',
  `ssp_edafin_sspa` int(6) DEFAULT NULL COMMENT 'Edad final para la cual aplica la validación de pertinencia',
  `ssp_sexapl_sspa` varchar(1) DEFAULT NULL COMMENT 'Sexo al cual aplica el servicio:1=Masculino 2=Femenino 3=Ambos',
  `ssp_tv4505_sspa` int(6) DEFAULT NULL COMMENT 'Cantidad  variables 4505  de  la actividad que deben ser verificables para clasificar como actividad que identifica a un registro 4505',
  `ssp_tt4505_sspa` int(6) DEFAULT NULL COMMENT 'Cantidad minima de variables 4505  que deben ser verificadas para clasificar como actividad que identifica a un registro 4505',
  `ssp_tvrips_sspa` int(6) DEFAULT NULL COMMENT 'Cantidad de registros detalles (actividades Rips) que pertenecen a la actividad que deben ser verificables para clasificar como actividad que identifica a un registro 4505',
  `ssp_ttrips_sspa` int(6) DEFAULT NULL COMMENT 'Cantidad minima de registros detalles (actividades Rips)  que deben ser verificados para clasificar como actividad que identifica a un registro 4505',
  `ssp_imagen_sspa` varchar(60) DEFAULT NULL COMMENT 'Nombre de la imagen que representa el registro en las diferentes vistas',
  `ssp_icolor_sspa` varchar(20) DEFAULT NULL COMMENT 'Color del fondo en imagen en vista navegacionde registros',
  `ssp_conreg_sspa` int(5) DEFAULT NULL COMMENT 'Contador para generar los códigos registros detalles',
  `ssp_estreg_sspa` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=activo 2=Inactivo',
  PRIMARY KEY (`ssp_codpro_sspa`),
  KEY `sspa02` (`ssp_titpro_sspa`),
  KEY `sspa03` (`ssp_despro_sspa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `spprogramgrupmd` table : 
#

DROP TABLE IF EXISTS `spprogramgrupmd`;

CREATE TABLE `spprogramgrupmd` (
  `ssp_secreg_sspd` varchar(10) NOT NULL DEFAULT '' COMMENT 'Consecutivo unico del registro generado por el sistema',
  `ssp_codpro_sspa` varchar(4) DEFAULT NULL COMMENT 'Codigo unico del programa de salud digitado por el usuario',
  `ssp_codcam_resc` varchar(15) DEFAULT NULL COMMENT 'Consecutivo unico de campo o nombre (ejemplo: SSP_CAM025_MS45) en historicos resolucion 4505',
  `ssp_ordvis_sspd` int(3) DEFAULT NULL COMMENT 'Orden vista organización',
  `ssp_priori_sspd` varchar(1) DEFAULT NULL COMMENT 'Prioridad de la variable en procesos de clasificacion del registro 4505 1=Alta (diligenciada obligatoria para la actividad) 2=Baja (puede contener datos o tener valor por defecto)',
  `ssp_estreg_sspd` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=activo 2=Inactivo',
  PRIMARY KEY (`ssp_secreg_sspd`),
  KEY `sspd02` (`ssp_codpro_sspa`),
  KEY `sspd03` (`ssp_codcam_resc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sptabcampos4505` table : 
#

DROP TABLE IF EXISTS `sptabcampos4505`;

CREATE TABLE `sptabcampos4505` (
  `ssp_codcam_resc` varchar(15) NOT NULL DEFAULT '' COMMENT 'Consecutivo Único de campo o nombre (ejemplo: SSP_CAM025_MS45)',
  `ssp_nomcam_resc` varchar(150) DEFAULT NULL COMMENT 'Etiqueta del campo (descripcion campo)',
  `ssp_ordvis_resc` int(5) DEFAULT NULL COMMENT 'Orden de vista del campo en la resolucion (inicia desde campo cero (0) hasta 118)',
  `ssp_descam_resc` varchar(240) DEFAULT NULL COMMENT 'Descripción del Campo',
  `ssp_tipval_resc` varchar(1) DEFAULT NULL COMMENT 'Tipo de valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico',
  `ssp_valper_resc` varchar(240) DEFAULT NULL COMMENT 'Valores permitidos para el campo',
  `ssp_camdig_resc` varchar(1) DEFAULT NULL COMMENT 'Campo digitable: 1=Si 2=No',
  `ssp_ranini_resc` varchar(15) DEFAULT NULL COMMENT 'Rango inicial del valor digitable',
  `ssp_ranfin_resc` varchar(15) DEFAULT NULL COMMENT 'Rango final del valor digitable',
  PRIMARY KEY (`ssp_codcam_resc`),
  KEY `resc02` (`ssp_nomcam_resc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

#
# Structure for the `sptabcamposplan` table : 
#

DROP TABLE IF EXISTS `sptabcamposplan`;

CREATE TABLE `sptabcamposplan` (
  `ssp_secreg_sscp` varchar(20) NOT NULL DEFAULT '' COMMENT 'Consecutivo unico del registro generado desde editor plantillas',
  `grp_idepla_grpl` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la plantilla  base',
  `grp_idepla_grpv` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de la version plantilla usada',
  `hcl_nomcam_hccm` varchar(20) DEFAULT NULL COMMENT 'Relacionado con HCLREGISEVCAMPO Nombre del campo en la base de datos donde se guardaran los datos capturados desde el objeto, ejemplo: HCL_TXT018_HCTX, es un campo texto corto (char 130)  en el maestro HCLREGISEXTXA.',
  `ssp_codcam_resc` varchar(15) DEFAULT NULL COMMENT 'Consecutivo unico de campo o nombre (ejemplo: SSP_CAM025_MS45) en historicos resolucion 4505',
  `ssp_estreg_sscp` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=activo 2=Inactivo',
  PRIMARY KEY (`ssp_secreg_sscp`),
  KEY `sscp02` (`grp_idepla_grpl`),
  KEY `sscp03` (`grp_idepla_grpv`),
  KEY `sscp04` (`hcl_nomcam_hccm`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sptablaperiodos` table : 
#

DROP TABLE IF EXISTS `sptablaperiodos`;

CREATE TABLE `sptablaperiodos` (
  `ssp_codper_peri` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código de periodo',
  `ssp_desper_peri` varchar(50) DEFAULT NULL COMMENT 'Descripción periodo',
  `ssp_mesper_peri` varchar(2) DEFAULT NULL COMMENT 'Mes del periodo',
  `ssp_anoper_peri` varchar(4) DEFAULT NULL COMMENT 'Año del periodo',
  `ssp_tipper_peri` varchar(1) DEFAULT NULL COMMENT 'Tipo periodo: 1 mensual, 2 trimestral',
  `ssp_fecini_peri` date DEFAULT NULL COMMENT 'Fecha de inicio del periodo',
  `ssp_fecfin_peri` date DEFAULT NULL COMMENT 'Fecha de fin del periodo',
  `ssp_estper_peri` varchar(1) DEFAULT NULL COMMENT 'Estado del periodo',
  PRIMARY KEY (`ssp_codper_peri`),
  KEY `peri02` (`ssp_desper_peri`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sptablmsres4505` table : 
#

DROP TABLE IF EXISTS `sptablmsres4505`;

CREATE TABLE `sptablmsres4505` (
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Código de Eps o Asegurador según Listado EPS Ministerio Protección social',
  `ssp_cam000_ms45` varchar(1) DEFAULT NULL COMMENT 'Tipo De Registro',
  `ssp_cam001_ms45` varchar(20) NOT NULL COMMENT 'Número consecutivo de registros de detalle dentro del archivo. Inicia en 1 para el primer registro de detalle y va incrementando de 1 en 1, hasta el final del archivo.',
  `ssp_cam002_ms45` varchar(12) DEFAULT NULL COMMENT 'Tabla REPS (Registro Especial de Prestadores de Servicios de Salud) Si es desconocido registrar 999',
  `ssp_cam003_ms45` varchar(2) DEFAULT NULL COMMENT 'RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo para menores con 2 meses o menos de nacidos calculando entre la fecha de nacimiento y la fecha de corte del reporte.',
  `ssp_cam004_ms45` varchar(18) DEFAULT NULL COMMENT 'Número del documento de identificación, de acuerdo con el tipo de identificación del campo anterior.',
  `ssp_cam005_ms45` varchar(30) DEFAULT NULL COMMENT 'Primer apellido del usuario. Tenga en cuenta el numeral 1.',
  `ssp_cam006_ms45` varchar(30) DEFAULT NULL COMMENT 'Tenga en cuenta el numeral 1. En caso que el usuario no tenga segundo apellido o no se tenga este dato Registre NONE, en mayúscula sostenida.',
  `ssp_cam007_ms45` varchar(30) DEFAULT NULL COMMENT 'Primer nombre del usuario. Tenga en cuenta el numeral 1.',
  `ssp_cam008_ms45` varchar(30) DEFAULT NULL COMMENT 'Segundo nombre del usuario. Tenga en cuenta el numeral 1. En caso que el usuario no tenga segundo apellido o no se tenga este dato Registre NONE, en mayúscula sostenida.',
  `ssp_cam009_ms45` date DEFAULT NULL COMMENT 'Fecha de Nacimiento. AAAA-MM-DD',
  `ssp_cam010_ms45` varchar(1) DEFAULT NULL COMMENT 'Sexo. M - Masculino F - Femenino',
  `ssp_cam011_ms45` varchar(1) DEFAULT NULL COMMENT 'Codigo pertenencia etnica. Registre según lo reporte el usuario: 1-Indígena 2-ROM (gitano)3-Raizal etc',
  `ssp_codocu_ciuo` varchar(4) DEFAULT NULL COMMENT 'Código de acuerdo a la Clasificación Internacional Uniforme de Ocupaciones (CIUO). En los casos en que no se tiene esta información registrar (9999). En el caso que no aplique registrar (9998).',
  `ssp_cam013_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre según lo reporte el usuario: 1- No Definido 2- Preescolar 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc',
  `ssp_cam014_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam015_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si es mujer con sífilis\r\ngestacional\r\n2- Si es recién nacido con sífilis\r\ncongénita\r\n3- No\r\n21- Riesgo no evaluado',
  `ssp_cam016_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam017_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam018_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam019_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam020_ms45` varchar(2) DEFAULT NULL COMMENT '1- Paucibacilar\r\n2- Multibacilar\r\n3- No\r\n21- Riesgo no evaluado',
  `ssp_cam021_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si es Obesidad\r\n2- Si es Desnutrición Proteico\r\nCalórica\r\n3- No\r\n21- Riesgo no evaluado',
  `ssp_cam022_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si es Mujer víctima del\r\nmaltrato\r\n2- Si es Menor víctima del\r\nmaltrato\r\n3- No\r\n21- Riesgo no evaluado',
  `ssp_cam023_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam024_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam025_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si el diagnóstico es Ansiedad\r\n2- Si el diagnóstico es\r\nDepresión\r\n3- Si el diagnóstico es\r\nesquizofrenia\r\n4- Si el diagnóstico es Déficit de\r\natención por Hiperactividad\r\n5- Si el diagnóstico es consumo\r\nSustancias ',
  `ssp_cam026_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam027_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam028_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam029_ms45` date DEFAULT NULL COMMENT 'Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01',
  `ssp_cam030_ms45` float(4,1) DEFAULT NULL COMMENT 'Peso en Kilogramos Se registra el dato obtenido de la medición. Si no se toma registrar 999',
  `ssp_cam031_ms45` date DEFAULT NULL COMMENT 'Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01',
  `ssp_cam032_ms45` int(4) DEFAULT NULL COMMENT 'Se registra el dato obtenido de la medición. Si no se toma registrar 999',
  `ssp_cam033_ms45` date DEFAULT NULL COMMENT 'Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam034_ms45` int(3) DEFAULT NULL COMMENT 'Se registra el dato de la edad gestacional en semanas. Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam035_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por\r\nNegación del ',
  `ssp_cam036_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por\r\nNegación del ',
  `ssp_cam037_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No ',
  `ssp_cam038_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis\r\n4- Cuatro Dosis\r\n5- Cinco Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por ',
  `ssp_cam039_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n4- Cuatro Dosis\r\n5- Cinco Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra ',
  `ssp_cam040_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por',
  `ssp_cam041_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se ',
  `ssp_cam042_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis Anual\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- ',
  `ssp_cam043_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por\r\nNegación del ',
  `ssp_cam044_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por\r\nNegación del',
  `ssp_cam045_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por',
  `ssp_cam046_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No ',
  `ssp_cam047_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis\r\n4- Cuatro Dosis\r\n5- Cinco Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por ',
  `ssp_cam048_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si – 1ra vez en el año\r\n2- Si – 2da vez en el año\r\n16- No se realiza por una\r\nTradición\r\n17- No se realiza por una\r\nCondición de Salud\r\n18- No se realiza por Negación\r\ndel usuario\r\n19- No se realiza por',
  `ssp_cam049_ms45` date DEFAULT NULL COMMENT 'Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam050_ms45` date DEFAULT NULL COMMENT 'Fecha salida de la atencion del parto o cesarea AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam051_ms45` date DEFAULT NULL COMMENT 'Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam052_ms45` date DEFAULT NULL COMMENT 'Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam053_ms45` date DEFAULT NULL COMMENT 'Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam054_ms45` varchar(2) DEFAULT NULL COMMENT 'Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera ETC',
  `ssp_cam055_ms45` date DEFAULT NULL COMMENT 'Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01 ETC',
  `ssp_cam056_ms45` date DEFAULT NULL COMMENT 'Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam057_ms45` int(3) DEFAULT NULL COMMENT 'Control Prenatal Registre el número de controles que ha tenido en el último período de reporte durante la gestación actual, Si no tiene el dato registrar 999 Si no aplica registrar 998',
  `ssp_cam058_ms45` date DEFAULT NULL COMMENT 'ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01 ETC',
  `ssp_cam059_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si se suministra\r\n16- No se suministra por una\r\nTradición\r\n17- No se suministra por una\r\nCondición de Salud\r\n18- No se suministra por\r\nNegación de la usuaria\r\n20- No se suministra por otras\r\nrazones',
  `ssp_cam060_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si se suministra\r\n16- No se suministra por una\r\nTradición\r\n17- No se suministra por una\r\nCondición de Salud\r\n18- No se suministra por\r\nNegación de la usuaria\r\n20- No se suministra por otras\r\nrazones',
  `ssp_cam061_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si se suministra\r\n16- No se suministra por una\r\nTradición\r\n17- No se suministra por una\r\nCondición de Salud\r\n18- No se suministra por\r\nNegación de la usuaria\r\n20- No se suministra por otras\r\nrazones',
  `ssp_cam062_ms45` date DEFAULT NULL COMMENT 'AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam063_ms45` date DEFAULT NULL COMMENT 'Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam064_ms45` date DEFAULT NULL COMMENT 'Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01 ETC',
  `ssp_cam065_ms45` date DEFAULT NULL COMMENT 'Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam066_ms45` date DEFAULT NULL COMMENT 'Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam067_ms45` date DEFAULT NULL COMMENT 'Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam068_ms45` date DEFAULT NULL COMMENT 'Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC',
  `ssp_cam069_ms45` date DEFAULT NULL COMMENT 'Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam070_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si se suministra\r\n16- No se suministra por una\r\nTradición\r\n17- No se suministra por una\r\nCondición de Salud\r\n18- No se suministra por\r\nNegación de la usuario\r\n20- No se suministra por otras\r\nrazones\r\n21- Registro no Evaluado',
  `ssp_cam071_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si se suministra\r\n16- No se suministra por una\r\nTradición\r\n17- No se suministra por una\r\nCondición de Salud\r\n18- No se suministra por\r\nNegación de la usuario\r\n20- No se suministra por otras\r\nrazones\r\n21- Registro no Evaluado',
  `ssp_cam072_ms45` date DEFAULT NULL COMMENT 'Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam073_ms45` date DEFAULT NULL COMMENT 'Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam074_ms45` int(3) DEFAULT NULL COMMENT 'Preservativos entregados a pacientes con ITS Registre el número de Preservativos entregados durante el período de reporte. Si no tiene el dato registrar 999 Si no aplica registrar 998 ETC',
  `ssp_cam075_ms45` date DEFAULT NULL COMMENT 'Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam076_ms45` date DEFAULT NULL COMMENT 'Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam077_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- En proceso de atención.\r\n2- Si recibió atención por equipo\r\ninterdisciplinario completo.\r\n16- No recibió atención por\r\ntener una tradición que se lo\r\nimpide\r\n17- No recibió atención por una\r\ncondición de salud',
  `ssp_cam078_ms45` date DEFAULT NULL COMMENT 'Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam079_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Negativo\r\n2- Positivo\r\n22- Sin dato',
  `ssp_cam080_ms45` date DEFAULT NULL COMMENT 'Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam081_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- No Reactiva\r\n2- Reactiva\r\n22- Sin dato',
  `ssp_cam082_ms45` date DEFAULT NULL COMMENT 'Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam083_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Negativo\r\n2- Positivo\r\n22- Sin dato',
  `ssp_cam084_ms45` date DEFAULT NULL COMMENT 'Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam085_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Normal\r\n2- Anormal\r\n22- Sin dato',
  `ssp_cam086_ms45` varchar(2) DEFAULT NULL COMMENT 'Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam087_ms45` date DEFAULT NULL COMMENT 'Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam088_ms45` varchar(3) DEFAULT NULL COMMENT 'Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US (células escamosas atípicas de significado indeterminado) 2- ASC-H (células escamosas atípicas, que no puede descartar alto grado) 3- Lesión intraepitelial escamosa de bajo grado ETC',
  `ssp_cam089_ms45` varchar(3) DEFAULT NULL COMMENT 'Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam090_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Citologia Cervicouterina Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam091_ms45` date DEFAULT NULL COMMENT 'Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam092_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Colposcopia Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam093_ms45` date DEFAULT NULL COMMENT 'Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam094_ms45` varchar(3) DEFAULT NULL COMMENT 'Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1- Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto Grado: NIC II - NIC III ETC',
  `ssp_cam095_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam096_ms45` date DEFAULT NULL COMMENT 'Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam097_ms45` varchar(3) DEFAULT NULL COMMENT 'Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico o Mamograma previo para evaluación 1- Negativo 2- Hallazgos Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa ETC',
  `ssp_cam098_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam099_ms45` date DEFAULT NULL COMMENT 'Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam100_ms45` date DEFAULT NULL COMMENT 'Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam101_ms45` varchar(3) DEFAULT NULL COMMENT 'Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada) 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam102_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam103_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam104_ms45` float(4,1) DEFAULT NULL COMMENT 'Hemoglobina Registre el dato reportado por el laboratorio. Si no aplica registre 0',
  `ssp_cam105_ms45` date DEFAULT NULL COMMENT 'Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam106_ms45` date DEFAULT NULL COMMENT 'Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam107_ms45` float(4,1) DEFAULT NULL COMMENT 'Creatinina Registre el dato reportado por el laboratorio. Si no tiene el dato registrar 999 Si no aplica registrar 0',
  `ssp_cam108_ms45` date DEFAULT NULL COMMENT 'Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam109_ms45` float(4,1) DEFAULT NULL COMMENT 'Hemoglobina Glicosilada Registre el dato reportado por el laboratorio Si no tiene el dato registrar 999 Si no aplica registrar 0',
  `ssp_cam110_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam111_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam112_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam113_ms45` varchar(2) DEFAULT NULL COMMENT '1- Negativa\r\n2- Positiva\r\n3- En proceso\r\n4- No\r\n22- Sin dato',
  `ssp_cam114_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si recibe tratamiento pero\r\naún no ha terminado\r\n2- Si recibió tratamiento y ya lo\r\nterminó\r\n16- No recibió tratamiento por\r\ntener una tradición que se lo\r\nimpide\r\n17- No recibió tratamiento por',
  `ssp_cam115_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si recibe tratamiento pero\r\naún no ha terminado\r\n2- Si recibió tratamiento y ya lo\r\nterminó\r\n16- No recibió tratamiento por\r\ntener una tradición que se lo\r\nimpide\r\n17- No recibió tratamiento por',
  `ssp_cam116_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si recibe tratamiento pero\r\naún no ha terminado\r\n2- Si recibió tratamiento y ya lo\r\nterminó\r\n16- No recibió tratamiento por\r\ntener una tradición que se lo\r\nimpide\r\n17- No recibió tratamiento ',
  `ssp_cam117_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si recibe tratamiento pero\r\naún no ha terminado\r\n2- Si recibió tratamiento y ya lo\r\nterminó\r\n16- No recibió tratamiento por\r\ntener una tradición que se lo\r\nimpide\r\n17- No recibió tratamiento ',
  `ssp_cam118_ms45` date DEFAULT NULL COMMENT 'Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 Si no se realiza por una Condición de Salud registrar 1810-01-01',
  `ssp_consec_ms45` int(10) DEFAULT NULL COMMENT 'Contador para generar secuencial de novedades',
  PRIMARY KEY (`ssp_cam001_ms45`),
  KEY `ms4502` (`sia_nroide_usua`),
  KEY `ms4503` (`ssp_cam005_ms45`),
  KEY `ms4504` (`ssp_cam006_ms45`),
  KEY `ms4505` (`ssp_cam007_ms45`),
  KEY `ms4506` (`ssp_cam008_ms45`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

#
# Structure for the `sptablnsres4505` table : 
#

DROP TABLE IF EXISTS `sptablnsres4505`;

CREATE TABLE `sptablnsres4505` (
  `ssp_idesec_ns45` varchar(20) NOT NULL DEFAULT '' COMMENT 'Id Único del registro novedad',
  `ssp_secreg_sppr` varchar(10) DEFAULT NULL COMMENT 'Secuencial unico paquetes de proceso al cual pertenece el registro',
  `ssp_codper_peri` varchar(10) DEFAULT NULL COMMENT 'Codigo del periodo',
  `ssp_mesper_peri` varchar(2) DEFAULT NULL COMMENT 'Mes periodo',
  `ssp_anoper_peri` varchar(4) DEFAULT NULL COMMENT 'Año del periodo',
  `ssp_llaper_ns45` varchar(6) DEFAULT NULL COMMENT 'Llave del periodo (año+mes)',
  `ssp_llaloc_ns45` varchar(20) DEFAULT NULL COMMENT 'Llave para localizacion del registro  (SIA_IDESEC_USUA+SSP_LLAPER_NS45)',
  `sia_idesec_usua` varchar(20) DEFAULT NULL COMMENT 'Consecutivo Único de paciente en el sistema, se genera al momento de crear el registro o cuando la base de datos es cargada en el sistema',
  `sia_nroide_usua` varchar(20) DEFAULT NULL COMMENT 'Numero de identificación del paciente: Registro civil, Cedula, Tarjeta de identidad y otros',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Código de Eps o Asegurador según Listado EPS Ministerio Protección social',
  `ssp_codpro_sspa` varchar(4) DEFAULT NULL COMMENT 'Codigo unico Grupo Actividad o  Programa de salud digitado por el usuario',
  `ssp_codpro_ms45` varchar(150) DEFAULT NULL COMMENT 'Lista códigos programa o grupo actividad (separada por guion), clasificadas que contiene el registro EJEMPLO: (01-02-03-04-05) 01=Vacunación/02=Saludoral/03=Parto/04=Recién nacido/05=Planificación/ otros …',
  `ssp_abrevi_ms45` varchar(180) DEFAULT NULL COMMENT 'Lista abreviaturas de todos programas en los que se clasifica el registro separadas por guión VAC=Vacunación/SOR=Salud oral/PAR=Atención parto/NAC=Atención recién nacido/otros…',
  `ssp_varmod_ms45` varchar(4) DEFAULT NULL COMMENT 'Lista variables 4505 modificadas del registro, separadas por guion medio son variables que contienen datos  ejemplo:  25-53-63-67-73…',
  `ssp_cam000_ms45` varchar(1) DEFAULT NULL COMMENT 'Tipo De Registro',
  `ssp_cam001_ms45` varchar(20) DEFAULT NULL COMMENT 'Número consecutivo de registros de detalle dentro del archivo. Inicia en 1 para el primer registro de detalle y va incrementando de 1 en 1, hasta el final del archivo. (el tamaño real del campo es char 8)',
  `ssp_cam002_ms45` varchar(12) DEFAULT NULL COMMENT 'Tabla REPS (Registro Especial de Prestadores de Servicios de Salud) Si es desconocido registrar 99',
  `ssp_cam003_ms45` varchar(2) DEFAULT NULL COMMENT 'RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo para menores con 2 meses o menos de nacidos calculando entre la fecha de nacimiento y la fecha de corte del reporte.',
  `ssp_cam004_ms45` varchar(18) DEFAULT NULL COMMENT 'Número del documento de identificación, de acuerdo con el tipo de identificación del campo anterior.',
  `ssp_cam005_ms45` varchar(30) DEFAULT NULL COMMENT 'Primer apellido del usuario. Tenga en cuenta el numeral 1.',
  `ssp_cam006_ms45` varchar(30) DEFAULT NULL COMMENT 'Tenga en cuenta el numeral 1. En caso que el usuario no tenga segundo apellido o no se tenga este dato Registre NONE, en mayúscula sostenida.',
  `ssp_cam007_ms45` varchar(30) DEFAULT NULL COMMENT 'Primer nombre del usuario. Tenga en cuenta el numeral 1.',
  `ssp_cam008_ms45` varchar(30) DEFAULT NULL COMMENT 'Segundo nombre del usuario. Tenga en cuenta el numeral 1. En caso que el usuario no tenga segundo apellido o no se tenga este dato Registre NONE, en mayúscula sostenida.',
  `ssp_cam009_ms45` date DEFAULT NULL COMMENT 'Fecha de Nacimiento. AAAA-MM-DD',
  `ssp_cam010_ms45` varchar(1) DEFAULT NULL COMMENT 'Sexo. M - Masculino F - Femenino',
  `ssp_cam011_ms45` varchar(1) DEFAULT NULL COMMENT 'Codigo pertenencia etnica. Registre según lo reporte el usuario: 1-Indígena 2-ROM (gitano)3-Raizal etc',
  `ssp_codocu_ciuo` varchar(4) DEFAULT NULL COMMENT 'Código de acuerdo a la Clasificación Internacional Uniforme de Ocupaciones (CIUO). En los casos en que no se tiene esta información registrar (9999). En el caso que no aplique registrar (9998).',
  `ssp_cam013_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre según lo reporte el usuario: 1- No Definido 2- Preescolar 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc',
  `ssp_cam014_ms45` varchar(1) DEFAULT NULL COMMENT '0- No 1- Si 2- No aplica 3- Riesgo no evaluado',
  `ssp_cam015_ms45` varchar(1) DEFAULT NULL COMMENT '0- No 1- Si es mujer con sífilis gestacional 2- Si es recién nacido con sífilis congénita 3- No aplica 4- Riesgo no evaluado',
  `ssp_cam016_ms45` varchar(1) DEFAULT NULL COMMENT 'Hipertension Inducida por la Gestacion 0- No 1- Si 2- No aplica 3- Riesgo no evaluado',
  `ssp_cam017_ms45` varchar(1) DEFAULT NULL COMMENT 'Hipotiroidismo Congenito 0- No 1- Si 2- No aplica 3- Riesgo no evaluado',
  `ssp_cam018_ms45` varchar(1) DEFAULT NULL COMMENT 'Sintomatico Respiratorio 0- No 1- Si 2- Riesgo no evaluado',
  `ssp_cam019_ms45` varchar(1) DEFAULT NULL COMMENT 'Tuberculosis Multidrogoresistente 0- No 1- Si 2- No aplica 3- Riesgo no evaluado',
  `ssp_cam020_ms45` varchar(1) DEFAULT NULL COMMENT 'Lepra 0- No 1- Pausibacilar 2- Multibacilar 3- Riesgo no evaluado',
  `ssp_cam021_ms45` varchar(1) DEFAULT NULL COMMENT 'Obesidad o Desnutricion Proteico Calorica 0- No 1- Si es Obesidad 2- Si es Desnutrición Proteico Calórica 3- Riesgo no evaluado',
  `ssp_cam022_ms45` varchar(1) DEFAULT NULL COMMENT 'Mujer Victima de Maltrato 0- No 1- Si es Mujer víctima del maltrato 2- Si es Menor víctima del maltrato 3- No aplica 4- Riesgo no evaluado',
  `ssp_cam023_ms45` varchar(1) DEFAULT NULL COMMENT 'Victima de Violencia Sexual 0- No 1- Si 2- No aplica 3- Riesgo no evaluado',
  `ssp_cam024_ms45` varchar(1) DEFAULT NULL COMMENT 'Infecciones de Trasmision Sexual 0- No 1- Si 2- No aplica 3- Riesgo no evaluado',
  `ssp_cam025_ms45` varchar(1) DEFAULT NULL COMMENT 'Enfermedad Mental 0- No 1- Si el diagnóstico es Ansiedad 2- Si el diagnóstico es Depresión 3- Si el diagnóstico es esquizofrenia ETC',
  `ssp_cam026_ms45` varchar(1) DEFAULT NULL COMMENT 'Cancer de Cervix 0- No 1- Si 2- No aplica 3- Riesgo no evaluado',
  `ssp_cam027_ms45` varchar(1) DEFAULT NULL COMMENT 'Cancer de Seno 0- No 1- Si 2- No aplica 3- Riesgo no evaluado',
  `ssp_cam028_ms45` varchar(1) DEFAULT NULL COMMENT 'Fluorosis Dental 0- No 1- Si 2- No aplica 3- Riego no evaluado',
  `ssp_cam029_ms45` date DEFAULT NULL COMMENT 'Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01',
  `ssp_cam030_ms45` int(4) DEFAULT NULL COMMENT 'Peso en Kilogramos Se registra el dato obtenido de la medición. Si no se toma registrar 999',
  `ssp_cam031_ms45` date DEFAULT NULL COMMENT 'Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01',
  `ssp_cam032_ms45` int(4) DEFAULT NULL COMMENT 'Se registra el dato obtenido de la medición. Si no se toma registrar 999',
  `ssp_cam033_ms45` date DEFAULT NULL COMMENT 'Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam034_ms45` int(3) DEFAULT NULL COMMENT 'Se registra el dato de la edad gestacional en semanas. Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam035_ms45` varchar(1) DEFAULT NULL COMMENT 'BCG Registre el dato de la última dosis aplicada así: 0- RN 1- Otra Dosis 2- Sin dato 3- No se administra por una Tradición ETC',
  `ssp_cam036_ms45` varchar(1) DEFAULT NULL COMMENT 'Hepatitis B menores de 1 año Registre el dato de la última dosis aplicada así: 0- RN 1- Primera Dosis 2- Segunda Dosis 3- Tercera Dosis ETC',
  `ssp_cam037_ms45` varchar(1) DEFAULT NULL COMMENT 'Pentavalente Registre el dato de la última dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Sin dato ETC',
  `ssp_cam038_ms45` varchar(1) DEFAULT NULL COMMENT 'Polio Registre el dato de la última dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Primer Refuerzo ETC',
  `ssp_cam039_ms45` varchar(1) DEFAULT NULL COMMENT 'DPT menores de 5 años Registre el dato de la última dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Primer Refuerzo ETC',
  `ssp_cam040_ms45` varchar(1) DEFAULT NULL COMMENT 'Rotavirus Registre el dato de la última dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2- Sin dato ETC',
  `ssp_cam041_ms45` varchar(1) DEFAULT NULL COMMENT 'Neumococo Registre el dato de la última dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin dato ETC',
  `ssp_cam042_ms45` varchar(1) DEFAULT NULL COMMENT 'Influenza Niños Registre el dato de la última dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC',
  `ssp_cam043_ms45` varchar(1) DEFAULT NULL COMMENT 'Fiebre Amarilla niños de 1 año Registre el dato de la última dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición ETC',
  `ssp_cam044_ms45` varchar(1) DEFAULT NULL COMMENT 'Hepatitis A Registre el dato de la última dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición 3- No se administra por una Condición de Salud ETC',
  `ssp_cam045_ms45` varchar(1) DEFAULT NULL COMMENT 'Triple Viral Niños Registre el dato de la última dosis aplicada así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No se administra por una Tradición 4- No se administra por una Condición de Salud ETC',
  `ssp_cam046_ms45` varchar(1) DEFAULT NULL COMMENT 'Virus del Papiloma Humano (VPH) Registre el dato de la última dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera Dosis 3- Sin dato ETC',
  `ssp_cam047_ms45` varchar(1) DEFAULT NULL COMMENT 'TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato de la última dosis aplicada así: 0- Primera Dosis 1- Segunda  Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC',
  `ssp_cam048_ms45` varchar(1) DEFAULT NULL COMMENT 'Control de Placa Bacteriana 0- No se realiza por una Tradición 1- No se realiza por una Condición de Salud 2- No se realiza por Negación del usuario',
  `ssp_cam049_ms45` date DEFAULT NULL COMMENT 'Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam050_ms45` date DEFAULT NULL COMMENT 'Fecha salida de la atencion del parto o cesarea AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam051_ms45` date DEFAULT NULL COMMENT 'Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam052_ms45` date DEFAULT NULL COMMENT 'Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam053_ms45` date DEFAULT NULL COMMENT 'Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam054_ms45` varchar(2) DEFAULT NULL COMMENT 'Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera ETC',
  `ssp_cam055_ms45` date DEFAULT NULL COMMENT 'Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01 ETC',
  `ssp_cam056_ms45` date DEFAULT NULL COMMENT 'Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam057_ms45` int(3) DEFAULT NULL COMMENT 'Control Prenatal Registre el número de controles que ha tenido en el último período de reporte durante la gestación actual, Si no tiene el dato registrar 999 Si no aplica registrar 998',
  `ssp_cam058_ms45` date DEFAULT NULL COMMENT 'ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01 ETC',
  `ssp_cam059_ms45` varchar(1) DEFAULT NULL COMMENT '0- No se suministra por una Tradición 1- No se suministra por una Condición de Salud 2- No se suministra por Negación de la usuaria 3- No se suministra por otras razones 4- Si se suministra 5- Registro no Evaluado 6- No aplica',
  `ssp_cam060_ms45` varchar(1) DEFAULT NULL COMMENT '0- No se suministra por una Tradición 1- No se suministra por una Condición de Salud 2- No se suministra por Negación del usuario 3- No se suministra por otras razones 4- Si se suministra 5- Registro no Evaluado 6- No aplica',
  `ssp_cam061_ms45` varchar(1) DEFAULT NULL COMMENT '0- No se suministra por una Tradición 1- No se suministra por una Condición de Salud 2- No se suministra por Negación del usuario 3- No se suministra por otras razones 4- Si se suministra 5- Registro no Evaluado 6- No aplica',
  `ssp_cam062_ms45` date DEFAULT NULL COMMENT 'AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam063_ms45` date DEFAULT NULL COMMENT 'Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam064_ms45` date DEFAULT NULL COMMENT 'Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01 ETC',
  `ssp_cam065_ms45` date DEFAULT NULL COMMENT 'Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam066_ms45` date DEFAULT NULL COMMENT 'Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam067_ms45` date DEFAULT NULL COMMENT 'Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam068_ms45` date DEFAULT NULL COMMENT 'Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC',
  `ssp_cam069_ms45` date DEFAULT NULL COMMENT 'Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam070_ms45` varchar(1) DEFAULT NULL COMMENT '0- No se suministra por una Tradición 1- No se suministra por una Condición de Salud 2- No se suministra por Negación del usuario 3- No se suministra por otras razones 4- Si se suministra 5- Registro no Evaluado 6- No aplica',
  `ssp_cam071_ms45` varchar(1) DEFAULT NULL COMMENT '0- No se suministra por una Tradición 1- No se suministra por una Condición de Salud 2- No se suministra por Negación del usuario 3- No se suministra por otras razones 4- Si se suministra 5- Registro no Evaluado 6- No aplica',
  `ssp_cam072_ms45` date DEFAULT NULL COMMENT 'Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam073_ms45` date DEFAULT NULL COMMENT 'Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam074_ms45` int(3) DEFAULT NULL COMMENT 'Preservativos entregados a pacientes con ITS Registre el número de Preservativos entregados durante el período de reporte. Si no tiene el dato registrar 999 Si no aplica registrar 998 ETC',
  `ssp_cam075_ms45` date DEFAULT NULL COMMENT 'Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam076_ms45` date DEFAULT NULL COMMENT 'Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam077_ms45` varchar(1) DEFAULT NULL COMMENT '0- No recibió atención por tener una tradición que se lo impide 1- No recibió atención por una condición de salud 2- No recibió atención por negación del usuario ETC',
  `ssp_cam078_ms45` date DEFAULT NULL COMMENT 'Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam079_ms45` varchar(1) DEFAULT NULL COMMENT 'Resultado Antigeno de Superficie Hepatitis B en Gestantes 0- Negativo 1- Positivo 2- Sin dato 3- No aplica',
  `ssp_cam080_ms45` date DEFAULT NULL COMMENT 'Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam081_ms45` varchar(1) DEFAULT NULL COMMENT 'Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva 2- Sin dato 3- No aplica',
  `ssp_cam082_ms45` date DEFAULT NULL COMMENT 'Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam083_ms45` varchar(1) DEFAULT NULL COMMENT 'Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado 3- Sin dato 4- No aplica',
  `ssp_cam084_ms45` date DEFAULT NULL COMMENT 'Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam085_ms45` varchar(1) DEFAULT NULL COMMENT 'Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato 3- No aplica',
  `ssp_cam086_ms45` varchar(2) DEFAULT NULL COMMENT 'Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam087_ms45` date DEFAULT NULL COMMENT 'Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam088_ms45` varchar(2) DEFAULT NULL COMMENT 'Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US (células escamosas atípicas de significado indeterminado) 2- ASC-H (células escamosas atípicas, que no puede descartar alto grado) 3- Lesión intraepitelial escamosa de bajo grado ETC',
  `ssp_cam089_ms45` varchar(2) DEFAULT NULL COMMENT 'Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam090_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Citologia Cervicouterina Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam091_ms45` date DEFAULT NULL COMMENT 'Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam092_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Colposcopia Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam093_ms45` date DEFAULT NULL COMMENT 'Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam094_ms45` varchar(2) DEFAULT NULL COMMENT 'Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1- Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto Grado: NIC II - NIC III ETC',
  `ssp_cam095_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam096_ms45` date DEFAULT NULL COMMENT 'Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam097_ms45` varchar(2) DEFAULT NULL COMMENT 'Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico o Mamograma previo para evaluación 1- Negativo 2- Hallazgos Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa ETC',
  `ssp_cam098_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam099_ms45` date DEFAULT NULL COMMENT 'Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam100_ms45` date DEFAULT NULL COMMENT 'Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam101_ms45` varchar(2) DEFAULT NULL COMMENT 'Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada) 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam102_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam103_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam104_ms45` int(6) DEFAULT NULL COMMENT 'Hemoglobina Registre el dato reportado por el laboratorio. Si no aplica registre 9998',
  `ssp_cam105_ms45` date DEFAULT NULL COMMENT 'Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam106_ms45` date DEFAULT NULL COMMENT 'Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam107_ms45` int(6) DEFAULT NULL COMMENT 'Creatinina Registre el dato reportado por el laboratorio. Si no tiene el dato registrar 999 Si no aplica registrar 998',
  `ssp_cam108_ms45` date DEFAULT NULL COMMENT 'Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam109_ms45` int(6) DEFAULT NULL COMMENT 'Hemoglobina Glicosilada Registre el dato reportado por el laboratorio Si no tiene el dato registrar 999 Si no aplica registrar 998',
  `ssp_cam110_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam111_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam112_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam113_ms45` varchar(1) DEFAULT NULL COMMENT 'Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3- Sin dato 4- No aplica',
  `ssp_cam114_ms45` varchar(1) DEFAULT NULL COMMENT 'Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento por tener una tradición que se lo impide 1- No recibió tratamiento por una condición de salud que se lo impide ETC',
  `ssp_cam115_ms45` varchar(1) DEFAULT NULL COMMENT 'Tratamiento para Sifilis gestacional 0- No recibió tratamiento por tener una tradición que se lo impide 1- No recibió tratamiento por una condición de salud 2- No recibió tratamiento por negación del usuario ETC',
  `ssp_cam116_ms45` varchar(1) DEFAULT NULL COMMENT 'Tratamiento para Sifilis Congenita 0- No recibió tratamiento por tener una tradición que se lo impide 1- No recibió tratamiento por una condición de salud 2- No recibió tratamiento por negación del usuario ETC',
  `ssp_cam117_ms45` varchar(1) DEFAULT NULL COMMENT 'Tratamiento para Lepra 0- No recibió tratamiento por tener una tradición que se lo impide 1- No recibió tratamiento por una condición de salud 2- No recibió tratamiento por negación del usuario ETC',
  `ssp_cam118_ms45` date DEFAULT NULL COMMENT 'Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 Si no se realiza por una Condición de Salud registrar 1810-01-01',
  `ssp_notedt_ms45` text COMMENT 'Nota textual gestion del registro',
  `ssp_estedt_ms45` varchar(50) DEFAULT NULL COMMENT 'Estado textual del registro en proceso:  ERRADO/MODIFICADO/ACTUALIZADO/ Y OTROS',
  `ssp_estreg_ms45` varchar(1) DEFAULT NULL COMMENT 'Estado del registro para proceso de edicion 1 = Activo o Incluido en gestion 2=Inactivo o No incluido para gestion',
  PRIMARY KEY (`ssp_idesec_ns45`),
  KEY `ns4502` (`sia_idesec_usua`),
  KEY `ns4503` (`sia_nroide_usua`),
  KEY `ns4504` (`ssp_secreg_sppr`),
  KEY `ns4505` (`ssp_codpro_sspa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `spvaloredefault` table : 
#

DROP TABLE IF EXISTS `spvaloredefault`;

CREATE TABLE `spvaloredefault` (
  `ssp_idesec_spvd` varchar(20) NOT NULL DEFAULT '' COMMENT 'Id Único del registro (generado por el sistema)',
  `ssp_desval_spvd` varchar(60) DEFAULT NULL COMMENT 'Descripcion de registro de valores por defecto',
  `ssp_secreg_spdf` varchar(10) DEFAULT NULL COMMENT 'Codigo grupo maestro para agrupar y generar registros 4505',
  `ssp_codpro_sspa` varchar(4) DEFAULT NULL COMMENT 'Codigo unico del grupo de actividad',
  `ssp_edidia_spvd` int(6) DEFAULT NULL COMMENT 'Edad inicial en dias',
  `ssp_edfdia_spvd` int(6) DEFAULT NULL COMMENT 'Edad final en dias',
  `ssp_ediano_spvd` int(3) DEFAULT NULL COMMENT 'Edad inicial en años',
  `ssp_edfano_spvd` int(3) DEFAULT NULL COMMENT 'Edad final en años',
  `ssp_sexapl_spvd` varchar(1) DEFAULT NULL COMMENT 'Sexo al cual aplica : F=femenino M=Masculino',
  `ssp_cam000_ms45` varchar(1) DEFAULT NULL COMMENT 'Tipo De Registro',
  `ssp_cam001_ms45` varchar(20) DEFAULT NULL COMMENT 'Número consecutivo de registros de detalle dentro del archivo. Inicia en 1 para el primer registro de detalle y va incrementando de 1 en 1, hasta el final del archivo.',
  `ssp_cam002_ms45` varchar(12) DEFAULT NULL COMMENT 'Tabla REPS (Registro Especial de Prestadores de Servicios de Salud) Si es desconocido registrar 99',
  `ssp_cam003_ms45` varchar(2) DEFAULT NULL COMMENT 'RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo para menores con 2 meses o menos de nacidos calculando entre la fecha de nacimiento y la fecha de corte del reporte.',
  `ssp_cam004_ms45` varchar(18) DEFAULT NULL COMMENT 'Número del documento de identificación, de acuerdo con el tipo de identificación del campo anterior.',
  `ssp_cam005_ms45` varchar(30) DEFAULT NULL COMMENT 'Primer apellido del usuario. Tenga en cuenta el numeral 1.',
  `ssp_cam006_ms45` varchar(30) DEFAULT NULL COMMENT 'Tenga en cuenta el numeral 1. En caso que el usuario no tenga segundo apellido o no se tenga este dato Registre NONE, en mayúscula sostenida.',
  `ssp_cam007_ms45` varchar(30) DEFAULT NULL COMMENT 'Primer nombre del usuario. Tenga en cuenta el numeral 1.',
  `ssp_cam008_ms45` varchar(30) DEFAULT NULL COMMENT 'Segundo nombre del usuario. Tenga en cuenta el numeral 1. En caso que el usuario no tenga segundo apellido o no se tenga este dato Registre NONE, en mayúscula sostenida.',
  `ssp_cam009_ms45` date DEFAULT NULL COMMENT 'Fecha de Nacimiento. AAAA-MM-DD',
  `ssp_cam010_ms45` varchar(1) DEFAULT NULL COMMENT 'Sexo. M - Masculino F - Femenino',
  `ssp_cam011_ms45` varchar(1) DEFAULT NULL COMMENT 'Codigo pertenencia etnica. Registre según lo reporte el usuario: 1-Indígena 2-ROM (gitano)3-Raizal etc',
  `ssp_codocu_ciuo` varchar(4) DEFAULT NULL COMMENT 'Código de acuerdo a la Clasificación Internacional Uniforme de Ocupaciones (CIUO). En los casos en que no se tiene esta información registrar (9999). En el caso que no aplique registrar (9998).',
  `ssp_cam013_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre según lo reporte el usuario: 1- No Definido 2- Preescolar 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc',
  `ssp_cam014_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam015_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si es mujer con sífilis\r\ngestacional\r\n2- Si es recién nacido con sífilis\r\ncongénita\r\n3- No\r\n21- Riesgo no evaluado',
  `ssp_cam016_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam017_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam018_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam019_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam020_ms45` varchar(2) DEFAULT NULL COMMENT '1- Paucibacilar\r\n2- Multibacilar\r\n3- No\r\n21- Riesgo no evaluado',
  `ssp_cam021_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si es Obesidad\r\n2- Si es Desnutrición Proteico\r\nCalórica\r\n3- No\r\n21- Riesgo no evaluado',
  `ssp_cam022_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si es Mujer víctima del\r\nmaltrato\r\n2- Si es Menor víctima del\r\nmaltrato\r\n3- No\r\n21- Riesgo no evaluado',
  `ssp_cam023_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam024_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam025_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si el diagnóstico es Ansiedad\r\n2- Si el diagnóstico es\r\nDepresión\r\n3- Si el diagnóstico es\r\nesquizofrenia\r\n4- Si el diagnóstico es Déficit de\r\natención por Hiperactividad\r\n5- Si el diagnóstico es consumo\r\nSustancias ',
  `ssp_cam026_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam027_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam028_ms45` varchar(2) DEFAULT NULL COMMENT '1- Si\r\n2- No\r\n21- Riesgo no evaluado',
  `ssp_cam029_ms45` date DEFAULT NULL COMMENT 'Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01',
  `ssp_cam030_ms45` float(4,1) DEFAULT NULL COMMENT 'Peso en Kilogramos Se registra el dato obtenido de la medición. Si no se toma registrar 999',
  `ssp_cam031_ms45` date DEFAULT NULL COMMENT 'Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01',
  `ssp_cam032_ms45` int(4) DEFAULT NULL COMMENT 'Se registra el dato obtenido de la medición. Si no se toma registrar 999',
  `ssp_cam033_ms45` date DEFAULT NULL COMMENT 'Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam034_ms45` int(3) DEFAULT NULL COMMENT 'Se registra el dato de la edad gestacional en semanas. Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam035_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por\r\nNegación del ',
  `ssp_cam036_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por\r\nNegación del ',
  `ssp_cam037_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No ',
  `ssp_cam038_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis\r\n4- Cuatro Dosis\r\n5- Cinco Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por ',
  `ssp_cam039_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n4- Cuatro Dosis\r\n5- Cinco Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra ',
  `ssp_cam040_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por',
  `ssp_cam041_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se ',
  `ssp_cam042_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis Anual\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- ',
  `ssp_cam043_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por\r\nNegación del ',
  `ssp_cam044_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por\r\nNegación del',
  `ssp_cam045_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No se administra por',
  `ssp_cam046_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por una\r\nCondición de Salud\r\n18- No ',
  `ssp_cam047_ms45` varchar(2) DEFAULT NULL COMMENT 'Registre el dato del último\r\nnúmero de dosis aplicada así:\r\n0- No aplica\r\n1- Una Dosis\r\n2- Dos Dosis\r\n3- Tres Dosis\r\n4- Cuatro Dosis\r\n5- Cinco Dosis\r\n16- No se administra por una\r\nTradición\r\n17- No se administra por ',
  `ssp_cam048_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si – 1ra vez en el año\r\n2- Si – 2da vez en el año\r\n16- No se realiza por una\r\nTradición\r\n17- No se realiza por una\r\nCondición de Salud\r\n18- No se realiza por Negación\r\ndel usuario\r\n19- No se realiza por',
  `ssp_cam049_ms45` date DEFAULT NULL COMMENT 'Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam050_ms45` date DEFAULT NULL COMMENT 'Fecha salida de la atencion del parto o cesarea AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam051_ms45` date DEFAULT NULL COMMENT 'Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam052_ms45` date DEFAULT NULL COMMENT 'Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam053_ms45` date DEFAULT NULL COMMENT 'Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam054_ms45` varchar(2) DEFAULT NULL COMMENT 'Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera ETC',
  `ssp_cam055_ms45` date DEFAULT NULL COMMENT 'Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01 ETC',
  `ssp_cam056_ms45` date DEFAULT NULL COMMENT 'Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam057_ms45` int(3) DEFAULT NULL COMMENT 'Control Prenatal Registre el número de controles que ha tenido en el último período de reporte durante la gestación actual, Si no tiene el dato registrar 999 Si no aplica registrar 998',
  `ssp_cam058_ms45` date DEFAULT NULL COMMENT 'ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01 ETC',
  `ssp_cam059_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si se suministra\r\n16- No se suministra por una\r\nTradición\r\n17- No se suministra por una\r\nCondición de Salud\r\n18- No se suministra por\r\nNegación de la usuaria\r\n20- No se suministra por otras\r\nrazones',
  `ssp_cam060_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si se suministra\r\n16- No se suministra por una\r\nTradición\r\n17- No se suministra por una\r\nCondición de Salud\r\n18- No se suministra por\r\nNegación de la usuaria\r\n20- No se suministra por otras\r\nrazones',
  `ssp_cam061_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si se suministra\r\n16- No se suministra por una\r\nTradición\r\n17- No se suministra por una\r\nCondición de Salud\r\n18- No se suministra por\r\nNegación de la usuaria\r\n20- No se suministra por otras\r\nrazones',
  `ssp_cam062_ms45` date DEFAULT NULL COMMENT 'AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam063_ms45` date DEFAULT NULL COMMENT 'Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam064_ms45` date DEFAULT NULL COMMENT 'Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01 ETC',
  `ssp_cam065_ms45` date DEFAULT NULL COMMENT 'Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam066_ms45` date DEFAULT NULL COMMENT 'Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam067_ms45` date DEFAULT NULL COMMENT 'Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam068_ms45` date DEFAULT NULL COMMENT 'Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC',
  `ssp_cam069_ms45` date DEFAULT NULL COMMENT 'Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam070_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si se suministra\r\n16- No se suministra por una\r\nTradición\r\n17- No se suministra por una\r\nCondición de Salud\r\n18- No se suministra por\r\nNegación de la usuario\r\n20- No se suministra por otras\r\nrazones\r\n21- Registro no Evaluado',
  `ssp_cam071_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si se suministra\r\n16- No se suministra por una\r\nTradición\r\n17- No se suministra por una\r\nCondición de Salud\r\n18- No se suministra por\r\nNegación de la usuario\r\n20- No se suministra por otras\r\nrazones\r\n21- Registro no Evaluado',
  `ssp_cam072_ms45` date DEFAULT NULL COMMENT 'Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam073_ms45` date DEFAULT NULL COMMENT 'Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam074_ms45` int(3) DEFAULT NULL COMMENT 'Preservativos entregados a pacientes con ITS Registre el número de Preservativos entregados durante el período de reporte. Si no tiene el dato registrar 999 Si no aplica registrar 998 ETC',
  `ssp_cam075_ms45` date DEFAULT NULL COMMENT 'Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam076_ms45` date DEFAULT NULL COMMENT 'Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam077_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- En proceso de atención.\r\n2- Si recibió atención por equipo\r\ninterdisciplinario completo.\r\n16- No recibió atención por\r\ntener una tradición que se lo\r\nimpide\r\n17- No recibió atención por una\r\ncondición de salud',
  `ssp_cam078_ms45` date DEFAULT NULL COMMENT 'Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam079_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Negativo\r\n2- Positivo\r\n22- Sin dato',
  `ssp_cam080_ms45` date DEFAULT NULL COMMENT 'Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam081_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- No Reactiva\r\n2- Reactiva\r\n22- Sin dato',
  `ssp_cam082_ms45` date DEFAULT NULL COMMENT 'Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam083_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Negativo\r\n2- Positivo\r\n22- Sin dato',
  `ssp_cam084_ms45` date DEFAULT NULL COMMENT 'Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam085_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Normal\r\n2- Anormal\r\n22- Sin dato',
  `ssp_cam086_ms45` varchar(2) DEFAULT NULL COMMENT 'Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam087_ms45` date DEFAULT NULL COMMENT 'Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam088_ms45` varchar(3) DEFAULT NULL COMMENT 'Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US (células escamosas atípicas de significado indeterminado) 2- ASC-H (células escamosas atípicas, que no puede descartar alto grado) 3- Lesión intraepitelial escamosa de bajo grado ETC',
  `ssp_cam089_ms45` varchar(3) DEFAULT NULL COMMENT 'Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam090_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Citologia Cervicouterina Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam091_ms45` date DEFAULT NULL COMMENT 'Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam092_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Colposcopia Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam093_ms45` date DEFAULT NULL COMMENT 'Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam094_ms45` varchar(3) DEFAULT NULL COMMENT 'Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1- Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto Grado: NIC II - NIC III ETC',
  `ssp_cam095_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam096_ms45` date DEFAULT NULL COMMENT 'Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam097_ms45` varchar(3) DEFAULT NULL COMMENT 'Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico o Mamograma previo para evaluación 1- Negativo 2- Hallazgos Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa ETC',
  `ssp_cam098_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam099_ms45` date DEFAULT NULL COMMENT 'Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam100_ms45` date DEFAULT NULL COMMENT 'Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01',
  `ssp_cam101_ms45` varchar(3) DEFAULT NULL COMMENT 'Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada) 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam102_ms45` varchar(12) DEFAULT NULL COMMENT 'Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF Tabla REPS (Registro Especial de Prestadores de Servicios de Salud). Si no tiene el dato registrar 99 Si no aplica registrar 98',
  `ssp_cam103_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam104_ms45` float(4,1) DEFAULT NULL COMMENT 'Hemoglobina Registre el dato reportado por el laboratorio. Si no aplica registre 0',
  `ssp_cam105_ms45` date DEFAULT NULL COMMENT 'Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01',
  `ssp_cam106_ms45` date DEFAULT NULL COMMENT 'Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam107_ms45` float(4,1) DEFAULT NULL COMMENT 'Creatinina Registre el dato reportado por el laboratorio. Si no tiene el dato registrar 999 Si no aplica registrar 0',
  `ssp_cam108_ms45` date DEFAULT NULL COMMENT 'Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam109_ms45` float(4,1) DEFAULT NULL COMMENT 'Hemoglobina Glicosilada Registre el dato reportado por el laboratorio Si no tiene el dato registrar 999 Si no aplica registrar 0',
  `ssp_cam110_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam111_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam112_ms45` date DEFAULT NULL COMMENT 'Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 ETC',
  `ssp_cam113_ms45` varchar(2) DEFAULT NULL COMMENT '1- Negativa\r\n2- Positiva\r\n3- En proceso\r\n4- No\r\n22- Sin dato',
  `ssp_cam114_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si recibe tratamiento pero\r\naún no ha terminado\r\n2- Si recibió tratamiento y ya lo\r\nterminó\r\n16- No recibió tratamiento por\r\ntener una tradición que se lo\r\nimpide\r\n17- No recibió tratamiento por',
  `ssp_cam115_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si recibe tratamiento pero\r\naún no ha terminado\r\n2- Si recibió tratamiento y ya lo\r\nterminó\r\n16- No recibió tratamiento por\r\ntener una tradición que se lo\r\nimpide\r\n17- No recibió tratamiento por',
  `ssp_cam116_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si recibe tratamiento pero\r\naún no ha terminado\r\n2- Si recibió tratamiento y ya lo\r\nterminó\r\n16- No recibió tratamiento por\r\ntener una tradición que se lo\r\nimpide\r\n17- No recibió tratamiento ',
  `ssp_cam117_ms45` varchar(2) DEFAULT NULL COMMENT '0- No aplica\r\n1- Si recibe tratamiento pero\r\naún no ha terminado\r\n2- Si recibió tratamiento y ya lo\r\nterminó\r\n16- No recibió tratamiento por\r\ntener una tradición que se lo\r\nimpide\r\n17- No recibió tratamiento ',
  `ssp_cam118_ms45` date DEFAULT NULL COMMENT 'Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01 Si no se realiza por una Condición de Salud registrar 1810-01-01',
  PRIMARY KEY (`ssp_idesec_spvd`),
  KEY `spvd02` (`ssp_desval_spvd`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

#
# Structure for the `spvaloredefmaes` table : 
#

DROP TABLE IF EXISTS `spvaloredefmaes`;

CREATE TABLE `spvaloredefmaes` (
  `ssp_secreg_spdf` varchar(10) NOT NULL DEFAULT '' COMMENT 'Secuencial registro maestro valores por defecto (generado por el sistema)',
  `ssp_despro_spdf` varchar(150) DEFAULT NULL COMMENT 'Descripcion textual del registro maestro valores por defecto',
  `sia_codeps_teps` varchar(6) DEFAULT NULL COMMENT 'Código de Eps o Asegurador que esta asociada al grupo de valores por defecto para generar registros 4505',
  `ssp_conreg_spdf` int(5) DEFAULT NULL COMMENT 'Contador para generar el secuencial unico de registros en detalle (gestion interna)',
  `ssp_estreg_spdf` varchar(1) DEFAULT NULL COMMENT 'Estado del registro 1=activo 2=Inactivo',
  PRIMARY KEY (`ssp_secreg_spdf`),
  KEY `spdf02` (`ssp_despro_spdf`),
  KEY `spdf03` (`sia_codeps_teps`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysaccionperfil` table : 
#

DROP TABLE IF EXISTS `sysaccionperfil`;

CREATE TABLE `sysaccionperfil` (
  `sys_codape_aper` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo unico generado por el sistema',
  `sys_codper_perf` varchar(5) DEFAULT NULL COMMENT 'Codigo del perfil asociado con la accion',
  `sys_codmod_modu` varchar(5) DEFAULT NULL COMMENT 'Codigo unico del Modulo al cual se asocia el componente asignado y accion del perfil',
  `sys_codcom_comp` varchar(10) DEFAULT NULL COMMENT 'Codigo Unico del componente (Formulario, opcion reporte y otros)  asociado a la accion ejm: COM0015',
  `sys_accper_aper` varchar(50) DEFAULT NULL COMMENT 'Llave verificacion de la accion para el perfil en un componente,  es la concatenacion del codigo del componente el objeto que recibe el enfoque y la accion que este objeto ejecuta   SYS_CODCOM_COMP+IDOBJETO+ACCION',
  `sys_estacp_aper` varchar(1) DEFAULT NULL COMMENT 'Estado de la Opcion  1= Activa 2= Inactiva',
  PRIMARY KEY (`sys_codape_aper`),
  KEY `aper02` (`sys_codper_perf`),
  KEY `aper03` (`sys_codmod_modu`),
  KEY `aper04` (`sys_codcom_comp`),
  KEY `aper05` (`sys_accper_aper`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysadmgrupomens` table : 
#

DROP TABLE IF EXISTS `sysadmgrupomens`;

CREATE TABLE `sysadmgrupomens` (
  `sys_codmsg_symg` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código único grupos de mensajes',
  `sys_desmsg_symg` varchar(80) DEFAULT NULL COMMENT 'Descripción grupos de mensajes',
  `sys_nrohor_symg` int(2) DEFAULT NULL COMMENT 'Numero de horas maxima vigencia de un mensaje de alarma para el grupo',
  PRIMARY KEY (`sys_codmsg_symg`),
  KEY `sytmg02` (`sys_desmsg_symg`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysadmnotigrupo` table : 
#

DROP TABLE IF EXISTS `sysadmnotigrupo`;

CREATE TABLE `sysadmnotigrupo` (
  `sys_codreg_syng` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código único registro',
  `sys_codper_perf` varchar(5) DEFAULT NULL COMMENT 'Código perfil de usuarios que reciben  el mensaje',
  `sys_gruvis_syvg` varchar(10) DEFAULT NULL COMMENT 'Grupo vista notificaciones para un formulario ejemplo: FCM-FACT = Vista notificaciones en vista facturación',
  `sys_titulo_syng` varchar(80) DEFAULT NULL COMMENT 'Titulo para el boton en vista notificaciones',
  `sys_codmsg_symg` varchar(10) DEFAULT NULL COMMENT 'Grupo o modulos que recibe:  MSG = Mensajes general SYS: = Grupos mensajes de sistema ADM:= Mensajes modulo admisión',
  `sys_codtip_sytm` varchar(20) DEFAULT NULL COMMENT 'Código único tipos de mensajes que desencadena un proceso',
  `sys_estreg_syng` varchar(1) DEFAULT NULL COMMENT 'Estado del registro',
  PRIMARY KEY (`sys_codreg_syng`),
  KEY `syng02` (`sys_codmsg_symg`),
  KEY `syng03` (`sys_codtip_sytm`),
  KEY `syng01` (`sys_gruvis_syvg`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysadmsmensajes` table : 
#

DROP TABLE IF EXISTS `sysadmsmensajes`;

CREATE TABLE `sysadmsmensajes` (
  `sys_codsec_syam` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código único notificación generada por el sistema',
  `sys_llavis_syam` int(12) DEFAULT NULL COMMENT 'llave numerica para orden vista de notificaciones y filtro de nitficaciones  llave: (Año+Mes+Dia+HoraMilitar+Minutos)',
  `sys_parent_syam` varchar(10) DEFAULT NULL COMMENT 'Código único notificación mensaje padre desde el cual se genera una copia para otros usuarios',
  `sys_desmsj_syam` varchar(80) DEFAULT NULL COMMENT 'Descripción de la notificación enviada según el evento ocurrido que debe ser notificado',
  `sys_notmsj_syam` text COMMENT 'Nota adicional del mensaje (en tamaño largo)',
  `sys_regeve_sytm` text COMMENT 'Código del registro de evento que desencadena la notificación, pude ser: Código registro admisión, Código registro historia clínica, Id solicitud descuento en facturación y mas',
  `sys_tipmsj_syam` varchar(1) DEFAULT NULL COMMENT 'Tipo mensaje enviado: 1= Mensaje Publico ( no genera notificación de recibido) 2= Mensaje publico masivo con notificación de recibido  (a todos los usuarios, activos , grupos de usuarios y otros) 3= Mensaje Privado (solo a un usuario en particular)',
  `sys_coduse_usux` varchar(5) DEFAULT NULL COMMENT 'Código único del usuario que genera y envía el mensaje',
  `sys_codusu_usux` varchar(5) DEFAULT NULL COMMENT 'Código único del usuario que recibe el mensaje (para los mensajes públicos el usuario es un id general único)',
  `sys_codtip_sytm` varchar(20) DEFAULT NULL COMMENT 'Código único tipos de mensajes que desencadena un proceso',
  `sys_codmsg_symg` varchar(10) DEFAULT NULL COMMENT 'Código único grupos de mensajes  ejm: MSG = Mensajes general SYS: = Grupos mensajes de sistema FCM =Facturacion',
  `sys_codper_perf` varchar(5) DEFAULT NULL COMMENT 'Código perfil de usuarios que reciben  el mensaje',
  `sys_sisfec_syam` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando se genera registro del evento',
  `sys_sishor_syam` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema al generar registro de evento en formato militar  (HH) ejm: 16',
  `sys_vinfec_syam` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando única la vigencia del mensaje (cuando no aplica vigencia, se asume fecha generación mensaje en sistema)',
  `sys_vinhor_syam` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema cuando inicia vigencia el evento del mensaje en formato militar  (HH) ejm: 16',
  `sys_vfnfec_syam` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando finalización  la vigencia del mensaje (cuando no aplica vigencia debe estar vacía)',
  `sys_vfnhor_syam` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema cuando finaliza vigencia el evento del mensaje en formato militar  (HH) ejm: 16',
  `sys_vfrfec_syam` date DEFAULT NULL COMMENT 'Fecha  del sistema cuando el destinatario marco el mensaje como visto',
  `sys_vfrhor_syam` decimal(5,2) DEFAULT NULL COMMENT 'Hora de del sistema cuando el destinatario marco el mensaje como visto formato militar  (HH) ejm: 16',
  `sys_msjvis_syam` varchar(1) DEFAULT NULL COMMENT 'Marca para saber si el mensaje fue revisado por el usuario destino: 1= Mensaje visto por el destinatario 2= Mensaje no visto aun',
  PRIMARY KEY (`sys_codsec_syam`),
  KEY `syam02` (`sys_parent_syam`),
  KEY `syam03` (`sys_desmsj_syam`),
  KEY `syam04` (`sys_codusu_usux`),
  KEY `syam05` (`sys_codtip_sytm`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysadmstipomens` table : 
#

DROP TABLE IF EXISTS `sysadmstipomens`;

CREATE TABLE `sysadmstipomens` (
  `sys_codtip_sytm` varchar(20) NOT NULL COMMENT 'Código único tipos de mensajes que desencadena un proceso',
  `sys_desmsj_sytm` varchar(80) DEFAULT NULL COMMENT 'Descripción del tipo notificación enviada según el evento ocurrido que debe ser notificado',
  `sys_codmod_modu` varchar(5) DEFAULT NULL COMMENT 'Código único del Módulo al cual se asocian los mensajes emitidos',
  `sys_tipmsj_syam` varchar(1) DEFAULT NULL COMMENT 'Tipo mensaje enviado: 1= Mensaje Publico ( no genera notificación de recibido) 2= Mensaje publico masivo con notificación de recibido  (a todos los usuarios, activos , grupos de usuarios y otros) 3= Mensaje Privado (solo a un usuario en particular)',
  `sys_tipvig_sytm` varchar(1) DEFAULT NULL COMMENT 'Tipo vigencia del mensaje: 1= Permanente 2 = Caduca según tiempo asignado',
  `sys_sumale_sytm` varchar(1) DEFAULT NULL COMMENT 'El mensaje genera sumatoria alerta  visual: 1= SI  2 = NO',
  `sys_tipale_sytm` varchar(1) DEFAULT NULL COMMENT 'Tipo despliegue del mensaje  visual: 1= Vista en Historial servicio de mensajería   2 = Vista en ventana popup  3= Mensaje critico del sistema en ventana popup',
  `sys_niveli_sytm` varchar(1) DEFAULT NULL COMMENT 'Nivel de importancia del mensaje: 1= Baja 2= Media 3= Alta',
  `sys_tiemed_sytm` varchar(1) DEFAULT NULL COMMENT 'Medida tiempo  vigencia del mensaje  : 1= Días  2 = Horas  3= No Aplica',
  `sys_tievig_sytm` int(6) DEFAULT NULL COMMENT 'Unidades de tiempo para vigencia del mensaje (cuando aplique)',
  `grc_iderec_grcm` varchar(50) DEFAULT NULL COMMENT 'Código único del recurso de imagen que representa el evento (viene de galería de recursos)',
  `sys_estreg_sytm` varchar(1) DEFAULT NULL COMMENT 'Estado del  registro  1= Activo 2= Inactivo',
  PRIMARY KEY (`sys_codtip_sytm`),
  KEY `sytm02` (`sys_desmsj_sytm`),
  KEY `sytm03` (`sys_codmod_modu`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

#
# Structure for the `syscompmodulos` table : 
#

DROP TABLE IF EXISTS `syscompmodulos`;

CREATE TABLE `syscompmodulos` (
  `sys_codcom_comd` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo Unico del Registro generado por el sistema',
  `sys_codmod_modu` varchar(5) DEFAULT NULL COMMENT 'Codigo unico del Modulo al cual se asocia el componente',
  `sys_codcom_comp` varchar(10) DEFAULT NULL COMMENT 'Codigo Unico del componente (Formulario, opcion reporte y otros)  asociado al modulo ejm: COM0015',
  `sys_prmetr_comp` varchar(80) DEFAULT NULL COMMENT 'Expresion de texto que se agregan como parametros en los casos que sean requeridos',
  `sys_ordvis_comd` int(2) DEFAULT NULL COMMENT 'Orden para mostrar en la vista del menu de sistema',
  `sys_estcom_comd` varchar(1) DEFAULT NULL COMMENT 'Estado del componente dentro del modulo:  1= Activo 2= Inactivo',
  PRIMARY KEY (`sys_codcom_comd`),
  KEY `comd02` (`sys_codmod_modu`),
  KEY `comd03` (`sys_codcom_comp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `syscomponentacc` table : 
#

DROP TABLE IF EXISTS `syscomponentacc`;

CREATE TABLE `syscomponentacc` (
  `sys_codreg_acco` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo unico del registro para generado por el sistema',
  `sys_codacc_acco` varchar(50) DEFAULT NULL COMMENT 'Codigo unico del registro para la tabla, es la concatenacion de SYS_CODCOM_COMP+IDOBJETO+ACCION,se utiliza como llave de verificacion de la accion para el componente',
  `sys_codcom_comp` varchar(10) DEFAULT NULL COMMENT 'Codigo Unico del componente (Formulario, opcion reporte y otros),  es el ID unico del Formulario o la opcion  ejm: COM0015, es generado por el sistema',
  `sys_desacc_acco` varchar(50) DEFAULT NULL COMMENT 'Descripcion textual para mostrar o titulo ejemplo: Adicionar un registro, Eliminar, Ejecutar Proceso y otras',
  `sys_tipacc_tacc` varchar(10) DEFAULT NULL COMMENT 'Tipo accion según eventos que se puden realizar en un componente o formulario: ADD=Adicionar EDT=Modificar DEL=Eliminar y mas',
  `sys_estacc_acco` varchar(1) DEFAULT NULL COMMENT 'Estado de accion dentro del componente: 1= Activa 2= Inactiva',
  PRIMARY KEY (`sys_codreg_acco`),
  KEY `acco02` (`sys_codacc_acco`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `syscomponentes` table : 
#

DROP TABLE IF EXISTS `syscomponentes`;

CREATE TABLE `syscomponentes` (
  `sys_codcom_comp` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo Unico del componente (Formulario, opcion reporte y otros),  es el ID unico del Formulario o la opcion  ejm: COM0015, es generado por el sistema',
  `sys_codmod_modu` varchar(5) DEFAULT NULL COMMENT 'Codigo unico del Modulo nativo al cual se asocia el componente (en el cual esta desarrollado)',
  `sys_titcom_comp` varchar(60) DEFAULT NULL COMMENT 'Titulo de la opcion, este texto se mostrara en las opciones del menu del sistema',
  `sys_descom_comp` varchar(90) DEFAULT NULL COMMENT 'Descripcion textual para mostrar como texto de ayuda',
  `sys_nomcom_comp` varchar(50) DEFAULT NULL COMMENT 'Nombre fisico del componente Formulario, Funcion y otros EJ: SIS_M01_PERFIL, fcrSISgencodigo()',
  `sys_nomcla_comp` varchar(30) DEFAULT NULL COMMENT 'Construtor de la clase principal del formulario',
  `sys_prmetr_comp` varchar(80) DEFAULT NULL COMMENT 'Expresion de texto que se agregan como parametros en los casos que sean requeridos',
  `sys_rutimg_comp` varchar(150) DEFAULT NULL COMMENT 'Ruta y Nombre de la Imagen jpg que lo representa en las vista de Menu',
  `sys_codtco_tcom` varchar(2) DEFAULT NULL COMMENT 'Codigo Tipo  Componenete: 1=Formulario, 2=Funcion 3=PRG y otros',
  `sys_contac_comp` int(5) DEFAULT NULL COMMENT 'Contador para generar el codigo unico de las acciones o eventos que se ejecutan dentro del componente',
  `sys_estcom_comp` varchar(1) DEFAULT NULL COMMENT 'Estado del componente para ser mostrado en una Opcion del sistema: 1= Activo 2= Inactivo',
  PRIMARY KEY (`sys_codcom_comp`),
  KEY `comp02` (`sys_titcom_comp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `syscomponperfil` table : 
#

DROP TABLE IF EXISTS `syscomponperfil`;

CREATE TABLE `syscomponperfil` (
  `sys_codreg_cper` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo unico del rgistro generado por el sistema',
  `sys_codper_perf` varchar(5) DEFAULT NULL COMMENT 'Codigo del perfil asociado con componente',
  `sys_codcom_comd` varchar(10) DEFAULT NULL COMMENT 'Codigo Unico del componente en asignacion en modulos (codigo de asignacion)',
  `sys_codmod_modu` varchar(5) DEFAULT NULL COMMENT 'Codigo unico del Modulo al cual se asocia el componente asignado al perfil',
  `sys_llavco_cper` varchar(20) DEFAULT NULL COMMENT 'Llave de verificacion  es el Codigo Modulo + Codigo unico del Componente (SYS_CODMOD_MODU+SYS_CODCOM_COMP) ejm:  FCMCOM0015 donde FCM y COM0015 son modulo y componente',
  `sys_codcom_comp` varchar(10) DEFAULT NULL COMMENT 'Codigo Unico del componente (Formulario, opcion reporte y otros)  asociado al modulo ejm: COM0015',
  `sys_prmetr_comp` varchar(80) DEFAULT NULL COMMENT 'Expresion de texto que se agregan como parametros en los casos que sean requeridos',
  `sys_estccp_cper` varchar(1) DEFAULT NULL COMMENT 'Estado del Componente  dentro del perfil  1= Activo 2= Inactivo',
  PRIMARY KEY (`sys_codreg_cper`),
  KEY `cper02` (`sys_codper_perf`),
  KEY `cper03` (`sys_codmod_modu`),
  KEY `cper04` (`sys_codcom_comp`),
  KEY `cper05` (`sys_llavco_cper`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysconexionbdat` table : 
#

DROP TABLE IF EXISTS `sysconexionbdat`;

CREATE TABLE `sysconexionbdat` (
  `sys_codcon_cone` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo generado para cada Tipo de registro de configuracion del sistema',
  `sys_descon_cone` varchar(50) DEFAULT NULL COMMENT 'Descripcion de la conexión ejm: Conexión a la base de datos local  MySQL',
  `sys_tipmot_cone` varchar(10) DEFAULT NULL COMMENT 'Tipo de Motor: FOXPRO, MYSQL,FIREBIRD,ORACLE,SQL, WEB',
  `sys_ubbdat_cone` varchar(10) DEFAULT NULL COMMENT 'Ubicación de la base de datos : LOCAL o WEB',
  `sys_dirips_cone` varchar(150) DEFAULT NULL COMMENT 'Ruta o Direccion Ip donde esta ubicada la base de datos en el servidor, Ejemplo: localhost:C:\rutadbfsdatos , http://www.midwssoft.com/midws/midws.php',
  `sys_nonbdt_cone` varchar(20) DEFAULT NULL COMMENT 'Nombre de la Base de datos',
  `sys_nomodb_cone` varchar(50) DEFAULT NULL COMMENT 'Nombre del ODBC ej: midws.php, MySQL ODBC 3.51 Driver,  (se utiliza para realizar la conexión)',
  `sys_nomusu_cone` varchar(30) DEFAULT NULL COMMENT 'Nombre del  usuario para conexión a la base de datos',
  `sys_clausu_cone` varchar(30) DEFAULT NULL COMMENT 'Clave del  usuario para conexión a la base de datos',
  `sys_codest_cone` varchar(2) DEFAULT NULL COMMENT 'Codigo de Estado del Registro',
  PRIMARY KEY (`sys_codcon_cone`),
  KEY `cone02` (`sys_descon_cone`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysgeneradorcod` table : 
#

DROP TABLE IF EXISTS `sysgeneradorcod`;

CREATE TABLE `sysgeneradorcod` (
  `sys_codsec_gcod` varchar(30) NOT NULL DEFAULT '' COMMENT 'Llave unica para localizar el Secuenial',
  `sys_codmod_modu` varchar(5) DEFAULT NULL COMMENT 'Codigo del Modulo al cual peretenece el secuencial esto para mostrarlos como grupos',
  `sys_dessec_gcod` varchar(90) DEFAULT NULL COMMENT 'Descripcion del Secuencial',
  `sys_ultsec_gcod` int(15) DEFAULT NULL COMMENT 'Ultimo secuencial generado',
  `sys_inisec_gcod` int(15) DEFAULT NULL COMMENT 'Numero desde el cual inicia el conteo',
  `sys_finsec_gcod` int(15) DEFAULT NULL COMMENT 'Numero en el cual Finaliza el conteo',
  `sys_maxsec_gcod` int(2) DEFAULT NULL COMMENT 'Inidica el tamaño maximo en caracteres para el secuencial generado',
  `sys_alrsec_gcod` int(5) DEFAULT NULL COMMENT 'Indica cuantos numeros secuenciales antes se emite mensaje de alarma de que se cumpla el limite',
  `sys_relcer_gcod` varchar(1) DEFAULT NULL COMMENT 'Inidica si se rellena el nuevo secuencial con ceros a la izquierda 1 =Si 2=No',
  `sys_prefij_gcod` varchar(4) DEFAULT NULL COMMENT 'Texto o Identificador Inicial del nuevo codigo generado',
  `sys_sufijo_gcod` varchar(4) DEFAULT NULL COMMENT 'Texto o Identificador final del nuevo codigo generado',
  `sys_incfec_gcod` varchar(1) DEFAULT NULL COMMENT 'Inidica si se incluye datos de fecha en el nuevo secuncial 1=Incluir en prefijo  2=Incluir sufijo 3 =No incluir',
  `sys_locfec_gcod` varchar(1) DEFAULT NULL COMMENT 'Localizacion del dato fecha dentro del nuevo secencial  1= Antes 2=Despues',
  `sys_forfec_gcod` varchar(1) DEFAULT NULL COMMENT 'Formato fecha 1= DD/MM/AA 2=MM/DD/AA 3= AA/MM/DD 4=AA/DD/MM',
  `sys_incdia_gcod` varchar(1) DEFAULT NULL COMMENT 'Incluir el dia para para la fecha 1=Si 2=No',
  `sys_incmes_gcod` varchar(1) DEFAULT NULL COMMENT 'Incluir el mes para para la fecha 1=Si 2=No',
  `sys_incano_gcod` varchar(1) DEFAULT NULL COMMENT 'Incluir el año para para la fecha 1=Si 2=No',
  `sys_nivacc_gcod` varchar(1) DEFAULT NULL COMMENT 'Nivel Prioridad de acceso a vista del registro de secuencial, para super usuarios y usuarios de gestion: 1=Solo Super Usuarios 2=Adminstradores',
  PRIMARY KEY (`sys_codsec_gcod`),
  KEY `gcod02` (`sys_codmod_modu`),
  KEY `gcod03` (`sys_dessec_gcod`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysgrupomodusis` table : 
#

DROP TABLE IF EXISTS `sysgrupomodusis`;

CREATE TABLE `sysgrupomodusis` (
  `sys_codgru_grmo` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico del grupo de Modulos del sistema para agrupar Tiles',
  `sys_desgru_grmo` varchar(50) DEFAULT NULL COMMENT 'Nombre del Grupo de modulos (para Titulo de grupos en browser)',
  `sys_nivmod_grmo` varchar(1) DEFAULT NULL COMMENT 'Codigo nivel de modulo al que se relaciona el grupo: 1=Nivel1(menu principal) 2=Submodulos(sub menu)',
  PRIMARY KEY (`sys_codgru_grmo`),
  KEY `grmo01` (`sys_desgru_grmo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

#
# Structure for the `sysmoduloperfil` table : 
#

DROP TABLE IF EXISTS `sysmoduloperfil`;

CREATE TABLE `sysmoduloperfil` (
  `sys_codreg_sycm` varchar(10) NOT NULL DEFAULT '' COMMENT 'Código único del registro generado por el sistema',
  `sys_codper_perf` varchar(5) DEFAULT NULL COMMENT 'Código del perfil asociado con componente',
  `sys_codmod_modu` varchar(5) DEFAULT NULL COMMENT 'Código único del Modulo asignado al perfil',
  `sys_condet_sycm` int(5) DEFAULT NULL COMMENT 'Contador para generar los registros detalles',
  `sys_estmod_sycm` varchar(1) DEFAULT NULL COMMENT 'Estado del Componente  dentro del perfil  1= Activo 2= Inactivo',
  PRIMARY KEY (`sys_codreg_sycm`),
  KEY `sycm02` (`sys_codper_perf`),
  KEY `sycm03` (`sys_codmod_modu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysmodulosistem` table : 
#

DROP TABLE IF EXISTS `sysmodulosistem`;

CREATE TABLE `sysmodulosistem` (
  `sys_codmod_modu` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico del Modulo digitado por el usuario',
  `sys_nommod_modu` varchar(50) DEFAULT NULL COMMENT 'Nombre del Modulo, que se mostrara como titulo en las opciones del sistema',
  `sys_desmod_modu` varchar(90) DEFAULT NULL COMMENT 'Descripcion textual para mostrar como texto de ayuda en ventanas contextuales',
  `sys_rutimg_modu` varchar(150) DEFAULT NULL COMMENT 'Ruta y Nombre de la Imagen jpg que lo representa en las vista del Menu',
  `sys_fonimg_modu` varchar(150) DEFAULT NULL COMMENT 'Ruta y Nombre de la imagen del fondo (tiles)',
  `sys_ordvis_modu` int(3) DEFAULT NULL COMMENT 'Orden Vista dentro del menu, según el numero colocado aquí',
  `sys_codtmo_tmod` varchar(1) DEFAULT NULL COMMENT 'Clasificacion de los modulos:1=Adminstrativos 2=Asistenciales 3=Configuracion del Sistema',
  `sys_codgru_grmo` varchar(5) DEFAULT NULL COMMENT 'Codigo unico del grupo de Modulos digitado por el usuario',
  `sys_codcom_comp` varchar(10) DEFAULT NULL COMMENT 'Codigo componente (Formulario, opcion reporte y otros), para acceder al elemento desde menu principal, es decir no hay submenu (NA - por defecto)',
  `sys_contco_modu` int(4) DEFAULT NULL COMMENT 'Contador para generar los codigos de los compomentes del modulo',
  `sys_estmod_modu` varchar(1) DEFAULT NULL COMMENT 'Estado del Modulo 1= Activo 2= Inactivo',
  PRIMARY KEY (`sys_codmod_modu`),
  KEY `modu02` (`sys_nommod_modu`),
  KEY `modu03` (`sys_desmod_modu`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

#
# Structure for the `sysperfiusuario` table : 
#

DROP TABLE IF EXISTS `sysperfiusuario`;

CREATE TABLE `sysperfiusuario` (
  `sys_codper_perf` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico del perfil en el sistema (generado por el sistema)',
  `sys_desper_perf` varchar(50) DEFAULT NULL COMMENT 'Descripcion del perfil textual del perfil',
  `sys_rutimg_perf` varchar(150) DEFAULT NULL COMMENT 'Ruta y Nombre de la Imagen jpg que lo representa en las vista de Menu',
  `sys_secreg_perf` int(10) DEFAULT NULL COMMENT 'Control Contador de Nuevos Registros',
  `sys_nivusu_perf` varchar(1) DEFAULT NULL COMMENT 'Nivel del usuario en el sistema: 1=Super usuario 2=Adminstrador 3=Usuario de gestion',
  `sys_estper_perf` varchar(1) DEFAULT NULL COMMENT 'Estado del Perfil: 1=Activo 2=Inactivo',
  PRIMARY KEY (`sys_codper_perf`),
  KEY `perf02` (`sys_desper_perf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `systipoaccicomp` table : 
#

DROP TABLE IF EXISTS `systipoaccicomp`;

CREATE TABLE `systipoaccicomp` (
  `sys_tipacc_tacc` varchar(10) NOT NULL DEFAULT '' COMMENT 'Tipo accion según eventos que se puden realizar en un componente o formulario: ADD=Adicionar EDT=Modificar DEL=Eliminar y mas',
  `sys_destac_tacc` varchar(30) DEFAULT NULL COMMENT 'Descripcion tipo  accion del componente o del sistema',
  `sys_rutimg_tacc` varchar(150) DEFAULT NULL COMMENT 'Ruta y Nombre de la Imagen jpg que lo representa en las vista de Menu',
  PRIMARY KEY (`sys_tipacc_tacc`),
  KEY `tacc02` (`sys_destac_tacc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `systipocomponen` table : 
#

DROP TABLE IF EXISTS `systipocomponen`;

CREATE TABLE `systipocomponen` (
  `sys_codtco_tcom` varchar(2) NOT NULL DEFAULT '' COMMENT 'Codigo Tipo  Componenete',
  `sys_destco_tcom` varchar(30) DEFAULT NULL COMMENT 'Descripcion Tipo Modulo',
  PRIMARY KEY (`sys_codtco_tcom`),
  KEY `tcom02` (`sys_destco_tcom`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysusuarios` table : 
#

DROP TABLE IF EXISTS `sysusuarios`;

CREATE TABLE `sysusuarios` (
  `sys_codusu_usux` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico del usuario genrado por el sistema: ejm US001',
  `sys_ideusu_usux` varchar(20) DEFAULT NULL COMMENT 'ID que digita el usuario  para acceso al sistema ejm: calos4, juanb, MAN34,mile25',
  `sys_nomusu_usux` varchar(50) DEFAULT NULL COMMENT 'Nombre Completo del  usuario',
  `sys_clausu_usux` varchar(50) DEFAULT NULL COMMENT 'Clave del Usuario',
  `sys_codper_perf` varchar(5) DEFAULT NULL COMMENT 'Codigo del perfil de usuario',
  `sys_imagen_usux` varchar(150) DEFAULT NULL COMMENT 'Ruta nombre y extencion del archivo de imagen que representa al usuario (cuando este vacio se representa con imagen del perfil)',
  `sys_estusu_usux` varchar(1) DEFAULT NULL COMMENT 'Estado del Usuario  1= Activo 2= Inactivo',
  PRIMARY KEY (`sys_codusu_usux`),
  KEY `usux02` (`sys_ideusu_usux`),
  KEY `usux03` (`sys_clausu_usux`),
  KEY `usux04` (`sys_nomusu_usux`),
  KEY `usux05` (`sys_codper_perf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysvarconfigma` table : 
#

DROP TABLE IF EXISTS `sysvarconfigma`;

CREATE TABLE `sysvarconfigma` (
  `sys_seggru_sycg` varchar(5) NOT NULL DEFAULT '' COMMENT 'Codigo unico del grupo generado por el sistema',
  `sys_codmod_modu` varchar(5) DEFAULT NULL COMMENT 'Código único del Modulo que componen el sistema',
  `sys_nomgru_sycg` varchar(50) DEFAULT NULL COMMENT 'Nombre del grupo variables',
  `sys_idegru_sycg` varchar(10) DEFAULT NULL COMMENT 'Nombre variable Identificador del grupo (ejemplo PRN, CONFIG…ETC)',
  `sys_desgru_sycg` varchar(170) DEFAULT NULL COMMENT 'Descripcion mas detallada del grupo',
  `sys_gruimg_sycg` varchar(60) DEFAULT NULL COMMENT 'Nombre de la imagen que representa el registro',
  `sys_ordvis_sycg` int(3) DEFAULT NULL COMMENT 'Orden visualizacion dentro del modulo configuracion ',
  `sys_estgru_sycg` varchar(1) DEFAULT NULL COMMENT 'Estado del registro grupo 1 =Activo 2=Inactivo',
  PRIMARY KEY (`sys_seggru_sycg`),
  KEY `sycg02` (`sys_codmod_modu`),
  KEY `sycg03` (`sys_nomgru_sycg`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `sysvarconfigmd` table : 
#

DROP TABLE IF EXISTS `sysvarconfigmd`;

CREATE TABLE `sysvarconfigmd` (
  `sys_secvar_sycv` varchar(10) NOT NULL DEFAULT '' COMMENT 'Codigo unico de la variable generado por el sistema',
  `sys_seggru_sycg` varchar(5) DEFAULT NULL COMMENT 'Codigo unico del grupo  proveniente de  modulos',
  `sys_codmod_modu` varchar(5) DEFAULT NULL COMMENT 'Código único del Modulo que componen el sistema',
  `sys_varkey_sycv` varchar(40) DEFAULT NULL COMMENT 'Llave Nombre de la  variable, se usa para referencia busqueda y configuracion ejemplo: FCM-PRN-FORMATO-FACT-INDIVIDUAL',
  `sys_varnom_sycv` varchar(60) DEFAULT NULL COMMENT 'Titulo o Nombre  textual de la variable',
  `sys_vardes_sycv` varchar(170) DEFAULT NULL COMMENT 'Descripcion mas detallada  de la variable y su fución',
  `sys_vartip_sycv` varchar(10) DEFAULT NULL COMMENT 'Tipo variable: según lista tipos: RA-DIAG/RA-USUA/IMAGEN/LISTA/TEXTO…',
  `sys_vardfl_sycv` text COMMENT 'Valor seleccionado o activo por defecto como parametro de la viariable',
  `sys_varval_sycv` text COMMENT 'Lista de valores permitidos XML y otros, cuando el origen es una lista los valores se separan con coma',
  `sys_varvad_sycv` text COMMENT 'Lista descripcion valores permitidos XML y otros, cuando el origen es una lista los valores se separan con coma',
  `sys_varaux_sycv` text COMMENT 'Valor auxiliar para usos varios según alguna configuracion',
  `sys_varimg_sycv` varchar(60) DEFAULT NULL COMMENT 'Nombre de la imagen que representa el registro',
  `sys_ordvis_sycv` int(3) DEFAULT NULL COMMENT 'Orden visualizacion dentro del modulo configuracion',
  `sys_varest_sycv` varchar(1) DEFAULT NULL COMMENT 'Estado del registro grupo 1 =Activo 2=Inactivo',
  PRIMARY KEY (`sys_secvar_sycv`),
  KEY `sycv02` (`sys_seggru_sycg`),
  KEY `sycv03` (`sys_codmod_modu`),
  KEY `sycv04` (`sys_varkey_sycv`),
  KEY `sycv05` (`sys_varnom_sycv`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

