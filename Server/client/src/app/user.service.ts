import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { User } from 'src/Model/user';
import { HttpParams } from '@angular/common/http';


@Injectable()

export class UserService {
  private baseUrl = 'http://localhost:56671/';
  public currentUser: User=new User();

  constructor(private myHttp: HttpClient) {

  }

  login(mail: string, password: string) {
    //const params = new HttpParams()
    //params.set('mail', mail);
    //params.set('password', password);
    return this.myHttp.get(this.baseUrl + 'API/User/Login?mail=' + mail + '&password=' + password);
  }
  
  Register(user: User) {
    return this.myHttp.post(this.baseUrl + 'API/User/Register', user);
  }
  Update(user: User) {
    return this.myHttp.post(this.baseUrl + 'API/User/Update', user);
  }
 


    /**
     * Method is use to download file.
     * @param data - Array Buffer data
     * @param type - type of the document.
     */
   

  downlaod() {
    return this.myHttp.get(this.baseUrl+ 'API/User/downloadProgram',{responseType: 'blob'})
  }
    
   // return this.myHttp.post(this.baseUrl + 'API/User/downloadProgram', {responseType: 'text'})};
//  download(){
//   this.myHttp.get(`${environment.apiUrl}`,{responseType: 'arraybuffer',headers:headers} )
//   .subscribe(response => this.downLoadFile(response, "application/ms-excel"));
//  }

//     /**
//      * Method is use to download file.
//      * @param data - Array Buffer data
//      * @param type - type of the document.
//      */
//     downLoadFile(data: any, type: string) {
//       let blob = new Blob([data], { type: type});
//       let url = window.URL.createObjectURL(blob);
//       let pwa = window.open(url);
//       if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
//           alert( 'Please disable your Pop-up blocker and try again.');
//       }
//   }

  public getPDF(): Observable<Blob> {   
    //const options = { responseType: 'blob' }; there is no use of this
        let uri = 'Y:/group 2 תשעט/קציר שרי/Server/BLL/System_file/ConsoleApp2.exe.config';
        // this.http refers to HttpClient. Note here that you cannot use the generic get<Blob> as it does not compile: instead you "choose" the appropriate API in this way.
        return this.myHttp.get(uri, { responseType: 'blob' });
    }

    public downloadReport(file): Observable<any> {
      // Create url
      let url = `${this.baseUrl}${"/experiment/resultML/downloadReport"}`;
      var body = { filename: file };
  
      return this.myHttp.post(url, body, {
        responseType: "blob",
        headers: new HttpHeaders().append("Content-Type", "application/json")
      });
    }

  // http.get('Some Url')
  // .map(res => res.json())
  // .subscribe(
  //   (data) => this.data = data,
  //   (err) => this.error = err); // Reach here if fails

}
