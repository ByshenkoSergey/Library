export interface UserLogin {
  login: string;
  password: string;
}

export interface BookAdd {
  bookId?: any
  bookName: string
  bookFileAddress: string
  authorName: string
  yearOfPublishing: string
  publisherName: string
}

export interface BookForm {
  bookId: number
  bookName: string
  bookFileAddress: string
  authorName: string
  authorId:number
  yearOfPublishing: string
  publisherName: string
  publisherId: number
  rating: number
}

export interface DbAuthResponse {
  access_token: string
  userLogin: string
  tokenExpiration: string
}

export interface Author {
  authorId: number
  authorName: string
  authorBiography: string
}

export interface Book {
  bookId: number
  bookName: string
  bookText?: string
}

export interface Publisher {
  publisherId?: number
  publisherName?: string
  publisherInfo?: string
  publisherTellNumber?: string
  publisherEmail?: string
}

export interface User {
  userId?: number
  userLogin: string
  userPassword: string
  userFirstName?: string
  userLastName?: string
  userYearsOld?: string
  phoneNumber?: string
  email: string

}

export interface UserRole {
  roleId?: number
  roleName?: string
}
