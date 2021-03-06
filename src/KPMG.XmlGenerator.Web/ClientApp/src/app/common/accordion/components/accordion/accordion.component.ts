import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-accordion',
  templateUrl: './accordion.component.html',
  styleUrls: ['./accordion.component.scss'],
  // animations: [
  //   trigger('fadeInOut', [
  //     transition(':enter', [
  //       // :enter is alias to 'void => *'
  //       style({ opacity: 0 }),
  //       animate(500, style({ opacity: 1 })),
  //     ]),W
  //     transition(':leave', [
  //       // :leave is alias to '* => void'
  //       animate(500, style({ opacity: 0 })),
  //     ]),
  //   ]),
  // ],
})
export class AccordionComponent {
  @Input() isOpen = true;
  @Input() title = '';

  public openClose() {
    this.isOpen = !this.isOpen;
  }
}
