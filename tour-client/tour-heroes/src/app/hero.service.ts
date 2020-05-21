import { Injectable } from '@angular/core';
import { Hero } from './hero';
import { HEROES } from './mock-heroes';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HeroService {
  HEROES: Hero[] = HEROES;
  url = 'http://ec2-52-14-24-91.us-east-2.compute.amazonaws.com/Tour';
  headers = new Headers({'Content-Type': 'application/json'});
  options = { header: this.headers, withCredentials: false };

  constructor(private messageService: MessageService, private httpClient: HttpClient) { }

  ngOnInit(): void {
    // Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    // Add 'implements OnInit' to the class.
    this.getHeroes();
  }

  getHeroes(): Observable<Hero[]> {
    // TODO: send the messae _after_ fetching the heroes.
    return this.httpClient.get<Hero[]>(this.url, this.options);
  }

  getHero(id: string): Observable<Hero>{
    const url = `${this.url}/${id}`;
    return this.httpClient.get<Hero>(url).pipe(
                          tap(_ => this.log(`fetched hero id=${id}`)),
                          catchError(this.handleError<Hero>(`getHero id=${id}`))
  );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  private log(message: string) {
  this.messageService.add(`HeroService: ${message}`);
}
}
