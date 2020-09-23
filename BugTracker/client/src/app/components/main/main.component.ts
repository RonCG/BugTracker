import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({ templateUrl: './main.component.html' })
export class MainComponent implements OnInit {

    items: MenuItem[];

    constructor( 
        private authService: AuthService
    ){}

    ngOnInit() {
        this.items = [{
            label: 'Bug Tracker',    
            items: [
               {separator: true},
               {label: 'Home', icon: 'pi pi-fw pi-home',  routerLink: 'home'},
               {label: 'Projects', icon: 'pi pi-fw pi-th-large'},
               {label: 'Tasks', icon: 'pi pi-fw pi-list'},
               {label: 'Bugs', icon: 'pi pi-fw pi-times-circle'},
               {label: 'Users & Roles', icon: 'pi pi-fw pi-users', routerLink: 'users-roles'},
               {separator: true},
               {label: 'Logout', icon: 'pi pi-fw pi-sign-out',  styleClass: 'logout', command: () => this.logout()},
            ]
        }];
    }

    logout(){
        this.authService.logout();
    }
}