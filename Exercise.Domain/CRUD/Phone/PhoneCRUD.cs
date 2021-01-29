using System;

namespace Exercise.Domain.CRUD.Phone
{
    public record ReadPhone(int Id, DateTime Created, string ModelName, string Color, decimal Price);
    public record CreatePhone(DateTime Created, string ModelName, string Color, int ManufacturerId, decimal Price);
    public record UpdatePhone(string ModelName, string Color, decimal Price);
}