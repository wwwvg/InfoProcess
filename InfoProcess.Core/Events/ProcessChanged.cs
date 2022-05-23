using Prism.Events;
using System.Collections.Generic;

namespace InfoProcess.Core.Events
{
    public class ProcessChanged : PubSubEvent<KeyValuePair<int, string>>
    {

    }
}
