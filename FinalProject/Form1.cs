using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTCTaskProject;
using System.IO;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            btcTask = new BTCTask(g, new Size(pictureBoxKLine.Size.Width - 100, pictureBoxKLine.Size.Height));
            ErrorCode Error = btcTask.LoadTaskFile();
            LineNum.Text = btcTask.LineNum.ToString();
            KLineChoice.Enabled = true;
            panel2.Enabled = true;  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBoxKLine.Width, pictureBoxKLine.Height);
            g = Graphics.FromImage(bmp);
        }
        private void radioButton_CheckedChange(object sender, EventArgs e) 
        {
            draw();
            draw();
        }

        private void draw() 
        {
            g.Clear(Color.LightGray);
            if (radioButton1MKLine.Checked)
            {
                btcTask.draw(1);
            }
            if (radioButton15MKLine.Checked)
            {
                btcTask.draw(2);
            }
            if (radioButton1HKLine.Checked)
            {
                btcTask.draw(3);
            }
            pictureBoxKLine.Image = bmp;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            int NewLineNum;
            bool canConvert = int.TryParse(LineNum.Text, out NewLineNum);
            if (canConvert == true)
            {
                btcTask.Linenum = NewLineNum;
            }
            LineNum.Text = btcTask.LineNum.ToString();
            draw();
            draw();
        }

        private void buttoncalculate_Click(object sender, EventArgs e)
        {
            draw();
            if (checkBoxMACD.Checked == true) 
            {
                if (radioButton1MKLine.Checked)
                {
                    macd_Date = new MACD_Data(g, btcTask.Entity_1m, btcTask);
                    macd_Date.draw();
                }
                if (radioButton15MKLine.Checked)
                {
                    macd_Date = new MACD_Data(g, btcTask.Entity_15m, btcTask);
                    macd_Date.draw();
                }
                if (radioButton1HKLine.Checked)
                {
                    macd_Date = new MACD_Data(g, btcTask.Entity_1h, btcTask);
                    macd_Date.draw();
                }
            }
            if (checkBoxKDJ.Checked == true) 
            {
                if (radioButton1MKLine.Checked)
                {
                    kdj_Data = new KDJ_Data(g, btcTask.Entity_1m, btcTask);
                    kdj_Data.draw();
                }
                if (radioButton15MKLine.Checked)
                {
                    kdj_Data = new KDJ_Data(g, btcTask.Entity_15m, btcTask);
                    kdj_Data.draw();
                }
                if (radioButton1HKLine.Checked)
                {
                    kdj_Data = new KDJ_Data(g, btcTask.Entity_1h, btcTask);
                    kdj_Data.draw();
                }
            }
            if (checkBoxRSI.Checked == true)
            {
                if (radioButton1MKLine.Checked)
                {
                    rsi_Data = new RSI_Data(g, btcTask.Entity_1m, btcTask);
                    rsi_Data.draw();
                }
                if (radioButton15MKLine.Checked)
                {
                    rsi_Data = new RSI_Data(g, btcTask.Entity_15m, btcTask);
                    rsi_Data.draw();
                }
                if (radioButton1HKLine.Checked)
                {
                    rsi_Data = new RSI_Data(g, btcTask.Entity_1h, btcTask);
                    rsi_Data.draw();
                }
            }
            pictureBoxKLine.Image = bmp;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            pictureBoxKLine.Image.Save("output.jpg");
        }
    }
}
