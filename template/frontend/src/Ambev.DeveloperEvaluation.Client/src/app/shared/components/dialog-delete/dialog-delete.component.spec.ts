import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DialogDeleteComponent } from './dialog-delete.component';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

describe('DialogDeleteComponent', () => {
  let component: DialogDeleteComponent;
  let fixture: ComponentFixture<DialogDeleteComponent>;
  let mockActiveModal: jasmine.SpyObj<NgbActiveModal>;

  beforeEach(async () => {
    mockActiveModal = jasmine.createSpyObj('NgbActiveModal', ['close', 'dismiss']);

    await TestBed.configureTestingModule({
      declarations: [DialogDeleteComponent],
      providers: [{ provide: NgbActiveModal, useValue: mockActiveModal }],
    }).compileComponents();

    fixture = TestBed.createComponent(DialogDeleteComponent);
    component = fixture.componentInstance;
    component.data = {
      id: 1,
      titulo: 'Delete Item',
      identificacao: 'Item #1',
    };
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should have correct input data', () => {
    expect(component.data).toEqual({
      id: 1,
      titulo: 'Delete Item',
      identificacao: 'Item #1',
    });
  });

  it('should call NgbActiveModal.close() when confirmed', () => {
    component.activeModal.close();
    expect(mockActiveModal.close).toHaveBeenCalled();
  });

  it('should call NgbActiveModal.dismiss() when dismissed', () => {
    component.activeModal.dismiss();
    expect(mockActiveModal.dismiss).toHaveBeenCalled();
  });

  it('should define onNoClick but not have functionality by default', () => {
    expect(component.onNoClick).toBeDefined();
    const result = component.onNoClick();
    expect(result).toBeUndefined();
  });
});
