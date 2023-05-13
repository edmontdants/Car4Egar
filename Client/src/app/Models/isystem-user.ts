export interface ISystemUser {
  nid: string;    //f1
  userName: string; //f1
  password: string; //f3
  email: string;  //f1 //f3
  role: string;
  isActivated: boolean;
  address: string;  //f1
  phoneNumber: string;  //f1
  gender: string;   //f1
  birthDate: string; //f1
  photo: string;
  identityPhoto: string;
  driverLicencePhoto: string;
  driverLicenceNumber: string;  //f1
  driverLicenceEXDate: string;
  bank_NID: string;
  bank_Name: string;
  bank_AccountNumber:string;  //
  bank_Branch:string;  //
  card_EXDate: string;
  card_Number:string; //
  card_CVC: string;
  card_HolderName: string;
  balance: number;
  fine: number;
  rate: number;
  ratedPeople: number;
}
