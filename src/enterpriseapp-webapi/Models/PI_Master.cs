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

namespace Click2Cloud.EnterpriseApp.WebAPI.Models
{
    public class PI_Master
    {
        public int i_ID
        {
            get;
            set;
        }

        public string s_DeptName
        {
            get;
            set;
        }

        public string s_PIName
        {
            get;
            set;
        }

        public int i_Dept_ID
        {
            get;
            set;
        }

        public string s_Firstname
        {
            get;
            set;
        }

        public string s_Lastname
        {
            get;
            set;
        }

        public string s_Email
        {
            get;
            set;
        }

        public string s_Phone_no
        {
            get;
            set;
        }

        public string s_MCR_No
        {
            get;
            set;
        }

        public string s_Description
        {
            get;
            set;
        }

        public string s_CreatedBy_ID
        {
            get;
            set;
        }

        public string s_ModifyBy_ID
        {
            get;
            set;
        }

        public DateTime dt_Created_Date
        {
            get;
            set;
        }

        public DateTime dt_Modify_Date
        {
            get;
            set;

        }
    }

    public class Depatrment_PI
    {
        public int i_PI_ID { get; set; }
        public int i_dept_id { get; set; }
        public string s_email { get; set; }
        public string s_name { get; set; }
        public string s_mcrno { get; set; }
        public string s_phone { get; set; }
    }

    public class Project_Dept_PI
    {
        public int i_Project_ID
        {
            get;
            set;
        }
        public int i_PI_ID
        {
            get;
            set;
        }
        public string s_ModifyBy_ID
        {
            get;
            set;
        }
        public DateTime dt_Modify_Date
        {
            get;
            set;
        }
    }
}
