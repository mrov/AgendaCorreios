export interface User {
  id: number;
  name: string;
  lastname: string;
  email: string;
  phone1: string;
  phone2: string;
  birthDay: Date;
  address: Address;
}

export interface Address {
  id: number;
  cep: string;
  street: string;
  city: string;
  state: string;
  number: string;
  complement: string;
  neighborhood: string;
}
