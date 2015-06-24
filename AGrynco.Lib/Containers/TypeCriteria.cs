#region Usings
using System;
using System.Diagnostics;
using System.Reflection;
#endregion

namespace AGrynco.Lib.Containers
{
    public class TypeCriteria
    {
        #region Fields (private)
        private readonly Assembly[] _assemblies;
        private readonly Type[] _attributeTypes;
        #endregion

        #region Constructors
        public TypeCriteria(Assembly[] assemblies, Type[] attributeTypes)
        {
            _assemblies = assemblies;
            _attributeTypes = attributeTypes;
        }

        public TypeCriteria(Type[] assemblyIdentifiers, Type[] attributeTypes)
            : this(FromTypes(assemblyIdentifiers), attributeTypes)
        {
        }
        #endregion

        #region Static Methods (private)
        private static Assembly[] FromTypes(Type[] assemblyIdentifiers)
        {
            Assembly[] result = new Assembly[assemblyIdentifiers.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Assembly.GetAssembly(assemblyIdentifiers[i]);
            }
            return result;
        }
        #endregion

        #region Properties (public)
        public Assembly[] Assemblies
        {
            [DebuggerStepThrough]
            get { return _assemblies; }
        }

        public Type[] AttributeTypes
        {
            [DebuggerStepThrough]
            get { return _attributeTypes; }
        }
        #endregion
    }
}