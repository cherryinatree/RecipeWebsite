using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _8_1_TripLog.Models
{
    public class Trips
    {

        public int TripsId { get; set; }
        [Required(ErrorMessage = "Please enter a Destination.")]
        public string Destination { get; set; } = string.Empty!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Accommodation { get; set; }
        public string? AccommodationPhone { get; set; }
        public string? AccommodationEmail { get; set; }
        [Required(ErrorMessage = "Please enter an activity.")]
        public string ThingToDo1 { get; set; } = string.Empty!;
        [Required(ErrorMessage = "Please enter an activity.")]
        public string ThingToDo2 { get; set; } = string.Empty!;
        [Required(ErrorMessage = "Please enter an activity.")]
        public string ThingToDo3 { get; set; } = string.Empty!;
    }
}
