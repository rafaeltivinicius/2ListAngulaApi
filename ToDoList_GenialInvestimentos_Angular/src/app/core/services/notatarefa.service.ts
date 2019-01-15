import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs/Observable';
import { catchError, map, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NotaTarefa } from '../models/notatarefa';
import 'rxjs/add/operator/toPromise';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=UTF-8'})
};

@Injectable()
export class NotaTarefaService {
  private repositoryUrl = environment.api + "/v1/notasTarefa/";

  constructor(private http: HttpClient) {
  }

  getall(): Observable<NotaTarefa[]> {
    return this.http.get<NotaTarefa[]>(this.repositoryUrl);
  }

  create(notaTarefa: NotaTarefa): Observable<NotaTarefa> {
    return this.http.post<NotaTarefa>(this.repositoryUrl, notaTarefa, httpOptions);
  }

  update(notaTarefa: NotaTarefa) {
    this.http.put(this.repositoryUrl, notaTarefa, httpOptions).subscribe();
  }

  delete(id: number) {
    this.http.delete(this.repositoryUrl + id, httpOptions).subscribe();
  }
}
