import { Component, OnInit, ViewChild } from '@angular/core';
import { MapService, MapResult } from '../services/map.service'
import { FormBuilder, FormGroup, Validators, FormArray, NgForm, NgModel } from '@angular/forms';
import { debounceTime, switchMap, distinctUntilChanged, mergeMap, map } from 'rxjs/operators';
import { Observable, Subscribable, Subscription, BehaviorSubject } from 'rxjs';
import { TemplateParseResult } from '@angular/compiler';
import { CreateRideModel, Trip, Result, Position, } from '../models/CreateRideModel';
import { } from 'rxjs/operators';
import { CarpoolService } from '../services/carpool.service';
import { User } from 'src/app/account/_models';
import { AuthenticationService } from 'src/app/account/_services';
declare let L;
declare let tomtom: any;
@Component({
  selector: 'app-create-ride',
  templateUrl: './create-ride.component.html',
  styleUrls: ['./create-ride.component.scss']
})
export class CreateRideComponent implements OnInit {
  @ViewChild("createForm") createForm: NgForm;
  map: any;
  routeOnMapView: any;
  routeSummaryInstance: any;
  createRide: CreateRideModel = new CreateRideModel();
  createRideResponse = new CreateRideModel();
  currentUser: User;
  date: Date;
  points: any[] = [];
  subTrip1Seats: number = 0;
  constructor(private mapService: MapService,
    private carpoolService: CarpoolService, private authenticationService: AuthenticationService) {
  }
  incrementSeats1() {
    if (this.createRide.Trip.freeSeats1 === 3) {
      return;
    }
    this.createRide.Trip.freeSeats1++;
  }
  decrementSeats1() {
    if (this.createRide.Trip.freeSeats1 === 0) {
      return;
    }
    this.createRide.Trip.freeSeats1--;
  }
  incrementSeats2() {
    if (this.createRide.Trip.freeSeats2 === 3) {
      return;
    }
    this.createRide.Trip.freeSeats2++;
  }
  decrementSeats2() {
    if (this.createRide.Trip.freeSeats2 === 0) {
      return;
    }
    this.createRide.Trip.freeSeats2--;

  }
  subTrip2Seats: number;
  fromfilterdAddresse: MapResult;
  layover: MapResult;
  tofilterdAddresse: MapResult;
  minutes = ['00', '15', '30', '45']
  hours = ['00', '01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23'];

  private getData(value: any): Observable<any> {
    return this.mapService.getTest(value);
  }


  displayFn(c?: any): string | undefined {
    return (c && c.poi && c.address.municipalitySubdivision) ? `${c.poi.name},  ${c.address.municipalitySubdivision}` : undefined;
  }

  checkFromAddress() {

    if (!this.createRide.Trip.fromAddress || !this.fromfilterdAddresse.results.some(x => x == this.createRide.Trip.fromAddress)) {
      this.createRide.Trip.fromAddress = null;
      this.createForm.form.controls['fromAddress'].setErrors({ 'notInList': true, 'required': true });
      console.log(this.createForm)
      // this.createForm.form.controls['fromAddress'].setErrors({'notInList':true});

    }


  }

