﻿using Microsoft.AspNetCore.Identity;
using ProductIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductIdentity.Infrastracture.Interface;

public interface IAuthenticationRepository
{
    Task<IdentityResult> RegisterUser(User user);
}
