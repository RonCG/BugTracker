import { AuthService } from './../../services/auth.service';
import { Component } from '@angular/core';

@Component({ templateUrl: './main.component.html' })
export class MainComponent {

    constructor( 
        private authService: AuthService
    ){}

    logout(){
        this.authService.logout();
    }
}