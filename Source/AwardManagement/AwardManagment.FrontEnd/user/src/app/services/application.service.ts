import { Injectable } from '@angular/core';
import { Http, Response,  RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Application } from './models/applicationModel';
import { forEach } from '@angular/router/src/utils/collection';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ApplicationService {
    applicationList: Application[];
    apps: any[];
    constructor(private http: Http) { }
    getApplicationList() {
        this.http.get('http://localhost:62192/api/Application/')
        .map((data: Response) => {

          return data.json() as Application[];
        }).toPromise().then(x => {
            console.log(x);
          this.apps = x;
          console.log(this.apps);
        });

        return this.apps;
      }
}
