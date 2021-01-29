using System;

namespace Exercise.Domain.Records
{
    public record Phone
    {

        public int Id { get;init; }
        public DateTime Created { get;init; }
        public string ModelName { get;init; }
        public string Color { get;init; }
        public Manufacturer Manufacturer { get;init; }      
        public int ManufacturerId { get;init; }
        public decimal Price { get;init; }
    }
}