import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from "@angular/core";

@Component({
    selector: 'app-users-roles-list',
    templateUrl: './users-roles-list.component.html'
})
export class UsersAndRolesListComponent implements OnInit {

    constructor(
        private router: Router
    )
    {}
    ngOnInit(): void {
    }

    newUser(){
        this.router.navigate([`${this.router.url}/user/`, -1]);
    }
}