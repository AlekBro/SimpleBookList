// -----------------------------------------------------------------------
// <copyright file="BookListService.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using AutoMapper;
    using DAL;
    using DAL.Interfaces;
    using Infrastructure;
    using Interfaces;
    using Models;
    using OfficeOpenXml;
    /// <summary>
    /// Implement IBookListService - used for working with Books
    /// </summary>
    public class BookListService : IBookListService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService" /> class.
        /// </summary>
        /// <param name="unitOfWork">implementation instance of IUnitOfWork interface</param>
        public BookListService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWorkProperty = unitOfWork;
        }

        /// <summary>
        /// Gets Automapper Configuration
        /// </summary>
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        /// <summary>
        /// Gets or sets UnitOfWork class
        /// </summary>
        private IUnitOfWork UnitOfWorkProperty { get; set; }

        /// <summary>
        /// Get collection of all Books
        /// </summary>
        /// <returns>Book models collection</returns>
        public IEnumerable<BookViewModel> GetAllBooks()
        {
            IEnumerable<Book> allBooks = this.UnitOfWorkProperty.BooksRepository.GetAll();

            return this.Mapper.Map<IEnumerable<BookViewModel>>(allBooks);
        }

        /// <summary>
        /// Get one Book by his Id
        /// </summary>
        /// <param name="bookId">Book Id</param>
        /// <returns>Found Book model</returns>
        public BookViewModel GetOneBook(int bookId)
        {
            Book bookItem = this.UnitOfWorkProperty.BooksRepository.Get(bookId);

            return this.Mapper.Map<BookViewModel>(bookItem);
        }

        /// <summary>
        /// Create new Book
        /// </summary>
        /// <param name="bookViewModel">new Book model</param>
        /// <returns>New Book model item</returns>
        public BookViewModel CreateBook(BookViewModel bookViewModel)
        {
            Book newBook = this.Mapper.Map<Book>(bookViewModel);
            if (bookViewModel.AuthorsIds != null)
            {
                newBook.Authors =
                this.UnitOfWorkProperty.AuthorsRepository.Find(x => bookViewModel.AuthorsIds.Contains(x.Id)).ToList();
            }
            
            newBook = this.UnitOfWorkProperty.BooksRepository.Create(newBook);
            this.UnitOfWorkProperty.Save();

            BookViewModel newBookViewModel = this.Mapper.Map<BookViewModel>(newBook);
            return newBookViewModel;
        }

        /// <summary>
        /// Update existing Book
        /// </summary>
        /// <param name="bookViewModel">Book model for update</param>
        public void UpdateBook(BookViewModel bookViewModel)
        {
            Book bookItem = this.UnitOfWorkProperty.BooksRepository.Get(bookViewModel.Id);

            bookItem = this.Mapper.Map(bookViewModel, bookItem);

            bookItem.Authors.Clear();

            if (bookViewModel.AuthorsIds != null)
            {
                foreach (Author item in this.UnitOfWorkProperty
                    .AuthorsRepository.Find(x => bookViewModel.AuthorsIds.Contains(x.Id)).ToList())
                {
                    bookItem.Authors.Add(item);
                } 
            }
            else
            {
                bookItem.Authors = new List<Author>();
            }

            this.UnitOfWorkProperty.BooksRepository.Update(bookItem);

            this.UnitOfWorkProperty.Save();
        }

        /// <summary>
        /// Delete existing Book by his Id
        /// </summary>
        /// <param name="bookId">Book Id</param>
        public void DeleteBook(int bookId)
        {
            Book bookItem = this.UnitOfWorkProperty.BooksRepository.Get(bookId);

            if (bookItem != null)
            {
                this.UnitOfWorkProperty.BooksRepository.Delete(bookItem);
                this.UnitOfWorkProperty.Save();
            }
            else
            {
                throw new ArgumentException("Such Book is not found in the database!");
            }
        }

        /// <summary>
        /// Get All Authors from Database
        /// </summary>
        /// <returns>List of AuthorViewModel</returns>
        public IEnumerable<AuthorViewModel> GetAllAuthors()
        {
            IEnumerable<Author> allAuthors = this.UnitOfWorkProperty.AuthorsRepository.GetAll();
            return this.Mapper.Map<IEnumerable<AuthorViewModel>>(allAuthors);
        }

        /// <summary>
        /// Get one Author by his Id
        /// </summary>
        /// <param name="authorId">Author Id</param>
        /// <returns>Author View Model</returns>
        public AuthorViewModel GetOneAuthor(int authorId)
        {
            Author author = this.UnitOfWorkProperty.AuthorsRepository.Get(authorId);
            return this.Mapper.Map<AuthorViewModel>(author);
        }

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <param name="authorViewModel">new Author View Model</param>
        /// <returns>>new Author View Model</returns>
        public AuthorViewModel CreateAuthor(AuthorViewModel authorViewModel)
        {
            Author author = this.Mapper.Map<Author>(authorViewModel);
            author = this.UnitOfWorkProperty.AuthorsRepository.Create(author);
            this.UnitOfWorkProperty.Save();

            return this.Mapper.Map<AuthorViewModel>(author);
        }

        /// <summary>
        /// Update exist Author
        /// </summary>
        /// <param name="authorViewModel">Author View Model for update</param>
        public void UpdateAuthor(AuthorViewModel authorViewModel)
        {
            Author authorItem = this.UnitOfWorkProperty.AuthorsRepository.Get(authorViewModel.Id);

            authorItem = this.Mapper.Map(authorViewModel, authorItem);

            this.UnitOfWorkProperty.AuthorsRepository.Update(authorItem);
            this.UnitOfWorkProperty.Save();
        }

        /// <summary>
        /// Delete exist Author by his Id
        /// </summary>
        /// <param name="authorId">Author Id</param>
        public void DeleteAuthor(int authorId)
        {
            Author authorItem = this.UnitOfWorkProperty.AuthorsRepository.Get(authorId);

            if (authorItem != null)
            {
                this.UnitOfWorkProperty.AuthorsRepository.Delete(authorItem);
                this.UnitOfWorkProperty.Save();
            }
            else
            {
                throw new ArgumentException("Such Author is not found in the database!");
            }
        }

        /// <summary>
        /// Free any objects here.
        /// </summary>
        public void Dispose()
        {
            this.UnitOfWorkProperty.Dispose();
        }

        /// <summary>
        /// Create new xlsx file with all Books
        /// </summary>
        /// <param name="fullFilePath">Path for file wuth file name</param>
        /// <param name="service">Book list service</param>
        /// <returns>New file bytes for download</returns>
        public byte[] ExportBooksToFile(string fullFilePath)
        {
            FileInfo newFile = new FileInfo(fullFilePath);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(fullFilePath);
            }

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // Add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Books");

                //Add the headers
                worksheet.Cells[1, 1].Value = " --- ID --- ";
                worksheet.Cells[1, 2].Value = " --- Book Name --- ";
                worksheet.Cells[1, 3].Value = " --- Release Date --- ";
                worksheet.Cells[1, 4].Value = " --- Pages --- ";
                worksheet.Cells[1, 5].Value = " --- Rating --- ";
                worksheet.Cells[1, 6].Value = " --- Publisher --- ";
                worksheet.Cells[1, 7].Value = " --- ISBN --- ";
                worksheet.Cells[1, 8].Value = " --- Authors --- ";

                List<BookViewModel> allBooks = GetAllBooks().ToList();

                int y = 2;
                foreach (BookViewModel book in allBooks)
                {
                    worksheet.Cells[y, 1].Value = book.Id;
                    worksheet.Cells[y, 2].Value = book.Name;
                    worksheet.Cells[y, 3].Value = book.ReleaseDate.ToShortDateString();
                    worksheet.Cells[y, 4].Value = book.Pages;
                    worksheet.Cells[y, 5].Value = book.Rating;
                    worksheet.Cells[y, 6].Value = book.Publisher;
                    worksheet.Cells[y, 7].Value = book.ISBN;
                    worksheet.Cells[y, 8].Value = book.AuthorsNames;
                    y = y + 1;
                }

                // Autofit columns for all cells
                worksheet.Cells.AutoFitColumns(0);
                // Lets set the header text bold
                worksheet.Cells["A1:H1"].Style.Font.Bold = true;
                worksheet.Cells["A:H"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["A:H"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                // Create an autofilter for the range
                worksheet.Cells["A1:H1"].AutoFilter = true;

                worksheet.Column(3).Style.Numberformat.Format = "MM/DD/YYYY";

                // Set some document properties
                package.Workbook.Properties.Title = "SimpleBooksList";
                package.Workbook.Properties.Author = "Brova Aleksandr";

                package.Save();
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(fullFilePath);

            return fileBytes;
        }
    }
}
