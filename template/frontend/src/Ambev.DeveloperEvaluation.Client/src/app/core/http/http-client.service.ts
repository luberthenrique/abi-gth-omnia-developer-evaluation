import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { map } from 'rxjs/operators';

interface HttpResponse<T>{
  data: T;
  code: number;
  message: number;
  erros: any[];
}

export class HttpClientService{

  constructor(protected http: HttpClient,
    protected baseUrl: string) { }

  get<T>(
    path: string,
    options?: { headers?: HttpHeaders, params: HttpParams }
  ): Observable<T>{
    return this.http
    .get<T>(`${this.baseUrl}api/${path}`, options);
  }

  getById<T>(
    id: string,
    path: string,
  ) {
    return this.http.get<T>(`${this.baseUrl}api/${path}/${id}`);
  }

  post<T>(
    path: string,
    options?: { headers?: HttpHeaders, params: HttpParams }
  ) {
    return this.http.post<T>(`${this.baseUrl}api/${path}`, options);
  }

  put<T>(
    id: string,
    path: string,
    options?: { headers?: HttpHeaders, params: HttpParams }) {
    return this.http.put<T>(`${this.baseUrl}api/${path}/${id}`, options)
        .pipe(map(x => {
            return x;
        }));
  }

  delete(
    id: string,
    path: string) {
      return this.http.delete(`${this.baseUrl}api/${path}/${id}`)
          .pipe(map(x => {
              return x;
          }));
  }
}
