import { Component, OnDestroy, OnInit } from '@angular/core';
import { faPencil, faPlus, faTrash } from '@fortawesome/free-solid-svg-icons';
import { RoleInnerService } from '../../service/role-inner.service';

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
  constructor(private pageService: RoleInnerService) {
    
    
  }  
  iconEdit = faPencil

  iconDelete = faTrash

  iconCreate = faPlus

  data = [
    {
      Name: 'Administrador',
      Description: 'Acesso completo ao sistema'
    },
    {
      Name: 'Usuário',
      Description: 'Acesso limitado às funcionalidades básicas'
    },
    {
      Name: 'Supervisor',
      Description: 'Pode visualizar e editar registros, mas não excluir'
    },
    {
      Name: 'Convidado',
      Description: 'Acesso somente leitura'
    }
  ];

  ngOnInit(): void {
   
  }
  ngOnDestroy(): void {
    this.pageService.$ModalState.next({visible: false, isEdit: false, data: null})
    this.pageService.$deleteModalState.next({visible: false, data: null})
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

}
