import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-xml-button',
  templateUrl: './xml-button.component.html',
  styleUrls: ['./xml-button.component.scss'],
})
export class XmlButtonComponent {
  @Input() title = '';
  @Input() whiteTheme: boolean;
  @Input() disabled: boolean;
  @Input() isSubmit = false;
}
