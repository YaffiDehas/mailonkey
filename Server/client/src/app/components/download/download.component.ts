import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user.service';
@Component({
  selector: 'app-download',
  templateUrl: './download.component.html',
  styleUrls: ['./download.component.css']
})
export class DownloadComponent implements OnInit {

  constructor(private UserService: UserService) { }

  ngOnInit() {
  }
  download() {
    this.UserService.downlaod().subscribe(response => this.downLoadFile(response, "application/octet-stream"));
  }

  downLoadFile(data: any, type: string) {

    let blob = new Blob([data], { type: type});
    let url = window.URL.createObjectURL(blob);
    let pwa = window.open(url);

    if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
        alert( 'Please disable your Pop-up blocker and try again.');
    }
    

    //let thefile = {};
    //this.pservice.downloadfile(this.rundata.name, type)
     //   .subscribe(data => thefile = new Blob([data], { type: "application/octet-stream" }), //console.log(data),
     //               error => console.log("Error downloading the file."),
     //               () => console.log('Completed file download.'));
//
    //let url = window.URL.createObjectURL(thefile);
    //window.open(url);



    // let blob = new Blob([data], { type: type});
    // let url =window.URL.createObjectURL(blob);
    // // if (filename) new Blob(data, {type: type})
    // //     downloadLink.setAttribute('download', filename);
    // // document.body.appendChild(downloadLink);
    // let pwa = window.open(url);

    // if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
    //     alert( 'Please disable your Pop-up blocker and try again.');
    // }
}
}