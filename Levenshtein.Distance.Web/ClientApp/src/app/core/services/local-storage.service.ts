import * as CryptoJS from 'crypto-js';

import { BehaviorSubject, Subject } from 'rxjs';

import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  localStorage: Storage;

  changes$ = new Subject();

  selectedUserSource = new BehaviorSubject<any>(false);
  selectedUser$ = this.selectedUserSource.asObservable();

  constructor() {
    this.localStorage = window.localStorage;
  }

  get(key: string): any {
    if (this.isLocalStorageSupported && this.localStorage.length) {
      let item = this.localStorage.getItem(key);
      item = this.decryptUsingAES256(item);
      return JSON.parse(item);
    }

    return null;
  }

  set(key: string, value: any): boolean {
    if (this.isLocalStorageSupported) {
      let val = this.encryptUsingAES256(value);
      this.localStorage.setItem(key, val);
      this.changes$.next({
        type: 'set',
        key,
        value
      });
      return true;
    }

    return false;
  }

  remove(key: string): boolean {
    if (this.isLocalStorageSupported) {
      this.localStorage.removeItem(key);
      this.changes$.next({
        type: 'remove',
        key
      });
      return true;
    }

    return false;
  }

  clear() {
    this.localStorage.clear();
  }

  get isLocalStorageSupported(): boolean {
    return !!this.localStorage
  }
  encryptUsingAES256
    (data) {
    let _key = CryptoJS.enc.Utf8.parse(environment.SECRET_KEY);
    let _iv = CryptoJS.enc.Utf8.parse(environment.SECRET_KEY);
    let encrypted = CryptoJS.AES.encrypt(
      JSON.stringify(data), _key, {
      keySize: 16,
      iv: _iv,
      mode: CryptoJS.mode.ECB,
      padding: CryptoJS.pad.Pkcs7
    });
    return encrypted.toString();
  }

  decryptUsingAES256(data) {
    let _key = CryptoJS.enc.Utf8.parse(environment.SECRET_KEY);
    let _iv = CryptoJS.enc.Utf8.parse(environment.SECRET_KEY);

    let decrypted = CryptoJS.AES.decrypt(
      data, _key, {
      keySize: 16,
      iv: _iv,
      mode: CryptoJS.mode.ECB,
      padding: CryptoJS.pad.Pkcs7
    }).toString(CryptoJS.enc.Utf8);

    return decrypted;
  }
}