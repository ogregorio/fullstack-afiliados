import { render } from '@testing-library/react';
import SalesmanListItemMolecule from '.';
import { MemoryRouter } from 'react-router-dom';

const dataSalesman = {
  name: 'John Doe',
  totalAmount: 1000,
};

test('renders SalesmanListItemMolecule', () => {
  const { getByText } = render(
    <MemoryRouter>
      <SalesmanListItemMolecule salesman={dataSalesman} t={(key) => key} />
    </MemoryRouter>
  );

  const salesmanName = getByText('John Doe');

  expect(salesmanName).toBeInTheDocument();
});
