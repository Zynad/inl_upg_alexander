using WebApi.Models.DTO;
using WebApi.Repositories;

namespace WebApi.Services;

public class ShowCaseService
{
    private readonly ShowCaseRepo _showCaseRepo;

    public ShowCaseService(ShowCaseRepo showCaseRepo)
    {
        _showCaseRepo = showCaseRepo;
    }
    public async Task<bool> RegisterAsync(CreateShowCaseDTO dto)
    {
        try
        {
            await _showCaseRepo.AddAsync(dto);
            return true;
        }
        catch { }

        return false;
        
    }

    public async Task<ShowCaseDTO> GetLatestShowCaseAsync()
    {
        var showCases = await _showCaseRepo.GetAllAsync();
        var latestShowCase = showCases.MaxBy(x => x.Id);
        ShowCaseDTO dto = latestShowCase!;
        return dto;
    }

    public async Task<IEnumerable<ShowCaseDTO>> GetAllShowCasesAsync()
    {
        var dtoList = new List<ShowCaseDTO>();

        var showCases = await _showCaseRepo.GetAllAsync();

        foreach (var showCase in showCases)
        {
            ShowCaseDTO dto = showCase;
            dtoList.Add(dto);
        }
        return dtoList;
    }
}
