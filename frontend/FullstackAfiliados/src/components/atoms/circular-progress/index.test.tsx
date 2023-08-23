import { render } from '@testing-library/react';
import CircularProgressAtom from './';

test('renders CircularProgressAtom', () => {
  const { container } = render(<CircularProgressAtom />);
  const circularProgress = container.querySelector('svg');

  expect(circularProgress).toBeInTheDocument();
});
