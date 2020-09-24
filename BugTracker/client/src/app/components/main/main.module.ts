import { CommonModule } from '@angular/common';
import { UsersAndRolesComponent } from './../users-roles/users-roles.component';
import { UserDetailComponent } from './../users-roles/user-detail/user-detail.component';
import { MenuModule } from 'primeng/menu';
import { MainRoutingModule } from './main-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { MainComponent } from './main.component';
import { UsersAndRolesListComponent } from '../users-roles/users-roles-list/users-roles-list.component';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';

@NgModule({
    declarations: [
        MainComponent,
        UsersAndRolesListComponent,
        UsersAndRolesComponent,
        UserDetailComponent
    ],
    imports: [  
        ReactiveFormsModule,
        MainRoutingModule,
        MenuModule,
        InputTextModule,
        ButtonModule,
        CommonModule,
    ],
    exports: [MainComponent],
    providers: []
})
export class MainModule {}