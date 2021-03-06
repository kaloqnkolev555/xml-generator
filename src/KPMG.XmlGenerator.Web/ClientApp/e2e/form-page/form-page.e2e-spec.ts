import { FormPage } from './form-page.po';

describe('Form page section', () => {
  let formPage: FormPage;

  const invalidCredentias = {
    product: '',
    email: 'invalid',
    price: 'invalid',
    expiryDate: ''
  };

  beforeEach(() => {
    formPage = new FormPage();

  });

  it('should enable add button after the user inputs valid creditentials', () => {
    formPage.navigateToFormPage();

    formPage.fillCredentials();

    expect(formPage.returnsIfAddButtonIsEnabled()).toBe(true);
  });

  it('should send an alert message for each field having invalid format in the form', () => {
    formPage.navigateToFormPage();

    formPage.fillCredentials(invalidCredentias);

    expect(formPage.getProductErrorMessage()).toEqual('This field is required!');
    expect(formPage.getEmailErrorMessage()).toEqual('Please enter a valid email!');
    expect(formPage.getPriceErrorMessage()).toEqual('This field is required!');
    expect(formPage.getExpiryDateErrorMessage()).toEqual('Please enter a valid date!');
  });
});
