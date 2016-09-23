using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.Model
{
    public class Person : BaseModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }

        public BankingWebAPI2.Models.Person ToWebApiModel()
        {
            return new BankingWebAPI2.Models.Person() { Id = this.Id, FirstName = this.FirstName, LastName = this.LastName, IdNumber = this.IdNumber };
        }

        public void FromWebApiModel(BankingWebAPI2.Models.Person person)
        {
            this.Id = person.Id;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.IdNumber = person.IdNumber;
        }
    }


}
