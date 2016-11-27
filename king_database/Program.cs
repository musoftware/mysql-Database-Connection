using ConnectCsharpToMysql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace king_database
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Solution For Jack My Friend";

                Solutions sol = new Solutions();

                sol.CheckConnection();


                sol.ApplyFirst();
                Console.WriteLine("DONE :: From lean_domain_keyword table@ data_king database delete 2 chars");

                ///////////////

                sol.ApplySecond("start_with");
                Console.WriteLine("DONE :: Updating value for Dic_Keyword_% column IN start_with");

                sol.ApplyThird("start_with");
                Console.WriteLine("DONE :: Updating value for popularity_% column IN start_with");

                sol.ApplyFourth("start_with");
                Console.WriteLine("DONE :: Updating values for Pattern_%column IN start_with");


                sol.ApplySecond("end_with");
                Console.WriteLine("DONE :: Updating value for Dic_Keyword_% column IN end_with");

                sol.ApplyThird("end_with");
                Console.WriteLine("DONE :: Updating value for popularity_% column IN end_with");

                sol.ApplyFourth("end_with");
                Console.WriteLine("DONE :: Updating values for Pattern_%column IN end_with");

                Console.WriteLine("I have finished successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is exception");
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }



    }
}
