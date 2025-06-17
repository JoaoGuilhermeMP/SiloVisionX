import { Component, OnDestroy, OnInit } from '@angular/core';
import { UserInnerService } from '../../service/user-inner.service';
import { Subject, takeUntil } from 'rxjs';
import { faL, faTrash } from '@fortawesome/free-solid-svg-icons';
import { UserApiService } from '../../../../api/UserApi/user-api.service';

@Component({
  selector: 'delete-modal',
  standalone: false,
  templateUrl: './delete-modal.component.html',
  styleUrl: './delete-modal.component.css'
})
export class DeleteModalComponent implements OnInit, OnDestroy{

  /**
   *
   */
  constructor(private pageService: UserInnerService, private api: UserApiService) {
    
    
  }
  

  iconTrash = faTrash

  visible: boolean = false;

  user: any

  private lifeCycle = new Subject<void>()

  ngOnInit(): void {
    this.registerModalState()
  }
  ngOnDestroy(): void {
    this.lifeCycle.next()
  }

  delete() {

    try {
      this.api.deleteUser(this.user?.email)

      this.visible = false
      this.pageService.$deleteModalState.next({visible: false}) 
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
        this.visible = state.visible;
        this.user = state.data || null;
      }
    })
  }

}
