using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Calculator.Services;
using Calculator.Data.Repositories;

public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        // Register your services here
        container.RegisterType<ICalculationService, CalculationService>();
        container.RegisterType<ICalculationLogRepository, CalculationLogRepository>();

        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
}
