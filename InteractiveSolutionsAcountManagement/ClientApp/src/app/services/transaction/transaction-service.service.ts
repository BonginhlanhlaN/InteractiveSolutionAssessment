import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Transaction } from '../../models/Transaction';

const httpOptions = {

  headers: new HttpHeaders({

    'Content-Type': 'application/json'

  })

}

@Injectable({
  providedIn: 'root'
})
export class TransactionServiceService {

  //Fields
  baseURL: string = 'api/transactions';

  constructor(private http: HttpClient) { }

  getTransaction(code: number):Observable<Transaction> {

    return this.http.get<Transaction>(`${this.baseURL}/${code}`);

  }


  getAccountTransactions(account_code: number): Observable<Transaction[]> {

    return this.http.get<Transaction[]>(`${this.baseURL}/account-transctions/${account_code}`);

  }

  addTransaction(transaction: any):Observable<Transaction> {

    console.log(transaction);
    return this.http.post<Transaction>(this.baseURL, transaction, httpOptions);

  }

  editTransaction(transactionCode: number,transaction: Transaction): Observable<any> {

    const editURL: string = `${this.baseURL}/${transactionCode}`;
    return this.http.put(editURL, transaction, httpOptions);

  }

}
