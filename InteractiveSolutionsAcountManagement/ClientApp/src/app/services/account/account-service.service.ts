import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Account } from '../../models/Account';

const httpOptions = {

  headers: new HttpHeaders({

    'Content-Type': 'application/json'

  })

}

@Injectable({
  providedIn: 'root'
})
export class AccountServiceService {

  //Field
  baseURL: string = 'api/accounts';

  constructor(private http: HttpClient) { }

  getPersonAccounts(person_id: number): Observable<Account[]> {

    const getpersonAccountsUrl: string = `${this.baseURL}/persons-accounts/${person_id}`;
    return this.http.get<Account[]>(getpersonAccountsUrl);

  }

  addPersonAccount(account: any): Observable<Account> {

    return this.http.post<Account>(this.baseURL, account, httpOptions);

  }

  getAccount(code: number): Observable<Account> {

    const getAccountURL: string = `${this.baseURL}/${code}`;
    return this.http.get<Account>(getAccountURL);

  }

}
