import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { _MatInkBarPositioner } from '@angular/material';
import { Result } from '../models/CreateRideModel';


@Injectable({
  providedIn: 'root'
})
export class MapService {

  constructor(private httpClient:HttpClient) 
  {

  }
  //example search in tomtom map
  getTest(query:any){
    console.log('test = '+JSON.stringify(query))
    return this.httpClient.get<MapResult>(`https://api.tomtom.com/search/2/poiSearch/${query}.json?key=gq3RXmBZ8mAopiD2QIPSmynhn7Jmq2X6&countrySet=TN&[minFuzzyLevel=4]`);

  }
  calculateRoutes(query){
    return `https://api.tomtom.com/routing/1/calculateRoute/${query}/json?key=gq3RXmBZ8mAopiD2QIPSmynhn7Jmq2X6`
  }

}

export interface MapResult
{
  summary:Summary;
  results:Result[];
}
// export class TestResult{
//   position:Position;
//   address:Address={
//     country:'',
//     countryCode:'',
//     countryCodeIS03:'',
//     countrySubdivision:'',
//     freeformAddress:'',
//     municipality:''
//   };
//   poi:POI={
//     name:''
//   }

// }
// export interface Position{
//   lat:string;
//   lon:string;
//   score:string

// }
export interface Summary
{
  fuzzyLevel:number;
  numResults:number;
  offset:number;
  query:string;
  queryTime:string;
  totalResults:number;
  queryType:string;
}
// export class Address{
//   country:string='';
//   countryCode:string='';
//   countryCodeIS03:string='';
//   countrySubdivision:string='';
//   freeformAddress:string='';
//   municipality:string='';
// }
// export class POI
// {
//   name:string;
// }
