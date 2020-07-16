import {Pipe, PipeTransform} from "@angular/core";
import {User} from "../interfaces/interfaces";

@Pipe({
  name: 'searchUsers'
})
export class SearchUserPipe implements PipeTransform {
  transform(users: User[], search = ''): User[] {
    if (!search.trim()) {
      return users
    }
    return users.filter(user => {
      return user.userLogin.toLowerCase().includes(search.toLowerCase())
    })
  }
}
