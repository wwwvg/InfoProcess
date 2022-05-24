using Prism.Events;
using System.Collections.Generic;

namespace Information.Events
{
    public class ProcessChanged : PubSubEvent<KeyValuePair<int, string>>
    {

    }
}
