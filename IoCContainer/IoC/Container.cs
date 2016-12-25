using System;
using System.Collections.Generic;

namespace IoCContainer.IoC
{
    public enum IoCLifeCycle
    {
        Singleton = 1,
    }
    public class Container
    {

        private Dictionary<Type, Type> typeToImplementation;
        private Dictionary<Type, object> singletonInstances;


        public Container()
        {
            typeToImplementation = new Dictionary<Type, Type>();
            singletonInstances = new Dictionary<Type, object>();
        }

        public void Register<TInterface, TImplementation>()
        {
            typeToImplementation[typeof(TInterface)] = typeof(TImplementation);
        }

        public void Register<TInterface, TImplementation>(IoCLifeCycle lifeCycle)
        {
            typeToImplementation[typeof(TInterface)] = typeof(TImplementation);

            if (lifeCycle == IoCLifeCycle.Singleton)
            {
                singletonInstances[typeof(TInterface)] = Activator.CreateInstance(typeToImplementation[typeof(TInterface)]);
            }
        }

        public TInterface GetImplementation<TInterface>()
        {
            if (singletonInstances.ContainsKey(typeof(TInterface)))
            {
                return (TInterface)singletonInstances[typeof(TInterface)];
            }

            return (TInterface)Activator.CreateInstance(typeToImplementation[typeof(TInterface)]);
        }

        public object Resolve(Type contract)
        {
            if (typeToImplementation.ContainsKey(contract))
            {
                return typeToImplementation[contract];
            }
            return null;
        }
    }
}
