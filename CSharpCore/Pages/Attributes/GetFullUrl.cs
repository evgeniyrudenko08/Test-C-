namespace CSharpCore.Pages.Attributes
{
    using OpenQA.Selenium;

    public class GetFullUrl
    {
        public GetFullUrl()
        {
        }

        protected IWebDriver Driver { get; private set; }

        public static string GetUrl(object page)
        {
            string url = "/";
            foreach (DefaultUrlAttribute defaultUrlurl in page.GetType().GetCustomAttributes(typeof(DefaultUrlAttribute), true))
            {
                url = defaultUrlurl.GetUrl();
            }

            return url;
        }

        public bool IsCurrentPage()
        {
            string expectedKeyWord = string.Empty;

            foreach (AtAttribute keyWordAt in GetType().GetCustomAttributes(typeof(AtAttribute), true))
            {
                expectedKeyWord = keyWordAt.GetAt();
            }

            return Driver.Url.Contains(expectedKeyWord);
        }
    }
}
