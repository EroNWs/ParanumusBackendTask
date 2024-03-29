﻿using System.ComponentModel.DataAnnotations;

namespace ProductPerformance.Models;

public class UserLogin
{
    [Required(ErrorMessage = "Username is Required")]
    public string UserName { get; init; }

    [Required(ErrorMessage = "Password is Required")]
    public string Password { get; init; }
}
