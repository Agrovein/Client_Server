
namespace Client_Server
{
    partial class Test_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test_Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sendAnswersBTN = new System.Windows.Forms.Button();
            this.startedTestBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.startTestingBTN = new System.Windows.Forms.Button();
            this.openTestBTN = new System.Windows.Forms.Button();
            this.refreshListBTN = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bookPageBTN = new System.Windows.Forms.Button();
            this.loginPageBTN = new System.Windows.Forms.Button();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.Question_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answer_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fullName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sendAnswersBTN);
            this.groupBox1.Controls.Add(this.startedTestBox);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.startTestingBTN);
            this.groupBox1.Controls.Add(this.openTestBTN);
            this.groupBox1.Controls.Add(this.refreshListBTN);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(5, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 672);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тест";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(421, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Дайте відповідь на всі питання в таблиці нижче і натисніть \"Відправити відповідь\"" +
    "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Виберіть тест зі списку і натисніть \"Почати Тест\"";
            // 
            // fullName
            // 
            this.fullName.Location = new System.Drawing.Point(120, 176);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(243, 20);
            this.fullName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Введіть ваш ПІБ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ім’я початого Теста";
            // 
            // sendAnswersBTN
            // 
            this.sendAnswersBTN.Location = new System.Drawing.Point(120, 423);
            this.sendAnswersBTN.Name = "sendAnswersBTN";
            this.sendAnswersBTN.Size = new System.Drawing.Size(243, 24);
            this.sendAnswersBTN.TabIndex = 6;
            this.sendAnswersBTN.Text = "Відправити відповідь";
            this.sendAnswersBTN.UseVisualStyleBackColor = true;
            this.sendAnswersBTN.Click += new System.EventHandler(this.sendAnswersBTN_Click);
            // 
            // startedTestBox
            // 
            this.startedTestBox.Location = new System.Drawing.Point(120, 144);
            this.startedTestBox.Name = "startedTestBox";
            this.startedTestBox.ReadOnly = true;
            this.startedTestBox.Size = new System.Drawing.Size(243, 20);
            this.startedTestBox.TabIndex = 5;
            this.startedTestBox.TextChanged += new System.EventHandler(this.startedTestBox_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Question_No,
            this.Answer_Value});
            this.dataGridView1.Location = new System.Drawing.Point(120, 225);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(243, 192);
            this.dataGridView1.TabIndex = 4;
            // 
            // startTestingBTN
            // 
            this.startTestingBTN.Location = new System.Drawing.Point(120, 114);
            this.startTestingBTN.Name = "startTestingBTN";
            this.startTestingBTN.Size = new System.Drawing.Size(243, 24);
            this.startTestingBTN.TabIndex = 3;
            this.startTestingBTN.Text = "Почати Тест";
            this.startTestingBTN.UseVisualStyleBackColor = true;
            this.startTestingBTN.Click += new System.EventHandler(this.startTestingBTN_Click);
            // 
            // openTestBTN
            // 
            this.openTestBTN.Location = new System.Drawing.Point(238, 19);
            this.openTestBTN.Name = "openTestBTN";
            this.openTestBTN.Size = new System.Drawing.Size(222, 23);
            this.openTestBTN.TabIndex = 2;
            this.openTestBTN.Text = "Відкрити обраний тест";
            this.openTestBTN.UseVisualStyleBackColor = true;
            this.openTestBTN.Click += new System.EventHandler(this.openTestBTN_Click);
            // 
            // refreshListBTN
            // 
            this.refreshListBTN.Location = new System.Drawing.Point(7, 19);
            this.refreshListBTN.Name = "refreshListBTN";
            this.refreshListBTN.Size = new System.Drawing.Size(222, 23);
            this.refreshListBTN.TabIndex = 2;
            this.refreshListBTN.Text = "Оновити список";
            this.refreshListBTN.UseVisualStyleBackColor = true;
            this.refreshListBTN.Click += new System.EventHandler(this.refreshListBTN_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(453, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Натисніть кнопку \"Оновити список\" для подальших дій";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bookPageBTN);
            this.groupBox2.Controls.Add(this.loginPageBTN);
            this.groupBox2.Location = new System.Drawing.Point(5, 687);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 179);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Кнопки навігації по сторінкам";
            // 
            // bookPageBTN
            // 
            this.bookPageBTN.Location = new System.Drawing.Point(244, 84);
            this.bookPageBTN.Name = "bookPageBTN";
            this.bookPageBTN.Size = new System.Drawing.Size(222, 23);
            this.bookPageBTN.TabIndex = 1;
            this.bookPageBTN.Text = "Сторінка книг";
            this.bookPageBTN.UseVisualStyleBackColor = true;
            this.bookPageBTN.Click += new System.EventHandler(this.bookPageBTN_Click);
            // 
            // loginPageBTN
            // 
            this.loginPageBTN.Location = new System.Drawing.Point(7, 84);
            this.loginPageBTN.Name = "loginPageBTN";
            this.loginPageBTN.Size = new System.Drawing.Size(222, 23);
            this.loginPageBTN.TabIndex = 0;
            this.loginPageBTN.Text = "Сторінка авторизації";
            this.loginPageBTN.UseVisualStyleBackColor = true;
            this.loginPageBTN.Click += new System.EventHandler(this.loginPageBTN_Click);
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(483, 8);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(785, 858);
            this.axAcroPDF1.TabIndex = 0;
            // 
            // Question_No
            // 
            this.Question_No.HeaderText = "Питання №";
            this.Question_No.Name = "Question_No";
            this.Question_No.ReadOnly = true;
            // 
            // Answer_Value
            // 
            this.Answer_Value.HeaderText = "Ваша відповідь";
            this.Answer_Value.Name = "Answer_Value";
            // 
            // Test_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1271, 878);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axAcroPDF1);
            this.Name = "Test_Form";
            this.Text = "Test_Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button loginPageBTN;
        private System.Windows.Forms.Button bookPageBTN;
        private System.Windows.Forms.Button openTestBTN;
        private System.Windows.Forms.Button refreshListBTN;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button startTestingBTN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox fullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendAnswersBTN;
        private System.Windows.Forms.TextBox startedTestBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Question_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Answer_Value;
    }
}