using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Exercise.Domain.CRUD.User
{
    public record ReadUser(string Username, string Token);
    
    //Register
    public record CreateUser([Required] string Username, [MinLength(6)] [Required] string Password,
        [Required] string Gender, [Required] DateTime DateOfBirth,
        [Required] string City, [Required] string Country);
    
    //login
    public record LoginUser([Required] string Username, [Required] string Password);
}