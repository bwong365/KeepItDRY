using System;
using System.Collections.Generic;

namespace KeepItDRY.DAL.Entities
{
    public partial class Owner : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        List<Pet> Pets { get; set; }
    }
}
