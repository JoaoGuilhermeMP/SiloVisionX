import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEditModalComponent } from './create-edit-modal.component';

describe('CreateEditModalComponent', () => {
  let component: CreateEditModalComponent;
  let fixture: ComponentFixture<CreateEditModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateEditModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateEditModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
