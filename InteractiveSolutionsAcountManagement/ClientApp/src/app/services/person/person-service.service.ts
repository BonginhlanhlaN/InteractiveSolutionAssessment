import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../../models/Person';



const httpOptions = {

  headers: new HttpHeaders({

    'Content-Type': 'application/json'

  })

}

@Injectable({
  providedIn: 'root'
})

export class PersonServiceService {

  //Fields
  baseURL: string = 'api/persons';

  constructor(private http: HttpClient) { }

  getAllPersons(): Observable<Person[]> {

    return this.http.get<Person[]>(this.baseURL);

  }

  getPerson(id: number):Observable<Person> {

    const getPersonUrl: string = `${this.baseURL}/${id}`;
    return this.http.get<Person>(getPersonUrl);

  }

  addPerson(person: any):Observable<Person> {

    return this.http.post<Person>(this.baseURL, person, httpOptions);

  }

  editPerson(id:number , person: Person): Observable<any> {

    const updateURL: string = `${this.baseURL}/${id}`;
    return this.http.put(updateURL, person, httpOptions);

  }

  deletePerson(person: Person):Observable<Person> {

    const deleteURL: string = `${this.baseURL}/${person.code}`;
    return this.http.delete<Person>(deleteURL, httpOptions);

  }



}
