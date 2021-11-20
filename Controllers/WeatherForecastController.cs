using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DependencyService1 _service1;
        private readonly DependencyService2 _service2;
        private readonly IEnumerable<IOperationSingletonInstance> _allOperationSingletonInstances;

        public WeatherForecastController(DependencyService1 service1,DependencyService2 service2,IEnumerable<IOperationSingletonInstance> allOperationSingletonInstances)
        {
            _service1 = service1;
            _service2 = service2;
            _allOperationSingletonInstances = allOperationSingletonInstances;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _service1.Write();
            _service2.Write();
            Console.WriteLine();
            foreach (var item in _allOperationSingletonInstances)
                Console.WriteLine(item.OperationId);
            return  Enumerable.Empty<WeatherForecast>();
        }
    }
}
