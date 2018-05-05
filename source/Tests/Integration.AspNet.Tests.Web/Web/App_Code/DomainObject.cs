using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EnterpriseLibrary.Validation.Validators;
using EnterpriseLibrary.Validation.TestSupport.TestClasses;
using System.Diagnostics;

namespace DomainModel
{
    public class DomainObject
    {
        public DomainObject(string name, string surName, int numberProperty, TraceOptions enumProperty)
        {
            this.name = name;
            this.surName = surName;
            this.numberProperty = numberProperty;
            this.enumProperty = enumProperty;
        }

        private string name;
        [StringLengthValidator(10, MessageTemplate = "invalid name from attribute")]
        [PropertyComparisonValidator("SurName", ComparisonOperator.NotEqual, Ruleset = "cross field")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surName;
        public string SurName
        {
            get { return surName; }
            set { surName = value; }
        }

        private int numberProperty;
        [MockValidator(true)]
        public int NumberProperty
        {
            get { return numberProperty; }
            set { numberProperty = value; }
        }

        private string propertyWithMultipleMessages;
        [MockValidator(true, MessageTemplate = "message 1")]
        [MockValidator(true, MessageTemplate = "message 2")]
        public string PropertyWithMultipleMessages
        {
            get { return propertyWithMultipleMessages; }
            set { propertyWithMultipleMessages = value; }
        }

        private TraceOptions enumProperty;
        [MockValidator(true)]
        public TraceOptions EnumProperty
        {
            get { return enumProperty; }
            set { enumProperty = value; }
        }
    }
}
