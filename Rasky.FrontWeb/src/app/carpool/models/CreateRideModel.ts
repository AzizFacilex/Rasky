

export class CreateRideModel {
    constructor()
    {
      this.isRoadTrip=false;
      this.Trip=new Trip(new Date());
      this.minDate=new Date().toISOString();
    }

    Trip:Trip;
    isRoadTrip:boolean;
    userId:string;
    maxSeats:number;
    minSeats=1;
    minDate;
    maxDate;
}
export class Trip
{
  constructor(date:Date)
  {
    this.departureDate=date.toISOString();
    this.toAddress
    this.fromAddress
    this.layoverAddress
  }
    fromAddress:Result
    layoverAddress:Result
    toAddress:Result

    departureDate:string;
    RoadTripDate?:string;
    departureHour:number;
    departureMinutes:number;
    roadTripDepartureHour:number;
    roadTripDepartureMinutes:number
    freeSeats1:number=3;
    freeSeats2:number=3;

}
export class Result{
  constructor(s:string){
    this.address
    this.position
  }
    type:string;
    id:string;
    score:number;
    info;
    address:Address;
    position:Position;
    poi:Poi;
}
export class Poi{
    name:string;
}
export class Position{
    lat:number;
    lon:number;
}
export class Address {
    country:string
    countryCode:string;
    countryCodeISO3:string;
    countrySubdivision: string;
    freeformAddress:string;
    municipality:string;
    municipalitySubdivision:string;
    //in backend search for, in order:
    //1-free form address
    //2- muni subdivision
    //3- muni
}

`
{
    "isRoadTrip": false,
    "mainTrip": {
      "fromAddress": {
        "type": "POI",
        "id": "TN/POI/p0/41688",
        "score": 2.124,
        "info": "search:ta:788009000108637-TN",
        "poi": {
          "name": "Bab Saadoun",
          "categorySet": [
            {
              "id": 7376003
            }
          ],
          "categories": [
            "important tourist attraction",
            "monument"
          ],
          "classifications": [
            {
              "code": "IMPORTANT_TOURIST_ATTRACTION",
              "names": [
                {
                  "nameLocale": "en-US",
                  "name": "monument"
                },
                {
                  "nameLocale": "en-US",
                  "name": "important tourist attraction"
                }
              ]
            }
          ]
        },
        "address": {
          "streetName": "Place Bab Saadoun",
          "municipalitySubdivision": "Tunis Ville, El Omrane",
          "municipality": "Tunis",
          "countrySubdivision": "Tunis",
          "countryCode": "TN",
          "country": "Tunisia",
          "countryCodeISO3": "TUN",
          "freeformAddress": "Place Bab Saadoun, El Omrane, Tunis"
        },
        "position": {
          "lat": 36.8086,
          "lon": 10.15901
        },
        "viewport": {
          "topLeftPoint": {
            "lat": 36.8095,
            "lon": 10.15789
          },
          "btmRightPoint": {
            "lat": 36.8077,
            "lon": 10.16013
          }
        },
        "entryPoints": [
          {
            "type": "main",
            "position": {
              "lat": 36.80856,
              "lon": 10.15923
            }
          }
        ]
      }
    },
    "layoverTrips": []
  }
`