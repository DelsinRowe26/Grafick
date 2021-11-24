using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace Grafick
{
    public partial class Form1 : Form
    {
        double ScreenW, ScreenH;
        private float devX;
        private float devY;
        private float[,] GrapValuesArray;
        private int elements_count = 0;       
        private bool not_calculate = true;
        private int pointPosition = 0;
        float lineX, lineY;       
        float Mcoord_X = 0, Mcoord_Y = 0;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            int height = AnT.Height;
            int width = AnT.Width;
            AnT.InitializeContexts();

            Gl.glViewport(0, 0, width, height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45.0f, (double)width / (double)height, 0.01f, 5000.0f);
        }
        double xrot, yrot, zrot = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT); //clear buffers to preset values

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();                 // load the identity matrix

            Gl.glTranslated(0, 0, -4);          //moves our figure (x,y,z)
            Gl.glRotated(xrot += 0.5, 1, 0, 0); //rotate on x
            Gl.glRotated(yrot += 0.3, 0, 1, 0); //rotate on y
            Gl.glRotated(zrot += 0.2, 0, 0, 1); //rotate on z

            //face 1
            Gl.glBegin(Gl.GL_LINE_LOOP);    //start drawing GL_LINE_LOOP is the connection mode
            Gl.glColor3ub(255, 0, 255);
            Gl.glVertex3d(1, 1, -1);
            Gl.glVertex3d(1, -1, -1);
            Gl.glVertex3d(-1, -1, -1);
            Gl.glVertex3d(-1, 1, -1);
            Gl.glEnd();

            //face 2
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glColor3ub(0, 255, 255);
            Gl.glVertex3d(-1, -1, -1);
            Gl.glVertex3d(1, -1, -1);
            Gl.glVertex3d(1, -1, 1);
            Gl.glVertex3d(-1, -1, 1);
            Gl.glEnd();

            //face 3
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glColor3ub(255, 255, 0);
            Gl.glVertex3d(-1, 1, -1);
            Gl.glVertex3d(-1, -1, -1);
            Gl.glVertex3d(-1, -1, 1);
            Gl.glVertex3d(-1, 1, 1);
            Gl.glEnd();

            //face 4
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glColor3ub(0, 0, 255);
            Gl.glVertex3d(1, 1, 1);
            Gl.glVertex3d(1, -1, 1);
            Gl.glVertex3d(1, -1, -1);
            Gl.glVertex3d(1, 1, -1);
            Gl.glEnd();

            //face 5
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glColor3ub(0, 255, 0);
            Gl.glVertex3d(-1, 1, -1);
            Gl.glVertex3d(-1, 1, 1);
            Gl.glVertex3d(1, 1, 1);
            Gl.glVertex3d(1, 1, -1);
            Gl.glEnd();

            //face 6
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glColor4d(255, 0, 0, 100);
            Gl.glVertex3d(-1, 1, 1);
            Gl.glVertex3d(-1, -1, 1);
            Gl.glVertex3d(1, -1, 1);
            Gl.glVertex3d(1, 1, 1);
            Gl.glEnd();
            Timer timer = new Timer();

            while (i != 2)
            {
                Gl.glBegin(Gl.GL_LINE_LOOP);    //start drawing GL_LINE_LOOP is the connection mode
                Gl.glColor3ub(255, 0, 255);
                Gl.glVertex3d(2, 1, -2);
                Gl.glVertex3d(2, -1, -2);
                Gl.glVertex3d(-2, -1, -2);
                Gl.glVertex3d(-2, 1, -2);
                Gl.glEnd();

                //face 2
                Gl.glBegin(Gl.GL_LINE_LOOP);
                Gl.glColor3ub(0, 255, 255);
                Gl.glVertex3d(-3, -1, -3);
                Gl.glVertex3d(3, -1, -3);
                Gl.glVertex3d(3, -1, 3);
                Gl.glVertex3d(-3, -1, 3);
                Gl.glEnd();

                //face 3
                Gl.glBegin(Gl.GL_LINE_LOOP);
                Gl.glColor3ub(255, 255, 0);
                Gl.glVertex3d(-2, 1, -2);
                Gl.glVertex3d(-2, -1, -2);
                Gl.glVertex3d(-2, -1, 2);
                Gl.glVertex3d(-2, 1, 2);
                Gl.glEnd();

                //face 4
                Gl.glBegin(Gl.GL_LINE_LOOP);
                Gl.glColor3ub(0, 0, 255);
                Gl.glVertex3d(3, 1, 3);
                Gl.glVertex3d(3, -1, 3);
                Gl.glVertex3d(3, -1, -3);
                Gl.glVertex3d(3, 1, -3);
                Gl.glEnd();

                //face 5
                Gl.glBegin(Gl.GL_LINE_LOOP);
                Gl.glColor3ub(0, 255, 0);
                Gl.glVertex3d(-2, 1, -2);
                Gl.glVertex3d(-2, 1, 2);
                Gl.glVertex3d(2, 1, 2);
                Gl.glVertex3d(2, 1, -2);
                Gl.glEnd();

                //face 6
                Gl.glBegin(Gl.GL_LINE_LOOP);
                Gl.glColor4d(255, 0, 0, 100);
                Gl.glVertex3d(-3, 1, 2);
                Gl.glVertex3d(-2, -1, 3);
                Gl.glVertex3d(3, -1, 2);
                Gl.glVertex3d(2, 1, 3);
                Gl.glEnd();
                i++;
            }
        }

        private void PointInGrap_Tick(object sender, EventArgs e)
        {

        }
    }
}
