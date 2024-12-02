namespace junpro_responsi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cbDept = new ComboBox();
            cbJabatan = new ComboBox();
            tbNama = new TextBox();
            btnInsert = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvData = new DataGridView();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 105);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Nama Karyawan:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 145);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 1;
            label2.Text = "Dept. Karyawan:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 185);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 2;
            label3.Text = "Jabatan Karyawan:";
            // 
            // cbDept
            // 
            cbDept.FormattingEnabled = true;
            cbDept.Location = new Point(180, 142);
            cbDept.Name = "cbDept";
            cbDept.Size = new Size(173, 23);
            cbDept.TabIndex = 3;
            // 
            // cbJabatan
            // 
            cbJabatan.FormattingEnabled = true;
            cbJabatan.Location = new Point(180, 182);
            cbJabatan.Name = "cbJabatan";
            cbJabatan.Size = new Size(173, 23);
            cbJabatan.TabIndex = 4;
            // 
            // tbNama
            // 
            tbNama.Location = new Point(180, 102);
            tbNama.Name = "tbNama";
            tbNama.Size = new Size(173, 23);
            tbNama.TabIndex = 5;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(48, 236);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(133, 23);
            btnInsert.TabIndex = 6;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(237, 236);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(133, 23);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(406, 236);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(133, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvData
            // 
            dgvData.BackgroundColor = SystemColors.ButtonHighlight;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(30, 277);
            dgvData.Name = "dgvData";
            dgvData.Size = new Size(509, 161);
            dgvData.TabIndex = 9;
            dgvData.CellClick += dgvData_CellClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.IndianRed;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(426, 85);
            label4.Name = "label4";
            label4.Size = new Size(90, 120);
            label4.TabIndex = 10;
            label4.Text = "\r\nID Departemen:\r\nHR : HR\r\nENG : Engineer\r\nDEV : Developer\r\nPM : Product M\r\nFIN : Finance\r\n\r\n";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(56, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 49);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Brown;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(138, 44);
            label5.Name = "label5";
            label5.Size = new Size(365, 21);
            label5.TabIndex = 12;
            label5.Text = "   McDonald's Employee Management System  \r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(569, 450);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(dgvData);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnInsert);
            Controls.Add(tbNama);
            Controls.Add(cbJabatan);
            Controls.Add(cbDept);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cbDept;
        private ComboBox cbJabatan;
        private TextBox tbNama;
        private Button btnInsert;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvData;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label5;
    }
}
