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
        public IActionResult Get()
        {
            IEnumerable<Voucher> vouchers = service.GetVouchers();
            return Ok(vouchers);
        }

        [HttpGet("{id}")]
        public IActionResult GetVoucher([FromRoute]int id)
        {
            return Ok(service.GetVoucher(id));
        }

        [HttpPost]
        public IActionResult CreateVoucher([FromBody]Voucher voucher)
        {
            service.CreateVoucher(voucher);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVoucher([FromRoute]int id)
        {
            service.DeleteVoucher(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateVoucher([FromBody]Voucher voucher)
        {
            service.UpdateVoucher(voucher);
            return Ok();
        }
    }
}