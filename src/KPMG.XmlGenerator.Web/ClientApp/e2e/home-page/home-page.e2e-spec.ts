import { HomePage } from './home-page.po';

describe('Home page section', () => {
  let homePage: HomePage;

  beforeEach(() => {
    homePage = new HomePage();
  });

  it('should display KPMG Web Template when user enters the home page', () => {
    homePage.navigateTo();

    expect(homePage.getMainHeading()).toEqual('KPMG XmlGenerator');
  });
});
