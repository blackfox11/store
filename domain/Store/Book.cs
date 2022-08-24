namespace Store;
// Эрик Эванс "Предметно-ориентированное проектирование: структуризация сложных программных систем"
public class Book
{
    public int Id { get; }
    public string Title { get; }
    public Book(int id, string title)
    {
        Id = id;
        Title = title;
    }
}
