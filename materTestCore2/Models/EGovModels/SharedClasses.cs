using System.ComponentModel;

namespace materTestCore2.Models.EGovModels
{
    public class SharedClasses
    {
        public class authenticationRequest
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        public class authenticationResponse
        {
            public bool Success { get; set; }
            public string returnURL { get; set; }
            public string Code { get; set; }
            public string Message { get; set; }
        }
        public class basicResponse
        {
            public bool Success { get; set; }
            public string returnURL { get; set; }
            public string Code { get; set; }
            public string Message { get; set; }
        }
        public class authenticationResponse2 : basicResponse
        {
            /// <summary>
            /// user token 
            /// </summary>
            public string Token { get; set; }
            /// <summary>
            /// user id
            /// </summary>
            public string USERID { get; set; }
            public string USERNAME { get; set; }
            public string FIRSTNAME { get; set; }
            public string LASTNAME { get; set; }
            public string PASSWORD { get; set; }
            public string ROLE { get; set; }
            public List<string> PERMISSIONS { get; set; }
            public List<string> ROLES { get; set; }
        }

        public enum AuthError
        {
            None,

            [Description("الحساب مغلق")]
            Locked,

            [Description("الصلاحية غير كافية")]
            NotEnaughPermissions,

            [Description("المستخدم لا يمتلك صلاحية ضمن هذا التطبيق")]
            UserHaveNoRolesInApp,

            [Description("انتهت صلاحية الجلسة. سجل الدخول من جديد")]
            SessionExpired,
        }
        //public class authoriztionRequest
        //{
        //    public AuthorizationContext AuthorizationContext { get; set; }

        //}
        //public class authorizationResponse
        //{
        //    public bool Success { get; set; }
        //    public string returnURL { get; set; }
        //    public string Code { get; set; }
        //    public string Message { get; set; }
        //}
    }
}