  onFromSelected(value: Result) {
    if (this.points.length == 3) {
      this.points.splice(0, 1, value.position)

    } else {
      this.points.splice(0, 0, value.position)

    }
    this.routeOnMapView.LocationsFound = this.points;
    this.routeOnMapView.draw(this.routeOnMapView.LocationsFound);
    console.log(this.routeOnMapView)
    // this.routeSummaryInstance.updateSummaryData(this.routeOnMapView.);
  }
  onFromCleared() {
    this.createRide.Trip.fromAddress = null;
    this.createRide.Trip.toAddress=null;
    this.createRide.Trip.layoverAddress=null;
    this.points.length = 0;
    this.routeOnMapView.draw(this.points)
  }
  setRoadTripDate() {
    console.log("im ere")
    this.createRide.Trip.RoadTripDate = this.createRide.Trip.departureDate
  }
  getCurrentModel() {
    return JSON.stringify(this.createRide)
  }
  checkToAddress() {

    if (!this.createRide.Trip.toAddress || !this.tofilterdAddresse.results.some(x => x == this.createRide.Trip.toAddress)) {
      this.createRide.Trip.toAddress = null;
      this.createForm.form.controls['toAddress'].setErrors({ 'notInList': true, 'required': true });


    }

  }
  onToSelected(value: Result) {
    if (this.points.length == 3) {
      this.points.splice(1, 1, value.position)

    } else {
      this.points.splice(1, 0, value.position)

    }
    // this.routeOnMapView.draw(this.points);
    // console.log(this.routeOnMapView.Events.RouteChanged);
    this.routeOnMapView.LocationsFound = this.points;
    this.routeOnMapView.draw(this.routeOnMapView.LocationsFound);
    console.log(this.routeOnMapView)

  }
  onToCleared() {

    this.createRide.Trip.toAddress = null;
    this.createRide.Trip.layoverAddress = null;
    this.points.splice(1, 1);
    if (this.points.length == 2) {
      this.points.splice(1, 1)
    }
    if(this.points.length===3){
      this.points.splice(1,1)
      this.points.splice(1,1)
    }
    this.routeOnMapView.draw(this.points)
  }
  checkLayoverAddress() {
    if (!this.createRide.Trip.layoverAddress || !this.layover.results.some(x => x == this.createRide.Trip.layoverAddress)) {
      this.createRide.Trip.layoverAddress = null;
      this.createForm.form.controls['layoverAddress'].setErrors({ 'notInList': true });


    }
  }
  onLayoverSelected(value: Result) {
    if (this.points.length == 3) {
      this.points.splice(2, 1, value.position)

    } else {
      this.points.splice(2, 0, value.position)

    }
    this.routeOnMapView.LocationsFound = this.points;
    this.routeOnMapView.draw(this.routeOnMapView.LocationsFound);
    console.log(this.routeOnMapView)
    // this.routeOnMapView.draw(this.points)
  }
  onLayoverCleared() {
    this.createRide.Trip.layoverAddress = null;
    this.points.splice(2, 1);
    this.routeOnMapView.draw(this.points)
  }
  FromSubscription: Subscription;
  onFromChanged(value) {
    if (this.FromSubscription) {
      this.FromSubscription.unsubscribe();
    }
    if (value.length > 2) {
      this.FromSubscription = this.getData(value).pipe(
        debounceTime(1500)
      ).subscribe((res: MapResult) => {
        this.fromfilterdAddresse = res
      })
    }

  }
  ToSubscription: Subscription;
  onToChanged(value) {
    if (this.ToSubscription) {
      this.ToSubscription.unsubscribe();
    }
    if (value.length > 2) {
      this.ToSubscription = this.getData(value).pipe(
        debounceTime(1500)
      ).subscribe((res: MapResult) => {
        this.tofilterdAddresse = res
      });
    }

  }
  LayoversSubscription: Subscription;
  onLayoverChange(value: string) {
    if (this.LayoversSubscription) {
      this.LayoversSubscription.unsubscribe();
    }

    if (value.length > 2) {
      this.LayoversSubscription = this.getData(value).pipe(
        debounceTime(1500)
      ).subscribe((res: MapResult) => {
        this.layover = res

      })
    }
  }
  submitForm() {
    this.createRide.userId = this.currentUser.id
    this.carpoolService.createRide(this.createRide).subscribe(res => {
      this.createRideResponse = res;
    })
  }
  ngOnInit() {
    this.createRide = new CreateRideModel();
    console.log(this.createRide.Trip.departureDate);
    this.authenticationService.currentUser.subscribe(
      user => {
        this.currentUser = user;
      }
    );
    tomtom.routingKey('gq3RXmBZ8mAopiD2QIPSmynhn7Jmq2X6');
    tomtom.searchKey('gq3RXmBZ8mAopiD2QIPSmynhn7Jmq2X6');
    this.map = tomtom.L.map('map', {
      key: 'gq3RXmBZ8mAopiD2QIPSmynhn7Jmq2X6',
      basePath: '/assets/map-sdk',
      countrySet: 'TN',
      center: [34.695138, 9.734099],
      zoom: 5,
      source: 'raster'
    });
    this.map.zoomControl.setPosition('topright');
    this.routeOnMapView = tomtom.routeOnMap().addTo(this.map);
    // var routeSummaryInstance = tomtom.routeSummary({
    //   size: [400, 300],

    // }).addTo(this.map);
    //  this.routeOnMapView.on(this.routeOnMapView.Events.RouteChanged, function (eventObject) {
    //  routeSummaryInstance.updateSummaryData(eventObject.object);
    //  console.log(routeSummaryInstance);
    // });
    // routeInputs.on(routeInputs.Events.LocationsFound, function (eventObject) {
    //   console.log(eventObject.points);
    //   this.routeOnMapView.draw(eventObject.points);
    // });
    // routeInputs.on(this.createRide.Trip.toAddress, function (eventObject) {
    //   this.routeOnMapView.draw(eventObject.points);
    // });
  }
}
