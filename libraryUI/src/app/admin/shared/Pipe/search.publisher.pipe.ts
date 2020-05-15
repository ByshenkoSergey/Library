import {Pipe, PipeTransform} from "@angular/core";
import {Publisher} from "../interfaces/interfaces";

@Pipe({
  name: 'searchPublishers'
})
export class SearchPublisherPipe implements  PipeTransform{
  transform(publishers: Publisher[], search = ''): Publisher[] {
    if(!search.trim()){
      return publishers
    }
    return publishers.filter(publisher =>{
      return publisher.publisherName.toLowerCase().includes(search.toLowerCase())
    })
  }
}
