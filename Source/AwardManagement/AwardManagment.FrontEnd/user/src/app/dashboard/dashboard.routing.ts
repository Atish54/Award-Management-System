import { Routes } from '@angular/router';

import { JuryDashboardComponent } from './jurydashboard/jurydashboard.component';
import { ApplicantDashboardComponent } from './applicantdashboard/applicantdashboard.component';
import { AssesorDashboardComponent } from './assesordashboard/assesordashboard.component';
import { ChairmanDashboardComponent } from './chairmandashboard/chairmandashboard.component';
import { RatingComponent } from './rating/rating.component';

export const DashboardRoutes: Routes = [
    {
      path: '',
      children: [ {
        path: 'jurydashboard',
        component: JuryDashboardComponent
    }]
},
{
    path: '',
    children: [ {
      path: 'Chairmandashboard',
      component: ChairmanDashboardComponent
  }]
},
{
    path : '',
    children: [{
        path : 'applicantdashboard',
component : ApplicantDashboardComponent
    }]
},
{
    path : '',
    children: [{
        path : 'assesordashboard',
        component : AssesorDashboardComponent
    }]
},{
    path : '',
    children: [{
        path : 'updateaplication',
        component : RatingComponent
    }]
}
];
