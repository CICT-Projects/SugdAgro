using Microsoft.EntityFrameworkCore;
using SugdAgro.Data;
using SugdAgro.DTOs.Common;
using SugdAgro.DTOs.News;
using SugdAgro.Models;
using SugdAgro.Services.Interfaces;

namespace SugdAgro.Services;

public class NewsService : INewsService
{
    private readonly ApplicationDbContext _context;

    public NewsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<NewsListDto>> GetAllAsync(
        int page = 1, int pageSize = 10, string? lang = null, int? categoryId = null)
    {
        var query = _context.News
            .Include(n => n.Category)
            .Where(n => n.IsPublished)
            .AsQueryable();

        if (categoryId.HasValue)
            query = query.Where(n => n.CategoryId == categoryId);

        var totalCount = await query.CountAsync();
        
        var items = await query
            .OrderByDescending(n => n.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(n => new NewsListDto
            {
                Id = n.Id,
                Title = lang == "tg" ? n.TitleTg : n.TitleRu,
                Slug = n.Slug,
                ImageUrl = n.ImageUrl,
                CategoryName = lang == "tg" ? n.Category!.NameTg : n.Category!.NameRu,
                CreatedAt = n.CreatedAt
            })
            .ToListAsync();

        return new PagedResult<NewsListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    // TODO: Реализовать остальные методы
}