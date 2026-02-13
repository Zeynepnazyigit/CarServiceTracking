using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.MechanicDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Services
{
    public class MechanicService : IMechanicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MechanicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<MechanicListDTO>>> GetAllAsync()
        {
            var mechanics = await _unitOfWork.Mechanics.GetAllAsync();
            var mechanicDtos = new List<MechanicListDTO>();

            foreach (var mechanic in mechanics.OrderBy(x => x.FirstName))
            {
                var dto = _mapper.Map<MechanicListDTO>(mechanic);
                dto.FullName = mechanic.FullName;

                var assignments = await _unitOfWork.ServiceAssignments.GetListAsync(x => x.MechanicId == mechanic.Id);
                dto.ActiveAssignments = assignments.Count(x => x.CompletedAt == null);
                dto.IsAvailable = dto.ActiveAssignments == 0;

                mechanicDtos.Add(dto);
            }

            return new SuccessDataResult<List<MechanicListDTO>>(mechanicDtos, "Ustalar başarıyla listelendi.");
        }

        public async Task<IDataResult<List<MechanicListDTO>>> GetAvailableMechanicsAsync()
        {
            var mechanics = await _unitOfWork.Mechanics.GetAllAsync();
            var mechanicDtos = new List<MechanicListDTO>();

            foreach (var mechanic in mechanics.OrderBy(x => x.FirstName))
            {
                var assignments = await _unitOfWork.ServiceAssignments.GetListAsync(x => x.MechanicId == mechanic.Id);
                var activeAssignments = assignments.Count(x => x.CompletedAt == null);

                if (activeAssignments == 0)
                {
                    var dto = _mapper.Map<MechanicListDTO>(mechanic);
                    dto.FullName = mechanic.FullName;
                    dto.ActiveAssignments = 0;

                    mechanicDtos.Add(dto);
                }
            }

            return new SuccessDataResult<List<MechanicListDTO>>(mechanicDtos, "Müsait ustalar başarıyla listelendi.");
        }

        public async Task<IDataResult<List<MechanicListDTO>>> GetBySpecializationAsync(string specialization)
        {
            var mechanics = await _unitOfWork.Mechanics.GetListAsync(x => x.Specialization == specialization);
            var mechanicDtos = new List<MechanicListDTO>();

            foreach (var mechanic in mechanics.OrderBy(x => x.FirstName))
            {
                var dto = _mapper.Map<MechanicListDTO>(mechanic);
                dto.FullName = mechanic.FullName;

                var assignments = await _unitOfWork.ServiceAssignments.GetListAsync(x => x.MechanicId == mechanic.Id);
                dto.ActiveAssignments = assignments.Count(x => x.CompletedAt == null);
                dto.IsAvailable = dto.ActiveAssignments == 0;

                mechanicDtos.Add(dto);
            }

            return new SuccessDataResult<List<MechanicListDTO>>(mechanicDtos, "Ustalar başarıyla listelendi.");
        }

        public async Task<IDataResult<MechanicDetailDTO>> GetByIdAsync(int id)
        {
            var mechanic = await _unitOfWork.Mechanics.GetByIdAsync(id);

            if (mechanic == null)
                return new ErrorDataResult<MechanicDetailDTO>("Usta bulunamadı.");

            var dto = _mapper.Map<MechanicDetailDTO>(mechanic);
            dto.FullName = mechanic.FullName;

            return new SuccessDataResult<MechanicDetailDTO>(dto, "Usta başarıyla getirildi.");
        }

        public async Task<IDataResult<MechanicDetailDTO>> CreateAsync(MechanicCreateDTO dto)
        {
            var existingMechanic = await _unitOfWork.Mechanics.GetAsync(x => x.Email == dto.Email);
            if (existingMechanic != null)
                return new ErrorDataResult<MechanicDetailDTO>("Bu email adresi zaten kayıtlı.");

            var mechanic = _mapper.Map<Mechanic>(dto);

            var createdMechanic = await _unitOfWork.Mechanics.AddAsync(mechanic);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetByIdAsync(createdMechanic.Id);
            return new SuccessDataResult<MechanicDetailDTO>(result.Data, "Usta başarıyla oluşturuldu.");
        }

        public async Task<IDataResult<MechanicDetailDTO>> UpdateAsync(MechanicUpdateDTO dto)
        {
            var mechanic = await _unitOfWork.Mechanics.GetByIdAsync(dto.Id);

            if (mechanic == null)
                return new ErrorDataResult<MechanicDetailDTO>("Usta bulunamadı.");

            var existingMechanic = await _unitOfWork.Mechanics.GetAsync(x => x.Email == dto.Email && x.Id != dto.Id);
            if (existingMechanic != null)
                return new ErrorDataResult<MechanicDetailDTO>("Bu email adresi başka bir usta tarafından kullanılıyor.");

            _mapper.Map(dto, mechanic);
            mechanic.ModifiedDate = DateTime.Now;

            await _unitOfWork.Mechanics.UpdateAsync(mechanic);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetByIdAsync(mechanic.Id);
            return new SuccessDataResult<MechanicDetailDTO>(result.Data, "Usta başarıyla güncellendi.");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var success = await _unitOfWork.Mechanics.DeleteAsync(id);

            if (!success)
                return new ErrorResult("Usta silinemedi.");

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Usta başarıyla silindi.");
        }
    }
}
