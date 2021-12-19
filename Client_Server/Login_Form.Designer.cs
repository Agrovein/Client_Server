
namespace Client_Server
{
    partial class Login_Form
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
            this.loginBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginUserBTN = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.refreshDataBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchBTN = new System.Windows.Forms.Button();
            this.Test_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentStats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Questions_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(489, 520);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(339, 20);
            this.loginBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(489, 546);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(339, 20);
            this.passwordBox.TabIndex = 1;
            // 
            // loginUserBTN
            // 
            this.loginUserBTN.Location = new System.Drawing.Point(551, 572);
            this.loginUserBTN.Name = "loginUserBTN";
            this.loginUserBTN.Size = new System.Drawing.Size(214, 28);
            this.loginUserBTN.TabIndex = 2;
            this.loginUserBTN.Text = "Авторизуватись";
            this.loginUserBTN.UseVisualStyleBackColor = true;
            this.loginUserBTN.Click += new System.EventHandler(this.loginUserBTN_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Test_Name,
            this.studentName,
            this.studentStats,
            this.Questions_Count});
            this.dataGridView1.Location = new System.Drawing.Point(318, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(667, 282);
            this.dataGridView1.TabIndex = 3;
            // 
            // refreshDataBTN
            // 
            this.refreshDataBTN.Location = new System.Drawing.Point(318, 119);
            this.refreshDataBTN.Name = "refreshDataBTN";
            this.refreshDataBTN.Size = new System.Drawing.Size(112, 22);
            this.refreshDataBTN.TabIndex = 4;
            this.refreshDataBTN.Text = "Оновити таблицю";
            this.refreshDataBTN.UseVisualStyleBackColor = true;
            this.refreshDataBTN.Click += new System.EventHandler(this.refreshDataBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Назва тесту або піб студента для пошуку";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(692, 119);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(175, 20);
            this.searchBox.TabIndex = 6;
            // 
            // searchBTN
            // 
            this.searchBTN.Location = new System.Drawing.Point(873, 119);
            this.searchBTN.Name = "searchBTN";
            this.searchBTN.Size = new System.Drawing.Size(112, 22);
            this.searchBTN.TabIndex = 7;
            this.searchBTN.Text = "Знайти";
            this.searchBTN.UseVisualStyleBackColor = true;
            this.searchBTN.Click += new System.EventHandler(this.searchBTN_Click);
            // 
            // Test_Name
            // 
            this.Test_Name.HeaderText = "Назва Тесту";
            this.Test_Name.Name = "Test_Name";
            this.Test_Name.ReadOnly = true;
            this.Test_Name.Width = 200;
            // 
            // studentName
            // 
            this.studentName.HeaderText = "ПІБ Студента";
            this.studentName.Name = "studentName";
            this.studentName.ReadOnly = true;
            this.studentName.Width = 200;
            // 
            // studentStats
            // 
            this.studentStats.HeaderText = "Правильних відповідей у Тесті";
            this.studentStats.Name = "studentStats";
            this.studentStats.ReadOnly = true;
            // 
            // Questions_Count
            // 
            this.Questions_Count.HeaderText = "Кіль-ть питань у Тесті";
            this.Questions_Count.Name = "Questions_Count";
            this.Questions_Count.ReadOnly = true;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1327, 846);
            this.Controls.Add(this.searchBTN);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshDataBTN);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.loginUserBTN);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.loginBox);
            this.Name = "Login_Form";
            this.Text = "Login_Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button loginUserBTN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button refreshDataBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchBTN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Test_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn Questions_Count;
    }
}