import { WebAngFromCLI2Page } from './app.po';

describe('web-ang-from-cli2 App', () => {
  let page: WebAngFromCLI2Page;

  beforeEach(() => {
    page = new WebAngFromCLI2Page();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
