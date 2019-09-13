using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BmiClient.Models;

namespace BmiClient
{
   public interface IBmiHandler
   {
       Task<BmiResponseModel> CreateBmi(double weigth, double heigth, double bmi);
   }
}
