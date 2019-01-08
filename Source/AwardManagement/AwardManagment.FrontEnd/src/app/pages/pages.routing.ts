import { Routes } from '@angular/router';

import { RegisterComponent } from './register/register.component';
import { PricingComponent } from './pricing/pricing.component';
import { LockComponent } from './lock/lock.component';
import { LoginComponent } from './login/login.component';
import { AssesorLoginComponent } from './assesor-login/assesor-login.component';
import { JueryLoginComponent } from './juery-login/juery-login.component';

export const PagesRoutes: Routes = [

    {
        path: '',
        children: [ {
            path: 'login',
            component: LoginComponent
        },{
            path: 'lock',
            component: LockComponent
        },{
            path: 'register',
            component: RegisterComponent
        },{
            path: 'pricing',
            component: PricingComponent
        },{
            path: 'assesor-login',
            component: AssesorLoginComponent
        },{
            path: 'juery-login',
            component: JueryLoginComponent
        }]
    }
];
