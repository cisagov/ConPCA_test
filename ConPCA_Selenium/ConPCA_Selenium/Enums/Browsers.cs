using System;

namespace ConPCA_Selenium.Enums
{
    public enum Browsers
    {
        [BrowsersAttr("ie")] InternetExplorer,
        [BrowsersAttr("chrome")] Chrome,
        [BrowsersAttr("chromeMobile")] Chrome_Mobile,
        [BrowsersAttr("firefox")] Firefox,
        [BrowsersAttr("Edge")] Edge,
        [BrowsersAttr("opera")] Opera,
        [BrowsersAttr("safari")] Safari
    }

    class BrowsersAttr : Attribute
    {
        internal BrowsersAttr(String type)
        {
            this.Value = type;
        }
        public String Value { get; private set; }
    }

    public static class BrowsersExtensions
    {
        public static String GetValue(this Browsers enumChoice)
        {
            var attr = enumChoice.GetAttribute<BrowsersAttr>();
            return attr.Value;
        }
    }
}
