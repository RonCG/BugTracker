import { LookupTypeConsts } from './../../../constants/LookupTypeConst';
import { LookupService } from './../../../services/lookup.service';
import { UserService } from './../../../services/user.service';
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { UserModel } from 'src/app/models/UserModel';
import { SelectItem } from 'primeng/api';
import { RoleModel } from 'src/app/models/RoleModel';

@Component({
    selector: 'app-user-detail',
    templateUrl: './user-detail.component.html'
})
export class UserDetailComponent implements OnInit {

    userID: number;
    isNewUser: boolean;
    userDetail: UserModel;
    rolesLookup: SelectItem[];
    userForm: FormGroup;

    constructor(
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private lookupService: LookupService,
        private userService: UserService,
    ){}

    ngOnInit(){
        this.userID = Number(this.route.snapshot.params['id']);
        this.isNewUser = this.userID == -1;
        if(this.isNewUser){
            this.initForm();
            return;
        } 
        
        this.initUserData();       
    }

    initUserData(){
        this.userService.getUserDetail(this.userID).subscribe(
            user => {
                this.userDetail = user;
                this.initForm();
            },
            error => {
                 //show error message with toaster... 
            }
        );
    }
    
    initForm(){
        this.lookupService.getLookUp(LookupTypeConsts.Roles, true).subscribe(
            rolesLookup => {
                this.rolesLookup = rolesLookup;
                this.userForm = this.generateUserForm();
            }, 
            error => {
               //show error message with toaster... 
            });
    }

    generateUserForm(){
        return this.fb.group({
            FirstName: new FormControl(this.isNewUser ? '' : this.userDetail.FirstName),
            LastName: new FormControl(this.isNewUser ? '' : this.userDetail.LastName),
            UserNanme: new FormControl(this.isNewUser ? '' : this.userDetail.LastName),
            Email: new FormControl(this.isNewUser ? '' : this.userDetail.Email)
        });
    }

    get UserFormControls() { return this.userForm.controls; }

    setUserData(): UserModel{
        const userRoles = this.setUserRoles();
        return {
            UserID: 0,
            FirstName: this.UserFormControls.FirstName.value,
            LastName: this.UserFormControls.LastName.value,
            UserName: this.UserFormControls.UserNanme.value,
            Email: this.UserFormControls.Email.value,
            Roles: userRoles
        }
    }

    setUserRoles() : RoleModel[]{
        return [];
    }

    saveUser(){
        if(this.isNewUser){
            this.createNewUser();
            return;
        }

        this.updateUser();  
    }

    createNewUser(){

    }

    updateUser(){

    }

}