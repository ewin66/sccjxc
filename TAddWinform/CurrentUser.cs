using System;
using System.Collections.Generic;
using System.Text;

namespace TAddWinform
{
    public class CurrentUser
    {
        public string UserCode = string.Empty;
        public string UserName = string.Empty;
        public string Password = string.Empty;
        public Boolean IsAdmin = false;
        public string Memo = string.Empty;

        private static CurrentUser _Instance = null;

        private CurrentUser( )
        {

        }
        public static CurrentUser Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CurrentUser();
                }
                return _Instance;
            }

        }
    }
}
