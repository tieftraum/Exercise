using System;
using System.Collections.Generic;

namespace Exercise.Domain.Records
{
    public record Phone(int Id, DateTime Created, string ModelName, Manufacturer Manufacturer, int ManufacturerId, decimal Price, string Color);
    public record Manufacturer(int Id, string Name, ICollection<Phone> Phones);
}
