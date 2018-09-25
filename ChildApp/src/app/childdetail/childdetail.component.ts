

import { Component, OnInit } from '@angular/core';
import { SelectList, ChildDetails, RequestParams,ItemList } from '../model/Entities';
import { ChildService } from '../child.service';
import { SharedService } from '../shared.service';
import { Router } from '@angular/router'
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-childdetail',
  templateUrl: './childdetail.component.html',
  styleUrls: ['./childdetail.component.css']
})
export class ChilddetailComponent implements OnInit {
  Gender: SelectList[];
  Type: SelectList[];
  ChildRelation: SelectList[];
  Status: SelectList[];
  childinfo: ChildDetails = new ChildDetails();
  item: ItemList = new ItemList();
  constructor(private childservice: ChildService, private service: SharedService, private router: Router) {

    this.service = service;
    //console.log('cone called');
    this.item.ChildID = service.getData();
  }

  onSubmit(childinfo):void {
    if (childinfo.ChildFirstName == "") {
      alert("Please Enter Child First Name");
    }
    else if (childinfo.ChildLastName == "") {
      alert("Please Enter Child Last Name");
    }
    else {
      this.childservice.AddEditChildData(childinfo).subscribe(res => {
        alert(res.Message);
        this.router.navigate(['/childlist']);
        this.childinfo.ChildFirstName = "";
        this.childinfo.ChildLastName = "";
      });
    }

  }

  GetOneChildData() {
    this.childservice.GetOneChildData(this.item).subscribe(res => {
      this.childinfo = res;
    });
  }

  getFilters(): void {
    this.childservice.bindSearchFilter().subscribe(res => {
      this.Gender = res.Gender;
      this.Type = res.Type;
      this.ChildRelation = res.ChildRelation;
      this.Status = res.Status;
    });
  }

  ngOnInit() {
    this.getFilters();
    if (this.item.ChildID) {
      this.GetOneChildData();
    }
   
  }

}
