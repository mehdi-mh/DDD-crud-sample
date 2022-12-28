using Application.Service.Customers.Commands.AddCustomer;
using Application.Service.Customers.Commands.EditCustomer;
using Application.Service.Customers.Dto;
using Application.Service.Customers.Queries;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace CRUD_Test
{
    [TestClass]
    public class UnitTests
    {
        public DatabaseContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            var cs =
                "Server=localhost;Database=crud-project;Trusted_Connection=True;User Id=sa;Password=sapassword!;TrustServerCertificate=True";
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(cs)
                .Options;
            var databaseContext = new DatabaseContext(options);
            databaseContext.Database.EnsureCreated();
            _context = databaseContext;
        }

        [TestMethod]
        public void Add_Customer_Valid_Returns_Success()
        {
            var service = new AddCustomerService(_context);
            var dto = new RequestAddCustomerDto()
            {
                Firstname = "Mehdi",
                Lastname = "Hosseini",
                PhoneNumber = "2024561111",
                BankAccountNumber = "ABCD12345",
                DateOfBirth = new DateTime(1981, 09, 14),
                Email = "a1@a.com"
            };
            var result1 = service.Execute(dto);

            dto = new RequestAddCustomerDto()
            {
                Firstname = "Ali",
                Lastname = "Hosseini",
                PhoneNumber = "2024561111",
                BankAccountNumber = "ABCD12345",
                DateOfBirth = new DateTime(1979, 01, 01),
                Email = "a2@a.com"
            };
           var result2 = service.Execute(dto);

            Assert.AreEqual(true, result1.IsSuccess);
            Assert.AreEqual(true, result2.IsSuccess);
        }

        [TestMethod]
        public void Add_Customer_InValid_Returns_Error()//INVALID EMAIL
        {
            var service = new AddCustomerService(_context);
            var dto = new RequestAddCustomerDto()
            {
                Firstname = "A",
                Lastname = "B",
                PhoneNumber = "2024561111",
                BankAccountNumber = "ABCD12345",
                DateOfBirth = new DateTime(1981, 09, 14),
                Email = "a"
            };
            var result2 = service.Execute(dto);

            Assert.AreEqual(true, result2.IsSuccess);
        }

        [TestMethod]
        public void Edit_Customer_Valid_Returns_Success()//PLEASE PROVIDE VALID ID
        {
            var editCustomerService = new EditCustomerService(_context);

            var dto = new RequestEditCustomerDto()
            {
                Id = 23,
                Firstname = "Reza",
                Lastname = "Hosseini",
                PhoneNumber = "2024561111",
                BankAccountNumber = "ABCD12345",
                DateOfBirth = new DateTime(1981, 09, 14),
                Email = "A@a.com"
            };
            var result = editCustomerService.Execute(dto);

            Assert.AreEqual(true, result.IsSuccess);
        }

        [TestMethod]
        public void Edit_Customer_InValid_Returns_Error()//PLEASE PROVIDE VALID ID -- Invalid email
        {
            var editCustomerService = new EditCustomerService(_context);

            var dto = new RequestEditCustomerDto()
            {
                Id = 10,
                Firstname = "A",
                Lastname = "B",
                PhoneNumber = "2024561111",
                BankAccountNumber = "ABCD12345",
                DateOfBirth = new DateTime(1981, 09, 14),
                Email = "A"
            };
            var result = editCustomerService.Execute(dto);

            Assert.AreEqual(true, result.IsSuccess);
        }

        [TestMethod]
        public void Get_All_Customer_Return_List()
        {
            var editCustomerService = new GetCustomersService(_context);
            var result = editCustomerService.Execute();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }
    }
}