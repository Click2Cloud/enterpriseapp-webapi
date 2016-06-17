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
    public class AdUserDetail
    {
        public string UserGUID
        {
            get;
            set;
        }

        public string DisplayName
        {
            get;
            set;
        }

        public string LoginName
        {
            get;
            set;
        }

        public int MenuId
        {
            get;
            set;
        }

        public string MenuName
        {
            get;
            set;
        }

        public int Parent
        {
            get;
            set;
        }

        public int Child
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }

        public string EmployeeEmail
        {
            get;
            set;
        }
    }
}
