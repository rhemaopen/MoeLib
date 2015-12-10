﻿// ***********************************************************************
// Project          : MoeLib
// File             : WebApiConfig.cs
// Created          : 2015-11-20  5:55 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-24  5:50 PM
// ***********************************************************************
// <copyright file="WebApiConfig.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Web.Http;
using Moe.Lib;
using Moe.Lib.Web;

namespace MoeLibWebLab
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            string mockBearerAuthKeys = @"&lt;RSAKeyValue&gt;&lt;Modulus&gt;2xZz3D700cC6DRoD52rm0DqcokQnJY8SoKGdaios/32nbnAVhFQavQa76fCTv/yn5rR2tTI/oBp8uzHox3vDHe/ZCC0hr2eI2FqaWSkG48k6Rd3IOke9AU0C+s4B1BVhvDkcfVw0NBN7jqneWzrjF4KDsPTqme53vCKeeePfc7HPaR7DWQyfxxqQu8zN6MHGBTPQEG7/nkVnO1m5K6UpbbLCTI70klyKfZD4n+rJC0dSgRuelW/Ep5YuLq5jgqTDxnTx+4BkTGJArcZq3Hi0jfXEQ4898yspybvywgcl5cWVuM1g6Hsz0mDTWlLQHiYn3zkOeMdxwL4z+Kfsznd+Pw==&lt;/Modulus&gt;&lt;Exponent&gt;AQAB&lt;/Exponent&gt;&lt;P&gt;8ZGbaP2xW13Be8NfZQBJxpVg93Xam5xOp3rQKBxt5OnaarOCjg+cO6WIQijbKd2dLKsWtI+pAdVRn2PzuWCP8U3OrfyVTVNFB7Xx7O9miiE3uHYmBRsd2Ki3DWxWOK/o38O6UetrmOQmUPhNL6UqW4UWQJ+wNrsGFEfGHhH+LjU=&lt;/P&gt;&lt;Q&gt;6C0I7Z/zoxtmai4KvN4eT3K9EKuLatdj605iY/Rc/s65wowCYBJft9qgx+gOX34BUwelSK/sHdl2U0ub1KelW8lkl6Tg1VJOlWx2uC/AjwajJadNbeXiRXibxT+jwdE5RP3rJpGYvM1eTj8GtK0WgpxW0BFRkW6q0CXP78PkGSM=&lt;/Q&gt;&lt;DP&gt;pK7FKfA5ZrYl3z+z2uE1amIPtuPrYkZPALIjEhU/fd1G/5LdIAfYVHlmyOOddY8VRYxlcDa32v4YJPc5AlmoB7MpgUc+aXapCrao9QPH/cbje6dgB/8Se8+Y61e99+tEcLe4X3yE37g5vt1nkWGh3L6ACxJSSR166Xx8vac6hzk=&lt;/DP&gt;&lt;DQ&gt;RAwu+bZPqhZ1xdkIvKI9L/vo/eHJUt8eIfEvVSxhtSzRtPtkFtRLyY8CYJTa4ZIEwVkUUGF/SqBZ1b/rREB+bpBwMyHX463j6leH1CPqxACmAHswbm1aDBJ1VTJ5xGyV5GqnaP5zTaLDaRt/06SHXHCF4SWySnWtCqSKdTNsvxE=&lt;/DQ&gt;&lt;InverseQ&gt;6gGwP8nYdJ4ja74kmcSAfC4fwGBdzobHK/VAtmVQ2BU9FqM9Me2Ijx/XeocXoe9WzuK98WGdw6ZLs0qB+R1RlXqGN2cIt0sK08b/GXwWgXmk/1wP6ZmBALg4PhSWWBum107e1FewqkBEt/NpDtwfzv1QKv7PCt1XSlo7jbvF7UU=&lt;/InverseQ&gt;&lt;D&gt;avHX1qAos6cHatPTKgjl6KljwlXQYiYn6p9ZjvRNiN3WeDNgXXsMnk8GNZkJFoOHljdrZuHDayzizCH9xjqksR1ebP5S3iOFCk+X3oQHZ/PXbTlovwI7wcHM/Y7IF7XkQpQCUzNKDE2iV66V6ySgq9462IuFZWShsAWaJFfWwMsY+YHPR9+7PqiBNE/cOSU0oi8arJVNw7lu2NZEz0HTGyl1iqrlH8AWlFZCfi4W33FijfjicV1MgGNzaYcsoBp+7ef58O3mxD1EWgiJOPP4Dmx9Agc5FuNqSmgekIUXNIYP46Xob2TT42h6TsbvZVVknLBSDk1vjluiA3nSxLdZ2Q==&lt;/D&gt;&lt;/RSAKeyValue&gt;".HtmlDecode();
            string mockGovernmentServerPublicKey = mockBearerAuthKeys;

            // Web API configuration and services
            config.UseJinyinmaoExceptionHandler();

            config.UseJinyinmaoTraceEntryHandler();
            config.UseJinyinmaoAuthorizationHandler(mockBearerAuthKeys, mockGovernmentServerPublicKey);
            config.UseJinyinmaoLogHandler();

            config.UseJinyinmaoExceptionLogger();
            config.UseJinyinmaoTraceWriter();

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}