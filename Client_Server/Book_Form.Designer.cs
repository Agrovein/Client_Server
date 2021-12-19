
namespace Client_Server
{
    partial class Book_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Book_Form));
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.openBookBTN = new System.Windows.Forms.Button();
            this.refreshListBTN = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.testPageBTN = new System.Windows.Forms.Button();
            this.loginPageBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(474, 8);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(785, 858);
            this.axAcroPDF1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.openBookBTN);
            this.groupBox1.Controls.Add(this.refreshListBTN);
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 746);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Книга";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownHeight = 250;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(13, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(435, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Натисніть кнопку \"Оновити список\" для подальших дій";
            // 
            // openBookBTN
            // 
            this.openBookBTN.Location = new System.Drawing.Point(244, 28);
            this.openBookBTN.Name = "openBookBTN";
            this.openBookBTN.Size = new System.Drawing.Size(204, 23);
            this.openBookBTN.TabIndex = 1;
            this.openBookBTN.Text = "Відкрити обрану книгу";
            this.openBookBTN.UseVisualStyleBackColor = true;
            this.openBookBTN.Click += new System.EventHandler(this.openBookBTN_Click);
            // 
            // refreshListBTN
            // 
            this.refreshListBTN.Location = new System.Drawing.Point(13, 28);
            this.refreshListBTN.Name = "refreshListBTN";
            this.refreshListBTN.Size = new System.Drawing.Size(204, 23);
            this.refreshListBTN.TabIndex = 0;
            this.refreshListBTN.Text = "Оновити список";
            this.refreshListBTN.UseVisualStyleBackColor = true;
            this.refreshListBTN.Click += new System.EventHandler(this.refreshListBTN_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.testPageBTN);
            this.groupBox2.Controls.Add(this.loginPageBTN);
            this.groupBox2.Location = new System.Drawing.Point(5, 760);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(463, 106);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Кнопки навігації по сторінкам";
            // 
            // testPageBTN
            // 
            this.testPageBTN.Location = new System.Drawing.Point(244, 43);
            this.testPageBTN.Name = "testPageBTN";
            this.testPageBTN.Size = new System.Drawing.Size(204, 23);
            this.testPageBTN.TabIndex = 1;
            this.testPageBTN.Text = "Сторінка тестів";
            this.testPageBTN.UseVisualStyleBackColor = true;
            this.testPageBTN.Click += new System.EventHandler(this.testPageBTN_Click);
            // 
            // loginPageBTN
            // 
            this.loginPageBTN.Location = new System.Drawing.Point(13, 43);
            this.loginPageBTN.Name = "loginPageBTN";
            this.loginPageBTN.Size = new System.Drawing.Size(204, 23);
            this.loginPageBTN.TabIndex = 0;
            this.loginPageBTN.Text = "Сторінка авторизації";
            this.loginPageBTN.UseVisualStyleBackColor = true;
            this.loginPageBTN.Click += new System.EventHandler(this.loginPageBTN_Click);
            // 
            // Book_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1266, 878);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axAcroPDF1);
            this.Name = "Book_Form";
            this.Text = "Book_Form";
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button openBookBTN;
        private System.Windows.Forms.Button refreshListBTN;
        private System.Windows.Forms.Button testPageBTN;
        private System.Windows.Forms.Button loginPageBTN;
    }
}