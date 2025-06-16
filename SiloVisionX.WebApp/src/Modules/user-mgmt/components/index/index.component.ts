import { Component, ViewChild } from '@angular/core';
import { faAdd, faPencil, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Table } from 'primeng/table';
import { UserInnerService } from '../../service/user-inner.service';

@Component({
  selector: 'app-index',
  standalone: false,
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent {


  /**
   *
   */
  constructor(private pageService: UserInnerService) {
    
    
  }

  @ViewChild('table') table!: Table;

  data = [
    {
      name: 'João Silva',
      email: 'joao.silva@email.com',
      cpf: '123.456.789-00',
      telefone: '(41) 99876-5432',
      permissions: 'Administrador'
    },
    {
      name: 'Maria Souza',
      email: 'maria.souza@email.com',
      cpf: '234.567.890-11',
      telefone: '(11) 98765-4321',
      permissions: 'Usuário'
    },
    {
      name: 'Carlos Lima',
      email: 'carlos.lima@email.com',
      cpf: '345.678.901-22',
      telefone: '(21) 91234-5678',
      permissions: 'Visualizador'
    },
    {
      name: 'Ana Oliveira',
      email: 'ana.oliveira@email.com',
      cpf: '456.789.012-33',
      telefone: '(51) 99812-3344',
      permissions: 'Administrador'
    },
    {
      name: 'Paulo Mendes',
      email: 'paulo.mendes@email.com',
      cpf: '567.890.123-44',
      telefone: '(31) 98741-1122',
      permissions: 'Usuário'
    }
  ];
  iconEdit = faPencil
  iconDelete = faTrash
  iconAdd = faAdd


  openModal() {
    this.pageService.$modalState.next({
      visible: true, isEdit: false, data: null
    });
  }

  onSearch(value: string): void {
    this.table.filterGlobal(value, 'contains');
  }

  editUser(user: any) {
    this.pageService.$modalState.next({
          visible: true, isEdit: true, data: user
        });
  }

  deleteUser(user: any) {
    this.pageService.$deleteModalState.next({
      visible: true, data: user
    });
  }

}
