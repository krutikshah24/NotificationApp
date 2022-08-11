using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushNotification
{
    public class PushSender : IPushSender
    {

        public virtual Task SendAsync(PushDefault pushDefault)
        {
            throw new NotImplementedException();
        }
    }
}
