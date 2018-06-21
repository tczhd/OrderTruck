import { Injectable }    from '@angular/core';
import { Headers, Http} from '@angular/http';
import { Observable } from "rxjs/Rx"
import { HttpErrorResponse } from '@angular/common/http';
import 'rxjs/add/operator/toPromise';

import { Hero } from './hero';

@Injectable()
export class HeroService {

  private headers = new Headers({'Content-Type': 'application/json'});
  private heroesUrl = 'api/heroes';  // URL to web api
 

  constructor(private http: Http) { }

  getToken(){

    const req1 = this.http
    .post('https://localhost:44308/token', {username: 'hongdingzhu@hotmail.com',
    Password: 'Lq160011!'}, {headers: this.headers})
    .subscribe(
      res => {
        console.log(res.json())
        let a = res;
      },
      err => {
        console.log(err.json())
        let error = err;
      }
    );

      // this.http.get('https://localhost:44308/api/helloworld').subscribe(data => {
      //   console.log(data);
      // });

    //let b = req1;
  }

  getHeroes(): Promise<Hero[]> {
    return this.http.get(this.heroesUrl)
               .toPromise()
               .then(response => response.json().data as Hero[])
               .catch(this.handleError);
  }


  getHero(id: number): Promise<Hero> {
    const url = `${this.heroesUrl}/${id}`;
    return this.http.get(url)
      .toPromise()
      .then(response => response.json().data as Hero)
      .catch(this.handleError);
  }

  delete(id: number): Promise<void> {
    const url = `${this.heroesUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  create(name: string): Promise<Hero> {
    return this.http
      .post(this.heroesUrl, JSON.stringify({name: name}), {headers: this.headers})
      .toPromise()
      .then(res => res.json().data as Hero)
      .catch(this.handleError);
  }

  update(hero: Hero): Promise<Hero> {
    const url = `${this.heroesUrl}/${hero.id}`;
    return this.http
      .put(url, JSON.stringify(hero), {headers: this.headers})
      .toPromise()
      .then(() => hero)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}

