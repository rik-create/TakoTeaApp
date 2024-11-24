using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.Interfaces;
using TakoTea.Models;

namespace TakoTea.Services
{
    public class BatchService : IBatchService
    {
        public void AddBatch(Batch batch)
        {
            using (var context = new Entities())
            {
                context.Batches.Add(batch);

                context.SaveChanges();
            }
        }


    }
}
