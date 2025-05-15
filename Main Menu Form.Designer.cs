namespace Student_Record_Management_System
{
    partial class Main_Menu_Form
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnAdd = new Button();
            btnView = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(90, 21);
            label1.Name = "label1";
            label1.Size = new Size(341, 24);
            label1.TabIndex = 0;
            label1.Text = "Student Record Management System";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.images1;
            pictureBox1.Location = new Point(120, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(262, 168);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LimeGreen;
            btnAdd.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(12, 262);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 31);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Student";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnView
            // 
            btnView.BackColor = Color.Crimson;
            btnView.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnView.Location = new Point(133, 262);
            btnView.Name = "btnView";
            btnView.Size = new Size(122, 31);
            btnView.TabIndex = 3;
            btnView.Text = "View students";
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Yellow;
            btnEdit.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.Location = new Point(261, 262);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(110, 31);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit student";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DodgerBlue;
            btnDelete.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(381, 262);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 31);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete student";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 299);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(489, 219);
            dataGridView1.TabIndex = 6;
            // 
            // Main_Menu_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(513, 530);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnView);
            Controls.Add(btnAdd);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Main_Menu_Form";
            Text = "Main_Menu_Form";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Button btnAdd;
        private Button btnView;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dataGridView1;
    }
}