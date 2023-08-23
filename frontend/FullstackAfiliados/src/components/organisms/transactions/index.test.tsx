import { render } from '@testing-library/react';
import TransactionsListOrganism from './';
import { Transaction } from 'src/types/transaction.type';

const mockTransactions: Transaction[] = [
  {
    salesman: 'CARLOS',
    date: '2023-08-23',
    product: 'Example Product',
    amount: 100,
    type: {
      origin: 'Entrada',
      description: 'Description here',
      signal: true,
      type: 4,
      createAt: new Date().toString(),
      modifyAt: new Date().toString(),
      id: '1',
      isDeleted: false,
    },
  },
];

test('renders TransactionsListOrganism with transactions', () => {
  const { getByText } = render(
    <TransactionsListOrganism
      transactions={mockTransactions}
      loading={false}
      error={null}
      t={(key: string) => key}
      page={0}
      rowsPerPage={5}
      onPageChange={() => undefined}
      onRowsPerPageChange={() => undefined}
    />
  );

  const signal = getByText('+');
  const type = getByText('4');
  const product = getByText('Example Product');

  expect(signal).toBeInTheDocument();
  expect(type).toBeInTheDocument();
  expect(product).toBeInTheDocument();
});

test('renders TransactionsListOrganism without transactions', () => {
  const { getByText } = render(
    <TransactionsListOrganism
      transactions={[]}
      loading={false}
      error={null}
      t={(key: string) => key}
      page={0}
      rowsPerPage={5}
      onPageChange={() => undefined}
      onRowsPerPageChange={() => undefined}
    />
  );

  const noTransactionsText = getByText('transactions.not-found');

  expect(noTransactionsText).toBeInTheDocument();
});
