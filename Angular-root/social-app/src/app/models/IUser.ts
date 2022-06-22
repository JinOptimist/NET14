import { SiteRole } from "./enums/SiteRole";

export interface IUser{
    id: number,
    firstName: string, 
    lastName: string,
    age: number,
    country: string,
    city: string
    userPhoto: number;
    role: SiteRole;
    isBlocked: boolean;
}