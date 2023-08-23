import { Salesman } from 'src/types/salesman.type';

export type FetchDataState = {
    loading: boolean;
    data: Salesman[] | null;
    error: Error | null | unknown;
}