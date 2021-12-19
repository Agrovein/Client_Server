using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const int port = 8080;
        private const string server = "127.0.0.1";

        private void addNewBookBTN_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(bookName.Text) && !String.IsNullOrEmpty(path.Text))
            {
                try
                {
                    TcpClient client = new TcpClient();
                    client.Connect(server, port);
                    StringBuilder response = new StringBuilder();
                    NetworkStream stream = client.GetStream();
                    using (FileStream fstream = File.OpenRead(path.Text))
                    {
                        byte[] file = new byte[fstream.Length];
                        fstream.Read(file, 0, file.Length);
                        byte[] fileLength = BitConverter.GetBytes(fstream.Length);
                        string fileName = bookName.Text + ';' + "Book" + ';' + "addNewItem";
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
                        if (server_reply == "Waiting for File...")
                        {
                            package = new byte[4 + file.Length];
                            fileLength.CopyTo(package, 0);
                            file.CopyTo(package, 4);
                            stream.Write(package, 0, package.Length);
                            stream.Close();
                        }
                        if (server_reply == "File with This name already exist")
                        {
                            MessageBox.Show("Файл с таким именем существует, измените имя файла");
                        }
                        stream.Close();
                        client.Close();
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
            else MessageBox.Show("Введите имя книги и выберите файл");
        }

        private void browseFileBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdl = new OpenFileDialog();
            if (fdl.ShowDialog() == DialogResult.OK)
            {
                path.Text = fdl.FileName;
                axAcroPDF1.src = fdl.FileName;
            }
            fdl = null;
        }

        private void refreshListBTN_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();
                string select = "Book" + ";" + "refreshList";
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
                List<string> CategoryList = new List<string>();
                CategoryList = server_reply.Split(';').ToList();
                string id = CategoryList[0];
                string name = CategoryList[1];
                List<string> splittedID = new List<string>();
                List<string> splittedNAME = new List<string>();
                splittedID = id.Split(',').Select(s => s.Trim()).ToList();
                splittedNAME = name.Split(',').Select(s => s.Trim()).ToList();
                foreach (var book in splittedID.Zip(splittedNAME, Tuple.Create))
                {
                    comboBox1.Items.Add(book.Item1 + "|" + book.Item2);
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

        private void openBookBTN_Click(object sender, EventArgs e)
        {         
            try
            {
                string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                List<string> selectedID = new List<string>();
                selectedID = selected.Split('|').ToList();
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "books");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filePath = selectedID.Last() + ".pdf";
                string path = Path.Combine(folder, filePath);
                FileInfo fInfo = new FileInfo(path);
                if (!fInfo.Exists)
                {
                    TcpClient client = new TcpClient();
                    client.Connect(server, port);
                    StringBuilder response = new StringBuilder();
                    NetworkStream stream = client.GetStream();
                    string comm = selectedID[0] + ';' + "Book" + ';' + "openSelectedItem";
                    byte[] command = Encoding.UTF8.GetBytes(comm);
                    byte[] commandLength = BitConverter.GetBytes(command.Length);
                    byte[] package;
                    package = new byte[4 + command.Length];
                    commandLength.CopyTo(package, 0);
                    command.CopyTo(package, 4);
                    stream.Write(package, 0, package.Length);
                    stream.Read(package, 0, 4);
                    int fileSize = BitConverter.ToInt32(package, 0);
                    package = new byte[fileSize];
                    int received = 0;
                    int count;
                    using (var fileIO = File.Create(path))
                    {
                        while (received < fileSize && (count = stream.Read(package, 0, package.Length)) > 0)
                        {
                            fileIO.Write(package, 0, count);
                            received += count;
                        }
                    }
                    axAcroPDF1.LoadFile(path);
                }
                else { axAcroPDF1.LoadFile(path); }
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdl = new OpenFileDialog();
            if (fdl.ShowDialog() == DialogResult.OK)
            {
                testBrowseFile.Text = fdl.FileName;
                axAcroPDF1.src = fdl.FileName;
            }
            fdl = null;
        }

        private void addNewTest_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(testName.Text) && !String.IsNullOrEmpty(questionAmount.Text) && !String.IsNullOrEmpty(testBrowseFile.Text))
            {
                try
                {
                    TcpClient client = new TcpClient();
                    client.Connect(server, port);
                    StringBuilder response = new StringBuilder();
                    NetworkStream stream = client.GetStream();
                    using (FileStream fstream = File.OpenRead(testBrowseFile.Text))
                    {
                        byte[] file = new byte[fstream.Length];
                        fstream.Read(file, 0, file.Length);
                        byte[] fileLength = BitConverter.GetBytes(fstream.Length);
                        int numberOfQuestion = Convert.ToInt32(questionAmount.Text);
                        string[] answersValueArray = new string[numberOfQuestion];
                        string answersValueString = null;
                        for (int i = 0; i < numberOfQuestion; i++)
                        {
                            answersValueArray[i] += Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                            if (i < numberOfQuestion - 1)
                            {
                                answersValueString += answersValueArray[i] + ',';
                            }
                            else answersValueString += answersValueArray[i];
                        }
                        string fileName = testName.Text + ';' + questionAmount.Text + ';' + answersValueString + ';' + "Test" + ';' + "addNewItem";
                        byte[] command = Encoding.UTF8.GetBytes(fileName);
                        byte[] commandLength = BitConverter.GetBytes(command.Length);
                        byte[] package;
                        package = new byte[4 + command.Length];
                        commandLength.CopyTo(package, 0);
                        command.CopyTo(package, 4);
                        stream.Write(package, 0, package.Length);
                        do
                        {
                            int bytes = stream.Read(package, 0, package.Length);
                            response.Append(Encoding.UTF8.GetString(package, 0, bytes));
                        }
                        while (stream.DataAvailable);
                        string server_reply = Convert.ToString(response);
                        if (server_reply == "Waiting for File...")
                        {
                            package = new byte[4 + file.Length];
                            fileLength.CopyTo(package, 0);
                            file.CopyTo(package, 4);
                            stream.Write(package, 0, package.Length);
                            stream.Close();
                        }
                        if (server_reply == "File with This name already exist")
                        {
                            MessageBox.Show("Файл с таким именем уже существует, измените имя");
                        }
                        stream.Close();
                        client.Close();
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
            else MessageBox.Show("Введите название теста, ответы на вопрос и выберите файл");
        }

        private void textListBTN_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();
                string select = "Test" + ";" + "refreshList";
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
                List<string> CategoryList = new List<string>();
                CategoryList = server_reply.Split(';').ToList();
                string id = CategoryList[0];
                string name = CategoryList[1];
                List<string> splittedID = new List<string>();
                List<string> splittedNAME = new List<string>();
                splittedID = id.Split(',').Select(s => s.Trim()).ToList();
                splittedNAME = name.Split(',').Select(s => s.Trim()).ToList();
                foreach (var book in splittedID.Zip(splittedNAME, Tuple.Create))
                {
                    comboBox2.Items.Add(book.Item1 + "|" + book.Item2);
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
       
        private void openTestBTN_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
                List<string> selectedID = new List<string>();
                selectedID = selected.Split('|').ToList();
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "tests");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filePath = selectedID.Last() + ".pdf";
                string path = Path.Combine(folder, filePath);
                FileInfo fInfo = new FileInfo(path);
                if (!fInfo.Exists)
                {
                    TcpClient client = new TcpClient();
                    client.Connect(server, port);
                    StringBuilder response = new StringBuilder();
                    NetworkStream stream = client.GetStream();
                    string comm = selectedID[0] + ';' + "Test" +';'+"openSelectedItem";
                    byte[] command = Encoding.UTF8.GetBytes(comm);
                    byte[] commandLength = BitConverter.GetBytes(command.Length);
                    byte[] package;
                    package = new byte[4 + command.Length];
                    commandLength.CopyTo(package, 0);
                    command.CopyTo(package, 4);
                    stream.Write(package, 0, package.Length);
                    stream.Read(package, 0, 4);
                    int fileSize = BitConverter.ToInt32(package, 0);
                    package = new byte[fileSize];
                    int received = 0;
                    int count;
                    using (var fileIO = File.Create(path))
                    {
                        while (received < fileSize && (count = stream.Read(package, 0, package.Length)) > 0)
                        {
                            fileIO.Write(package, 0, count);
                            received += count;
                        }
                    }
                    axAcroPDF1.LoadFile(path);
                }
                else { axAcroPDF1.LoadFile(path); }
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

        private void removeBookBTN_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                List<string> selectedItem = new List<string>();
                selectedItem = selected.Split('|').ToList();
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "books");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filePath = selectedItem.Last() + ".pdf";
                string path = Path.Combine(folder, filePath);
                FileInfo fInfo = new FileInfo(path);
                if (fInfo.Exists)
                {
                    fInfo.Delete();
                }
                TcpClient client = new TcpClient();
                client.Connect(server, port);
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();
                string comm = selectedItem[0] + ';' + "Book" + ';' + "removeSelectedItem";
                byte[] command = Encoding.UTF8.GetBytes(comm);
                byte[] commandLength = BitConverter.GetBytes(command.Length);
                byte[] package;
                package = new byte[4 + command.Length];
                commandLength.CopyTo(package, 0);
                command.CopyTo(package, 4);
                stream.Write(package, 0, package.Length);
                this.comboBox1.Items.Remove(this.comboBox1.SelectedItem);              
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

        private void removeTestBTN_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
                List<string> selectedItem = new List<string>();
                selectedItem = selected.Split('|').ToList();
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "tests");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filePath = selectedItem.Last() + ".pdf";
                string path = Path.Combine(folder, filePath);
                FileInfo fInfo = new FileInfo(path);
                if (fInfo.Exists)
                {
                    fInfo.Delete();
                }
                TcpClient client = new TcpClient();
                client.Connect(server, port);
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();
                string comm = selectedItem[0] + ';' + "Test" + ';' + "removeSelectedItem";
                byte[] command = Encoding.UTF8.GetBytes(comm);
                byte[] commandLength = BitConverter.GetBytes(command.Length);
                byte[] package;
                package = new byte[4 + command.Length];
                commandLength.CopyTo(package, 0);
                command.CopyTo(package, 4);
                stream.Write(package, 0, package.Length);
                this.comboBox2.Items.Remove(this.comboBox2.SelectedItem);
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

        private void loginPageBTN_Click(object sender, EventArgs e)
        {
            Login_Form nextForm = new Login_Form();
            this.Hide();
            nextForm.ShowDialog();
            this.Close();
        }

        private void bookPageBTN_Click(object sender, EventArgs e)
        {
            Book_Form nextForm = new Book_Form();
            this.Hide();
            nextForm.ShowDialog();
            this.Close();
        }

        private void testPageBTN_Click(object sender, EventArgs e)
        {
            Test_Form nextForm = new Test_Form();
            this.Hide();
            nextForm.ShowDialog();
            this.Close();
        }

        private void generateQuestionBTN_Click(object sender, EventArgs e)
        {
            int numberOfQuestion = Convert.ToInt32(questionAmount.Text);
            dataGridView1.Rows.Clear();
            int count = 1;
            for(int i=0; i<numberOfQuestion; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = "Питання #"+count;
                count++;
            }
        }

        private void path_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
