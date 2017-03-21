import { Component, OnInit } from '@angular/core';

import { AuthorService } from '../../services/authors.service';

import { AuthorViewModel } from '../../models/AuthorViewModel';

import { DTResult } from '../../../../app/core/models/DTResult';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  constructor(private _authorService: AuthorService) {

  }

  Authors: DTResult<AuthorViewModel>;


  getNumberForItem(data, type, full, meta) {
    return new Number(data);
  };

  getStringForItem(data, type, full, meta) {
    return new String(data);
  };

  // Получаем и форматируем ссылку на редактирование
  getEditLinkForItem(data, type, full, meta) {
    return '<a href="#' + data.Id + '" value="' + data.Id + '" onclick="editFunc(this, event)">Edit</a>';
  };

  // Получаем и форматируем ссылку на удаление
  getDeleteLinkForItem(data, type, full, meta) {
    return '<a href="#' + data.Id + '" value="' + data.Id + '" onclick="deleteAuthorFunc(this, event)">Delete</a>';
  };

  getDetailsLinkForItem(data, type, full, meta) {
    return '<a href="#' + data.Id + '" value="' + data.Id + '" onclick="detailsFunc(this, event)">Details</a>';
  };

  setDatatable() {

    $('#AuthorsListTable').DataTable({

      "processing": true, // for show progress bar
      //"serverSide": true, // for process server side - NOT WORK!
      //"orderMulti": false, // for disable multiple column at once
      //"paging": true, // ??
      //"deferRender": true, // ??
      //"stateSave": true, // restore table state on page reload.
      data: this.Authors.data,
      columns: [
        { "data": 'Id', "visible": false, "searchable": false },
        { "data": 'FirstName' },
        { "data": 'LastName' },
        { "data": 'BooksNumber' },
        { "data": null, "render": this.getEditLinkForItem, "visible": true, "searchable": false },
        { "data": null, "render": this.getDeleteLinkForItem, "visible": true, "searchable": false },
        { "data": null, "render": this.getDetailsLinkForItem, "visible": true, "searchable": false }
      ]


    });


    /*
    $('#AuthorsListTable').DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        //"filter": false, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "paging": true, // ??
        "deferRender": true, // ??
        "stateSave": true, // restore table state on page reload.
        "ajax": {
            "url": "http://localhost:52211/API/Authors/",
            "type": "GET",
            //"datatype": "json"
            "contentType": 'application/json; charset=utf-8',
            //'data': function (data) { return data = JSON.stringify(data); }
        },
        "columns": [
            { "data": "Id", "render": this.getNumberForItem, "visible": false, "searchable": false },
            { "data": "FirstName", "render": this.getStringForItem, "visible": true, "searchable": true },
            { "data": "LastName", "render": this.getStringForItem, "visible": true, "searchable": true },
            { "data": "BooksNumber", "render": this.getNumberForItem, "visible": true, "searchable": true },
            { "data": null, "render": this.getEditLinkForItem, "visible": true, "searchable": false },
            { "data": null, "render": this.getDeleteLinkForItem, "visible": true, "searchable": false },
            { "data": null, "render": this.getDetailsLinkForItem, "visible": true, "searchable": false }
        ]

    });
    */

  }


  ngOnInit() {

    $('#test').html('<h1>WORKS!</h1>');



    this._authorService.getAuthors()
      .then(Authors => {
        this.Authors = Authors;

        console.log(this.Authors);

        this.setDatatable();

      })
      .catch((ex) => {
        this.handleError(ex);
      });

  }

  handleError(error: any) {
    //this.isError = true;

    console.log(error);

    return Promise.resolve();
  }

}
