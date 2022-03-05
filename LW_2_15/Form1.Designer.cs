namespace LW_2_15
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
            ((System.ComponentModel.ISupportInitialize)(this.pb_Field)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Field
            // 
            this.pb_Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Field.Location = new System.Drawing.Point(0, 0);
            this.pb_Field.Name = "pb_Field";
            this.pb_Field.Size = new System.Drawing.Size(603, 504);
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
            this.tmNewBall.Tick += new System.EventHandler(this.CreateBall_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 504);
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
    }
}

