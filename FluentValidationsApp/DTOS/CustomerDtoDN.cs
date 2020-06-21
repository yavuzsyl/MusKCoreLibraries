using System;

namespace FluentValidationsApp.DTOS
{
    public class CustomerDtoDN
    {

        public int Id { get; set; }
        public string KnownFor { get; set; }
        public string Contact { get; set; }
        public int YearsOld { get; set; }
        public string FullInfo { get; set; }

        public string CCName { get; set; }
        public DateTime CCValidDate { get; set; }
    }
}