import { Component, OnDestroy, OnInit } from '@angular/core';
import { faPencil, faPlus, faTrash } from '@fortawesome/free-solid-svg-icons';
import { RoleInnerService } from '../../service/role-inner.service';
import { RolesApiService } from '../../../../api/RolesApi/roles-api.service';
import { Subject, takeUntil } from 'rxjs';

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
  constructor(private pageService: RoleInnerService, private api: RolesApiService) {
    
    
  }  
  iconEdit = faPencil

  iconDelete = faTrash

  iconCreate = faPlus

  // data = [
  //   {
  //     Name: 'Administrador',
  //     Description: 'Acesso completo ao sistema'
  //   },
  //   {
  //     Name: 'Usuário',
  //     Description: 'Acesso limitado às funcionalidades básicas'
  //   },
  //   {
  //     Name: 'Supervisor',
  //     Description: 'Pode visualizar e editar registros, mas não excluir'
  //   },
  //   {
  //     Name: 'Convidado',
  //     Description: 'Acesso somente leitura'
  //   }
  // ];

  data: any

  private lifeCycle = new Subject<void>()

  ngOnInit(): void {
   this.getAllRoles()

   this.registerTableData()

  }
  ngOnDestroy(): void {
    this.pageService.$ModalState.next({visible: false, isEdit: false, data: null})
    this.pageService.$deleteModalState.next({visible: false, data: null})
    this.lifeCycle.next()
  }


  private async getAllRoles() {
    try {
      const result = await this.api.getRoles()

      this.data = result
    } catch (error) {
      console.log(error)
    }
  }

  addRole() {
    this.pageService.$ModalState.next({visible: true, isEdit: false})
  }

  editRole(role: any) {
    this.pageService.$ModalState.next({visible: true, isEdit: true, data: role})
  }

  deleteRole(role: any) {
    this.pageService.$deleteModalState.next({visible: true, data: role})
  }

  private registerTableData() {
    this.pageService.$refreshTableData
    .pipe(takeUntil(this.lifeCycle))
    .subscribe({
      next: () => {
        this.getAllRoles()
      }
    })
  }

}
