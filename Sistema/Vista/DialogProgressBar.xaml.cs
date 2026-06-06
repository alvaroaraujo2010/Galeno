using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Sistema.Vista
{
  /// <summary>
  /// A simple progress dialog that invokes clients via
  /// a synchronous event which is called on a worker thread.
  /// </summary>
  public partial class DialogProgressBar : Window
  {
      private double lduBarraWidth;
      private double lduHeight;

    //-----------------------------------------------------------------
    // CAMPOS
    //-----------------------------------------------------------------
    #region Campos
    /// <summary>
    /// The background worker which handles asynchronous invocation
    /// of the worker method.
    /// </summary>
    private readonly BackgroundWorker worker;
    //-------------------
    /// <summary>
    /// The UI culture of the thread that invokes the dialog.
    /// </summary>
    private CultureInfo uiCulture;
    //-------------------
    /// <summary>
    /// Whether background processing was cancelled by the user.
    /// </summary>
    //private bool cancelled = false;
    //-------------------
    /// <summary>
    /// Provides an exception that occurred during the asynchronous
    /// operation on the worker thread. Defaults to null, which
    /// indicates that no exception occurred at all.
    /// </summary>
    private Exception error = null;
    //-------------------
    /// <summary>
    /// The result, if assigned to the <see cref="DoWorkEventArgs.Result"/>
    /// property by the worker method.
    /// </summary>
    private object result = null;
    //-------------------
    /// <summary>
    /// The 
    /// </summary>
    private DoWorkEventHandler workerCallback;
    #endregion
    //-----------------------------------------------------------------
    // PROPIEDADES
    //-----------------------------------------------------------------
    #region Propiedades
    /// <summary>
    /// Provides an exception that occurred during the asynchronous
    /// operation on the worker thread. Defaults to null, which
    /// indicates that no exception occurred at all.
    /// </summary>
    public Exception Error
    {
      get { return error; }
    }
    /// <summary>
    /// The result, if assigned to the <see cref="DoWorkEventArgs.Result"/>
    /// property by the worker method. Defaults to null.
    /// </summary>
    public object Result
    {
      get { return result; }
    }
    #endregion
    //-----------------------------------------------------------------
    // EJECUCION DEL HILO DE TRABAJO    
    //-----------------------------------------------------------------
    /// <summary>
    /// Dialogo principal
    /// </summary>
    public DialogProgressBar()
    {
        InitializeComponent();

        // iniciar el trabajo en segundo plano
        worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.WorkerSupportsCancellation = true;

        worker.DoWork += fcvDoWorkIniciarTrabajo;
        worker.ProgressChanged += fcvReportarProgressChanged;
        worker.RunWorkerCompleted += fcvCompletoRunWorkerCompleted;

        fcvResizePantalla();
        SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
    }
    #region fcvResizePantalla: Tamaños de pantalla y objetos
    //------------------------------------------------------------
    // Evento para detectar el cambio de Resolucion de Pantalla en Windows
    //------------------------------------------------------------
    /// <summary>
    /// <para>Detectar el cambio de Resolucion de Pantalla en Windows y realizar ajustes</para>
    /// </summary>
    void SystemEvents_ReajustarVistaPantalla(object sender, EventArgs e)
    {
        fcvResizePantalla();
    }
    public void fcvResizePantalla()
    {
        lduBarraWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 100;
        lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 100;
        this.Width = lduBarraWidth;
        this.Top = lduHeight >= 1000? lduHeight - 100 : lduHeight - 80;
        this.Left = 0;
    }
    #endregion
    //-----------------------------------------------------------------
    // EJECUCION DEL HILO DE TRABAJO    
    //-----------------------------------------------------------------
    #region ejecutar el hilo de trabajo
    /// <summary>
    /// Launches a worker thread which is intendet to perform
    /// work while progress is indicated.
    /// </summary>
    /// <param name="workHandler">A callback method which is
    /// being invoked on a background thread in order to perform
    /// the work to be performed.</param>
    public bool EjecutarHiloDeTrabajo(DoWorkEventHandler workHandler)
    {
      return EjecutarHiloDeTrabajo(null, workHandler);
    }
    /// <summary>
    /// <para>Lanza un subproceso de trabajo que se pretende realizar</para>
    /// <para>Trabajo mientras se indica el progreso, y muestra el cuadro de diálogo</para>
    /// <para>Modal con el fin de bloquear el subproceso de llamada.</para>
    /// Launches a worker thread which is intended to perform
    /// work while progress is indicated, and displays the dialog
    /// modally in order to block the calling thread.
    /// </summary>
    /// <param name="argument">A custom object which will be
    /// submitted in the <see cref="DoWorkEventArgs.Argument"/>
    /// property <paramref name="workHandler"/> callback method.</param>
    /// <param name="workHandler">A callback method which is
    /// being invoked on a background thread in order to perform
    /// the work to be performed.</param>
    public bool EjecutarHiloDeTrabajo(object argument, DoWorkEventHandler workHandler)
    {
        //store the UI culture
        uiCulture = CultureInfo.CurrentUICulture;

        //Guardar referencia para controlador callback y subproceso de trabajo puesto en marcha
        workerCallback = workHandler;
        worker.RunWorkerAsync(argument);

        // mostrar ventana  barra de progreso
        return ShowDialog() ?? false;
    }
    #endregion
    //-----------------------------------------------------------------
    // MANEJADOR DE EVENTOS
    //-----------------------------------------------------------------
    #region Manejador de eventos
    /// <summary>
    /// <para>Método trabajador que es llamado desde el hilo o subproceso de trabajo que necesitamos vigilar.</para>
    /// <para>Llama sincrónicamente los eventos con algun manejador de trabajo cargado</para>
    /// </summary>
    private void fcvDoWorkIniciarTrabajo(object sender, DoWorkEventArgs e)
    {
        try
        {
            //make sure the UI culture is properly set on the worker thread
            Thread.CurrentThread.CurrentUICulture = uiCulture;
            //invoke the callback method with the designated argument
            workerCallback(sender, e);
        }
        catch (Exception )
        {
            //disable cancelling and rethrow the exception
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (SendOrPostCallback)delegate { btnCancel.SetValue(Button.IsEnabledProperty, false); }, null);
        }
    }
    /// <summary>
    /// Cancels the background worker's progress.
    /// </summary>
    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        btnCancel.IsEnabled = false;
        worker.CancelAsync();
        //cancelled = true;
    }
    /// <summary>
    /// <para>Refresca los cambios reportados por el proceso ejecutado en segundo plano</para>
    /// <para>y los refleja en la barra de progreso</para>
    /// </summary>
    private void fcvReportarProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (!Dispatcher.CheckAccess())
        {
            //Iniciar el hilo de usuario si no esta en ejecucion
            ProgressChangedEventHandler handler = fcvReportarProgressChanged;
            Dispatcher.Invoke(DispatcherPriority.SystemIdle, handler, new object[] { sender, e }, null);
            return;
        }

        if (e.ProgressPercentage != int.MinValue)
        {
            objProgressBar.Value = e.ProgressPercentage;
        }

        lblStatus.Text = (String)e.UserState;
        //Thread.Sleep(60);

    }
    /// <summary>
    /// <para>Actualiza el estado completado de todo el proceso</para>
    /// <para>Actualiza la interfaz de usuario una vez que se ha completado una</para>
    /// <para>operación y establece estado del diálogo</para>
    /// </summary>
    private void fcvCompletoRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (!Dispatcher.CheckAccess())
        {
            //ejecutar en el subproceso de interfaz de usuario
            RunWorkerCompletedEventHandler handler = fcvCompletoRunWorkerCompleted;
            Dispatcher.Invoke(DispatcherPriority.SystemIdle, handler, new object[] { sender, e }, null);
            return;
        }

        if (e.Error != null)
        {
            error = e.Error;
        }
        else if (!e.Cancelled)
        {
            //asignar resultado si no había ni una excepción ni cancelar
            result = e.Result;
        }

        //actualización de la interfaz de usuario en el caso de cerrar el diálogo toma un momento
        objProgressBar.Value = objProgressBar.Maximum;
        btnCancel.IsEnabled = false;

        //establecer diálogo result que cierra el cuadro de diálogo 
        DialogResult = error == null && !e.Cancelled;
    }
    #endregion
    //-----------------------------------------------------------------
    // ACTUALIZAR BARRA DE PROGRESO Y ETIQUETA
    //-----------------------------------------------------------------
    #region Actualizar barra y Etiqueta
    /// <summary>
    /// Directly updates the value of the underlying
    /// progress bar. This method can be invoked from a worker thread.
    /// </summary>
    /// <param name="progress"></param>
    /// <exception cref="ArgumentOutOfRangeException">If the
    /// value is not between 0 and 100.</exception>
    public void UpdateProgress(int progress)
    {
        if (!Dispatcher.CheckAccess())
        {
            //switch to UI thread
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate { UpdateProgress(progress); }, null);
            return;
        }
        //validate range
        if (progress < objProgressBar.Minimum || progress > objProgressBar.Maximum)
        {
            string msg = " Ejecutado proceso {0}  tambien  {1} %...";
            msg = String.Format(msg, objProgressBar.Minimum, objProgressBar.Maximum);
            throw new ArgumentOutOfRangeException("progress", progress, msg);
        }

        //set the progress bar's value
        objProgressBar.SetValue(ProgressBar.ValueProperty, progress);
    }
    #endregion
  }
}