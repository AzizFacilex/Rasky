using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Rasky.API.IdentityDb;
using Rasky.API.ViewModels;
using Rasky.API.ViewModels.Helpers;
namespace Rasky.API.ViewModels.Mapping {
    public class RideVMtoRides : ITypeConverter<CreateRideViewModel, List<Ride>> {
        public List<Ride> Convert (CreateRideViewModel VM, List<Ride> dest, ResolutionContext context) {
            var toReturn = new List<Ride> ();
            if (VM.Trip.LayoverAddress == null) {
                var Ride = new Ride ();

                Ride.DriverId = VM.userId;
                Ride.FreeSeats = VM.Trip.FreeSeats1;
                Ride.FromAddress.CountryCode = VM.Trip.FromAddress.Address.CountryCode;
                Ride.FromAddress.ExactAddress = VM.Trip.FromAddress.Address.FreeformAddress;
                Ride.FromAddress.Governorate = VM.Trip.FromAddress.Address.CountrySubdivision;
                Ride.FromAddress.Municipality = VM.Trip.FromAddress.Address.Municipality;
                Ride.FromAddress.StreetName = VM.Trip.FromAddress.Address.streetName;
                Ride.FromAddress.Latitude = VM.Trip.FromAddress.Position.Lat;
                Ride.FromAddress.Longitude = VM.Trip.FromAddress.Position.Lon;
                Ride.FromAddress.Country = VM.Trip.FromAddress.Address.Country;

                Ride.ToAddress.CountryCode = VM.Trip.ToAddress.Address.CountryCode;
                Ride.ToAddress.ExactAddress = VM.Trip.ToAddress.Address.FreeformAddress;
                Ride.ToAddress.Governorate = VM.Trip.ToAddress.Address.CountrySubdivision;
                Ride.ToAddress.Municipality = VM.Trip.ToAddress.Address.Municipality;
                Ride.ToAddress.StreetName = VM.Trip.ToAddress.Address.streetName;
                Ride.ToAddress.Latitude = VM.Trip.ToAddress.Position.Lat;
                Ride.ToAddress.Longitude = VM.Trip.ToAddress.Position.Lon;
                Ride.ToAddress.Country = VM.Trip.ToAddress.Address.Country;
                Ride.Departure = new DateTime (VM.Trip.DepartureDate.Year, VM.Trip.DepartureDate.Month, VM.Trip.DepartureDate.Day).AddHours (VM.Trip.DepartureHour).AddMinutes (VM.Trip.departureMinutes);

                toReturn.Add (Ride);
                if (VM.IsRoadTrip) {
                    var temp = Ride.ToAddress;
                    Ride.ToAddress = Ride.FromAddress;
                    Ride.FromAddress = temp;
                    Ride.Departure = new DateTime (VM.Trip.RoadTripDate.Year, VM.Trip.RoadTripDate.Month, VM.Trip.RoadTripDate.Day).AddHours (VM.Trip.RoadTripDepartureHour).AddMinutes (VM.Trip.RoadTripdepartureMinutes);
                    toReturn.Add (Ride);
                }
                return toReturn;
            } else {

                var Ride1 = new Ride ();
                Ride1.DriverId = VM.userId;

                Ride1.FreeSeats = VM.Trip.FreeSeats1;
                Ride1.FromAddress.CountryCode = VM.Trip.FromAddress.Address.CountryCode;
                Ride1.FromAddress.ExactAddress = VM.Trip.FromAddress.Address.FreeformAddress;
                Ride1.FromAddress.Governorate = VM.Trip.FromAddress.Address.CountrySubdivision;
                Ride1.FromAddress.Municipality = VM.Trip.FromAddress.Address.Municipality;
                Ride1.FromAddress.StreetName = VM.Trip.FromAddress.Address.streetName;
                Ride1.FromAddress.Latitude = VM.Trip.FromAddress.Position.Lat;
                Ride1.FromAddress.Longitude = VM.Trip.FromAddress.Position.Lon;
                Ride1.FromAddress.Country = VM.Trip.FromAddress.Address.Country;
                Ride1.ToAddress.CountryCode = VM.Trip.LayoverAddress.Address.CountryCode;
                Ride1.ToAddress.ExactAddress = VM.Trip.LayoverAddress.Address.FreeformAddress;
                Ride1.ToAddress.Governorate = VM.Trip.LayoverAddress.Address.CountrySubdivision;
                Ride1.ToAddress.Municipality = VM.Trip.LayoverAddress.Address.Municipality;
                Ride1.ToAddress.StreetName = VM.Trip.LayoverAddress.Address.streetName;
                Ride1.ToAddress.Latitude = VM.Trip.LayoverAddress.Position.Lat;
                Ride1.ToAddress.Longitude = VM.Trip.LayoverAddress.Position.Lon;
                Ride1.ToAddress.Country = VM.Trip.ToAddress.Address.Country;
                Ride1.Departure = new DateTime (VM.Trip.DepartureDate.Year, VM.Trip.DepartureDate.Month, VM.Trip.DepartureDate.Day).AddHours (VM.Trip.DepartureHour).AddMinutes (VM.Trip.departureMinutes);
                toReturn.Add (Ride1);
                var Ride2 = new Ride ();
                Ride2.DriverId = VM.userId;

                Ride2.FreeSeats = VM.Trip.FreeSeats2;
                Ride2.FromAddress.CountryCode = VM.Trip.LayoverAddress.Address.CountryCode;
                Ride2.FromAddress.ExactAddress = VM.Trip.LayoverAddress.Address.FreeformAddress;
                Ride2.FromAddress.Governorate = VM.Trip.LayoverAddress.Address.CountrySubdivision;
                Ride2.FromAddress.Municipality = VM.Trip.LayoverAddress.Address.Municipality;
                Ride2.FromAddress.StreetName = VM.Trip.LayoverAddress.Address.streetName;
                Ride2.FromAddress.Latitude = VM.Trip.LayoverAddress.Position.Lat;
                Ride2.FromAddress.Longitude = VM.Trip.LayoverAddress.Position.Lon;
                Ride2.FromAddress.Country = VM.Trip.LayoverAddress.Address.Country;
                Ride2.ToAddress.CountryCode = VM.Trip.ToAddress.Address.CountryCode;
                Ride2.ToAddress.ExactAddress = VM.Trip.ToAddress.Address.FreeformAddress;
                Ride2.ToAddress.Governorate = VM.Trip.ToAddress.Address.CountrySubdivision;
                Ride2.ToAddress.Municipality = VM.Trip.ToAddress.Address.Municipality;
                Ride2.ToAddress.StreetName = VM.Trip.ToAddress.Address.streetName;
                Ride2.ToAddress.Latitude = VM.Trip.ToAddress.Position.Lat;
                Ride2.ToAddress.Longitude = VM.Trip.ToAddress.Position.Lon;
                Ride2.ToAddress.Country = VM.Trip.ToAddress.Address.Country;
                Ride2.Departure = new DateTime (VM.Trip.DepartureDate.Year, VM.Trip.DepartureDate.Month, VM.Trip.DepartureDate.Day).AddHours (VM.Trip.DepartureHour).AddMinutes (VM.Trip.departureMinutes);
                toReturn.Add (Ride2);
                if (VM.IsRoadTrip) {
                    var ride3 = new Ride ();
                    ride3.Departure = new DateTime (VM.Trip.RoadTripDate.Year, VM.Trip.RoadTripDate.Month, VM.Trip.RoadTripDate.Day).AddHours (VM.Trip.RoadTripDepartureHour).AddMinutes (VM.Trip.RoadTripdepartureMinutes);
                    ride3.FreeSeats=Ride2.FreeSeats;
                    ride3.FromAddress=Ride2.ToAddress;
                    ride3.ToAddress=Ride2.FromAddress;
                    ride3.DriverId=VM.userId;
                    var ride4 = new Ride ();
                    ride4.Departure = new DateTime (VM.Trip.RoadTripDate.Year, VM.Trip.RoadTripDate.Month, VM.Trip.RoadTripDate.Day).AddHours (VM.Trip.RoadTripDepartureHour).AddMinutes (VM.Trip.RoadTripdepartureMinutes);
                    ride4.FreeSeats=Ride1.FreeSeats;
                    ride4.FromAddress=Ride1.ToAddress;
                    ride4.ToAddress=Ride1.FromAddress;
                    ride4.DriverId=VM.userId;
                    toReturn.Add(ride3);
                    toReturn.Add(ride4);
                    
                }
                return toReturn;
            }

        }
    }

