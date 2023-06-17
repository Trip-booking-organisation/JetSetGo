import {Component, OnInit} from '@angular/core';
import {FormControl, Validators} from "@angular/forms";
import {ApiKeyService} from "../../shared/services/api-key.service";
import {ApiKeyRequest} from "../../shared/model/ApiKeyRequest";
import {AutentificationService} from "../../shared/services/autentificationService";
import {TokenStorageService} from "../../shared/services/tokenStorage.service";
import {MatDialog, MatDialogRef} from "@angular/material/dialog";
import {CopyApiKeyComponent} from "../copi-api-key/copy-api-key.component";

@Component({
  selector: 'app-generet-api-key',
  templateUrl: './generate-api-key.component.html',
  styleUrls: ['./generate-api-key.component.scss']
})
export class GenerateApiKeyComponent implements OnInit{
  apikeyName = new FormControl('',Validators.required);
  expiration = new FormControl('false',Validators.required);
  constructor(private apiKeyClient : ApiKeyService,
              private dialogRef : MatDialogRef<ApiKeyService>,
              private dialog : MatDialog,
              private tokenStorage: TokenStorageService ) {
  }
  ngOnInit(): void {
  }
  getExpirationValue() {
    if(this.expiration.value as string === 'true')
      return true
    return false;
  }
  onGenerate() {
    let user = this.tokenStorage.getUser();



    if (this.apikeyName.valid && this.expiration.valid) {
      console.log(this.apikeyName.value)
      let request: ApiKeyRequest = {
        name: this.apikeyName.value as string,
        id: user.id,
        expiration: this.getExpirationValue()
      }
      console.log(request)
      this.apiKeyClient.generateApiKey(request).subscribe({
        next: response => {
          console.log(response.token)
          let apiKey = response.token as string
          console.log(apiKey)
          this.dialogRef.close()
          this.dialog.open(CopyApiKeyComponent,{
            width: '600px',
            data: {apiKey : apiKey},
          })
        }
      })
    }
  }
}
