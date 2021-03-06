﻿// -----------------------------------------------------------------------
// <copyright file="MappingProfile.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.BLL.Infrastructure
{
    using AutoMapper;

    using DAL;
    using Models;

    /// <summary>
    /// Automapper Profile Configuration
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Creating maps for Automapper
        /// </summary>
        protected override void Configure()
        {
            this.CreateMap<Author, AuthorViewModel>()
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.BooksNumber, opt => opt.MapFrom(x => x.Books.Count));

            this.CreateMap<Book, BookViewModel>();

            this.CreateMap<AuthorViewModel, Author>();

            this.CreateMap<BookViewModel, Book>();
        }
    }
}
