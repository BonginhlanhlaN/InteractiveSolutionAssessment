import { Component, OnInit } from '@angular/core';
import { Route, ActivatedRoute, Router, ParamMap } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { PersonServiceService } from '../../../services/person/person-service.service';




@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.css']
})
export class EditPersonComponent implements OnInit {

  //Fields

  //From route params
  code!: number;

  editPersonForm = new FormGroup({

    code: new FormControl(''),
    name: new FormControl(''),
    surname: new FormControl('', Validators.required),
    idNumber: new FormControl(''),

  });

  constructor(private activatedRouter: ActivatedRoute, private personService: PersonServiceService , private router: Router) { }

  ngOnInit() {

    this.code = this.activatedRouter.snapshot.params['code'];

    this.personService.getPerson(this.code).subscribe(response => {

      this.editPersonForm = new FormGroup({

        code: new FormControl(response['code']),
        name: new FormControl(response['name']),
        surname: new FormControl(response['surname'], Validators.required),
        idNumber: new FormControl(response['idNumber']),

      });

    });


  }

  
  onPersonUpdate() {

    this.personService.editPerson(this.activatedRouter.snapshot.params['code'], this.editPersonForm.value)
      .subscribe(response => { this.router.navigate(['/person-list'])  });

  }


}