    public class ViewModelToEntityMappingProfile : Profile {

        private readonly IStringLocalizer<PublicProfileViewModel> publicProfileLocalizer;
        private readonly IStringLocalizer<Message> MessageLocalizer;
        public ViewModelToEntityMappingProfile (IStringLocalizer<PublicProfileViewModel> publicProfileLocalizer, IStringLocalizer<Message> messageLocalizer) {
            this.publicProfileLocalizer = publicProfileLocalizer;
            this.MessageLocalizer = messageLocalizer;
            CreateMaps ();

        }
        public void CreateMaps () {
            //mapping Ride creation form to ride
            CreateMap<CreateRideViewModel, List<Ride>> ().ConvertUsing (new RideVMtoRides ());
            //mappimg errors
            CreateMap<IdentityError, Message> ()
                .ForMember (au => au.Identifier, map => map.MapFrom (vm => vm.Code))
                .ForMember (au => au.Description, map => map.MapFrom (vm => MessageLocalizer[vm.Description]));
            //mappin registration form    
            CreateMap<RegisterViewModel, AppUser> ()
                .ForMember (au => au.Email, map => map.MapFrom (vm => vm.emailGroup["email"]))
                .ForMember (au => au.FirstName, map => map.MapFrom (vm => vm.nameGroup["firstName"]))
                .ForMember (au => au.LastName, map => map.MapFrom (vm => vm.nameGroup["lastName"]))
                .ForMember (au => au.UserName, map => map.MapFrom (vm => vm.emailGroup["email"]))
                .ForMember (au => au.PhoneNumber, map => map.MapFrom (vm => vm.phoneNumber))
                .ForMember (au => au.Password, map => map.MapFrom (vm => vm.passwordGroup["password"]));
            //mapping profile  to view  
            CreateMap<UserProfile, PublicProfileViewModel> ()
                .ForMember (au => au.PrefDiscussion, map => map.MapFrom (vm => vm.PrefDiscussion))
                .ForMember (au => au.PrefMusic, map => map.MapFrom (vm => vm.PrefMusic))
                .ForMember (au => au.PrefPet, map => map.MapFrom (vm => vm.PrefPet))
                .ForMember (au => au.PrefSmoke, map => map.MapFrom (vm => vm.PrefSmoke))
                .ForMember (au => au.UserExperience, map => map.MapFrom (vm => vm.Experience))
                .ForMember (au => au.UserImage, map => map.MapFrom (vm => vm.Image))
                .ForMember (au => au.UserSummary, map => map.MapFrom (vm => vm.Summary))
                .ForMember (au => au.UserRides, map => map.MapFrom (vm => vm.Rides))
                .ForMember (au => au.UserRating, map => map.MapFrom (vm => vm.Rating))
                .ForMember (au => au.PrefDiscussionText, map => map.MapFrom (vm => vm.PrefDiscussion? publicProfileLocalizer["PrefDiscussionText"] : publicProfileLocalizer["NoPrefDiscussionText"]))
                .ForMember (au => au.PrefMusicText, map => map.MapFrom (vm => vm.PrefDiscussion? publicProfileLocalizer["PrefMusicText"] : publicProfileLocalizer["NoPrefMusicText"]))
                .ForMember (au => au.PrefPetText, map => map.MapFrom (vm => vm.PrefDiscussion? publicProfileLocalizer["PrefPetText"] : publicProfileLocalizer["NoPrefPetText"]))
                .ForMember (au => au.PrefSmokeText, map => map.MapFrom (vm => vm.PrefDiscussion? publicProfileLocalizer["PrefSmokeText"] : publicProfileLocalizer["NoPrefSmokeText"]))
                .ForMember (au => au.UserFirstName, map => map.Ignore ())
                .ForMember (au => au.UserLastName, map => map.Ignore ())
                .ForMember (au => au.EmailVerified, map => map.Ignore ())
                .ForMember (au => au.MobileVerified, map => map.Ignore ())
                .ForMember (au => au.IdVerified, map => map.Ignore ())
                .ForMember (au => au.MobileVerifiedText, map => map.Ignore ())
                .ForMember (au => au.IdVerifiedText, map => map.Ignore ())
                .ForMember (au => au.EmailVerifiedText, map => map.Ignore ())
                .ForMember (au => au.UserExperienceText, map => map.Ignore ())
                .ForMember (au => au.UserSince, map => map.Ignore ());
            //mapping view to profile    
            CreateMap<AppUser, PublicProfileViewModel> ()
                .ForMember (au => au.UserFirstName, map => map.MapFrom (vm => vm.FirstName))
                .ForMember (au => au.UserLastName, map => map.MapFrom (vm => vm.LastName))
                .ForMember (au => au.EmailVerified, map => map.MapFrom (vm => vm.EmailConfirmed))
                .ForMember (au => au.MobileVerified, map => map.MapFrom (vm => vm.PhoneNumberConfirmed))
                .ForMember (au => au.IdVerified, map => map.MapFrom (vm => vm.IdNumberVerified))
                .ForMember (au => au.MobileVerifiedText, map => map.MapFrom (vm => vm.PhoneNumberConfirmed? publicProfileLocalizer["MobileVerifiedText"] : publicProfileLocalizer["MobileNotVerifiedText"]))
                .ForMember (au => au.IdVerifiedText, map => map.MapFrom (vm => vm.IdNumberVerified? publicProfileLocalizer["IdVerfiedText"] : publicProfileLocalizer["IdNotVerfiedText"]))
                .ForMember (au => au.EmailVerifiedText, map => map.MapFrom (vm => vm.EmailConfirmed? publicProfileLocalizer["EmailVerifiedText"] : publicProfileLocalizer["EmailNotVerifiedText"]))
                .ForMember (au => au.UserExperienceText, map => map.MapFrom (vm => publicProfileLocalizer["UserExperienceText"]))
                .ForMember (au => au.UserSince, map => map.MapFrom (vm => vm.RegistedOn.ToString ("dd/MM/yyyy")))
                .ForMember (au => au.PrefDiscussion, map => map.Ignore ())
                .ForMember (au => au.PrefMusic, map => map.Ignore ())
                .ForMember (au => au.PrefPet, map => map.Ignore ())
                .ForMember (au => au.PrefSmoke, map => map.Ignore ())
                .ForMember (au => au.UserExperience, map => map.Ignore ())
                .ForMember (au => au.UserImage, map => map.Ignore ())
                .ForMember (au => au.UserSummary, map => map.Ignore ())
                .ForMember (au => au.UserRides, map => map.Ignore ())
                .ForMember (au => au.UserRating, map => map.Ignore ())
                .ForMember (au => au.PrefDiscussionText, map => map.Ignore ())

            ;
        }
    }
}