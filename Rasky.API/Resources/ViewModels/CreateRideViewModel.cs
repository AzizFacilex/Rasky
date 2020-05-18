using System;
using System.Collections.Generic;
using Rasky.API.ViewModels.Helpers;
namespace Rasky.API.ViewModels {
    public class CreateRideViewModel : BaseViewModel {
        public bool IsRoadTrip { get; set; }
        public Trip Trip { get; set; }
        public string userId{get;set;}

    }
    public class Trip {
        public DateTime DepartureDate { get; set; }
        public byte DepartureHour { get; set; }
        public byte departureMinutes { get; set; }
        public DateTime RoadTripDate { get; set; }
        public byte RoadTripDepartureHour { get; set; }
        public byte RoadTripdepartureMinutes { get; set; }
        public int FreeSeats1 { get; set; }
        public int FreeSeats2 { get; set; }
        public FullAddress FromAddress { get; set; }
        public FullAddress ToAddress { get; set; }
        public FullAddress LayoverAddress { get; set; }
    }
    public class FullAddress {
        public string Info { get; set; }
        public Address Address { get; set; }
        public Position Position { get; set; }

    }
    public class Address {

        public string MunicipalitySubdivision { get; set; }
        public string Municipality { get; set; }
        public string CountrySubdivision { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string CountryCodeISO3 { get; set; }
        public string FreeformAddress { get; set; }
        public string streetName { get; set; }

    }
    public class Position {
        public float Lat { get; set; }
        public float Lon { get; set; }
    }
}
// "isRoadTrip": false,
//   "Trip": {
//     "departureDate": "2019-05-06T22:00:00.000Z",
//     "freeSeats1": 2,
//     "freeSeats2": 0,
//     "fromAddress": {
//       "type": "POI",
//       "id": "TN/POI/p0/16115",
//       "score": 2.004,
//       "info": "search:ta:788009000137534-TN",
//       "poi": {
//         "name": "Café Ali Baba",
//         "categorySet": [
//           {
//             "id": 9376002
//           }
//         ],
//         "categories": [
//           "café",
//           "café/pub"
//         ],
//         "classifications": [
//           {
//             "code": "CAFE_PUB",
//             "names": [
//               {
//                 "nameLocale": "en-US",
//                 "name": "café"
//               },
//               {
//                 "nameLocale": "en-US",
//                 "name": "café/pub"
//               }
//             ]
//           }
//         ]
//       },
//       "address": {
//         "streetName": "Rue Hassine Khouja",
//         "municipalitySubdivision": "Tunis Ville",
//         "municipality": "Tunis",
//         "countrySubdivision": "Tunis",
//         "countryCode": "TN",
//         "country": "Tunisia",
//         "countryCodeISO3": "TUN",
//         "freeformAddress": "Rue Hassine Khouja, El Kabbaria, Tunis"
//       },
//       "position": {
//         "lat": 36.75493,
//         "lon": 10.19633
//       },
//       "viewport": {
//         "topLeftPoint": {
//           "lat": 36.75583,
//           "lon": 10.19521
//         },
//         "btmRightPoint": {
//           "lat": 36.75403,
//           "lon": 10.19745
//         }
//       },
//       "entryPoints": [
//         {
//           "type": "main",
//           "position": {
//             "lat": 36.75481,
//             "lon": 10.19646
//           }
//         }
//       ]
//     },
//     "toAddress": {
//       "type": "POI",
//       "id": "TN/POI/p0/67069",
//       "score": 2.044,
//       "info": "search:ta:788009000039708-TN",
//       "poi": {
//         "name": "Aéroport International Sfax Thyna",
//         "categorySet": [
//           {
//             "id": 7383002
//           }
//         ],
//         "categories": [
//           "airport",
//           "public authority"
//         ],
//         "classifications": [
//           {
//             "code": "AIRPORT",
//             "names": [
//               {
//                 "nameLocale": "en-US",
//                 "name": "airport"
//               },
//               {
//                 "nameLocale": "en-US",
//                 "name": "public authority"
//               }
//             ]
//           }
//         ]
//       },
//       "address": {
//         "municipalitySubdivision": "Tina",
//         "municipality": "Tina",
//         "countrySubdivision": "Sfax",
//         "countryCode": "TN",
//         "country": "Tunisia",
//         "countryCodeISO3": "TUN",
//         "freeformAddress": "Tina, Sfax"
//       },
//       "position": {
//         "lat": 34.72467,
//         "lon": 10.68894
//       },
//       "viewport": {
//         "topLeftPoint": {
//           "lat": 34.72557,
//           "lon": 10.68785
//         },
//         "btmRightPoint": {
//           "lat": 34.72377,
//           "lon": 10.69003
//         }
//       },
//       "entryPoints": [
//         {
//           "type": "main",
//           "position": {
//             "lat": 34.72505,
//             "lon": 10.68914
//           }
//         }
//       ],
//       "dataSources": {
//         "geometry": {
//           "id": "00005455-4e00-3c00-0000-000059682f2f"
//         }
//       }
//     },
//     "departureHour": "01",
//     "departureMinutes": "30"
//   }