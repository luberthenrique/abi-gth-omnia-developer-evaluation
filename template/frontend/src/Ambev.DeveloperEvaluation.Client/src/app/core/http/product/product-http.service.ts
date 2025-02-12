import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';


@Injectable({
  providedIn: 'root'
})
export class ProductHttpService extends HttpClientService {
  path = 'products';
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http, 'https://localhost:8081/');
  }

  getAll(params: any) {

    let queryParams = new HttpParams();

    if (params.name != '') {
      queryParams = queryParams.append("name", params.name);
    }

    return this.get<any>(this.path, { params: queryParams });
  }

  override getById(id: string) {
    return super.getById<any>(id, this.path);
  }

  register(params : any) {
    return super.post(this.path, params);
  }

  update(id: string, params: any) {
    return this.put<any>(id, this.path, params);
  }

  override delete(id: string) {
    return super.delete(id, this.path);
  }
}
