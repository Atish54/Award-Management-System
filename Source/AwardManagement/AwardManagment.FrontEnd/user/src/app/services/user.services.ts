import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response, Http, RequestOptions, RequestMethod } from '@angular/http';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
// import { User } from './user.model';
import {User} from './models/userModel';
import {UserRole} from './models/userRoleModel';
import { Role } from './models/roleModel';
import { Application } from './models/applicationModel';
import { ApplicationQuestions } from './models/ApplicationQuestionsModel';
@Injectable()
export class UserService {
  userrole: Role;
  readonly rootUrl = 'http://localhost:62192/api';
  constructor(private http: HttpClient, private http1: Http) { }

//   registerUser(user: User) {
//     const body: User = {
//       UserName: user.UserName,
//       Password: user.Password,
//       Email: user.Email,
//       FirstName: user.FirstName,
//       LastName: user.LastName
//     }
//     var reqHeader = new HttpHeaders({'No-Auth':'True'});
//     return this.http.post(this.rootUrl + '/api/User/Register', body,{headers : reqHeader});
//   }

  userAuthentication(Email, password) {
    const data = 'Email=' + Email + '&password=' + password ;
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded', 'No-Auth': 'True'});
    return this.http.post(this.rootUrl + '/login', data, { headers: reqHeader });
  }
  PostApplication(id: ApplicationQuestions) {
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json', 'No-Auth': 'True'});
    return this.http.post('http://localhost:62192/api/Application/', id , { headers: reqHeader});
  }

//   getuserrole(id) {
//  debugger;
//     var _this = this;
//     return this.http1.get('http://localhost:62192/api/userrole/'+id )
//     .map((data: Response) => {
//       return data.json() as Role;
//     }).toPromise().then(x => {
//       _this.userrole = x;
//       return _this.userrole;
//     });
//   }
 // /825d9448-bdfa-4b79-9831-3ae85de0bafb

//   getUserClaims(){
//    return  this.http.get(this.rootUrl+'/api/GetUserClaims');
//   }

}
