using Entities.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Helpers
{
    public interface ICartSessionHelper
    {
        Cart Getcart();
        void SetCart(Cart cart);
        void Clear();
    }
}
