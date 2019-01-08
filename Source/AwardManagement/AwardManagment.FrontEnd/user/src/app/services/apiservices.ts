import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Application } from './models/applicationModel';
import { Award } from './models/AwardModel';
import { Notifications } from './models/notificationsModel';
import { Category } from './models/categoryModel';
import { SubCategory } from './models/subCategoryModel';

import { Role } from './models/roleModel';
import { User } from './models/userModel';
import { Rating } from './models/ratingModel';
import { ApplicationRating } from './models/aaplicationRatingModel';

@Injectable()
export class ApiService {
  //  apps :any[];

  applist: Application[];
  applistwithStage: Application[];
  application: Application;
  award: Award;
  notifications: Notifications[];
  notificationcount: number;
  sCategories: SubCategory[];
  categories: Category[];
  awardlist: Award[];
  profile: User;
  userrole: Role;
  userList: User[];

  constructor(private http: Http) { }
  getAwardList(id) {
    const _this = this;
    return this.http.get('http://localhost:62192/api/AwardList/' + id)
      .map((data: Response) => {
        // tslint:disable-next-line:no-debugger
        return data.json() as Award[];
      })
      .toPromise().then(x => {
        _this.awardlist = x;
        return _this.awardlist;
      });
  }
  getApplicationStagelist(id: number) {
    const _this = this;
    return this.http.get('http://localhost:62192/api/ApplicationStage/' + id)
      .map((data: Response) => {
        return data.json() as Application[];
      }).toPromise().then(x => {
        _this.applistwithStage = x;
        _this.http.get('http://localhost:62192/api/User/' + sessionStorage.getItem('User'))
          .map((data: Response) => {
            return data.json() as User;
          }).toPromise().then(z => {
            _this.profile = z;
            // tslint:disable-next-line:no-shadowed-variable
            _this.applistwithStage = _this.applistwithStage.filter((z) =>
              z.Award.AwdId === _this.profile.UserRoles.find(b => b.UserId === sessionStorage.getItem('User')).AwardId);
          });
        console.log(_this.applistwithStage);
        return _this.applistwithStage;
      });
  }
  getApplicationlist() {
    const _this = this;
    return this.http.get('http://localhost:62192/api/Application/')
      .map((data: Response) => {
        // tslint:disable-next-line:no-debugger
        return data.json() as Application[];
      }).toPromise();
  }

  getAwardlist() {
    const _this = this;
    return this.http.get('http://localhost:62192/api/Award')
      .map((data: Response) => {
        // tslint:disable-next-line:no-debugger
        return data.json() as Award[];
      }).toPromise().then(x => {
        _this.awardlist = x;
        // console.log(_this.applist);
        return _this.awardlist;
      });
  }
  getAward(id) {
    const _this = this;
    return this.http.get('http://localhost:62192/api/Award/' + id)
      .map((data: Response) => {
        // tslint:disable-next-line:no-debugger
        return data.json() as Award;
      }).toPromise().then(x => {
        _this.award = x;
        return _this.award;
      });
  }
  getNotifications() {
    const _this = this;
    return this.http.get('http://localhost:62192/api/Notification/' + sessionStorage.getItem('User'))
      .map((data: Response) => {
        // tslint:disable-next-line:no-debugger
        return data.json() as Notifications[];
      }).toPromise().then(x => {
        _this.notifications = x;
        _this.notificationcount = _this.notifications.length;
        return _this.notifications;
      });
  }
  getCategories() {
    const _this = this;
    return this.http.get('http://localhost:62192/api/Category/')
      .map((data: Response) => {
        // tslint:disable-next-line:no-debugger
        return data.json() as Category[];
      }).toPromise().then(x => {
        _this.categories = x;
        console.log(_this.categories);
        // _this.notificationcount = _this.notifications.length;
        return _this.categories;
      });
  }
  getSubCategories(id) {
    const _this = this;
    return this.http.get('http://localhost:62192/api/SubCategories/' + id)
      .map((data: Response) => {
        // tslint:disable-next-line:no-debugger
        return data.json() as SubCategory[];
      }).toPromise().then(x => {
        _this.sCategories = x;
        console.log(_this.sCategories);
        return _this.sCategories;
      });
  }
  // get profile of user
  getProfile(id) {
    // tslint:disable-next-line:no-debugger

    // tslint:disable-next-line:no-var-keyword
    var _this = this;
    return this.http.get('http://localhost:62192/api/User/' + id)
      .map((data: Response) => {
        return data.json() as User;
      }).toPromise().then(x => {
        _this.profile = x;
        return _this.profile;
      });
  }
  getuserrole(id) {
    // tslint:disable-next-line:prefer-const
    let _this = this;
    return this.http.get('http://localhost:62192/api/userrole/' + id)
      .map((data: Response) => {
        return data.json() as Role;
      }).toPromise().then(x => {
        _this.userrole = x;
        return _this.userrole;
      });
  }
  getWinners() {
    const _this = this;
    return this.http.get('http://localhost:62192/api/User/')
      .map((data: Response) => {
        return data.json() as User[];
      }).toPromise().then(x => {
        _this.userList = x;
        _this.userList.forEach(function (value) {
          value.Applications = value.Applications.filter(y => y.Stage === 5);
        });
        _this.userList.sort((a) => a.Applications.length);
        _this.userList.reverse();
        _this.userList = _this.userList.slice(0, 10);
        // console.log(_this.userList);
        return _this.userList;
      });
  }
  // get Application Detail
  getApplication(id) {
    const _this = this;
    return this.http.get('http://localhost:62192/api/Application/' + id)
      .map((data: Response) => {
        // tslint:disable-next-line:no-debugger
        return data.json() as Application;
      }).toPromise().then(x => {
        _this.application = x;
        return _this.application;
      });
  }

  // put or update of application by jury or assesor or chairman
  putapplication(app, s: Rating) {
    const headerOptions = new Headers({ 'Content-Type': 'application/json' });
    const requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    var body: ApplicationRating = new ApplicationRating();
    body.Application = app;
    s.UserId = sessionStorage.getItem('User');
    body.Rating = s;

    console.log(body)
    return this.http.put('http://localhost:62192/api/Application/', body,
      requestOptions).map(res => res.json());
  }
}
