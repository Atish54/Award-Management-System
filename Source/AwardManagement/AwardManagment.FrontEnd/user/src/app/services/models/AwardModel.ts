import { Application } from './applicationModel';
import { SubCategory } from './subCategoryModel';
import { UserRole } from './userRoleModel';
import { Question } from './questionModel';

export class Award {
        AwdId: any;
        SubCateId: any;
        AwardName: string;
        ShortDescription: string;
        LongDescription: any;
        StartDate: Date;
        EndDate: Date;
        DateCreated: Date;
        IsDisable: boolean;
        Applications: Application[];
        SubCategory: SubCategory;
        UserRoles: UserRole[];
        Questions: Question[];
}
