
namespace APS_PaintPatterns
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
            this.RectangleToolButton = new System.Windows.Forms.Button();
            this.EllipseToolButton = new System.Windows.Forms.Button();
            this.SelectToolButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RectangleToolButton
            // 
            this.RectangleToolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RectangleToolButton.Location = new System.Drawing.Point(12, 12);
            this.RectangleToolButton.Name = "RectangleToolButton";
            this.RectangleToolButton.Size = new System.Drawing.Size(65, 65);
            this.RectangleToolButton.TabIndex = 0;
            this.RectangleToolButton.Text = "🔲";
            this.RectangleToolButton.UseVisualStyleBackColor = true;
            this.RectangleToolButton.Click += new System.EventHandler(this.RectangleToolButton_Click);
            // 
            // EllipseToolButton
            // 
            this.EllipseToolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EllipseToolButton.Location = new System.Drawing.Point(83, 12);
            this.EllipseToolButton.Name = "EllipseToolButton";
            this.EllipseToolButton.Size = new System.Drawing.Size(65, 65);
            this.EllipseToolButton.TabIndex = 1;
            this.EllipseToolButton.Text = "⚪";
            this.EllipseToolButton.UseVisualStyleBackColor = true;
            this.EllipseToolButton.Click += new System.EventHandler(this.EllipseToolButton_Click);
            // 
            // SelectToolButton
            // 
            this.SelectToolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectToolButton.Location = new System.Drawing.Point(154, 12);
            this.SelectToolButton.Name = "SelectToolButton";
            this.SelectToolButton.Size = new System.Drawing.Size(65, 65);
            this.SelectToolButton.TabIndex = 2;
            this.SelectToolButton.Text = "⇱";
            this.SelectToolButton.UseVisualStyleBackColor = true;
            this.SelectToolButton.Click += new System.EventHandler(this.SelectToolButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectToolButton);
            this.Controls.Add(this.EllipseToolButton);
            this.Controls.Add(this.RectangleToolButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RectangleToolButton;
        private System.Windows.Forms.Button EllipseToolButton;
        private System.Windows.Forms.Button SelectToolButton;
    }
}

