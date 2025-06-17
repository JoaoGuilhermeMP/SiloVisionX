import { Component, OnDestroy, OnInit } from '@angular/core';
import { faTractor, faTrash } from '@fortawesome/free-solid-svg-icons';
import { RoleInnerService } from '../../service/role-inner.service';
import { Subject, takeUntil } from 'rxjs';
import { RolesApiService } from '../../../../api/RolesApi/roles-api.service';

@Component({
  selector: 'delete-role',
  standalone: false,
  templateUrl: './delete-role.component.html',
  styleUrl: './delete-role.component.css'
})
export class DeleteRoleComponent implements OnInit, OnDestroy{

  /**
   *
   */
  constructor(private pageService: RoleInnerService, private api: RolesApiService) {
    
    
  }
  

  visible: boolean = false

  role: any

  iconTrash = faTrash

  private lifeCycle = new Subject<void>()

  ngOnInit(): void {
    this.registerModalState()
  }
  ngOnDestroy(): void {
    this.lifeCycle.next()
  }

  async delete() {
    try {
      await this.api.deleteRole(this.role)
      this.visible = false
      this.pageService.$deleteModalState.next({
        visible: false,
        data: null
      })
      this.pageService.$refreshTableData.next()
    } catch (error) {
      console.log(error)
    }
  }

  private registerModalState() {
    this.pageService.$deleteModalState
    .pipe(takeUntil(this.lifeCycle))
    .subscribe({
      next: (state) => {
        this.visible = state.visible
        this.role = state.data
      }
    })
  }

}
