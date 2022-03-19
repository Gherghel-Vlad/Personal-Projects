using MayorAssistantApp.Models.ChatBotModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MayorAssistantApp.DAL
{
    public class QADB
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Gets all the elements from the QA table
        /// </summary>
        /// <returns></returns>
        public static List<QA> GetAllQA()
        {
            List<QA> list = new List<QA>();
            QA elem = new QA();
            string kw;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM QA";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        elem = new QA();

                        elem.QAId = reader.GetInt32(0);
                        elem.QAText = reader.GetString(1);
                        elem.QAResponseId = reader.GetInt32(2);
                        elem.Context = reader.GetString(3);
                        elem.FlowId = reader.GetString(4);
                        elem.ComponentType = reader.GetInt32(5);
                        elem.ComponentGroupId = reader.GetString(6);
                        kw = reader.GetString(7);
                        elem.Keywords = kw.Split(',', ' ').ToList() ;

                        list.Add(elem);
                    }


                }
            }
            return list;
        }


        /// <summary>
        /// Gets the QA element from the table QA by Id
        /// </summary>
        /// <returns></returns>
        public static QA GetQAById(int qaid)
        {
            QA elem = new QA();
            string kw;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM QA WHERE QAId = @qaid";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@qaid", qaid);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        elem = new QA();

                        elem.QAId = reader.GetInt32(0);
                        elem.QAText = reader.GetString(1);
                        elem.QAResponseId = reader.GetInt32(2);
                        elem.Context = reader.GetString(3);
                        elem.FlowId = reader.GetString(4);
                        elem.ComponentType = reader.GetInt32(5);
                        elem.ComponentGroupId = reader.GetString(6);
                        kw = reader.GetString(7);
                        elem.Keywords = kw.Split(',', ' ').ToList();
                    }


                }
            }
            return elem;
        }

        /// <summary>
        /// Gets the QA elements from the table QA by ComponentGroupId
        /// </summary>
        /// <returns></returns>
        public static List<QA> GetQAByComponentGroupId(string componentGroupId)
        {
            List<QA> list = new List<QA>();
            QA elem = new QA();
            string kw;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM QA WHERE ComponentGroupId = @componentGroupId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@componentGroupId", componentGroupId);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        elem = new QA();

                        elem.QAId = reader.GetInt32(0);
                        elem.QAText = reader.GetString(1);
                        elem.QAResponseId = reader.GetInt32(2);
                        elem.Context = reader.GetString(3);
                        elem.FlowId = reader.GetString(4);
                        elem.ComponentType = reader.GetInt32(5);
                        elem.ComponentGroupId = reader.GetString(6);
                        kw = reader.GetString(7);
                        elem.Keywords = kw.Split(',', ' ').ToList();

                        list.Add(elem);
                    }


                }
            }
            return list;
        }


        /// <summary>
        /// Inserts the QA element into the QA table
        /// </summary>
        /// <returns></returns>
        public static void InsertQA(QA qa)
        {
            string ewords ="";
            foreach (var str in qa.Keywords)
                ewords = ewords + ", " + str;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO QA( QAText, QAResponseId, Context, FlowId, ComponentType," +
                    " ComponentGroupId, Keywords) VALUES ( @qatext, @qaresponseid, @context," +
                    "@flowid, @componenttype,@componentgroupid, @keywords)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@qatext", qa.QAText);
                    cmd.Parameters.AddWithValue("@qaresponseid", qa.QAResponseId);
                    cmd.Parameters.AddWithValue("@context", qa.Context);
                    cmd.Parameters.AddWithValue("@flowid", qa.FlowId);
                    cmd.Parameters.AddWithValue("@componenttype", qa.ComponentType);
                    cmd.Parameters.AddWithValue("@componentgroupid", qa.ComponentGroupId);
                    cmd.Parameters.AddWithValue("@keywords", ewords);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Inserts the QA element into the QA table and returns the id that it will have
        /// </summary>
        /// <returns></returns>
        public static int InsertQAAndReturnTheId(QA qa)
        {
            int id;
            string ewords = "";
            foreach (var str in qa.Keywords)
                ewords = ewords + ", " + str;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO QA( QAText, QAResponseId, Context, FlowId, ComponentType," +
                    " ComponentGroupId, Keywords) VALUES ( @qatext, @qaresponseid, @context," +
                    "@flowid, @componenttype,@componentgroupid, @keywords); SELECT SCOPE_IDENTITY()  ";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@qatext", qa.QAText);
                    cmd.Parameters.AddWithValue("@qaresponseid", qa.QAResponseId);
                    cmd.Parameters.AddWithValue("@context", qa.Context);
                    cmd.Parameters.AddWithValue("@flowid", qa.FlowId);
                    cmd.Parameters.AddWithValue("@componenttype", qa.ComponentType);
                    cmd.Parameters.AddWithValue("@componentgroupid", qa.ComponentGroupId);
                    cmd.Parameters.AddWithValue("@keywords", ewords);

                    cmd.ExecuteNonQuery();
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return id;
            
        }


        /// <summary>
        /// Updates a QA element from the table based on the id
        /// </summary>
        /// <returns></returns>
        public static void UpdateQA(QA qa)
        {
            string ewords = "";
            foreach (var str in qa.Keywords)
                ewords = ewords + ", " + str;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = " UPDATE QA SET QAText=@qatext, QAResponseId=@qaresponseid, Context=@context," +
                    "FlowId=@flowid, ComponentType=@componenttype, ComponentGroupId=@componentgroupid," +
                    " Keywords=@keywords WHERE QAId = @qaid";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@qaid", qa.QAId);
                    cmd.Parameters.AddWithValue("@qatext", qa.QAText);
                    cmd.Parameters.AddWithValue("@qaresponseid", qa.QAResponseId);
                    cmd.Parameters.AddWithValue("@context", qa.Context);
                    cmd.Parameters.AddWithValue("@flowid", qa.FlowId);
                    cmd.Parameters.AddWithValue("@componenttype", qa.ComponentType);
                    cmd.Parameters.AddWithValue("@componentgroupid", qa.ComponentGroupId);
                    cmd.Parameters.AddWithValue("@keywords", ewords);

                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}