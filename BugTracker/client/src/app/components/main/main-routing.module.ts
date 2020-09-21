import { UserDetailComponent } from './../users-roles/user-detail/user-detail.component';
import { UsersAndRolesListComponent } from './../users-roles/users-roles-list/users-roles-list.component';
import { UsersAndRolesComponent } from './../users-roles/users-roles.component';
import { HomeComponent } from './../home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main.component';

/** Main Route Module */
const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    {
        path: '',
        component: MainComponent,
        children: [
            {
                path: 'home',
                component: HomeComponent
            },
            {
                path: 'users-roles',
                component: UsersAndRolesComponent,
                children: [
                    {
                        path: '',
                        component: UsersAndRolesListComponent
                    },
                    {
                        path: 'user/:id',
                        component: UserDetailComponent
                    }

                ]
            }
        ]
        
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MainRoutingModule {}
