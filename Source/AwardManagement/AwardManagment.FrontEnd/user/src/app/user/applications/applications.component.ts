import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Application } from '../../services/models/applicationModel';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { ApiService } from '../../services/apiservices';
import { timeout } from 'q';
import { Observable } from 'rxjs/Observable';
import { User } from '../../services/models/userModel';
declare var $: any;

declare interface DataTable {
  headerRow: string[];
  footerRow: string[];
  dataRows: string[][];
}
@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html'
})
export class ApplicationsComponent implements OnInit {
  temp: any[];
  // // constructor(private navbarTitleService: NavbarTitleService, private notificationService: NotificationService) { }
  public dataTable: DataTable;
  public appdata: Application[];
  public userList: User[];
  // public apps1: any[];
  // tmp: any;
  constructor(private _applicationService: ApiService) { }


  ngOnInit() {
    // tslint:disable-next-line:no-debugger
    this._applicationService.getApplicationlist().then(x => {
      this.appdata = x;
      console.log(this.appdata);
      this.appdata = this.appdata.filter(y => y.User.UserId == sessionStorage.getItem('User') && y.Stage === 3 && y.isRejected === false);
      console.log(this.appdata);
    });
   
    setTimeout(function () {
      $('#datatables1').DataTable({
        'pagingType': 'full_numbers',
        'lengthMenu': [[10, 25, 50, -1], [10, 25, 50, 'All']],
        responsive: true,
        language: {
          search: '_INPUT_',
          searchPlaceholder: 'Search records',
        }

      });
      const table = $('#datatables1').DataTable();

      // Edit record
      table.on('click', '.edit', function () {
        const $tr = $(this).closest('tr');

        const data = table.row($tr).data();
        alert('You press on Row: ' + data[0] + ' ' + data[1] + ' ' + data[2] + '\'s row.');
      });

      // Delete a record
      table.on('click', '.remove', function (e) {
        const $tr = $(this).closest('tr');
        table.row($tr).remove().draw();
        e.preventDefault();
      });

      // Like record
      table.on('click', '.like', function () {
        alert('You clicked on Like button');
      });

      //  Activate the tooltips
      $('[rel="tooltip"]').tooltip();
    }
      , 2000);

    // console.log(this.appdata);
    // this.dataTable = {
    //     headerRow: [ 'Award Name', 'Category', 'Sub Category', 'Applied Date', 'Status', 'Actions' ],
    //     footerRow: [ 'Award Name', 'Category', 'Sub Category', 'Applied Date', 'Status', 'Actions' ],
    //     dataRows: [ ['Award Name', 'Category', 'Sub Category', 'Applied Date', 'Status', 'Actions'] ]
    //  };

    // console.log(this.appdata);
  }


}

