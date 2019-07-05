import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from './components/register/register.component';
import { AboutComponent } from './components/about/about.component';
import { HelpComponent } from './components/help/help.component';
import { UserService } from './user.service';
import { MailLoginComponent } from './components/mail-login/mail-login.component';
import { PreviewDetailsComponent } from './components/preview-details/preview-details.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule} from '@angular/material';
import { MyMaterialModule } from './modules/my-material.module';
import { DownloadComponent } from './components/download/download.component';
import { PerferncesListComponent } from './components/perfernces-list/perfernces-list.component';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import{HttpModule} from '@angular/http';
import { AddInputEmailComponent } from './components/add-input-email/add-input-email.component';
const appRoutes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'about', component: AboutComponent },
  { path: 'help', component: HelpComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'preview-details', component: PreviewDetailsComponent },
  { path: 'login', component: MailLoginComponent },
  { path: 'perfencesList', component:PerferncesListComponent}, 
  { path: 'download', component:DownloadComponent},
  { path: '**', component: MailLoginComponent },
  {path:'test', component:AddInputEmailComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    MailLoginComponent,
    AboutComponent,
    HelpComponent,
    PreviewDetailsComponent,
    DownloadComponent,
    PerferncesListComponent,
    AddInputEmailComponent
  ],
  imports: [
    BrowserModule,
    MatButtonModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MyMaterialModule,
      MatCheckboxModule,
      HttpModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true }
    )
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
