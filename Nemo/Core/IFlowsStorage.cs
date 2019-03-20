using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemo.Core
{
    public interface IFlowsStorage
    {
        //stores flows into the specified XML file
        void Store(List<Flow> flows, string storageString);
        //loads flows from the specified XML file
        List<Flow> Load(string file);
    }
}
