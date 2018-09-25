import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SelectList, ChildDetails,SearchFilter } from './model/Entities';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { environment } from "../environments/environment";
@Injectable()
export class ChildService {


  constructor(private http: HttpClient) { }

  //GetChild(){
   
  //  //return this.http.get(`${environment.ServiceURL}GetChilds`).pipe(map(res => res.json()));
  //  return this.http.get<ChildDetails[]>('http://localhost:51549/api/GetChilds');

  //}
  bindSearchFilter(): Observable<any> {

    return this.http.get('http://localhost:51549/api/Search');

  }

  GetChild(request) {

    //return this.http.get(`${environment.ServiceURL}GetChilds`).pipe(map(res => res.json()));
    return this.http.post<ChildDetails[]>('http://localhost:51549/api/GetChilds', request);

  }
  GetOneChildData(request) {

    //return this.http.get(`${environment.ServiceURL}GetChilds`).pipe(map(res => res.json()));
    return this.http.post<ChildDetails>('http://localhost:51549/api/GetOneChildData', request);

  }
  

  AddEditChildData(child): Observable<any>{

    return this.http.post('http://localhost:51549/api/AddEditChildData',child);

  }
  DelteChildData(item): Observable<any> {

    return this.http.post('http://localhost:51549/api/DeleteChildData', item);

  }

}
