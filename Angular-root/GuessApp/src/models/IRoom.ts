import { IUser } from './IUser';
import { RoomType } from './RoomType';
export interface IRoom{
    id: number;
    membersCount: number;
    owner: string; 
    type: RoomType;
    members: IUser[];
}