using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AptitudeTest.Models
{
    public class DAL
    {
        public Response GetTheToDoList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from list", connection);
            DataTable dt = new DataTable();
            List<ToDoList> listToDoList = new List<ToDoList>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ToDoList toDoList = new ToDoList();
                    toDoList.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    toDoList.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    toDoList.SubTitle = Convert.ToString(dt.Rows[i]["SubTitle"]);
                    toDoList.Date = Convert.ToDateTime(dt.Rows[i]["Date"]);
                    listToDoList.Add(toDoList);
                }
            }
            if (listToDoList.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listToDoList = listToDoList;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listToDoList = null;
            }
            return response;
        }
        
        public Response TheToDoListByID(SqlConnection connection, int ID)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from list where ID = '"+ID+"'", connection);
            DataTable dt = new DataTable();
            ToDoList ToDoLists = new ToDoList();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ToDoList toDoList = new ToDoList();
                toDoList.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                toDoList.Title = Convert.ToString(dt.Rows[0]["Title"]);
                toDoList.SubTitle = Convert.ToString(dt.Rows[0]["SubTitle"]);
                toDoList.Date = Convert.ToDateTime(dt.Rows[0]["Date"]);
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.ToDoList = toDoList;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.ToDoList = null;
            }
            return response;
        }

        public Response AddTheToDoList(SqlConnection connection, ToDoList toDoList)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO list (Title,SubTitle, Date) VALUES('" + toDoList.Title + "','" + toDoList.SubTitle + "',GETDATE()) ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Target Added";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Added";
            }
            return response;
        }

        public Response UpdateTheToDoList(SqlConnection connection, ToDoList toDoList)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE list SET Title = '" + toDoList.Title + "',SubTitle = '" + toDoList.SubTitle + "' WHERE ID = '" + toDoList.ID + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Target Updated";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Updated";
            }
            return response;
        }

        public Response DeleteTheToDoList(SqlConnection connection, int ID)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE from list WHERE ID ='" + ID + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Target Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Target Not Deleted";
            }
            return response;
        }
    }
}