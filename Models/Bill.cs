using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication9Municipal_Billing_System.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public int WaterId { get; set; }
        public int ElectricityId { get; set; }
        public int TarriffId { get; set; }

        public decimal BasicCost { get; set; }
        public decimal TarriffDiscount { get; set; }
        public decimal TotalCost { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual Reg Reg { get; set; } // Navigation property for User

        [ForeignKey("WaterId")]
        public virtual Water Water { get; set; }

        [ForeignKey("ElectricityId")]
        public virtual Electricity Electricity { get; set; }

        [ForeignKey("TarriffId")]
        public virtual Tarriff Tarriff { get; set; }


        // Method to calculate basic cost (sum of water and electricity costs)
        public decimal CalculateBasicCost()
        {
            // Assuming Water and Electricity objects are loaded with their respective costs
            decimal waterCost = Water?.Cost ?? 0; // Use 0 if Water is null
            decimal electricityCost = Electricity?.Cost ?? 0; // Use 0 if Electricity is null

            BasicCost = waterCost + electricityCost;
            return BasicCost;
        }

        public decimal TarriffDiscountRate()
        {
           decimal  disc = Tarriff.DiscRate;
           decimal rate = disc / 100;

           return rate;
        }


        // Method to calculate total cost after applying tariff discount
        public decimal CalculateTotalCost()
        {
            // First, calculate the basic cost
            

            // Apply discount to calculate total cost
            TotalCost = CalculateBasicCost() - (CalculateBasicCost() * TarriffDiscountRate());
            return TotalCost;
        }
    }
}
