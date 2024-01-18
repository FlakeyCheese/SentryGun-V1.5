using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SentryGun
{
    public partial class GunForm1 : Form
    {
        public GunForm1()
        {
            InitializeComponent();
        }
        int rounds = 500;
        double remaining = 33.33f;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush orangeBrush = new SolidBrush(Color.FromArgb(255, 128, 0));
            Pen orangePen = new Pen(System.Drawing.Color.FromArgb(255, 128, 0), 4);
            e.Graphics.DrawEllipse(orangePen, new Rectangle(22, 12, 50, 50));
            e.Graphics.DrawEllipse(orangePen, new Rectangle(1080, 12, 50, 50));
            e.Graphics.DrawRectangle(orangePen, new Rectangle(10, 0, 1130, 105));
            e.Graphics.DrawRectangle(orangePen, new Rectangle(440, 175, 245, 110));
            e.Graphics.DrawRectangle(orangePen, new Rectangle(400, 330, 325, 100));
            Point point1 = new Point(573, 510);
            Point point2 = new Point(623, 510);
            Point point3 = new Point(598, 530);
            Point[] curvePoints = { point1, point2, point3, };
            e.Graphics.FillPolygon(orangeBrush, curvePoints);
            Point point4 = new Point(400, 215);
            Point point5 = new Point(400, 245);
            Point point6 = new Point(440, 230);
            Point[] curvePoints2 = { point4, point5, point6, };
            e.Graphics.FillPolygon(orangeBrush, curvePoints2);
            e.Graphics.DrawLine(orangePen, 1050, 170, 1050, 430);//vertical
            e.Graphics.DrawLine(orangePen, 1010, 172, 1050, 172);
            e.Graphics.DrawLine(orangePen, 1030, 202, 1050, 202);
            e.Graphics.DrawLine(orangePen, 1020, 298, 1050, 298);
            e.Graphics.DrawLine(orangePen, 1030, 330, 1050, 330);
            e.Graphics.DrawLine(orangePen, 1020, 233, 1050, 233);
            e.Graphics.DrawLine(orangePen, 1030, 265, 1050, 265);
            e.Graphics.DrawLine(orangePen, 1020, 363, 1050, 363);
            e.Graphics.DrawLine(orangePen, 1030, 395, 1050, 395);
            e.Graphics.DrawLine(orangePen, 1010, 428, 1050, 428);
            e.Graphics.DrawLine(orangePen, 818, 170, 818, 430); //vertical
            e.Graphics.DrawLine(orangePen, 782, 172, 818, 172);
            e.Graphics.DrawLine(orangePen, 802, 202, 818, 202);
            e.Graphics.DrawLine(orangePen, 792, 298, 818, 298);
            e.Graphics.DrawLine(orangePen, 802, 330, 818, 330);
            e.Graphics.DrawLine(orangePen, 792, 233, 818, 233);
            e.Graphics.DrawLine(orangePen, 802, 265, 818, 265);
            e.Graphics.DrawLine(orangePen, 792, 363, 818, 363);
            e.Graphics.DrawLine(orangePen, 802, 395, 818, 395);
            e.Graphics.DrawLine(orangePen, 782, 428, 818, 428);
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
        private void shot()
        {
            byte[] fileByte = Properties.Resources.gun_shot;
            Stream stream = new MemoryStream(fileByte);
            var reader = new NAudio.Wave.Mp3FileReader(stream);
            var waveOut = new WaveOut();
            waveOut.Init(reader);
            waveOut.Play();
        }
        
        private void panel1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            clack();
            Owner.Show();
            Hide();
              
        }

        private void GunForm1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Height++;
            int pBoxTop = 428 - pictureBox1.Height;
            if( pBoxTop < 220 ) { timer1.Enabled = false; }
            pictureBox1.SetBounds(780,pBoxTop ,25,pictureBox1.Height) ;
            rounds--;
            remaining = Math.Round((rounds / 15d),2);
            LBL_rounds.Text=rounds.ToString();
            LBL_rem.Text=remaining.ToString();  
            shot();
            
        }
    }
}
