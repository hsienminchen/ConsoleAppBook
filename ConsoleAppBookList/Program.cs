// See https://aka.ms/new-console-template for more information
// 定義一個靜態方法，用來執行測試程式
using ConsoleAppBookList;

// 建立一個 BookTable 物件，表示一個收藏書籍/電子書的資料表
BookTable bookTable = new BookTable();

// 建立一些 Book 物件，表示一些書籍/電子書
Book book1 = new Book("The Catcher in the Rye", "J.D. Salinger", 1951, "Little, Brown and Company", 10.99, "Paperback");
Book book2 = new Book("Nineteen Eighty-Four", "George Orwell", 1949, "Secker & Warburg", 9.99, "Hardcover");
Book book3 = new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 1979, "Pan Books", 7.99, "E-book");

// 使用 BookTable 類別的 AddBook 方法來將書籍/電子書加入到資料表中
bookTable.AddBook(book1);
bookTable.AddBook(book2);
bookTable.AddBook(book3);

// 使用 BookTable 類別的 PrintAllBooks 方法來輸出資料表中所有的書籍/電子書的資訊
bookTable.PrintAllBooks();
// 使用 BookTable 類別的 RemoveBook 方法來移除資料表中的第二本書籍/電子書
bookTable.RemoveBook(1);

// 使用 BookTable 類別的 PrintAllBooks 方法來輸出資料表中所有的書籍/電子書的資訊
bookTable.PrintAllBooks();

// 建立一個新的 Book 物件，表示一本新的書籍/電子書
Book book4 = new Book("The Lord of the Rings", "J.R.R. Tolkien", 1954, "Allen & Unwin", 19.99, "Paperback");

// 使用 BookTable 類別的 UpdateBook 方法來修改資料表中的第三本書籍/電子書為新的書籍/電子書
bookTable.UpdateBook(1, book4);

// 使用 BookTable 類別的 PrintAllBooks 方法來輸出資料表中所有的書籍/電子書的資訊
bookTable.PrintAllBooks();
