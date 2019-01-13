using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DraGLand.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserName { get; set; }
        public string QiwiCardNumber { get; set; }
        public string Email { get; set; }
        public int GameMoney { get; set; }
        public int RealMoney { get; set; }
        public string InviteCode { get; set; }
        public int ContractCharge { get; set; }
        public ICollection<Car> Cars { get; set; }
        public User()
        {
            Cars = new List<Car>();
        }
    }

    public class Car
    {
        public int CarId { get; set; }
        public string UserName { get; set; }
        public string Photo { get; set; }
        public User User { get; set; }
        public string CarName { get; set;}
        public int Price { get; set; }
        public int Stage { get; set; }
        public int AccelerateLvl { get; set; }
        public int WeightLvl { get; set; }
        public int EngineLvl { get; set; }
        public int TiresLvl { get; set; }
    }
}