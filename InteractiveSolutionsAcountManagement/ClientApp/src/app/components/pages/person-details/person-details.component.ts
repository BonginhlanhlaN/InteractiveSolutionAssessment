import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { AccountServiceService } from '../../../services/account/account-service.service';
import { Account } from '../../../models/Account';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrls: ['./person-details.component.css']
})
export class PersonDetailsComponent implements OnInit {

  //Fields
  person_code!: number;

  accounts!: Account[];

  constructor(private activeRoute: ActivatedRoute, private accountService: AccountServiceService) { }

  ngOnInit() {

    this.person_code = this.activeRoute.snapshot.params['person_code'];
    this.accountService.getPersonAccounts(this.person_code).subscribe(accounts => { this.accounts = accounts; });

  }

}
