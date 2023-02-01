using System;

namespace ConPCA_Selenium.Enums.Con_PCA
{
    public enum LoginInfo

    {
        [LoginAttr("jessica.qu")] User_Name,
        [LoginAttr("Abc123$$")] Password,
    }

    class LoginAttr : Attribute
    {
        internal LoginAttr(String loginInfo)
        {
            this.Value = loginInfo;
        }
        public String Value { get; private set; }
    }

    public static class LoginExtensions
    {
        public static String GetValue(this LoginInfo enumChoice)
        {
            var attr = enumChoice.GetAttribute<LoginAttr>();
            return attr.Value;
        }
    }
}
