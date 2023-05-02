// 定義一個靜態方法，用來執行測試程式
using ConsoleAppBookSQLEFCore;
using System.Linq;

// 建立一個 BookTable 物件，表示一個收藏書籍/電子書的資料庫內容
BookTable bookTable = new BookTable();

// 建立一些 Book 物件，表示一些書籍/電子書
Book book1 = new Book("The Catcher in the Rye", "J.D. Salinger", 1951, "Little, Brown and Company", 10.99, "Paperback");
Book book2 = new Book("Nineteen Eighty-Four", "George Orwell", 1949, "Secker & Warburg", 9.99, "Hardcover");
Book book3 = new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 1979, "Pan Books", 7.99, "E-book");

//// 使用 BookTable 類別的 Add 方法來將書籍/電子書加入到資料集合中
//bookTable.Book.Add(book1);
//bookTable.Book.Add(book2);
//bookTable.Book.Add(book3);

//// 使用 BookTable 類別的 SaveChanges 方法來將資料集合的變更同步到資料庫中
//bookTable.SaveChanges();

// 使用 BookTable 類別的 PrintAllBooks 方法來輸出資料表中所有的書籍/電子書的資訊
bookTable.PrintAllBooks();

//// 使用 BookTable 類別的 Find 方法來查詢資料集合中的第二本書籍/電子書
Book delbook = bookTable.Book.Find(1);
//Book delbook = bookTable.Book.Where<Book>(x => x.Id == 1).FirstOrDefault();
if (delbook != null)
{
    //使用 BookTable 類別的 Remove 方法來移除資料集合中的第二本書籍 / 電子書
    bookTable.Book.Remove(delbook);
}

// 使用 BookTable 類別的 SaveChanges 方法來將資料集合的變更同步到資料庫中
bookTable.SaveChanges();

//// 使用 BookTable 類別的 PrintAllBooks 方法來輸出資料表中所有的書籍/電子書的資訊
//bookTable.PrintAllBooks();

// 建立一個新的 Book 物件，表示一本新的書籍/電子書
Book book4 = new Book("The Lord of the Ringsx", "J.R.R. Tolkien", 1954, "Allen & Unwin", 19.99, "Paperback");

// 使用 BookTable 類別的 Find 方法來查詢資料集合中的第三本書籍/電子書
var updbook = bookTable.Book.Find(2);

// 將第三本書籍/電子書物件的屬性值修改為新的書籍/電子書物件的屬性值
book3.Title = book4.Title;
book3.Author = book4.Author;
book3.Year = book4.Year;
book3.Publisher = book4.Publisher;
book3.Price = book4.Price;
book3.Format = book4.Format;

// 使用 BookTable 類別的 SaveChanges 方法來將資料集合的變更同步到資料庫中
bookTable.SaveChanges();

// 使用 BookTable 類別的 PrintAllBooks 方法來輸出資料表中所有的書籍/電子書的資訊
bookTable.PrintAllBooks();