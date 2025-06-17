import { Component, OnDestroy, OnInit } from '@angular/core';
import { UserInnerService } from '../../service/user-inner.service';
import { Subject, takeUntil } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserApiService } from '../../../../api/UserApi/user-api.service';
import { RolesApiService } from '../../../../api/RolesApi/roles-api.service';

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
  constructor(private pageService: UserInnerService, private fb: FormBuilder, private api: UserApiService, private rolesApi: RolesApiService) {
    
    
  }

  form!: FormGroup

  // roles = [
  //   { label: 'Administrador', value: 'ADMIN' },
  //   { label: 'Usuário', value: 'USER' },
  //   { label: 'Convidado', value: 'GUEST' }
  // ];

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
    this.getRoles()
  }

   ngOnDestroy(): void {
    this.lifeCycle.next();
  }

  save(form: any) {

    const formData = form.value

    const apiData = {
      nome: formData.Name,
      cpf: formData.CPF,
      telefone: formData.Telefone,
      email: formData.Email,
      role: formData.Role
    }

    if (this.isEdit == true) {
      this.putUser(apiData)
    } else {
      this.addUser(apiData)
    }
  }

  reset() {
    this.isEdit = false
    this.form.patchValue({
      Name: '',
      Email: '',
      CPF: '',
      Telefone: '',
      Role: [],
    })
  }

  private fpatchValue() {
    this.form.patchValue({
      Name: this.userData?.nome,
      Email: this.userData?.email,
      CPF: this.userData?.cpf,
      Telefone: this.userData?.telefone,
      Role: this.userData?.role ?? null,
    })
  }

  private async addUser(user: any) {
    try {
      await this.api.createUser(user)

      this.visible = false
      this.pageService.$modalState.next({visible: false, data: null, isEdit: false})
      this.pageService.$refreshTableData.next()

    } catch (error) {
      console.log(error)
    }
  }

  private async putUser(user: any) {
    try {
      await this.api.editUser(user)

      this.visible = false
      this.pageService.$modalState.next({visible: false, data: null, isEdit: false})
      this.pageService.$refreshTableData.next()

    } catch (error) {
      console.log(error)
    }
  }

  private async getRoles() {
    try {
      const result =  await this.rolesApi.getRoles()
      
       this.roles = result.map((role: any) => ({
      label: role.description,
      value: role.name
    }));

      
    } catch (error) {
      console.log(error)
    }
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
          this.fpatchValue()
        }
      }
    })
  }

}
