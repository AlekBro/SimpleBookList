import { WebAngFromCLIPage } from './app.po';

describe('web-ang-from-cli App', function() {
  let page: WebAngFromCLIPage;

  beforeEach(() => {
    page = new WebAngFromCLIPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
