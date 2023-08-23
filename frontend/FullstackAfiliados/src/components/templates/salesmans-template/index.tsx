import CircularProgressAtom from '@cp/atoms/circular-progress';
import AlertAtom from '@cp/atoms/alert';
import SalesmanListSection from '@cp/organisms/salesmans-list-section';
import { Salesman } from 'src/types/salesman.type';

type Params= {
    loading?: boolean
    error?: unknown,
    data: Salesman[] | null,
    t: (str: string) => string
}

export default function SalesmanTemplate({ loading, error, data, t }: Params) {
  if (loading) {
    return <CircularProgressAtom />;
  }

  if (error || !data) {
    return <AlertAtom severity="error" message={t('salesman.error')} />;
  }

  return <SalesmanListSection data={data} t={t} />;
}
