using Application.Dtos;
using Application.Features.Request.Commands.ContactCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace AppUnitTest
{
    public class ApplicationUnitTest
    {
        private readonly ContactController _contactController;
        private readonly Mock<IMediator> _mediatorMoq;
        public ApplicationUnitTest()
        {
            _mediatorMoq = new Mock<IMediator>();
            _contactController = new ContactController(_mediatorMoq.Object);
        }
        
        [Fact]
        public void Add_Contact_With_Detail_Test()
        {
            var contact_one = new AddContactWithDetailCommand()
            {
                ContactWithContactDetailList = new ContactWithContactDetailListDto()
                {
                    Contact = new ContactDto()
                    {
                        Name = "enes",
                        Surname = "aydos",
                        Company = "free",
                        ContactDetailIdList = new List<string>()
                    },
                    ContactDetailList = new List<ContactDetailDto>()
                    {
                        new ContactDetailDto()
                        {
                            Location = "umraniye",
                            Email = "a@a.com",
                            Phone = "5555555555",
                            ContactId = null
                        }
                    }
                }
            };
            var result_one = _contactController.AddContactWithDetail(contact_one);
            Assert.NotNull(result_one);
            Assert.IsType<Task<IActionResult>>(result_one);

            var contact_two = new AddContactWithDetailCommand()
            {
                ContactWithContactDetailList = new ContactWithContactDetailListDto()
                {
                    Contact = new ContactDto()
                    {
                        Name = "ali",
                        Surname = "veli",
                        Company = "free",
                        ContactDetailIdList = new List<string>()
                    },
                    ContactDetailList = new List<ContactDetailDto>()
                    {
                        new ContactDetailDto()
                        {
                            Location = "umraniye",
                            Email = "b@b.com",
                            Phone = "5555555554",
                            ContactId = null
                        }
                    }
                }
            };
            var result_two = _contactController.AddContactWithDetail(contact_two);
            Assert.NotNull(result_two);
            Assert.IsType<Task<IActionResult>>(result_two);

            var contact_three = new AddContactWithDetailCommand()
            {
                ContactWithContactDetailList = new ContactWithContactDetailListDto()
                {
                    Contact = new ContactDto()
                    {
                        Name = "ahmet",
                        Surname = "mehmet",
                        Company = "free",
                        ContactDetailIdList = new List<string>()
                    },
                    ContactDetailList = new List<ContactDetailDto>()
                    {
                        new ContactDetailDto()
                        {
                            Location = "kadikoy",
                            Email = "c@c.com",
                            Phone = "5555555553",
                            ContactId = null
                        }
                    }
                }
            };
            var result_three = _contactController.AddContactWithDetail(contact_three);
            Assert.NotNull(result_three);
            Assert.IsType<Task<IActionResult>>(result_three);

            var contact_four = new AddContactWithDetailCommand()
            {
                ContactWithContactDetailList = new ContactWithContactDetailListDto()
                {
                    Contact = new ContactDto()
                    {
                        Name = "ayse",
                        Surname = "fatma",
                        Company = "free",
                        ContactDetailIdList = new List<string>()
                    },
                    ContactDetailList = new List<ContactDetailDto>()
                    {
                        new ContactDetailDto()
                        {
                            Location = "atasehir",
                            Email = "d@d.com",
                            Phone = "5555555552",
                            ContactId = null
                        }
                    }
                }
            };
            var result_four = _contactController.AddContactWithDetail(contact_four);
            Assert.NotNull(result_four);
            Assert.IsType<Task<IActionResult>>(result_four);

            var contact_five = new AddContactWithDetailCommand()
            {
                ContactWithContactDetailList = new ContactWithContactDetailListDto()
                {
                    Contact = new ContactDto()
                    {
                        Name = "alex",
                        Surname = "de souza",
                        Company = "free",
                        ContactDetailIdList = new List<string>()
                    },
                    ContactDetailList = new List<ContactDetailDto>()
                    {
                        new ContactDetailDto()
                        {
                            Location = "kadikoy",
                            Email = "e@e.com",
                            Phone = "5555555551",
                            ContactId = null
                        }
                    }
                }
            };
            var result_five = _contactController.AddContactWithDetail(contact_five);
            Assert.NotNull(result_five);
            Assert.IsType<Task<IActionResult>>(result_five);
        }
    }
}
