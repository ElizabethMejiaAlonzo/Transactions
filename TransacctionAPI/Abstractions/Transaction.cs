using System;
using System.ComponentModel.DataAnnotations;

namespace Abstractions
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required Description")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required Amount")]
        [Range(1, 49999.99, ErrorMessage = "For security it is only possible to transfer less than $ 50,000")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Required AccountNumber")]
        [Range(100000000000, 9999999999999999999, ErrorMessage = "AccountNumber must be between 12 and 19 digits")]
        public Int64 AccountNumber { get; set; }
        [Required(ErrorMessage = "Required Beneficiary Name")]
        [MaxLength(50)]
        [MinLength(1)]
        public string BeneficiaryName { get; set; }
        [Required(ErrorMessage = "Required Bank Name")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Bank { get; set; }
        public string CreationDate { get; set; }
        [Required(ErrorMessage = "Required Transaction Type")]
        public int Type { get; set; }
        public bool Status { get; set; }
    }
}
