import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ChildListComponent } from './child-list/child-list.component'
import {ChilddetailComponent} from './childdetail/childdetail.component'
import {UploadComponent } from './upload/upload.component'
const routes: Routes = [
  { 'path': '', 'redirectTo': '/childlist', 'pathMatch': 'full' },
  { 'path': 'childlist', 'component': ChildListComponent},
  { 'path': 'childdetail', 'component': ChilddetailComponent },
  { 'path': 'upload', 'component': UploadComponent },
]

@NgModule({
  imports: [
    CommonModule, RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
