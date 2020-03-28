using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesService;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Export;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        IService service;
        public VouchersController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        public Export<Voucher> Get()
        {
            IEnumerable<Voucher> vouchers = service.GetVouchers();
            Export<Voucher> obj = new Export<Voucher>();
            obj.obj = vouchers;
            return obj;
        }

        [HttpGet("{id}")]
        public Voucher GetVoucher([FromRoute]int id)
        {
            return service.GetVoucher(id);
        }

        [HttpPost]
        public void CreateVoucher([FromBody]Voucher voucher)
        {
            service.CreateVoucher(voucher);
        }

        [HttpDelete("{id}")]
        public void DeleteVoucher([FromRoute]int id)
        {
            service.DeleteVoucher(id);
        }
        [HttpPut]
        public void UpdateVoucher([FromBody]Voucher voucher)
        {
            service.UpdateVoucher(voucher);
        }
    }
}