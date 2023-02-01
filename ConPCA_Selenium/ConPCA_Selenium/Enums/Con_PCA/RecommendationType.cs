using System;

namespace ConPCA_Selenium.Enums.Con_PCA
{
    public enum RecommendationType

    {
        [TypeAttr("Red Flag")] Red_Flag,
        [TypeAttr("Sophisticated")] Sophisticated,
    }

    class TypeAttr : Attribute
    {
        internal TypeAttr(String type)
        {
            this.Value = type;
        }
        public String Value { get; private set; }
    }

    public static class TypeExtensions
    {
        public static String GetValue(this RecommendationType enumChoice)
        {
            var attr = enumChoice.GetAttribute<TypeAttr>();
            return attr.Value;
        }
    }
}
