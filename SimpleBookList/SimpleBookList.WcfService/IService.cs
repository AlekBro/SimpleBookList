using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SimpleBookList.Models;

namespace SimpleBookList.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<BookViewModel> GetBookList();

        [OperationContract]
        BookViewModel GetBookById(int id);

        [OperationContract]
        int? AddNewBook(BookViewModel newBook);

        [OperationContract]
        bool DeleteBookById(int bookId);

        [OperationContract]
        BookViewModel EditBook(BookViewModel inputBook);


        [OperationContract]
        List<AuthorViewModel> GetAuthorList();

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
