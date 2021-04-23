import { Component, OnInit, Input } from '@angular/core';

import { Account } from '../../models/Account';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  //Field
  @Input() account!: Account;

  constructor() { }

  ngOnInit() {
  }

}
