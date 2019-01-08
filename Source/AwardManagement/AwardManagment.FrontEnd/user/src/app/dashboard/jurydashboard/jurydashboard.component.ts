import { Component, OnInit, AfterViewInit } from '@angular/core';
import { TableData } from '../../md/md-table/md-table.component';

import * as Chartist from 'chartist';
import { Router } from '@angular/router';
import { UtilityService } from '../../services/utility.services';
import { ApiService } from '../../services/apiservices';
import { Application } from '../../services/models/applicationModel';
import { Rating } from '../../services/models/ratingModel';

declare var $: any;
declare var swal: any;
@Component({
    selector: 'app-jurydashboard',
    templateUrl: './jurydashboard.component.html',
    styleUrls: ['./jurydashboard.component.css']
})
export class JuryDashboardComponent implements OnInit, AfterViewInit {
    // constructor(private navbarTitleService: NavbarTitleService, private notificationService: NotificationService) { }
    public tableData: TableData;
   
    constructor(private utility: UtilityService, private _router: Router, public apiservice: ApiService) {  }
    startAnimationForLineChart(chart) {
        let seq, delays, durations;
        seq = 0;
        delays = 80;
        durations = 500;
        chart.on('draw', function (data) {

            if (data.type === 'line' || data.type === 'area') {
                data.element.animate({
                    d: {
                        begin: 600,
                        dur: 700,
                        from: data.path.clone().scale(1, 0).translate(0, data.chartRect.height()).stringify(),
                        to: data.path.clone().stringify(),
                        easing: Chartist.Svg.Easing.easeOutQuint
                    }
                });
            } else if (data.type === 'point') {
                seq++;
                data.element.animate({
                    opacity: {
                        begin: seq * delays,
                        dur: durations,
                        from: 0,
                        to: 1,
                        easing: 'ease'
                    }
                });
            }
        });

        seq = 0;
    }
    public viewAppDetails(id) {
        this.apiservice.getApplication(id);
        setTimeout(() => {
            let s = '<div class="text-left"><label> Applicant Name: <strong>' + this.apiservice.application.User.Name +
                '</strong> </label><br>' +
                '<label> Applied on: <strong>' + this.apiservice.application.AppliedDate + '</strong> </label>';
            s += '<table>';
            s += '<tr ><td colspan=2><label><strong><h5>Award Application Detail</strong> </h5></label></td></tr>';
            for (let i = 0; i < this.apiservice.application.ApplicationDetails.length; i++) {

                s = s + '<tr><td><label> <strong>Q : </strong></label></td><td class="text-left"><label><strong>' +
                    this.apiservice.application.ApplicationDetails[i].Question.Question1 +
                    ' ?</strong></label> </td></tr><tr><td></td><td><label>' +
                    this.apiservice.application.ApplicationDetails[i].Answer + '</label></td></tr><br>';
            }
            s += '</table>';

            s += '<table>';
            for (let i = 0; i < this.apiservice.application.UserRatings.length; i++) {
                s = s + '<tr><td><label><strong>Ratings By:</strong>' +
                    this.apiservice.application.UserRatings[i].User.Name + '</label></td><td class="text-left">' +
                    '<td> <label>Ratings:</label> ';
                for (let j = 0; j < this.apiservice.application.UserRatings[i].Rating; j++) {
                    s += '<i class="material-icons">stars</i> </label>';
                }
                s += '<br><label> <h6>Reason </h6>:' +
                    this.apiservice.application.UserRatings[i].Reason + '</label></td></tr><br>';
            }
            s += '</table>';
            s += '</div>';
            switch (this.apiservice.application.Stage) {
                case 1:
                    s = s + '<tr><td> Current Stage: </td> <td> Applicant</td> </tr>';
                    break;
                case 2:
                    s = s + '<tr><td> Current Stage: </td> <td> Assesor</td> </tr>';
                    break;
                case 3:
                    s = s + '<tr><td> Current Stage: </td> <td> Jury</td> </tr>';
                    break;
                case 4:
                    s = s + '<tr><td> Current Stage: </td> <td> Chairman </td> </tr>';
                    break;
                case 5:
                    s = s + '<tr><td> Current Stage: </td> <td> Won </td> </tr>';
                    break;
                default:
                    break;
            }
            console.log(s);
            console.log(this.apiservice.application);
            swal({
                title: this.apiservice.application.Award.AwardName,
                buttonsStyling: false,
                confirmButtonClass: 'btn btn-success',
                html: s
            });
        }, 1000);

    }

