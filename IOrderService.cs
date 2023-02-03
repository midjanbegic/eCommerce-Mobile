using Devision.eCommerce.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devision.eCommerce.Mobile.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetList();
    }
}
