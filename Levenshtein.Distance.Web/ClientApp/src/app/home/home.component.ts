import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CompareService } from '../core/services/compare.service';
import { CompareStringRequest } from '../shared/models/string-compare-model';
import { AppResources } from '../configs/resource/app-resources';
import { Name_Prop_Regex } from '../configs/constants/regex';
import { LocalStorageService } from '../core/services/local-storage.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  translation = AppResources;
  submitted = false;
  form: FormGroup;
  validationMessages: any;
  @Input() public modelData: any;
  compareStringRequest : CompareStringRequest
  finalDistance = null;
  output = null;
  
  constructor(private fb: FormBuilder,
    private _compareService: CompareService,
    private _localStorageService: LocalStorageService) {
      this.validationMessages = this.translation.common.validationMessages;
    }

    ngOnInit(): void {
      this.createForm();
    }
  
    createForm() {
      this.form = this.fb.group({
        firstString: ['', [Validators.required, Validators.pattern(Name_Prop_Regex)]],
        secondString: ['', Validators.required]
      });
    }
  
    get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }
    let compareStringRequest = this.form.getRawValue();
      this._compareService.compareDistane(compareStringRequest).subscribe(result => {
        this._localStorageService.set('result', window.btoa(JSON.stringify(result)));
        this.finalDistance = result["outPut"];
        this.output = this.getMatrix(compareStringRequest.firstString, compareStringRequest.secondString);
      });
  }

  getMatrix(a: any, b: any) {
    let finalresult = {
      matrix: null,
      firstString: [""],
      secondString: [""],
      distance: null
    };
    if (a.length == 0) return b.length;
    if (b.length == 0) return a.length;
 
    var matrix = [];
 
    // increment along the first column of each row
    var i;
    for (i = 0; i <= b.length; i++) {
      matrix[i] = [i];
      finalresult.secondString.push(b[i]);
    }
    var j;
    for (j = 0; j <= a.length; j++) {
      matrix[0][j] = j;
      finalresult.firstString.push(a[j]);
    }
 
    // Fill in the rest of the matrix
    for (i = 1; i <= b.length; i++) {
      for (j = 1; j <= a.length; j++) {
        if (b.charAt(i - 1) == a.charAt(j - 1)) {
          matrix[i][j] = matrix[i - 1][j - 1];
        } else {
          matrix[i][j] = Math.min(
            matrix[i - 1][j - 1] + 1, // substitution
            Math.min(
              matrix[i][j - 1] + 1, // insertion
              matrix[i - 1][j] + 1
            )
          ); // deletion
        }
      }
    }
 
    finalresult.matrix = matrix;
    finalresult.distance = matrix[b.length][a.length];
 
    return finalresult;
  }
}
