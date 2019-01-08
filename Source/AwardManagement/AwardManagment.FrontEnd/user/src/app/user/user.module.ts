import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ApplicationsComponent } from './applications/applications.component';
import { UserRoutes } from './user.routing';
import { ApplyComponent } from './apply/apply.component';
import { IconsComponent } from './icons/icons.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { PanelsComponent } from './panels/panels.component';
import { SweetAlertComponent } from './sweetalert/sweetalert.component';
import { TypographyComponent } from './typography/typography.component';
import {UserHistoryComponent} from './userhistory/userhistory.component';
import { AwardComponent } from './award/award.component';
import {ApplicantProfileComponent} from './applicantprofile/applicantprofile.component';
import { TempComponent } from './award/temp/temp.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(UserRoutes),
    FormsModule, ReactiveFormsModule
  ],
  declarations: [
      ApplicationsComponent,
      ApplyComponent,
      IconsComponent,
      NotificationsComponent,
      PanelsComponent,
      SweetAlertComponent,
      TypographyComponent,
      UserHistoryComponent,
      ApplicantProfileComponent,
      AwardComponent,
      TempComponent
  ]
})

export class UsersModule {}
