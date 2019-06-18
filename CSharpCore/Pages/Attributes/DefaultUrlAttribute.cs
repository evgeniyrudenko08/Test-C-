namespace CSharpCore.Pages.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DefaultUrlAttribute : Attribute
    {
        private readonly string url;

        public DefaultUrlAttribute(string url)
        {
            this.url = url;
        }

        public string GetUrl()
        {
            return this.url;
        }
    }
}
