using System;
using System.Collections.Generic;
using System.Text;

namespace ColmenApp.Models
{
    public class GeneralSetting
    {
        #region Properties
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool IsLogged { get; set; }
        public bool FirstTime { get; set; }
        #endregion

        #region Constructors
        public GeneralSetting()
        {
            FirstTime = true;
        }
        #endregion
    }
}
