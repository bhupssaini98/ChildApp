import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ChildListComponent } from './child-list/child-list.component';
import { AppRoutingModule } from './app-routing.module';
import { ChilddetailComponent } from './childdetail/childdetail.component';
import { ChildService } from './child.service';
import { SharedService} from './shared.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UploadComponent } from './upload/upload.component';
import { OnlyNumber } from './directive/onlynumber';
@NgModule({
  declarations: [
    AppComponent,
    ChildListComponent,
    ChilddetailComponent,
    UploadComponent,
    OnlyNumber
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ChildService,SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
