using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BmiClient.Models;

namespace BmiClient
{
    public class BmiHandler : IBmiHandler
    {
        private readonly string _dbConnectionString;
        private readonly string _id;
        private readonly string _userName;

        public BmiHandler(string dbConnectionString, string id, string userName)
        {
            _dbConnectionString = dbConnectionString;
            _id = id;
            _userName = userName;
        }


   

        public async Task<BmiResponseModel> CreateBmi(double weigth, double heigth, double bmi)
        {
            try
            {
                if (string.IsNullOrEmpty(_dbConnectionString))
                    throw new NullReferenceException("No db location is provided");

                if (string.IsNullOrEmpty(_userName))
                    throw new NullReferenceException("No username is provided");

                if (string.IsNullOrEmpty(_id))
                    throw new NullReferenceException("No id is provided");


                BmiResponseModel r = await Task.FromResult(new BmiResponseModel
                {
                    Bmi = bmi,
                    Text = BmiConverter(bmi),
                });


                if (r == null) throw new NullReferenceException("Result is null");

                if (r.Text.Equals("Kunne ikke beregne - mangler du et decimal?"))
                    return r;

                //Create in db
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(_dbConnectionString);
                    SqlCommand cmd;

                    string sql =
                        $"INSERT INTO [dbo].[BmiResults]([Weigth],[Heigth],[Id],[UserName],[CreatedOn],[Bmi],[BmiText]) VALUES (@weigth, @heigth, @id, @userName, @createdOn, @bmi, @bmiText)";
                    cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@weigth", Value = weigth });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@heigth", Value = heigth });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = _id});
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@userName", Value = _userName});
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@createdOn", Value = DateTime.Now });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@bmi", Value = r.Bmi });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@bmiText", Value = r.Text });


                    if (sqlConnection.State != ConnectionState.Open)
                        sqlConnection.Open();
                    await cmd.ExecuteNonQueryAsync();

                    sqlConnection.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;

                }

                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    

        private string BmiConverter(double? r)
        {

            if(r == null)
                throw new NullReferenceException($"Bmi cannot be null - Please check your weigth and heigth");

            if (r > 18.5)
                return "Du er undervægtig";

            if (r > 18.5 && r < 25)
                return "Du har en sund og normal vægt";

            if (r > 25 && r < 30)
                return "Du er overvægtig";

            if (r > 30 && r < 40)
                return "Du er svært overvægtig";

            return r > 40 ? "Du er ekstremt overvægtig" : "Kunne ikke beregne - mangler du et decimal?";
        }
    }
}
