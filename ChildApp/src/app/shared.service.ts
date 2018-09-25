import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ItemList } from './model/Entities';
@Injectable()
export class SharedService {
  sharingData: ItemList = new ItemList();

  constructor(private http: HttpClient) { }

  saveData(id:number) {
    //console.log('save data function called' + str + this.sharingData.name);
    this.sharingData.ChildID = id;
  }
  getData():number
  {
    //console.log('get data function called');
    return this.sharingData.ChildID;
  }

}
