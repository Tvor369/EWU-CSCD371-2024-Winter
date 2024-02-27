using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1);//Skip the header

        /*public IEnumerable<string> CsvRows => (IEnumerable<string>)File.ReadAllLines("People.csv")
            .Skip(1)//Skip the header
            .Select(x => x.Split(','))
            .Select(x => new
            {
                Id = int.Parse(x[0]),
                FirstName = x[1].ToString(),
                LastName = x[2].ToString(),
                Email = x[3].ToString(),
                StreetAddress = x[4].ToString(),
                City = x[5].ToString(),
                State = x[6].ToString(),
                Zip = x[7].ToString()
            });*/

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => throw new NotImplementedException();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
