using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Animation;

static class QuickJumper
{
    public static Dictionary<string, double> WrapPanelDi = new Dictionary<string, double>();
    public static String gcrModulo;
    //public static String gcrTituloModulo;
    public static String gcrImgIcono;
    public static String gcrImgTiles;
    public static StackPanel gobStackPanel;
    public static String gcrPerfil;
    public static String gcrEstadoComModulo = "1";
    
    // Dependiendo la letra que fue presionada mover el MetroStackPanel de ese
    // WrapPanel que contiene los tiles requeridos para que esten a la vista.
    public static void ShiftStackPanel(ref string letter, ref StackPanel metroStackPanel)
    {
        if (WrapPanelDi.ContainsKey(letter.ToLower()))
        {
            DoubleAnimationUsingKeyFrames doubleAnim = new DoubleAnimationUsingKeyFrames();
            double newX = WrapPanelDi[letter.ToLower()];
            doubleAnim.Duration = TimeSpan.FromMilliseconds(1800);

            doubleAnim.KeyFrames.Add(new SplineDoubleKeyFrame(-newX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
            doubleAnim.FillBehavior = FillBehavior.HoldEnd;
            metroStackPanel.BeginAnimation(Canvas.LeftProperty, doubleAnim);
            doubleAnim.KeyFrames.Clear();
        }
    }

}
