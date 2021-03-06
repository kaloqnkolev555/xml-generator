import { browser, by, element, ElementFinder } from 'protractor';

export class HomePage {

   private mainHeading: ElementFinder = element(by.xpath('//app-home//h1'));

  navigateTo() {
    return browser.get('/');
  }

  private waitUntilReady = function (elm: ElementFinder) {
    browser.wait(function () {
      return elm.isPresent();
    }, 10000);
  };

  getMainHeading() {
    this.waitUntilReady(this.mainHeading);
    return this.mainHeading.getText();
  }
}
