namespace CSharpCore.Pages.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AtAttribute : Attribute
    {
        private readonly string url;

        public AtAttribute(string url)
        {
            this.url = url;
        }

        public string GetAt()
        {
            return this.url;
        }
    }
}
