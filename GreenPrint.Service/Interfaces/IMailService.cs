using GreenPrint.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Interfaces
{
    public interface IMailService
    {
        /// <summary>
        /// Sends a mail to the user to confirm the order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task SendOrderConfirmMail(OrderDTO order);

        /// <summary>
        /// Sends a test mail to the user
        /// </summary>
        /// <returns></returns>
        Task SendTestMail();
    }
}
