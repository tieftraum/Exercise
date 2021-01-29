using System.Collections.Generic;

namespace Exercise.Domain.Records
{
    public record Manufacturer
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public ICollection<Phone> Phones { get; init; }
        
    };
}