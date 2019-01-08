import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SidebarComponent } from './sidebar.component';
import { SidebarCommonComponent } from './sidebar-common/sidebar-common.component';


@NgModule({
    imports: [ RouterModule, CommonModule ],
    declarations: [ SidebarComponent, SidebarCommonComponent ],
    exports: [ SidebarComponent, SidebarCommonComponent ]
})

export class SidebarModule {}
