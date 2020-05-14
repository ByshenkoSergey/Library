import {Pipe, PipeTransform} from "@angular/core";
import {Author} from "../interfaces/interfaces";

@Pipe({
  name: 'searchBooks'
})
export class SearchPipeAuthor implements  PipeTransform{
  transform(authors: Author[], search = ''): Author[] {
    if(!search.trim()){
      return authors
    }
    return authors.filter(author =>{
      return author.authorName.toLowerCase().includes(search.toLowerCase())
    })
  }
}
