import { Component, OnInit } from '@angular/core';

import { AuthorService } from '../../services/authors.service';

import { AuthorViewModel } from '../../models/AuthorViewModel';

import { DTResult } from '../../../../app/core/models/DTResult';

//import * as $ from "jquery";

declare var $: any;

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css',
    //there is no css in  '../node_modules/datatables.net/' !!!
  ]
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
    return '<a href="authors/edit/' + data.Id + '">Edit</a>';
  };

  // Получаем и форматируем ссылку на удаление
  getDeleteLinkForItem(data, type, full, meta) {
    return '<a href="#' + data.Id + '" value="' + data.Id + '" onclick="deleteAuthorFunc(this, event)">Delete</a>';
  };

  getDetailsLinkForItem(data, type, full, meta) {
    return '<a href="/author/' + data.Id + '">Details</a>';
  };


  getDataSrc(json) {
    console.log(json);
    //this.Authors = json;
    return json.data;
  }


  updateGrid() {
    var dataTable = $('#AuthorsListTable').DataTable({
      "processing": true, // for show progress bar
      "serverSide": true, // for process server side
      //"filter": false, // this is for disable filter (search box)
      "orderMulti": false, // for disable multiple column at once
      //"paging": true, // ??
      //"deferRender": true, // ??
      //"stateSave": true, // restore table state on page reload.
      "ajax": {
        "url": "http://localhost:52211/API/Authors/",
        "type": "GET",
        //"datatype": "json"
        //"contentType": 'application/json; charset=utf-8',
        "data": function (data) {
          // https://datatables.net/reference/option/ajax
          // Add data to the request by manipulating the data object:
          return data;
        },
        "dataSrc": this.getDataSrc
        /*
        "dataSrc": function (json) {
          // Manipulate the data returned from the server
          console.log(json);
          this.Authors = json;
          return json.data;
        }
        */
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
  }


  ngOnInit() {

    this.Authors = new DTResult<AuthorViewModel>();

    this.updateGrid();

  }

  handleError(error: any) {
    //this.isError = true;

    console.log(error);

    return Promise.resolve();
  }

}
