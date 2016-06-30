import { AwesomeUxPage } from './app.po';

describe('awesome-ux App', function() {
  let page: AwesomeUxPage;

  beforeEach(() => {
    page = new AwesomeUxPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
