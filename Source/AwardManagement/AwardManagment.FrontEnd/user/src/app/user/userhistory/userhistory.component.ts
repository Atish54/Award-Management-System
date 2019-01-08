import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/apiservices';
import { Application } from '../../services/models/applicationModel';

declare var $: any;

declare interface DataTable {
    headerRow: string[];
    footerRow: string[];
    dataRows: string[][];
}
@Component({
    selector: 'app-userhistory',
    templateUrl: './userhistory.component.html'
})
export class UserHistoryComponent implements OnInit {
    public dataTable: DataTable;
    public application: Application[];
    // constructor(private navbarTitleService: NavbarTitleService, private notificationService: NotificationService) { }
    constructor(private apiService: ApiService) { }



    ngOnInit() {
        this.apiService.getApplicationStagelist(3).then((data) => {
            this.application = data;
            this.application = this.application.filter(x => x.Stage === 3 && new Date(x.AppliedDate.toString()) < new Date()
            && x.isRejected === true );
            console.log(this.application);
        });
        setTimeout(() => {
            $('#datatables1').DataTable({
                'pagingType': 'full_numbers',
                'lengthMenu': [[5, 10, 25, 50, -1], [5, 10, 25, 50, 'All']],
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
        }, 3000);
    }
}

