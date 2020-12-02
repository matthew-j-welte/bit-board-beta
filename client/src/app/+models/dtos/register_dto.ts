import { UserInfo } from './user_dto';

export interface Register extends UserInfo {
  password: string;
}
