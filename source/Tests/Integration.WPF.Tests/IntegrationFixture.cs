// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWC = System.Windows.Controls;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WPF.Tests
{
    [TestClass]
    public class IntegrationFixture
    {
        [TestInitialize]
        public void TestInitialize()
        {
            using (var configSource = new SystemConfigurationSource(false))
            {
                ValidationFactory.SetDefaultConfigurationValidatorFactory(configSource);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ValidationFactory.Reset();
        }

        [STATestMethod]
        public void CanValidateWithExplicitlySuppliedValidatorRule()
        {
            var control = new ControlWithExplicitRule();

            var textBox = control.TextBox1;

            textBox.Text = "bbbbbbbbbbb";

            Assert.IsTrue(SWC.Validation.GetHasError(textBox));
            Assert.AreEqual("invalid string", SWC.Validation.GetErrors(textBox).First().ErrorContent);
        }

        [STATestMethod]
        public void CanValidateWithValidatorRuleSpecifiedWithAttachedProperties()
        {
            var control = new ControlWithExplicitRule();

            var textBox = control.TextBox1;

            textBox.Text = "bbbbbbbbbbb";

            Assert.IsTrue(SWC.Validation.GetHasError(textBox));
            Assert.AreEqual("invalid string", SWC.Validation.GetErrors(textBox).First().ErrorContent);
        }

        [STATestMethod]
        public void CanValidateWithValidatorRuleSpecifiedWithAttachedPropertiesUsingRuleset()
        {
            var control = new ControlWithImplicitRuleWithRulesetAndSource();

            var textBox = control.TextBoxWithRuleset;

            textBox.Text = "bbbbbbbbbbb";

            Assert.IsTrue(SWC.Validation.GetHasError(textBox));
            Assert.AreEqual("invalid string ruleset", SWC.Validation.GetErrors(textBox).First().ErrorContent);
        }

        [STATestMethod]
        public void CanValidateWithValidatorRuleSpecifiedWithAttachedPropertiesUsingSpecificationSource()
        {
            var control = new ControlWithImplicitRuleWithRulesetAndSource();

            var textBox = control.TextBoxWithSource;

            textBox.Text = "bbbbbbbbbbb";

            Assert.IsTrue(SWC.Validation.GetHasError(textBox));
            Assert.AreEqual("invalid string: vab", SWC.Validation.GetErrors(textBox).First().ErrorContent);
        }


        [STATestMethod]
        public void TwoWayBindingFiresValidationWhenUIChanges()
        {
            var control = new ControlWithImplicitRuleWithRulesetAndSource();
            var textBox = control.TextBoxWithTwoWayBinding;

            textBox.Text = "bbbbbbbbbbb";

            Assert.IsTrue(SWC.Validation.GetHasError(textBox));

            Assert.AreEqual("String must be one character", SWC.Validation.GetErrors(textBox).First().ErrorContent);
        }

        [STATestMethod]
        public void TwoWayBindingFiresValidationWhenSourceChanges()
        {
            var control = new ControlWithImplicitRuleWithRulesetAndSource();
            var textBox = control.TextBoxWithTwoWayBinding;
            var source = (ValidatedObject)control.Resources["validated"];

            source.TwoWayValidatedStringProperty = "Hello";

            Assert.IsTrue(SWC.Validation.GetHasError(textBox));

            Assert.AreEqual("String must be one character", SWC.Validation.GetErrors(textBox).First().ErrorContent);
        }
    }
}
