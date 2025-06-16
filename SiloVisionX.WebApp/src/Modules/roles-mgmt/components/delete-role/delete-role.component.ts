import { Component, OnDestroy, OnInit } from '@angular/core';
import { faTractor, faTrash } from '@fortawesome/free-solid-svg-icons';
import { RoleInnerService } from '../../service/role-inner.service';
import { Subject, takeUntil } from 'rxjs';

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
  constructor(private pageService: RoleInnerService) {
    
    
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
