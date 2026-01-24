using Microsoft.AspNetCore.Mvc;
using SugdAgro.DTOs.News;
using SugdAgro.Services.Interfaces;

namespace SugdAgro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    // Endpoints будут добавлены в следующих задачах
}