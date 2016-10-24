import { Injectable } from '@angular/core';

import { Hero } from './hero';
import { HEROES } from './mock-heroes';


@Injectable()
export class HeroService {
    getHeroes(): Promise<Hero[]> {
       // return Promise.resolve(HEROES);
        return new Promise<Hero[]>(resolve =>
            setTimeout(resolve, 2000)) // delay 2 seconds
            .then(() => Promise.resolve(HEROES));
    } // stub
}
