import { Component, OnInit } from '@angular/core';
import { SelectList, ChildDetails,RequestParams,ItemList } from '../model/Entities';
import { ChildService } from '../child.service';
import { SharedService } from '../shared.service';
import { Router} from '@angular/router'
@Component({
  selector: 'app-child-list',
  templateUrl: './child-list.component.html',
  styleUrls: ['./child-list.component.css']
})
export class ChildListComponent implements OnInit {

  child: ChildDetails[];
  item: ItemList=new ItemList();
  request: RequestParams = new RequestParams();
  constructor(private childservice: ChildService, private service: SharedService, private router: Router) { }

  onSubmit(cfname: string, clname: string): void {
    this.request.ChildFirstName = cfname;
    this.request.ChildLastName = clname;
    this.childservice.GetChild(this.request)
      .subscribe(res => {
        this.child = res;
        console.log(res);
      });
  };
  onEdit(childId: number) {
    this.service.saveData(childId);
    this.router.navigate(['/childdetail']);
  }
  onDelete(childId: number) {
    if (confirm('Are you sure you want to delete record')) {
      this.item.ChildID = childId;
      this.childservice.DelteChildData(this.item).subscribe(res => {
        alert(res.Message);
        //this.child.splice(index);
        this.request.ChildFirstName = "";
        this.request.ChildLastName = "";
        this.childservice.GetChild(this.request)
          .subscribe(res => {
            this.child = res;
            console.log(res);
          });
      });

    }
  }
  onDocumentUpload(childId: number) {
    this.service.saveData(childId);
    this.router.navigate(['/upload']);
  }


  ngOnInit() {
    this.request.ChildFirstName = "";
    this.request.ChildLastName = "";
    this.childservice.GetChild(this.request)
      .subscribe(res => {
        this.child = res;
        console.log(res);
      });
  }

}
