using System;
using System.Threading.Tasks;

namespace FinanceLatest.Interfaces
{
    public interface IShare
    {
        Task Show(String title, string Url);
    }
}
