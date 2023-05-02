using Azure.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;

namespace ConsoleAppBookSQLEFCore;


// 定義一個類別，表示一本書籍/電子書
public class Book
{
    // 定義一些屬性，如書名、作者、出版年份、出版社、價格、格式等
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string Publisher { get; set; }
    public decimal Price { get; set; }
    public string Format { get; set; } // 可以是 "Paperback", "Hardcover", "E-book" 等

    // 定義一個建構式，用來初始化一個書籍/電子書物件
    public Book(string title, string author, int year, string publisher, double price, string format)
    {
        // 將參數值指派給屬性
        Title = title;
        Author = author;
        Year = year;
        Publisher = publisher;
        Price = (decimal)price;
        Format = format;
    }
    public Book(string title, string author, int year, string publisher, decimal price, string format)
    {
        // 將參數值指派給屬性
        Title = title;
        Author = author;
        Year = year;
        Publisher = publisher;
        Price = price;
        Format = format;
    }

    // 定義一個方法，用來輸出書籍/電子書的資訊
    public void PrintInfo()
    {
        // 使用 Console.WriteLine 方法來輸出屬性值
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Year: " + Year);
        Console.WriteLine("Publisher: " + Publisher);
        Console.WriteLine("Price: " + Price);
        Console.WriteLine("Format: " + Format);
        Console.WriteLine(); // 空行
    }

//use BingSQL
//go

//CREATE TABLE book(
//    id INT PRIMARY KEY IDENTITY(1,1),
//    title VARCHAR(50) NOT NULL,
//    author VARCHAR(50) NOT NULL,
//    year INT NOT NULL,
//    publisher VARCHAR(50) NOT NULL,
//    price DECIMAL(10,2) NOT NULL,
//    format VARCHAR(10) NOT NULL
//);
}

