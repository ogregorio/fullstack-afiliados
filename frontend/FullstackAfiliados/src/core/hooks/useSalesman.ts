import { useState, useEffect } from 'react';
import { Salesman } from 'src/types/salesman.type';
import { FetchDataState } from 'src/types/fetch.type';
import apiInstance from '@core/utils/api';

const useSalesman = (): FetchDataState => {
  const [fetchDataState, setFetchDataState] = useState<FetchDataState>({
    loading: true,
    data: null,
    error: null,
  });
  
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await apiInstance.get('/transactions/salesman');
        const data: Salesman[] = response.data;
        setFetchDataState({
          loading: false,
          data,
          error: null,
        });
      } catch (error) {
        setFetchDataState({
          loading: false,
          data: null,
          error
        });
      }
    };
  
    fetchData();
  }, []);
  
  return fetchDataState;
};
  

export default useSalesman;
