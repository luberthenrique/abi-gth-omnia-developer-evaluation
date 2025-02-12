import { Component, Input } from '@angular/core';


@Component({
  selector: 'tr[skeleton-table]',
  templateUrl: './skeleton-table.component.html',
  styleUrls: ['./skeleton-table.component.scss']
})
export class SkeletonTableComponent{
    @Input() colspan = 2;
    @Input() rows = 5;
}
