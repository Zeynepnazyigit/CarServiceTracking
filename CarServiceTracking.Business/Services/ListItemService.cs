using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.ListItemDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Services
{
    public class ListItemService : IListItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<ListItemListDTO>>> GetAllAsync()
        {
            var listItems = await _unitOfWork.ListItems.GetAllAsync();
            var listItemDtos = _mapper.Map<List<ListItemListDTO>>(listItems.OrderBy(x => x.ListType).ThenBy(x => x.SortOrder).ToList());
            return new SuccessDataResult<List<ListItemListDTO>>(listItemDtos, "Liste öğeleri başarıyla getirildi.");
        }

        public async Task<IDataResult<List<ListItemListDTO>>> GetByTypeAsync(string listType)
        {
            var listItems = await _unitOfWork.ListItems.GetListAsync(x => x.ListType == listType);
            var listItemDtos = _mapper.Map<List<ListItemListDTO>>(listItems.OrderBy(x => x.SortOrder).ToList());
            return new SuccessDataResult<List<ListItemListDTO>>(listItemDtos, "Liste öğeleri başarıyla getirildi.");
        }

        public async Task<IDataResult<ListItemDetailDTO>> GetByIdAsync(int id)
        {
            var listItem = await _unitOfWork.ListItems.GetByIdAsync(id);

            if (listItem == null)
                return new ErrorDataResult<ListItemDetailDTO>("Liste öğesi bulunamadı.");

            var listItemDto = _mapper.Map<ListItemDetailDTO>(listItem);

            // Parent name
            if (listItem.ParentId.HasValue)
            {
                var parent = await _unitOfWork.ListItems.GetByIdAsync(listItem.ParentId.Value);
                listItemDto.ParentName = parent?.Name;
            }

            return new SuccessDataResult<ListItemDetailDTO>(listItemDto, "Liste öğesi başarıyla getirildi.");
        }

        public async Task<IDataResult<ListItemDetailDTO>> CreateAsync(ListItemCreateDTO dto)
        {
            var listItem = _mapper.Map<ListItem>(dto);
            var createdListItem = await _unitOfWork.ListItems.AddAsync(listItem);
            await _unitOfWork.SaveChangesAsync();

            var listItemDto = _mapper.Map<ListItemDetailDTO>(createdListItem);
            return new SuccessDataResult<ListItemDetailDTO>(listItemDto, "Liste öğesi başarıyla oluşturuldu.");
        }

        public async Task<IDataResult<ListItemDetailDTO>> UpdateAsync(ListItemUpdateDTO dto)
        {
            var listItem = await _unitOfWork.ListItems.GetByIdAsync(dto.Id);

            if (listItem == null)
                return new ErrorDataResult<ListItemDetailDTO>("Liste öğesi bulunamadı.");

            _mapper.Map(dto, listItem);
            listItem.ModifiedDate = DateTime.Now;

            var updatedListItem = await _unitOfWork.ListItems.UpdateAsync(listItem);
            await _unitOfWork.SaveChangesAsync();

            var listItemDto = _mapper.Map<ListItemDetailDTO>(updatedListItem);
            return new SuccessDataResult<ListItemDetailDTO>(listItemDto, "Liste öğesi başarıyla güncellendi.");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var success = await _unitOfWork.ListItems.DeleteAsync(id);

            if (!success)
                return new ErrorResult("Liste öğesi silinemedi.");

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Liste öğesi başarıyla silindi.");
        }
    }
}
