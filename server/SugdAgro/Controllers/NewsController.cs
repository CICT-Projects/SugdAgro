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
    [HttpGet]
    public async Task<ActionResult> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? lang = null,
        [FromQuery] int? categoryId = null)
    {
        var result = await _newsService.GetAllAsync(page, pageSize, lang, categoryId);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<NewsDto>> GetById(int id, [FromQuery] string? lang = null)
    {
        var news = await _newsService.GetByIdAsync(id, lang);
        if (news == null)
            return NotFound();
        return Ok(news);
    }

    [HttpGet("slug/{slug}")]
    public async Task<ActionResult<NewsDto>> GetBySlug(string slug, [FromQuery] string? lang = null)
    {
        var news = await _newsService.GetBySlugAsync(slug, lang);
        if (news == null)
            return NotFound();
        return Ok(news);
    }
    [HttpPost]
    public async Task<ActionResult<NewsDto>> Create([FromBody] CreateNewsDto dto)
    {
        var news = await _newsService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = news.Id }, news);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<NewsDto>> Update(int id, [FromBody] UpdateNewsDto dto)
    {
        var news = await _newsService.UpdateAsync(id, dto);
        if (news == null)
            return NotFound();
        return Ok(news);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _newsService.DeleteAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpPost("{id:int}/view")]
    public async Task<ActionResult> IncrementView(int id)
    {
        await _newsService.IncrementViewCountAsync(id);
        return Ok();
    }
}