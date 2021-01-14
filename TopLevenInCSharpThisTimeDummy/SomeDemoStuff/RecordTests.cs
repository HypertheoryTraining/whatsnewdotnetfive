using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SomeDemoStuff
{
   public  class RecordTests
    {
        [Fact]
        public void CanCreateAPerson()
        {
            var bob = new Person("Bob", "Smith");
            Assert.Equal("Bob", bob.FirstName);
            var robert = new Person("Bob", "Smith");

            Assert.Equal(bob, robert);
            Assert.Equal("Person { FirstName = Bob, LastName = Smith }", bob.ToString());

            Person clone1 = bob with { };
            Assert.Equal(bob, clone1);

            //Person clone2 = bob with { FirstName = "Robert" };

            var sue = new Employee("Sue", "Jones", 50000);

            var sueWithRaise = sue with { Salary = 60000 };
            Assert.Equal(60000, sueWithRaise.Salary);
            Assert.Equal(50000, sue.Salary);

        }
        [Fact]
        public void UsingInitProperties()
        {
            var book = new Book
            {
                Id = 3,
                Title = "Walden",
                Author = "Thoreau",
                Genre = "Philosophy"
            };

            //book.Author = "Emerson";
            book.Genre = "Fiction";
        }

        [Fact]
        public void CreatingObjects()
        {
            var b = new Book();

            Book b2 = new() { Title = "C# for Dummies", };

        }
    }

    public class Book
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public string Genre { get; set; }
    }

    public record Person
    {
        public string FirstName { get;  }
        public string LastName { get; }

        public Person(string first, string last) 
            => (FirstName, LastName) = (first, last);
        
    }

    public record Employee(string first, string last, decimal Salary):Person(first, last);

}
