import { render } from '@testing-library/react';
import AlertAtom from './';

test('renders error Alert with message', () => {
  const errorMessage = 'An error occurred';
  const { getByRole, getByText } = render(
    <AlertAtom severity="error" message={errorMessage} />
  );
  
  const errorAlert = getByRole('alert');
  const errorText = getByText(errorMessage);
  
  expect(errorAlert).toBeInTheDocument();
  expect(errorText).toBeInTheDocument();
  expect(errorAlert).toHaveClass('MuiAlert-standardError');
});
  
test('renders warning Alert with message', () => {
  const warningMessage = 'A warning';
  const { getByRole, getByText } = render(
    <AlertAtom severity="warning" message={warningMessage} />
  );
  
  const warningAlert = getByRole('alert');
  const warningText = getByText(warningMessage);
  
  expect(warningAlert).toBeInTheDocument();
  expect(warningText).toBeInTheDocument();
  expect(warningAlert).toHaveClass('MuiAlert-standardWarning');
});
  