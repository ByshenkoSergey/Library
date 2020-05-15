import {Pipe, PipeTransform} from "@angular/core";
import {Author, BookForm, UserRole} from "../interfaces/interfaces";

@Pipe({
  name: 'searchUserRole'
})
export class SearchUserRolePipe implements  PipeTransform{
  transform(roles: UserRole[], search = ''): UserRole[] {
    if(!search.trim()){
      return roles
    }
    return roles.filter(role =>{
      return role.roleName.toLowerCase().includes(search.toLowerCase())
    })
  }
}
