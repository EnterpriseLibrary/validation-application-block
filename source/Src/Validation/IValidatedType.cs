// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.EnterpriseLibrary.Validation
{
    /// <summary>
    /// Represents the description of how validation must be performed on a type.
    /// </summary>
    public interface IValidatedType : IValidatedElement
    {
        /// <summary>
        /// Gets the <see cref="IValidatedElement"/> instances representing the properties on the validated type.
        /// </summary>
        /// <returns>The validated properties.</returns>
        IEnumerable<IValidatedElement> GetValidatedProperties();

        /// <summary>
        /// Gets the <see cref="IValidatedElement"/> instances representing the fields on the validated type.
        /// </summary>
        /// <returns>The validated fields.</returns>
        IEnumerable<IValidatedElement> GetValidatedFields();

        /// <summary>
        /// Gets the <see cref="IValidatedElement"/> instances representing the methods on the validated type.
        /// </summary>
        /// <returns>The validated methods.</returns>
        IEnumerable<IValidatedElement> GetValidatedMethods();

        /// <summary>
        /// Gets the self-validation methods on the validated type.
        /// </summary>
        /// <returns>The self-validation methods.</returns>
        IEnumerable<MethodInfo> GetSelfValidationMethods();
    }
}
