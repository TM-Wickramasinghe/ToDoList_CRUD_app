using AptitudeTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AptitudeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ToDoListController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetTheToDoList")]
        public Response GetTheToDoList()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetTheToDoList(connection);
            return response;
        }

        [HttpGet]
        [Route("GetTheToDoList{ID}")]
        public Response GetTheToDoList(int ID)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetTheToDoList(connection);
            return response;
        }

        [HttpPost]
        [Route("AddTheToDoList")]
        public Response AddTheToDoList(ToDoList toDoList)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddTheToDoList(connection,toDoList);
            return response;
        }

        [HttpPut]
        [Route("UpdateTheToDoList")]
        public Response UpdateTheToDoList(ToDoList toDoList)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateTheToDoList(connection, toDoList);
            return response;
        }

        [HttpDelete]
        [Route("DeleteTheToDoList/{ID}")]
        public Response DeleteTheToDoList(int ID)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteTheToDoList(connection, ID);
            return response;
        }
    }
}