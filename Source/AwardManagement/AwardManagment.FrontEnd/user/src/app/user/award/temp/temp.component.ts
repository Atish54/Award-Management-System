import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    moduleId: module.id,
    // tslint:disable-next-line:component-selector
    selector: 'temp',
    templateUrl: 'temp.component.html',

})
export class TempComponent {

    // tslint:disable-next-line:no-input-rename
    @Input('group')
    public queForm: FormGroup;

     @Input('QuId')
     QuId: any;

     @Input('Que')
     Que: any;
}