    AcceptRejectApplication(id, flag: boolean) {
        // tslint:disable-next-line:no-unused-expression
        let temp: Application;
        this.apiservice.getApplication(id);
        setTimeout(() => {
            temp = this.apiservice.application;
            temp.isRejected = flag;
            if (!flag) {
                temp.Stage += 1;
            }
            if (flag) {
                swal({
                    title: 'Are you sure?',
                    text: 'This Application Get Rejected!',
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonText: 'Yes, Reject it!',
                    cancelButtonText: 'No, keep it',
                    confirmButtonClass: 'btn btn-success',
                    cancelButtonClass: 'btn btn-danger',
                    buttonsStyling: false
                }).then(() => {
                    // console.log("its here");

                    this.apiservice.putapplication(temp, null).subscribe(data => {
                        const title = 'Rejected';
                        const text = 'Your Application Rejected';
                        const type = 'error';
                        swal({
                            title: title,
                            text: text,
                            type: type,
                            confirmButtonClass: 'btn btn-success',
                            buttonsStyling: false
                        });
                    });
                }, function (dismiss) {
                    // dismiss can be 'overlay', 'cancel', 'close', 'esc', 'timer'
                    if (dismiss === 'cancel') {
                        swal({
                            title: 'Cancelled',
                            text: 'Your imaginary file is safe :)',
                            type: 'error',
                            confirmButtonClass: 'btn btn-info',
                            buttonsStyling: false
                        });
                    }
                });
            } else {
                swal({
                    title: 'Reason For Updgrade Application',
                    html: '<div class="form-group">' +
                        '<input id="' + temp.AppId + '" type="text" class="form-control" />' +
                        '</div>',
                    showCancelButton: true,
                    confirmButtonClass: 'btn btn-success',
                    cancelButtonClass: 'btn btn-danger',
                    buttonsStyling: false
                }).then(() => {
                    var temp1=new Rating();
                    temp1.rating=2;
                    temp1.reason=$('#' + temp.AppId).val();
                    this.apiservice.putapplication(temp, temp1).subscribe(data => {

                        swal({
                            title: 'Application Upgraded',
                            type: 'success',
                            html: 'Thank you for upgrading it',
                            confirmButtonClass: 'btn btn-success',
                            buttonsStyling: false
                        });
                    });
                }).catch(swal.noop);

            }
        }, 1000);
    }
    startAnimationForBarChart(chart) {
        let seq2, delays2, durations2;
        seq2 = 0;
        delays2 = 80;
        durations2 = 500;
        chart.on('draw', function (data) {
            if (data.type === 'bar') {
                seq2++;
                data.element.animate({
                    opacity: {
                        begin: seq2 * delays2,
                        dur: durations2,
                        from: 0,
                        to: 1,
                        easing: 'ease'
                    }
                });
            }
        });

        seq2 = 0;
    }
    // constructor(private navbarTitleService: NavbarTitleService) { }

    public ngOnInit() {
        this.utility.isLogged().then((result: boolean) => {
            if (!result) {
                this._router.navigate(['/pages/juery-login']);
            }
        });
        this.apiservice.getApplicationStagelist(3);
    }
    ngAfterViewInit() {
        const breakCards = true;
        if (breakCards === true) {
            // We break the cards headers if there is too much stress on them :-)
            $('[data-header-animation="true"]').each(function () {
                const $fix_button = $(this);
                const $card = $(this).parent('.card');
                $card.find('.fix-broken-card').click(function () {
                    console.log(this);
                    const $header = $(this).parent().parent().siblings('.card-header, .card-image');
                    $header.removeClass('hinge').addClass('fadeInDown');

                    $card.attr('data-count', 0);

                    setTimeout(function () {
                        $header.removeClass('fadeInDown animate');
                    }, 480);
                });

                $card.mouseenter(function () {
                    const $this = $(this);
                    const hover_count = parseInt($this.attr('data-count'), 10) + 1 || 0;
                    $this.attr('data-count', hover_count);
                    if (hover_count >= 20) {
                        $(this).children('.card-header, .card-image').addClass('hinge animated');
                    }
                });
            });
        }
        //  Activate the tooltips
        $('[rel="tooltip"]').tooltip();
    }
}
