using ConnectCsharpToMysql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace king_database
{
    class Solutions
    {
        DBConnect db = new DBConnect();


        public bool CheckConnection()
        {
            if (!db.OpenConnection())
            {
                throw new Exception("");
            }
            else
            {
                db.CloseConnection();
            }
            return true;
        }

        public void ApplyFirst()
        {
            string in_sql = "";
            foreach (var item in phonogram_two_letter_words.list1)
                in_sql += "'" + item + "',";
            in_sql = in_sql.Trim(',');
            //var data = db.Select("SELECT * FROM lean_domain_keyword where length(Dic_word) = 2 and Dic_word not in (" + in_sql + ")");

            db.Delete("Delete FROM lean_domain_keyword where length(Dic_word) = 2 and Dic_word not in (" + in_sql + ")");
        }

        public void ApplySecond(string tablePrefix = "start_with")
        {
       
            //var data = db.Select("SELECT * FROM start_with inner join start_with_dic on start_with.Char1 = start_with_dic.Char1 where start_with.Dic_keyword =1 ");

            string forEnd = "Dic_Keyword_%";

            if (tablePrefix != "start_with")
                forEnd = "DIc_word_%";

            db.Update("UPDATE " + tablePrefix + " AS s inner join " + tablePrefix + "_dic AS d on s.Char1 = d.Char1 SET s.`Dic_Keyword_%` = d.`" + forEnd + "`  where s.Dic_keyword =1 ");
        }

        public void ApplyThird(string tablePrefix = "start_with")
        {
            //var data = db.Select("SELECT * FROM start_with as s inner join lean_domain_keyword d on s.Char1 = d.Dic_word where s.Dic_keyword =1 ");

            db.Update("UPDATE " + tablePrefix + " AS s inner join lean_domain_keyword AS d on s.Char1 = d.Dic_word SET s.`Popularity_%` = d.`Popularity_%` where s.Dic_keyword = 1");

            //
        }


        public void ApplyFourth(string tablePrefix = "start_with")
        {
            int Count = int.Parse(db.Select("SELECT COUNT(*) FROM string_pattern")[0][0].ToString());
            
            //var data = db.Select("SELECT * FROM start_with as s inner join string_pattern p on s.Char1 = p.String_pattern where s.Char_length = 3");

            db.Update("UPDATE " + tablePrefix + " as s inner join string_pattern p on s.Char1 = p.String_pattern SET s.`Pattern_%` = ROUND(p.String_count / " + Count + " * 100, 2)  where s.Char_length >= 3");

        } 
        



    }
}
