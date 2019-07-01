// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace Microsoft.Practices.EnterpriseLibrary.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberAccessValidatorBuilderFactory
    {
        internal static readonly MemberAccessValidatorBuilderFactory Default = new MemberAccessValidatorBuilderFactory();

        private MemberValueAccessBuilder valueAccessBuilder;

        /// <summary>
        /// 
        /// </summary>
        public MemberAccessValidatorBuilderFactory()
            : this(new ReflectionMemberValueAccessBuilder())
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueAccessBuilder"></param>
        public MemberAccessValidatorBuilderFactory(MemberValueAccessBuilder valueAccessBuilder)
        {
            this.valueAccessBuilder = valueAccessBuilder;
        }

        /// <summary>
        /// Returns an object that will build a ValueAccessValidator for <paramref name="propertyInfo"/> with the supplied 
        /// validation modifiers.
        /// </summary>
        /// <returns>A <see cref="ValueAccessValidatorBuilder"/> for the supplied parameters.</returns>
        /// <exception cref="ArgumentNullException">when <paramref name="propertyInfo"/> is <see langword="null"/>.</exception>
        public virtual ValueAccessValidatorBuilder GetPropertyValueAccessValidatorBuilder(PropertyInfo propertyInfo, IValidatedElement validatedElement)
        {
            return new ValueAccessValidatorBuilder(this.valueAccessBuilder.GetPropertyValueAccess(propertyInfo),
                validatedElement);
        }

        /// <summary>
        /// Returns an object that will build a ValueAccessValidator for <paramref name="fieldInfo"/> with the supplied 
        /// validation modifiers.
        /// </summary>
        /// <returns>A <see cref="ValueAccessValidatorBuilder"/> for the supplied parameters.</returns>
        /// <exception cref="ArgumentNullException">when <paramref name="fieldInfo"/> is <see langword="null"/>.</exception>
        public virtual ValueAccessValidatorBuilder GetFieldValueAccessValidatorBuilder(FieldInfo fieldInfo, IValidatedElement validatedElement)
        {
            return new ValueAccessValidatorBuilder(this.valueAccessBuilder.GetFieldValueAccess(fieldInfo),
                validatedElement);
        }

        /// <summary>
        /// Returns an object that will build a ValueAccessValidator for <paramref name="methodInfo"/> with the supplied 
        /// validation modifiers.
        /// </summary>
        /// <returns>A <see cref="ValueAccessValidatorBuilder"/> for the supplied parameters.</returns>
        /// <exception cref="ArgumentNullException">when <paramref name="methodInfo"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">when <paramref name="methodInfo"/> returns <see langword="void"/>.</exception>
        /// <exception cref="ArgumentException">when <paramref name="methodInfo"/> has parameters.</exception>
        public virtual ValueAccessValidatorBuilder GetMethodValueAccessValidatorBuilder(MethodInfo methodInfo, IValidatedElement validatedElement)
        {
            return new ValueAccessValidatorBuilder(this.valueAccessBuilder.GetMethodValueAccess(methodInfo),
                validatedElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="validatedElement"></param>
        /// <returns></returns>
        public virtual CompositeValidatorBuilder GetTypeValidatorBuilder(Type type, IValidatedElement validatedElement)
        {
            if (null == type)
                throw new ArgumentNullException("type");

            return new CompositeValidatorBuilder(validatedElement);
        }

        /// <summary>
        /// 
        /// </summary>
        public MemberValueAccessBuilder MemberValueAccessBuilder
        {
            get { return this.valueAccessBuilder; }
        }
    }
}
