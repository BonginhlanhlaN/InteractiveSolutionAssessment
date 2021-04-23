import { Component, OnInit } from '@angular/core';
import { PersonServiceService } from '../../../services/person/person-service.service';

import { Person } from '../../../models/Person';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {

  //Fields
  personsList!: Person[];

  constructor(private personService: PersonServiceService) { }

  ngOnInit(): void {

    this.personService.getAllPersons().subscribe(persons => { this.personsList = persons })

  }

  deletePerson(person: Person) {

    this.personsList.filter(p => p.code !== person.code);
    this.personService.deletePerson(person).subscribe(

      result => {
        // Handle result
        console.log(result);
      },
      error => {
        // Handle Error
        console.log(error);
      },
      () => {
        // Handle Complete
      }

    );
    //console.log("Delete this");

  }

}
