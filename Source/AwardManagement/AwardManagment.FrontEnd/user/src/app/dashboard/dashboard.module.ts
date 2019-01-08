import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MdTableComponent } from '../md/md-table/md-table.component';

import { JuryDashboardComponent } from './jurydashboard/jurydashboard.component';
import { DashboardRoutes } from './dashboard.routing';
import { ApplicantDashboardComponent } from './applicantdashboard/applicantdashboard.component';

import { AssesorDashboardComponent } from './assesordashboard/assesordashboard.component';
import { ChairmanDashboardComponent } from './chairmandashboard/chairmandashboard.component';
import { RatingComponent } from './rating/rating.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
//import { UpdateapplicationComponent } from './updateapplication/updateapplication.component';
@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(DashboardRoutes),
        FormsModule,
        NgbModule
    ],
    declarations: [
        JuryDashboardComponent,
        ChairmanDashboardComponent ,
        ApplicantDashboardComponent,
        AssesorDashboardComponent,
        MdTableComponent,
        RatingComponent,
       // UpdateapplicationComponent 
    ]
})

export class DashboardModule {}
