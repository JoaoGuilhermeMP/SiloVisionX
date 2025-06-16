import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-index',
  standalone: false,
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent implements OnInit, OnDestroy{

  /**
   *
   */
  constructor(private fb: FormBuilder) {
    
    
  }
 

  form!: FormGroup

  email: string = ''

  isTokenPage: boolean = false

  ngOnInit(): void {
    this.form = this.fb.group({
      Email: ['', Validators.required]
    })
  }

   ngOnDestroy(): void {
    this.isTokenPage = false
  }

  auth(form: any) {
    this.email = form.value

    console.log(this.email)

    this.isTokenPage = true

  }

  

}
