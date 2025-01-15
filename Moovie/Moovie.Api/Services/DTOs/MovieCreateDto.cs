using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moovie.Api.Services.DTOs;

public class MovieCreateDto : BaseMovieDto
{
    public long BoxOfficeEarnings { get; set; }
}
