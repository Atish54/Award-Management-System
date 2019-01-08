import {Category} from './categoryModel'
import { Award } from './AwardModel';

export class SubCategory {
    SubCateId: any;
    SubCategory1: string;
    CateId: any;
    IsDisable: boolean;
    LongDescription: string;
    ShortDescription: string;
    Awards: Award[];
    Category: Category;
}
