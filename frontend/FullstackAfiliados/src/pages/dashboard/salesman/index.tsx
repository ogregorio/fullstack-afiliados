import SalesmanTemplate from '@cp/templates/salesmans-template';
import useSalesman from '@core/hooks/useSalesman';
import { useTranslation } from 'react-i18next';

export default function SalesmanListPage() {
  const { loading, data, error } = useSalesman();
  const { t } = useTranslation();

  return (
    <SalesmanTemplate loading={loading} error={error} data={data} t={t} />
  );
}
