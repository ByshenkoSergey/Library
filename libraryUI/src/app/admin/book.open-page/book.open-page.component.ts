import {Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {BookService} from "../shared/services/book.service";
import {DomSanitizer} from "@angular/platform-browser";
import {AuthService} from "../shared/services/auth.service";
import {HttpEventType} from "@angular/common/http";
import {ProgressStatus, ProgressStatusEnum} from "../shared/interfaces/interfaces";


@Component({
  selector: 'app-book.open-page',
  templateUrl: './book.open-page.component.html',
  styleUrls: ['./book.open-page.component.scss']
})
export class BookOpenPageComponent implements OnInit {

  @Input() public disabled: boolean;
  @Output() public downloadStatus: EventEmitter<ProgressStatus>;

  bookText: any
  downloadedFile: any
  params: any
  userRole: string
  id: any
  bookName: any;

  constructor(
    private service: BookService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private auth: AuthService
  ) {
    this.downloadStatus = new EventEmitter<ProgressStatus>();
  }

  ngOnInit() {
    this.userRole = this.auth.userRole
    this.params = this.route.params
    this.id = this.params['value'].id
    this.downloadStatus.emit({status: ProgressStatusEnum.START});
    this.service.getBook(this.id).subscribe(res => {
      this.bookName = res.bookName
     })
    this.service.getBookFile(this.id).subscribe(data => {
        this.downloadedFile = data
        switch (data.type) {
          case HttpEventType.DownloadProgress:
            this.downloadStatus.emit({
              status: ProgressStatusEnum.IN_PROGRESS,
              percentage: Math.round((data.loaded / data.total) * 100)
            });
            break;
          case HttpEventType.Response:
            this.downloadStatus.emit({status: ProgressStatusEnum.COMPLETE});
            this.downloadedFile = new Blob([data.body], {type: data.body.type});
            let fileReader = new FileReader();

            fileReader.onload = () => {
              this.bookText = fileReader.result;
            }
            fileReader.readAsText(this.downloadedFile)

            break;
        }
      },
      error => {
        this.downloadStatus.emit({status: ProgressStatusEnum.ERROR});
      }
    );

  }

  download() {
    const a = document.createElement('a');
    a.setAttribute('style', 'display:none;');
    document.body.appendChild(a);
    a.download = this.bookName;
    a.href = URL.createObjectURL(this.downloadedFile);
    a.target = '_blank';
    a.click();
    document.body.removeChild(a);
  }
}

