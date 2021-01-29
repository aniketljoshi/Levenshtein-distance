import * as endpoints from 'src/app/configs/constants/api.endpoints';

import { HttpClient, HttpHeaders} from '@angular/common/http';

import {CompareStringRequest} from '../../shared/models/string-compare-model'
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CompareService {

  headers: HttpHeaders;

  constructor(private _http: HttpClient) { }

  compareDistane(request: CompareStringRequest) {
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Authorization', 'Bearer eyJraWQiOiJLbWpcL2ppZ3lVODhuU2ZqZ1JuaUVFTjFZSGhyb1wvV0pkbFZqYmdidkZZQnM9IiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiJhNTlmNjljMy03YWVlLTRjZGQtYWVmZC1hZGFlZDE4NGI4ODYiLCJldmVudF9pZCI6IjU2ZjI1MmI2LWE4ODYtNDk0ZC05MGI4LTA0YTRiYjFiZWQ0NiIsInRva2VuX3VzZSI6ImFjY2VzcyIsInNjb3BlIjoiYXdzLmNvZ25pdG8uc2lnbmluLnVzZXIuYWRtaW4iLCJhdXRoX3RpbWUiOjE2MTE5MzkyMDcsImlzcyI6Imh0dHBzOlwvXC9jb2duaXRvLWlkcC51cy1lYXN0LTEuYW1hem9uYXdzLmNvbVwvdXMtZWFzdC0xXzl0WEZPbnEwbyIsImV4cCI6MTYxMTk0MjgwNywiaWF0IjoxNjExOTM5MjA3LCJqdGkiOiIyZjRlNGIzYy01YmMyLTQ5MDYtYThlMi03YjI4YzFiYzgwMWMiLCJjbGllbnRfaWQiOiIyMzRkYzJvcWxnbDVlajE0aTUzOHZlcTI0IiwidXNlcm5hbWUiOiJjcnlwdG9fYXBpX2FwcCJ9.XdiRsvrVH2sfVVOcA0LWAj7oc4mEjq6n54uRvxbvslcP175PWRSfejkI_QxauZhpDx7n09AzCVonmnTMdDlYxuaJNJMvGn_QUsTurXMaExFLKF7rzR3AEeqTFXDZRKg1Xss150vHyMflhI6sWVNNnkNTNKlZXVj580XsmiPOhyIychknXGgwHB-v8moQt5apcBXn7FDpLzCEN7nBtwEhk2N_rCcV0u9-BKXZa83QMSXtckJp8m-XbVjNJaiaTJNS_8DYxWi9LiYRBzLcebHWh5E1D3sZ7KLY8jGz2Ubgeqm4VkD6l-GV9luED0voFU1SoMoKX3twPKlxhba__Em7bg');
    let endpoint = endpoints.compareDistane();
    return this._http.post(endpoint, request, { headers: this.headers });
  }
}
