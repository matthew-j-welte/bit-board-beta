import { User } from './user_dto';

export interface Register extends User {
    password: string;
}