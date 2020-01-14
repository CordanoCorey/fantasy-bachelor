import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'bachelor-site-map',
  templateUrl: './site-map.component.html',
  styleUrls: ['./site-map.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SiteMapComponent implements OnInit {

  @Input() userId = 0;
  @Input() userName = '';

  constructor() { }

  ngOnInit() {
  }

}
