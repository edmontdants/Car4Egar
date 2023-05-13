import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { CarService } from 'src/app/car/Services/car.service';

@Component({
  selector: 'app-profile-pic',
  templateUrl: './profile-pic.component.html',
  styleUrls: ['./profile-pic.component.scss'],
})
export class ProfilePicComponent {

  @Input() UserImg:string='';
  ngOnInit(){
    this.NID = String(sessionStorage.getItem('userNID'));
  }


  onChangeFile(event: any) {

    if(event.target.files.length > 0) {
      const file = event.target.files[0];
      this.uploadPicture(this.NID , event.target.files[0].name);
      if(file.type == 'image/png' || file.type == 'image/jpeg') {
        const formData = new FormData();
        formData.append('file',file);

        this.http.post('https://localhost:7136/Admin/UploadPictureAndSave',formData).subscribe((res: any)=> {

        });

      } else {
        alert('Pease select only jpeg and png');
      }
    }
  }

  private baseUrl3 = 'https://localhost:7136';
  public async uploadPicture(NID:string, filename:string) {
    const url = `${this.baseUrl3}/Admin/UploadPicture`;
    // const body = {NID ,base64String, filename };
    const headers = new HttpHeaders({
      'NID': NID,
      'Filename': filename
    });
    const res = await this.http.put(url,null ,{ headers }).toPromise();
    console.log("Done!");
    alert('Profile Logo Updated Successfully!'); location.reload();
    return res;
  }


  file: string = '';
  onFileChange(event: any) {
    const files = event.target.files as FileList;

    if (files.length > 0) {
      const _file = URL.createObjectURL(files[0]);
      this.file = _file;
      this.resetInput();
    }
  }

NID:string='';
constructor(private http : HttpClient,public service:CarService) {
  this.NID = String(sessionStorage.getItem('userNID'));
}




  resetInput() {
    const input = document.getElementById(
      'avatar-input-file'
    ) as HTMLInputElement;
    if (input) {
      input.value = '';
    }
  }
}
