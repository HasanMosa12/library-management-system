using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TDD
{
    public partial class Form1 : Form
    {
        private List<Book> books = new List<Book>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ISBN_TextChanged(object sender, EventArgs e)
        {
        }

        private void BookName_TextChanged(object sender, EventArgs e)
        {
        }

        private void AutherName_TextChanged(object sender, EventArgs e)
        {
        }

        private void PublichYear_TextChanged(object sender, EventArgs e)
        {
        }

        private void Catorgy_TextChanged(object sender, EventArgs e)
        {
        }

        private void QStatus_TextChanged(object sender, EventArgs e)
        {
        }

        private void ISBN1_TextChanged(object sender, EventArgs e)
        {
        }

        private void BookName1_TextChanged(object sender, EventArgs e)
        {
        }

        private void AutherName1_TextChanged(object sender, EventArgs e)
        {
        }

        private void PublichYear1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Catorgy1_TextChanged(object sender, EventArgs e)
        {
        }

        private void QStatus1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Addbooks_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var categories = new[] { "Science Fiction", "Romance", "History", "Biography" };
            var bookNames = new[] { "Book1", "Book2", "Book3" }; // Add more names as needed
            var authorNames = new[] { "Author1", "Author2", "Author3" }; // Add more names as needed

            for (int i = 0; i < 10000; i++)
            {
                var book = new Book
                {
                    ISBN = random.Next(1000000, 9999999).ToString(),
                    Name = bookNames[random.Next(bookNames.Length)],
                    Author = authorNames[random.Next(authorNames.Length)],
                    PublishYear = random.Next(1900, 2024),
                    Category = categories[random.Next(categories.Length)],
                    IsBorrowed = random.Next(2) == 1
                };
                books.Add(book);
            }

            MessageBox.Show("10,000 books generated successfully!");
        }


        private void Insertbook_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Create a new book object and populate it with data from the form inputs
                var book = new Book
                {
                    ISBN = ISBN.Text,
                    Name = BookName.Text,
                    Author = AutherName.Text,
                    PublishYear = int.Parse(PublichYear.Text),
                    Category = Catorgy.Text,
                    IsBorrowed = QStatus.Text == "Borrowed"
                };

                // Add the book to the books list (ensure you have a list named 'books' defined elsewhere in your class)
                books.Add(book);

                // Notify the user that the book has been successfully added
                MessageBox.Show("Book added successfully!");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the book addition process
                MessageBox.Show("Error adding book: " + ex.Message);
            }
        }




        private void Bookslist_Click(object sender, EventArgs e)
        {
            var sortedBooks = BubbleSortBooksByPublishYear(books);

            // Calculate statistics
            int totalBooks = sortedBooks.Count;
            double averageYear = sortedBooks.Average(book => book.PublishYear);
            int availableBooks = sortedBooks.Count(book => !book.IsBorrowed);

            // Display report
            string report = $"Total Books: {totalBooks}\nAverage Publish Year: {averageYear:F2}\nAvailable Books: {availableBooks}\n";
            report += "Books:\n";

            foreach (var book in sortedBooks)
            {
                report += $"{book.ISBN}, {book.Name}, {book.Author}, {book.PublishYear}, {book.Category}, {(book.IsBorrowed ? "Borrowed" : "Available")}\n";
            }

            MessageBox.Show(report);
        }

        private List<Book> BubbleSortBooksByPublishYear(List<Book> bookList)
        {
            int n = bookList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (bookList[j].PublishYear < bookList[j + 1].PublishYear)
                    {
                        // Swap
                        var temp = bookList[j];
                        bookList[j] = bookList[j + 1];
                        bookList[j + 1] = temp;
                    }
                }
            }
            return bookList;
        }
    }

    public class Book
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public string Category { get; set; }
        public bool IsBorrowed { get; set; }
    }
}
