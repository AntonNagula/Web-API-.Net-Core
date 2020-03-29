using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using Data.Mappers;
using System.Linq;
namespace Data.Repositories
{
    public class VoucherRepository : IGenericRepository<Voucher>
    {
        private ProjectDbContext database;
        public VoucherRepository(ProjectDbContext db)
        {
            database = db;
        }
        public void Create(Voucher item)
        {
            database.Vouchers.Add(item.ToVoucherDB());
            database.SaveChanges();
        }

        public void Delete(int id)
        {
            Entities.Voucher voucher = database.Vouchers.FirstOrDefault(x => x.VoucherId == id);
            database.Vouchers.Remove(voucher);
            database.SaveChanges();
        }

        public Voucher Get(int id)
        {
            return database.Vouchers.FirstOrDefault(x => x.VoucherId == id).ToVoucherApp();
        }

        public IEnumerable<Voucher> GetAll()
        {
            return database.Vouchers.Select(x => x.ToVoucherApp()).ToList();
        }

        public void Update(Voucher item)
        {
            int id = Int32.Parse(item.VoucherId);
            Entities.Voucher voucher = database.Vouchers.FirstOrDefault(x => x.VoucherId == id);
            voucher.UpdateVoucherDB(item);
            database.Vouchers.Update(voucher);
            database.SaveChanges();
        }
    }
}
