﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleBookList.WcfUI.BooksListServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BooksListServiceReference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetBookList", ReplyAction="http://tempuri.org/IService/GetBookListResponse")]
        SimpleBookList.Models.BookViewModel[] GetBookList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetBookList", ReplyAction="http://tempuri.org/IService/GetBookListResponse")]
        System.Threading.Tasks.Task<SimpleBookList.Models.BookViewModel[]> GetBookListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetBooks", ReplyAction="http://tempuri.org/IService/GetBooksResponse")]
        SimpleBookList.Models.DataTableModels.DTResult<SimpleBookList.Models.BookViewModel> GetBooks(SimpleBookList.Models.DataTableModels.DTParameters param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetBooks", ReplyAction="http://tempuri.org/IService/GetBooksResponse")]
        System.Threading.Tasks.Task<SimpleBookList.Models.DataTableModels.DTResult<SimpleBookList.Models.BookViewModel>> GetBooksAsync(SimpleBookList.Models.DataTableModels.DTParameters param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetBookById", ReplyAction="http://tempuri.org/IService/GetBookByIdResponse")]
        SimpleBookList.Models.BookViewModel GetBookById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetBookById", ReplyAction="http://tempuri.org/IService/GetBookByIdResponse")]
        System.Threading.Tasks.Task<SimpleBookList.Models.BookViewModel> GetBookByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddNewBook", ReplyAction="http://tempuri.org/IService/AddNewBookResponse")]
        System.Nullable<int> AddNewBook(SimpleBookList.Models.BookViewModel newBook);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddNewBook", ReplyAction="http://tempuri.org/IService/AddNewBookResponse")]
        System.Threading.Tasks.Task<System.Nullable<int>> AddNewBookAsync(SimpleBookList.Models.BookViewModel newBook);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteBookById", ReplyAction="http://tempuri.org/IService/DeleteBookByIdResponse")]
        bool DeleteBookById(int bookId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteBookById", ReplyAction="http://tempuri.org/IService/DeleteBookByIdResponse")]
        System.Threading.Tasks.Task<bool> DeleteBookByIdAsync(int bookId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditBook", ReplyAction="http://tempuri.org/IService/EditBookResponse")]
        SimpleBookList.Models.BookViewModel EditBook(SimpleBookList.Models.BookViewModel inputBook);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditBook", ReplyAction="http://tempuri.org/IService/EditBookResponse")]
        System.Threading.Tasks.Task<SimpleBookList.Models.BookViewModel> EditBookAsync(SimpleBookList.Models.BookViewModel inputBook);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAuthorList", ReplyAction="http://tempuri.org/IService/GetAuthorListResponse")]
        SimpleBookList.Models.AuthorViewModel[] GetAuthorList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAuthorList", ReplyAction="http://tempuri.org/IService/GetAuthorListResponse")]
        System.Threading.Tasks.Task<SimpleBookList.Models.AuthorViewModel[]> GetAuthorListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAuthors", ReplyAction="http://tempuri.org/IService/GetAuthorsResponse")]
        SimpleBookList.Models.DataTableModels.DTResult<SimpleBookList.Models.AuthorViewModel> GetAuthors(SimpleBookList.Models.DataTableModels.DTParameters param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAuthors", ReplyAction="http://tempuri.org/IService/GetAuthorsResponse")]
        System.Threading.Tasks.Task<SimpleBookList.Models.DataTableModels.DTResult<SimpleBookList.Models.AuthorViewModel>> GetAuthorsAsync(SimpleBookList.Models.DataTableModels.DTParameters param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAuthorById", ReplyAction="http://tempuri.org/IService/GetAuthorByIdResponse")]
        SimpleBookList.Models.AuthorViewModel GetAuthorById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAuthorById", ReplyAction="http://tempuri.org/IService/GetAuthorByIdResponse")]
        System.Threading.Tasks.Task<SimpleBookList.Models.AuthorViewModel> GetAuthorByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddNewAuthor", ReplyAction="http://tempuri.org/IService/AddNewAuthorResponse")]
        System.Nullable<int> AddNewAuthor(SimpleBookList.Models.AuthorViewModel newAuthor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddNewAuthor", ReplyAction="http://tempuri.org/IService/AddNewAuthorResponse")]
        System.Threading.Tasks.Task<System.Nullable<int>> AddNewAuthorAsync(SimpleBookList.Models.AuthorViewModel newAuthor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteAuthorById", ReplyAction="http://tempuri.org/IService/DeleteAuthorByIdResponse")]
        bool DeleteAuthorById(int authorId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteAuthorById", ReplyAction="http://tempuri.org/IService/DeleteAuthorByIdResponse")]
        System.Threading.Tasks.Task<bool> DeleteAuthorByIdAsync(int authorId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditAuthor", ReplyAction="http://tempuri.org/IService/EditAuthorResponse")]
        SimpleBookList.Models.AuthorViewModel EditAuthor(SimpleBookList.Models.AuthorViewModel inputAuthor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditAuthor", ReplyAction="http://tempuri.org/IService/EditAuthorResponse")]
        System.Threading.Tasks.Task<SimpleBookList.Models.AuthorViewModel> EditAuthorAsync(SimpleBookList.Models.AuthorViewModel inputAuthor);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : SimpleBookList.WcfUI.BooksListServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<SimpleBookList.WcfUI.BooksListServiceReference.IService>, SimpleBookList.WcfUI.BooksListServiceReference.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SimpleBookList.Models.BookViewModel[] GetBookList() {
            return base.Channel.GetBookList();
        }
        
        public System.Threading.Tasks.Task<SimpleBookList.Models.BookViewModel[]> GetBookListAsync() {
            return base.Channel.GetBookListAsync();
        }
        
        public SimpleBookList.Models.DataTableModels.DTResult<SimpleBookList.Models.BookViewModel> GetBooks(SimpleBookList.Models.DataTableModels.DTParameters param) {
            return base.Channel.GetBooks(param);
        }
        
        public System.Threading.Tasks.Task<SimpleBookList.Models.DataTableModels.DTResult<SimpleBookList.Models.BookViewModel>> GetBooksAsync(SimpleBookList.Models.DataTableModels.DTParameters param) {
            return base.Channel.GetBooksAsync(param);
        }
        
        public SimpleBookList.Models.BookViewModel GetBookById(int id) {
            return base.Channel.GetBookById(id);
        }
        
        public System.Threading.Tasks.Task<SimpleBookList.Models.BookViewModel> GetBookByIdAsync(int id) {
            return base.Channel.GetBookByIdAsync(id);
        }
        
        public System.Nullable<int> AddNewBook(SimpleBookList.Models.BookViewModel newBook) {
            return base.Channel.AddNewBook(newBook);
        }
        
        public System.Threading.Tasks.Task<System.Nullable<int>> AddNewBookAsync(SimpleBookList.Models.BookViewModel newBook) {
            return base.Channel.AddNewBookAsync(newBook);
        }
        
        public bool DeleteBookById(int bookId) {
            return base.Channel.DeleteBookById(bookId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteBookByIdAsync(int bookId) {
            return base.Channel.DeleteBookByIdAsync(bookId);
        }
        
        public SimpleBookList.Models.BookViewModel EditBook(SimpleBookList.Models.BookViewModel inputBook) {
            return base.Channel.EditBook(inputBook);
        }
        
        public System.Threading.Tasks.Task<SimpleBookList.Models.BookViewModel> EditBookAsync(SimpleBookList.Models.BookViewModel inputBook) {
            return base.Channel.EditBookAsync(inputBook);
        }
        
        public SimpleBookList.Models.AuthorViewModel[] GetAuthorList() {
            return base.Channel.GetAuthorList();
        }
        
        public System.Threading.Tasks.Task<SimpleBookList.Models.AuthorViewModel[]> GetAuthorListAsync() {
            return base.Channel.GetAuthorListAsync();
        }
        
        public SimpleBookList.Models.DataTableModels.DTResult<SimpleBookList.Models.AuthorViewModel> GetAuthors(SimpleBookList.Models.DataTableModels.DTParameters param) {
            return base.Channel.GetAuthors(param);
        }
        
        public System.Threading.Tasks.Task<SimpleBookList.Models.DataTableModels.DTResult<SimpleBookList.Models.AuthorViewModel>> GetAuthorsAsync(SimpleBookList.Models.DataTableModels.DTParameters param) {
            return base.Channel.GetAuthorsAsync(param);
        }
        
        public SimpleBookList.Models.AuthorViewModel GetAuthorById(int id) {
            return base.Channel.GetAuthorById(id);
        }
        
        public System.Threading.Tasks.Task<SimpleBookList.Models.AuthorViewModel> GetAuthorByIdAsync(int id) {
            return base.Channel.GetAuthorByIdAsync(id);
        }
        
        public System.Nullable<int> AddNewAuthor(SimpleBookList.Models.AuthorViewModel newAuthor) {
            return base.Channel.AddNewAuthor(newAuthor);
        }
        
        public System.Threading.Tasks.Task<System.Nullable<int>> AddNewAuthorAsync(SimpleBookList.Models.AuthorViewModel newAuthor) {
            return base.Channel.AddNewAuthorAsync(newAuthor);
        }
        
        public bool DeleteAuthorById(int authorId) {
            return base.Channel.DeleteAuthorById(authorId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAuthorByIdAsync(int authorId) {
            return base.Channel.DeleteAuthorByIdAsync(authorId);
        }
        
        public SimpleBookList.Models.AuthorViewModel EditAuthor(SimpleBookList.Models.AuthorViewModel inputAuthor) {
            return base.Channel.EditAuthor(inputAuthor);
        }
        
        public System.Threading.Tasks.Task<SimpleBookList.Models.AuthorViewModel> EditAuthorAsync(SimpleBookList.Models.AuthorViewModel inputAuthor) {
            return base.Channel.EditAuthorAsync(inputAuthor);
        }
    }
}