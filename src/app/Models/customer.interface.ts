export interface Customer {
    id: number;
    name: string;
    address: string;
    district: string;
    mobile: number;
    phoneNumber1: number;
    phoneNumber2: number;
    whatsapp_Number: number;
    email: string;
    gender: string;
    residence: string;
    description: string;
    jop: string;
    salesman: string;
    client_source: string;
    customer_rating: string;
    [key: string]: any;
  }