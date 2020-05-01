export interface UserLogin {
  login: string;
  password: string;
}

export interface BookAdd {
  bookId?: number
  bookName: string
  bookFileAddress: string
  authorName: string
  yearOfPublishing: string
  publishingHouseName: string
}

export interface BookForm {
  bookId: number
  bookName: string
  bookFileAddress: string
  authorName: string
  yearOfPublishing: string
  publishingHouseName: string
  rating: number
}

export interface DbAuthResponse {
  access_token: string
  userLogin: string
  tokenExpiration: string
}

export interface Author {
  authorID?: number
  authorName?: string
  authorBiography?: string
}

export interface Book {
  bookId: number
  bookName: string
  bookText?: string
}

export interface PublishingHouse {
  publishingHouseId?: number
  publishingHouseName?: string
  publishingHouseInfo?: string
  publishingHouseTellNumber?: string
  publishingHouseEmail?: string
}

export interface User {
  userId?: number
  userLogin?: string
  userPassword?: string
  userRole?: string
  userFirstName?: string
  userLastName?: string
  userYearsOld?: string
  phoneNumber?: string
  email?: string
  token?: string
}

export interface UserRole {
  roleId?: number
  roleName?: string
}
