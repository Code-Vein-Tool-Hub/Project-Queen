namespace Project_Queen.GUI.Controls
{
    partial class InnerEditor
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.button8 = new System.Windows.Forms.Button();
            this.HideThumbnail_Path = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_HideThumbnail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EnableColour7 = new System.Windows.Forms.CheckBox();
            this.EnableColour6 = new System.Windows.Forms.CheckBox();
            this.EnableColour5 = new System.Windows.Forms.CheckBox();
            this.EnableColour4 = new System.Windows.Forms.CheckBox();
            this.EnableColour3 = new System.Windows.Forms.CheckBox();
            this.EnableColour2 = new System.Windows.Forms.CheckBox();
            this.EnableColour1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(153, 356);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(3, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Add_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(84, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Remove_Click);
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(463, 142);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Section";
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
            this.TB_Thumbnail.Location = new System.Drawing.Point(81, 66);
            this.TB_Thumbnail.Name = "TB_Thumbnail";
            this.TB_Thumbnail.Size = new System.Drawing.Size(320, 20);
            this.TB_Thumbnail.TabIndex = 2;
            this.TB_Thumbnail.TextChanged += new System.EventHandler(this.TB_Thumbnail_TextChanged);
            // 
            // Mesh_Path
            // 
            this.Mesh_Path.AutoSize = true;
            this.Mesh_Path.Location = new System.Drawing.Point(78, 94);
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
            this.Thumbnail_Path.Location = new System.Drawing.Point(78, 50);
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
            this.TB_Mesh.Location = new System.Drawing.Point(81, 112);
            this.TB_Mesh.Name = "TB_Mesh";
            this.TB_Mesh.Size = new System.Drawing.Size(320, 20);
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
            this.TB_EntryName.Location = new System.Drawing.Point(81, 20);
            this.TB_EntryName.Name = "TB_EntryName";
            this.TB_EntryName.Size = new System.Drawing.Size(131, 20);
            this.TB_EntryName.TabIndex = 0;
            this.TB_EntryName.TextChanged += new System.EventHandler(this.TB_EntryName_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(58, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Color 7";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(58, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Color 6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(58, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Color 5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Color 4";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Location = new System.Drawing.Point(27, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Color 3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(27, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Enabled = false;
            this.pictureBox7.Location = new System.Drawing.Point(27, 205);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(25, 25);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 12;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Color 2";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Location = new System.Drawing.Point(27, 81);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Color 1";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox6.Enabled = false;
            this.pictureBox6.Location = new System.Drawing.Point(27, 174);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(25, 25);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Enabled = false;
            this.pictureBox4.Location = new System.Drawing.Point(27, 112);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Location = new System.Drawing.Point(27, 143);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 25);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.treeView2);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.HideThumbnail_Path);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.TB_HideThumbnail);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(286, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 237);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hide Options";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "HidePartsA",
            "HidePartsB",
            "HidePartsC",
            "HidePartsD",
            "HidePartsE",
            "HidePartsF",
            "HidePartsG",
            "HidePartsH"});
            this.comboBox1.Location = new System.Drawing.Point(173, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // treeView2
            // 
            this.treeView2.Enabled = false;
            this.treeView2.Location = new System.Drawing.Point(6, 19);
            this.treeView2.Name = "treeView2";
            this.treeView2.ShowLines = false;
            this.treeView2.ShowRootLines = false;
            this.treeView2.Size = new System.Drawing.Size(111, 149);
            this.treeView2.TabIndex = 18;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(308, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(25, 25);
            this.button8.TabIndex = 17;
            this.button8.Text = "?";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // HideThumbnail_Path
            // 
            this.HideThumbnail_Path.AutoSize = true;
            this.HideThumbnail_Path.Location = new System.Drawing.Point(3, 188);
            this.HideThumbnail_Path.Name = "HideThumbnail_Path";
            this.HideThumbnail_Path.Size = new System.Drawing.Size(29, 13);
            this.HideThumbnail_Path.TabIndex = 15;
            this.HideThumbnail_Path.Text = "Path";
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(277, 202);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 20);
            this.button7.TabIndex = 14;
            this.button7.Text = "...";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 13;
            this.label13.Text = "Thumbnail:";
            // 
            // TB_HideThumbnail
            // 
            this.TB_HideThumbnail.Enabled = false;
            this.TB_HideThumbnail.Location = new System.Drawing.Point(6, 203);
            this.TB_HideThumbnail.Name = "TB_HideThumbnail";
            this.TB_HideThumbnail.Size = new System.Drawing.Size(265, 20);
            this.TB_HideThumbnail.TabIndex = 12;
            this.TB_HideThumbnail.TextChanged += new System.EventHandler(this.TB_HideThumbnail_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(123, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 11;
            this.label11.Text = "Name:";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(173, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(61, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Remove";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(123, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(44, 23);
            this.button6.TabIndex = 3;
            this.button6.Text = "Add";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.EnableColour7);
            this.groupBox3.Controls.Add(this.EnableColour6);
            this.groupBox3.Controls.Add(this.EnableColour5);
            this.groupBox3.Controls.Add(this.EnableColour4);
            this.groupBox3.Controls.Add(this.EnableColour3);
            this.groupBox3.Controls.Add(this.EnableColour2);
            this.groupBox3.Controls.Add(this.EnableColour1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.pictureBox7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.pictureBox5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.pictureBox4);
            this.groupBox3.Controls.Add(this.pictureBox6);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Location = new System.Drawing.Point(162, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 237);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Default Colors";
            // 
            // EnableColour7
            // 
            this.EnableColour7.AutoSize = true;
            this.EnableColour7.Enabled = false;
            this.EnableColour7.Location = new System.Drawing.Point(7, 205);
            this.EnableColour7.Name = "EnableColour7";
            this.EnableColour7.Size = new System.Drawing.Size(15, 14);
            this.EnableColour7.TabIndex = 25;
            this.EnableColour7.UseVisualStyleBackColor = true;
            this.EnableColour7.CheckedChanged += new System.EventHandler(this.EnableColour_CheckedChanged);
            // 
            // EnableColour6
            // 
            this.EnableColour6.AutoSize = true;
            this.EnableColour6.Enabled = false;
            this.EnableColour6.Location = new System.Drawing.Point(7, 174);
            this.EnableColour6.Name = "EnableColour6";
            this.EnableColour6.Size = new System.Drawing.Size(15, 14);
            this.EnableColour6.TabIndex = 24;
            this.EnableColour6.UseVisualStyleBackColor = true;
            this.EnableColour6.CheckedChanged += new System.EventHandler(this.EnableColour_CheckedChanged);
            // 
            // EnableColour5
            // 
            this.EnableColour5.AutoSize = true;
            this.EnableColour5.Enabled = false;
            this.EnableColour5.Location = new System.Drawing.Point(7, 143);
            this.EnableColour5.Name = "EnableColour5";
            this.EnableColour5.Size = new System.Drawing.Size(15, 14);
            this.EnableColour5.TabIndex = 23;
            this.EnableColour5.UseVisualStyleBackColor = true;
            this.EnableColour5.CheckedChanged += new System.EventHandler(this.EnableColour_CheckedChanged);
            // 
            // EnableColour4
            // 
            this.EnableColour4.AutoSize = true;
            this.EnableColour4.Enabled = false;
            this.EnableColour4.Location = new System.Drawing.Point(7, 112);
            this.EnableColour4.Name = "EnableColour4";
            this.EnableColour4.Size = new System.Drawing.Size(15, 14);
            this.EnableColour4.TabIndex = 22;
            this.EnableColour4.UseVisualStyleBackColor = true;
            this.EnableColour4.CheckedChanged += new System.EventHandler(this.EnableColour_CheckedChanged);
            // 
            // EnableColour3
            // 
            this.EnableColour3.AutoSize = true;
            this.EnableColour3.Enabled = false;
            this.EnableColour3.Location = new System.Drawing.Point(7, 81);
            this.EnableColour3.Name = "EnableColour3";
            this.EnableColour3.Size = new System.Drawing.Size(15, 14);
            this.EnableColour3.TabIndex = 21;
            this.EnableColour3.UseVisualStyleBackColor = true;
            this.EnableColour3.CheckedChanged += new System.EventHandler(this.EnableColour_CheckedChanged);
            // 
            // EnableColour2
            // 
            this.EnableColour2.AutoSize = true;
            this.EnableColour2.Enabled = false;
            this.EnableColour2.Location = new System.Drawing.Point(7, 50);
            this.EnableColour2.Name = "EnableColour2";
            this.EnableColour2.Size = new System.Drawing.Size(15, 14);
            this.EnableColour2.TabIndex = 20;
            this.EnableColour2.UseVisualStyleBackColor = true;
            this.EnableColour2.CheckedChanged += new System.EventHandler(this.EnableColour_CheckedChanged);
            // 
            // EnableColour1
            // 
            this.EnableColour1.AutoSize = true;
            this.EnableColour1.Enabled = false;
            this.EnableColour1.Location = new System.Drawing.Point(7, 19);
            this.EnableColour1.Name = "EnableColour1";
            this.EnableColour1.Size = new System.Drawing.Size(15, 14);
            this.EnableColour1.TabIndex = 0;
            this.EnableColour1.UseVisualStyleBackColor = true;
            this.EnableColour1.CheckedChanged += new System.EventHandler(this.EnableColour_CheckedChanged);
            // 
            // InnerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "InnerEditor";
            this.Size = new System.Drawing.Size(631, 395);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Mesh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Thumbnail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_EntryName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox EnableColour7;
        private System.Windows.Forms.CheckBox EnableColour6;
        private System.Windows.Forms.CheckBox EnableColour5;
        private System.Windows.Forms.CheckBox EnableColour4;
        private System.Windows.Forms.CheckBox EnableColour3;
        private System.Windows.Forms.CheckBox EnableColour2;
        private System.Windows.Forms.CheckBox EnableColour1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label Thumbnail_Path;
        private System.Windows.Forms.Label Mesh_Path;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label HideThumbnail_Path;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TB_HideThumbnail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
