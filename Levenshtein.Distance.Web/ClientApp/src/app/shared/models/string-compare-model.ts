export class CompareStringRequest {
    firstSting: string;
    secondString: string;
  
    constructor(compareStringRequest?: CompareStringRequest) {
      this.firstSting = compareStringRequest && compareStringRequest.firstSting ? compareStringRequest.firstSting : null;
      this.secondString = compareStringRequest && compareStringRequest.secondString ? compareStringRequest.secondString : null;
    }
  }