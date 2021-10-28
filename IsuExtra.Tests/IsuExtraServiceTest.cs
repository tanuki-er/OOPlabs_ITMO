using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class Tests
    {
        private IsuExtra.Services.IIsuExtraService _isuExtraService;

        [SetUp]
        public void Setup()
        {
            _isuExtraService = new IsuExtra.Services.IsuExtraService();
        }
    }
}