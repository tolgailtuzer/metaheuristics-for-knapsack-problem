namespace SimulatedAnnealing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startTemp = new System.Windows.Forms.TextBox();
            this.endTemp = new System.Windows.Forms.TextBox();
            this.repeat = new System.Windows.Forms.TextBox();
            this.startAlgorithm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.choose = new System.Windows.Forms.Button();
            this.runAll = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Temp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "End Temp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Repeat Count";
            // 
            // startTemp
            // 
            this.startTemp.Location = new System.Drawing.Point(98, 19);
            this.startTemp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startTemp.Name = "startTemp";
            this.startTemp.Size = new System.Drawing.Size(76, 20);
            this.startTemp.TabIndex = 3;
            // 
            // endTemp
            // 
            this.endTemp.Location = new System.Drawing.Point(98, 55);
            this.endTemp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.endTemp.Name = "endTemp";
            this.endTemp.Size = new System.Drawing.Size(76, 20);
            this.endTemp.TabIndex = 4;
            // 
            // repeat
            // 
            this.repeat.Location = new System.Drawing.Point(98, 91);
            this.repeat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.repeat.Name = "repeat";
            this.repeat.Size = new System.Drawing.Size(76, 20);
            this.repeat.TabIndex = 5;
            // 
            // startAlgorithm
            // 
            this.startAlgorithm.Location = new System.Drawing.Point(199, 19);
            this.startAlgorithm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startAlgorithm.Name = "startAlgorithm";
            this.startAlgorithm.Size = new System.Drawing.Size(110, 94);
            this.startAlgorithm.TabIndex = 6;
            this.startAlgorithm.Text = "Start Algorithm";
            this.startAlgorithm.UseVisualStyleBackColor = true;
            this.startAlgorithm.Click += new System.EventHandler(this.startAlgorithm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "File";
            // 
            // choose
            // 
            this.choose.Location = new System.Drawing.Point(98, 123);
            this.choose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(75, 25);
            this.choose.TabIndex = 8;
            this.choose.Text = "Choose";
            this.choose.UseVisualStyleBackColor = true;
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // runAll
            // 
            this.runAll.Location = new System.Drawing.Point(199, 123);
            this.runAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.runAll.Name = "runAll";
            this.runAll.Size = new System.Drawing.Size(110, 25);
            this.runAll.TabIndex = 9;
            this.runAll.Text = "Run All";
            this.runAll.UseVisualStyleBackColor = true;
            this.runAll.Click += new System.EventHandler(this.runAll_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 176);
            this.Controls.Add(this.runAll);
            this.Controls.Add(this.choose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startAlgorithm);
            this.Controls.Add(this.repeat);
            this.Controls.Add(this.endTemp);
            this.Controls.Add(this.startTemp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(338, 215);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulated Annealing UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox startTemp;
        private System.Windows.Forms.TextBox endTemp;
        private System.Windows.Forms.TextBox repeat;
        private System.Windows.Forms.Button startAlgorithm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button choose;
        private System.Windows.Forms.Button runAll;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}