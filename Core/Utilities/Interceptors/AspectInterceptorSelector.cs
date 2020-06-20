using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
	public class AspectInterceptorSelector:IInterceptorSelector
	{
		public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
		{
			var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit: true).ToList();
			var methodAttribute = type.GetMethod(method.Name)
				.GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit: true);
			classAttributes.AddRange(methodAttribute);

			return classAttributes.OrderBy(x => x.Priority).ToArray();
		}
	}
}
