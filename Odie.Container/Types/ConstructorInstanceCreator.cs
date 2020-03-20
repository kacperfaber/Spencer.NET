using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorInstanceCreator : IConstructorInstanceCreator
    {
        public IConstructorProvider ConstructorProvider;
        public IConstructorParametersGenerator ParametersGenerator;
        public IConstructorInvoker ConstructorInvoker;
        public IConstructorListGenerator ConstructorListGenerator;
        public IConstructorFinder ConstructorFinder;

        public ConstructorInstanceCreator(IConstructorInvoker constructorInvoker, IConstructorParametersGenerator parametersGenerator, IConstructorProvider constructorProvider)
        {
            ConstructorInvoker = constructorInvoker;
            ParametersGenerator = parametersGenerator;
            ConstructorProvider = constructorProvider;
        }

        public object CreateInstance(ServiceFlags flags, Type @class, IContainer container)
        {
            ConstructorInfo constructor = ConstructorProvider.ProvideConstructor(@class, flags);
            IEnumerable<object> parameters = ParametersGenerator.GenerateParameters(constructor, flags, container);
            object instance = ConstructorInvoker.InvokeConstructor(constructor, parameters);

            return instance;
        }

        public object CreateInstance(Type @class, IContainer container)
        {
            ConstructorInfo constructor = ConstructorProvider.ProvideConstructor(@class);
            IEnumerable<object> parameters = ParametersGenerator.GenerateParameters(constructor, container);
            object instance = ConstructorInvoker.InvokeConstructor(constructor, parameters);

            return instance;
        }

        public object CreateInstance(Type @class, IRegisterParameters registerParameter)
        {
            // implement one list of ctors in all of methods. TODO
            ConstructorInfo[] constructors = ConstructorListGenerator.GenerateList(@class);
            ConstructorInfo constructor = ConstructorFinder.FindBy(constructors, registerParameter);
            IEnumerable<object> parameters = ParametersGenerator.GenerateParameters(constructor, registerParameter);
            object instance = ConstructorInvoker.InvokeConstructor(constructor, parameters);

            return instance;
        }
    }
}