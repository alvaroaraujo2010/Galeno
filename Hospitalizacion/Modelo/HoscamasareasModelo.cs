using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;
namespace Hospitalizacion.Modelo
{
    public class HoscamasareasModelo : clBaseInpc
    {
        #region Modelo Attributos
        private static  DbAplicacion _context;
        //private string _hos_codcam_caho;
        private string _hos_nrohab_habi;
        private string _hos_descam_caho;
        private string _hos_tipcam_tcam;
        private string _hos_camaux_caho;
        private string _fcm_idesec_sips;
        private string _hos_codsec_hsec;
        private string _hos_estcam_ecam;
        private string _hos_destip_tcam;
        #endregion

        #region Modelo Propiedades
        public string Hos_codcam_caho { get; set; } // Campo llave de la tabla

        public string Hos_nrohab_habi
        {
            get { return _hos_nrohab_habi; }
            set
            {
                if (_hos_nrohab_habi == value) return;
                _hos_nrohab_habi = value;
                OnPropertyChanged("Hos_nrohab_habi");
            }
        }

        public string Hos_descam_caho
        {
            get { return _hos_descam_caho; }
            set
            {
                if (_hos_descam_caho == value) return;
                _hos_descam_caho = value;
                OnPropertyChanged("Hos_descam_caho");
            }
        }

        public string Hos_tipcam_tcam
        {
            get { return _hos_tipcam_tcam; }
            set
            {
                if (_hos_tipcam_tcam == value) return;
                _hos_tipcam_tcam = value;
                OnPropertyChanged("Hos_tipcam_tcam");
            }
        }

        public string Hos_camaux_caho
        {
            get { return _hos_camaux_caho; }
            set
            {
                if (_hos_camaux_caho == value) return;
                _hos_camaux_caho = value;
                OnPropertyChanged("Hos_camaux_caho");
            }
        }

        public string Fcm_idesec_sips
        {
            get { return _fcm_idesec_sips; }
            set
            {
                if (_fcm_idesec_sips == value) return;
                _fcm_idesec_sips = value;
                OnPropertyChanged("Hcm_idesec_sips");
            }
        }

        public string Hos_codsec_hsec
        {
            get { return _hos_codsec_hsec; }
            set
            {
                if (_hos_codsec_hsec == value) return;
                _hos_codsec_hsec = value;
                OnPropertyChanged("Hos_codsec_hsec");
            }
        }

        public string Hos_estcam_ecam
        {
            get { return _hos_estcam_ecam; }
            set
            {
                if (_hos_estcam_ecam == value) return;
                _hos_estcam_ecam = value;
                OnPropertyChanged("Hos_estcam_ecam");
            }
        }

        public string Hos_destip_tcam
        {
            get { return _hos_destip_tcam; }
            set
            {
                if (_hos_destip_tcam == value) return;
                _hos_destip_tcam = value;
                OnPropertyChanged("Hos_destip_tcam");
            }
        }

        #endregion

        #region Metodos Publicos del Modelo
        public static string flgAddRegistro(HoscamasareasModelo tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFhoscamasareas
                {
                    hos_codcam_caho = tobjModelo.Hos_codcam_caho,
                    hos_nrohab_habi = tobjModelo.Hos_nrohab_habi,
                    hos_descam_caho = tobjModelo.Hos_descam_caho,
                    hos_tipcam_tcam = tobjModelo.Hos_tipcam_tcam,
                    hos_camaux_caho = tobjModelo.Hos_camaux_caho,
                    fcm_idesec_sips = tobjModelo.Fcm_idesec_sips,
                    hos_codsec_hsec = tobjModelo.Hos_codsec_hsec,
                    hos_estcam_ecam = tobjModelo.Hos_estcam_ecam,
                };

                _context.AddToHoscamasareas(lobjRegistro);
                _context.SaveChanges();
                return lobjRegistro.hos_codcam_caho;
            }
        }

