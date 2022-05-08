namespace Project_Queen.GUI.Controls
{
    partial class MaskEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button3 = new System.Windows.Forms.Button();
            this.TB_Thumbnail = new System.Windows.Forms.TextBox();
            this.Mesh_Path = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.Thumbnail_Path = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Mesh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_EntryName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_HideHair = new System.Windows.Forms.CheckBox();
            this.CB_HideFace = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NUD_Z = new System.Windows.Forms.NumericUpDown();
            this.NUD_Y = new System.Windows.Forms.NumericUpDown();
            this.NUD_X = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_CheckFlag = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_X)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(84, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Remove_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(3, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Add_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(153, 244);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(407, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 20);
            this.button3.TabIndex = 7;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TB_Thumbnail
            // 
            this.TB_Thumbnail.Enabled = false;
            this.TB_Thumbnail.Location = new System.Drawing.Point(90, 66);
            this.TB_Thumbnail.Name = "TB_Thumbnail";
            this.TB_Thumbnail.Size = new System.Drawing.Size(311, 20);
            this.TB_Thumbnail.TabIndex = 2;
            this.TB_Thumbnail.TextChanged += new System.EventHandler(this.TB_Thumbnail_TextChanged);
            // 
            // Mesh_Path
            // 
            this.Mesh_Path.AutoSize = true;
            this.Mesh_Path.Location = new System.Drawing.Point(85, 94);
            this.Mesh_Path.Name = "Mesh_Path";
            this.Mesh_Path.Size = new System.Drawing.Size(29, 13);
            this.Mesh_Path.TabIndex = 10;
            this.Mesh_Path.Text = "Path";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(407, 112);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 20);
            this.button4.TabIndex = 9;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Thumbnail_Path
            // 
            this.Thumbnail_Path.AutoSize = true;
            this.Thumbnail_Path.Location = new System.Drawing.Point(85, 50);
            this.Thumbnail_Path.Name = "Thumbnail_Path";
            this.Thumbnail_Path.Size = new System.Drawing.Size(29, 13);
            this.Thumbnail_Path.TabIndex = 8;
            this.Thumbnail_Path.Text = "Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Model:";
            // 
            // TB_Mesh
            // 
            this.TB_Mesh.Enabled = false;
            this.TB_Mesh.Location = new System.Drawing.Point(90, 112);
            this.TB_Mesh.Name = "TB_Mesh";
            this.TB_Mesh.Size = new System.Drawing.Size(311, 20);
            this.TB_Mesh.TabIndex = 4;
            this.TB_Mesh.TextChanged += new System.EventHandler(this.TB_Mesh_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thumbnail:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // TB_EntryName
            // 
            this.TB_EntryName.Enabled = false;
            this.TB_EntryName.Location = new System.Drawing.Point(90, 20);
            this.TB_EntryName.Name = "TB_EntryName";
            this.TB_EntryName.Size = new System.Drawing.Size(131, 20);
            this.TB_EntryName.TabIndex = 0;
            this.TB_EntryName.TextChanged += new System.EventHandler(this.TB_EntryName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_HideHair);
            this.groupBox1.Controls.Add(this.CB_HideFace);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.NUD_Z);
            this.groupBox1.Controls.Add(this.NUD_Y);
            this.groupBox1.Controls.Add(this.NUD_X);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TB_CheckFlag);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.TB_Thumbnail);
            this.groupBox1.Controls.Add(this.Mesh_Path);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.Thumbnail_Path);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_Mesh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TB_EntryName);
            this.groupBox1.Location = new System.Drawing.Point(162, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 273);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Section";
            // 
            // CB_HideHair
            // 
            this.CB_HideHair.AutoSize = true;
            this.CB_HideHair.Enabled = false;
            this.CB_HideHair.Location = new System.Drawing.Point(90, 217);
            this.CB_HideHair.Name = "CB_HideHair";
            this.CB_HideHair.Size = new System.Drawing.Size(15, 14);
            this.CB_HideHair.TabIndex = 26;
            this.CB_HideHair.UseVisualStyleBackColor = true;
            this.CB_HideHair.CheckedChanged += new System.EventHandler(this.CB_HideHair_CheckedChanged);
            // 
            // CB_HideFace
            // 
            this.CB_HideFace.AutoSize = true;
            this.CB_HideFace.Enabled = false;
            this.CB_HideFace.Location = new System.Drawing.Point(90, 193);
            this.CB_HideFace.Name = "CB_HideFace";
            this.CB_HideFace.Size = new System.Drawing.Size(15, 14);
            this.CB_HideFace.TabIndex = 25;
            this.CB_HideFace.UseVisualStyleBackColor = true;
            this.CB_HideFace.CheckedChanged += new System.EventHandler(this.CB_HideFace_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(255, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Z";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(171, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(87, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "X";
            // 
            // NUD_Z
            // 
            this.NUD_Z.Enabled = false;
            this.NUD_Z.Location = new System.Drawing.Point(273, 164);
            this.NUD_Z.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUD_Z.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.NUD_Z.Name = "NUD_Z";
            this.NUD_Z.Size = new System.Drawing.Size(65, 20);
            this.NUD_Z.TabIndex = 21;
            this.NUD_Z.ValueChanged += new System.EventHandler(this.NUD_Z_ValueChanged);
            // 
            // NUD_Y
            // 
            this.NUD_Y.Enabled = false;
            this.NUD_Y.Location = new System.Drawing.Point(188, 164);
            this.NUD_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUD_Y.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.NUD_Y.Name = "NUD_Y";
            this.NUD_Y.Size = new System.Drawing.Size(65, 20);
            this.NUD_Y.TabIndex = 20;
            this.NUD_Y.ValueChanged += new System.EventHandler(this.NUD_Y_ValueChanged);
            // 
            // NUD_X
            // 
            this.NUD_X.Enabled = false;
            this.NUD_X.Location = new System.Drawing.Point(104, 164);
            this.NUD_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUD_X.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.NUD_X.Name = "NUD_X";
            this.NUD_X.Size = new System.Drawing.Size(65, 20);
            this.NUD_X.TabIndex = 19;
            this.NUD_X.ValueChanged += new System.EventHandler(this.NUD_X_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Hide Hair:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Hide Face:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Offset:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Check Flag:";
            // 
            // TB_CheckFlag
            // 
            this.TB_CheckFlag.Enabled = false;
            this.TB_CheckFlag.Location = new System.Drawing.Point(90, 138);
            this.TB_CheckFlag.Name = "TB_CheckFlag";
            this.TB_CheckFlag.Size = new System.Drawing.Size(131, 20);
            this.TB_CheckFlag.TabIndex = 11;
            this.TB_CheckFlag.TextChanged += new System.EventHandler(this.TB_CheckFlag_TextChanged);
            // 
            // MaskEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "MaskEditor";
            this.Size = new System.Drawing.Size(634, 283);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_X)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox TB_Thumbnail;
        private System.Windows.Forms.Label Mesh_Path;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label Thumbnail_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Mesh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_EntryName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_CheckFlag;
        private System.Windows.Forms.CheckBox CB_HideHair;
        private System.Windows.Forms.CheckBox CB_HideFace;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NUD_Z;
        private System.Windows.Forms.NumericUpDown NUD_Y;
        private System.Windows.Forms.NumericUpDown NUD_X;
    }
}
