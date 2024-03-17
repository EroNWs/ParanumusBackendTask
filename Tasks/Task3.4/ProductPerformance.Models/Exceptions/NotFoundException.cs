using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPerformance.Models.Exceptions;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message)
    {

    }

}

public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(int id) : base($"The Product with id : {id} Could not Found!")
    {

    }
}
