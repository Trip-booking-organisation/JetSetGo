export interface ISignInRequest{
  email?:string;
  password?: string;
}
export class SignInRequest implements ISignInRequest{
  email?:string;
  password?: string;
  constructor(data?: ISignInRequest) {
    if(data){
      for (const property in data){
        if (data.hasOwnProperty(property))
          (<any>this)[property] = (<any>data)[property];
      }
    }
  }
}
