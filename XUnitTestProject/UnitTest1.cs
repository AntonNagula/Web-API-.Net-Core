using Business;
using BusinesService;
using Core;
using Data;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Controllers;
using WebApi.Export;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        private readonly ProjectDbContext context;
        private readonly IUnitOfWork unitOfWork;
        private readonly IService service;
        private readonly CitiesController Citycontroller;
        private readonly ContriesController Contrycontroller;
        private readonly HotelsController Hotelcontroller;
        private readonly RolesController Rolescontroller;
        private readonly ToursController Tourcontroller;
        private readonly UsersController Usercontroller;
        private readonly VouchersController Vouchercontroller;
        public UnitTest1()
        {
            context = new ProjectDbContext();
            unitOfWork = new UnitOfWork(context);
            service = new Service(unitOfWork);
            Citycontroller = new CitiesController(service);
            Contrycontroller = new ContriesController(service);
            Hotelcontroller = new HotelsController(service);
            Vouchercontroller = new VouchersController(service);
            Rolescontroller = new RolesController(service);
            Tourcontroller = new ToursController(service);
            Usercontroller = new UsersController(service);
        }
        [Fact]
        public void Test1()
        {
            Export<Country> obj = Contrycontroller.Get();
            IEnumerable<Country> cities = obj.obj;
            Assert.NotNull(cities);
        }
        [Fact]
        public void Test2()
        {
            Export<City> obj = Citycontroller.Get();
            IEnumerable<City> cities = obj.obj;
            Assert.NotNull(cities);
        }
        [Fact]
        public void Test3()
        {
            Export<Hotel> obj = Hotelcontroller.Get();
            IEnumerable<Hotel> hotels = obj.obj;
            Assert.NotNull(hotels);
        }
        [Fact]
        public void Test4()
        {
            Export<Role> obj = Rolescontroller.GetRoles();
            IEnumerable<Role> roles = obj.obj;
            Assert.NotNull(roles);
        }
        [Fact]
        public void Test5()
        {
            Export<Tour> tour = Tourcontroller.Get();
            IEnumerable<Tour> toures = tour.obj;
            Assert.NotNull(toures);
        }
        [Fact]
        public void Test6()
        {
            Export<User> obj = Usercontroller.GetUsers();
            IEnumerable<User> users = obj.obj;
            Assert.NotNull(users);
        }
        [Fact]
        public void Test7()
        {
            Export<Voucher> obj = Vouchercontroller.Get();
            IEnumerable<Voucher> vouchers = obj.obj;
            Assert.NotNull(vouchers);
        }

        [Fact]
        public void Test8()
        {
            City obj = Citycontroller.GetCity(1);
            Assert.NotNull(obj);
        }
        [Fact]
        public void Test9()
        {
            Country contry = Contrycontroller.GetContry(1);
            Assert.NotNull(contry);
        }
        [Fact]
        public void Test10()
        {
            Hotel hotel = Hotelcontroller.GetHotel(1);
            Assert.NotNull(hotel);
        }
        [Fact]
        public void Test11()
        {
            Tour tour = Tourcontroller.GetTour(1);
            Assert.NotNull(tour);
        }
        [Fact]
        public void Test12()
        {
            User user = Usercontroller.GetUser(1);
            Assert.NotNull(user);
        }
        [Fact]
        public void Test13()
        {            
            Voucher voucher = Vouchercontroller.GetVoucher(1);
            Assert.NotNull(voucher);
        }
        
    }
}
