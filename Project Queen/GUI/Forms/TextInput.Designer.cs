namespace Project_Queen.GUI.Forms
{
    partial class TextInput
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
            this.TB_InputText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TB_NotifcationText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TB_InputText
            // 
            this.TB_InputText.Location = new System.Drawing.Point(12, 38);
            this.TB_InputText.Name = "TB_InputText";
            this.TB_InputText.Size = new System.Drawing.Size(388, 20);
            this.TB_InputText.TabIndex = 0;
            this.TB_InputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextInput_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(200, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TB_NotifcationText
            // 
            this.TB_NotifcationText.BackColor = System.Drawing.SystemColors.Control;
            this.TB_NotifcationText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_NotifcationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_NotifcationText.Location = new System.Drawing.Point(12, 15);
            this.TB_NotifcationText.Name = "TB_NotifcationText";
            this.TB_NotifcationText.ReadOnly = true;
            this.TB_NotifcationText.Size = new System.Drawing.Size(388, 15);
            this.TB_NotifcationText.TabIndex = 3;
            this.TB_NotifcationText.Text = "Enter Input Text";
            this.TB_NotifcationText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 96);
            this.Controls.Add(this.TB_NotifcationText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TB_InputText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextInput";
            this.Text = "TextInput";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextInput_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_InputText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TB_NotifcationText;
    }
}