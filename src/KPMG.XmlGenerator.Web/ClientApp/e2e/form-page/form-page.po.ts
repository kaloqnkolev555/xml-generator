import { browser, by, element, Key, protractor, ElementFinder } from 'protractor';

export class FormPage {

  private productText = 'TestProduct';
  private emailText = 'test@test';
  private priceValue = 125;
  private expiryDateValue = '99/99/9999';

  private product: ElementFinder = element(by.xpath('//*[@formcontrolname="product"]'));
  private email: ElementFinder = element(by.xpath('//*[@formcontrolname="email"]'));
  private price: ElementFinder = element(by.xpath('//*[@formcontrolname="price"]'));
  private expiryDate: ElementFinder = element(by.xpath('//*[@formcontrolname="expiryDate"]'));
  private addButton: ElementFinder = element(by.className('button'));
  private productErrormsg: ElementFinder = element(by.xpath('//*[@formcontrolname="product"]/../app-error'));
  private emailErrormsg: ElementFinder = element(by.xpath('//*[@formcontrolname="email"]/../app-error'));
  private priceErrormsg: ElementFinder = element(by.xpath('//*[@formcontrolname="price"]/../app-error'));
  private expiryErrormsg: ElementFinder = element(by.xpath('//*[@formcontrolname="expiryDate"]/../app-error'));

  private validCredentias = {
    product: this.productText,
    email: this.emailText,
    price: this.priceValue,
    expiryDate: this.expiryDateValue,
  };

  private waitUntilReady = function (elm: ElementFinder) {
    browser.wait(function () {
      return elm.isPresent();
    }, 10000);
  };

  navigateToFormPage() {
    return browser.get('form');
  }

  getProductErrorMessage() {
    this.waitUntilReady(this.productErrormsg);
    return this.productErrormsg.getText();
  }

  getEmailErrorMessage() {
    this.waitUntilReady(this.emailErrormsg);
    return this.emailErrormsg.getText();
  }

  getPriceErrorMessage() {
    this.waitUntilReady(this.priceErrormsg);
    return this.priceErrormsg.getText();
  }

  getExpiryDateErrorMessage() {
    this.waitUntilReady(this.expiryErrormsg);
    return this.expiryErrormsg.getText();
  }

  fillCredentials(credentias: any = this.validCredentias) {

    this.product.sendKeys(credentias.product);
    this.email.sendKeys(credentias.email);
    this.price.sendKeys(credentias.price);
    this.expiryDate.sendKeys(credentias.expiryDate);
    this.expiryDate.sendKeys(Key.TAB);
  }

  returnsIfAddButtonIsEnabled() {
    this.waitUntilReady(this.addButton);
    return this.addButton.isEnabled();
  }
}
