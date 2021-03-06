let SpecReporter = require('jasmine-spec-reporter').SpecReporter;
let TfsReporter = require('jasmine-tfs-reporter');

exports.config = {
  allScriptsTimeout: 240000,
  specs: [
    './e2e/**/*.e2e-spec.ts',
  ],
  capabilities: {
    browserName: 'chrome',
    chromeOptions: {
      args: [
        '--headless', 
        '--disable-gpu', 
        '--window-size=800x600', 
        '--no-sandbox',
        '--disable-extensions']        
    }
  },
  directConnect: true,
  baseUrl: 'https://localhost:12000',
  framework: 'jasmine',
  jasmineNodeOpts: {
    showColors: true,
    defaultTimeoutInterval: 240000,
    print: function () { }
  },
  onPrepare() {
    require('ts-node').register({
      project: require('path').join(__dirname, 'e2e/tsconfig.e2e.json')
    });
    jasmine.getEnv().addReporter(new SpecReporter({ spec: { displayStacktrace: true } }));
    jasmine.getEnv().addReporter(new TfsReporter({ spec: { displayStacktrace: true } }));
  }
};
