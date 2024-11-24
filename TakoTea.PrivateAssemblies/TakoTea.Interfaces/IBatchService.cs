using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.Models;

namespace TakoTea.Interfaces
{
    public interface IBatchService
    {
        void AddBatch(Batch batch);
    }
}
