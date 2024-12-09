using System;
using System.Collections.Generic;


namespace _04_Two_Generics_Parms
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Library Manager = new Library();
            Manager.AddB(new Book("1984", "Джордж Оруэлл"));
            Manager.AddB(new Book("Мастер и Маргарита", "Михаил Булгаков"));
            Manager.AddB(new Book("Война и мир", "Лев Толстой"));

            Console.WriteLine("\nВсе книги:");
            Manager.PrintBooks();


            Console.WriteLine("\nВставка книг:");
            Manager.InsertAtStart(new Book("Отцы и дети", "Иван Тургенев"));
            Manager.InsertAtEnd(new Book("Преступление и наказание", "Фёдор Достоевский"));
            Manager.InsertAtPosition(new Book("Анна Каренина", "Лев Толстой"), 2);
            Manager.PrintBooks();


            Console.WriteLine("\nОбновление книги:");
            Manager.Update("1984", new Book("1984", "Джордж Смит"));
            Manager.PrintBooks();


            Console.WriteLine("\nУдаление книг:");
            Manager.RemoveFromStart();
            Manager.RemoveFromEnd();
            Manager.RemoveAtPosition(1);
            Manager.PrintBooks();




            // 1 Task //
            //Work workManager = new Work();


            //workManager.AddWork(new Employee("Иван Иванов", "Менеджер", 60000, "ivanov@example.com"));
            //workManager.AddWork(new Employee("Петр Петров", "Разработчик", 80000, "petrov@example.com"));
            //workManager.AddWork(new Employee("Анна Смирнова", "Аналитик", 70000, "smirnova@example.com"));


            //Console.WriteLine("\nСотрудники после сортировки по должности:");
            //var sortedEmployees = workManager.SortByJob();
            //workManager.PrintEmployees(sortedEmployees);


            //Console.WriteLine("\nОбновление сотрудника:");
            //workManager.Update("ivanov@example.com", new Employee("Иван Сидоров", "Директор", 90000, "ivanov@example.com"));


            //Console.WriteLine("\nУдаление сотрудника:");
            //workManager.RemoveWork("petrov@example.com");


            //Console.WriteLine("\nПоиск сотрудников с зарплатой 70000:");
            //var foundEmployees = workManager.Search(70000);
            //workManager.PrintEmployees(foundEmployees);
        }
    }

    class Book
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public Book(string name,string info) 
        { 
            Name = name;
            Info = info;
        }
        public override string ToString()
        {
            return $"{Name}, {Info}";
        }
    }
    class Library
    {
        public LinkedList<Book> books = new LinkedList<Book>();
        public void AddB(Book book)
        {
            books.AddLast(book);
            Console.WriteLine($"Книга была успешно добавлена / {book.Name} /");
        }

        public void RemoveB(Book book)
        {
            if(book != null)
            {
                books.Remove(book);
                Console.WriteLine($" Книгу удалили {book.Name}");
            }
            else
            {
                Console.WriteLine(" Nouu  book");
            }
        }
        public void Update(string name, Book book)
        {
            if (book != null)
            {
                book.Name = book.Name;
                book.Info = book.Info;
                Console.WriteLine($"Книга \"{name}\" обновлена.");
            }
            else
            {
                Console.WriteLine($"Книга \"{name}\" не найдена.");
            }
        }
        public void InsertAtStart(Book book)
        {
            books.AddFirst(book);
            Console.WriteLine($"Книга \"{book.Name}\" вставлена в начало.");
        }

        public void InsertAtEnd(Book book)
        {
            books.AddLast(book);
            Console.WriteLine($"Книга \"{book.Name}\" вставлена в конец.");
        }
        public void InsertAtPosition(Book book, int position)
        {
            if (position < 0 || position >= books.Count)
            {
                Console.WriteLine("Некорректная позиция.");
                return;
            }

            var current = books.First;
            for (int i = 0; i < position && current != null; i++)
            {
                current = current.Next;
            }
            books.AddBefore(current, book);
            Console.WriteLine($"Книга \"{book.Name}\" вставлена на позицию {position}.");
        }

        public void RemoveFromStart()
        {
            if (books.Count > 0)
            {
                Console.WriteLine($"Книга \"{books.First.Value.Name}\" удалена из начала.");
                books.RemoveFirst();
            }
            else
            {
                Console.WriteLine("Список пуст.");
            }
        }

        public void RemoveFromEnd()
        {
            if (books.Count > 0)
            {
                Console.WriteLine($"Книга \"{books.Last.Value.Name}\" удалена из конца.");
                books.RemoveLast();
            }
            else
            {
                Console.WriteLine("Список пуст.");
            }
        }
        public void RemoveAtPosition(int position)
        {
            if (position < 0 || position >= books.Count)
            {
                Console.WriteLine("Некорректная позиция.");
                return;
            }

            var current = books.First;
            for (int i = 0; i < position && current != null; i++)
            {
                current = current.Next;
            }

            if (current != null)
            {
                Console.WriteLine($"Книга \"{current.Value.Name}\" удалена с позиции {position}.");
                books.Remove(current);
            }
        }
        public void PrintBooks(IEnumerable<Book> booksToPrint = null)
        {
            var list = booksToPrint ?? books;
            if (!list.Any())
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            foreach (var book in list)
            {
                Console.WriteLine(book);
            }
        }

    }












    //class Employee : IComparable<Employee>
    //{
    //    public string Fio { get; set; }
    //    public string Job { get; set; }
    //    public int Payment { get; set; }
    //    public string Email { get; set; }

    //    public Employee(string fio, string job, int payment, string email)
    //    {
    //        Fio = fio;
    //        Job = job;
    //        Payment = payment;
    //        Email = email;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Fio} , {Job} , {Payment} , {Email}";
    //    }

    //    public int CompareTo(Employee other)
    //    {
    //        if (other == null) throw new ArgumentNullException(nameof(other));
    //        return string.Compare(Job, other.Job, StringComparison.OrdinalIgnoreCase);
    //    }
    //}

    //class Work
    //{
    //    public List<Employee> works = new List<Employee>();
    //    public void AddWork(Employee emp)
    //    {
    //        if (works.Any(e => e.Email == emp.Email))
    //        {
    //            Console.WriteLine("Сотрудник с таким email уже существует");
    //            return;
    //        }
    //        works.Add(emp);
    //        Console.WriteLine("Сотрудника успешно добавили");
    //    }

    //    public void RemoveWork(string email)
    //    {
    //        
    //        if (employee != null)
    //        {
    //            works.Remove(employee);
    //            Console.WriteLine("Сотрудника удалили");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Сотрудник с таким email не найден");
    //        }
    //    }

    //    public void Update(string email, Employee emp)
    //    {
    //        
    //        if (employee != null)
    //        {
    //            employee.Fio = emp.Fio;
    //            employee.Job = emp.Job;
    //            employee.Payment = emp.Payment;
    //            employee.Email = emp.Email;
    //            Console.WriteLine("/ Updated /");
    //        }
    //        else
    //        {
    //            Console.WriteLine("We haven't found your email");
    //        }
    //    }

    //    public List<Employee> Search(int payment)
    //    {
    //        return works.Where(e => e.Payment == payment).ToList();
    //    }

    //    public List<Employee> SortByJob()
    //    {
    //        return works.OrderBy(e => e.Job).ToList();
    //    }

    //    public void PrintEmployees(IEnumerable<Employee> employees)
    //    {
    //        foreach (var employee in employees)
    //        {
    //            Console.WriteLine(employee);
    //        }
    //    }
    //}
}
