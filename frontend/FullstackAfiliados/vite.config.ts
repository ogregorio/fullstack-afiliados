/* eslint-disable @typescript-eslint/naming-convention */
import {defineConfig} from 'vite';
import react from '@vitejs/plugin-react';
import path from 'path';

export default defineConfig({
  plugins: [react({
    jsxRuntime: 'classic',
  })],
  esbuild: {
    jsxInject: `
			import i18n from 'i18next';
			const {t} = i18n;
		`,
  },
  resolve: {
    alias: {
      '@cp': path.resolve(__dirname, './src/components'),
      '@pages': path.resolve(__dirname, './src/pages'),
      '@assets': path.resolve(__dirname, './src/assets'),
      '@core': path.resolve(__dirname, './src/core'),
      '@types': path.resolve(__dirname, './src/types'),
    },
  },
  server: {
    host: true,
  },
});
