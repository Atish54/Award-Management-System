import {Award} from './AwardModel';
import {User} from './userModel';
import {Role} from './roleModel';


export class UserRole {
    UserId: any;
    RoleId: any;
    IsDisable: boolean;
    AwardId: any;
    Award: Award;
    Role: Role;
    User: User;
}
