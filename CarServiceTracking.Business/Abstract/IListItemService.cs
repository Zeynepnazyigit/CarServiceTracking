using CarServiceTracking.Core.DTOs.ListItemDTOs;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Abstract
{
    public interface IListItemService
    {
        Task<IDataResult<List<ListItemListDTO>>> GetAllAsync();
        Task<IDataResult<List<ListItemListDTO>>> GetByTypeAsync(string listType);
        Task<IDataResult<ListItemDetailDTO>> GetByIdAsync(int id);
        Task<IDataResult<ListItemDetailDTO>> CreateAsync(ListItemCreateDTO dto);
        Task<IDataResult<ListItemDetailDTO>> UpdateAsync(ListItemUpdateDTO dto);
        Task<IResult> DeleteAsync(int id);
    }
}
