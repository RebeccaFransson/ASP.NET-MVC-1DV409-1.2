using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using rf222cz_1_2_aventyrliga_kontakter.Models.Repositories;

namespace rf222cz_1_2_aventyrliga_kontakter
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IRepository, Repositroy>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}