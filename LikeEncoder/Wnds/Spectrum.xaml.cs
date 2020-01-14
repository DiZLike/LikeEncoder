using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SharpGL;
using SharpGL.SceneGraph;
using lib.Encoders;
using SharpGL.Enumerations;
using System.Threading;
using System.Drawing;

namespace LikeEncoder.Wnds
{
    /// <summary>
    /// Логика взаимодействия для Spectrum.xaml
    /// </summary>
    public partial class Spectrum : Window
    {
        private float minGLx = -1f;
        private float maxGLx = 1f;
        private float minGLy = -1f;
        private float maxGLy = 1f;
        private float cur = 0f;
        private float oldValue = 0f;
        private float maxValue = 0f;

        private int currectSpec = 0;
        private TestCodec tcod;
        private OpenGL gl;

        public Spectrum(TestCodec tcod)
        {
            InitializeComponent();
            gl = spec.OpenGL;
            this.tcod = tcod;
        }

        private float ConvXY(float min1, float max1, float max2, float val)
        {
            float f = val / max2 * (max1 * 2f) + min1;
            return f;
        }

        private void ShowSpectrum1()
        {
            gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);

            int band = 44100 / 2;
            int step = 200;
            float k = 1;
            float pixel = (float)this.Height / (band / step);

            gl.PointSize(pixel);

            gl.Begin(BeginMode.Points);
            if (cur >= this.ActualWidth)
                cur = 0f;

            for (int i = 0; i < band; i += step)
            {
                float amp = tcod.GetSpectrum(i, i + step);
                k += 0.022f;
                float x = ConvXY(minGLx, maxGLx, (float)this.ActualWidth, cur);
                float y = ConvXY(minGLy, maxGLy, band, i);
                gl.Color(amp * k, amp * k, amp * k);
                gl.Vertex(x, y, 0);
            }

            cur += pixel;
            gl.End();
            //Thread.Sleep(100);
        }
        private void ShowSpectrum2()
        {
            gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_COLOR_BUFFER_BIT);

            int band = 44100 / 2;
            int step = 200;
            float k = 1;

            float pixel = (float)this.Height / (band / step);
            gl.PointSize(pixel);

            gl.Begin(BeginMode.Points);
            for (int i = 0; i < band; i += step)
            {
                float amp = tcod.GetSpectrum(i, i + step) * k;
                k += 0.022f;
                float x = ConvXY(minGLx, maxGLx, band, i);
                float y = ConvXY(minGLy, maxGLy, 2f, amp);
                gl.Color(1f, 1f, 1f);
                gl.Vertex(x, y, 0);
            }
            gl.End();
        }
        private void ShowSpectrum3()
        {
            gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_COLOR_BUFFER_BIT);

            int band = 44100 / 2;
            int step = 100;
            float k = 1;

            float pixel = (float)this.Height / (band / step);
            gl.PointSize(pixel);

            gl.Begin(BeginMode.Lines);
            
            for (int i = 0; i < band; i += step)
            {
                float amp1 = tcod.GetSpectrum(i, i + step) * k;
                if (amp1 > maxValue)
                    maxValue = amp1;

                float amp2 = oldValue;
                k += 0.022f;
                float x1 = ConvXY(minGLx, maxGLx, band, i);
                float x2 = ConvXY(minGLx, maxGLx, band, i - step);

                float y1 = ConvXY(minGLy, maxGLy, maxValue, amp1);
                float y2 = ConvXY(minGLy, maxGLy, maxValue, amp2);

                gl.Color(GetColor(amp1));
                gl.Vertex(x2, y2, 0);
                gl.Vertex(x1, y1, 0);

                oldValue = amp1;
            }
            gl.End();
        }
        private float[] GetColor(float amp)
        {
            float[] color = new float[3];

            color[0] = amp;
            color[1] = 1f;
            color[2] = 0.9f;
            return color;
        }

        private void OpenGLControl_OpenGLDraw(object sender, OpenGLEventArgs args)
        {
            //ShowSpectrum3();
            switch (currectSpec)
            {
                case 0:
                    ShowSpectrum1();
                    break;
                case 1:
                    ShowSpectrum2();
                    break;
                case 2:
                    ShowSpectrum3();
                    break;
            }
            
        }

        private void OpenGLControl_OpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            spec.FrameRate = 15;
        }

        private void OpenGLControl_Resized(object sender, OpenGLEventArgs args)
        {
            
        }

        private void spec_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void spec_MouseUp(object sender, MouseButtonEventArgs e)
        {
        
        }

        private void spec_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (currectSpec >= 2)
                currectSpec = 0;
            else
                currectSpec++;

            gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_COLOR_BUFFER_BIT);
            cur = 0;
        }
    }
}
