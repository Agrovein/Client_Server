
namespace Client_Server
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.browseFileBTN = new System.Windows.Forms.Button();
            this.addNewBookBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bookName = new System.Windows.Forms.TextBox();
            this.path = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.refreshListBTN = new System.Windows.Forms.Button();
            this.openBookBTN = new System.Windows.Forms.Button();
            this.testName = new System.Windows.Forms.TextBox();
            this.questionAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.testBrowseFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.addNewTest = new System.Windows.Forms.Button();
            this.textListBTN = new System.Windows.Forms.Button();
            this.openTestBTN = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.removeBookBTN = new System.Windows.Forms.Button();
            this.removeTestBTN = new System.Windows.Forms.Button();
            this.bookPageBTN = new System.Windows.Forms.Button();
            this.testPageBTN = new System.Windows.Forms.Button();
            this.loginPageBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.generateQuestionBTN = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.Question_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answer_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // browseFileBTN
            // 
            this.browseFileBTN.Location = new System.Drawing.Point(101, 71);
            this.browseFileBTN.Name = "browseFileBTN";
            this.browseFileBTN.Size = new System.Drawing.Size(141, 23);
            this.browseFileBTN.TabIndex = 0;
            this.browseFileBTN.Text = "Вибрати файл";
            this.browseFileBTN.UseVisualStyleBackColor = true;
            this.browseFileBTN.Click += new System.EventHandler(this.browseFileBTN_Click);
            // 
            // addNewBookBTN
            // 
            this.addNewBookBTN.Location = new System.Drawing.Point(248, 71);
            this.addNewBookBTN.Name = "addNewBookBTN";
            this.addNewBookBTN.Size = new System.Drawing.Size(141, 23);
            this.addNewBookBTN.TabIndex = 1;
            this.addNewBookBTN.Text = "Додати нову книгу";
            this.addNewBookBTN.UseVisualStyleBackColor = true;
            this.addNewBookBTN.Click += new System.EventHandler(this.addNewBookBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Назва книги";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Шлях до файлу";
            // 
            // bookName
            // 
            this.bookName.Location = new System.Drawing.Point(101, 19);
            this.bookName.Name = "bookName";
            this.bookName.Size = new System.Drawing.Size(288, 20);
            this.bookName.TabIndex = 4;
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(101, 45);
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Size = new System.Drawing.Size(288, 20);
            this.path.TabIndex = 5;
            this.path.TextChanged += new System.EventHandler(this.path_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownHeight = 200;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(9, 129);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(495, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Text = "Натисніть на кнопку \"Оновити список\" для подальших дій";
            // 
            // refreshListBTN
            // 
            this.refreshListBTN.Location = new System.Drawing.Point(9, 100);
            this.refreshListBTN.Name = "refreshListBTN";
            this.refreshListBTN.Size = new System.Drawing.Size(161, 23);
            this.refreshListBTN.TabIndex = 11;
            this.refreshListBTN.Text = "Оновити список";
            this.refreshListBTN.UseVisualStyleBackColor = true;
            this.refreshListBTN.Click += new System.EventHandler(this.refreshListBTN_Click);
            // 
            // openBookBTN
            // 
            this.openBookBTN.Location = new System.Drawing.Point(176, 100);
            this.openBookBTN.Name = "openBookBTN";
            this.openBookBTN.Size = new System.Drawing.Size(161, 23);
            this.openBookBTN.TabIndex = 12;
            this.openBookBTN.Text = "Відкрити обрану книгу";
            this.openBookBTN.UseVisualStyleBackColor = true;
            this.openBookBTN.Click += new System.EventHandler(this.openBookBTN_Click);
            // 
            // testName
            // 
            this.testName.Location = new System.Drawing.Point(99, 19);
            this.testName.Name = "testName";
            this.testName.Size = new System.Drawing.Size(288, 20);
            this.testName.TabIndex = 13;
            // 
            // questionAmount
            // 
            this.questionAmount.Location = new System.Drawing.Point(142, 74);
            this.questionAmount.Name = "questionAmount";
            this.questionAmount.Size = new System.Drawing.Size(98, 20);
            this.questionAmount.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Назва тесту";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Кіль-ть питань у тесті";
            // 
            // testBrowseFile
            // 
            this.testBrowseFile.Location = new System.Drawing.Point(99, 100);
            this.testBrowseFile.Name = "testBrowseFile";
            this.testBrowseFile.ReadOnly = true;
            this.testBrowseFile.Size = new System.Drawing.Size(288, 20);
            this.testBrowseFile.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Шлях до файлу";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Вибрати файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addNewTest
            // 
            this.addNewTest.Location = new System.Drawing.Point(246, 126);
            this.addNewTest.Name = "addNewTest";
            this.addNewTest.Size = new System.Drawing.Size(141, 23);
            this.addNewTest.TabIndex = 20;
            this.addNewTest.Text = "Додати новий тест";
            this.addNewTest.UseVisualStyleBackColor = true;
            this.addNewTest.Click += new System.EventHandler(this.addNewTest_Click);
            // 
            // textListBTN
            // 
            this.textListBTN.Location = new System.Drawing.Point(8, 155);
            this.textListBTN.Name = "textListBTN";
            this.textListBTN.Size = new System.Drawing.Size(161, 23);
            this.textListBTN.TabIndex = 21;
            this.textListBTN.Text = "Оновити список";
            this.textListBTN.UseVisualStyleBackColor = true;
            this.textListBTN.Click += new System.EventHandler(this.textListBTN_Click);
            // 
            // openTestBTN
            // 
            this.openTestBTN.Location = new System.Drawing.Point(176, 155);
            this.openTestBTN.Name = "openTestBTN";
            this.openTestBTN.Size = new System.Drawing.Size(161, 23);
            this.openTestBTN.TabIndex = 22;
            this.openTestBTN.Text = "Відкрити обраний тест";
            this.openTestBTN.UseVisualStyleBackColor = true;
            this.openTestBTN.Click += new System.EventHandler(this.openTestBTN_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownHeight = 180;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.IntegralHeight = false;
            this.comboBox2.Location = new System.Drawing.Point(8, 184);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(496, 21);
            this.comboBox2.TabIndex = 23;
            this.comboBox2.Text = "Натисніть на кнопку \"Оновити список\" для подальших дій";
            // 
            // removeBookBTN
            // 
            this.removeBookBTN.Location = new System.Drawing.Point(343, 100);
            this.removeBookBTN.Name = "removeBookBTN";
            this.removeBookBTN.Size = new System.Drawing.Size(161, 23);
            this.removeBookBTN.TabIndex = 24;
            this.removeBookBTN.Text = "Видалити обрану книгу";
            this.removeBookBTN.UseVisualStyleBackColor = true;
            this.removeBookBTN.Click += new System.EventHandler(this.removeBookBTN_Click);
            // 
            // removeTestBTN
            // 
            this.removeTestBTN.Location = new System.Drawing.Point(343, 155);
            this.removeTestBTN.Name = "removeTestBTN";
            this.removeTestBTN.Size = new System.Drawing.Size(161, 23);
            this.removeTestBTN.TabIndex = 25;
            this.removeTestBTN.Text = "Видалити обраний тест";
            this.removeTestBTN.UseVisualStyleBackColor = true;
            this.removeTestBTN.Click += new System.EventHandler(this.removeTestBTN_Click);
            // 
            // bookPageBTN
            // 
            this.bookPageBTN.Location = new System.Drawing.Point(0, 19);
            this.bookPageBTN.Name = "bookPageBTN";
            this.bookPageBTN.Size = new System.Drawing.Size(242, 23);
            this.bookPageBTN.TabIndex = 26;
            this.bookPageBTN.Text = "Сторінка книг";
            this.bookPageBTN.UseVisualStyleBackColor = true;
            this.bookPageBTN.Click += new System.EventHandler(this.bookPageBTN_Click);
            // 
            // testPageBTN
            // 
            this.testPageBTN.Location = new System.Drawing.Point(268, 19);
            this.testPageBTN.Name = "testPageBTN";
            this.testPageBTN.Size = new System.Drawing.Size(236, 23);
            this.testPageBTN.TabIndex = 27;
            this.testPageBTN.Text = "Сторінка тестів";
            this.testPageBTN.UseVisualStyleBackColor = true;
            this.testPageBTN.Click += new System.EventHandler(this.testPageBTN_Click);
            // 
            // loginPageBTN
            // 
            this.loginPageBTN.Location = new System.Drawing.Point(0, 48);
            this.loginPageBTN.Name = "loginPageBTN";
            this.loginPageBTN.Size = new System.Drawing.Size(504, 23);
            this.loginPageBTN.TabIndex = 28;
            this.loginPageBTN.Text = "Сторінка авторизації";
            this.loginPageBTN.UseVisualStyleBackColor = true;
            this.loginPageBTN.Click += new System.EventHandler(this.loginPageBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bookName);
            this.groupBox1.Controls.Add(this.path);
            this.groupBox1.Controls.Add(this.browseFileBTN);
            this.groupBox1.Controls.Add(this.removeBookBTN);
            this.groupBox1.Controls.Add(this.addNewBookBTN);
            this.groupBox1.Controls.Add(this.refreshListBTN);
            this.groupBox1.Controls.Add(this.openBookBTN);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 365);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Книга";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.generateQuestionBTN);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.testName);
            this.groupBox2.Controls.Add(this.questionAmount);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.removeTestBTN);
            this.groupBox2.Controls.Add(this.textListBTN);
            this.groupBox2.Controls.Add(this.openTestBTN);
            this.groupBox2.Controls.Add(this.testBrowseFile);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.addNewTest);
            this.groupBox2.Location = new System.Drawing.Point(12, 381);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 365);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тест";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(387, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Введіть кіль-ть питань в поле нижче та натисніть на \"Генерувати таблицю\"";
            // 
            // generateQuestionBTN
            // 
            this.generateQuestionBTN.Location = new System.Drawing.Point(246, 72);
            this.generateQuestionBTN.Name = "generateQuestionBTN";
            this.generateQuestionBTN.Size = new System.Drawing.Size(141, 23);
            this.generateQuestionBTN.TabIndex = 27;
            this.generateQuestionBTN.Text = "Генерувати таблицю";
            this.generateQuestionBTN.UseVisualStyleBackColor = true;
            this.generateQuestionBTN.Click += new System.EventHandler(this.generateQuestionBTN_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Question_No,
            this.Answer_Value});
            this.dataGridView1.Location = new System.Drawing.Point(114, 221);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(245, 106);
            this.dataGridView1.TabIndex = 26;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.loginPageBTN);
            this.groupBox3.Controls.Add(this.testPageBTN);
            this.groupBox3.Controls.Add(this.bookPageBTN);
            this.groupBox3.Location = new System.Drawing.Point(12, 752);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 86);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Кнопки навігації по сторінкам";
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(528, 5);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(785, 858);
            this.axAcroPDF1.TabIndex = 6;
            // 
            // Question_No
            // 
            this.Question_No.HeaderText = "Питання №";
            this.Question_No.Name = "Question_No";
            this.Question_No.ReadOnly = true;
            // 
            // Answer_Value
            // 
            this.Answer_Value.HeaderText = "Правильна відповідь";
            this.Answer_Value.Name = "Answer_Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1317, 878);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axAcroPDF1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button browseFileBTN;
        private System.Windows.Forms.Button addNewBookBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bookName;
        private System.Windows.Forms.TextBox path;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button refreshListBTN;
        private System.Windows.Forms.Button openBookBTN;
        private System.Windows.Forms.TextBox testName;
        private System.Windows.Forms.TextBox questionAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox testBrowseFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addNewTest;
        private System.Windows.Forms.Button textListBTN;
        private System.Windows.Forms.Button openTestBTN;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button removeBookBTN;
        private System.Windows.Forms.Button removeTestBTN;
        private System.Windows.Forms.Button bookPageBTN;
        private System.Windows.Forms.Button testPageBTN;
        private System.Windows.Forms.Button loginPageBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button generateQuestionBTN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Question_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Answer_Value;
    }
}

