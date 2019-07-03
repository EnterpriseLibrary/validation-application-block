using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WPF.Tests
{
    // WPF tests need to run from a STA thread, but .NET Core defaults to MTA
    public class STATestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                return base.Execute(testMethod);
            }

            TestResult[] result = null;
            var thread = new Thread(() => result = base.Execute(testMethod));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return result;
        }
    }
}
