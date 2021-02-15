
using System;
using System.ComponentModel.DataAnnotations;

namespace Abstractions
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public Int64 AccountNumber { get; set; }
        public string Bank { get; set; }
    }
}
