namespace GeneticAlgorithm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.populationSize = new System.Windows.Forms.TextBox();
            this.crossoverRate = new System.Windows.Forms.TextBox();
            this.mutationRate = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.repeatTime = new System.Windows.Forms.TextBox();
            this.advanced = new System.Windows.Forms.CheckBox();
            this.crossoverMethod = new System.Windows.Forms.ComboBox();
            this.selectionMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RunAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Population Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Crossover Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mutation Rate";
            // 
            // chooseFile
            // 
            this.chooseFile.Location = new System.Drawing.Point(160, 142);
            this.chooseFile.Name = "chooseFile";
            this.chooseFile.Size = new System.Drawing.Size(100, 26);
            this.chooseFile.TabIndex = 3;
            this.chooseFile.Text = "Choose";
            this.chooseFile.UseVisualStyleBackColor = true;
            this.chooseFile.Click += new System.EventHandler(this.chooseFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "File";
            // 
            // populationSize
            // 
            this.populationSize.Location = new System.Drawing.Point(160, 25);
            this.populationSize.Name = "populationSize";
            this.populationSize.Size = new System.Drawing.Size(100, 20);
            this.populationSize.TabIndex = 5;
            // 
            // crossoverRate
            // 
            this.crossoverRate.Location = new System.Drawing.Point(160, 55);
            this.crossoverRate.Name = "crossoverRate";
            this.crossoverRate.Size = new System.Drawing.Size(100, 20);
            this.crossoverRate.TabIndex = 6;
            // 
            // mutationRate
            // 
            this.mutationRate.Location = new System.Drawing.Point(160, 84);
            this.mutationRate.Name = "mutationRate";
            this.mutationRate.Size = new System.Drawing.Size(100, 20);
            this.mutationRate.TabIndex = 7;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(288, 25);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(154, 143);
            this.start.TabIndex = 9;
            this.start.Text = "Start Algorithm";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Repeat Time";
            // 
            // repeatTime
            // 
            this.repeatTime.Location = new System.Drawing.Point(160, 114);
            this.repeatTime.Name = "repeatTime";
            this.repeatTime.Size = new System.Drawing.Size(100, 20);
            this.repeatTime.TabIndex = 11;
            // 
            // advanced
            // 
            this.advanced.AutoSize = true;
            this.advanced.Location = new System.Drawing.Point(25, 183);
            this.advanced.Name = "advanced";
            this.advanced.Size = new System.Drawing.Size(75, 17);
            this.advanced.TabIndex = 12;
            this.advanced.Text = "Advanced";
            this.advanced.UseVisualStyleBackColor = true;
            this.advanced.CheckedChanged += new System.EventHandler(this.advanced_CheckedChanged);
            // 
            // crossoverMethod
            // 
            this.crossoverMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crossoverMethod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.crossoverMethod.FormattingEnabled = true;
            this.crossoverMethod.Items.AddRange(new object[] {
            "One Point Crossover",
            "Two Point Crossover"});
            this.crossoverMethod.Location = new System.Drawing.Point(51, 256);
            this.crossoverMethod.Name = "crossoverMethod";
            this.crossoverMethod.Size = new System.Drawing.Size(121, 21);
            this.crossoverMethod.TabIndex = 13;
            // 
            // selectionMethod
            // 
            this.selectionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionMethod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectionMethod.FormattingEnabled = true;
            this.selectionMethod.Items.AddRange(new object[] {
            "Tournament Selection",
            "Roulet Selection"});
            this.selectionMethod.Location = new System.Drawing.Point(288, 256);
            this.selectionMethod.Name = "selectionMethod";
            this.selectionMethod.Size = new System.Drawing.Size(121, 21);
            this.selectionMethod.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Crossover Method";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Selection Method";
            // 
            // RunAll
            // 
            this.RunAll.Location = new System.Drawing.Point(321, 174);
            this.RunAll.Name = "RunAll";
            this.RunAll.Size = new System.Drawing.Size(75, 23);
            this.RunAll.TabIndex = 17;
            this.RunAll.Text = "Run All";
            this.RunAll.UseVisualStyleBackColor = true;
            this.RunAll.Click += new System.EventHandler(this.RunAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 211);
            this.Controls.Add(this.RunAll);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selectionMethod);
            this.Controls.Add(this.crossoverMethod);
            this.Controls.Add(this.advanced);
            this.Controls.Add(this.repeatTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.start);
            this.Controls.Add(this.mutationRate);
            this.Controls.Add(this.crossoverRate);
            this.Controls.Add(this.populationSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chooseFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(483, 250);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genetic UI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button chooseFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox populationSize;
        private System.Windows.Forms.TextBox crossoverRate;
        private System.Windows.Forms.TextBox mutationRate;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox repeatTime;
        private System.Windows.Forms.CheckBox advanced;
        private System.Windows.Forms.ComboBox crossoverMethod;
        private System.Windows.Forms.ComboBox selectionMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button RunAll;
    }
}