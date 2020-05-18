export class User {
    constructor(e:string)
    {
        this.email=e;
    }
    id: string;
    phoneNumber:string;
    username: string;
    password: string;
    confirmPassword:string;
    firstName: string;
    lastName: string;
    email: string;
    token?: string;
}