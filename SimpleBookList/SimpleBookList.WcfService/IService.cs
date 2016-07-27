using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SimpleBookList.Models;
using SimpleBookList.Models.DataTableModels;

namespace SimpleBookList.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<BookViewModel> GetBookList();


        [OperationContract]
        DTResult<BookViewModel> GetBooks(DTParameters param);


        [OperationContract]
        BookViewModel GetBookById(int id);

        [OperationContract]
        int? AddNewBook(BookViewModel newBook);

        [OperationContract]
        bool DeleteBookById(int bookId);

        [OperationContract]
        BookViewModel EditBook(BookViewModel inputBook);

        /// <summary>
        /// Old Version
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<AuthorViewModel> GetAuthorList();

        /// <summary>
        /// New version - for filtering on server
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationContract]
        DTResult<AuthorViewModel> GetAuthors(DTParameters param);

        [OperationContract]
        AuthorViewModel GetAuthorById(int id);

        [OperationContract]
        int? AddNewAuthor(AuthorViewModel newAuthor);

        [OperationContract]
        bool DeleteAuthorById(int authorId);

        [OperationContract]
        AuthorViewModel EditAuthor(AuthorViewModel inputAuthor);
    }


   
}
