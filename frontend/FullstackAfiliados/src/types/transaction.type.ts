export interface Transaction {
    salesman: string
    type: Type
    date: string
    product: string
    amount: number
}
  
export interface Type {
    id: string
    createAt: string
    modifyAt: string
    isDeleted: boolean
    type: number
    description: string
    origin: string
    signal: boolean
}
  