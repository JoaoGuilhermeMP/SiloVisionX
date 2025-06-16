import { Component, OnDestroy, OnInit } from '@angular/core';
import { RoleInnerService } from '../../service/role-inner.service';
import { Subject, takeUntil } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'create-or-edit-roles',
  standalone: false,
  templateUrl: './create-or-edit-roles.component.html',
  styleUrl: './create-or-edit-roles.component.css'
})
export class CreateOrEditRolesComponent implements OnInit, OnDestroy{
  
  /**
   *
   */
  constructor(private pageService: RoleInnerService, private fb: FormBuilder) {
    
    
  }


  form!: FormGroup 

  visible: boolean = false
  
  role: any

  isEdit: boolean = false

  private lifeCycle = new Subject<void>()
  
  ngOnInit(): void {

    this.form = this.fb.group({
      Name: ['', Validators.required],
      Description: ['', Validators.required],
    })

    this.registerModalState()
  }

  ngOnDestroy(): void {
    this.lifeCycle.next()
  }

  private patchValue() {
    this.form.patchValue({
      Name: this.role?.Name,
      Description: this.role?.Description,
    })
  }

  private registerModalState() {
    this.pageService.$ModalState
    .pipe(takeUntil(this.lifeCycle))
    .subscribe({
      next: (state) => {
        this.visible = state.visible
        this.isEdit = state.isEdit
        this.role = state.data

        if (this.isEdit == true) {
          this.patchValue()
        }

      }
    })
  }

}
