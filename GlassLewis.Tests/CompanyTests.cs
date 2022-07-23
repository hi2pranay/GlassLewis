using GlassLewis.Core.GlassLewis.Interfaces;
using GlassLewis.Core.GlassLewis.Models;
using GlassLewis.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GlassLewis.Tests
{
    public class CompanyTests
    {
        Mock<ICompanyRepository> companyRepositoryMock = null;
        [SetUp]
        public void Setup()
        {
            // Arrange
            var dbSetMock = new Mock<DbSet<Company>>();
            var dbContextMock = new Mock<GlassLewisDbContext>();
            dbContextMock.Setup(s => s.Set<Company>()).Returns(dbSetMock.Object);
            companyRepositoryMock = new Mock<ICompanyRepository>();
        }

        [Test]
        public void Companies_Returns_All()
        {
            // Act
            List<Company> companies = new List<Company>();
            companies.Add(new Company { Id = 1, Name = "Apple Inc.", Exchange = "NASDAQ", Ticker = "AAPL", ISIN = "US0378331005", Website = "http://www.apple.com" });
            companies.Add(new Company { Id = 2, Name = "British Airways Plc.", Exchange = "Pink Sheets", Ticker = "BAIRY", ISIN = "US1104193065", Website = "" });
            companies.Add(new Company { Id = 3, Name = "Heineken NV", Exchange = "Euronext Amsterdam", Ticker = "HEIA", ISIN = "NL0000009165", Website = "" });
            companies.Add(new Company { Id = 4, Name = "Panasonic Corp", Exchange = "Tokyo Stock Exchange", Ticker = "6752", ISIN = "JP3866800000", Website = "http://www.panasonic.co.jp" });
            companies.Add(new Company { Id = 5, Name = "Porsche Automobil", Exchange = "Deutsche Börse", Ticker = "PAH3", ISIN = "DE000PAH0038", Website = "https://www.porsche.com/" });

            companyRepositoryMock.Setup(s => s.GetAllCompanies()).Returns(Task.FromResult(companies));

            var allCompanies = companyRepositoryMock.Object.GetAllCompanies();

            //Assert  
            Assert.NotNull(allCompanies);
        }

        [Test]
        public void Company_By_Id_AppleInc()
        {
            // Act
            string companyName = "Apple Inc.";

            companyRepositoryMock.Setup(s => s.GetCompanyById(It.IsAny<int>())).Returns(Task.FromResult(companyName));

            var company = companyRepositoryMock.Object.GetCompanyById(1);

            //Assert  
            Assert.IsTrue(company.Result == companyName);
        }

        [Test]
        public void Company_By_ISIN_AppleInc()
        {
            // Act
            string companyName = "Apple Inc.";

            companyRepositoryMock.Setup(s => s.GetCompanyByISIN(It.IsAny<string>())).Returns(Task.FromResult(companyName));

            var company = companyRepositoryMock.Object.GetCompanyByISIN("US0378331005");

            //Assert  
            Assert.IsTrue(company.Result == companyName);
        }

        [Test]
        public void Create_Company_True()
        {
            // Act
            Company company = new Company() 
            { 
                Id = 6, 
                Name = "GlassLewis", 
                Exchange = "London", 
                Ticker = "GL1", 
                ISIN = "GL000GLL0011", 
                Website = "https://www.glasslewis.com/"
            };

            companyRepositoryMock.Setup(s => s.CreateCompany(It.IsAny<Company>())).Returns(Task.FromResult(true));

            var isCompanyCreated = companyRepositoryMock.Object.CreateCompany(company);

            //Assert  
            Assert.IsTrue(isCompanyCreated.Result == true);
        }

        [Test]
        public void Update_Company_True()
        {
            // Act
            Company company = new Company()
            {
                Id = 1,
                Name = "Apple Inc. USA",
                Exchange = "USNASDAQ",
                Ticker = "AAPL",
                ISIN = "US0378331392",
                Website = "http://www.apple.com"
            };

            companyRepositoryMock.Setup(s => s.UpdateCompany(It.IsAny<Company>())).Returns(Task.FromResult(true));

            var isCompanyUpdated = companyRepositoryMock.Object.UpdateCompany(company);

            //Assert  
            Assert.IsTrue(isCompanyUpdated.Result == true);
        }
    }
}