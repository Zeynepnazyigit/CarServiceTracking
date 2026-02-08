using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.PartDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Services
{
    public class PartService : IPartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<PartListDTO>>> GetAllAsync()
        {
            var parts = await _unitOfWork.Parts.GetAllAsync();
            var partDtos = _mapper.Map<List<PartListDTO>>(parts.OrderBy(x => x.PartName).ToList());
            return new SuccessDataResult<List<PartListDTO>>(partDtos, "Parçalar başarıyla listelendi.");
        }

        public async Task<IDataResult<List<PartListDTO>>> GetLowStockPartsAsync()
        {
            var parts = await _unitOfWork.Parts.GetAllAsync();
            var lowStockParts = parts.Where(x => x.StockQuantity <= x.MinStockLevel).OrderBy(x => x.StockQuantity).ToList();
            var partDtos = _mapper.Map<List<PartListDTO>>(lowStockParts);
            return new SuccessDataResult<List<PartListDTO>>(partDtos, "Düşük stoklu parçalar listelendi.");
        }

        public async Task<IDataResult<List<PartListDTO>>> GetByCategoryAsync(string category)
        {
            var parts = await _unitOfWork.Parts.GetListAsync(x => x.Category == category);
            var partDtos = _mapper.Map<List<PartListDTO>>(parts.OrderBy(x => x.PartName).ToList());
            return new SuccessDataResult<List<PartListDTO>>(partDtos, "Parçalar başarıyla listelendi.");
        }

        public async Task<IDataResult<PartDetailDTO>> GetByIdAsync(int id)
        {
            var part = await _unitOfWork.Parts.GetByIdAsync(id);

            if (part == null)
                return new ErrorDataResult<PartDetailDTO>("Parça bulunamadı.");

            var partDto = _mapper.Map<PartDetailDTO>(part);
            return new SuccessDataResult<PartDetailDTO>(partDto, "Parça başarıyla getirildi.");
        }

        public async Task<IDataResult<PartDetailDTO>> GetByPartCodeAsync(string partCode)
        {
            var part = await _unitOfWork.Parts.GetAsync(x => x.PartCode == partCode);

            if (part == null)
                return new ErrorDataResult<PartDetailDTO>("Parça bulunamadı.");

            var partDto = _mapper.Map<PartDetailDTO>(part);
            return new SuccessDataResult<PartDetailDTO>(partDto, "Parça başarıyla getirildi.");
        }

        public async Task<IDataResult<PartDetailDTO>> CreateAsync(PartCreateDTO dto)
        {
            var existingPart = await _unitOfWork.Parts.GetAsync(x => x.PartCode == dto.PartCode);
            if (existingPart != null)
                return new ErrorDataResult<PartDetailDTO>("Bu parça kodu zaten mevcut.");

            var part = _mapper.Map<Part>(dto);
            var createdPart = await _unitOfWork.Parts.AddAsync(part);
            await _unitOfWork.SaveChangesAsync();

            var partDto = _mapper.Map<PartDetailDTO>(createdPart);
            return new SuccessDataResult<PartDetailDTO>(partDto, "Parça başarıyla oluşturuldu.");
        }

        public async Task<IDataResult<PartDetailDTO>> UpdateAsync(PartUpdateDTO dto)
        {
            var part = await _unitOfWork.Parts.GetByIdAsync(dto.Id);

            if (part == null)
                return new ErrorDataResult<PartDetailDTO>("Parça bulunamadı.");

            var existingPart = await _unitOfWork.Parts.GetAsync(x => x.PartCode == dto.PartCode && x.Id != dto.Id);
            if (existingPart != null)
                return new ErrorDataResult<PartDetailDTO>("Bu parça kodu zaten başka bir parçada kullanılıyor.");

            _mapper.Map(dto, part);
            part.ModifiedDate = DateTime.Now;

            var updatedPart = await _unitOfWork.Parts.UpdateAsync(part);
            await _unitOfWork.SaveChangesAsync();

            var partDto = _mapper.Map<PartDetailDTO>(updatedPart);
            return new SuccessDataResult<PartDetailDTO>(partDto, "Parça başarıyla güncellendi.");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var success = await _unitOfWork.Parts.DeleteAsync(id);

            if (!success)
                return new ErrorResult("Parça silinemedi.");

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Parça başarıyla silindi.");
        }

        public async Task<IResult> UpdateStockAsync(int partId, int quantity)
        {
            var part = await _unitOfWork.Parts.GetByIdAsync(partId);

            if (part == null)
                return new ErrorResult("Parça bulunamadı.");

            part.StockQuantity += quantity;
            part.ModifiedDate = DateTime.Now;

            await _unitOfWork.Parts.UpdateAsync(part);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult($"Stok güncellendi. Yeni miktar: {part.StockQuantity}");
        }
    }
}
