import {User} from './userModel';
import {Application} from './applicationModel';

export class UserRating {
    AppId: any;
    UserId: any;
    Rating: number;
    Reason: string;
    Application: Application;
    User: User;
}
