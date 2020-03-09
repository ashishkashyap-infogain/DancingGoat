using System;
using System.Collections.Generic;
using Business.Dto.Coffee;

namespace Business.Repository.Coffee
{
    public interface ICoffeeRepository
    {
        CoffeeDto GetCoffee(Guid nodeGuid);
        IEnumerable<CoffeeDto> GetCoffees();
    }
}