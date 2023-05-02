using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppBookSQLEFCore;

// 定義一個類別，表示一個收藏書籍/電子書的資料表
public class BookTable : DbContext
{
    // 定義一個屬性，用來表示書籍/電子書的資料集合
    public DbSet<Book> Book { get; set; }

    // 覆寫 OnConfiguring 方法，用來設定資料庫連接字串
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 使用 UseSqlServer 方法來指定連接 MSSQL 資料庫
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BingSQL;User=sa;Password=Oliver69700525$;TrustServerCertificate=true;");
    }

    // 覆寫 OnModelCreating 方法，用來設定資料表和欄位的約束條件
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // 使用 HasKey 方法來指定哪個屬性是主鍵
    //    modelBuilder.Entity<Book>().HasKey(b => b.Id);

    //    //// 使用 HasIdentity 方法來指定哪個屬性是自動遞增
    //    //modelBuilder.Entity<Book>().Property(b => b.Id).HasIdentity();
    //}

    public void PrintAllBooks()
    {
        BookTable bookTable = new BookTable();
        // 使用 BookTable 類別的 Books 屬性來查詢資料集合中所有的書籍/電子書
        var books = bookTable.Book.ToList();

        // 遍歷資料集合中的每一個書籍/電子書物件
        foreach (var book in books)
        {
            // 使用 Book 類別的 PrintInfo 方法來輸出書籍/電子書的資訊
            book.PrintInfo();
        }

    }
}

