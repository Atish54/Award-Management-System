import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { PasswordValidation } from './password-validator.component';


declare interface User {
    text?: string; // required, must be 5-8 characters
    email?: string; // required, must be valid email format
    password?: string; // required, value must be equal to confirm password.
    confirmPassword?: string; // required, value must be equal to password.
    number?: number; // required, value must be equal to password.
    url?: string;
    idSource?: string;
    idDestination?: string;
}

@Component({
    moduleId: module.id,
    // tslint:disable-next-line:component-selector
    selector: 'validationforms-cmp',
    templateUrl: 'validationforms.component.html'
})

export class ValidationFormsComponent{
    // rangeValidation : FormGroup;
    //
    // // We are passing an instance of the FormBuilder to our constructor
    // constructor(fb: FormBuilder){
    //   // Here we are using the FormBuilder to build out our form.
    //   this.rangeValidation = fb.group({
    // tslint:disable-next-line:max-line-length
    //     // To add a validator, we must first convert the string value into an array. The first item in the array is the default value if any, then the next item in the array is the validator. Here we are adding a required validator meaning that the firstName attribute must have a value in it.
    // tslint:disable-next-line:max-line-length
    //     // To add a validator, we must first convert the string value into an array. The first item in the array is the default value if any, then the next item in the array is the validator. Here we are adding a required validator meaning that the firstName attribute must have a value in it.
    //   'firstName' : [null, Validators.required],
    // tslint:disable-next-line:max-line-length
    //   // We can use more than one validator per field. If we want to use more than one validator we have to wrap our array of validators with a Validators.compose function. Here we are using a required, minimum length and maximum length validator.
    //   'lastName': [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(10)])],
    //   'gender' : [null, Validators.required],
    //
    //   })
    // }
    public user: User;
    public typeValidation: User;

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit() {
    this.user = {
      email: '',
      password: '',
      confirmPassword: ''
    }
    this.typeValidation = {
        text: '',
        email: '',
        idSource: '',
        idDestination: '',
        url: ''
    }
  }

  save(model: User, isValid: boolean) {
    // call API to save customer
    console.log(model, isValid);
  }
    onSubmit(value: any):void{
        console.log(value);
    }
}
