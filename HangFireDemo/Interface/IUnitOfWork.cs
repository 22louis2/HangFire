using HangFireDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Interface
{
    public interface IUnitOfWork
    {
        Task<bool> Save();
    }
}
