import { render } from '@testing-library/react';
import TransactionsListTemplate from './';
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

test('renders TransactionsListTemplate with transactions', () => {
  const { getByText } = render(
    <TransactionsListTemplate
      transactions={mockTransactions}
      loading={false}
      error={null}
      t={(str: string) => str}
    />
  );

  const productCell = getByText('Example Product');
  const originCell = getByText('Entrada');
  const descriptionCell = getByText('Description here');
  const signalCell = getByText('+');
  const typeCell = getByText('4');

  expect(productCell).toBeInTheDocument();
  expect(originCell).toBeInTheDocument();
  expect(descriptionCell).toBeInTheDocument();
  expect(signalCell).toBeInTheDocument();
  expect(typeCell).toBeInTheDocument();
});
