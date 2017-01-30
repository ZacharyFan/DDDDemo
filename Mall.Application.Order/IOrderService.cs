using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mall.Application.Order.DTO;
using Mall.Infrastructure.Results;

namespace Mall.Application.Order
{
    public interface IOrderService
    {
        Result Create(OrderRequest orderRequest);
    }
}
