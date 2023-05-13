import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.scss']
})
export class StarComponent implements OnChanges {
  cropWidth : number = 90;
  @Input() rating : number =0;

  ngOnChanges(changes: SimpleChanges): void {
    this.cropWidth =this.rating * 90/5;
  }

  onClick()
  {
    this.ratingClicked.emit(`${this.rating}`);
  }
  @Output() ratingClicked:EventEmitter<string>= new EventEmitter<string>();

}
