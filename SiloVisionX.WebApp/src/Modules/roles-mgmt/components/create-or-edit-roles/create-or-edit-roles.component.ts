import { Component, OnDestroy, OnInit } from '@angular/core';
import { RoleInnerService } from '../../service/role-inner.service';
import { Subject, takeUntil, firstValueFrom } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RolesApiService } from '../../../../api/RolesApi/roles-api.service';

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
  constructor(private pageService: RoleInnerService, private fb: FormBuilder, private api: RolesApiService) {
    
    
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

  save(form: any) {

    const formData = form.value 

    const apiData = {
      name: formData?.Name,
      description: formData?.Description,
    }

    if (this.isEdit == true) {
      this.putRole(apiData)
    } else {
      this.addRole(apiData)
    }

  }

  reset() {
    this.isEdit = false
    this.visible = false
    this.form.patchValue({
      Name: '',
      Description: ''
    })
  }

  private patchValue() {
    this.form.patchValue({
      Name: this.role?.name,
      Description: this.role?.description,
    })
  }

  private async addRole(role: any) {
    try {
          await this.api.createRole(role)
          this.reset()
          this.pageService.$refreshTableData.next()
        } catch (error) {
          console.log(error)
        }
  }

  private async putRole(role: any) {
    try {
      await this.api.editRole(role)
      this.reset()
      this.pageService.$refreshTableData.next()
    } catch (error) {
      console.log(error)
    }
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
