// -----------------------------------------------------------------------
// <copyright file="XlsxExporter.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.UI.Utils
{
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using OfficeOpenXml;

    using Models;
    using BLL.Interfaces;

    /// <summary>
    /// Exporting Books list to xlsx file
    /// </summary>
    public static class XlsxExporter
    {
        /// <summary>
        /// Create new xlsx file with all Books
        /// </summary>
        /// <param name="fullPathFile">Path for file wuth file name</param>
        /// <param name="service">Book list service</param>
        /// <returns>New file bytes for download</returns>
        public static byte[] CreateFileForExport(string fullPathFile, IBookListService service)
        {
            FileInfo newFile = new FileInfo(fullPathFile);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(fullPathFile);
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

                List<BookViewModel> allBooks = service.GetAllBooks().ToList();

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

            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPathFile);

            return fileBytes;
        }
    }
}