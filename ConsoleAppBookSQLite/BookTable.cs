using System.Data;
using System.Data.SQLite;
using System.Security.Policy;

namespace ConsoleAppBookSQLite;

// 定義一個類別，表示一個收藏書籍/電子書的資料表
public class BookTable
{
    // 定義一個屬性，用來儲存連接到MSSQL的連接字串
    public string ConnectionString { get; set; }

    // 定義一個建構式，用來初始化一個連接到MSSQL的資料表
    public BookTable(string connectionString)
    {
        // 將參數值指派給屬性
        ConnectionString = connectionString;
        using var con = new SQLiteConnection(ConnectionString);
        con.Open();

        using var cmd = new SQLiteCommand(con);

        cmd.CommandText = "DROP TABLE IF EXISTS book";
        cmd.ExecuteNonQuery();

        //id INT PRIMARY KEY IDENTITY(1, 1),
        //title VARCHAR(50) NOT NULL,
        //author VARCHAR(50) NOT NULL,
        //year INT NOT NULL,
        //publisher VARCHAR(50) NOT NULL,
        //price DECIMAL(10, 2) NOT NULL,
        //format VARCHAR(10) NOT NULL
        cmd.CommandText = @"CREATE TABLE book(
            id INTEGER PRIMARY KEY,
            title TEXT,
            author TEXT,
            year INTEGER,
            publisher TEXT,
            price REAL,
            format TEXT)";
        cmd.ExecuteNonQuery();
        con.Close();
    }

    // 定義一個方法，用來新增一本書籍/電子書到資料表中
    public void AddBook(Book book)
    {
        // 建立一個 SQLiteConnection 物件，用來連接到資料庫
        using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        {
            // 建立一個 SQLiteCommand 物件，用來執行SQL指令
            using (SQLiteCommand command = new SQLiteCommand())
            {
                // 設定 SQLiteCommand 物件的屬性
                command.Connection = connection; // 指定連接物件
                command.CommandType = CommandType.Text; // 指定指令類型為文字
                //command.CommandText = "INSERT INTO book (title, author, year, publisher, price, format) VALUES (?, ?, ?, ?, ?, ?)"; // 指定指令內容為插入資料
                command.CommandText = @"INSERT INTO book (title, author, year, publisher, price, format) VALUES (@title, @author, @year, @publisher, @price, @format)"; // 指定指令內容為插入資料

                // 建立一些 SQLiteParameter 物件，用來傳遞參數值給SQL指令
                command.Parameters.Add(new SQLiteParameter("@title", book.Title)); // 傳遞書名參數
                command.Parameters.Add(new SQLiteParameter("@author", book.Author)); // 傳遞作者參數
                command.Parameters.Add(new SQLiteParameter("@year", book.Year.ToString())); // 傳遞出版年份參數
                command.Parameters.Add(new SQLiteParameter("@publisher", book.Publisher)); // 傳遞出版社參數
                command.Parameters.Add(new SQLiteParameter("@price", book.Price.ToString())); // 傳遞價格參數
                command.Parameters.Add(new SQLiteParameter("@format", book.Format)); // 傳遞格式參數

                // 開啟連接
                connection.Open();

                // 執行SQL指令，並取得影響的資料列數目
                int rowsAffected = command.ExecuteNonQuery();

                // 關閉連接
                connection.Close();

                // 判斷是否有成功插入資料
                if (rowsAffected > 0)
                {
                    // 輸出成功訊息
                    Console.WriteLine("Book added successfully.");
                }
            }
        }
    }

    // 定義一個方法，用來移除資料表中的一本書籍/電子書
    public void RemoveBook(int id)
    {
        // 建立一個 SQLiteConnection 物件，用來連接到資料庫
        using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        {
            // 建立一個 SQLiteCommand 物件，用來執行SQL指令
            using (SQLiteCommand command = new SQLiteCommand())
            {
                // 設定 SQLiteCommand 物件的屬性
                command.Connection = connection; // 指定連接物件
                command.CommandType = CommandType.Text; // 指定指令類型為文字
                command.CommandText = @"DELETE FROM book WHERE id = @id"; // 指定指令內容為刪除資料

                // 建立一個 SQLiteParameter 物件，用來傳遞參數值給SQL指令
                command.Parameters.Add(new SQLiteParameter("@id", id.ToString())); // 傳遞書籍/電子書編號參數

                // 開啟連接
                connection.Open();

                // 執行SQL指令，並取得影響的資料列數目
                int rowsAffected = command.ExecuteNonQuery();

                // 關閉連接
                connection.Close();

                // 判斷是否有成功刪除資料
                if (rowsAffected > 0)
                {
                    // 輸出成功訊息
                    Console.WriteLine("Book removed successfully.");
                }
            }
        }
    }

    // 定義一個方法，用來修改資料表中的一本書籍/電子書的資訊
    public void UpdateBook(int id, Book book)
    {
        // 建立一個 SQLiteConnection 物件，用來連接到資料庫
        using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        {
            // 建立一個 SQLiteCommand 物件，用來執行SQL指令
            using (SQLiteCommand command = new SQLiteCommand())
            {
                // 設定 SQLiteCommand 物件的屬性
                command.Connection = connection; // 指定連接物件
                command.CommandType = CommandType.Text; // 指定指令類型為文字
                //command.CommandText = "UPDATE book SET title = ?, author = ?, year = ?, publisher = ?, price = ?, format = ? WHERE Id = ?"; // 指定指令內容為更新資料
                command.CommandText = "UPDATE book SET title = @title, author = @author, year = @year, publisher = @publisher, price = @price, format = @format WHERE id = @id"; // 指定指令內容為更新資料

                // 建立一些 SQLiteParameter 物件，用來傳遞參數值給SQL指令
                command.Parameters.Add(new SQLiteParameter("@title", book.Title)); // 傳遞書名參數
                command.Parameters.Add(new SQLiteParameter("@author", book.Author)); // 傳遞作者參數
                command.Parameters.Add(new SQLiteParameter("@year", book.Year.ToString())); // 傳遞出版年份參數
                command.Parameters.Add(new SQLiteParameter("@publisher", book.Publisher)); // 傳遞出版社參數
                command.Parameters.Add(new SQLiteParameter("@price", book.Price.ToString())); // 傳遞價格參數
                command.Parameters.Add(new SQLiteParameter("@format", book.Format)); // 傳遞格式參數
                command.Parameters.Add(new SQLiteParameter("@id", id.ToString())); // 傳遞書籍/電子書編號參數

                // 開啟連接
                connection.Open();

                // 執行SQL指令，並取得影響的資料列數目
                int rowsAffected = command.ExecuteNonQuery();

                // 關閉連接
                connection.Close();

                // 判斷是否有成功更新資料
                if (rowsAffected > 0)
                {
                    // 輸出成功訊息
                    Console.WriteLine("Book updated successfully.");
                }
            }
        }
    }

    // 定義一個方法，用來輸出資料表中所有的書籍/電子書的資訊
    public void PrintAllBooks()
    {
        // 建立一個 SQLiteConnection 物件，用來連接到資料庫
        using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        {
            // 建立一個 SQLiteCommand 物件，用來執行SQL指令
            using (SQLiteCommand command = new SQLiteCommand())
            {
                // 設定 SQLiteCommand 物件的屬性
                command.Connection = connection; // 指定連接物件
                command.CommandType = CommandType.Text; // 指定指令類型為文字
                command.CommandText = "SELECT * FROM book"; // 指定指令內容為查詢所有資料

                // 開啟連接
                connection.Open();

                // 執行SQL指令，並取得一個 SQLiteDataReader 物件，用來讀取資料
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // 判斷是否有資料可以讀取
                    if (reader.HasRows)
                    {
                        // 逐筆讀取資料
                        while (reader.Read())
                        {
                            // 取得每個欄位的值，並建立一個 Book 物件，用來表示一本書籍/電子書的資訊
                            Book book = new Book(
                                reader.GetString(1), // 取得第一個欄位的值，即 title
                                reader.GetString(2), // 取得第二個欄位的值，即 author
                                reader.GetInt32(3),  // 取得第三個欄位的值，即 year
                                reader.GetString(4), // 取得第四個欄位的值，即 publisher
                                reader.GetDouble(5), // 取得第五個欄位的值，即 price
                                reader.GetString(6)  // 取得第六個欄位的值，即 format
                            );

                            // 使用 Book 類別的 PrintInfo 方法來輸出書籍/電子書的資訊
                            book.PrintInfo();
                        }
                    }
                    else
                    {
                        // 輸出沒有資料的訊息
                        Console.WriteLine("No data found.");
                    }
                }

                // 關閉連接
                connection.Close();
            }
        }
    }
}

