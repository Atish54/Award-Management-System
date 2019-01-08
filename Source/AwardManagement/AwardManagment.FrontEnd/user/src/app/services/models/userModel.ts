import { Application } from './applicationModel';
import { UserRating } from './userRatingModel';
import { UserRole } from './userRoleModel';
import { Notifications } from './notificationsModel';

export class User {
    UserId: any;
    Name: string;
    Email: string;
    Password: string;
    Mobile: number;
    Gender: boolean;
    DOB: Date;
    DOJ: Date;
    Designation: string;
    Image: string;
    IsActive: boolean;
    IsDisable: boolean;
    Applications: Application[];
    Notifications: Notifications[];
    UserRating: UserRating;
    UserRoles: UserRole[];
}
