using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace RicknMortyEyeMoveMentWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MouseMove += MainWindow_MouseMove;
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePos = e.GetPosition(this);
            var Containerx = Width / 2;
            var Containery = Height / 2;

            RotateTransform myRotateTransform = new RotateTransform();
            myRotateTransform.Angle = 90 + GetAngle(mousePos.X, mousePos.Y, Containerx, Containery);

            MortyEyeLeft.RenderTransform = myRotateTransform;
            MortyEyeRight.RenderTransform = myRotateTransform;

            RickEyeLeft.RenderTransform = myRotateTransform;
            RickEyeRight.RenderTransform = myRotateTransform;
        }

        private double GetAngle(double cx, double cy, double ex, double ey)
        {
            var dy = ey - cy;
            var dx = ex - cx;
            var rad = Math.Atan2(dy, dx);
            var deg = rad * 180 / Math.PI;
            return deg;
        }
    }
}
