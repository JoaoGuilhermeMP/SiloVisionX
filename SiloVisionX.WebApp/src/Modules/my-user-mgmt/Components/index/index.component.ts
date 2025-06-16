import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { faSignOut } from '@fortawesome/free-solid-svg-icons';

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
  
  iconLogout = faSignOut

  form!: FormGroup

  roles: any

  ngOnInit(): void {
    this.form = this.fb.group({
      Name: [''],
      Email: [''],
      CPF: [''],
      Telefone: [''],
      Role: [''],
    })
  }
  ngOnDestroy(): void {
    
  }

}
