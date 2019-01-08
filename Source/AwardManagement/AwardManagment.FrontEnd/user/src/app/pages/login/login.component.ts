import { Component, OnInit } from '@angular/core';
import { login } from './model';
import { Routes, Router } from '@angular/router';
declare var $: any;


@Component({
    moduleId: module.id,
    // tslint:disable-next-line:component-selector
    selector: ' login-cmp ',
    templateUrl: './login.component.html'
})


export class LoginComponent implements OnInit {
    test: Date = new Date();

    checkFullPageBackgroundImage() {
        let $page = $('.full-page');
        let image_src = $page.data('image');

        if (image_src !== undefined) {
            let image_container = '<div class="full-page-background" style="background-image: url(' + image_src + ') "/>';
            $page.append(image_container);
        }
    };
    ngOnInit() {
        this.checkFullPageBackgroundImage();

        setTimeout(function () {
            // after 1000 ms we add the class animated to the login/register card
            $('.card').removeClass('card-hidden');
        }, 700);
    }
    constructor(private _router: Router) { }
    // tslint:disable-next-line:member-ordering
    model = new login();
    // data:any;
    formsubmit() {
        console.log(this.model.Email);
        if (this.model.Email === 'abc@gmail.com' && this.model.password === 'admin') {
            this._router.navigate(['/components/buttons']);
        } else {
            console.log('erooorrr..');
        }
    }

}
