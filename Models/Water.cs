using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication9Municipal_Billing_System.Models
{
    public class Water 
    {

    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WaterId{get;set;}
    public decimal Usage {get;set;}
    public decimal Rate {get;set;} //Cost Per litre
    public decimal Cost {get;set;} 
 // Foreign key for User
    public int UserId { get; set; }
    // Navigation property to associate this tariff with a User
    public Reg Reg  { get; set; }

    public decimal WaterCost()
    {
        return Usage * Rate ;
    }
    
    }
}