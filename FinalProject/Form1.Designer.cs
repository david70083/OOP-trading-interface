using System.Drawing;
using BTCTaskProject;

namespace FinalProject
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        /// 
        private Bitmap bmp;
        private System.ComponentModel.IContainer components = null;
        private Graphics g;
        private BTCTask btcTask;
        private MACD_Data macd_Date;
        private KDJ_Data kdj_Data;
        private RSI_Data rsi_Data;
        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1MKLine = new System.Windows.Forms.RadioButton();
            this.radioButton15MKLine = new System.Windows.Forms.RadioButton();
            this.radioButton1HKLine = new System.Windows.Forms.RadioButton();
            this.KLineChoice = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxMFI = new System.Windows.Forms.CheckBox();
            this.checkBoxCCI = new System.Windows.Forms.CheckBox();
            this.checkBoxMACD = new System.Windows.Forms.CheckBox();
            this.checkBoxRSI = new System.Windows.Forms.CheckBox();
            this.checkBoxKDJ = new System.Windows.Forms.CheckBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttoncalculate = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelLineNum = new System.Windows.Forms.Label();
            this.LineNum = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBoxKLine = new System.Windows.Forms.PictureBox();
            this.KLineChoice.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKLine)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F);
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "K Line";
            // 
            // radioButton1MKLine
            // 
            this.radioButton1MKLine.AutoSize = true;
            this.radioButton1MKLine.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton1MKLine.Location = new System.Drawing.Point(14, 19);
            this.radioButton1MKLine.Name = "radioButton1MKLine";
            this.radioButton1MKLine.Size = new System.Drawing.Size(94, 34);
            this.radioButton1MKLine.TabIndex = 2;
            this.radioButton1MKLine.TabStop = true;
            this.radioButton1MKLine.Text = "1分K";
            this.radioButton1MKLine.UseVisualStyleBackColor = true;
            this.radioButton1MKLine.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChange);
            // 
            // radioButton15MKLine
            // 
            this.radioButton15MKLine.AutoSize = true;
            this.radioButton15MKLine.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton15MKLine.Location = new System.Drawing.Point(14, 77);
            this.radioButton15MKLine.Name = "radioButton15MKLine";
            this.radioButton15MKLine.Size = new System.Drawing.Size(109, 34);
            this.radioButton15MKLine.TabIndex = 3;
            this.radioButton15MKLine.TabStop = true;
            this.radioButton15MKLine.Text = "15分K";
            this.radioButton15MKLine.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.radioButton15MKLine.UseVisualStyleBackColor = true;
            this.radioButton15MKLine.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChange);
            // 
            // radioButton1HKLine
            // 
            this.radioButton1HKLine.AutoSize = true;
            this.radioButton1HKLine.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton1HKLine.Location = new System.Drawing.Point(14, 132);
            this.radioButton1HKLine.Name = "radioButton1HKLine";
            this.radioButton1HKLine.Size = new System.Drawing.Size(94, 34);
            this.radioButton1HKLine.TabIndex = 4;
            this.radioButton1HKLine.TabStop = true;
            this.radioButton1HKLine.Text = "1時K";
            this.radioButton1HKLine.UseVisualStyleBackColor = true;
            this.radioButton1HKLine.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChange);
            // 
            // KLineChoice
            // 
            this.KLineChoice.Controls.Add(this.radioButton1HKLine);
            this.KLineChoice.Controls.Add(this.radioButton15MKLine);
            this.KLineChoice.Controls.Add(this.radioButton1MKLine);
            this.KLineChoice.Enabled = false;
            this.KLineChoice.Location = new System.Drawing.Point(23, 423);
            this.KLineChoice.Name = "KLineChoice";
            this.KLineChoice.Size = new System.Drawing.Size(226, 307);
            this.KLineChoice.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxMFI);
            this.panel2.Controls.Add(this.checkBoxCCI);
            this.panel2.Controls.Add(this.checkBoxMACD);
            this.panel2.Controls.Add(this.checkBoxRSI);
            this.panel2.Controls.Add(this.checkBoxKDJ);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(305, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 303);
            this.panel2.TabIndex = 9;
            // 
            // checkBoxMFI
            // 
            this.checkBoxMFI.AutoSize = true;
            this.checkBoxMFI.Font = new System.Drawing.Font("新細明體", 18F);
            this.checkBoxMFI.Location = new System.Drawing.Point(36, 235);
            this.checkBoxMFI.Name = "checkBoxMFI";
            this.checkBoxMFI.Size = new System.Drawing.Size(85, 34);
            this.checkBoxMFI.TabIndex = 9;
            this.checkBoxMFI.Text = "MFI";
            this.checkBoxMFI.UseVisualStyleBackColor = true;
            // 
            // checkBoxCCI
            // 
            this.checkBoxCCI.AutoSize = true;
            this.checkBoxCCI.Font = new System.Drawing.Font("新細明體", 18F);
            this.checkBoxCCI.Location = new System.Drawing.Point(36, 181);
            this.checkBoxCCI.Name = "checkBoxCCI";
            this.checkBoxCCI.Size = new System.Drawing.Size(82, 34);
            this.checkBoxCCI.TabIndex = 9;
            this.checkBoxCCI.Text = "CCI";
            this.checkBoxCCI.UseVisualStyleBackColor = true;
            // 
            // checkBoxMACD
            // 
            this.checkBoxMACD.AutoSize = true;
            this.checkBoxMACD.Font = new System.Drawing.Font("新細明體", 18F);
            this.checkBoxMACD.Location = new System.Drawing.Point(36, 17);
            this.checkBoxMACD.Name = "checkBoxMACD";
            this.checkBoxMACD.Size = new System.Drawing.Size(119, 34);
            this.checkBoxMACD.TabIndex = 9;
            this.checkBoxMACD.Text = "MACD";
            this.checkBoxMACD.UseVisualStyleBackColor = true;
            // 
            // checkBoxRSI
            // 
            this.checkBoxRSI.AutoSize = true;
            this.checkBoxRSI.Font = new System.Drawing.Font("新細明體", 18F);
            this.checkBoxRSI.Location = new System.Drawing.Point(36, 130);
            this.checkBoxRSI.Name = "checkBoxRSI";
            this.checkBoxRSI.Size = new System.Drawing.Size(79, 34);
            this.checkBoxRSI.TabIndex = 9;
            this.checkBoxRSI.Text = "RSI";
            this.checkBoxRSI.UseVisualStyleBackColor = true;
            // 
            // checkBoxKDJ
            // 
            this.checkBoxKDJ.AutoSize = true;
            this.checkBoxKDJ.Font = new System.Drawing.Font("新細明體", 18F);
            this.checkBoxKDJ.Location = new System.Drawing.Point(36, 75);
            this.checkBoxKDJ.Name = "checkBoxKDJ";
            this.checkBoxKDJ.Size = new System.Drawing.Size(86, 34);
            this.checkBoxKDJ.TabIndex = 9;
            this.checkBoxKDJ.Text = "KDJ";
            this.checkBoxKDJ.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("新細明體", 18F);
            this.buttonLoad.Location = new System.Drawing.Point(658, 426);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(135, 50);
            this.buttonLoad.TabIndex = 10;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttoncalculate
            // 
            this.buttoncalculate.Font = new System.Drawing.Font("新細明體", 18F);
            this.buttoncalculate.Location = new System.Drawing.Point(658, 573);
            this.buttoncalculate.Name = "buttoncalculate";
            this.buttoncalculate.Size = new System.Drawing.Size(135, 50);
            this.buttoncalculate.TabIndex = 10;
            this.buttoncalculate.Text = "calculate";
            this.buttoncalculate.UseVisualStyleBackColor = true;
            this.buttoncalculate.Click += new System.EventHandler(this.buttoncalculate_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("新細明體", 18F);
            this.buttonSave.Location = new System.Drawing.Point(658, 500);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(135, 50);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelLineNum
            // 
            this.labelLineNum.AutoSize = true;
            this.labelLineNum.Font = new System.Drawing.Font("新細明體", 18F);
            this.labelLineNum.Location = new System.Drawing.Point(911, 436);
            this.labelLineNum.Name = "labelLineNum";
            this.labelLineNum.Size = new System.Drawing.Size(165, 30);
            this.labelLineNum.TabIndex = 12;
            this.labelLineNum.Text = "Line Number";
            // 
            // LineNum
            // 
            this.LineNum.Font = new System.Drawing.Font("新細明體", 18F);
            this.LineNum.Location = new System.Drawing.Point(1111, 426);
            this.LineNum.Name = "LineNum";
            this.LineNum.Size = new System.Drawing.Size(104, 43);
            this.LineNum.TabIndex = 11;
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("新細明體", 18F);
            this.buttonOK.Location = new System.Drawing.Point(1111, 490);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(95, 45);
            this.buttonOK.TabIndex = 13;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // pictureBoxKLine
            // 
            this.pictureBoxKLine.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxKLine.Location = new System.Drawing.Point(15, 49);
            this.pictureBoxKLine.Name = "pictureBoxKLine";
            this.pictureBoxKLine.Size = new System.Drawing.Size(1250, 354);
            this.pictureBoxKLine.TabIndex = 14;
            this.pictureBoxKLine.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.pictureBoxKLine);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelLineNum);
            this.Controls.Add(this.LineNum);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttoncalculate);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.KLineChoice);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KLineChoice.ResumeLayout(false);
            this.KLineChoice.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1MKLine;
        private System.Windows.Forms.RadioButton radioButton15MKLine;
        private System.Windows.Forms.RadioButton radioButton1HKLine;
        private System.Windows.Forms.Panel KLineChoice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttoncalculate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxMFI;
        private System.Windows.Forms.CheckBox checkBoxCCI;
        private System.Windows.Forms.CheckBox checkBoxMACD;
        private System.Windows.Forms.CheckBox checkBoxRSI;
        private System.Windows.Forms.CheckBox checkBoxKDJ;
        private System.Windows.Forms.Label labelLineNum;
        private System.Windows.Forms.TextBox LineNum;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox pictureBoxKLine;
    }
}

