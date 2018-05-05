// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using EnterpriseLibrary.Common.Configuration.Design;
using EnterpriseLibrary.Validation.Configuration;

[assembly: SecurityTransparent]

[assembly: ComVisible(false)]

[assembly: HandlesSection(ValidationSettings.SectionName)]
[assembly: AddApplicationBlockCommand(
                ValidationSettings.SectionName,
                typeof(ValidationSettings),
                TitleResourceType = typeof(DesignResources),
                TitleResourceName = "AddValidationSettings")]
