import { IApiMethod } from './IApiMethod';

export interface IApi{
    name: string;
    methods: IApiMethod[];   
}