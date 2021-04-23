import { Component, OnInit } from '@angular/core';
import { Route, ActivatedRoute, Router, ParamMap } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';


import { AccountServiceService } from '../../../services/account/account-service.service';


@Component({
  selector: 'app-edit-account',
  templateUrl: './edit-account.component.html',
  styleUrls: ['./edit-account.component.css']
})
export class EditAccountComponent implements OnInit {

  editAccountForm = new FormGroup({

    accountNumber: new FormControl(''),
    outstandingBalance: new FormControl('')

  })

  constructor(private accountService: AccountServiceService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {

    console.log(this.activatedRoute.snapshot.params['code']);

    this.accountService.getAccount(this.activatedRoute.snapshot.params['code']).subscribe(

      result => {
        // Handle result
        this.editAccountForm = new FormGroup({

          accountNumber: new FormControl(result.accountNumber),
          outstandingBalance: new FormControl(result.outstandingBalance)

        });

      },
      error => {
        // Handle Error
        console.log(error);
      },
      () => {
        //Redirect to another component
      }

    );

  }


}
