using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathWorks;
using MathWorks.MATLAB;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using MLApp;
namespace matlab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MLApp.MLApp matlab = null;
            Type matlabAppType = System.Type.GetTypeFromProgID("Matlab.Application");
            matlab = System.Activator.CreateInstance(matlabAppType) as MLApp.MLApp;
            string command;
            //  string a=textBox1.Text;
            //   string b=textBox2.Text;
            command = "t=2:0.2:4*pi;y=sin(t);plot(t,y)";
            String path = System.IO.Directory.GetCurrentDirectory();//获取当前路径
            matlab.Visible = 0;
            matlab.Execute(command);
            command = @"print(gcf,   '-djpeg',   '" + path + "\\Test11');close all";
            matlab.Execute(command);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(path + "\\Test11.jpg");
        }
    }
}
