import { ApplicationDetails } from './applicationDetailsModel';
import { UserRating } from './userRatingModel';
import { Award } from './AwardModel';
import { User } from './userModel';

export class Application {
    //  public BOApplication()
    //     {
    //         this.ApplicationDetails = new HashSet<BOApplicationDetail>();
    //         this.UserRatings = new HashSet<BOUserRating>();
    //     }

        AppId: any;
        AppliedDate: Date;
        Stage: number;
        AwdId: any;
        UserId: any;
        ApplicationDetails: ApplicationDetails[];
        UserRatings: UserRating[];
        isRejected: boolean;
        Award: Award;
        User: User;
}
