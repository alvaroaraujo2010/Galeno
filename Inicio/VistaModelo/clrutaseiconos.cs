using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IWshRuntimeLibrary;
using System.Drawing;
using Datos.Modelos;
using System.Windows;

namespace Inicio.VistaModelo
{
    class clrutaseiconos
    {
        // Array de tipo Diccionario para el manejo de las rutas e iconos de los módulos y componentes para los tiles.
        public Dictionary<string, string[]> gArDicRutaseIconos = new Dictionary<string, string[]>();
        /// <summary>
        /// fcArObtenerRutaseIconos funcion que devuelve una estructura tipo Diccionario para 
        /// el manejo de las rutas e iconos de los módulos y componentes para los tiles. 
        /// </summary>
        /// <param name="tcrNivel">Nivel de acceso para modulos y componentes en el menu metro
        /// 1:nivel de Modulos, 2: componentes de un modulo</param>
        /// <returns></returns>
        public Dictionary<string, string[]> fcArObtenerRutaseIconos(String tcrCodigoModulo, String tcrImgTiles, String tcrRutaImagenes, String tcrNivel, String tcrPerfil)
        {
            if (tcrNivel == "MOD")
            {
                // el nivel 1 maneja los elementos que se mostrarán en el menu principal (modulos del sistema)
                using (DbAplicacion db = new DbAplicacion())
                {
                    // obtenemos los codigos de los módulos a los que el perfil del usuario activo tiene permiso
                    List<EFsyscomponperfil> lArModXper = (from reg in db.Syscomponperfil
                                                          join sysmodulosistem in db.Sysmodulosistem on reg.sys_codmod_modu equals sysmodulosistem.sys_codmod_modu into tmsysmodulosistem
                                                          from modu in tmsysmodulosistem.DefaultIfEmpty()
                                                          orderby modu.sys_ordvis_modu
                                                          where reg.sys_codper_perf == tcrPerfil && reg.sys_estccp_cper == "1"
                                                          select reg).ToList();

                    List<EFsysmodulosistem> lArModulos = new List<EFsysmodulosistem>();
                    // con estos codigos vamos a la tabla EFsysmodulosistem y obtenemos el nombre a ser mostrado
                    // y la imagen para el tile.
                    lArModulos = (List<EFsysmodulosistem>)fcListaModulos(lArModXper);
                    var larCodigosGrupo = lArModulos
                        .Select(x => x.sys_codgru_grmo)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Distinct()
                        .ToList();
                    var larGrupos = db.Sysgrupomodusis
                        .Where(x => larCodigosGrupo.Contains(x.sys_codgru_grmo))
                        .ToList()
                        .GroupBy(x => x.sys_codgru_grmo)
                        .ToDictionary(x => x.Key, x => x.First().sys_desgru_grmo);

                    int lnuIndice = 0;
                    foreach (var p in lArModulos)
                    {
                        string lcrTitulo;
                        if (string.IsNullOrWhiteSpace(p.sys_codgru_grmo) || !larGrupos.TryGetValue(p.sys_codgru_grmo, out lcrTitulo))
                        {
                            lcrTitulo = "Sin grupo";
                        }

                        gArDicRutaseIconos.Add(p.sys_codmod_modu.Trim(), new String[] {lnuIndice.ToString().Trim(), 
                                                p.sys_codmod_modu.Trim(), p.sys_nommod_modu.Trim(),
                                                p.sys_rutimg_modu, p.sys_fonimg_modu, "/Sistema;component/Imagenes/", 
                                                p.sys_codgru_grmo, lcrTitulo, p.sys_codcom_comp});
                        lnuIndice++;
                    }
                }
            }
            else // FRM
            {
                // el nivel 2 maneja los elementos que se mostrarán al seleccionar un modulo (componentes del módulo)
                using (DbAplicacion db = new DbAplicacion())
                {
                    // obtenemos los codigos de los componentes a los que el perfil del usuario activo tiene permiso
                    List<EFsyscompmodulos> lArComXper = (from reg in db.Syscompmodulos
                                                         where reg.sys_codmod_modu == tcrCodigoModulo
                                                         select reg).ToList();
                    List<EFsyscomponentes> lArComponentes = new List<EFsyscomponentes>();
                    // con estos codigos vamos a la tabla EFsyscomponentes y obtenemos el nombre a ser mostrado
                    // la imagen para el tile y codigo del componente.
                    lArComponentes = (List<EFsyscomponentes>)fcListaComponentes(lArComXper);
                    int lnuIndice = 0;
                    foreach (var p in lArComponentes)
                    {
                        gArDicRutaseIconos.Add(p.sys_codcom_comp.Trim(), new String[] { lnuIndice.ToString().Trim(),
                                                p.sys_codcom_comp.Trim(), p.sys_titcom_comp, p.sys_rutimg_comp, 
                                                tcrImgTiles, tcrRutaImagenes, p.sys_codcom_comp, p.sys_nomcom_comp,"NA"});
                        lnuIndice++;
                    }
                }
            }
            return gArDicRutaseIconos;
        }
        /// <summary>
        /// Devuelve lista de Modulos de un perfil
        /// </summary>
        /// <param name="tlArModXper"></param>
        /// <returns>Lista de codigos de Modulos de un perfil</returns>
        private List<EFsysmodulosistem> fcListaModulos(List<EFsyscomponperfil> tlArModXper)
        {
            using (DbAplicacion dbs = new DbAplicacion())
            {
                List<EFsysmodulosistem> lArModulos = new List<EFsysmodulosistem>();
                var larCodigosModulo = tlArModXper
                    .Select(x => x.sys_codmod_modu)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct()
                    .ToList();
                var larModulosPorCodigo = dbs.Sysmodulosistem
                    .Where(reg => larCodigosModulo.Contains(reg.sys_codmod_modu))
                    .ToList()
                    .GroupBy(x => x.sys_codmod_modu)
                    .ToDictionary(x => x.Key, x => x.First());

                foreach (var p in tlArModXper)
                {
                    EFsysmodulosistem lobModulo;
                    if (larModulosPorCodigo.TryGetValue(p.sys_codmod_modu, out lobModulo))
                    {
                        lArModulos.Add(lobModulo);
                    }
                }
                return lArModulos.ToList();
            }
        }
        /// <summary>
        /// Devuelve lista de Componentes de un perfil
        /// </summary>
        /// <param name="tlArComXper">Array de Componentes de un perfil</param>
        /// <returns>Lista de codigos de Componentes de un Perfil</returns>
        private List<EFsyscomponentes> fcListaComponentes(List<EFsyscompmodulos> tlArComXper)
        {
            using (DbAplicacion dbs = new DbAplicacion())
            {
                List<EFsyscomponentes> lArComponentes = new List<EFsyscomponentes>();
                var larCodigosComponente = tlArComXper
                    .Select(x => x.sys_codcom_comp)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct()
                    .ToList();
                var larComponentesPorCodigo = dbs.Syscomponentes
                    .Where(reg => larCodigosComponente.Contains(reg.sys_codcom_comp))
                    .ToList()
                    .GroupBy(x => x.sys_codcom_comp)
                    .ToDictionary(x => x.Key, x => x.First());

                foreach (var p in tlArComXper)
                {
                    EFsyscomponentes lobComponente;
                    if (larComponentesPorCodigo.TryGetValue(p.sys_codcom_comp, out lobComponente))
                    {
                        lArComponentes.Add(lobComponente);
                    }
                }
                return lArComponentes.ToList();
            }
        }
    }
}
