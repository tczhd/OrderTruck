import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { LoginUser} from './login-user';

@Injectable()
export class HeroService {

  private headers = new Headers({ 'Content-Type': 'application/json' });
  private heroesUrl = 'api/token';  // URL to web api

  constructor(private http: Http) { }


  create(userName: string, password: string): Promise<LoginUser> {
    return this.http
      .post(this.heroesUrl, JSON.stringify({ Username: name, Password: password }), { headers: this.headers })
      .toPromise()
      .then(res => res.json().data )
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}

