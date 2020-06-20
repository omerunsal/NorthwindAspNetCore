using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ProductManager>().As<IProductService>();
			builder.RegisterType<CategoryManager>().As<ICategoryService>();
			builder.RegisterType<UserManager>().As<IUserService>();
			builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
			builder.RegisterType<EfProductDal>().As<IProductDal>();
			builder.RegisterType<EfUserDal>().As<IUserDal>();

			builder.RegisterType<AuthManager>().As<IAuthService>();
			builder.RegisterType<JwtHelper>().As<ITokenHelper>();

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
			{
				Selector = new AspectInterceptorSelector()
			}).SingleInstance();
		}
	}
}
