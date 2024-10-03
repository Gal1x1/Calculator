using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Calculator.Services;

public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        // Register your services here
        container.RegisterType<ICalculationService, CalculationService>();

        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
}
