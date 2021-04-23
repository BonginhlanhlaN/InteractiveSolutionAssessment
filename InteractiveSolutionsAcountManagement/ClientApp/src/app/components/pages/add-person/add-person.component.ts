import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { PersonServiceService } from '../../../services/person/person-service.service';


@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.css']
})
export class AddPersonComponent implements OnInit {

  addPersonForm = new FormGroup({

    name: new FormControl(''),
    surname: new FormControl('', Validators.required),
    idNumber: new FormControl('', Validators.required)

  });

  constructor(private personService: PersonServiceService, private router:Router) { }

  ngOnInit() {
  }

  onSubmit() {

    this.personService.addPerson(this.addPersonForm.value).subscribe(

      result => {
        // Handle result
        console.log(result);
      },
      error => {
        // Handle Error
        console.log(error);
      },
      () => {
        this.router.navigate(['/person-list'])
      }


    );

  }

}
