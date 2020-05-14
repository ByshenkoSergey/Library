import {Pipe, PipeTransform} from "@angular/core";
import {Publisher} from "../interfaces/interfaces";

@Pipe({
  name: 'searchBooks'
})
export class SearchPipePublisher implements  PipeTransform{
  transform(publishers: Publisher[], search = ''): Publisher[] {
    if(!search.trim()){
      return publishers
    }
    return publishers.filter(publisher =>{
      return publisher.publisherName.toLowerCase().includes(search.toLowerCase())
    })
  }
}
