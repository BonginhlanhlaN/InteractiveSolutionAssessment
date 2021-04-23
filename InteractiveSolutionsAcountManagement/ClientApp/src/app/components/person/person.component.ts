import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

import { Person} from '../../models/Person';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  //Field
  @Input() person!: Person;
  @Output() deletePerson: EventEmitter<Person> = new EventEmitter(); 

  constructor() { }

  ngOnInit() {
  }

  onPersonDelete(person: Person) {

    this.deletePerson.emit(person);
    
  }

}                                                                                                                                                                                                                                                                                                                                                                                                   
