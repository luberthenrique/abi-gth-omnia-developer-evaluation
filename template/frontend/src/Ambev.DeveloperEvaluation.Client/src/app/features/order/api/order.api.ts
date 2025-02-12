import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { OrderHttpService } from '../../../core/http/order/order-http.service';

@Injectable({
  providedIn: 'root'
})
export class OrderApiService {

  constructor(private readonly serviceHttp: OrderHttpService) { }

  getAll(): Observable<any>{
    return this.serviceHttp.getAll()
      .pipe(map(objs => {
        return objs;
      }));
  }

  getById(id): Observable<any> {
    return this.serviceHttp.getById(id)
      .pipe(map((obj) => obj));
  }

  register(params) {
    return this.serviceHttp.register(params)
        .pipe(map(obj => {
          return obj;
        }));
  }

  update(id, params) {
    return this.serviceHttp.update(id, params)
      .pipe(map(obj => {
        return obj;
        }));
  }

  delete(id: string) {
      return this.serviceHttp.delete(id)
        .pipe(map(obj => {
          
              return obj;
          }));
  }
}
