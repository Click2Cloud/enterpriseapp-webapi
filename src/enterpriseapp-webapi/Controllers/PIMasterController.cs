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
using Click2Cloud.EnterpriseApp.WebAPI.Models;
using System.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Click2Cloud.EnterpriseApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PIMasterController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get(PI_Master _PI_Master, string mode)
        {
            string result = string.Empty;
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = Files.Config.ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.CommandText = "spPI_MasterDML";
            sqlCmd.Connection = myConnection;
            myConnection.Open();

            sqlCmd.Parameters.Add("@StatementType", SqlDbType.VarChar);
            sqlCmd.Parameters["@StatementType"].Value = mode;


            sqlCmd.Parameters.Add("@i_ID", SqlDbType.Int);
            sqlCmd.Parameters["@i_ID"].Value = _PI_Master.i_ID;

            if (mode.ToString() != "Delete")
            {

                sqlCmd.Parameters.Add("@i_Dept_ID", SqlDbType.Int);
                sqlCmd.Parameters["@i_Dept_ID"].Value = _PI_Master.i_Dept_ID;

                sqlCmd.Parameters.Add("@s_Firstname", SqlDbType.VarChar);
                sqlCmd.Parameters["@s_Firstname"].Value = _PI_Master.s_Firstname;

                sqlCmd.Parameters.Add("@s_Lastname", SqlDbType.VarChar);
                sqlCmd.Parameters["@StatementType"].Value = _PI_Master.s_Lastname;

                sqlCmd.Parameters.Add("@s_Email", SqlDbType.VarChar);
                sqlCmd.Parameters["@s_Email"].Value = _PI_Master.s_Email;

                sqlCmd.Parameters.Add("@s_Phone_no", SqlDbType.VarChar);
                sqlCmd.Parameters["@s_Phone_no"].Value = _PI_Master.s_Phone_no;

                sqlCmd.Parameters.Add("@s_MCR_No", SqlDbType.VarChar);
                sqlCmd.Parameters["@s_MCR_No"].Value = _PI_Master.s_MCR_No;

                sqlCmd.Parameters.Add("@UserCID", SqlDbType.VarChar);
                sqlCmd.Parameters["@UserCID"].Value = _PI_Master.s_CreatedBy_ID;

            }
            sqlCmd.Parameters.Add("@Ret_Parameter", SqlDbType.VarChar);
            sqlCmd.Parameters["@Ret_Parameter"].Size = 500;
            sqlCmd.Parameters["@Ret_Parameter"].Direction = ParameterDirection.Output;
            sqlCmd.ExecuteNonQuery();
            if (string.IsNullOrEmpty(sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString()))
            {
                result = "Success" + " | " + sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString();
            }
            else
            {
                result = sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString();
            }
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PI_Master Get(int id)
        {
            string result = string.Empty;
            SqlDataReader reader = null;
            PI_Master mas = new PI_Master();
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = Files.Config.ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.CommandText = "spPI_MasterDML";
            sqlCmd.Connection = myConnection;
            myConnection.Open();

            sqlCmd.Parameters.Add("@StatementType", SqlDbType.VarChar);
            sqlCmd.Parameters["@StatementType"].Value = "Select";


            sqlCmd.Parameters.Add("@i_ID", SqlDbType.Int);
            sqlCmd.Parameters["@i_ID"].Value = id;


            sqlCmd.Parameters.Add("@Ret_Parameter", SqlDbType.VarChar);
            sqlCmd.Parameters["@Ret_Parameter"].Size = 500;
            sqlCmd.Parameters["@Ret_Parameter"].Direction = ParameterDirection.Output;
            reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                mas.s_Email = reader.GetValue(4).ToString();
                mas.s_Phone_no = reader.GetValue(5).ToString();
                mas.s_MCR_No = reader.GetValue(6).ToString();
            }
            //if (string.IsNullOrEmpty(sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString()))
            //{
            //    result = "Success" + " | " + sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString();
            //    mas.s_Email=
            //}
            //else
            //{
            //    result = sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString();
            //}
            return mas;
        }

        // POST api/values
        [HttpPost]

        public string Post([FromBody]PI_Master pi_Master, string mode = "Insert")
        {
            string result = string.Empty;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = Files.Config.ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            myConnection.Open();
            sqlCmd.Connection = myConnection;
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.CommandText = "spPI_MasterDML";
            sqlCmd.Parameters.Add("@StatementType", SqlDbType.VarChar);
            sqlCmd.Parameters["@StatementType"].Value = mode;
            sqlCmd.Parameters.Add("@i_ID", SqlDbType.Int);
            sqlCmd.Parameters["@i_ID"].Value = pi_Master.i_ID;

            if (mode.ToString() != "Delete")
            {
                sqlCmd.Parameters.Add("@i_Dept_ID", SqlDbType.Int);
                sqlCmd.Parameters["@i_Dept_ID"].Value = pi_Master.i_Dept_ID;
                sqlCmd.Parameters.Add("@s_Firstname", SqlDbType.VarChar);
                sqlCmd.Parameters["@s_Firstname"].Value = pi_Master.s_Firstname;
                sqlCmd.Parameters.Add("@s_Lastname", SqlDbType.VarChar);
                sqlCmd.Parameters["@s_Lastname"].Value = pi_Master.s_Lastname;
                sqlCmd.Parameters.Add("@s_Email", SqlDbType.VarChar);
                sqlCmd.Parameters["@s_Email"].Value = pi_Master.s_Email;
                sqlCmd.Parameters.Add("@s_Phone_no", SqlDbType.VarChar);
                sqlCmd.Parameters["@s_Phone_no"].Value = pi_Master.s_Phone_no;
                sqlCmd.Parameters.Add("@s_MCR_No", SqlDbType.VarChar);
                sqlCmd.Parameters["@s_MCR_No"].Value = pi_Master.s_MCR_No;
                sqlCmd.Parameters.Add("@UserCID", SqlDbType.VarChar);
                sqlCmd.Parameters["@UserCID"].Value = pi_Master.s_CreatedBy_ID;
            }
            sqlCmd.Parameters.Add("@Ret_Parameter", SqlDbType.VarChar);
            sqlCmd.Parameters["@Ret_Parameter"].Size = 500;
            sqlCmd.Parameters["@Ret_Parameter"].Direction = ParameterDirection.Output;
            sqlCmd.ExecuteNonQuery();
            if (!string.IsNullOrEmpty(sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString()))
            {
                if (sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString().ToLower().Contains("success"))
                {
                    result = sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString();
                    //success is returned from db
                }
                else
                {
                    result = sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString();
                }
            }
            else
            {
                result = sqlCmd.Parameters[sqlCmd.Parameters.Count - 1].Value.ToString();
            }
            myConnection.Close();
            return result;
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
