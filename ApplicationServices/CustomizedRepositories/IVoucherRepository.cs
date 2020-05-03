using Core;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IVoucherRepository : IGenericRepository<Voucher>
    {
        IEnumerable<VoucherAndTourInfo> GetActualVouchersByUserId(int id);
    }
}
