#region Copyright ©2016, Click2Cloud Inc. - All Rights Reserved
/* ------------------------------------------------------------------- *
*                            Click2Cloud Inc.                          *
*                  Copyright ©2016 - All Rights reserved               *
*                                                                      *
*                                                                      *
*  Copyright © 2016 by Click2Cloud Inc. | www.click2cloud.net          *
*  All rights reserved. No part of this publication may be reproduced, *
*  stored in a retrieval system or transmitted, in any form or by any  *
*  means, photocopying, recording or otherwise, without prior written  *
*  consent of Click2cloud Inc.                                         *
*                                                                      *
*                                                                      *
* -------------------------------------------------------------------  */
#endregion Copyright ©2016, Click2Cloud Inc. - All Rights Reserved

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Click2Cloud.EnterpriseApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValidateController : Controller
    {
        [HttpGet("{_ModuleName}")]
        public string GetProjectId(string _ModuleName, string _A, string _B, string _C, string _D)
        {//http://localhost:62777/api/validate/_ModuleName
            string result = string.Empty;
            try
            {

                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                //var builder = new ConfigurationBuilder().AddJsonFile("config.json");
                //var config = builder.Build();
                //string _connectionString = config["ConnectionString"];

                myConnection.ConnectionString = Files.Config.ConnectionString; //_connectionString;
                SqlCommand sqlCmd = new SqlCommand();
                myConnection.Open();
                sqlCmd.Connection = myConnection;
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.CommandText = "CheckValidate";

                sqlCmd.Parameters.Add("@MODULENAME", SqlDbType.VarChar);
                sqlCmd.Parameters["@MODULENAME"].Value = _ModuleName;

                sqlCmd.Parameters.Add("@A", SqlDbType.VarChar);
                sqlCmd.Parameters["@A"].Value = string.IsNullOrEmpty(_A) ? "" : _A;

                sqlCmd.Parameters.Add("@B", SqlDbType.VarChar);
                sqlCmd.Parameters["@B"].Value = string.IsNullOrEmpty(_B) ? "" : _B;

                sqlCmd.Parameters.Add("@C", SqlDbType.VarChar);
                sqlCmd.Parameters["@C"].Value = string.IsNullOrEmpty(_C) ? "" : _C;
                sqlCmd.Parameters.Add("@D", SqlDbType.VarChar);
                sqlCmd.Parameters["@D"].Value = string.IsNullOrEmpty(_D) ? "" : _D;
                reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader[0].ToString();
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
