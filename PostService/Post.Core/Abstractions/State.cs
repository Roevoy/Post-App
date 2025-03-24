using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Core.Abstractions
{
    public enum State
    {
        Preparing,
        Sent,
        Delivered,
        Received
    }
}
