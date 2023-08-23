import React from 'react';
import { useTranslation } from 'react-i18next';
import TransactionsListTemplate from '@cp/templates/transactions-template';
import useTransactions from '@core/hooks/useTransactions';

const TransactionsListPage: React.FC = () => {
  const { transactions, loading, error } = useTransactions();
  const { t } = useTranslation();

  return (
    <TransactionsListTemplate
      transactions={transactions}
      loading={loading}
      error={error}
      t={t}
    />
  );
};

export default TransactionsListPage;
