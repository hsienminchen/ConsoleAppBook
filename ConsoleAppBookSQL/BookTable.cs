using System.Data;
using System.Data.SqlClient;

namespace ConsoleAppBookSQL;

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
    }

    // 定義一個方法，用來新增一本書籍/電子書到資料表中
    public void AddBook(Book book)
    {
        // 建立一個 SqlConnection 物件，用來連接到資料庫
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            // 建立一個 SqlCommand 物件，用來執行SQL指令
            using (SqlCommand command = new SqlCommand())
            {
                // 設定 SqlCommand 物件的屬性
                command.Connection = connection; // 指定連接物件
                command.CommandType = CommandType.Text; // 指定指令類型為文字
                command.CommandText = "INSERT INTO book (title, author, year, publisher, price, format) VALUES (@title, @author, @year, @publisher, @price, @format)"; // 指定指令內容為插入資料

                // 建立一些 SqlParameter 物件，用來傳遞參數值給SQL指令
                command.Parameters.AddWithValue("@title", book.Title); // 傳遞書名參數
                command.Parameters.AddWithValue("@author", book.Author); // 傳遞作者參數
                command.Parameters.AddWithValue("@year", book.Year); // 傳遞出版年份參數
                command.Parameters.AddWithValue("@publisher", book.Publisher); // 傳遞出版社參數
                command.Parameters.AddWithValue("@price", book.Price); // 傳遞價格參數
                command.Parameters.AddWithValue("@format", book.Format); // 傳遞格式參數

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
                else
                {
                    // 輸出失敗訊息
                    Console.WriteLine("Book added failed.");
                }
            }
        }
    }

    // 定義一個方法，用來移除資料表中的一本書籍/電子書
    public void RemoveBook(int id)
    {
        // 建立一個 SqlConnection 物件，用來連接到資料庫
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            // 建立一個 SqlCommand 物件，用來執行SQL指令
            using (SqlCommand command = new SqlCommand())
            {
                // 設定 SqlCommand 物件的屬性
                command.Connection = connection; // 指定連接物件
                command.CommandType = CommandType.Text; // 指定指令類型為文字
                command.CommandText = "DELETE FROM book WHERE id = @id"; // 指定指令內容為刪除資料

                // 建立一個 SqlParameter 物件，用來傳遞參數值給SQL指令
                command.Parameters.AddWithValue("@id", id); // 傳遞書籍/電子書的編號參數

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
                else
                {
                    // 輸出失敗訊息
                    Console.WriteLine("Book removed failed.");
                }
            }
        }
    }

    // 定義一個方法，用來修改資料表中的一本書籍/電子書的資訊
    public void UpdateBook(int id, Book book)
    {
        // 建立一個 SqlConnection 物件，用來連接到資料庫
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            // 建立一個 SqlCommand 物件，用來執行SQL指令
            using (SqlCommand command = new SqlCommand())
            {
                // 設定 SqlCommand 物件的屬性
                command.Connection = connection; // 指定連接物件
                command.CommandType = CommandType.Text; // 指定指令類型為文字
                command.CommandText = "UPDATE book SET title = @title, author = @author, year = @year, publisher = @publisher, price = @price, format = @format WHERE id = @id"; // 指定指令內容為更新資料

                // 建立一些 SqlParameter 物件，用來傳遞參數值給SQL指令
                command.Parameters.AddWithValue("@id", id); // 傳遞書籍/電子書的編號參數
                command.Parameters.AddWithValue("@title", book.Title); // 傳遞書名參數
                command.Parameters.AddWithValue("@author", book.Author); // 傳遞作者參數
                command.Parameters.AddWithValue("@year", book.Year); // 傳遞出版年份參數
                command.Parameters.AddWithValue("@publisher", book.Publisher); // 傳遞出版社參數
                command.Parameters.AddWithValue("@price", book.Price); // 傳遞價格參數
                command.Parameters.AddWithValue("@format", book.Format); // 傳遞格式參數

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
                else
                {
                    // 輸出失敗訊息
                    Console.WriteLine("Book updated failed.");
                }
            }
        }
    }

    // 定義一個方法，用來查詢資料表中的所有書籍/電子書的資訊，並回傳一個清單
    public List<Book> QueryAllBooks()
    {
        // 建立一個空的清單物件，用來儲存查詢結果
        List<Book> books = new List<Book>();

        // 建立一個 SqlConnection 物件，用來連接到資料庫
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            // 建立一個 SqlCommand 物件，用來執行SQL指令
            using (SqlCommand command = new SqlCommand())
            {
                // 設定 SqlCommand 物件的屬性
                command.Connection = connection; // 指定連接物件
                command.CommandType = CommandType.Text; // 指定指令類型為文字
                command.CommandText = "SELECT * FROM book"; // 指定指令內容為查詢所有資料

                // 開啟連接
                connection.Open();

                // 執行SQL指令，並取得一個 SqlDataReader 物件，用來讀取查詢結果
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // 使用 while 迴圈來遍歷 SqlDataReader 物件中的每一筆資料
                    while (reader.Read())
                    {
                        // 使用 SqlDataReader 物件的索引器或 GetXXX 方法來取得每一個欄位的值
                        int id = reader.GetInt32(0); // 取得第一個欄位（id）的值，型別為 int
                        string title = reader.GetString(1); // 取得第二個欄位（title）的值，型別為 string
                        string author = reader.GetString(2); // 取得第三個欄位（author）的值，型別為 string
                        int year = reader.GetInt32(3); // 取得第四個欄位（year）的值，型別為 int
                        string publisher = reader.GetString(4); // 取得第五個欄位（publisher）的值，型別為 string
                        double price = (double)reader.GetDecimal(5); // 取得第六個欄位（price）的值，型別為 double
                        string format = reader.GetString(6); // 取得第七個欄位（format）的值，型別為 string

                        // 建立一個 Book 物件，用來表示一本書籍/電子書，並將讀取到的值指派給它的屬性
                        Book book = new Book(title, author, year, publisher, price, format);

                        // 將 Book 物件加入到清單中
                        books.Add(book);
                    }
                }

                // 關閉連接
                connection.Close();
            }
        }

        // 回傳清單物件
        return books;
    }

    // 定義一個方法，用來輸出資料表中所有的書籍/電子書的資訊
    public void PrintAllBooks()
    {
        // 使用 QueryAllBooks 方法來查詢資料表中所有的書籍/電子書的資訊，並將回傳的清單物件指派給一個變數
        List<Book> books = QueryAllBooks();

        // 使用 foreach 迴圈來遍歷清單中的每一個元素（即每一本書籍/電子書）
        foreach (Book book in books)
            // 使用 Book 類別的 PrintInfo 方法來輸出每一本書籍/電子書的資訊
            book.PrintInfo();
    }
}

