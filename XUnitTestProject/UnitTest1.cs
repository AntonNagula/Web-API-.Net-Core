using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Core;
using WebApi.Controllers;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;
using System.Text;

namespace XUnitTestProject
{
    public class UnitTest1 : IntegrationTest
    {
        [Fact]
        public async Task Test1()
        {
            var response = await TestClient.GetAsync("api/cities");
           
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
        [Fact]
        public async Task Test2()
        {            
            var response = await TestClient.GetAsync("api/contries");

            response.StatusCode.Should().Be(HttpStatusCode.OK);  
            response.Content.Should().NotBeNull();
        }
        [Fact]
        public async Task Test3()
        {
            var response = await TestClient.GetAsync("api/roles");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
        [Fact]
        public async Task Test4()
        {
            var response = await TestClient.GetAsync("api/hotels");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
        [Fact]
        public async Task Test5()
        {
            var response = await TestClient.GetAsync("api/tours");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
        [Fact]
        public async Task Test6()
        {
            var response = await TestClient.GetAsync("api/users");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
        [Fact]
        public async Task Test7()
        {
            var response = await TestClient.GetAsync("api/vouchers");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
        [Fact]
        public async Task Test8()
        {
            var response = await TestClient.GetAsync("api/hotels/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Hotel hotel = await response.Content.ReadAsAsync<Hotel>();
            hotel.CityId.Should().Be("1");
        }
        [Fact]
        public async Task Test9()
        {
            var response = await TestClient.GetAsync("api/cities/1");
                        
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            City city = await response.Content.ReadAsAsync<City>();
            city.CityId.Should().Be("1");
        }
        [Fact]
        public async Task Test10()
        {
            var response = await TestClient.GetAsync("api/contries/2");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Country country = await response.Content.ReadAsAsync<Country>();
            country.Name.Should().Be("Италия");
        }

        [Fact]
        public async Task Test11()
        {
            var response = await TestClient.GetAsync("api/tours/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Tour tour = await response.Content.ReadAsAsync<Tour>();
            tour.Name.Should().Be("Минск-Барселон");
        }
        [Fact]
        public async Task Test12()
        {
            var response = await TestClient.GetAsync("api/users/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            User user = await response.Content.ReadAsAsync<User>();
            user.Email.Should().Be("anton@mail.ru");
        }
        [Fact]
        public async Task Test13()
        {
            var response = await TestClient.GetAsync("api/vouchers/2");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Voucher voucher = await response.Content.ReadAsAsync<Voucher>();
            voucher.TourId.Should().Be("2");
        }
        [Fact]
        public async Task Test14()
        {
            var response = await TestClient.DeleteAsync("api/vouchers/2");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task Test15()
        {
            var response = await TestClient.DeleteAsync("api/tours/3");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task Test16()
        {
            var response = await TestClient.DeleteAsync("api/users/5");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task Test17()
        {
            var cities1 = await TestClient.GetAsync("api/cities");
            List<City> cities_list1 = await cities1.Content.ReadAsAsync<List<City>>();
            var response = await TestClient.PostAsync("api/cities", new StringContent(JsonConvert.SerializeObject(new City { CountryId = "1", RusName = "Мадрид" }), Encoding.UTF8, "application/json"));

            var cities2 = await TestClient.GetAsync("api/cities");


            List<City> cities_list2 = await cities2.Content.ReadAsAsync<List<City>>();

            Assert.Equal(cities_list1.Count + 1, cities_list2.Count);
        }
        [Fact]
        public async Task Test18()
        {
            var response = await TestClient.DeleteAsync("api/hotels/1");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Test19()
        {
            var response = await TestClient.DeleteAsync("api/hotels/3");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task Test20()
        {
            var response1 = await TestClient.GetAsync("api/contries");
            response1.StatusCode.Should().Be(HttpStatusCode.OK);
            List<Country> countries_list1 = await response1.Content.ReadAsAsync<List<Country>>();
            var response2 = await TestClient.DeleteAsync("api/contries/11");
            var response3 = await TestClient.GetAsync("api/contries");
            response3.StatusCode.Should().Be(HttpStatusCode.OK);
            List<Country> countries_list3 = await response3.Content.ReadAsAsync<List<Country>>();

            Assert.Equal(countries_list1.Count-1,countries_list3.Count);
        }
    }
}
