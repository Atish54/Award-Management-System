import { ApplicationDetails } from './applicationDetailsModel';
import { Award } from './AwardModel';

export class Question {
// public BOQuestion()
//         {
//             this.ApplicationDetails = new HashSet<BOApplicationDetail>();
//             this.Awards = new HashSet<BOAward>();
//         }
        QueId: any;
        Question1: string;
        IsDisable: boolean;
        ApplicationDetails: ApplicationDetails[];
        Awards: Award[];
}
