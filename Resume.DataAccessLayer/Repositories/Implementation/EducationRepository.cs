using Microsoft.EntityFrameworkCore;
using Resume.DataAccessLayer.Context;
using Resume.DataAccessLayer.Models.Education;
using Resume.DataAccessLayer.Repositories.Inteface;
using Resume.DataAccessLayer.ViewModels.Education;

namespace Resume.DataAccessLayer.Repositories.Implementation;

public class EducationRepository : IEducationRepository
{
    #region fields

    private readonly ResumeContext _context;

    #endregion

    #region Cunstractor

    public EducationRepository(ResumeContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model)
    {
        var query = _context.Educations.AsQueryable();

        #region Filter

        if (!string.IsNullOrEmpty(model.Title))
        {
            query = query.Where(s => s.Title.Contains(model.Title));
        }

        if (model.Start.HasValue)
        {
            query = query.Where(s => s.Start >= model.Start.Value);
        }

        if (model.End.HasValue)
        {
            query = query.Where(s => s.End <= model.End.Value);
        }

        #endregion

        query = query.OrderByDescending(e => e.CreateDate);

        #region Pagination

        await model.Paging(query.Select(e => new EducationViewModel()
        {
            CreateDate = e.CreateDate,
            Description = e.Description,
            Title = e.Title,
            End = e.End,
            Start = e.Start,
            Id = e.Id
        }));

        #endregion

        return model;
    }

    public async Task InsertAsync(Education education)
    {
        await _context.Educations.AddAsync(education);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Education> GetByIdAsync(int id)
    {
        return await _context.Educations
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public void Update(Education education)
    {
        _context.Educations.Update(education);
    }

    public async Task<EditEducationViewModel> GetForEditByIdAsync(int id)
    {
        return await _context.Educations
            .Select(e => new EditEducationViewModel
            {
                Id = e.Id,
                Title = e.Title,
                Start = e.Start,
                End = e.End,
                Description = e.Description
            })
            .FirstOrDefaultAsync(e => e.Id == id);
    }
    #endregion
}

