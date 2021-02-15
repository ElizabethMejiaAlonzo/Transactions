import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private httpClient: HttpClient) { }

  apiUrl = "https://localhost:44354/Transaction";

  /**
   * sendGetRequest
   * @returns {Observable<Object>}
   */
  public sendGetRequest() {
    const headers = new HttpHeaders();

    headers.set('Access-Control-Allow-Origin','http://localhost:4200');
    headers.set('withCredentials', 'true');
    headers.set('Access-Control-Allow-Credentials', 'false');
    
    return this.httpClient.get(this.apiUrl, {
      
      headers: {'Access-Control-Allow-Origin':'*',
      'Content-Type': 'application/json',
      'Authorization':'false'}
    });
  }
}
