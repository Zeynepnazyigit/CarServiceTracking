using AutoMapper;
using CarServiceTracking.Business.Abstract;
using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Core.DTOs.AppointmentDTOs;
using CarServiceTracking.Core.Entities;
using CarServiceTracking.Core.Enums;
using CarServiceTracking.Utilities.Results;

namespace CarServiceTracking.Business.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<AppointmentListDTO>>> GetAllAsync()
        {
            var appointments = await _unitOfWork.Appointments.GetAllAsync();
            var appointmentDtos = new List<AppointmentListDTO>();

            foreach (var appointment in appointments.OrderByDescending(x => x.AppointmentDate))
            {
                var dto = _mapper.Map<AppointmentListDTO>(appointment);
                
                var customer = await _unitOfWork.Customers.GetByIdAsync(appointment.CustomerId);
                dto.CustomerName = customer?.FullName ?? "Bilinmiyor";

                var car = await _unitOfWork.Cars.GetByIdAsync(appointment.CarId);
                dto.CarInfo = car?.DisplayName ?? "Bilinmiyor";

                appointmentDtos.Add(dto);
            }

            return new SuccessDataResult<List<AppointmentListDTO>>(appointmentDtos, "Randevular başarıyla listelendi.");
        }

        public async Task<IDataResult<List<AppointmentListDTO>>> GetByCustomerIdAsync(int customerId)
        {
            var appointments = await _unitOfWork.Appointments.GetListAsync(x => x.CustomerId == customerId);
            var appointmentDtos = new List<AppointmentListDTO>();

            foreach (var appointment in appointments.OrderByDescending(x => x.AppointmentDate))
            {
                var dto = _mapper.Map<AppointmentListDTO>(appointment);
                
                var customer = await _unitOfWork.Customers.GetByIdAsync(appointment.CustomerId);
                dto.CustomerName = customer?.FullName ?? "Bilinmiyor";

                var car = await _unitOfWork.Cars.GetByIdAsync(appointment.CarId);
                dto.CarInfo = car?.DisplayName ?? "Bilinmiyor";

                appointmentDtos.Add(dto);
            }

            return new SuccessDataResult<List<AppointmentListDTO>>(appointmentDtos, "Randevular başarıyla listelendi.");
        }

        public async Task<IDataResult<List<AppointmentListDTO>>> GetByDateAsync(DateTime date)
        {
            var appointments = await _unitOfWork.Appointments.GetListAsync(x => x.AppointmentDate.Date == date.Date);
            var appointmentDtos = new List<AppointmentListDTO>();

            foreach (var appointment in appointments.OrderBy(x => x.TimeSlot))
            {
                var dto = _mapper.Map<AppointmentListDTO>(appointment);
                
                var customer = await _unitOfWork.Customers.GetByIdAsync(appointment.CustomerId);
                dto.CustomerName = customer?.FullName ?? "Bilinmiyor";

                var car = await _unitOfWork.Cars.GetByIdAsync(appointment.CarId);
                dto.CarInfo = car?.DisplayName ?? "Bilinmiyor";

                appointmentDtos.Add(dto);
            }

            return new SuccessDataResult<List<AppointmentListDTO>>(appointmentDtos, "Randevular başarıyla listelendi.");
        }

        public async Task<IDataResult<List<AppointmentListDTO>>> GetByStatusAsync(AppointmentStatus status)
        {
            var appointments = await _unitOfWork.Appointments.GetListAsync(x => x.Status == status);
            var appointmentDtos = new List<AppointmentListDTO>();

            foreach (var appointment in appointments.OrderByDescending(x => x.AppointmentDate))
            {
                var dto = _mapper.Map<AppointmentListDTO>(appointment);
                
                var customer = await _unitOfWork.Customers.GetByIdAsync(appointment.CustomerId);
                dto.CustomerName = customer?.FullName ?? "Bilinmiyor";

                var car = await _unitOfWork.Cars.GetByIdAsync(appointment.CarId);
                dto.CarInfo = car?.DisplayName ?? "Bilinmiyor";

                appointmentDtos.Add(dto);
            }

            return new SuccessDataResult<List<AppointmentListDTO>>(appointmentDtos, "Randevular başarıyla listelendi.");
        }

        public async Task<IDataResult<AppointmentDetailDTO>> GetByIdAsync(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);

            if (appointment == null)
                return new ErrorDataResult<AppointmentDetailDTO>("Randevu bulunamadı.");

            var dto = _mapper.Map<AppointmentDetailDTO>(appointment);

            var customer = await _unitOfWork.Customers.GetByIdAsync(appointment.CustomerId);
            dto.CustomerName = customer?.FullName ?? "Bilinmiyor";
            dto.CustomerPhone = customer?.Phone ?? "Bilinmiyor";

            var car = await _unitOfWork.Cars.GetByIdAsync(appointment.CarId);
            dto.CarInfo = car?.DisplayName ?? "Bilinmiyor";

            return new SuccessDataResult<AppointmentDetailDTO>(dto, "Randevu başarıyla getirildi.");
        }

        public async Task<IDataResult<AppointmentDetailDTO>> CreateAsync(AppointmentCreateDTO dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);
            appointment.Status = AppointmentStatus.Pending;

            var createdAppointment = await _unitOfWork.Appointments.AddAsync(appointment);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetByIdAsync(createdAppointment.Id);
            return new SuccessDataResult<AppointmentDetailDTO>(result.Data, "Randevu başarıyla oluşturuldu.");
        }

        public async Task<IDataResult<AppointmentDetailDTO>> UpdateAsync(AppointmentUpdateDTO dto)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(dto.Id);

            if (appointment == null)
                return new ErrorDataResult<AppointmentDetailDTO>("Randevu bulunamadı.");

            _mapper.Map(dto, appointment);
            appointment.ModifiedDate = DateTime.Now;

            await _unitOfWork.Appointments.UpdateAsync(appointment);
            await _unitOfWork.SaveChangesAsync();

            var result = await GetByIdAsync(appointment.Id);
            return new SuccessDataResult<AppointmentDetailDTO>(result.Data, "Randevu başarıyla güncellendi.");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var success = await _unitOfWork.Appointments.DeleteAsync(id);

            if (!success)
                return new ErrorResult("Randevu silinemedi.");

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Randevu başarıyla silindi.");
        }

        public async Task<IResult> ConfirmAppointmentAsync(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);

            if (appointment == null)
                return new ErrorResult("Randevu bulunamadı.");

            appointment.Status = AppointmentStatus.Confirmed;
            appointment.ConfirmedAt = DateTime.Now;
            appointment.ModifiedDate = DateTime.Now;

            await _unitOfWork.Appointments.UpdateAsync(appointment);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Randevu onaylandı.");
        }

        public async Task<IResult> CancelAppointmentAsync(int id, string reason)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);

            if (appointment == null)
                return new ErrorResult("Randevu bulunamadı.");

            appointment.Status = AppointmentStatus.Cancelled;
            appointment.CancelledAt = DateTime.Now;
            appointment.CancellationReason = reason;
            appointment.ModifiedDate = DateTime.Now;

            await _unitOfWork.Appointments.UpdateAsync(appointment);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Randevu iptal edildi.");
        }
    }
}
