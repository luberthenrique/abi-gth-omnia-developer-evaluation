import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { map } from 'rxjs';

import { HttpClientService } from '../http-client.service';


@Injectable({
  providedIn: 'root'
})
export class OrderHttpService extends HttpClientService {
  path = 'orders';
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http, 'https://localhost:8081/');
  }

  getAll() {
    return super.get<any>(this.path);
  }

  override getById(id: string) {
    return super.getById<any>(id, this.path);
  }

  register(params: any) {
    return super.post<any>(this.path, params);
  }

  update(id: string, params: any) {
    return super.put<any>(id, this.path, params);
  }
  cancel(id: number, params: any) {
    return this.http.put<any>(`https://localhost:8081/api/${this.path}/${id}/cancel`, params)
      .pipe(map(x => {
        return x;
      }));
  }

  override delete(id: string) {
    return super.delete(id, this.path);
  }
}
