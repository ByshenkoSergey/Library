export interface UserLogin {
  login: string;
  password: string;
}

export interface BookAdd {
  bookId?: any
  bookName: string
  authorName: string
  yearOfPublishing: string
  publisherName: string
  fileType: string
  filePath: string
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
  userId: any
  tokenExpiration: string
  userRole:string
}

export interface Author {
  authorId: number
  authorName: string
  authorBiography: string
}

export interface BookFile {
  fileName: string
  file: any
  filePath: string
  fileType:string
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
  userRole:string
  email: string
  
}

export interface UserRole {
  roleName: string
  roleInfo:string
}

export interface Response {
  message:string
  }

export interface ResponseObject {
  object: any
  message:string
}

export interface ProgressStatus {
  status: ProgressStatusEnum;
  percentage?: number;
}

export enum ProgressStatusEnum {
  START,
  COMPLETE,
  IN_PROGRESS,
  ERROR
}


