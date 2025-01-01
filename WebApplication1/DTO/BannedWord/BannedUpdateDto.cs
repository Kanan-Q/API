using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.DataAccess;
using WebApplication1.DTO.Games;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.DTO.BannedWord
{
    public class BannedUpdateDto
    {

        public int Id { get; set; }
        public string Text { get; set; }
    }
}
