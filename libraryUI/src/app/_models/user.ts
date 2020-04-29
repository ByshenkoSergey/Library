export class User {
  constructor(
    public UserId?: number,
    public UserLogin?: string,
    public UserPassword?: string,
    public UserRole?: string,
    public UserFirstName?: string,
    public UserLastName?: string,
    public UserYearsOld?: string,
    public PhoneNumber?: string,
    public Email?: string,
    public Token?: string) { }
}
