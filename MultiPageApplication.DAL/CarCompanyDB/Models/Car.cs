using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPageApplication.DAL.CarCompanyDB.Models
{
    public class Car
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
    }
}
