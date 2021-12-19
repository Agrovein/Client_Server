using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Server
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }
        private const int port = 8080;
        private const string server = "127.0.0.1";
        private void loginUserBTN_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(loginBox.Text) && !String.IsNullOrEmpty(passwordBox.Text))
            {
                try
                {
                TcpClient client = new TcpClient();
                client.Connect(server, port);
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();
                string fileName = loginBox.Text + ';' + passwordBox.Text + ';' + "userLogin";
                byte[] command = Encoding.UTF8.GetBytes(fileName);
                byte[] commandLength = BitConverter.GetBytes(command.Length);
                byte[] package;
                package = new byte[4 + command.Length];
                commandLength.CopyTo(package, 0);
                command.CopyTo(package, 4);
                stream.Write(package, 0, package.Length);
                package = new byte[128];
                do
                {
                    int bytes = stream.Read(package, 0, package.Length);
                    response.Append(Encoding.UTF8.GetString(package, 0, bytes));
                }
                while (stream.DataAvailable);
                string server_reply = Convert.ToString(response);
                if (server_reply == "teacher")
                {
                    Form1 nextForm = new Form1();
                    this.Hide();
                    nextForm.ShowDialog();
                    this.Close();
                }
                if (server_reply == "student")
                {
                    Book_Form nextForm = new Book_Form();
                    this.Hide();
                    nextForm.ShowDialog();
                    this.Close();
                }
                if (server_reply == "Wrong login or password")
                {
                    MessageBox.Show("Неправильний логін або пароль");
                }
                stream.Close();
                client.Close();
                }
                
                catch (SocketException a)
                {
                    Console.WriteLine("SocketException: {0}", a);
                }
                catch (Exception a)
                {
                    Console.WriteLine("Exception: {0}", a.Message);
                }
            }
            else MessageBox.Show("Введіть логін і пароль");
        }

        private void refreshDataBTN_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                TcpClient client = new TcpClient();
                client.Connect(server, port);
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();
                string select = "TestResults" + ";" + "getTestResults";
                byte[] command = Encoding.UTF8.GetBytes(select);
                byte[] commandLength = BitConverter.GetBytes(command.Length);
                byte[] package;
                package = new byte[4 + command.Length];
                commandLength.CopyTo(package, 0);
                command.CopyTo(package, 4);
                stream.Write(package, 0, package.Length);
                package = new byte[128];
                do
                {
                    int bytes = stream.Read(package, 0, package.Length);
                    response.Append(Encoding.UTF8.GetString(package, 0, bytes));
                }
                while (stream.DataAvailable);
                string server_reply = Convert.ToString(response);
                stream.Close();
                List<string> CategoryList = new List<string>();
                CategoryList = server_reply.Split(';').ToList();
                string TestName = CategoryList[0];
                string StudentName = CategoryList[1];
                string StudentResult = CategoryList[2];
                string QuestionAmount = CategoryList[3];
                List<string> testName = new List<string>();
                List<string> studentName = new List<string>();
                List<string> studentResult = new List<string>();
                List<string> questionAmount = new List<string>();
                testName = TestName.Split(',').Select(s => s.Trim()).ToList();
                studentName = StudentName.Split(',').Select(s => s.Trim()).ToList();
                studentResult = StudentResult.Split(',').Select(s => s.Trim()).ToList();
                questionAmount = QuestionAmount.Split(',').Select(s => s.Trim()).ToList();
                for (int i = 0; i < testName.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = testName[i];
                    dataGridView1.Rows[i].Cells[1].Value = studentName[i];
                    dataGridView1.Rows[i].Cells[2].Value = studentResult[i];
                    dataGridView1.Rows[i].Cells[3].Value = questionAmount[i];
                }
            }
            catch (SocketException a)
            {
                Console.WriteLine("SocketException: {0}", a);
            }
            catch (Exception a)
            {
                Console.WriteLine("Exception: {0}", a.Message);
            }
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                TcpClient client = new TcpClient();
                client.Connect(server, port);
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();
                string select = searchBox.Text + ";" + "filterTestResults";
                byte[] command = Encoding.UTF8.GetBytes(select);
                byte[] commandLength = BitConverter.GetBytes(command.Length);
                byte[] package;
                package = new byte[4 + command.Length];
                commandLength.CopyTo(package, 0);
                command.CopyTo(package, 4);
                stream.Write(package, 0, package.Length);
                package = new byte[128];
                do
                {
                    int bytes = stream.Read(package, 0, package.Length);
                    response.Append(Encoding.UTF8.GetString(package, 0, bytes));
                }
                while (stream.DataAvailable);
                string server_reply = Convert.ToString(response);
                stream.Close();
                List<string> CategoryList = new List<string>();
                CategoryList = server_reply.Split(';').ToList();
                string TestName = CategoryList[0];
                string StudentName = CategoryList[1];
                string StudentResult = CategoryList[2];
                string QuestionAmount = CategoryList[3];
                List<string> testName = new List<string>();
                List<string> studentName = new List<string>();
                List<string> studentResult = new List<string>();
                List<string> questionAmount = new List<string>();
                testName = TestName.Split(',').Select(s => s.Trim()).ToList();
                studentName = StudentName.Split(',').Select(s => s.Trim()).ToList();
                studentResult = StudentResult.Split(',').Select(s => s.Trim()).ToList();
                questionAmount = QuestionAmount.Split(',').Select(s => s.Trim()).ToList();
                for (int i = 0; i < testName.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = testName[i];
                    dataGridView1.Rows[i].Cells[1].Value = studentName[i];
                    dataGridView1.Rows[i].Cells[2].Value = studentResult[i];
                    dataGridView1.Rows[i].Cells[3].Value = questionAmount[i];
                }
            }
            catch (SocketException a)
            {
                Console.WriteLine("SocketException: {0}", a);
            }
            catch (Exception a)
            {
                Console.WriteLine("Exception: {0}", a.Message);
            }
        }
    }   
}
