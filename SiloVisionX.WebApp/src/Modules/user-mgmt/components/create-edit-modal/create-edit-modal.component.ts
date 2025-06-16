import { Component, OnDestroy, OnInit } from '@angular/core';
import { UserInnerService } from '../../service/user-inner.service';
import { Subject, takeUntil } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'create-edit-modal',
  standalone: false,
  templateUrl: './create-edit-modal.component.html',
  styleUrl: './create-edit-modal.component.css'
})
export class CreateEditModalComponent implements OnInit, OnDestroy{

  /**
   *
   */
  constructor(private pageService: UserInnerService, private fb: FormBuilder) {
    
    
  }

  form!: FormGroup

  roles: any
  
  visible: boolean = false;

  isEdit: boolean = false;

  userData: any = null

  private lifeCycle = new Subject<void>()

  
 
  ngOnInit(): void {

    this.form = this.fb.group({
    Name: ['', Validators.required],
    Email: ['', Validators.required],
    CPF: ['', Validators.required],
    Telefone: ['', Validators.required],
    Role: [[], Validators.required],
  })

    

    this.registerModalState()
  }

   ngOnDestroy(): void {
    this.lifeCycle.next();
  }

  private patchValue() {
    this.form.patchValue({
      Name: this.userData?.name,
      Email: this.userData?.email,
      CPF: this.userData?.cpf,
      Telefone: this.userData?.telefone,
      Role: this.userData?.permissions || [],
    })
  }


  private registerModalState() {
    this.pageService.$modalState
    .pipe(takeUntil(this.lifeCycle))
    .subscribe({
      next: (state) => {
        this.visible = state.visible
        this.isEdit = state.isEdit || false;
        this.userData = state.data || null;

        if(this.isEdit == true) {
          this.patchValue()
        }
      }
    })
  }

}
