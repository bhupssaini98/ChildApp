import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http'
import { SharedService } from '../shared.service';
import {ItemList } from '../model/Entities';
@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  item: ItemList = new ItemList();
  public progress: number;
  public message: string;
  constructor(private http: HttpClient, private service: SharedService) {

    this.service = service;
    //console.log('cone called');
    this.item.ChildID = service.getData();
  }

  upload(files) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files) {
      formData.append(file.name, file);
    }
    formData.append('model', JSON.stringify(this.item));

    const uploadReq = new HttpRequest('POST', `http://localhost:51549/api/upload`, formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response)
        this.message = "upload Successful !";
    });
  }

  ngOnInit() {
  }

}