        public static void fcvActualizar(HoscamasareasModelo tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tobjModelo.Hos_codcam_caho);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hos_codcam_caho = tobjModelo.Hos_codcam_caho;
                    lobjRegistro.hos_nrohab_habi = tobjModelo.Hos_nrohab_habi;
                    lobjRegistro.hos_descam_caho = tobjModelo.Hos_descam_caho;
                    lobjRegistro.hos_tipcam_tcam = tobjModelo.Hos_tipcam_tcam;
                    lobjRegistro.hos_camaux_caho = tobjModelo.Hos_camaux_caho;
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.hos_codsec_hsec = tobjModelo.Hos_codsec_hsec;
                    lobjRegistro.hos_estcam_ecam = tobjModelo.Hos_estcam_ecam;
                    _context.SaveChanges();
                }
            }

        }

        //- Buscar Registro
        public static bool flgBuscarRegistro(string tcrCodigoRegistro)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tcrCodigoRegistro);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                }
            }
            return llgReturn;
        }

        //- Buscar Descripcion Tipo Cama 
        public static string fcrBuscarHostipocamas(string tcrCodigoRegistro)
        {
            string llgReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hostipocamas.FirstOrDefault(p => p.hos_tipcam_tcam == tcrCodigoRegistro);
                if (lobjRegistro != null)
                {
                    llgReturn = lobjRegistro.hos_destip_tcam;
                }
            }
            return llgReturn;
        }

        //-Eliminar
        public static void fcvEliminar(string tcrHos_codcam_caho)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tcrHos_codcam_caho);
                _context.DeleteObject(lobjRegistro);
                _context.SaveChanges();
            }
        }

        //-Lista de toda la Tabla
        public static List<HoscamasareasModelo> farListaArrayHoscamasareas(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    return _context.Hoscamasareas.Select(p => new HoscamasareasModelo
                    {
                        Hos_codcam_caho = p.hos_codcam_caho,
                        Hos_nrohab_habi = p.hos_nrohab_habi,
                        Hos_descam_caho = p.hos_descam_caho,
                        Hos_tipcam_tcam = p.hos_tipcam_tcam,
                        Hos_camaux_caho = p.hos_camaux_caho,
                        Fcm_idesec_sips = p.fcm_idesec_sips,
                        Hos_codsec_hsec = p.hos_codsec_hsec,
                        Hos_estcam_ecam = p.hos_estcam_ecam,
                        Hos_destip_tcam = _context.Hostipocamas.FirstOrDefault(x => x.hos_tipcam_tcam == p.hos_tipcam_tcam).hos_destip_tcam
                    }).ToList();
                }
                else 
                {
                    var lobConsulta = from caho in _context.Hoscamasareas
                                join tcam in _context.Hostipocamas on caho.hos_tipcam_tcam equals tcam.hos_tipcam_tcam into tmp
                                      where caho.hos_codcam_caho.Contains(tcrBuscar) || caho.hos_descam_caho.Contains(tcrBuscar)
                                from tmpx in tmp.DefaultIfEmpty()
                                select new HoscamasareasModelo
                                {
                                    Hos_codcam_caho = caho.hos_codcam_caho,
                                    Hos_nrohab_habi = caho.hos_nrohab_habi,
                                    Hos_descam_caho = caho.hos_descam_caho,
                                    Hos_tipcam_tcam = caho.hos_tipcam_tcam,
                                    Hos_camaux_caho = caho.hos_camaux_caho,
                                    Fcm_idesec_sips = caho.fcm_idesec_sips,
                                    Hos_codsec_hsec = caho.hos_codsec_hsec,
                                    Hos_estcam_ecam = caho.hos_estcam_ecam,
                                    Hos_destip_tcam = tmpx.hos_destip_tcam
                                };
                    return lobConsulta.ToList(); 
                }
            }
        }
        #endregion
    }
}
