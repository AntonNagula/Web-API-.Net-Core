using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IVoucherRepository
    {
        IEnumerable<Voucher> GetAll();
        Voucher Get(int id);
        void Create(Voucher item);
        void Update(Voucher item);
        void Delete(int id);
    }
}
