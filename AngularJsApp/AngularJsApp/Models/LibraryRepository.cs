using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsApp.Models
{
    public class LibraryRepository
    {
        static AuthorViewModel[] authors = {
                new AuthorViewModel { Id= "A001", Name= "Alexandre Dumas", WrittenBooks= 35 },
                new AuthorViewModel { Id= "A002", Name= "Charles Dickens",  WrittenBooks= 55 },
                new AuthorViewModel { Id= "A003", Name= "Charlotte Brontë", WrittenBooks= 48 },
                new AuthorViewModel { Id= "A004", Name= "F. Scott Fitzgerald",  WrittenBooks= 36 }
            };

        public AuthorViewModel[] GetAuthors()
        {
            return authors;
        }

        public void AddAuthor(AuthorViewModel author)
        {
            authors = authors.Concat(new[] { author }).ToArray();
        }

        public BookViewModel[] GetBooks()
        {
            var books = new[]
            {
                new BookViewModel { Isbn= "9781440750694", Title= "Of Mice and Men", Author= "John Steinbeck", Genre = "Novella", Price= 288, Cover="http://www.steinbeck.org/assets/images/assets/632/large_omamcoverlarge_.jpeg" },
                new BookViewModel { Isbn= "9781848373099", Title= "Sense and Sensibility", Author= "Jane Austen", Genre = "Romance novel", Price= 354, Cover="http://aspiritedmind.com/wp-content/uploads/2013/02/sense-and-sensibility.jpg"},
                new BookViewModel { Isbn= "9786155529269", Title= "The Little Prince", Author= "Antoine de Saint-Exupéry", Genre = "Play", Price= 68, Cover="http://www.merawan.com/wp-content/uploads/2011/05/IMHO-Books-The-Little-Prince.jpg" }
            };
            return books;
        }
    }
}