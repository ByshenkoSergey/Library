import {Pipe, PipeTransform} from "@angular/core";
import {BookForm} from "../interfaces/interfaces";

@Pipe({
  name: 'searchBooks'
})
export class SearchPipeBook implements  PipeTransform{
  transform(books: BookForm[], search = ''): BookForm[] {
    if(!search.trim()){
      return books
    }
    return books.filter(book =>{
      return book.bookName.toLowerCase().includes(search.toLowerCase())
    })
  }
}
