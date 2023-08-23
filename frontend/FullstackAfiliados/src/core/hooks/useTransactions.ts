import apiInstance from '@core/utils/api';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

const fetchTransactions = async (salesman: string) => {
  try {
    const response = await apiInstance.get(`/transactions?Salesman=${salesman}`);
    return response.data;
  } catch (error) {
    throw new Error('Error fetching transactions');
  }
};

const useTransactions = () => {
  const [transactions, setTransactions] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const params = useParams(); 

  useEffect(() => {
    fetchTransactions(params.id || '')
      .then(data => {
        setTransactions(data);
        setLoading(false);
      })
      .catch(err => {
        setError(err.message);
        setLoading(false);
      });
  }, [params]);

  return { transactions, loading, error };
};

export default useTransactions;