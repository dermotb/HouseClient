using System;
using System.ComponentModel.DataAnnotations;

namespace House4U.Models
{
    public class Property
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Address { get; set; }
        [Range(1, int.MaxValue)]
        public int NumRooms { get; set; }
        [Required]
        public bool FullyDelegated { get; set; }
        [Required]
        [EmailAddress]
        public string ClientMail { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0} | Address: {1} | Rooms: {2} | Delegated: {3} | Mail: {4}| Expiry: {5}", ID, Address, NumRooms, FullyDelegated, this.ClientMail, this.ExpiryDate);
        }
    }


}
