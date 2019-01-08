import { QuestionAnswer } from './QuestionAnswerModel';

export class ApplicationQuestions {
    AppliedDate: Date;
    Stage: number;
    AwdId: any;
    UserId: any;
    isRejected: boolean;
    QuestionAnswer: QuestionAnswer[];
}
