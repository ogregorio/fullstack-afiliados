export default {
  testEnvironment: 'jest-environment-jsdom',
  transform: {
    '^.+\\.tsx?$': 'ts-jest'
  },
  moduleNameMapper: {
    '\\.(gif|ttf|eot|svg|png)$': '<rootDir>/test/__mocks__/fileMock.js',
    '\\.(css|less|sass|scss)$': 'identity-obj-proxy',
    '^@cp/(.*)$': '<rootDir>/src/components/$1',
    '^@pages/(.*)$': '<rootDir>/src/pages/$1',
    '^@assets/(.*)$': '<rootDir>/src/assets/$1',
    '^@core/(.*)$': '<rootDir>/src/core/$1',
    '^@types/(.*)$': '<rootDir>/src/types/$1'
  },
  setupFilesAfterEnv: ['<rootDir>/tests/jest.setup.ts']
};