export class UserModel {
    constructor(
        public userID: string,
        public userName: string,
        public roles: Array<string>,
        private _token: string,
        private _tokenExpirationDate: Date
    ) {}
  
    get token() {
      if (!this._tokenExpirationDate || new Date() > this._tokenExpirationDate) {
        return null;
      }
      return this._token;
    }
  }
  