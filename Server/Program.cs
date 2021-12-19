using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.Reflection;
using System.Text;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Server
{
    class Program
    {

        static void Main(string[] args)
        {
            //Блок ініціалізації підключення та деяких зміних\колекцій
            const int port = 8080;
            const string ip = "127.0.0.1";
            int bufferSize = 128;
            TcpListener listener = null;
            List<string> splittedMSG = new List<string>();
            string connectionString = @"Data Source=DESKTOP-M4UMCQJ;Initial Catalog=strmz;Integrated Security=True";
            try
            {
                // Прослуховування підключеннь відь клієнтів
                listener = new TcpListener(IPAddress.Parse(ip), port);
                listener.Start();
                while (true)
                {
                    //Підтвердження підключення клієнта
                    Console.WriteLine("_______________________________________");
                    Console.WriteLine("Ожидание подключений... ");
                    TcpClient client = listener.AcceptTcpClient();
                    //Отримання потоку від клієньа та зчитування данних з нього
                    Console.WriteLine("Подключен клиент. Выполнение запроса... \n");
                    NetworkStream stream = client.GetStream();
                    byte[] bytes;
                    bytes = new byte[bufferSize];
                    int bytesRec = 0;
                    stream.Read(bytes, 0, 4);
                    int commandSize = BitConverter.ToInt32(bytes);
                    //Отримання команди та її частковий розподіл для виділення ідентифікатора
                    bytesRec = stream.Read(bytes, 0, bytes.Length);
                    string command = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    Console.WriteLine("Размер полученной команды: \t" + commandSize + " символов");
                    Console.WriteLine("Полученная команда: \t\t" + command + "\n");
                    splittedMSG = command.Split(';').ToList();
                    string select = null;
                    // Якщо ідентифікатор "Додати новий предмет"
                    if (splittedMSG.Last() == "addNewItem")
                    {
                        string insert = null;
                        string message = "Waiting for File...";
                        Console.WriteLine("Полученные данные из команды: " + splittedMSG.Last() + "\n");
                        splittedMSG.Remove("addNewItem");
                        if (splittedMSG.Last() == "Book")
                        {
                            // Якщо предмет - Книга.
                            Console.WriteLine("Тип предмета: " + splittedMSG.Last() + "\n");
                            splittedMSG.Remove("Book");
                            // Перевірка\створення директорії за заданим шляхом - назва файлу + локальна директорія
                            string folder = Path.Combine(Directory.GetCurrentDirectory(), "books");
                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);
                            }
                            string filePath = splittedMSG.Last() + ".pdf";
                            string path = Path.Combine(folder, filePath);
                            Console.WriteLine("Создание файла по выбранному пути: " + path + "\n");
                            // Відправлення повідомлення клієнту про готовність прийняти файл
                            // Створення файлового потоку для прийняття файлу
                            FileInfo fInfo = new FileInfo(path);
                            if (!fInfo.Exists)
                            {
                                bytes = Encoding.UTF8.GetBytes(message);
                                stream.Write(bytes, 0, bytes.Length);
                                bytesRec = 0;
                                stream.Read(bytes, 0, 4);
                                int fileSize = BitConverter.ToInt32(bytes, 0);
                                bytes = new byte[fileSize];
                                int received = 0;
                                int count;
                                Console.WriteLine("Размер получаемого файла: \t" + fileSize + " байт \n");
                                Console.WriteLine("Получение данных файла с потока и их запись в ранее созданный файл на сервере... \n");
                                // Створення файлу та запис інформації до нього
                                using (var fileIO = File.Create(path))
                                    while (received < fileSize && (count = stream.Read(bytes, 0, bytes.Length)) > 0)
                                    {
                                        fileIO.Write(bytes, 0, count);
                                        received += count;
                                    }
                                stream.Close();
                                Console.WriteLine("Файл успешно записан \n");
                                Console.WriteLine("Запись данных о файле в БД \n");
                                insert = splittedMSG.Last();
                                // Відправлення інформації про файл до БД
                                string sqlExpression = "INSERT INTO Books (bookNAME, bookPATH) VALUES ('" + insert + "','" + path + "')";
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    SqlCommand sqlcmd = new SqlCommand(sqlExpression, connection);
                                    int number = sqlcmd.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов в БД: {0}", number);
                                }
                            }
                            else
                            {
                                string nameAlreadyExist = "File with This name already exist";
                                Console.WriteLine("Файл с таким именем существует, выберите другое имя");
                                bytes = Encoding.UTF8.GetBytes(nameAlreadyExist);
                                stream.Write(bytes, 0, bytes.Length);
                                stream.Close();
                            }
                        }
                        // Аналогічний блок для предмету "Тест" Повторення
                        if (splittedMSG.Last() == "Test")
                        {
                            Console.WriteLine("Тип предмета: " + splittedMSG.Last() + "\n");
                            splittedMSG.Remove("Test");
                            string folder = Path.Combine(Directory.GetCurrentDirectory(), "tests");
                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);
                            }
                            string filePath = splittedMSG[0] + ".pdf";
                            string path = Path.Combine(folder, filePath);
                            string questionAmount, answersValues;
                            Console.WriteLine("Создание файла по выбранному пути: " + path + "\n");
                            FileInfo fInfo = new FileInfo(path);
                            if (!fInfo.Exists)
                            {
                                questionAmount = splittedMSG[1];
                                answersValues = splittedMSG.Last();
                                bytes = Encoding.UTF8.GetBytes(message);
                                stream.Write(bytes, 0, bytes.Length);
                                bytesRec = 0;
                                stream.Read(bytes, 0, 4);
                                int fileSize = BitConverter.ToInt32(bytes, 0);
                                bytes = new byte[fileSize];
                                int received = 0;
                                int count;
                                Console.WriteLine("Размер получаемого файла: \t" + fileSize + " байт \n");
                                Console.WriteLine("Получение данных файла с потока и их запись в ранее созданный файл на сервере... \n");
                                using (var fileIO = File.Create(path))
                                    while (received < fileSize && (count = stream.Read(bytes, 0, bytes.Length)) > 0)
                                    {
                                        fileIO.Write(bytes, 0, count);
                                        received += count;
                                    }
                                stream.Close();
                                Console.WriteLine("Файл успешно записан \n");
                                Console.WriteLine("Запись данных о файле в БД \n");
                                insert = splittedMSG.Last();
                                string sqlExpression = "INSERT INTO Tests (testNAME, testQUESTIONAMOUNT, testANSWERS, testPATH) VALUES ('" + insert + "','" + questionAmount + "','" + answersValues + "','" + path + "')";
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    SqlCommand sqlcmd = new SqlCommand(sqlExpression, connection);
                                    int number = sqlcmd.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов в БД: {0}", number);
                                }
                            }
                            else
                            {
                                string nameAlreadyExist = "File with This name already exist";
                                Console.WriteLine("Файл с таким именем существует, выберите другое имя");
                                bytes = Encoding.UTF8.GetBytes(nameAlreadyExist);
                                stream.Write(bytes, 0, bytes.Length);
                                stream.Close();
                            }
                        }

                    }
                    // Якщо ідентифікатор "Оновити Лист"
                    if (splittedMSG.Last() == "refreshList")
                    {
                        // Ідентифікатор для оновлення листа з існуючими предметами
                        // Створення колекцій для отримання Назви та ІД предмета.
                        List<int> bookID = new List<int>();
                        List<string> bookNAME = new List<string>();
                        Console.WriteLine("Полученные данные из команды: " + splittedMSG.Last() + "\n");
                        splittedMSG.Remove("refreshList");
                        // Для предмету Книга
                        if (splittedMSG.Last() == "Book")
                        {
                            Console.WriteLine("Тип предмета: " + splittedMSG.Last() + "\n");
                            select = splittedMSG.Last();
                            // Запит до БД на отримання всієї інформації з таблиці Книги
                            string sqlExpression = "SELECT bookID, bookNAME FROM Books";
                            Console.WriteLine("Запрос в БД для чтения данных... \n");
                            // З’єднання з БД
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
                                SqlDataReader reader = cmdSQL.ExecuteReader();
                                if (reader.HasRows) 
                                {
                                    while (reader.Read()) 
                                    {
                                        // Заповнення колекцій відповідними даними
                                        bookID.Add((int)reader.GetValue(0));
                                        bookNAME.Add((string)reader.GetValue(1));
                                    }
                                }
                                connection.Close();
                                Console.WriteLine("Данные с БД успешно получены \n");
                                // Зливання даних з колекції в один рядок
                                var messID = String.Join(", ", bookID.ToArray());
                                var messName = String.Join(", ", bookNAME.ToArray());
                                // Кодування рядку та відправлення до клієнта
                                bytes = Encoding.UTF8.GetBytes(messID + ';' + messName);
                                stream.Write(bytes, 0, bytes.Length);
                                stream.Close();
                                Console.WriteLine("Данные успешно отправлены на клиент \n"); 
                            }
                        }
                        // Для предмета Тест. Повторення як у Книга
                        if (splittedMSG.Last() == "Test")
                        {
                            Console.WriteLine("Тип предмета: " + splittedMSG.Last() + "\n");
                            select = splittedMSG.Last();
                            string sqlExpression = "SELECT testID, testNAME FROM Tests";
                            Console.WriteLine("Запрос в БД для чтения данных... \n");
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
                                SqlDataReader reader = cmdSQL.ExecuteReader();
                                if (reader.HasRows) 
                                {
                                    while (reader.Read()) 
                                    {
                                        bookID.Add((int)reader.GetValue(0));
                                        bookNAME.Add((string)reader.GetValue(1));
                                    }
                                }
                                connection.Close();
                                Console.WriteLine("Данные с БД успешно получены \n");
                                var messID = String.Join(", ", bookID.ToArray());
                                var messName = String.Join(", ", bookNAME.ToArray());
                                bytes = Encoding.UTF8.GetBytes(messID + ';' + messName);
                                stream.Write(bytes, 0, bytes.Length);
                                stream.Close();
                                Console.WriteLine("Данные успешно отправлены на клиент \n");
                            }
                        }
                    }
                    // Якщо ідентифікатор "Відкрити обраний файл"
                    if (splittedMSG.Last() == "openSelectedItem")
                    {
                        // Колекції для ІД та Назви предмета
                        List<int> bookID = new List<int>();
                        List<string> bookNAME = new List<string>();
                        Console.WriteLine("Полученные данные из команды: " + splittedMSG.Last() + "\n");
                        splittedMSG.Remove("openSelectedItem");
                        // Для Книги
                        if (splittedMSG.Last() == "Book")
                        {
                            Console.WriteLine("Тип предмета: " + splittedMSG.Last());
                            Console.WriteLine("ИД предмета: " + splittedMSG[0] + "\n");
                            string selectedID = null;
                            // Отримання ІД обраного предмета
                            selectedID = splittedMSG[0];
                            string sqlPATH = null;
                            // Запит на отримання даних з БД по ІД предмета.
                            string sqlExpression = "SELECT bookPATH FROM Books WHERE bookID = '" + selectedID + "'";
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
                                sqlPATH = (string)cmdSQL.ExecuteScalar();
                                connection.Close();
                            }
                            Console.WriteLine("Чтение файла предмета на сервере: \t" + sqlPATH + "\n");
                            // Зчитування файла по шляху, отриманому з БД та відправлення на клієнт.
                            using (FileStream fstream = File.OpenRead(sqlPATH))
                            {
                                byte[] file = new byte[fstream.Length];
                                fstream.Read(file, 0, file.Length);
                                byte[] fileLength = BitConverter.GetBytes(fstream.Length);
                                byte[] package;
                                package = new byte[4 + file.Length];
                                fileLength.CopyTo(package, 0);
                                file.CopyTo(package, 4);
                                stream.Write(package, 0, package.Length);
                                Console.WriteLine("Файл прочитан и отправлен на клиент \n");
                            }
                            stream.Close();
                        }
                        // Для Тесту (повторення як у Книзі)
                        if (splittedMSG.Last() == "Test")
                        {
                            Console.WriteLine("Тип предмета: " + splittedMSG.Last());
                            Console.WriteLine("ИД предмета: " + splittedMSG[0] + "\n");
                            string selectedID = null;
                            selectedID = splittedMSG[0];
                            string sqlPATH = null;
                            string sqlExpression = "SELECT testPATH FROM Tests WHERE testID = '" + selectedID + "'";
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
                                sqlPATH = (string)cmdSQL.ExecuteScalar();
                                connection.Close();
                            }
                            Console.WriteLine("Чтение файла предмета на сервере: \t" + sqlPATH + "\n");
                            using (FileStream fstream = File.OpenRead(sqlPATH))
                            {
                                byte[] file = new byte[fstream.Length];
                                fstream.Read(file, 0, file.Length);
                                byte[] fileLength = BitConverter.GetBytes(fstream.Length);
                                byte[] package;
                                package = new byte[4 + file.Length];
                                fileLength.CopyTo(package, 0);
                                file.CopyTo(package, 4);
                                stream.Write(package, 0, package.Length);
                                Console.WriteLine("Файл прочитан и отправлен на клиент \n");
                            }
                            stream.Close();
                        }                       
                    }
                    // Якщо ідентифікатор "Видалити обраний файл"
                    if (splittedMSG.Last() == "removeSelectedItem")
                    {
                        Console.WriteLine("Полученные данные из команды: " + splittedMSG.Last() + "\n");
                        splittedMSG.Remove("removeSelectedItem");
                        // Для Книги
                        if (splittedMSG.Last() == "Book")
                        {
                            Console.WriteLine("Тип предмета: " + splittedMSG.Last());
                            Console.WriteLine("ИД предмета: " + splittedMSG[0] + "\n");
                            // Створення змінних для ІД та Шляху файла
                            string selectedID = null;
                            // Зчитування ІД у відповідну змінную
                            selectedID = splittedMSG[0];
                            string sqlPATH = null;
                            // Витягування Шляху у відповідную змінну за допомогою ІД
                            string sqlGetPath = "SELECT bookPATH FROM Books WHERE bookID = '" + selectedID + "'";
                            // Видалення рядка з таблиці за допомогою ІД
                            string sqlExpression = "DELETE FROM Books WHERE bookID = '" + selectedID + "'";
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand cmdSQL;
                                cmdSQL = new SqlCommand(sqlGetPath, connection);
                                sqlPATH = (string)cmdSQL.ExecuteScalar();
                                cmdSQL = new SqlCommand(sqlExpression, connection);
                                cmdSQL.ExecuteScalar();
                                connection.Close();
                                Console.WriteLine("Запись о предмете в БД удалена \n");
                            }
                            // Видалення файлу за допомоги шляху
                            FileInfo fInfo = new FileInfo(sqlPATH);
                            if (fInfo.Exists)
                            {
                                fInfo.Delete();
                                Console.WriteLine("Путь к файлу предмета на сервере: \t" + sqlPATH);
                                Console.WriteLine("Файл предмета удален с сервера \n");
                            }
                            stream.Close();
                        }
                        // Для Тесту (повторення як для Книги)
                        if (splittedMSG.Last() == "Test")
                        {
                            Console.WriteLine("Тип предмета: " + splittedMSG.Last());
                            Console.WriteLine("ИД предмета: " + splittedMSG[0] + "\n");
                            string selectedID = null;
                            selectedID = splittedMSG[0];
                            string sqlPATH = null;
                            string sqlGetPath = "SELECT testPATH FROM Tests WHERE testID = '" + selectedID + "'";
                            string sqlExpression = "DELETE FROM Tests WHERE testID = '" + selectedID + "'";
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand cmdSQL;
                                cmdSQL = new SqlCommand(sqlGetPath, connection);
                                sqlPATH = (string)cmdSQL.ExecuteScalar();
                                cmdSQL = new SqlCommand(sqlExpression, connection);
                                cmdSQL.ExecuteScalar();
                                connection.Close();
                                Console.WriteLine("Запись о предмете в БД удалена \n");
                            }
                            FileInfo fInfo = new FileInfo(sqlPATH);
                            if (fInfo.Exists)
                            {
                                fInfo.Delete();
                                Console.WriteLine(sqlPATH);
                                Console.WriteLine("Путь к файлу предмета на сервере: \t" + sqlPATH);
                                Console.WriteLine("Файл предмета удален с сервера \n");
                            }
                            stream.Close();
                        }
                    }
                    // Якщо ідентифікатор "Почати Тестування"
                    if (splittedMSG.Last() == "startingTest")
                    {
                        Console.WriteLine("Полученные данные из команды: " + splittedMSG.Last() + "\n");
                        splittedMSG.Remove("startingTest");
                        // Збереження ІД обраного та початого тесту з клієнту
                        select = splittedMSG.Last();
                        Console.WriteLine("ИД Запрашиваемого Теста: \t" + select + "\n");
                        string questionsAmount = null;
                        // Отримання кількості питань для початого теста з БД
                        string sqlExpression = "SELECT testQUESTIONAMOUNT FROM Tests WHERE testID = '" + select + "'";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
                            questionsAmount = (string)cmdSQL.ExecuteScalar();
                            connection.Close();
                        }
                        // Відправлення кільксті питань на клієнт
                        bytes = Encoding.UTF8.GetBytes(questionsAmount);
                        Console.WriteLine("Отправляю данные клиенту");
                        Console.WriteLine("Количество вопросов в тесте: " + questionsAmount);
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Close();
                    }
                    // Якщо ідентифікатор "Надіслати відповіді"
                    if (splittedMSG.Last() == "sendAnswers")
                    {
                        Console.WriteLine("Полученные данные из команды: " + splittedMSG.Last() +"\n");
                        splittedMSG.Remove("sendAnswers");
                        // Формування колекції для ІД Тесту
                        List<string> testIdName = new List<string>();
                        // Зчитування в колекцію ІД Теста
                        testIdName = splittedMSG[0].Split('|').ToList();
                        Console.WriteLine("ИД Теста: \t\t" + testIdName[0]);
                        Console.WriteLine("Название Теста: \t" + testIdName[1]);
                        Console.WriteLine("Имя студента: \t\t" + splittedMSG[1]);
                        Console.WriteLine("Ответы студента: \t" + splittedMSG[2] + "\n");
                        // Змінні для кількості питань тесту та отримання правильних питаннь.
                        string questionsAmount = null;
                        string rightAnswers = null;
                        string sqlExpression = "SELECT testQUESTIONAMOUNT FROM Tests WHERE testID = '" + testIdName[0] + "'";
                        string sqlExpressionSec = "SELECT testANSWERS FROM Tests WHERE testID = '" + testIdName[0] + "'";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
                            SqlCommand cmdSQLSec = new SqlCommand(sqlExpressionSec, connection);
                            questionsAmount = (string)cmdSQL.ExecuteScalar();
                            rightAnswers = (string)cmdSQLSec.ExecuteScalar();
                            connection.Close();
                        }
                        // Запит для внесення данних студента, який пройшов тест.
                        string sqlExpressionThird = "INSERT INTO Test_Result (testID, testNAME, testQUESTIONAMOUNT, testRightANSWERS, testStundentNAME, " +
                            "testStudentANSWERS) VALUES ('" + testIdName[0] + "','" + testIdName.Last() + "','" + questionsAmount + "','" + rightAnswers + "'" +
                            ",'" + splittedMSG[1] + "','" + splittedMSG[2] + "')";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand sqlcmd = new SqlCommand(sqlExpressionThird, connection);
                            int number = sqlcmd.ExecuteNonQuery();
                            Console.WriteLine("Добавлено объектов в базу данных: {0}", number);
                        }
                        stream.Close();
                    }
                    // Якщо ідентифікатор "Авторизуватися"
                    if (splittedMSG.Last() == "userLogin")
                    {
                        // Створення колекцій для Логіну та Паролю
                        List<string> UserNAME = new List<string>();
                        List<string> UserPASS = new List<string>();
                        string message = "Wrong login or password";
                        Console.Write("Полученные данные из команды: " + splittedMSG.Last() + "\n");
                        splittedMSG.Remove("userLogin");
                        select = splittedMSG.Last();
                        // Запит на отримання паролю та логіну з БД
                        string sqlExpression = "SELECT userNAME, userPASS FROM Users";
                        Console.WriteLine("Запрос в БД для чтения данных... \n");
                        int usersCount = 0;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
                            SqlDataReader reader = cmdSQL.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    // Запис отриманих даних з БД до колекції
                                    UserNAME.Add((string)reader.GetValue(0));
                                    UserPASS.Add((string)reader.GetValue(1));
                                    usersCount++;
                                }
                            }
                            connection.Close();
                            Console.WriteLine("Данные с БД успешно получены \n");
                            // Згідно з пройденою умовою кодування і відправлення даних на клієнт
                            if(splittedMSG[0] == UserNAME[0] && splittedMSG[0] == UserPASS[0])
                            {
                                bytes = Encoding.UTF8.GetBytes("teacher");
                            }
                            else if(splittedMSG[1] == UserNAME[1] && splittedMSG[1] == UserPASS[1])
                            {
                                bytes = Encoding.UTF8.GetBytes("student");
                            }
                            else
                            {
                                bytes = Encoding.UTF8.GetBytes(message);
                            }
                            stream.Write(bytes, 0, bytes.Length);
                            stream.Close();
                            Console.WriteLine("Данные успешно отправлены на клиент \n");
                        }
                    }
                    // Якщо ідентифікатор "Отримати статистику по результатам тестування" Повторюється з Блоком нижче, різниця лише у фільтрі.
                    if (splittedMSG.Last() == "getTestResults")
                    {
                        List<string> TestName = new List<string>();
                        List<string> StudentName = new List<string>();
                        List<string> StudentAnswers = new List<string>();
                        List<string> TestAnswers = new List<string>();
                        List<string> TestQuestionAmount = new List<string>();
                        List<string> StudentResult = new List<string>();
                        Console.WriteLine("Отримані дані з команди: " + splittedMSG.Last() + "\n");
                        splittedMSG.Remove("getTestResults");
                        Console.WriteLine("Тип предмета: " + splittedMSG.Last() + "\n");
                        select = splittedMSG.Last();
                        string sqlExpression = "SELECT testNAME, testQUESTIONAMOUNT, testRightANSWERS, testStundentNAME, testStudentANSWERS  FROM Test_Result";
                        Console.WriteLine("Запит до БД на читання даних... \n");
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
                            SqlDataReader reader = cmdSQL.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    TestName.Add((string)reader.GetValue(0));
                                    TestQuestionAmount.Add((string)reader.GetValue(1));
                                    TestAnswers.Add((string)reader.GetValue(2));
                                    StudentName.Add((string)reader.GetValue(3));
                                    StudentAnswers.Add((string)reader.GetValue(4));
                                }
                            }
                            connection.Close();
                            string[] StudentAns;
                            string[] TestAns;
                            int rightAnswerCount;
                            for (int i = 0; i < TestName.Count; i++)
                            {
                                rightAnswerCount = 0;
                                StudentAns = new string[Convert.ToInt32(TestQuestionAmount[i])];
                                TestAns = new string[Convert.ToInt32(TestQuestionAmount[i])];
                                StudentAns = StudentAnswers[i].Split(',');
                                TestAns = TestAnswers[i].Split(',');
                                for (int j = 0; j < Convert.ToInt32(TestQuestionAmount[i]); j++)
                                {
                                    if (StudentAns[j] == TestAns[j]) rightAnswerCount++;
                                }
                                StudentResult.Add(Convert.ToString(rightAnswerCount));
                            }
                            Console.WriteLine("Дані успішно отримані з БД \n");
                            var testName = String.Join(", ", TestName.ToArray());
                            var studentName = String.Join(", ", StudentName.ToArray());
                            var studentResult = String.Join(", ", StudentResult.ToArray());
                            var testQuestionAmount = String.Join(", ", TestQuestionAmount.ToArray());
                            bytes = Encoding.UTF8.GetBytes(testName + ';' + studentName + ';' + studentResult + ';' + testQuestionAmount);
                            stream.Write(bytes, 0, bytes.Length);
                            stream.Close();
                            Console.WriteLine("Дані успішно відправлені на клінєт \n");
                        }
                    }
                    // Якщо ідентифікатор "Фільтрація результатів тестування"
                    if (splittedMSG.Last() == "filterTestResults")
                    {
                        // Створення колекцій для даних
                        List<string> TestName = new List<string>();
                        List<string> StudentName = new List<string>();
                        List<string> StudentAnswers = new List<string>();
                        List<string> TestAnswers = new List<string>();
                        List<string> TestQuestionAmount = new List<string>();
                        List<string> StudentResult = new List<string>();
                        Console.WriteLine("Отримані дані з команди: " + splittedMSG.Last() + "\n");
                        splittedMSG.Remove("filterTestResults");
                        Console.WriteLine("Тип предмета: " + splittedMSG.Last() + "\n");
                        select = splittedMSG.Last();
                        // Запит до БД з фільтром, дані для якого беруться з вищезазначенної змінної
                        string sqlExpression = "SELECT testNAME, testQUESTIONAMOUNT, testRightANSWERS, testStundentNAME, testStudentANSWERS  FROM Test_Result WHERE testNAME =  '" + select + "' OR testStundentNAME =  '" + select + "'";
                        Console.WriteLine("Запрос в БД для чтения данных... \n");
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
                            SqlDataReader reader = cmdSQL.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    TestName.Add((string)reader.GetValue(0));
                                    TestQuestionAmount.Add((string)reader.GetValue(1));
                                    TestAnswers.Add((string)reader.GetValue(2));
                                    StudentName.Add((string)reader.GetValue(3));
                                    StudentAnswers.Add((string)reader.GetValue(4));
                                }
                            }
                            connection.Close();
                            string[] StudentAns;
                            string[] TestAns;
                            int rightAnswerCount;
                            // Розділення та підрахування даних
                            for (int i = 0; i<TestName.Count; i++ )
                            {
                                rightAnswerCount = 0;
                                StudentAns = new string[Convert.ToInt32(TestQuestionAmount[i])];
                                TestAns = new string[Convert.ToInt32(TestQuestionAmount[i])];
                                StudentAns = StudentAnswers[i].Split(',');
                                TestAns = TestAnswers[i].Split(',');
                                for(int j = 0; j < Convert.ToInt32(TestQuestionAmount[i]); j++)
                                {
                                    if (StudentAns[j] == TestAns[j]) rightAnswerCount++;
                                }
                                StudentResult.Add(Convert.ToString(rightAnswerCount));
                            }
                            // Відправлення даних на клієнт
                            Console.WriteLine("Данные с БД успешно получены \n");
                            var testName = String.Join(", ", TestName.ToArray());
                            var studentName = String.Join(", ", StudentName.ToArray());
                            var studentResult = String.Join(", ", StudentResult.ToArray());
                            var testQuestionAmount = String.Join(", ", TestQuestionAmount.ToArray());
                            bytes = Encoding.UTF8.GetBytes(testName + ';' + studentName + ';' + studentResult + ';' + testQuestionAmount);
                            stream.Write(bytes, 0, bytes.Length);
                            stream.Close();
                            Console.WriteLine("Данные успешно отправлены на клиент \n");
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
