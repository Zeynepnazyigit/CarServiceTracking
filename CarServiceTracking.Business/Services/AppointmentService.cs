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

                dto.CarInfo = await GetCarInfoAsync(appointment);

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

                dto.CarInfo = await GetCarInfoAsync(appointment);

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

                dto.CarInfo = await GetCarInfoAsync(appointment);

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

                dto.CarInfo = await GetCarInfoAsync(appointment);

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

            dto.CarInfo = await GetCarInfoAsync(appointment);
            return new SuccessDataResult<AppointmentDetailDTO>(dto, "Randevu başarıyla getirildi.");
        }

        public async Task<IDataResult<AppointmentDetailDTO>> CreateAsync(AppointmentCreateDTO dto)
        {
            var hasCar = dto.CarId.HasValue && dto.CarId.Value > 0;
            var hasCustomerCar = dto.CustomerCarId.HasValue && dto.CustomerCarId.Value > 0;
            if (!hasCar && !hasCustomerCar)
                return new ErrorDataResult<AppointmentDetailDTO>("Araç veya şahsi araç seçimi zorunludur.");

            var appointment = _mapper.Map<Appointment>(dto);
            appointment.Status = AppointmentStatus.Pending;

            if (hasCustomerCar)
            {
                appointment.CustomerCarId = dto.CustomerCarId;
                appointment.CarId = null;
            }
            else
            {
                appointment.CarId = dto.CarId!.Value;
                appointment.CustomerCarId = null;
            }

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

        private async Task<string> GetCarInfoAsync(Appointment appointment)
        {
            if (appointment.CustomerCarId.HasValue)
            {
                var cc = await _unitOfWork.CustomerCars.GetByIdAsync(appointment.CustomerCarId.Value);
                return cc != null ? $"{cc.BrandModel} - {cc.PlateNumber}" : "Bilinmiyor";
            }
            if (appointment.CarId.HasValue)
            {
                var car = await _unitOfWork.Cars.GetByIdAsync(appointment.CarId.Value);
                return car?.DisplayName ?? "Bilinmiyor";
            }
            return "Bilinmiyor";
        }
    }
}
