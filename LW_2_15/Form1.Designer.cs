﻿namespace LW_2_15
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pb_Field = new System.Windows.Forms.PictureBox();
            this.tmDraw = new System.Windows.Forms.Timer(this.components);
            this.tmNewBall = new System.Windows.Forms.Timer(this.components);
            this.gb_Priority = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Field)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Field
            // 
            this.pb_Field.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_Field.Location = new System.Drawing.Point(0, 0);
            this.pb_Field.Name = "pb_Field";
            this.pb_Field.Size = new System.Drawing.Size(500, 504);
            this.pb_Field.TabIndex = 0;
            this.pb_Field.TabStop = false;
            // 
            // tmDraw
            // 
            this.tmDraw.Enabled = true;
            this.tmDraw.Interval = 10;
            this.tmDraw.Tick += new System.EventHandler(this.Draw_Tick);
            // 
            // tmNewBall
            // 
            this.tmNewBall.Enabled = true;
            this.tmNewBall.Interval = 5000;
            this.tmNewBall.Tick += new System.EventHandler(this.CreateBall_Tick);
            // 
            // gb_Priority
            // 
            this.gb_Priority.Dock = System.Windows.Forms.DockStyle.Right;
            this.gb_Priority.Location = new System.Drawing.Point(500, 0);
            this.gb_Priority.Name = "gb_Priority";
            this.gb_Priority.Size = new System.Drawing.Size(103, 504);
            this.gb_Priority.TabIndex = 1;
            this.gb_Priority.TabStop = false;
            this.gb_Priority.Text = "Приоритет";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 504);
            this.Controls.Add(this.gb_Priority);
            this.Controls.Add(this.pb_Field);
            this.Name = "Form1";
            this.Text = "B";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Field)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Field;
        private System.Windows.Forms.Timer tmDraw;
        private System.Windows.Forms.Timer tmNewBall;
        private System.Windows.Forms.GroupBox gb_Priority;
    }
}

