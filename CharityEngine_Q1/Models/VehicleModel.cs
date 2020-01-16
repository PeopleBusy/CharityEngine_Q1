using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharityEngine_Q1.Models
{
    public class VehicleModel
    {
        [Display(Name = "Registration number")]
        [Required(ErrorMessage = "Vehicle's registration number is required.")]
        public int VehiceRegistrationNumber { get; set; }// I supposed that registration number is the primary key

        [Display(Name = "Owner's name")]
        [Required(ErrorMessage = "Owner's name is required.")]
        public string OwnerName { get; set; }

        [Display(Name = "Owner's phone number")]
        [Required(ErrorMessage = "Owner's phone number is required.")]
        public int OwnerPhoneNumber { get; set; }

        [Display(Name = "Owner's unit number")]
        [Required(ErrorMessage = "Owner's unit number is required.")]
        public string OwnerUnitNumber { get; set; }

        [Display(Name = "Owner's appartment number")]
        [Required(ErrorMessage = "Owner's appartment number is required.")]
        public string OwnerAppartementNumber { get; set; }

        [Display(Name = "Vehicle's make")]
        [Required(ErrorMessage = "Vehicle's make is required.")]
        public string VehiceMake { get; set; }

        [Display(Name = "Vehicle's model")]
        [Required(ErrorMessage = "Vehicle's model is required.")]
        public string VehiceModel { get; set; }

        [Display(Name = "Vehicle's color")]
        [Required(ErrorMessage = "Vehicle's color is required.")]
        public string VehiceColor { get; set; }

        [Display(Name = "Registration date")]
        [Required(ErrorMessage = "Registration date is required.")]
        public DateTime RegistrationDate { get; set; }

    }
}