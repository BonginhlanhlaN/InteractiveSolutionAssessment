import { Component, OnInit,Input } from '@angular/core';

import { Transaction } from '../../models/Transaction';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {

  //Fields
  @Input() transaction!: Transaction;


  constructor() { }

  ngOnInit() {
  }

}
