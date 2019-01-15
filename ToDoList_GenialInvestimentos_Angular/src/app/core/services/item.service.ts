import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Item } from '../../core/models/item';
import 'rxjs/add/operator/toPromise';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable()
export class ItemService {
  private repositoryUrl = environment.api + "/v1/itens/";

  constructor(private http: HttpClient) {
  }

  getallByNotaTarefaId(notaTarefaId: number): Observable<Item[]> {
    return this.http.get<Item[]>(this.repositoryUrl + notaTarefaId);
  }

  create(discription: string, notaTarefaId: number): Observable<Item[]> {
    return this.http.post<Item[]>(this.repositoryUrl, { notaTarefaId: notaTarefaId, Description: discription }, httpOptions);
  }

  update(item: Item) {
    this.http.put(this.repositoryUrl, item, httpOptions).subscribe();
  }

  delete(id: number) {
    this.http.delete(this.repositoryUrl + id, httpOptions).subscribe();
  }
}
