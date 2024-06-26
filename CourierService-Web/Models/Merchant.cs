﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierService_Web.Models
{
    public class Merchant
    {
        [Key]
        public string Id { get; set; } = "M-" + Guid.NewGuid().ToString().Substring(0, 4);

        [Required(ErrorMessage = "Company name is required.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name should contain only alphabets.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Full address is required.")]
        public string FullAddress { get; set; }

        
        public string? CompanyAddress { get; set; }

        
        public string? District { get; set; }

        [Required(ErrorMessage = "Area is required.")]
        public string? Area { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^(\+88)?01[0-9]{9}$", ErrorMessage = "Please enter a valid phone number.")]
        public string ContactNumber { get; set; }

        //regx for facebook url
        [RegularExpression(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$", ErrorMessage = "Please enter a valid URL.")]
        public string? FacebookUrl { get; set; }

        [RegularExpression(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$", ErrorMessage = "Please enter a valid URL.")]
        public string? Website { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }


        public string? Password { get; set; }
        
        [Required(ErrorMessage = "Confirm Password is required.")]
        [NotMapped]
        [ValidateNever]
        public string? ConfirmPassword { get; set; }


        //nid should be 10, 13 digit or 17 digit
        [RegularExpression(@"^[0-9]{10}$|^[0-9]{13}$|^[0-9]{17}$", ErrorMessage = "Please enter a valid NID.")]
        public string? NID { get; set; }

        
        public string? TradeLicense { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        //tin should be 12 digit
        [RegularExpression(@"^[0-9]{12}$", ErrorMessage = "Please enter a valid TIN.")]
        public string? Tin { get; set; }



        public List<Parcel>? Parcels { get; set; }

        public List<DeliveredParcel>? DeliveredParcels { get; set; }

        [ForeignKey("HubId")]
        public string? HubId { get; set; }

        public Hub? Hub { get; set; }

        public List<Complain>? complains { get; set; }

        // Navigation property to MerchantPayments
        public List<MerchantPayment>? MerchantPayments { get; set; }

        public List<Store>? Stores { get; set; }
        // Specific delivery charge for each delivery type
        public int InsideDhakaDeliveryCharge { get; set; } = 70;
        public int SubDhakaDeliveryCharge { get; set; } = 90;
        public int OutsideDhakaDeliveryCharge { get; set; } = 120;
        public int InDhakaEmergencyDeliveryCharge { get; set; } = 100;
        public int P2PDeliveryCharge { get; set; } = 200;

        public decimal MaxiumWeight { get; set; } = 1;

        public int ExtraWeightCharge { get; set; } = 15;    

        public string? Status { get; set; } = "Requested";
       

    }
}
