import { Button, Typography } from '@mui/material';
import { useFileUploader } from '@core/hooks/useUpload';
import { ENDPOINTS } from '@core/constants/endpoints';

export default function Upload() {
  const {
    selectedFile,
    uploadError,
    uploadProgress,
    handleFileChange,
    uploadFile,
  } = useFileUploader();

  const handleSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    if (selectedFile) {
      uploadFile(ENDPOINTS.UPLOAD);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <Typography variant="h3" sx={{ paddingBottom: '40px' }}>
        {(t('upload.title'))}
      </Typography>
      <input
        type="file"
        onChange={handleFileChange}
      />
      {uploadProgress > 0 && (
        <Typography variant="caption">
          {(t('upload.progress'))}: {uploadProgress}%
        </Typography>
      )}
      <Button
        sx={{ marginLeft: '40px' }}
        type="submit"
        variant="contained"
        color="primary"
        disabled={!selectedFile}
      >
        {(t('upload.upload'))}
      </Button>
      {uploadProgress === 100 && !uploadError && (
        <Typography sx={{ color: 'green' }} variant="body1">
          {t('upload.success')}
        </Typography>
      )}
      {uploadError && (
        <Typography sx={{ color: 'red', marginTop: '20px' }} variant="body1">
          {uploadError}
        </Typography>
      )}
    </form>
  );
}
