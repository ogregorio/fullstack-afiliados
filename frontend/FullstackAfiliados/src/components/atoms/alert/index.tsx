import { Alert, AlertColor, AlertTitle } from '@mui/material';

type Params = {
    severity: AlertColor | undefined,
    message: string
}

export default function AlertAtom({ severity, message }: Params) {
  return (
    <Alert severity={severity}>
      <AlertTitle>{severity}</AlertTitle>
      {message}
    </Alert>
  );
}
