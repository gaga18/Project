using Project.Core.Domain.Entities;
using Project.Core.Domain.Enums;
using System;

namespace Project.Infrastructure.Persistence.Seeds
{
    internal static class PersonSeed
    {
        internal static readonly Person[] Persons = new Person[]
        {
                new Person { Id = 1, FirstName = "FirstName1", LastName = "LastName1", PersonalID = "12345678912", BirthdayDate = DateTime.Now.AddYears(-18), City = 1, Gender = Gender.Male},
                new Person { Id = 2, FirstName = "FirstName2", LastName = "LastName2", PersonalID = "12345678913", BirthdayDate = DateTime.Now.AddYears(-18), City = 2, Gender = Gender.Male},
                new Person { Id = 3, FirstName = "FirstName3", LastName = "LastName3", PersonalID = "12345678914", BirthdayDate = DateTime.Now.AddYears(-18), City = 5, Gender = Gender.Male},
                new Person { Id = 4, FirstName = "FirstName4", LastName = "LastName4", PersonalID = "12345678915", BirthdayDate = DateTime.Now.AddYears(-18), City = 1, Gender = Gender.Female},
                new Person { Id = 5, FirstName = "FirstName5", LastName = "LastName5", PersonalID = "12345678916", BirthdayDate = DateTime.Now.AddYears(-20), City = 1, Gender = Gender.Female},
                new Person { Id = 6, FirstName = "FirstName6", LastName = "LastName6", PersonalID = "12345678917", BirthdayDate = DateTime.Now.AddYears(-18), City = 2, Gender = Gender.Female},
                new Person { Id = 7, FirstName = "FirstName7", LastName = "LastName7", PersonalID = "12345678918", BirthdayDate = DateTime.Now.AddYears(-23), City = 1, Gender = Gender.Female},
                new Person { Id = 8, FirstName = "FirstName8", LastName = "LastName8", PersonalID = "12345678919", BirthdayDate = DateTime.Now.AddYears(-18), City = 1, Gender = Gender.Male},
                new Person { Id = 9, FirstName = "FirstName9", LastName = "LastName9", PersonalID = "12345678929", BirthdayDate = DateTime.Now.AddYears(-50), City = 1, Gender = Gender.Male},
                new Person { Id = 10, FirstName = "FirstName10", LastName = "LastName10", PersonalID = "12345678929", BirthdayDate = DateTime.Now.AddYears(-40), City = 1, Gender = Gender.Male},
        };
    }
}
