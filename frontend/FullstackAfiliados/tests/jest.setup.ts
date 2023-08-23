import '@testing-library/jest-dom';

const mockI18n = {
  t: jest.fn((key) => key),
};

beforeEach(() => {
  // @ts-ignore
  global.i18n = mockI18n;
});
