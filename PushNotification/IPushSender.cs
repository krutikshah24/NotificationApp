﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushNotification
{
    public interface IPushSender
    {
        Task SendAsync(PushDefault pushDefault);

    }
}
