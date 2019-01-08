import { Component, OnInit } from '@angular/core';
import { login } from '../login/model';
import { Router } from '@angular/router';
import { UtilityService } from '../../services/utility.services';
import {UserService} from '../../services/user.services';
import { HttpErrorResponse } from '@angular/common/http';
import { ApiService } from '../../services/apiservices';
declare var $: any;
declare var swal: any;
@Component({
  selector: 'app-juery-login',
  templateUrl: './juery-login.component.html'
})
export class JueryLoginComponent implements OnInit {

  test: Date = new Date();

    checkFullPageBackgroundImage() {
        const $page = $('.full-page');
        const image_src = $page.data('image');

        if (image_src !== undefined) {

            const image_container = '<div class="full-page-background" style="background-image: url(' + image_src + ') "/>';
            $page.append(image_container);
        }
    };
    ngOnInit() {

        this.checkFullPageBackgroundImage();
        setTimeout(function(){
            // after 1000 ms we add the class animated to the login/register card
            $('.card').removeClass('card-hidden');
        }, 700);
        //check login is there or not
        this.utility.isLogged().then((result: boolean) => {
            if (result) {
                this._router.navigate(['/jurydashboard']);
            }
        });
    }
    // tslint:disable-next-line:member-ordering
    // model = new login();
    constructor(private _router: Router, private utility: UtilityService, private user: UserService, private apiservices: ApiService) { }
    // data:any;
    formsubmit(Email, password) {
        this.user.userAuthentication(Email, password).subscribe((data: any) => {
            //  sessionStorage.setItem('User',data.UserId);
            // sessionStorage.setItem('User-name',data.Name);
            // sessionStorage.setItem('User-email',data.Email);
            // sessionStorage.setItem('flag',"1");

            // this._router.navigate(['/jurydashboard']);
            // debugger
            this.apiservices.getuserrole(data.UserId);
            setTimeout(() => {
                if (this.apiservices.userrole.Role1 === 'Jury') {
                    sessionStorage.setItem('User', data.UserId);
                    sessionStorage.setItem('User-name', data.Name);
                    sessionStorage.setItem('User-email', data.Email);
                    sessionStorage.setItem('flag', 'Jury');
                    this._router.navigate(['/jurydashboard']);
                    // console.log("yes");
                }else {
                    swal({
                        type: 'error',
                        text: 'Contact your system Administrator',
                        timer: 2000,
                        showConfirmButton: false
                      });
                }
            }, 3000);

          });
    }
}
