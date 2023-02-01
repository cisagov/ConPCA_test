using System;

namespace ConPCA_Selenium.Enums
{
    public enum DateDifferenceOptions
    {
        [DateDifferenceOptionsAttr("hh")] Hour,
        [DateDifferenceOptionsAttr("mi")] Minute,
        [DateDifferenceOptionsAttr("ss")] Second,
        [DateDifferenceOptionsAttr("ms")] Millis,
        [DateDifferenceOptionsAttr("dd")] Day,
        [DateDifferenceOptionsAttr("ww")] Week,
        [DateDifferenceOptionsAttr("mm")] Month,
        [DateDifferenceOptionsAttr("yyyy")] Year
    }

    class DateDifferenceOptionsAttr : Attribute
    {
        internal DateDifferenceOptionsAttr(String type)
        {
            this.Value = type;
        }
        public String Value { get; private set; }
    }

    public static class DateDifferenceOptionsExtensions
    {
        public static String GetValue(this DateDifferenceOptions enumChoice)
        {
            var attr = enumChoice.GetAttribute<DateDifferenceOptionsAttr>();
            return attr.Value;
        }
    }
}