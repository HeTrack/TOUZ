using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tour_TUI_Operator.Interfaces
{
    public interface IRepository
    {
        Task InitializeDataContext();
    }
}
