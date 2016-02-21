using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Domain.Concrete;
using Domain.Concrete.Interfaces;
using Domain.Concrete.Repositories;
using Ninject;

namespace CarSellApp.Infrastructure
{
	public class NinjectControllerFactory : DefaultControllerFactory
	{
		private IKernel ninjectKernel;

		public NinjectControllerFactory()
		{
			ninjectKernel = new StandardKernel();
			AddBindings();
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			return controllerType == null
				? null
				: (IController) ninjectKernel.Get(controllerType);
		}

		private void AddBindings()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			ninjectKernel.Bind<EFDbContext>().ToSelf().InSingletonScope().WithConstructorArgument("connectionString", connectionString);

			ninjectKernel.Bind<ICarRepository>().To<CarRepository>();
			ninjectKernel.Bind<IManufacturerRepository>().To<ManufacturerRepository>();
			ninjectKernel.Bind<IEquipmentRepository>().To<EquipmentRepository>();

			ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
		}
	}
}