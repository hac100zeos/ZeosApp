import { JwtPayload } from './jwt-payload';

export interface Jwt {
	payload: JwtPayload;
	token: string;
}
