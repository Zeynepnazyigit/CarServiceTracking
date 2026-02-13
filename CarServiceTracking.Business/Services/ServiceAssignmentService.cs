using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.ServiceAssignmentDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Services
{
    public class ServiceAssignmentService : IServiceAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceAssignmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<List<ServiceAssignmentListDTO>>> GetByServiceRequestIdAsync(int serviceRequestId)
        {
            var assignments = await _unitOfWork.ServiceAssignments
                .GetListAsync(x => x.ServiceRequestId == serviceRequestId);

            var dtoList = new List<ServiceAssignmentListDTO>();

            foreach (var a in assignments)
            {
                var mechanic = await _unitOfWork.Mechanics.GetByIdAsync(a.MechanicId);

                dtoList.Add(new ServiceAssignmentListDTO
                {
                    Id = a.Id,
                    ServiceRequestId = a.ServiceRequestId,
                    MechanicId = a.MechanicId,
                    MechanicName = mechanic?.FullName ?? "-",
                    Specialization = mechanic?.Specialization,
                    AssignedAt = a.AssignedAt,
                    StartedAt = a.StartedAt,
                    CompletedAt = a.CompletedAt,
                    EstimatedHours = a.EstimatedHours,
                    ActualHours = a.ActualHours,
                    Notes = a.Notes
                });
            }

            return new SuccessDataResult<List<ServiceAssignmentListDTO>>(dtoList);
        }

        public async Task<IResult> AssignAsync(ServiceAssignmentCreateDTO dto)
        {
            // Servis talebi kontrolu
            var serviceRequest = await _unitOfWork.ServiceRequests.GetByIdAsync(dto.ServiceRequestId);
            if (serviceRequest == null)
                return new ErrorResult("Servis talebi bulunamadi.");

            // Teknisyen kontrolu
            var mechanic = await _unitOfWork.Mechanics.GetByIdAsync(dto.MechanicId);
            if (mechanic == null)
                return new ErrorResult("Teknisyen bulunamadi.");

            // Ayni teknisyen zaten atanmis mi?
            var existing = await _unitOfWork.ServiceAssignments
                .GetListAsync(x => x.ServiceRequestId == dto.ServiceRequestId
                                && x.MechanicId == dto.MechanicId
                                && x.CompletedAt == null);

            if (existing.Any())
                return new ErrorResult("Bu teknisyen zaten bu talebe atanmis.");

            var entity = new ServiceAssignment
            {
                ServiceRequestId = dto.ServiceRequestId,
                MechanicId = dto.MechanicId,
                AssignedAt = DateTime.Now,
                EstimatedHours = dto.EstimatedHours,
                Notes = dto.Notes,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            await _unitOfWork.ServiceAssignments.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Teknisyen basariyla atandi.");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            var entity = await _unitOfWork.ServiceAssignments.GetByIdAsync(id);

            if (entity == null)
                return new ErrorResult("Atama bulunamadi.");

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Teknisyen atamasi kaldirildi.");
        }
    }
}
