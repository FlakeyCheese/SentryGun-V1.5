using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SentryGun
{
    public partial class Form1 : Form
    {
        GunForm1 gunForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)// paint the UI
        {
            SolidBrush orangeBrush = new SolidBrush(Color.FromArgb(255,128,0));
            Pen orangePen = new Pen (System.Drawing.Color.FromArgb(255,128,0),4);            
            e.Graphics.DrawEllipse(orangePen, new Rectangle(22, 12, 50, 50));
            e.Graphics.DrawEllipse(orangePen, new Rectangle(1080, 12, 50, 50));
            e.Graphics.DrawRectangle(orangePen, new Rectangle(10, 0, 1130, 105));
            e.Graphics.DrawRectangle(orangePen, new Rectangle(10, 105, 1130, 75));
            e.Graphics.DrawRectangle(orangePen, new Rectangle(10, 180, 1130, 140));
            e.Graphics.DrawRectangle(orangePen, new Rectangle(10, 320, 1130, 50));
            e.Graphics.DrawRectangle(orangePen, new Rectangle(10, 370, 1130, 120));
            e.Graphics.DrawLine(orangePen, 300, 105, 300, 320);
            e.Graphics.DrawLine(orangePen, 550, 105, 550, 320);
            e.Graphics.DrawLine(orangePen, 850, 105, 850, 320);
            e.Graphics.DrawLine(orangePen, 350, 320, 350, 490);
            e.Graphics.DrawLine(orangePen, 750, 320, 750, 490);
            Point point1 = new Point(573, 510);
            Point point2 = new Point(623, 510);
            Point point3 = new Point(598, 530);
            Point[] curvePoints = { point1, point2, point3,  };
            e.Graphics.FillPolygon(orangeBrush, curvePoints);
        }

        private void common_mode_click(object sender, EventArgs e)
        { Label s = sender as Label;
            LBL_AUTO_REMOTE.BackColor = Color.Black;
            LBL_AUTO_REMOTE.ForeColor =Color.FromArgb(255,128,0);
            LBL_MAN.BackColor = Color.Black;
            LBL_MAN.ForeColor=Color.FromArgb(255,128,0);
            LBL_SEMI.BackColor = Color.Black;
            LBL_SEMI.ForeColor=Color.FromArgb(255,128,0);
            s.ForeColor = Color.Black;
            s.BackColor = Color.FromArgb(255,128,0);
            clack();
        }

        private void common_weapon_click(object sender, EventArgs e)
        {
            Label s = sender as Label;
            LBL_SAFE.BackColor = Color.Black;
            LBL_SAFE.ForeColor=Color.FromArgb(255,128,0);
            LBL_ARMED.BackColor = Color.Black;
            LBL_ARMED.ForeColor=Color.FromArgb(255,128,0);
            s.ForeColor = Color.Black;
            s.BackColor = Color.FromArgb(255, 128, 0);
            clack();
        }

        private void common_iff_click(object sender, EventArgs e)
        {
            Label s = sender as Label;
            LBL_SEARCH.BackColor = Color.Black;
            LBL_SEARCH.ForeColor=Color.FromArgb(255,128,0);
            LBL_TEST.BackColor = Color.Black;
            LBL_TEST.ForeColor=Color.FromArgb(255,128,0);
            LBL_ENGAGED.BackColor = Color.Black;
            LBL_ENGAGED.ForeColor=Color.FromArgb(255,128,0);
            LBL_INT.BackColor = Color.Black;
            LBL_INT.ForeColor=Color.FromArgb(255,128,0);
            s.ForeColor = Color.Black;
            s.BackColor = Color.FromArgb(255, 128, 0);
            clack();
        }

        private void common_test_click(object sender, EventArgs e)
        {
            Label s = sender as Label;
            LBL_AUTO.BackColor = Color.Black;
            LBL_AUTO.ForeColor=Color.FromArgb(255,128,0);
            LBL_SELECT.BackColor = Color.Black;
            LBL_SELECT.ForeColor=Color.FromArgb(255,128,0);
            s.ForeColor = Color.Black;
            s.BackColor = Color.FromArgb(255, 128, 0);
            clack();
        }

        private void common_targetP_click(object sender, EventArgs e)
        {
            Label s = sender as Label;
            LBL_SOFT.BackColor = Color.Black;
            LBL_SEMIHARD.BackColor = Color.Black;
            LBL_HARD.BackColor=Color.Black;
            LBL_SOFT.ForeColor= Color.FromArgb(255, 128, 0);
            LBL_SEMIHARD.ForeColor= Color.FromArgb(255,128,0);
            LBL_HARD.ForeColor=Color.FromArgb(255,128,0);
            s.ForeColor = Color.Black;
            s.BackColor = Color.FromArgb(255, 128, 0);
            clack();
        }

        private void common_spectral_click(object sender, EventArgs e)
        {
            Label s = sender as Label;
            LBL_BIO.BackColor = Color.Black;
            LBL_BIO.ForeColor=Color.FromArgb (255, 128, 0);
            LBL_INERT.BackColor = Color.Black;
            LBL_INERT.ForeColor=Color.FromArgb(255,128,0);
            s.ForeColor = Color.Black;
            s.BackColor = Color.FromArgb(255, 128, 0);
            clack();
        }

        private void common_targetS_click(object sender, EventArgs e)
        {
            Label s = sender as Label;
            LBL_MULTI.BackColor = Color.Black;
            LBL_INFRA.BackColor = Color.Black;
            LBL_UV.BackColor = Color.Black;
            LBL_MULTI.ForeColor=Color.FromArgb(255,128,0);
            LBL_INFRA.ForeColor=Color.FromArgb(255,128,0);
            LBL_UV.ForeColor=Color.FromArgb(255,128,0) ;
            s.ForeColor = Color.Black;
            s.BackColor = Color.FromArgb(255, 128, 0);
            clack();
        }
        private void clack()
        {
            byte[] fileByte = Properties.Resources.clack;
            Stream stream = new MemoryStream(fileByte);
            var reader = new NAudio.Wave.Mp3FileReader(stream);
            var waveOut = new WaveOut();
            waveOut.Init(reader);
            waveOut.Play();
        }
        GunForm1 gunForm1 = new GunForm1();
        private void panel1_Click(object sender, EventArgs e)
        {
            clack();
            if (gunForm == null)
            {
                gunForm = new GunForm1();
                gunForm.FormClosed += gunForm_FormClosed;
            }
            gunForm.Show(this);
            Hide();
        }
        void gunForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            gunForm = null;
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
