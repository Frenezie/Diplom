namespace Diplom
{
    partial class Add_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cueTextBox5 = new Diplom.CueTextBox();
            this.cueTextBox4 = new Diplom.CueTextBox();
            this.cueTextBox3 = new Diplom.CueTextBox();
            this.cueTextBox2 = new Diplom.CueTextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(149, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 60);
            this.panel1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(19, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 40);
            this.label4.TabIndex = 13;
            this.label4.Text = "Создание записи\r\nСотрудники";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(265, 431);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 43);
            this.button1.TabIndex = 14;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cueTextBox5
            // 
            this.cueTextBox5.Cue = "Должность";
            this.cueTextBox5.Location = new System.Drawing.Point(265, 323);
            this.cueTextBox5.Name = "cueTextBox5";
            this.cueTextBox5.Size = new System.Drawing.Size(155, 22);
            this.cueTextBox5.TabIndex = 60;
            // 
            // cueTextBox4
            // 
            this.cueTextBox4.Cue = "Возраст";
            this.cueTextBox4.Location = new System.Drawing.Point(265, 283);
            this.cueTextBox4.Name = "cueTextBox4";
            this.cueTextBox4.Size = new System.Drawing.Size(155, 22);
            this.cueTextBox4.TabIndex = 59;
            // 
            // cueTextBox3
            // 
            this.cueTextBox3.Cue = "Пол";
            this.cueTextBox3.Location = new System.Drawing.Point(265, 244);
            this.cueTextBox3.Name = "cueTextBox3";
            this.cueTextBox3.Size = new System.Drawing.Size(155, 22);
            this.cueTextBox3.TabIndex = 58;
            // 
            // cueTextBox2
            // 
            this.cueTextBox2.Cue = "ФИО Сотрудника";
            this.cueTextBox2.Location = new System.Drawing.Point(265, 205);
            this.cueTextBox2.Name = "cueTextBox2";
            this.cueTextBox2.Size = new System.Drawing.Size(155, 22);
            this.cueTextBox2.TabIndex = 57;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = global::Diplom.Properties.Resources.Запись;
            this.pictureBox3.Location = new System.Drawing.Point(13, 13);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(125, 116);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // Add_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 497);
            this.Controls.Add(this.cueTextBox5);
            this.Controls.Add(this.cueTextBox4);
            this.Controls.Add(this.cueTextBox3);
            this.Controls.Add(this.cueTextBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Add_Form";
            this.Text = "Создание записи";
            this.Load += new System.EventHandler(this.Add_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private CueTextBox cueTextBox5;
        private CueTextBox cueTextBox4;
        private CueTextBox cueTextBox3;
        private CueTextBox cueTextBox2;
    }
}