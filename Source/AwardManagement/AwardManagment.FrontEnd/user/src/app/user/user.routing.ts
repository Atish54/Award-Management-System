import { Routes } from '@angular/router';

import { ApplicationsComponent } from './applications/applications.component';
import { ApplyComponent } from './apply/apply.component';
import { IconsComponent } from './icons/icons.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { PanelsComponent } from './panels/panels.component';
import { SweetAlertComponent } from './sweetalert/sweetalert.component';
import { TypographyComponent } from './typography/typography.component';
import { UserHistoryComponent } from './userhistory/userhistory.component';
import { AwardComponent } from './award/award.component';
import {ApplicantProfileComponent} from './applicantprofile/applicantprofile.component';
 import {LoginComponent} from '../pages/login/login.component';

export const UserRoutes: Routes = [
    {
        path: '',
        children: [
            {
                path: 'applications',
                component: ApplicationsComponent
            }
        ]
    },
    {
        path: '',
        children: [
            {
                path: 'apply',
                component: ApplyComponent
            }
        ]
    },
    {
        path: '',
        children: [
            {
                path: 'award/:id',
                component: AwardComponent
            }
        ]
    },
    {
        path: '',
        children: [
            {
                path: 'userhistory',
                component: UserHistoryComponent
            }
        ]
    },
    {
        path: '',
        children: [
            {
                path: 'applicantprofile',
                component: ApplicantProfileComponent
            }
        ]
    },
    {
        path: '',
        children: [
            {
                path: 'icons',
                component: IconsComponent
            }
        ]
    },
    {
        path: '',
        children: [
            {
                path: 'notifications',
                component: NotificationsComponent
            }
        ]
    },
    {
        path: '',
        children: [
            {
                path: 'panels',
                component: PanelsComponent
            }
        ]
    },
    {
        path: '',
        children: [
            {
                path: 'sweet-alert',
                component: SweetAlertComponent
            }
        ]
    },
    {
        path: '',
        children: [
            {
                path: 'typography',
                component: TypographyComponent
            }
        ]
    }
];
