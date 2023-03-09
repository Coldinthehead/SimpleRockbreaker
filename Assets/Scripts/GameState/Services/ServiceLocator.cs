using System;
using System.Collections.Generic;

namespace Scripts.GameState.Services
{

    public class ServiceLocator
    {
        private Dictionary<Type, IService> _servicesMap = new();


        public static ServiceLocator _instance;

        public static ServiceLocator Container
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new();
                }
                return _instance;
            }
        }

        public void Register<T>(T impl) where T : IService
        {
            _servicesMap[typeof(T)] = impl;
        }

        public T Single<T>() where T : class,IService
        {
            T item = _servicesMap[typeof(T)] as T;
            return item;
        }
    }
}