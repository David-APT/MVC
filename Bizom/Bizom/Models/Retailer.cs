using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bizom.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
        public string DPassword { get; set; }
        [Required]
        public string Roles { get; set; }
    }
    public class AccountCreation
    {
        [Key]
        public int CREATERE_Id { get; set; }
        public string CREATERE_USERNAME { get; set; }
        public string CREATERE_PASSWORD { get; set; }
        [Required]
        public string Roles { get; set; }
        public string status { get; set; }
    }
    public class Retailer
    {
        [Key]
        public int Retailer_Id { get; set; }
        [Required]
        public string Select_Beat { get; set; }
        [Required]
        public string Outlet_Types { get; set; }
        [Required]
        public string Outlet_Name { get; set; }
        [Required]
        public string Outlet_Address { get; set; }
        [Required]
        public string Owner_Name { get; set; }
        //[RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        //[Required]
        public Int64 Owner_Nunmer { get; set; }
        public string Outlet_Image { get; set; }
        [Required]
        public string EMAIL { get; set; }

    }
    public class product
    {
        [Key]
        public int product_id { get; set; }
        public string PRODUCT_BRAND { get; set; }
        public string PRODUCT_NAME { get; set; }
        public double PRODUCT_MAR { get; set; }
        public double PRODUCT_MARGIN { get; set; }
        public double PRODUCT_CASE { get; set; }
        public double PRODUCT_PRICE { get; set; }
        public string PRODUCT_IMAGE { get; set; }
        public int UNIT { get; set; }
        public int CASE { get; set; }

    }
    public enum roles
    {
        Admin, Staff, Customer
    }

    public enum Fields
    {
        BURMACOLONY, KALANIVASAL, SENJAI, RAILWAYROAD, PALLATHUR, PUTHUVAYAL
    }
    public enum types
    {
        OFO, GENERAL_STORE, KIRANA_STORE, WHOLESALE, CHEMIST
    }
    public enum brand
    {
        UJALA_FW, Maxo, EXO_STEEL, Green_Scrubber, Exo_Bar, HB, EXO_POWDER, PRIL_LIQUID, MR_WHITE_DETERGENT_POWDER, Henko, Ujala_LD, CHEK_BAR,
        Exo_Gel, Pril_BAR, Henkomatic_LD, HENKO_MATIC_POWDER, Morelight, Ujala_IDD, MARGO, Margo_HW, Maya, Ujala_CS, NTP, Henkomatic_Liquid
    }
    public class DbBIZ : DbContext
    {
        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<AccountCreation> AccountCreations { get; set; }
        public DbSet<product> products { get; set; }
    }

}