import {Header} from './Header';

export class Response<T>{
    public header:Header;
    public data:T;
}