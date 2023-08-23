import apiInstance from '@core/utils/api';
import { useState } from 'react';
import i18n from 'i18next';

interface FileUploaderHook {
  selectedFile: File | null;
  uploadError: string | null;
  uploadProgress: number;
  handleFileChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
  uploadFile: (url: string) => Promise<void>;
}

export function useFileUploader(): FileUploaderHook {
  const [selectedFile, setSelectedFile] = useState<File | null>(null);
  const [uploadError, setUploadError] = useState<string | null>(null);
  const [uploadProgress, setUploadProgress] = useState<number>(0);
  const {t} = i18n;

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files && event.target.files.length > 0) {
      setSelectedFile(event.target.files[0]);
    }
  };

  const uploadFile = async (url: string) => {
    if (!selectedFile) {
      setUploadError(t('upload.error.not-file'));
      return;
    }

    const formData = new FormData();
    formData.append('file', selectedFile);

    try {
      const response = await apiInstance.post(url, formData, {
        headers: {
          'Content-Type': 'multipart/form-data'
        },
        onUploadProgress: (progressEvent) => {
          const progress = Math.round((progressEvent.loaded / progressEvent.total!) * 100);
          setUploadProgress(progress);
        },
      });

      setUploadProgress(100);
    } catch (error) {
      if(uploadProgress < 100) {
        setUploadError(t('upload.error.failed-during-upload'));
      } else {
        setUploadError(t('upload.error.failed-to-upload'));
      }
    }
  };

  return {
    selectedFile,
    uploadError,
    uploadProgress,
    handleFileChange,
    uploadFile,
  };
}
