using System.ComponentModel.DataAnnotations;
namespace SmartParkingAdmin.Models;
public sealed class UserAccount { public Guid Id {get;set;} public string FullName {get;set;} = ""; public string Email {get;set;} = ""; public string Role {get;set;} = "Driver"; public bool IsActive {get;set;} = true; }
public sealed class ParkingPrice { public Guid Id {get;set;} [Required] public string FacilityName {get;set;} = ""; [Range(0,100000)] public decimal PricePerHour {get;set;} [Required, StringLength(3,MinimumLength=3)] public string Currency {get;set;} = "DKK"; }
public sealed class ParkingSpot { public Guid Id {get;set;} [Required] public string FacilityName {get;set;} = ""; [Required] public string SpotNumber {get;set;} = ""; public string Status {get;set;} = "Available"; public bool IsAccessible {get;set;} }
