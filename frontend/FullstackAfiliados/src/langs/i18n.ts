import i18next from 'i18next';
import {initReactI18next} from 'react-i18next';
import braziliamPortuguese from './translations/pt.json';

const resources = {
  pt: {
    translation: braziliamPortuguese,
  },
};

i18next.use(initReactI18next).init({
  resources, lng: 'pt',
});
