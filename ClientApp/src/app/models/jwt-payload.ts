export interface JwtPayload {
	aud: string;
	exp: Date;
	iss: string;
	jti: string;
	sub: string;
}
