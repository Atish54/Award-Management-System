import { Component, OnInit } from '@angular/core';
import{login} from './model';
import { Routes, Router } from '@angular/router';
declare var $:any;

@Component({
    moduleId:module.id,
    selector: 'login-cmp',
    templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit{
    test : Date = new Date();

    checkFullPageBackgroundImage(){
        var $page = $('.full-page');
        var image_src = $page.data('image');

        if(image_src !== undefined){
            var image_container = '<div class="full-page-background" style="background-image: url(' + image_src + ') "/>'
            $page.append(image_container);
        }
    };
    ngOnInit(){
        this.checkFullPageBackgroundImage();

        setTimeout(function(){
            // after 1000 ms we add the class animated to the login/register card
            $('.card').removeClass('card-hidden');
        }, 700)
    }
    constructor(private _router:Router){}
    model = new login();
    // data:any;
    formsubmit(){
        if(this.model.Email=="abc@gmail.com" && this.model.password=="admin" ){
            this._router.navigate(['/components/buttons']);
        }
        else{
            console.log("eroooooooorrrrrrrr...");
        }
    }
    
}
