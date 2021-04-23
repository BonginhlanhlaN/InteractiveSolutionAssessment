import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Route, ActivatedRoute, Router, ParamMap } from '@angular/router';

import { AccountServiceService } from '../../../services/account/account-service.service';

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.css']
})
export class AddAccountComponent implements OnInit {

  addAccountForm = new FormGroup({

    personCode: new FormControl(parseInt(this.activatedRoute.snapshot.params['person_code'])),
    accountNumber: new FormControl('', Validators.required),
    outstandingBalance: new FormControl(parseFloat('0.00'), Validators.required)

  });

  constructor(private accountService: AccountServiceService, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit() {
  }

  onAddAccount() {

    console.log(this.addAccountForm.value);
    this.accountService.addPersonAccount(this.addAccountForm.value).subscribe(

      result => {
        // Handle result
        console.log(result);
      },
      error => {
        // Handle Error
        console.log(error);
      },
      () => {
        this.router.navigate(['/person-details/' + this.activatedRoute.snapshot.params['person_code']])
      }

    );

  }

}
