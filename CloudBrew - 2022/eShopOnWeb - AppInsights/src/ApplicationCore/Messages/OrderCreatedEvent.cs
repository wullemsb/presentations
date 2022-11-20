using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Messages;
public class OrderCreatedEvent
{
    public string BuyerId { get; set; }
}
