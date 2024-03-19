using BookStore.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Shared.BaseController;

public class CustomBaseController : ControllerBase
{
    public IActionResult CreateActionResultInstance<T>(Response<T> response)
    {

        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };

    }


}