import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { APP_BASE_HREF } from '@angular/common';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { SidebarModule } from './sidebar/sidebar.module';
import { FooterModule } from './shared/footer/footer.module';
import { NavbarModule} from './shared/navbar/navbar.module';
import { AdminLayoutComponent } from './layouts/admin/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth/auth-layout.component';
import { AppRoutes } from './app.routing';
import { UtilityService } from './services/utility.services';
import { ApiService } from './services/apiservices';
import {UserService} from './services/user.services';


@NgModule({
    imports:      [
        BrowserModule,
        FormsModule,
        RouterModule.forRoot(AppRoutes),
        HttpModule,
        SidebarModule,
        NavbarModule,
        FooterModule,
        HttpClientModule,
        ReactiveFormsModule
    ],
    declarations: [
        AppComponent,
        AdminLayoutComponent,
        AuthLayoutComponent

    ],
    providers: [UtilityService, ApiService, UserService],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }
