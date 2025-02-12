/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { SkeletonTableComponent } from './skeleton-table.component';


describe('SkeletonTableComponent', () => {
  let component: SkeletonTableComponent;
  let fixture: ComponentFixture<SkeletonTableComponent>;

  // tslint:disable-next-line: deprecation
  beforeEach(waitForAsync(() => {
      TestBed.configureTestingModule({
      declarations: [ SkeletonTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SkeletonTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
