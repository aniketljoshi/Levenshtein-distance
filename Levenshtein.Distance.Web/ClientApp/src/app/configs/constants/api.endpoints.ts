import { environment } from 'src/environments/environment';

let base_url = environment.BASE_URL;

export const compareDistane = ()=> base_url + '/Compare/distance' ;