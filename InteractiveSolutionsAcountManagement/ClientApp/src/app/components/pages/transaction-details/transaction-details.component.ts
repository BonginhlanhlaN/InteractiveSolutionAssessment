import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { TransactionServiceService } from '../../../services/transaction/transaction-service.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-transaction-details',
  templateUrl: './transaction-details.component.html',
  styleUrls: ['./transaction-details.component.css']
})
export class TransactionDetailsComponent implements OnInit {

  code!: number;
  transactionDate!: any;
  captureDate!: any;
  amount!: number;
  description!: string;

  editTransactionForm = new FormGroup({

    accountCode: new FormControl(''),
    transactionDate: new FormControl(''),
    captureDate: new FormControl(''),
    amount: new FormControl(''),
    description: new FormControl('')

  })
  
  constructor(private transactionService: TransactionServiceService, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    this.code = this.activatedRoute.snapshot.params['code'];

    this.transactionService.getTransaction(this.code).subscribe(

      result => {

        // Handle result
        
        this.editTransactionForm = new FormGroup({

          accountCode: new FormControl(result.accountCode),
          transactionDate: new FormControl(result.transactionDate),
          captureDate: new FormControl(result.captureDate),
          amount: new FormControl(result.amount),
          description: new FormControl(result.description)

        })


      },
      error => {
        // Handle Error
        console.log(error);
      },
      () => {

        //Complete callback -- Redirect to next page
      }

    );

  }

  onEditTransaction() {

    this.router.navigate(['/person-list'])


  }


}
