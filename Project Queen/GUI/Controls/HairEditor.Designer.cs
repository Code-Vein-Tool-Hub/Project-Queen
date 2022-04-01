namespace Project_Queen.GUI.Controls
{
    partial class HairEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.B_Thumbnail = new System.Windows.Forms.Button();
            this.TB_Thumbnail = new System.Windows.Forms.TextBox();
            this.Mesh_Path = new System.Windows.Forms.Label();
            this.B_Mesh = new System.Windows.Forms.Button();
            this.Thumbnail_Path = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Mesh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_EntryName = new System.Windows.Forms.TextBox();
            this.B_Remove = new System.Windows.Forms.Button();
            this.B_Add = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.B_Thumbnail);
            this.groupBox1.Controls.Add(this.TB_Thumbnail);
            this.groupBox1.Controls.Add(this.Mesh_Path);
            this.groupBox1.Controls.Add(this.B_Mesh);
            this.groupBox1.Controls.Add(this.Thumbnail_Path);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_Mesh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TB_EntryName);
            this.groupBox1.Location = new System.Drawing.Point(162, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 273);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Section";
            // 
            // B_Thumbnail
            // 
            this.B_Thumbnail.Location = new System.Drawing.Point(407, 65);
            this.B_Thumbnail.Name = "B_Thumbnail";
            this.B_Thumbnail.Size = new System.Drawing.Size(50, 20);
            this.B_Thumbnail.TabIndex = 7;
            this.B_Thumbnail.Text = "...";
            this.B_Thumbnail.UseVisualStyleBackColor = true;
            this.B_Thumbnail.Click += new System.EventHandler(this.B_Thumbnail_Click);
            // 
            // TB_Thumbnail
            // 
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
            // B_Mesh
            // 
            this.B_Mesh.Location = new System.Drawing.Point(407, 112);
            this.B_Mesh.Name = "B_Mesh";
            this.B_Mesh.Size = new System.Drawing.Size(50, 20);
            this.B_Mesh.TabIndex = 9;
            this.B_Mesh.Text = "...";
            this.B_Mesh.UseVisualStyleBackColor = true;
            this.B_Mesh.Click += new System.EventHandler(this.B_Mesh_Click);
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
            this.TB_EntryName.Location = new System.Drawing.Point(90, 20);
            this.TB_EntryName.Name = "TB_EntryName";
            this.TB_EntryName.Size = new System.Drawing.Size(131, 20);
            this.TB_EntryName.TabIndex = 0;
            this.TB_EntryName.TextChanged += new System.EventHandler(this.TB_EntryName_TextChanged);
            // 
            // B_Remove
            // 
            this.B_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_Remove.Location = new System.Drawing.Point(84, 253);
            this.B_Remove.Name = "B_Remove";
            this.B_Remove.Size = new System.Drawing.Size(72, 23);
            this.B_Remove.TabIndex = 9;
            this.B_Remove.Text = "Remove";
            this.B_Remove.UseVisualStyleBackColor = true;
            this.B_Remove.Click += new System.EventHandler(this.B_Remove_Click);
            // 
            // B_Add
            // 
            this.B_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_Add.Location = new System.Drawing.Point(3, 253);
            this.B_Add.Name = "B_Add";
            this.B_Add.Size = new System.Drawing.Size(75, 23);
            this.B_Add.TabIndex = 8;
            this.B_Add.Text = "Add";
            this.B_Add.UseVisualStyleBackColor = true;
            this.B_Add.Click += new System.EventHandler(this.B_Add_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(153, 244);
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // HairEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.B_Remove);
            this.Controls.Add(this.B_Add);
            this.Controls.Add(this.treeView1);
            this.Name = "HairEditor";
            this.Size = new System.Drawing.Size(633, 282);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_Thumbnail;
        private System.Windows.Forms.TextBox TB_Thumbnail;
        private System.Windows.Forms.Label Mesh_Path;
        private System.Windows.Forms.Button B_Mesh;
        private System.Windows.Forms.Label Thumbnail_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Mesh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_EntryName;
        private System.Windows.Forms.Button B_Remove;
        private System.Windows.Forms.Button B_Add;
        private System.Windows.Forms.TreeView treeView1;
    }
}
