import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Hero } from './hero';
//import { HEROES } from './mock-heroes';


@Injectable()
export class HeroService {

    private heroesUrl = 'app/heroes';  // URL to web api

    constructor(private http: Http) { }

    getHeroes(): Promise<Hero[]> {
        return this.http.get(this.heroesUrl)
            .toPromise()
            .then(response => response.json())
            .catch(this.handleError);
    }

    getHero(id: number): Promise<Hero> {
        return this.getHeroes()
            .then(heroes => heroes.find(hero => hero.id === id));
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

    private headers = new Headers({ 'Content-Type': 'application/json' });
    private headers2 = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });

    update(hero: Hero): Promise<Hero> {
        const url = `${this.heroesUrl}/${hero.id}`;
        return this.http
            .put(url, JSON.stringify(hero), { headers: this.headers })
            .toPromise()
            .then(() => hero)
            .catch(this.handleError);
    }

    create(name: string): Promise<Hero> {
        return this.http.post(this.heroesUrl, "name=" + name ,{ headers: this.headers2 }).toPromise()
            .then(response => response.json())
            .catch(this.handleError);
    }

    delete(id: number): Promise<boolean> {
        return this.http.delete(this.heroesUrl+"/"+id, { headers: this.headers }).toPromise()
            .then(response => response.json())
            .catch(this.handleError);
    }
}
