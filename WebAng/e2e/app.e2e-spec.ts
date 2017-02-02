import { WebAngPage } from './app.po';

describe('web-ang App', function() {
  let page: WebAngPage;

  beforeEach(() => {
    page = new WebAngPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
