import { RoleModel } from './RoleModel';

export class UserModel {
    UserID: number;
    FirstName: string;
    LastName: string;
    UserName: string;
    Email: string;
    Roles: RoleModel[];
}