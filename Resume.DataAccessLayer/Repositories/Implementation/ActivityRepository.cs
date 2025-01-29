using Microsoft.EntityFrameworkCore;
using Resume.DataAccessLayer.Context;
using Resume.DataAccessLayer.Models.Activity;
using Resume.DataAccessLayer.Repositories.Inteface;
using Resume.DataAccessLayer.ViewModels.Activity;

namespace Resume.DataAccessLayer.Repositories.Implementation;

public class ActivityRepository : IActivityRepository
{
    #region Fields
    private readonly ResumeContext _context;
    #endregion

    #region Custractor
    public ActivityRepository(ResumeContext context)
    {
        _context = context;
    }
    #endregion

    #region Methods
    public async Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model)
    {
        var query = _context.Activities.AsQueryable();

        #region Filter

        if (!string.IsNullOrEmpty(model.Title))
            query = query.Where(a => EF.Functions.Like(a.Title, $"%{model.Title}%"));

        #endregion

        #region OrderBy

        query= query.OrderByDescending(a => a.CreateDate);

        #endregion

        #region Paging

        await model.Paging(query.Select(a => new ActivityDetailsViewModel()
        {
            CreateDate = a.CreateDate,
            Description = a.Description,
            Icon = a.Icon,
            Id = a.Id,
            Title = a.Title
        }));

        #endregion

        return model;
    }

    public async Task<List<ActivityDetailsViewModel>> GetAllInfo()
    {
        return await _context.Activities
            .Select(a => new ActivityDetailsViewModel()
            {
                CreateDate = a.CreateDate,
                Description = a.Description,
                Title = a.Title,
                Icon = a.Icon,
                Id = a.Id
            })
            .ToListAsync();
    }

    public async Task<Activity?> GetByIdAsync(int id)
    {
         return await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<EditActivityViewModel?> GetInfoByIdAsync(int id)
    {
        return await _context.Activities
            .Select(a => new EditActivityViewModel()
            {
                Description = a.Description,
                Icon = a.Icon,
                Title = a.Title,
                Id = a.Id
            }).FirstOrDefaultAsync(a=>a.Id==id);
    }

    public async Task InsertAsync(Activity activity)
    {
        await _context.AddAsync(activity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Activity activity)
    {
        _context.Activities.Update(activity);
    }

    #endregion

}