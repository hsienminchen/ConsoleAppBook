namespace ConsoleAppBookList;

// 定義一個類別，表示一個收藏書籍/電子書的資料表
public class BookTable
{
    // 定義一個屬性，用來儲存書籍/電子書的清單
    public List<Book> Books { get; set; }

    // 定義一個建構式，用來初始化一個空的資料表
    public BookTable()
    {
        // 建立一個空的清單物件
        Books = new List<Book>();
    }

    // 定義一個方法，用來新增一本書籍/電子書到資料表中
    public void AddBook(Book book)
    {
        // 使用 List 的 Add 方法來將書籍/電子書物件加入到清單中
        Books.Add(book);
    }

    // 定義一個方法，用來移除資料表中的一本書籍/電子書
    public void RemoveBook(int index)
    {
        // 使用 List 的 RemoveAt 方法來將指定索引位置的書籍/電子書物件從清單中移除
        Books.RemoveAt(index);
    }

    // 定義一個方法，用來修改資料表中的一本書籍/電子書的資訊
    public void UpdateBook(int index, Book book)
    {
        // 使用 List 的索引器來將指定索引位置的書籍/電子書物件更新為新的物件
        Books[index] = book;
    }
    // 定義一個方法，用來輸出資料表中所有的書籍/電子書的資訊
    public void PrintAllBooks()
    {
        // 使用 foreach 迴圈來遍歷清單中的每一個元素（即每一本書籍/電子書）
        foreach (Book book in Books)
            // 使用 Book 類別的 PrintInfo 方法來輸出每一本書籍/電子書的資訊
            book.PrintInfo();
    }
}

