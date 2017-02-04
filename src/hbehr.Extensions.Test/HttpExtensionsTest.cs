using NUnit.Framework;
using System.Web;

namespace hbehr.Extensions.Test
{
    [TestFixture]
    public class HttpExtensionsTest
    {
        [Test]
        public void TestIsAjaxRequest()
        {
            var request = new HttpRequest("filename", "https://www.teste.com.br", "lele=lala&lili=lulu");
            Assert.IsFalse(request.IsAjaxRequest());

            //request.Headers.Add("X-Requested-With", "XMLHttpRequest"); <- throws exception :(, can't mock Sealed class..
            //Assert.IsTrue(request.IsAjaxRequest());

            request = null;
            Assert.IsFalse(request.IsAjaxRequest());
        }
    }
}
